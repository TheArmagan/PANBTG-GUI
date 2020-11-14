﻿using PANBTG_GUI.Forms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PANBTG_GUI
{
    public partial class MainForm : Form
    {
        static string FOR_VERSION = "1.2.1";

        public MainForm()
        {
            InitializeComponent();
            controlPanel.Visible = false;
            resizingMethod1NumericInput.Visible = false;
            resizingMethod2NumericInput.Visible = false;
            resizingMethod1NumericInput.Maximum = decimal.MaxValue;
            resizingMethod2NumericInput.Maximum = decimal.MaxValue;
            resizingMethodXLabel.Visible = false;
            ditheringValueNumericInput.Visible = false;
            ditheringValueNumericInput.Maximum = new decimal(10);
            ditheringValueNumericInput.Minimum = new decimal(1);
            ditheringValueNumericInput.Value = new decimal(1);
            customScaffoldBlockInputPanel.Visible = false;
            resultCommandTextBox.Enabled = false;
            runResultCommandButton.Enabled = false;
            nearestNeighborCheckBox.Visible = false;
            preprocessingEffectsSetValueItemButton.Visible = false;
            directionXPanel.Visible = false;
            directionZPanel.Visible = false;

            openFileButton.ForeColor = Color.Lime;

            preprocessingEffectsListBox.Items.Add("[OFF]: Grayscale");
            preprocessingEffectsListBox.Items.Add("[OFF]: Deepfry");
            preprocessingEffectsListBox.Items.Add("[OFF]: Invert");
            preprocessingEffectsListBox.Items.Add("[OFF]: Brightness:50 <-100/100>");
            preprocessingEffectsListBox.Items.Add("[OFF]: Contrast:50 <-100/100>");

            preprocessingEffectsListBox.SelectedIndex = 0;

            forVersionLabel.Text = $"for v{FOR_VERSION}";

            statusTextTextBox.Text = "Please select an image.";
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image File|*.jpg;*.jpeg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    openFileButton.ForeColor = Color.White;
                    inputImagePathTextBox.Text = dialog.FileName;
                    controlPanel.Visible = true;
                    runResultCommandButton.Enabled = true;
                    FileInfo fileInfo = new FileInfo(dialog.FileName);
                    int[] imgWH = getImageWidthAndHeight(dialog.FileName);
                    fileSizeInfoLabel.Text = $"{imgWH[0]}x{imgWH[1]} ({Math.Round((double)(fileInfo.Length / 1024))}kb)";
                    fileInfo = null;
                    statusTextTextBox.Text = "Enable the what options you want!";
                    resultCommandTextBox.Enabled = true;
                }
                else 
                {
                    openFileButton.ForeColor = Color.Lime;
                    inputImagePathTextBox.Text = "";
                    controlPanel.Visible = false;
                    runResultCommandButton.Enabled = false;
                    fileSizeInfoLabel.Text = "0x0 (0kb)";
                    statusTextTextBox.Text = "Please select an image.";
                    resultCommandTextBox.Enabled = false;
                }
                genCmd();
            }
            GC.Collect();
        }

        public void genCmd()
        {
            int[] imgSize = getImageWidthAndHeight(inputImagePathTextBox.Text);
            bool isValidScale = (float)resizingMethod2NumericInput.Value != 1;
            bool isValidResize = !((int)resizingMethod1NumericInput.Value == imgSize[0] && (int)resizingMethod2NumericInput.Value == imgSize[1]);
            if (!String.IsNullOrEmpty(inputImagePathTextBox.Text)) {
                string resultCmd = "PANBTG.exe";

                resultCmd += $" --input \"{inputImagePathTextBox.Text}\"";

                //Console.WriteLine("SCALE " + resizingMethod2NumericInput.Value + " " + isValidScale);
                //Console.WriteLine("RESIZE " + resizingMethod1NumericInput.Value + " " + resizingMethod2NumericInput.Value  + " "+ isValidResize);

                if (resizingMethodComboBox.SelectedIndex == 1 && isValidScale)
                    resultCmd += $" --scale {resizingMethod2NumericInput.Value.ToString().Replace(",", ".")}";

                if (resizingMethodComboBox.SelectedIndex == 2 && isValidResize) 
                    resultCmd += $" --resize {resizingMethod1NumericInput.Value}x{resizingMethod2NumericInput.Value}";

                if (resizingMethodComboBox.SelectedIndex != 0 && nearestNeighborCheckBox.Checked && ((resizingMethodComboBox.SelectedIndex == 1 && isValidScale) || (resizingMethodComboBox.SelectedIndex == 2 && isValidResize)))
                    resultCmd += $" --nearest-neighbor";

                if (isUsingDitheringCheckBox.Checked)
                    resultCmd += $" --dither {ditheringValueNumericInput.Value}";

                if (isCustomDirectionEnabledCheckBox.Checked)
                    resultCmd += $" --direction {directionXTextBox.Text},{directionZTextBox.Text}";

                if (isCustomScaffoldCheckBox.Checked)
                    resultCmd += $" --scaffold-block {customScaffoldBlockTextBox.Text.Replace(" ", ":")}";

                if (isFullScaffoldEanbledCheckBox.Checked)
                    resultCmd += $" --full-scaffold";

                if (isVerticalCheckBox.Checked)
                    resultCmd += $" --vertical";

                {

                    string enabledEffects = "";

                    for (int i = 0; i < preprocessingEffectsListBox.Items.Count; i++)
                    {
                        string val = preprocessingEffectsListBox.Items[i] as string;
                        string[] valSplitted1 = val.Split(new string[] { ": " }, StringSplitOptions.None);
                        string[] _effectNameAndPower = valSplitted1[1].Split(' ')[0].Trim().Split(':');
                        string[] effectNameAndPower = new string[2];

                        for (int j = 0; j < _effectNameAndPower.Length; j++)
                        {
                            effectNameAndPower[j] = _effectNameAndPower[j];
                        }
                        

                        if (valSplitted1[0].Contains("ON") && effectNameAndPower[1] != "0")
                        {
                            enabledEffects += $"{(enabledEffects.Length != 0 ? "," : "")}{effectNameAndPower[0].ToLowerInvariant()}{(!String.IsNullOrWhiteSpace(effectNameAndPower[1]) ? ":" + effectNameAndPower[1] : "")}";
                        }
                    }

                    if (enabledEffects.Length != 0)
                    {
                        resultCmd += $" --effects {enabledEffects}";
                    }

                }

                if (isOnlyPreprocess.Checked)
                    resultCmd += " --only-preprocess";

                resultCommandTextBox.Text = resultCmd;
            } else
            {
                resultCommandTextBox.Text = "PANBTG.exe";
            }

            resultCommandTextBox.SelectionStart = resultCommandTextBox.Text.Length;
            resultCommandTextBox.ScrollToCaret();

        }

        private void resizingMethodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateResizingMethod(resizingMethodComboBox.SelectedIndex);
            genCmd();
        }

        private void updateResizingMethod(int index)
        {
            int[] imgSize = getImageWidthAndHeight(inputImagePathTextBox.Text);
            switch (index)
            {
                case 0: // No Resizing.
                    resizingMethod1NumericInput.Value = 1;
                    resizingMethod1NumericInput.Visible = false;
                    resizingMethod2NumericInput.Visible = false;
                    resizingMethodXLabel.Visible = false;
                    nearestNeighborCheckBox.Visible = false;
                    break;
                case 1: // By Factor.
                    resizingMethod2NumericInput.DecimalPlaces = 2;
                    resizingMethod2NumericInput.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
                    resizingMethod2NumericInput.Value = new decimal(new int[] { 1, 0, 0, 65536 });
                    resizingMethod2NumericInput.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
                    resizingMethod2NumericInput.Visible = true;
                    resizingMethod1NumericInput.Visible = false;
                    resizingMethodXLabel.Visible = false;
                    nearestNeighborCheckBox.Visible = true;
                    updateScaleMessage();
                    break;
                case 2: // By Width & Height
                    resizingMethod1NumericInput.Minimum = 1;
                    resizingMethod1NumericInput.Maximum = decimal.MaxValue;
                    resizingMethod1NumericInput.Value = new decimal(imgSize[0]);
                    resizingMethod1NumericInput.Increment = 1;
                    resizingMethod2NumericInput.Increment = 1;
                    resizingMethod2NumericInput.Minimum = 1;
                    resizingMethod2NumericInput.Maximum = decimal.MaxValue;
                    resizingMethod2NumericInput.Value = new decimal(imgSize[1]);
                    resizingMethod1NumericInput.DecimalPlaces = 0;
                    resizingMethod2NumericInput.DecimalPlaces = 0;
                    resizingMethod1NumericInput.Visible = true;
                    resizingMethod2NumericInput.Visible = true;
                    resizingMethodXLabel.Visible = true;
                    nearestNeighborCheckBox.Visible = true;
                    updateResizeMessage();
                    break;
                default:
                    break;
            }
        }

        private void updateScaleMessage()
        {
            if (resizingMethodComboBox.SelectedIndex == 0)
            {
                statusTextTextBox.Text = $"Resizing is disabled!";
            }
            else
            {
                if ((float)resizingMethod2NumericInput.Value == 1)
                {
                    statusTextTextBox.Text = $"Image scale factor is changes nothing! (Useless)";
                    blinkTheStatusText(Color.OrangeRed);
                }
                else
                {
                    int[] fwh = calcAfterFactorWidthAndHeight((double)resizingMethod2NumericInput.Value);
                    statusTextTextBox.Text = $"Image scale factor result is {fwh[0]}x{fwh[1]}!";
                }
            }
        }

        private void updateResizeMessage()
        {
            if (resizingMethodComboBox.SelectedIndex == 0) {
                statusTextTextBox.Text = $"Resizing is disabled!";
            } else
            {
                int[] imgSize = getImageWidthAndHeight(inputImagePathTextBox.Text);

                if ((int)resizingMethod1NumericInput.Value == imgSize[0] && (int)resizingMethod2NumericInput.Value == imgSize[1])
                {
                    statusTextTextBox.Text = $"The new image width and height same as original! (Useless)";
                    blinkTheStatusText(Color.OrangeRed);
                }
                else
                {
                    statusTextTextBox.Text = $"The new image width and height is {resizingMethod1NumericInput.Value}x{resizingMethod2NumericInput.Value}!";
                }
            }

        }

        private int[] calcAfterFactorWidthAndHeight(double factor)
        {
            int[] imgSize = getImageWidthAndHeight(inputImagePathTextBox.Text);
            return new int[] { (int)Math.Round((double)(imgSize[0] * resizingMethod2NumericInput.Value)), (int)Math.Round((double)(imgSize[1] * resizingMethod2NumericInput.Value)) };
        }

        private void resizingMethod1NumericInput_ValueChanged(object sender, EventArgs e)
        {
            updateResizeMessage();
            genCmd();
        }

        private void resizingMethod2NumericInput_ValueChanged(object sender, EventArgs e)
        {

            switch (resizingMethodComboBox.SelectedIndex)
            {
                case 1:
                    updateScaleMessage();
                    break;
                case 2:
                    updateResizeMessage();
                    break;
                default:
                    break;
            }

            genCmd();
        }

        private int[] getImageWidthAndHeight(string path)
        {
            int width = 1;
            int height = 1;

            if (!String.IsNullOrEmpty(path))
            {
                using (Stream stream = File.OpenRead(path))
                {
                    using (Image sourceImage = Image.FromStream(stream, false, false))
                    {
                        width = sourceImage.Width;
                        height = sourceImage.Height;
                    }
                }
                GC.Collect();
            }

            return new int[] { width, height };
        }

        private void enableDitheringCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isUsingDitheringCheckBox.Checked)
            {
                ditheringValueNumericInput.Value = new decimal(5);
                ditheringValueNumericInput.Enabled = true;
                ditheringValueNumericInput.Visible = true;
                statusTextTextBox.Text = "Dithering is enabled!";
            }
            else {
                ditheringValueNumericInput.Value = new decimal(1);
                ditheringValueNumericInput.Enabled = false;
                ditheringValueNumericInput.Visible = false;
                statusTextTextBox.Text = "Dithering is disabled!";
            }
            genCmd();
        }

        private void ditheringValueNumericInput_ValueChanged(object sender, EventArgs e)
        {
            statusTextTextBox.Text = $"Dithering factor is set to {ditheringValueNumericInput.Value}!";
            genCmd();
        }

        private void isVerticalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isVerticalCheckBox.Checked)
            {
                statusTextTextBox.Text = "Image orientation is changed vertical!";
            } else
            {
                statusTextTextBox.Text = "Image orientation is changed horizontal!";
            }
            genCmd();
        }

        private void isFullScaffoldCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isFullScaffoldEanbledCheckBox.Checked)
            {
                statusTextTextBox.Text = "Scaffold block is enabled for every block!";
            }
            else
            {
                statusTextTextBox.Text = "Scaffold mode changed to only scaffold powder blocks.";
            }
            genCmd();
        }

        private void enableCustomScaffoldBlockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            customScaffoldBlockTextBox.Text = "stone 0";
            if (isCustomScaffoldCheckBox.Checked)
            {
                customScaffoldBlockInputPanel.Visible = true;
            } else
            {
                customScaffoldBlockInputPanel.Visible = false;
            }
            statusTextTextBox.Text = $"New scaffold block is {customScaffoldBlockTextBox.Text}!";
            genCmd();
        }

        private void customScaffoldBlockTextBox_TextChanged(object sender, EventArgs e)
        {
            statusTextTextBox.Text = $"New scaffold block is {customScaffoldBlockTextBox.Text}!";
            genCmd();
        }

        private void preprocessingEffectsToggleItemButton_Click(object sender, EventArgs e)
        {
            string oldVal = preprocessingEffectsListBox.Items[preprocessingEffectsListBox.SelectedIndex] as string;
            string[] oldValSplitted = oldVal.Split(new string[] { ": " }, StringSplitOptions.None);

            string newVal = "";

            switch (oldValSplitted[0])
            {
                case "[ON ]":
                    newVal = $"[OFF]: {oldValSplitted[1].Trim()}";
                    statusTextTextBox.Text = $"PRE-EFFECTS: {oldValSplitted[1].Trim()} toggled to OFF!";
                    break;
                case "[OFF]":
                    newVal = $"[ON ]: {oldValSplitted[1].Trim()}";
                    statusTextTextBox.Text = $"PRE-EFFECTS: {oldValSplitted[1].Trim()} toggled to ON!";
                    break;
                default:
                    break;
            }

            preprocessingEffectsListBox.Items[preprocessingEffectsListBox.SelectedIndex] = newVal;

            genCmd();
        }

        private void preprocessingEffectsMoveUpItemButton_Click(object sender, EventArgs e)
        {
            if (preprocessingEffectsListBox.SelectedIndex != 0)
            {
                int oldIndex = preprocessingEffectsListBox.SelectedIndex;
                int newIndex = oldIndex - 1;

                string currentIndexItem = preprocessingEffectsListBox.Items[oldIndex] as string;
                string targetIndexItem = preprocessingEffectsListBox.Items[newIndex] as string;

                preprocessingEffectsListBox.Items[oldIndex] = targetIndexItem;
                preprocessingEffectsListBox.Items[newIndex] = currentIndexItem;

                preprocessingEffectsListBox.SelectedIndex = newIndex;
            } else
            {
                statusTextTextBox.Text = $"PRE-EFFECTS: You can't move upwards more!";
            }

            genCmd();
        }

        private void preprocessingEffectsMoveDownItemButton_Click(object sender, EventArgs e)
        {
            int oldIndex = preprocessingEffectsListBox.SelectedIndex;
            int newIndex = oldIndex + 1;

            if (!(newIndex >= preprocessingEffectsListBox.Items.Count))
            {
                string currentIndexItem = preprocessingEffectsListBox.Items[oldIndex] as string;
                string targetIndexItem = preprocessingEffectsListBox.Items[newIndex] as string;

                preprocessingEffectsListBox.Items[oldIndex] = targetIndexItem;
                preprocessingEffectsListBox.Items[newIndex] = currentIndexItem;

                preprocessingEffectsListBox.SelectedIndex = newIndex;
            } else
            {
                statusTextTextBox.Text = $"PRE-EFFECTS: You can't move downwards more!";
            }

            genCmd();
        }

        private void runResultCommandButton_Click(object sender, EventArgs e)
        {

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                statusTextTextBox.Text = $"Process started!";
                startInfo.Arguments = resultCommandTextBox.Text.Remove(0, 10);
                startInfo.FileName = resultCommandTextBox.Text.Substring(0, 10);
                startInfo.UseShellExecute = false;
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                startInfo.Environment.Add("PANBTG_GUI_FOR_VERSION", FOR_VERSION);
                Process process = Process.Start(startInfo);
                process.WaitForExit();
                statusTextTextBox.Text = "Conversion is finished!";
                blinkTheStatusText(Color.Lime, 2500);
            } catch (Exception err)
            {
                if (err.Message.Contains("cannot find"))
                {
                    statusTextTextBox.Text = "ERROR: Please put the PANBTG.exe and PANBGT-GUI.exe in same folder!";
                } else
                {
                    statusTextTextBox.Text = $"ERROR: {err.Message}";
                }
                
                blinkTheStatusText(Color.OrangeRed);
            }
        }

        private void nearestNeighborCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (nearestNeighborCheckBox.Checked)
            {
                statusTextTextBox.Text = $"Resizing method changed to Nearest Neighbor!";
            } else
            {
                statusTextTextBox.Text = $"Resizing method changed to Normal!";
            }
            genCmd();
        }


        private void blinkTheStatusText(Color bgColor, int ms = 50)
        {
            statusTextTextBox.BackColor = bgColor;
            statusTextTextBox.ForeColor = Color.Black;

            blinkStatusTextTimer1.Interval = ms;
            blinkStatusTextTimer1.Start();
        }

        private void blinkTheStatusText(Color bgColor, Color fgColor, int ms = 50)
        {
            statusTextTextBox.BackColor = bgColor;
            statusTextTextBox.ForeColor = fgColor;

            blinkStatusTextTimer1.Interval = ms;
            blinkStatusTextTimer1.Start();
        }

        private void blinkStatusTextTimer1_Tick(object sender, EventArgs e)
        {
            statusTextTextBox.BackColor = Color.FromArgb(255, 64, 64, 64);
            statusTextTextBox.ForeColor = Color.Gray;
            blinkStatusTextTimer1.Stop();
        }

        private void preprocessingEffectsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(preprocessingEffectsListBox.SelectedIndex < 0))
            {
                string currentVal = preprocessingEffectsListBox.Items[preprocessingEffectsListBox.SelectedIndex] as string;
                string[] currentValSplit1 = currentVal.Split(new string[] { ": " }, StringSplitOptions.None);
                string[] currentValSplit2 = currentValSplit1[1].Split(new string[] { " " }, StringSplitOptions.None);
                bool canSetValue = currentValSplit2.Length == 2;
                preprocessingEffectsSetValueItemButton.Visible = canSetValue;



                preprocessingEffectsToggleItemButton.BackColor = currentValSplit1[0].Contains("ON") ? Color.FromArgb(0, 64, 0) : Color.FromArgb(64, 0, 0);
            }
            
        }

        private void preprocessingEffectsSetValueItemButton_Click(object sender, EventArgs e)
        {
            string currentVal = preprocessingEffectsListBox.Items[preprocessingEffectsListBox.SelectedIndex] as string;
            string[] currentValSplit1 = currentVal.Split(new string[] { ": " }, StringSplitOptions.None);
            string[] currentValSplit2 = currentValSplit1[1].Split(' ');
            string[] effectNameAndPower = currentValSplit2[0].Split(':');
            string[] minMax = currentValSplit2[1].Replace("<","").Replace(">", "").Split('/');

            using (NumericPopupForm numericPopup = new NumericPopupForm())
            {
                numericPopup.setQuestionText($"Set power of {effectNameAndPower[0]} effect! ({minMax[0]}/{minMax[1]})");
                numericPopup.setupInput(int.Parse(effectNameAndPower[1]), 0, 1, int.Parse(minMax[0]), int.Parse(minMax[1]));

                if (numericPopup.ShowDialog() == DialogResult.OK)
                {
                    int result = int.Parse(numericPopup.getResult().ToString());
                    preprocessingEffectsListBox.Items[preprocessingEffectsListBox.SelectedIndex] = currentVal.Replace($":{effectNameAndPower[1]}", $":{result}");

                    statusTextTextBox.Text = $"PRE-EFFECTS: Effect {effectNameAndPower[0]}'s power changed to {result}!{(result == 0 ? " (Useless)" : "")}";
                    if (result == 0) blinkTheStatusText(Color.OrangeRed);
                }
            }
            genCmd();
            GC.Collect();
        }

        private void directionXTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(directionXTextBox.Text))
            {
                directionXTextBox.Text = "+";
                return;
            }
            char t = directionXTextBox.Text[directionXTextBox.Text.Length - 1].ToString().Trim()[0];
            if (t == '+' || t == '-')
            {
                directionXTextBox.Text = t.ToString();
            } else
            {
                directionXTextBox.Text = directionXTextBox.Text[0].ToString();
            }
            directionXTextBox.SelectionStart = directionXTextBox.Text.Length;
            directionXTextBox.ScrollToCaret();
            statusTextTextBox.Text = $"X direction changed to {directionXTextBox.Text}!";
            genCmd();
        }

        private void directionZTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(directionZTextBox.Text))
            {
                directionZTextBox.Text = "+";
                return;
            }
            char t = directionZTextBox.Text[directionZTextBox.Text.Length - 1].ToString().Trim()[0];
            if (t == '+' || t == '-')
            {
                directionZTextBox.Text = t.ToString();
            }
            else
            {
                directionZTextBox.Text = directionZTextBox.Text[0].ToString();
            }
            directionZTextBox.SelectionStart = directionZTextBox.Text.Length;
            directionZTextBox.ScrollToCaret();
            statusTextTextBox.Text = $"Z direction changed to {directionZTextBox.Text}!";
            genCmd();
        }

        private void isCustomDirectionEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isCustomDirectionEnabledCheckBox.Checked)
            {
                directionXTextBox.Text = "+";
                directionZTextBox.Text = "+";
                directionXPanel.Visible = true;
                directionZPanel.Visible = true;
                statusTextTextBox.Text = $"Custom direction is enabled!";
            } else
            {
                directionXPanel.Visible = false;
                directionZPanel.Visible = false;
                statusTextTextBox.Text = $"Custom direction is disabled!";
            }
            genCmd();
        }

        private void isOnlyPreprocess_CheckedChanged(object sender, EventArgs e)
        {
            if (isOnlyPreprocess.Checked)
            {
                statusTextTextBox.Text = $"Only preprocess mode enabled! (Not gonna generate the nbt!)";
                blinkTheStatusText(Color.OrangeRed);
            }
            else
            {
                statusTextTextBox.Text = $"Only preprocess mode disabled!";
                blinkTheStatusText(Color.FromArgb(0, 128, 0), Color.Gray);
            }
            genCmd();
        }
    }
}

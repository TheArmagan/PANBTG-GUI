using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace PANBTG_GUI
{
    public partial class MainForm : Form
    {
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
            scaleFactorResultLabel.Visible = false;
            resultCommandTextBox.Enabled = false;
            runResultCommandButton.Enabled = false;

            openFileButton.ForeColor = Color.Lime;

            preprocessingEffectsListBox.Items.Add("[OFF]: Grayscale");
            preprocessingEffectsListBox.Items.Add("[OFF]: Deepfry");

            statusTextTextBox.Text = "Please select an image.";

            genCmd();
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
            if (!String.IsNullOrEmpty(inputImagePathTextBox.Text)) {
                string resultCmd = "PANBTG.exe";

                resultCmd += $" --input \"{inputImagePathTextBox.Text}\"";

                if (resizingMethodComboBox.SelectedIndex == 1)
                    resultCmd += $" --scale {resizingMethod2NumericInput.Value.ToString().Replace(",", ".")}";

                if (resizingMethodComboBox.SelectedIndex == 2) 
                    resultCmd += $" --resize {resizingMethod1NumericInput.Value}x{resizingMethod2NumericInput.Value}";

                if (enableDitheringCheckBox.Checked)
                    resultCmd += $" --dither {ditheringValueNumericInput.Value}";

                if (enableCustomScaffoldBlockCheckBox.Checked)
                    resultCmd += $" --scaffold-block {customScaffoldBlockTextBox.Text.Replace(" ", ":")}";

                if (isFullScaffoldCheckBox.Checked)
                    resultCmd += $" --full-scaffold";

                if (isVerticalCheckBox.Checked)
                    resultCmd += $" --vertical";

                {

                    string enabledEffects = "";

                    for (int i = 0; i < preprocessingEffectsListBox.Items.Count; i++)
                    {
                        string val = preprocessingEffectsListBox.Items[i] as string;
                        string[] valSplitted = val.Split(new string[] { ": " }, StringSplitOptions.None);

                        if (valSplitted[0].Contains("ON"))
                        {
                            enabledEffects += $"{(enabledEffects.Length != 0 ? "," : "")}{valSplitted[1].Trim().ToLower()}";
                        }
                    }

                    if (enabledEffects.Length != 0)
                    {
                        resultCmd += $" --effects {enabledEffects}";
                    }

                }

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
                    scaleFactorResultLabel.Visible = false;
                    break;
                case 1: // By Factor.
                    resizingMethod2NumericInput.DecimalPlaces = 2;
                    resizingMethod2NumericInput.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
                    resizingMethod2NumericInput.Value = new decimal(new int[] { 1, 0, 0, 65536 });
                    resizingMethod2NumericInput.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
                    resizingMethod2NumericInput.Visible = true;
                    resizingMethod1NumericInput.Visible = false;
                    resizingMethodXLabel.Visible = false;
                    scaleFactorResultLabel.Visible = true;

                    int[] fwh = calcAfterFactorWidthAndHeight((double)resizingMethod2NumericInput.Value);
                    scaleFactorResultLabel.Text = $"{fwh[0]}x{fwh[1]}";

                    break;
                case 2: // By Width And Height
                    resizingMethod1NumericInput.Minimum = 1;
                    resizingMethod1NumericInput.Value = new decimal(imgSize[0]);
                    resizingMethod2NumericInput.Minimum = 1;
                    resizingMethod2NumericInput.Value = new decimal(imgSize[1]);
                    resizingMethod1NumericInput.DecimalPlaces = 0;
                    resizingMethod2NumericInput.DecimalPlaces = 0;
                    resizingMethod1NumericInput.Visible = true;
                    resizingMethod2NumericInput.Visible = true;
                    resizingMethodXLabel.Visible = true;
                    scaleFactorResultLabel.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void resizingMethod1NumericInput_ValueChanged(object sender, EventArgs e)
        {
            genCmd();
        }

        private int[] calcAfterFactorWidthAndHeight(double factor)
        {
            int[] imgSize = getImageWidthAndHeight(inputImagePathTextBox.Text);
            return new int[] { (int)Math.Round((double)(imgSize[0] * resizingMethod2NumericInput.Value)), (int)Math.Round((double)(imgSize[1] * resizingMethod2NumericInput.Value)) };
        }

        private void resizingMethod2NumericInput_ValueChanged(object sender, EventArgs e)
        {
            
            if (resizingMethodComboBox.SelectedIndex == 1)
            {
                int[] fwh = calcAfterFactorWidthAndHeight((double)resizingMethod2NumericInput.Value);
                scaleFactorResultLabel.Text = $"{fwh[0]}x{fwh[1]}";
            }

            genCmd();
        }

        private int[] getImageWidthAndHeight(string path)
        {
            int width = 1;
            int height = 1;
            using (Stream stream = File.OpenRead(path))
            {
                using (Image sourceImage = Image.FromStream(stream, false, false))
                {
                    width = sourceImage.Width;
                    height = sourceImage.Height;
                }
            }
            GC.Collect();

            return new int[] { width, height };
        }

        private void enableDitheringCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableDitheringCheckBox.Checked)
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
            if (isFullScaffoldCheckBox.Checked)
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
            if (enableCustomScaffoldBlockCheckBox.Checked)
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
            statusTextTextBox.Text = $"Process started!";
            Process.Start(resultCommandTextBox.Text);
        }
    }
}

namespace PANBTG_GUI
{
    partial class MainForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inputImagePathTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.resultCommandTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.nearestNeighborCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.preprocessingEffectsListBoxPanel = new System.Windows.Forms.Panel();
            this.preprocessingEffectsMoveDownItemButton = new System.Windows.Forms.Button();
            this.preprocessingEffectsMoveUpItemButton = new System.Windows.Forms.Button();
            this.preprocessingEffectsToggleItemButton = new System.Windows.Forms.Button();
            this.preprocessingEffectsListBox = new System.Windows.Forms.ListBox();
            this.customScaffoldBlockInputPanel = new System.Windows.Forms.Panel();
            this.customScaffoldBlockTextBox = new System.Windows.Forms.TextBox();
            this.enableCustomScaffoldBlockCheckBox = new System.Windows.Forms.CheckBox();
            this.isFullScaffoldCheckBox = new System.Windows.Forms.CheckBox();
            this.isVerticalCheckBox = new System.Windows.Forms.CheckBox();
            this.ditheringValueNumericInput = new System.Windows.Forms.NumericUpDown();
            this.enableDitheringCheckBox = new System.Windows.Forms.CheckBox();
            this.resizingMethodXLabel = new System.Windows.Forms.Label();
            this.resizingMethod2NumericInput = new System.Windows.Forms.NumericUpDown();
            this.resizingMethod1NumericInput = new System.Windows.Forms.NumericUpDown();
            this.resizingMethodComboBox = new System.Windows.Forms.ComboBox();
            this.runResultCommandButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fileSizeInfoLabel = new System.Windows.Forms.Label();
            this.statusTextTextBox = new System.Windows.Forms.TextBox();
            this.blinkStatusTextTimer1 = new System.Windows.Forms.Timer(this.components);
            this.forVersionLabel = new System.Windows.Forms.Label();
            this.preprocessingEffectsSetValueItemButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.preprocessingEffectsListBoxPanel.SuspendLayout();
            this.customScaffoldBlockInputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ditheringValueNumericInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizingMethod2NumericInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizingMethod1NumericInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(5, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 41);
            this.label3.TabIndex = 2;
            this.label3.Text = "PANBTG";
            // 
            // openFileButton
            // 
            this.openFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.openFileButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.openFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFileButton.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.openFileButton.ForeColor = System.Drawing.Color.White;
            this.openFileButton.Location = new System.Drawing.Point(12, 58);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(139, 32);
            this.openFileButton.TabIndex = 4;
            this.openFileButton.Text = "Pick A Image";
            this.openFileButton.UseVisualStyleBackColor = false;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.panel1.Controls.Add(this.inputImagePathTextBox);
            this.panel1.Location = new System.Drawing.Point(157, 58);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(451, 32);
            this.panel1.TabIndex = 6;
            // 
            // inputImagePathTextBox
            // 
            this.inputImagePathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.inputImagePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputImagePathTextBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputImagePathTextBox.ForeColor = System.Drawing.Color.White;
            this.inputImagePathTextBox.Location = new System.Drawing.Point(7, 7);
            this.inputImagePathTextBox.Name = "inputImagePathTextBox";
            this.inputImagePathTextBox.ReadOnly = true;
            this.inputImagePathTextBox.Size = new System.Drawing.Size(437, 18);
            this.inputImagePathTextBox.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.resultCommandTextBox);
            this.panel2.Location = new System.Drawing.Point(12, 536);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(451, 32);
            this.panel2.TabIndex = 7;
            // 
            // resultCommandTextBox
            // 
            this.resultCommandTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.resultCommandTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultCommandTextBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultCommandTextBox.ForeColor = System.Drawing.Color.White;
            this.resultCommandTextBox.Location = new System.Drawing.Point(7, 7);
            this.resultCommandTextBox.Name = "resultCommandTextBox";
            this.resultCommandTextBox.ReadOnly = true;
            this.resultCommandTextBox.Size = new System.Drawing.Size(437, 18);
            this.resultCommandTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(129, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "GUI";
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.nearestNeighborCheckBox);
            this.controlPanel.Controls.Add(this.label5);
            this.controlPanel.Controls.Add(this.label4);
            this.controlPanel.Controls.Add(this.preprocessingEffectsListBoxPanel);
            this.controlPanel.Controls.Add(this.customScaffoldBlockInputPanel);
            this.controlPanel.Controls.Add(this.enableCustomScaffoldBlockCheckBox);
            this.controlPanel.Controls.Add(this.isFullScaffoldCheckBox);
            this.controlPanel.Controls.Add(this.isVerticalCheckBox);
            this.controlPanel.Controls.Add(this.ditheringValueNumericInput);
            this.controlPanel.Controls.Add(this.enableDitheringCheckBox);
            this.controlPanel.Controls.Add(this.resizingMethodXLabel);
            this.controlPanel.Controls.Add(this.resizingMethod2NumericInput);
            this.controlPanel.Controls.Add(this.resizingMethod1NumericInput);
            this.controlPanel.Controls.Add(this.resizingMethodComboBox);
            this.controlPanel.Location = new System.Drawing.Point(12, 97);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(597, 433);
            this.controlPanel.TabIndex = 9;
            // 
            // nearestNeighborCheckBox
            // 
            this.nearestNeighborCheckBox.AutoSize = true;
            this.nearestNeighborCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nearestNeighborCheckBox.Location = new System.Drawing.Point(246, 8);
            this.nearestNeighborCheckBox.Name = "nearestNeighborCheckBox";
            this.nearestNeighborCheckBox.Size = new System.Drawing.Size(138, 18);
            this.nearestNeighborCheckBox.TabIndex = 16;
            this.nearestNeighborCheckBox.Text = "Nearest Neighbor";
            this.nearestNeighborCheckBox.UseVisualStyleBackColor = true;
            this.nearestNeighborCheckBox.CheckedChanged += new System.EventHandler(this.nearestNeighborCheckBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 11.45F);
            this.label5.Location = new System.Drawing.Point(-4, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "Resize By:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 11.45F);
            this.label4.Location = new System.Drawing.Point(-5, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "Preprocessing Effects:";
            // 
            // preprocessingEffectsListBoxPanel
            // 
            this.preprocessingEffectsListBoxPanel.Controls.Add(this.preprocessingEffectsSetValueItemButton);
            this.preprocessingEffectsListBoxPanel.Controls.Add(this.preprocessingEffectsMoveDownItemButton);
            this.preprocessingEffectsListBoxPanel.Controls.Add(this.preprocessingEffectsMoveUpItemButton);
            this.preprocessingEffectsListBoxPanel.Controls.Add(this.preprocessingEffectsToggleItemButton);
            this.preprocessingEffectsListBoxPanel.Controls.Add(this.preprocessingEffectsListBox);
            this.preprocessingEffectsListBoxPanel.Location = new System.Drawing.Point(246, 153);
            this.preprocessingEffectsListBoxPanel.Name = "preprocessingEffectsListBoxPanel";
            this.preprocessingEffectsListBoxPanel.Size = new System.Drawing.Size(352, 92);
            this.preprocessingEffectsListBoxPanel.TabIndex = 12;
            // 
            // preprocessingEffectsMoveDownItemButton
            // 
            this.preprocessingEffectsMoveDownItemButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.preprocessingEffectsMoveDownItemButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.preprocessingEffectsMoveDownItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preprocessingEffectsMoveDownItemButton.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.preprocessingEffectsMoveDownItemButton.ForeColor = System.Drawing.Color.White;
            this.preprocessingEffectsMoveDownItemButton.Location = new System.Drawing.Point(261, 57);
            this.preprocessingEffectsMoveDownItemButton.Name = "preprocessingEffectsMoveDownItemButton";
            this.preprocessingEffectsMoveDownItemButton.Size = new System.Drawing.Size(90, 35);
            this.preprocessingEffectsMoveDownItemButton.TabIndex = 14;
            this.preprocessingEffectsMoveDownItemButton.Text = "MOVE DOWN";
            this.preprocessingEffectsMoveDownItemButton.UseVisualStyleBackColor = false;
            this.preprocessingEffectsMoveDownItemButton.Click += new System.EventHandler(this.preprocessingEffectsMoveDownItemButton_Click);
            // 
            // preprocessingEffectsMoveUpItemButton
            // 
            this.preprocessingEffectsMoveUpItemButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.preprocessingEffectsMoveUpItemButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.preprocessingEffectsMoveUpItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preprocessingEffectsMoveUpItemButton.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.preprocessingEffectsMoveUpItemButton.ForeColor = System.Drawing.Color.White;
            this.preprocessingEffectsMoveUpItemButton.Location = new System.Drawing.Point(180, 57);
            this.preprocessingEffectsMoveUpItemButton.Name = "preprocessingEffectsMoveUpItemButton";
            this.preprocessingEffectsMoveUpItemButton.Size = new System.Drawing.Size(75, 35);
            this.preprocessingEffectsMoveUpItemButton.TabIndex = 13;
            this.preprocessingEffectsMoveUpItemButton.Text = "MOVE UP";
            this.preprocessingEffectsMoveUpItemButton.UseVisualStyleBackColor = false;
            this.preprocessingEffectsMoveUpItemButton.Click += new System.EventHandler(this.preprocessingEffectsMoveUpItemButton_Click);
            // 
            // preprocessingEffectsToggleItemButton
            // 
            this.preprocessingEffectsToggleItemButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.preprocessingEffectsToggleItemButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.preprocessingEffectsToggleItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preprocessingEffectsToggleItemButton.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.preprocessingEffectsToggleItemButton.ForeColor = System.Drawing.Color.White;
            this.preprocessingEffectsToggleItemButton.Location = new System.Drawing.Point(0, 57);
            this.preprocessingEffectsToggleItemButton.Name = "preprocessingEffectsToggleItemButton";
            this.preprocessingEffectsToggleItemButton.Size = new System.Drawing.Size(67, 35);
            this.preprocessingEffectsToggleItemButton.TabIndex = 12;
            this.preprocessingEffectsToggleItemButton.Text = "TOGGLE";
            this.preprocessingEffectsToggleItemButton.UseVisualStyleBackColor = false;
            this.preprocessingEffectsToggleItemButton.Click += new System.EventHandler(this.preprocessingEffectsToggleItemButton_Click);
            // 
            // preprocessingEffectsListBox
            // 
            this.preprocessingEffectsListBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.preprocessingEffectsListBox.FormattingEnabled = true;
            this.preprocessingEffectsListBox.Location = new System.Drawing.Point(0, 0);
            this.preprocessingEffectsListBox.Name = "preprocessingEffectsListBox";
            this.preprocessingEffectsListBox.Size = new System.Drawing.Size(351, 56);
            this.preprocessingEffectsListBox.TabIndex = 11;
            this.preprocessingEffectsListBox.SelectedIndexChanged += new System.EventHandler(this.preprocessingEffectsListBox_SelectedIndexChanged);
            // 
            // customScaffoldBlockInputPanel
            // 
            this.customScaffoldBlockInputPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.customScaffoldBlockInputPanel.Controls.Add(this.customScaffoldBlockTextBox);
            this.customScaffoldBlockInputPanel.Location = new System.Drawing.Point(246, 91);
            this.customScaffoldBlockInputPanel.Name = "customScaffoldBlockInputPanel";
            this.customScaffoldBlockInputPanel.Padding = new System.Windows.Forms.Padding(4);
            this.customScaffoldBlockInputPanel.Size = new System.Drawing.Size(351, 32);
            this.customScaffoldBlockInputPanel.TabIndex = 8;
            // 
            // customScaffoldBlockTextBox
            // 
            this.customScaffoldBlockTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.customScaffoldBlockTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customScaffoldBlockTextBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customScaffoldBlockTextBox.ForeColor = System.Drawing.Color.White;
            this.customScaffoldBlockTextBox.Location = new System.Drawing.Point(7, 7);
            this.customScaffoldBlockTextBox.Name = "customScaffoldBlockTextBox";
            this.customScaffoldBlockTextBox.Size = new System.Drawing.Size(336, 18);
            this.customScaffoldBlockTextBox.TabIndex = 7;
            this.customScaffoldBlockTextBox.TextChanged += new System.EventHandler(this.customScaffoldBlockTextBox_TextChanged);
            // 
            // enableCustomScaffoldBlockCheckBox
            // 
            this.enableCustomScaffoldBlockCheckBox.AutoSize = true;
            this.enableCustomScaffoldBlockCheckBox.Font = new System.Drawing.Font("Consolas", 11.45F);
            this.enableCustomScaffoldBlockCheckBox.Location = new System.Drawing.Point(-1, 95);
            this.enableCustomScaffoldBlockCheckBox.Name = "enableCustomScaffoldBlockCheckBox";
            this.enableCustomScaffoldBlockCheckBox.Size = new System.Drawing.Size(217, 23);
            this.enableCustomScaffoldBlockCheckBox.TabIndex = 9;
            this.enableCustomScaffoldBlockCheckBox.Text = "Custom Scaffold Block";
            this.enableCustomScaffoldBlockCheckBox.UseVisualStyleBackColor = true;
            this.enableCustomScaffoldBlockCheckBox.CheckedChanged += new System.EventHandler(this.enableCustomScaffoldBlockCheckBox_CheckedChanged);
            // 
            // isFullScaffoldCheckBox
            // 
            this.isFullScaffoldCheckBox.AutoSize = true;
            this.isFullScaffoldCheckBox.Font = new System.Drawing.Font("Consolas", 11.45F);
            this.isFullScaffoldCheckBox.Location = new System.Drawing.Point(-1, 124);
            this.isFullScaffoldCheckBox.Name = "isFullScaffoldCheckBox";
            this.isFullScaffoldCheckBox.Size = new System.Drawing.Size(145, 23);
            this.isFullScaffoldCheckBox.TabIndex = 8;
            this.isFullScaffoldCheckBox.Text = "Full Scaffold";
            this.isFullScaffoldCheckBox.UseVisualStyleBackColor = true;
            this.isFullScaffoldCheckBox.CheckedChanged += new System.EventHandler(this.isFullScaffoldCheckBox_CheckedChanged);
            // 
            // isVerticalCheckBox
            // 
            this.isVerticalCheckBox.AutoSize = true;
            this.isVerticalCheckBox.Font = new System.Drawing.Font("Consolas", 11.45F);
            this.isVerticalCheckBox.Location = new System.Drawing.Point(-1, 64);
            this.isVerticalCheckBox.Name = "isVerticalCheckBox";
            this.isVerticalCheckBox.Size = new System.Drawing.Size(154, 23);
            this.isVerticalCheckBox.TabIndex = 7;
            this.isVerticalCheckBox.Text = "Vertical Image";
            this.isVerticalCheckBox.UseVisualStyleBackColor = true;
            this.isVerticalCheckBox.CheckedChanged += new System.EventHandler(this.isVerticalCheckBox_CheckedChanged);
            // 
            // ditheringValueNumericInput
            // 
            this.ditheringValueNumericInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ditheringValueNumericInput.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.ditheringValueNumericInput.ForeColor = System.Drawing.Color.White;
            this.ditheringValueNumericInput.Location = new System.Drawing.Point(507, 33);
            this.ditheringValueNumericInput.Name = "ditheringValueNumericInput";
            this.ditheringValueNumericInput.Size = new System.Drawing.Size(89, 25);
            this.ditheringValueNumericInput.TabIndex = 6;
            this.ditheringValueNumericInput.ValueChanged += new System.EventHandler(this.ditheringValueNumericInput_ValueChanged);
            // 
            // enableDitheringCheckBox
            // 
            this.enableDitheringCheckBox.AutoSize = true;
            this.enableDitheringCheckBox.Font = new System.Drawing.Font("Consolas", 11.45F);
            this.enableDitheringCheckBox.Location = new System.Drawing.Point(-1, 35);
            this.enableDitheringCheckBox.Name = "enableDitheringCheckBox";
            this.enableDitheringCheckBox.Size = new System.Drawing.Size(172, 23);
            this.enableDitheringCheckBox.TabIndex = 5;
            this.enableDitheringCheckBox.Text = "Enable Dithering";
            this.enableDitheringCheckBox.UseVisualStyleBackColor = true;
            this.enableDitheringCheckBox.CheckedChanged += new System.EventHandler(this.enableDitheringCheckBox_CheckedChanged);
            // 
            // resizingMethodXLabel
            // 
            this.resizingMethodXLabel.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.resizingMethodXLabel.Location = new System.Drawing.Point(485, 6);
            this.resizingMethodXLabel.Name = "resizingMethodXLabel";
            this.resizingMethodXLabel.Size = new System.Drawing.Size(16, 18);
            this.resizingMethodXLabel.TabIndex = 4;
            this.resizingMethodXLabel.Text = "x";
            // 
            // resizingMethod2NumericInput
            // 
            this.resizingMethod2NumericInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.resizingMethod2NumericInput.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.resizingMethod2NumericInput.ForeColor = System.Drawing.Color.White;
            this.resizingMethod2NumericInput.Location = new System.Drawing.Point(507, 4);
            this.resizingMethod2NumericInput.Name = "resizingMethod2NumericInput";
            this.resizingMethod2NumericInput.Size = new System.Drawing.Size(89, 25);
            this.resizingMethod2NumericInput.TabIndex = 3;
            this.resizingMethod2NumericInput.ValueChanged += new System.EventHandler(this.resizingMethod2NumericInput_ValueChanged);
            // 
            // resizingMethod1NumericInput
            // 
            this.resizingMethod1NumericInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.resizingMethod1NumericInput.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.resizingMethod1NumericInput.ForeColor = System.Drawing.Color.White;
            this.resizingMethod1NumericInput.Location = new System.Drawing.Point(390, 4);
            this.resizingMethod1NumericInput.Name = "resizingMethod1NumericInput";
            this.resizingMethod1NumericInput.Size = new System.Drawing.Size(89, 25);
            this.resizingMethod1NumericInput.TabIndex = 2;
            this.resizingMethod1NumericInput.ValueChanged += new System.EventHandler(this.resizingMethod1NumericInput_ValueChanged);
            // 
            // resizingMethodComboBox
            // 
            this.resizingMethodComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.resizingMethodComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resizingMethodComboBox.Font = new System.Drawing.Font("Consolas", 11.45F);
            this.resizingMethodComboBox.ForeColor = System.Drawing.Color.White;
            this.resizingMethodComboBox.FormattingEnabled = true;
            this.resizingMethodComboBox.Items.AddRange(new object[] {
            "No Resizing",
            "Factor",
            "Width & Height"});
            this.resizingMethodComboBox.Location = new System.Drawing.Point(101, 4);
            this.resizingMethodComboBox.Name = "resizingMethodComboBox";
            this.resizingMethodComboBox.Size = new System.Drawing.Size(139, 26);
            this.resizingMethodComboBox.TabIndex = 1;
            this.resizingMethodComboBox.Text = "No Resizing";
            this.resizingMethodComboBox.SelectedIndexChanged += new System.EventHandler(this.resizingMethodComboBox_SelectedIndexChanged);
            // 
            // runResultCommandButton
            // 
            this.runResultCommandButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.runResultCommandButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.runResultCommandButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runResultCommandButton.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.runResultCommandButton.ForeColor = System.Drawing.Color.White;
            this.runResultCommandButton.Location = new System.Drawing.Point(469, 536);
            this.runResultCommandButton.Name = "runResultCommandButton";
            this.runResultCommandButton.Size = new System.Drawing.Size(140, 32);
            this.runResultCommandButton.TabIndex = 10;
            this.runResultCommandButton.Text = "Run The Command";
            this.runResultCommandButton.UseVisualStyleBackColor = false;
            this.runResultCommandButton.Click += new System.EventHandler(this.runResultCommandButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Pixel Art NBT Generator. By Kıraç Armağan Önal (Armaga#2469)";
            // 
            // fileSizeInfoLabel
            // 
            this.fileSizeInfoLabel.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.fileSizeInfoLabel.ForeColor = System.Drawing.Color.Gray;
            this.fileSizeInfoLabel.Location = new System.Drawing.Point(326, 32);
            this.fileSizeInfoLabel.Name = "fileSizeInfoLabel";
            this.fileSizeInfoLabel.Size = new System.Drawing.Size(283, 23);
            this.fileSizeInfoLabel.TabIndex = 12;
            this.fileSizeInfoLabel.Text = "0x0 (0kb)";
            this.fileSizeInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusTextTextBox
            // 
            this.statusTextTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.statusTextTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.statusTextTextBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTextTextBox.ForeColor = System.Drawing.Color.Gray;
            this.statusTextTextBox.Location = new System.Drawing.Point(12, 574);
            this.statusTextTextBox.Name = "statusTextTextBox";
            this.statusTextTextBox.ReadOnly = true;
            this.statusTextTextBox.Size = new System.Drawing.Size(597, 18);
            this.statusTextTextBox.TabIndex = 8;
            // 
            // blinkStatusTextTimer1
            // 
            this.blinkStatusTextTimer1.Interval = 50;
            this.blinkStatusTextTimer1.Tick += new System.EventHandler(this.blinkStatusTextTimer1_Tick);
            // 
            // forVersionLabel
            // 
            this.forVersionLabel.AutoSize = true;
            this.forVersionLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.forVersionLabel.ForeColor = System.Drawing.Color.Gray;
            this.forVersionLabel.Location = new System.Drawing.Point(130, 24);
            this.forVersionLabel.Name = "forVersionLabel";
            this.forVersionLabel.Size = new System.Drawing.Size(77, 14);
            this.forVersionLabel.TabIndex = 13;
            this.forVersionLabel.Text = "for v0.0.0";
            // 
            // preprocessingEffectsSetValueItemButton
            // 
            this.preprocessingEffectsSetValueItemButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.preprocessingEffectsSetValueItemButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.preprocessingEffectsSetValueItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preprocessingEffectsSetValueItemButton.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.preprocessingEffectsSetValueItemButton.ForeColor = System.Drawing.Color.White;
            this.preprocessingEffectsSetValueItemButton.Location = new System.Drawing.Point(73, 57);
            this.preprocessingEffectsSetValueItemButton.Name = "preprocessingEffectsSetValueItemButton";
            this.preprocessingEffectsSetValueItemButton.Size = new System.Drawing.Size(101, 35);
            this.preprocessingEffectsSetValueItemButton.TabIndex = 15;
            this.preprocessingEffectsSetValueItemButton.Text = "Set Value";
            this.preprocessingEffectsSetValueItemButton.UseVisualStyleBackColor = false;
            this.preprocessingEffectsSetValueItemButton.Click += new System.EventHandler(this.preprocessingEffectsSetValueItemButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(621, 604);
            this.Controls.Add(this.forVersionLabel);
            this.Controls.Add(this.statusTextTextBox);
            this.Controls.Add(this.runResultCommandButton);
            this.Controls.Add(this.fileSizeInfoLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "PANBTG-GUI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.preprocessingEffectsListBoxPanel.ResumeLayout(false);
            this.customScaffoldBlockInputPanel.ResumeLayout(false);
            this.customScaffoldBlockInputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ditheringValueNumericInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizingMethod2NumericInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizingMethod1NumericInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox inputImagePathTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox resultCommandTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.ComboBox resizingMethodComboBox;
        private System.Windows.Forms.NumericUpDown resizingMethod1NumericInput;
        private System.Windows.Forms.NumericUpDown resizingMethod2NumericInput;
        private System.Windows.Forms.Label resizingMethodXLabel;
        private System.Windows.Forms.CheckBox enableDitheringCheckBox;
        private System.Windows.Forms.NumericUpDown ditheringValueNumericInput;
        private System.Windows.Forms.CheckBox isVerticalCheckBox;
        private System.Windows.Forms.CheckBox isFullScaffoldCheckBox;
        private System.Windows.Forms.Panel customScaffoldBlockInputPanel;
        private System.Windows.Forms.TextBox customScaffoldBlockTextBox;
        private System.Windows.Forms.CheckBox enableCustomScaffoldBlockCheckBox;
        private System.Windows.Forms.Button runResultCommandButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox preprocessingEffectsListBox;
        private System.Windows.Forms.Panel preprocessingEffectsListBoxPanel;
        private System.Windows.Forms.Button preprocessingEffectsMoveDownItemButton;
        private System.Windows.Forms.Button preprocessingEffectsMoveUpItemButton;
        private System.Windows.Forms.Button preprocessingEffectsToggleItemButton;
        private System.Windows.Forms.Label fileSizeInfoLabel;
        private System.Windows.Forms.TextBox statusTextTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox nearestNeighborCheckBox;
        private System.Windows.Forms.Timer blinkStatusTextTimer1;
        private System.Windows.Forms.Label forVersionLabel;
        private System.Windows.Forms.Button preprocessingEffectsSetValueItemButton;
    }
}


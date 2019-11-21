using System.Drawing;

namespace Chip8_GUI.src
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.display_screen = new System.Windows.Forms.PictureBox();
            this.RamView = new System.Windows.Forms.ListBox();
            this.RegistersView = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProgramCounterView = new System.Windows.Forms.ListBox();
            this.AddressCounterView = new System.Windows.Forms.ListBox();
            this.StackPointerView = new System.Windows.Forms.ListBox();
            this.StackView = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.stepperMode = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.step100 = new System.Windows.Forms.Button();
            this.step10 = new System.Windows.Forms.Button();
            this.step5 = new System.Windows.Forms.Button();
            this.step1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.keypadF = new System.Windows.Forms.Button();
            this.keypadB = new System.Windows.Forms.Button();
            this.keypad0 = new System.Windows.Forms.Button();
            this.keypadA = new System.Windows.Forms.Button();
            this.keypadE = new System.Windows.Forms.Button();
            this.keypad9 = new System.Windows.Forms.Button();
            this.keypad8 = new System.Windows.Forms.Button();
            this.keypad7 = new System.Windows.Forms.Button();
            this.keypadD = new System.Windows.Forms.Button();
            this.keypad6 = new System.Windows.Forms.Button();
            this.keypad5 = new System.Windows.Forms.Button();
            this.keypad4 = new System.Windows.Forms.Button();
            this.keypadC = new System.Windows.Forms.Button();
            this.keypad3 = new System.Windows.Forms.Button();
            this.keypad2 = new System.Windows.Forms.Button();
            this.keypad1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.display_screen)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(155, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // display_screen
            // 
            this.display_screen.AccessibleDescription = "The screen which displays the emulated roms.";
            this.display_screen.AccessibleName = "output_screen";
            this.display_screen.Location = new System.Drawing.Point(182, 12);
            this.display_screen.Margin = new System.Windows.Forms.Padding(10);
            this.display_screen.MaximumSize = new System.Drawing.Size(6400, 3200);
            this.display_screen.MinimumSize = new System.Drawing.Size(64, 32);
            this.display_screen.Name = "display_screen";
            this.display_screen.Padding = new System.Windows.Forms.Padding(10);
            this.display_screen.Size = new System.Drawing.Size(640, 356);
            this.display_screen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.display_screen.TabIndex = 0;
            this.display_screen.TabStop = false;
            // 
            // RamView
            // 
            this.RamView.BackColor = System.Drawing.Color.DimGray;
            this.RamView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RamView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RamView.ForeColor = System.Drawing.Color.White;
            this.RamView.FormattingEnabled = true;
            this.RamView.ItemHeight = 16;
            this.RamView.Location = new System.Drawing.Point(14, 12);
            this.RamView.Margin = new System.Windows.Forms.Padding(10);
            this.RamView.Name = "RamView";
            this.RamView.Size = new System.Drawing.Size(174, 354);
            this.RamView.TabIndex = 4;
            this.RamView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetKeyDown);
            this.RamView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SetKeyUp);
            // 
            // RegistersView
            // 
            this.RegistersView.BackColor = System.Drawing.Color.Gray;
            this.RegistersView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegistersView.ForeColor = System.Drawing.Color.White;
            this.RegistersView.FormattingEnabled = true;
            this.RegistersView.ItemHeight = 16;
            this.RegistersView.Location = new System.Drawing.Point(957, 32);
            this.RegistersView.Name = "RegistersView";
            this.RegistersView.Size = new System.Drawing.Size(71, 146);
            this.RegistersView.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(583, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Program Counter:";
            // 
            // ProgramCounterView
            // 
            this.ProgramCounterView.BackColor = System.Drawing.Color.DimGray;
            this.ProgramCounterView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProgramCounterView.ForeColor = System.Drawing.Color.White;
            this.ProgramCounterView.FormattingEnabled = true;
            this.ProgramCounterView.ItemHeight = 16;
            this.ProgramCounterView.Location = new System.Drawing.Point(717, 136);
            this.ProgramCounterView.Name = "ProgramCounterView";
            this.ProgramCounterView.Size = new System.Drawing.Size(155, 18);
            this.ProgramCounterView.TabIndex = 7;
            // 
            // AddressCounterView
            // 
            this.AddressCounterView.BackColor = System.Drawing.Color.DimGray;
            this.AddressCounterView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddressCounterView.ForeColor = System.Drawing.Color.White;
            this.AddressCounterView.FormattingEnabled = true;
            this.AddressCounterView.ItemHeight = 16;
            this.AddressCounterView.Location = new System.Drawing.Point(717, 160);
            this.AddressCounterView.Name = "AddressCounterView";
            this.AddressCounterView.Size = new System.Drawing.Size(155, 18);
            this.AddressCounterView.TabIndex = 8;
            // 
            // StackPointerView
            // 
            this.StackPointerView.BackColor = System.Drawing.Color.DimGray;
            this.StackPointerView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StackPointerView.ForeColor = System.Drawing.Color.White;
            this.StackPointerView.FormattingEnabled = true;
            this.StackPointerView.ItemHeight = 16;
            this.StackPointerView.Location = new System.Drawing.Point(717, 111);
            this.StackPointerView.Name = "StackPointerView";
            this.StackPointerView.Size = new System.Drawing.Size(155, 18);
            this.StackPointerView.TabIndex = 9;
            // 
            // StackView
            // 
            this.StackView.BackColor = System.Drawing.Color.Gray;
            this.StackView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StackView.ForeColor = System.Drawing.Color.White;
            this.StackView.FormattingEnabled = true;
            this.StackView.ItemHeight = 16;
            this.StackView.Location = new System.Drawing.Point(890, 32);
            this.StackView.Name = "StackView";
            this.StackView.Size = new System.Drawing.Size(61, 146);
            this.StackView.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(584, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Address Counter:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(954, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Registers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(897, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Stack";
            // 
            // stepperMode
            // 
            this.stepperMode.AutoSize = true;
            this.stepperMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepperMode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.stepperMode.Location = new System.Drawing.Point(12, 19);
            this.stepperMode.Name = "stepperMode";
            this.stepperMode.Size = new System.Drawing.Size(113, 20);
            this.stepperMode.TabIndex = 14;
            this.stepperMode.Text = "Stepper Mode";
            this.stepperMode.UseVisualStyleBackColor = true;
            this.stepperMode.CheckedChanged += new System.EventHandler(this.StepperMode_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Controls.Add(this.step100);
            this.groupBox1.Controls.Add(this.step10);
            this.groupBox1.Controls.Add(this.step5);
            this.groupBox1.Controls.Add(this.step1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.stepperMode);
            this.groupBox1.Controls.Add(this.RegistersView);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ProgramCounterView);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.AddressCounterView);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.StackPointerView);
            this.groupBox1.Controls.Add(this.StackView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(0, 378);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1040, 199);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Diagnosics";
            // 
            // step100
            // 
            this.step100.Enabled = false;
            this.step100.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.step100.Location = new System.Drawing.Point(12, 144);
            this.step100.Name = "step100";
            this.step100.Size = new System.Drawing.Size(113, 27);
            this.step100.TabIndex = 19;
            this.step100.Text = "Step 100";
            this.step100.UseVisualStyleBackColor = true;
            this.step100.Click += new System.EventHandler(this.Step100_Click);
            // 
            // step10
            // 
            this.step10.Enabled = false;
            this.step10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.step10.Location = new System.Drawing.Point(12, 111);
            this.step10.Name = "step10";
            this.step10.Size = new System.Drawing.Size(113, 27);
            this.step10.TabIndex = 18;
            this.step10.Text = "Step 10";
            this.step10.UseVisualStyleBackColor = true;
            this.step10.Click += new System.EventHandler(this.Step10_Click);
            // 
            // step5
            // 
            this.step5.Enabled = false;
            this.step5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.step5.Location = new System.Drawing.Point(12, 78);
            this.step5.Name = "step5";
            this.step5.Size = new System.Drawing.Size(113, 27);
            this.step5.TabIndex = 17;
            this.step5.Text = "Step 5";
            this.step5.UseVisualStyleBackColor = true;
            this.step5.Click += new System.EventHandler(this.Step5_Click);
            // 
            // step1
            // 
            this.step1.Enabled = false;
            this.step1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.step1.Location = new System.Drawing.Point(12, 45);
            this.step1.Name = "step1";
            this.step1.Size = new System.Drawing.Size(113, 27);
            this.step1.TabIndex = 16;
            this.step1.Text = "Step 1";
            this.step1.UseVisualStyleBackColor = true;
            this.step1.Click += new System.EventHandler(this.Step1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(594, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Stack Pointer:";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.display_screen);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 378);
            this.panel1.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(28, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "Keyboard Input";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.71795F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.28205F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.keypadF, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.keypadB, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.keypad0, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.keypadA, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.keypadE, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.keypad9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.keypad8, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.keypad7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.keypadD, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.keypad6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.keypad5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.keypad4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.keypadC, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.keypad3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.keypad2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.keypad1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 217);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(157, 149);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // keypadF
            // 
            this.keypadF.AutoSize = true;
            this.keypadF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypadF.Location = new System.Drawing.Point(117, 115);
            this.keypadF.Margin = new System.Windows.Forms.Padding(1);
            this.keypadF.Name = "keypadF";
            this.keypadF.Size = new System.Drawing.Size(39, 33);
            this.keypadF.TabIndex = 15;
            this.keypadF.Text = "F";
            this.keypadF.UseVisualStyleBackColor = true;
            // 
            // keypadB
            // 
            this.keypadB.AutoSize = true;
            this.keypadB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypadB.Location = new System.Drawing.Point(76, 115);
            this.keypadB.Margin = new System.Windows.Forms.Padding(1);
            this.keypadB.Name = "keypadB";
            this.keypadB.Size = new System.Drawing.Size(39, 33);
            this.keypadB.TabIndex = 14;
            this.keypadB.Text = "B";
            this.keypadB.UseVisualStyleBackColor = true;
            // 
            // keypad0
            // 
            this.keypad0.AutoSize = true;
            this.keypad0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypad0.Location = new System.Drawing.Point(38, 115);
            this.keypad0.Margin = new System.Windows.Forms.Padding(1);
            this.keypad0.Name = "keypad0";
            this.keypad0.Size = new System.Drawing.Size(36, 33);
            this.keypad0.TabIndex = 13;
            this.keypad0.Text = "0";
            this.keypad0.UseVisualStyleBackColor = true;
            // 
            // keypadA
            // 
            this.keypadA.AutoSize = true;
            this.keypadA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypadA.Location = new System.Drawing.Point(1, 115);
            this.keypadA.Margin = new System.Windows.Forms.Padding(1);
            this.keypadA.Name = "keypadA";
            this.keypadA.Size = new System.Drawing.Size(35, 33);
            this.keypadA.TabIndex = 12;
            this.keypadA.Text = "A";
            this.keypadA.UseVisualStyleBackColor = true;
            // 
            // keypadE
            // 
            this.keypadE.AutoSize = true;
            this.keypadE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypadE.Location = new System.Drawing.Point(117, 75);
            this.keypadE.Margin = new System.Windows.Forms.Padding(1);
            this.keypadE.Name = "keypadE";
            this.keypadE.Size = new System.Drawing.Size(39, 38);
            this.keypadE.TabIndex = 11;
            this.keypadE.Text = "E";
            this.keypadE.UseVisualStyleBackColor = true;
            // 
            // keypad9
            // 
            this.keypad9.AutoSize = true;
            this.keypad9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypad9.Location = new System.Drawing.Point(76, 75);
            this.keypad9.Margin = new System.Windows.Forms.Padding(1);
            this.keypad9.Name = "keypad9";
            this.keypad9.Size = new System.Drawing.Size(39, 38);
            this.keypad9.TabIndex = 10;
            this.keypad9.Text = "9";
            this.keypad9.UseVisualStyleBackColor = true;
            // 
            // keypad8
            // 
            this.keypad8.AutoSize = true;
            this.keypad8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypad8.Location = new System.Drawing.Point(38, 75);
            this.keypad8.Margin = new System.Windows.Forms.Padding(1);
            this.keypad8.Name = "keypad8";
            this.keypad8.Size = new System.Drawing.Size(36, 38);
            this.keypad8.TabIndex = 9;
            this.keypad8.Text = "8";
            this.keypad8.UseVisualStyleBackColor = true;
            // 
            // keypad7
            // 
            this.keypad7.AutoSize = true;
            this.keypad7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypad7.Location = new System.Drawing.Point(1, 75);
            this.keypad7.Margin = new System.Windows.Forms.Padding(1);
            this.keypad7.Name = "keypad7";
            this.keypad7.Size = new System.Drawing.Size(35, 38);
            this.keypad7.TabIndex = 8;
            this.keypad7.Text = "7";
            this.keypad7.UseVisualStyleBackColor = true;
            // 
            // keypadD
            // 
            this.keypadD.AutoSize = true;
            this.keypadD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypadD.Location = new System.Drawing.Point(117, 37);
            this.keypadD.Margin = new System.Windows.Forms.Padding(1);
            this.keypadD.Name = "keypadD";
            this.keypadD.Size = new System.Drawing.Size(39, 36);
            this.keypadD.TabIndex = 7;
            this.keypadD.Text = "D";
            this.keypadD.UseVisualStyleBackColor = true;
            // 
            // keypad6
            // 
            this.keypad6.AutoSize = true;
            this.keypad6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypad6.Location = new System.Drawing.Point(76, 37);
            this.keypad6.Margin = new System.Windows.Forms.Padding(1);
            this.keypad6.Name = "keypad6";
            this.keypad6.Size = new System.Drawing.Size(39, 36);
            this.keypad6.TabIndex = 6;
            this.keypad6.Text = "6";
            this.keypad6.UseVisualStyleBackColor = true;
            // 
            // keypad5
            // 
            this.keypad5.AutoSize = true;
            this.keypad5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypad5.Location = new System.Drawing.Point(38, 37);
            this.keypad5.Margin = new System.Windows.Forms.Padding(1);
            this.keypad5.Name = "keypad5";
            this.keypad5.Size = new System.Drawing.Size(36, 36);
            this.keypad5.TabIndex = 5;
            this.keypad5.Text = "5";
            this.keypad5.UseVisualStyleBackColor = true;
            // 
            // keypad4
            // 
            this.keypad4.AutoSize = true;
            this.keypad4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypad4.Location = new System.Drawing.Point(1, 37);
            this.keypad4.Margin = new System.Windows.Forms.Padding(1);
            this.keypad4.Name = "keypad4";
            this.keypad4.Size = new System.Drawing.Size(35, 36);
            this.keypad4.TabIndex = 4;
            this.keypad4.Text = "4";
            this.keypad4.UseVisualStyleBackColor = true;
            // 
            // keypadC
            // 
            this.keypadC.AutoSize = true;
            this.keypadC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypadC.Location = new System.Drawing.Point(117, 1);
            this.keypadC.Margin = new System.Windows.Forms.Padding(1);
            this.keypadC.Name = "keypadC";
            this.keypadC.Size = new System.Drawing.Size(39, 34);
            this.keypadC.TabIndex = 3;
            this.keypadC.Text = "C";
            this.keypadC.UseVisualStyleBackColor = true;
            // 
            // keypad3
            // 
            this.keypad3.AutoSize = true;
            this.keypad3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypad3.Location = new System.Drawing.Point(76, 1);
            this.keypad3.Margin = new System.Windows.Forms.Padding(1);
            this.keypad3.Name = "keypad3";
            this.keypad3.Size = new System.Drawing.Size(39, 34);
            this.keypad3.TabIndex = 2;
            this.keypad3.Text = "3";
            this.keypad3.UseVisualStyleBackColor = true;
            // 
            // keypad2
            // 
            this.keypad2.AutoSize = true;
            this.keypad2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypad2.Location = new System.Drawing.Point(38, 1);
            this.keypad2.Margin = new System.Windows.Forms.Padding(1);
            this.keypad2.Name = "keypad2";
            this.keypad2.Size = new System.Drawing.Size(36, 34);
            this.keypad2.TabIndex = 1;
            this.keypad2.Text = "2";
            this.keypad2.UseVisualStyleBackColor = true;
            // 
            // keypad1
            // 
            this.keypad1.AutoSize = true;
            this.keypad1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypad1.Location = new System.Drawing.Point(1, 1);
            this.keypad1.Margin = new System.Windows.Forms.Padding(1);
            this.keypad1.Name = "keypad1";
            this.keypad1.Size = new System.Drawing.Size(35, 34);
            this.keypad1.TabIndex = 0;
            this.keypad1.Text = "1";
            this.keypad1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.RamView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(840, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 378);
            this.panel2.TabIndex = 1;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1040, 577);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GUI";
            this.Text = "Chip-8 Emulator";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SetKeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.display_screen)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox display_screen;
        private System.Windows.Forms.ListBox RamView;
        private System.Windows.Forms.ListBox RegistersView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox ProgramCounterView;
        private System.Windows.Forms.ListBox AddressCounterView;
        private System.Windows.Forms.ListBox StackPointerView;
        private System.Windows.Forms.ListBox StackView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox stepperMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button step100;
        private System.Windows.Forms.Button step10;
        private System.Windows.Forms.Button step5;
        private System.Windows.Forms.Button step1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button keypadF;
        private System.Windows.Forms.Button keypadB;
        private System.Windows.Forms.Button keypad0;
        private System.Windows.Forms.Button keypadA;
        private System.Windows.Forms.Button keypadE;
        private System.Windows.Forms.Button keypad9;
        private System.Windows.Forms.Button keypad8;
        private System.Windows.Forms.Button keypad7;
        private System.Windows.Forms.Button keypadD;
        private System.Windows.Forms.Button keypad6;
        private System.Windows.Forms.Button keypad5;
        private System.Windows.Forms.Button keypad4;
        private System.Windows.Forms.Button keypadC;
        private System.Windows.Forms.Button keypad3;
        private System.Windows.Forms.Button keypad2;
        private System.Windows.Forms.Button keypad1;
        private System.Windows.Forms.Label label6;
    }
}
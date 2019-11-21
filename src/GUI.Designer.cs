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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.display_screen)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.RamView.BackColor = System.Drawing.Color.Black;
            this.RamView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RamView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RamView.ForeColor = System.Drawing.Color.White;
            this.RamView.FormattingEnabled = true;
            this.RamView.ItemHeight = 16;
            this.RamView.Location = new System.Drawing.Point(16, 12);
            this.RamView.Name = "RamView";
            this.RamView.Size = new System.Drawing.Size(202, 306);
            this.RamView.TabIndex = 4;
            this.RamView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetKeyDown);
            this.RamView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SetKeyUp);
            // 
            // RegistersView
            // 
            this.RegistersView.BackColor = System.Drawing.Color.Black;
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
            this.ProgramCounterView.BackColor = System.Drawing.Color.Black;
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
            this.AddressCounterView.BackColor = System.Drawing.Color.Black;
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
            this.StackPointerView.BackColor = System.Drawing.Color.Black;
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
            this.StackView.BackColor = System.Drawing.Color.Black;
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
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
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
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.display_screen);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 378);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RamView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(840, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 378);
            this.panel2.TabIndex = 1;
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
            this.Load += new System.EventHandler(this.GUI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SetKeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.display_screen)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
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
    }
}
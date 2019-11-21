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
            ((System.ComponentModel.ISupportInitialize)(this.display_screen)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(52, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // display_screen
            // 
            this.display_screen.AccessibleDescription = "The screen which displays the emulated roms.";
            this.display_screen.AccessibleName = "output_screen";
            this.display_screen.Location = new System.Drawing.Point(88, 68);
            this.display_screen.Name = "display_screen";
            this.display_screen.Size = new System.Drawing.Size(640, 320);
            this.display_screen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.display_screen.TabIndex = 0;
            this.display_screen.TabStop = false;
            // 
            // RamView
            // 
            this.RamView.BackColor = System.Drawing.Color.Black;
            this.RamView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RamView.ForeColor = System.Drawing.Color.White;
            this.RamView.FormattingEnabled = true;
            this.RamView.Location = new System.Drawing.Point(743, 68);
            this.RamView.Name = "RamView";
            this.RamView.Size = new System.Drawing.Size(202, 314);
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
            this.RegistersView.Location = new System.Drawing.Point(868, 403);
            this.RegistersView.Name = "RegistersView";
            this.RegistersView.Size = new System.Drawing.Size(77, 132);
            this.RegistersView.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(573, 506);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Program Counter:";
            // 
            // ProgramCounterView
            // 
            this.ProgramCounterView.BackColor = System.Drawing.Color.Black;
            this.ProgramCounterView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProgramCounterView.ForeColor = System.Drawing.Color.White;
            this.ProgramCounterView.FormattingEnabled = true;
            this.ProgramCounterView.Location = new System.Drawing.Point(668, 506);
            this.ProgramCounterView.Name = "ProgramCounterView";
            this.ProgramCounterView.Size = new System.Drawing.Size(60, 15);
            this.ProgramCounterView.TabIndex = 7;
            // 
            // AddressCounterView
            // 
            this.AddressCounterView.BackColor = System.Drawing.Color.Black;
            this.AddressCounterView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddressCounterView.ForeColor = System.Drawing.Color.White;
            this.AddressCounterView.FormattingEnabled = true;
            this.AddressCounterView.Location = new System.Drawing.Point(668, 519);
            this.AddressCounterView.Name = "AddressCounterView";
            this.AddressCounterView.Size = new System.Drawing.Size(60, 15);
            this.AddressCounterView.TabIndex = 8;
            // 
            // StackPointerView
            // 
            this.StackPointerView.BackColor = System.Drawing.Color.Black;
            this.StackPointerView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StackPointerView.ForeColor = System.Drawing.Color.White;
            this.StackPointerView.FormattingEnabled = true;
            this.StackPointerView.Location = new System.Drawing.Point(755, 519);
            this.StackPointerView.Name = "StackPointerView";
            this.StackPointerView.Size = new System.Drawing.Size(73, 15);
            this.StackPointerView.TabIndex = 9;
            // 
            // StackView
            // 
            this.StackView.BackColor = System.Drawing.Color.Black;
            this.StackView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StackView.ForeColor = System.Drawing.Color.White;
            this.StackView.FormattingEnabled = true;
            this.StackView.Location = new System.Drawing.Point(755, 435);
            this.StackView.Name = "StackView";
            this.StackView.Size = new System.Drawing.Size(73, 80);
            this.StackView.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(574, 519);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Address Counter:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(865, 385);
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
            this.label4.Location = new System.Drawing.Point(764, 414);
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
            this.stepperMode.Location = new System.Drawing.Point(112, 487);
            this.stepperMode.Name = "stepperMode";
            this.stepperMode.Size = new System.Drawing.Size(113, 20);
            this.stepperMode.TabIndex = 14;
            this.stepperMode.Text = "Stepper Mode";
            this.stepperMode.UseVisualStyleBackColor = true;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(957, 547);
            this.Controls.Add(this.stepperMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StackView);
            this.Controls.Add(this.StackPointerView);
            this.Controls.Add(this.AddressCounterView);
            this.Controls.Add(this.ProgramCounterView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RegistersView);
            this.Controls.Add(this.RamView);
            this.Controls.Add(this.display_screen);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GUI";
            this.Text = "Chip-8 Emulator";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SetKeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.display_screen)).EndInit();
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
    }
}
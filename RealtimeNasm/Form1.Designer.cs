namespace RealtimeNasm
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.asmBox = new System.Windows.Forms.RichTextBox();
            this.outBox = new System.Windows.Forms.TextBox();
            this.bytesBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.arrayRb = new System.Windows.Forms.RadioButton();
            this.hexRb = new System.Windows.Forms.RadioButton();
            this.decimalRb = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.asmTimer = new System.Windows.Forms.Timer(this.components);
            this.openBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // asmBox
            // 
            this.asmBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.asmBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.asmBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asmBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.asmBox.Location = new System.Drawing.Point(12, 40);
            this.asmBox.Name = "asmBox";
            this.asmBox.Size = new System.Drawing.Size(511, 305);
            this.asmBox.TabIndex = 0;
            this.asmBox.Text = "[bits 32]";
            this.asmBox.TextChanged += new System.EventHandler(this.asmBox_TextChanged);
            // 
            // outBox
            // 
            this.outBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.outBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outBox.ForeColor = System.Drawing.Color.White;
            this.outBox.Location = new System.Drawing.Point(12, 373);
            this.outBox.Multiline = true;
            this.outBox.Name = "outBox";
            this.outBox.Size = new System.Drawing.Size(882, 119);
            this.outBox.TabIndex = 2;
            // 
            // bytesBox
            // 
            this.bytesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.bytesBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bytesBox.ForeColor = System.Drawing.Color.White;
            this.bytesBox.Location = new System.Drawing.Point(529, 40);
            this.bytesBox.Multiline = true;
            this.bytesBox.Name = "bytesBox";
            this.bytesBox.Size = new System.Drawing.Size(365, 305);
            this.bytesBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(529, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Output:";
            // 
            // arrayRb
            // 
            this.arrayRb.AutoSize = true;
            this.arrayRb.Checked = true;
            this.arrayRb.Location = new System.Drawing.Point(583, 17);
            this.arrayRb.Name = "arrayRb";
            this.arrayRb.Size = new System.Drawing.Size(51, 17);
            this.arrayRb.TabIndex = 5;
            this.arrayRb.TabStop = true;
            this.arrayRb.Text = "Array";
            this.arrayRb.UseVisualStyleBackColor = true;
            // 
            // hexRb
            // 
            this.hexRb.AutoSize = true;
            this.hexRb.Location = new System.Drawing.Point(640, 17);
            this.hexRb.Name = "hexRb";
            this.hexRb.Size = new System.Drawing.Size(44, 17);
            this.hexRb.TabIndex = 6;
            this.hexRb.Text = "Hex";
            this.hexRb.UseVisualStyleBackColor = true;
            // 
            // decimalRb
            // 
            this.decimalRb.AutoSize = true;
            this.decimalRb.Location = new System.Drawing.Point(690, 17);
            this.decimalRb.Name = "decimalRb";
            this.decimalRb.Size = new System.Drawing.Size(65, 17);
            this.decimalRb.TabIndex = 7;
            this.decimalRb.Text = "Decimal";
            this.decimalRb.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "NASM messages:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(819, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Clear files";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // asmTimer
            // 
            this.asmTimer.Interval = 1500;
            this.asmTimer.Tick += new System.EventHandler(this.asmTimer_Tick);
            // 
            // openBtn
            // 
            this.openBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.openBtn.FlatAppearance.BorderSize = 0;
            this.openBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openBtn.Location = new System.Drawing.Point(13, 11);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 10;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = false;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Location = new System.Drawing.Point(94, 11);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(906, 505);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.decimalRb);
            this.Controls.Add(this.hexRb);
            this.Controls.Add(this.arrayRb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bytesBox);
            this.Controls.Add(this.outBox);
            this.Controls.Add(this.asmBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "RealtimeNasm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox asmBox;
        private System.Windows.Forms.TextBox outBox;
        private System.Windows.Forms.TextBox bytesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton arrayRb;
        private System.Windows.Forms.RadioButton hexRb;
        private System.Windows.Forms.RadioButton decimalRb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer asmTimer;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button saveBtn;
    }
}


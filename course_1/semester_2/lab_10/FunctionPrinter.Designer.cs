namespace lab_10
{
    partial class FunctionPrinter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.formulaText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.maxXTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.minXTextBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.minYTextBox = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.maxYTextBox = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.functionPrinterControl = new lab_10.FunctionPrinterControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.formulaText);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Function";
            // 
            // formulaText
            // 
            this.formulaText.Location = new System.Drawing.Point(7, 15);
            this.formulaText.Name = "formulaText";
            this.formulaText.Size = new System.Drawing.Size(121, 20);
            this.formulaText.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(6, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 133);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "X Range";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.maxXTextBox);
            this.groupBox4.Location = new System.Drawing.Point(6, 75);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(136, 50);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Right";
            // 
            // maxXTextBox
            // 
            this.maxXTextBox.Location = new System.Drawing.Point(9, 19);
            this.maxXTextBox.Name = "maxXTextBox";
            this.maxXTextBox.Size = new System.Drawing.Size(121, 20);
            this.maxXTextBox.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.minXTextBox);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(136, 50);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Left";
            // 
            // minXTextBox
            // 
            this.minXTextBox.Location = new System.Drawing.Point(6, 19);
            this.minXTextBox.Name = "minXTextBox";
            this.minXTextBox.Size = new System.Drawing.Size(121, 20);
            this.minXTextBox.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Location = new System.Drawing.Point(6, 214);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(151, 133);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Y Range";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.minYTextBox);
            this.groupBox6.Location = new System.Drawing.Point(6, 75);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(136, 50);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Bottom";
            // 
            // minYTextBox
            // 
            this.minYTextBox.Location = new System.Drawing.Point(9, 19);
            this.minYTextBox.Name = "minYTextBox";
            this.minYTextBox.Size = new System.Drawing.Size(121, 20);
            this.minYTextBox.TabIndex = 1;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.maxYTextBox);
            this.groupBox7.Location = new System.Drawing.Point(6, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(136, 50);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Top";
            // 
            // maxYTextBox
            // 
            this.maxYTextBox.Location = new System.Drawing.Point(6, 19);
            this.maxYTextBox.Name = "maxYTextBox";
            this.maxYTextBox.Size = new System.Drawing.Size(121, 20);
            this.maxYTextBox.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.groupBox1);
            this.groupBox8.Controls.Add(this.groupBox5);
            this.groupBox8.Controls.Add(this.groupBox2);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox8.Location = new System.Drawing.Point(636, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(164, 450);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Input";
            // 
            // functionPrinterControl
            // 
            this.functionPrinterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.functionPrinterControl.Location = new System.Drawing.Point(0, 0);
            this.functionPrinterControl.Name = "functionPrinterControl";
            this.functionPrinterControl.Size = new System.Drawing.Size(636, 450);
            this.functionPrinterControl.TabIndex = 5;
            // 
            // FunctionPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.functionPrinterControl);
            this.Controls.Add(this.groupBox8);
            this.Name = "FunctionPrinter";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox maxXTextBox;
        private System.Windows.Forms.TextBox minXTextBox;
        private System.Windows.Forms.TextBox formulaText;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox minYTextBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox maxYTextBox;
        private System.Windows.Forms.GroupBox groupBox8;
        private FunctionPrinterControl functionPrinterControl;
    }
}


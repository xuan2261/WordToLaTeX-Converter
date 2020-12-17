namespace WordToKaTeX
{
    partial class WordToLaTeX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordToLaTeX));
            this.inputButton = new System.Windows.Forms.Button();
            this.OutputButton = new System.Windows.Forms.Button();
            this.inputPathTextBox = new System.Windows.Forms.TextBox();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.ProgressBar();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.exitbutton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.zipPathTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputButton
            // 
            this.inputButton.Location = new System.Drawing.Point(41, 32);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(156, 23);
            this.inputButton.TabIndex = 0;
            this.inputButton.Text = "Input Path";
            this.inputButton.UseVisualStyleBackColor = true;
            // 
            // OutputButton
            // 
            this.OutputButton.Location = new System.Drawing.Point(41, 61);
            this.OutputButton.Name = "OutputButton";
            this.OutputButton.Size = new System.Drawing.Size(156, 23);
            this.OutputButton.TabIndex = 1;
            this.OutputButton.Text = "Output Path";
            this.OutputButton.UseVisualStyleBackColor = true;
            // 
            // inputPathTextBox
            // 
            this.inputPathTextBox.AllowDrop = true;
            this.inputPathTextBox.Location = new System.Drawing.Point(222, 34);
            this.inputPathTextBox.Name = "inputPathTextBox";
            this.inputPathTextBox.Size = new System.Drawing.Size(496, 20);
            this.inputPathTextBox.TabIndex = 2;
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Location = new System.Drawing.Point(222, 63);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(496, 20);
            this.outputPathTextBox.TabIndex = 3;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(25, 127);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(156, 41);
            this.ConvertButton.TabIndex = 4;
            this.ConvertButton.Text = "Convert To LaTeX";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(222, 90);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(496, 23);
            this.statusBar.TabIndex = 5;
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(222, 140);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.statusBox.Size = new System.Drawing.Size(496, 123);
            this.statusBox.TabIndex = 6;
            this.statusBox.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Status:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Zip Directories";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(222, 167);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(496, 80);
            this.textBox1.TabIndex = 10;
            this.textBox1.WordWrap = false;
            // 
            // exitbutton
            // 
            this.exitbutton.Location = new System.Drawing.Point(25, 193);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(156, 41);
            this.exitbutton.TabIndex = 11;
            this.exitbutton.Text = "Exit";
            this.exitbutton.UseVisualStyleBackColor = true;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(266, 121);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 13);
            this.statusLabel.TabIndex = 12;
            this.statusLabel.Text = "label2";
            // 
            // zipPathTextBox
            // 
            this.zipPathTextBox.Location = new System.Drawing.Point(210, 30);
            this.zipPathTextBox.Name = "zipPathTextBox";
            this.zipPathTextBox.Size = new System.Drawing.Size(496, 20);
            this.zipPathTextBox.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.zipPathTextBox);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(12, 281);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(730, 69);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Provide the root directory path to Zip files:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ConvertButton);
            this.groupBox3.Controls.Add(this.exitbutton);
            this.groupBox3.Location = new System.Drawing.Point(16, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(726, 262);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Word To KaTeX:";
            // 
            // WordToLaTeX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(754, 371);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.outputPathTextBox);
            this.Controls.Add(this.inputPathTextBox);
            this.Controls.Add(this.OutputButton);
            this.Controls.Add(this.inputButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(770, 410);
            this.MinimumSize = new System.Drawing.Size(770, 410);
            this.Name = "WordToLaTeX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Word To LaTeX Converter";
            this.Load += new System.EventHandler(this.WordToKaTeX_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.Button OutputButton;
        private System.Windows.Forms.TextBox inputPathTextBox;
        private System.Windows.Forms.TextBox outputPathTextBox;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.ProgressBar statusBar;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button exitbutton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox zipPathTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}


namespace Avalon
{
    partial class FromText
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
            this.readFromFileButton = new System.Windows.Forms.Button();
            this.isBaseNotWrite = new System.Windows.Forms.CheckBox();
            this.addContragentsManualyButton = new System.Windows.Forms.Button();
            this.textBoxF11 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxF11Choosing = new System.Windows.Forms.ComboBox();
            this.comboBoxF12Choosing = new System.Windows.Forms.ComboBox();
            this.addContragentsByINNButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProgLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // readFromFileButton
            // 
            this.readFromFileButton.Location = new System.Drawing.Point(280, 31);
            this.readFromFileButton.Name = "readFromFileButton";
            this.readFromFileButton.Size = new System.Drawing.Size(95, 45);
            this.readFromFileButton.TabIndex = 0;
            this.readFromFileButton.Text = "Считать из файла";
            this.readFromFileButton.UseVisualStyleBackColor = true;
            this.readFromFileButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // isBaseNotWrite
            // 
            this.isBaseNotWrite.AutoSize = true;
            this.isBaseNotWrite.Checked = true;
            this.isBaseNotWrite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isBaseNotWrite.Enabled = false;
            this.isBaseNotWrite.Location = new System.Drawing.Point(392, 27);
            this.isBaseNotWrite.Name = "isBaseNotWrite";
            this.isBaseNotWrite.Size = new System.Drawing.Size(139, 17);
            this.isBaseNotWrite.TabIndex = 3;
            this.isBaseNotWrite.Text = "Не записывать в базу";
            this.isBaseNotWrite.UseVisualStyleBackColor = true;
            // 
            // addContragentsManualyButton
            // 
            this.addContragentsManualyButton.Location = new System.Drawing.Point(392, 48);
            this.addContragentsManualyButton.Name = "addContragentsManualyButton";
            this.addContragentsManualyButton.Size = new System.Drawing.Size(242, 28);
            this.addContragentsManualyButton.TabIndex = 17;
            this.addContragentsManualyButton.Text = "Заполнить контрагентов (без лицензий)";
            this.addContragentsManualyButton.UseVisualStyleBackColor = true;
            this.addContragentsManualyButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxF11
            // 
            this.textBoxF11.Location = new System.Drawing.Point(20, 2);
            this.textBoxF11.Name = "textBoxF11";
            this.textBoxF11.Size = new System.Drawing.Size(355, 20);
            this.textBoxF11.TabIndex = 15;
            this.textBoxF11.Text = "maintext.txt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Номер декларации F12";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Номер декларации F11";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 79);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(769, 340);
            this.textBox1.TabIndex = 12;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBoxF11Choosing
            // 
            this.comboBoxF11Choosing.FormattingEnabled = true;
            this.comboBoxF11Choosing.Location = new System.Drawing.Point(162, 28);
            this.comboBoxF11Choosing.Name = "comboBoxF11Choosing";
            this.comboBoxF11Choosing.Size = new System.Drawing.Size(112, 21);
            this.comboBoxF11Choosing.TabIndex = 18;
            this.comboBoxF11Choosing.SelectedIndexChanged += new System.EventHandler(this.comboBoxF11Choosing_SelectedIndexChanged);
            // 
            // comboBoxF12Choosing
            // 
            this.comboBoxF12Choosing.FormattingEnabled = true;
            this.comboBoxF12Choosing.Location = new System.Drawing.Point(162, 55);
            this.comboBoxF12Choosing.Name = "comboBoxF12Choosing";
            this.comboBoxF12Choosing.Size = new System.Drawing.Size(112, 21);
            this.comboBoxF12Choosing.TabIndex = 19;
            // 
            // addContragentsByINNButton
            // 
            this.addContragentsByINNButton.Location = new System.Drawing.Point(392, 2);
            this.addContragentsByINNButton.Name = "addContragentsByINNButton";
            this.addContragentsByINNButton.Size = new System.Drawing.Size(242, 23);
            this.addContragentsByINNButton.TabIndex = 20;
            this.addContragentsByINNButton.Text = "Заполнить подразделения (без лицензий)";
            this.addContragentsByINNButton.UseVisualStyleBackColor = true;
            this.addContragentsByINNButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 425);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(756, 15);
            this.progressBar1.TabIndex = 21;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // ProgLabel
            // 
            this.ProgLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ProgLabel.AutoSize = true;
            this.ProgLabel.Location = new System.Drawing.Point(17, 402);
            this.ProgLabel.Name = "ProgLabel";
            this.ProgLabel.Size = new System.Drawing.Size(0, 13);
            this.ProgLabel.TabIndex = 22;
            // 
            // FromText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 443);
            this.Controls.Add(this.ProgLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.addContragentsByINNButton);
            this.Controls.Add(this.comboBoxF12Choosing);
            this.Controls.Add(this.comboBoxF11Choosing);
            this.Controls.Add(this.addContragentsManualyButton);
            this.Controls.Add(this.textBoxF11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.isBaseNotWrite);
            this.Controls.Add(this.readFromFileButton);
            this.Name = "FromText";
            this.Text = "Из текстового файла";
            this.Load += new System.EventHandler(this.FromText_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readFromFileButton;
        private System.Windows.Forms.CheckBox isBaseNotWrite;
        private System.Windows.Forms.Button addContragentsManualyButton;
        private System.Windows.Forms.TextBox textBoxF11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.IO.StreamWriter erfile;
        private System.IO.StreamWriter noform;
        private System.Windows.Forms.ComboBox comboBoxF11Choosing;
        private System.Windows.Forms.ComboBox comboBoxF12Choosing;
        private System.Windows.Forms.Button addContragentsByINNButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label ProgLabel;
    }
}
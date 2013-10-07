namespace Avalon
{
    partial class EndsForm
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
            this.sourceBox = new System.Windows.Forms.ComboBox();
            this.destBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SText = new System.Windows.Forms.TextBox();
            this.DText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sourceBox
            // 
            this.sourceBox.FormattingEnabled = true;
            this.sourceBox.Location = new System.Drawing.Point(66, 43);
            this.sourceBox.Name = "sourceBox";
            this.sourceBox.Size = new System.Drawing.Size(88, 21);
            this.sourceBox.TabIndex = 0;
            // 
            // destBox
            // 
            this.destBox.FormattingEnabled = true;
            this.destBox.Location = new System.Drawing.Point(495, 46);
            this.destBox.Name = "destBox";
            this.destBox.Size = new System.Drawing.Size(92, 21);
            this.destBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Из";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "В";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Контрагенты отсутсвующие в базе - источнике";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Контрагенты отсутсвующие в базе - приемнике";
            // 
            // SText
            // 
            this.SText.Location = new System.Drawing.Point(0, 105);
            this.SText.Multiline = true;
            this.SText.Name = "SText";
            this.SText.Size = new System.Drawing.Size(328, 263);
            this.SText.TabIndex = 6;
            // 
            // DText
            // 
            this.DText.Location = new System.Drawing.Point(334, 105);
            this.DText.Multiline = true;
            this.DText.Name = "DText";
            this.DText.Size = new System.Drawing.Size(358, 263);
            this.DText.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(617, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Переписать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EndsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 368);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DText);
            this.Controls.Add(this.SText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.destBox);
            this.Controls.Add(this.sourceBox);
            this.Name = "EndsForm";
            this.Text = "EndsForm";
            this.Load += new System.EventHandler(this.EndsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox sourceBox;
        private System.Windows.Forms.ComboBox destBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SText;
        private System.Windows.Forms.TextBox DText;
        private System.Windows.Forms.Button button1;
    }
}
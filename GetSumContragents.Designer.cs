namespace Avalon
{
    partial class BaseEditor
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Tab = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DelDec = new System.Windows.Forms.Button();
            this.ContrDel = new System.Windows.Forms.Button();
            this.DelTtnBtn = new System.Windows.Forms.Button();
            this.DeleteRecords = new System.Windows.Forms.Button();
            this.prodCheckBox = new System.Windows.Forms.CheckBox();
            this.recordListBox_ = new System.Windows.Forms.ListBox();
            this.ttnListBox_ = new System.Windows.Forms.ListBox();
            this.orgListBox_ = new System.Windows.Forms.ListBox();
            this.decListBox_ = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ContragentsAndTaxButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabBW = new System.Windows.Forms.TabPage();
            this.btnIntoBase_ = new System.Windows.Forms.Button();
            this.btnCopyAll_ = new System.Windows.Forms.Button();
            this.nBaseCombo = new System.Windows.Forms.ComboBox();
            this.bCombo = new System.Windows.Forms.ComboBox();
            this.bButton_ = new System.Windows.Forms.Button();
            this.bLabel_ = new System.Windows.Forms.Label();
            this.openBaseDialog_ = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Tab.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabBW.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(433, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "По контрагентам";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(757, 305);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Узнать количество остатков по декларации с номером:";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(211, 355);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(216, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Tab
            // 
            this.Tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tab.Controls.Add(this.tabPage2);
            this.Tab.Controls.Add(this.tabPage1);
            this.Tab.Controls.Add(this.tabBW);
            this.Tab.Location = new System.Drawing.Point(-2, 2);
            this.Tab.Name = "Tab";
            this.Tab.SelectedIndex = 0;
            this.Tab.Size = new System.Drawing.Size(840, 430);
            this.Tab.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.DelDec);
            this.tabPage2.Controls.Add(this.ContrDel);
            this.tabPage2.Controls.Add(this.DelTtnBtn);
            this.tabPage2.Controls.Add(this.DeleteRecords);
            this.tabPage2.Controls.Add(this.prodCheckBox);
            this.tabPage2.Controls.Add(this.recordListBox_);
            this.tabPage2.Controls.Add(this.ttnListBox_);
            this.tabPage2.Controls.Add(this.orgListBox_);
            this.tabPage2.Controls.Add(this.decListBox_);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(832, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Редактор базы";
            // 
            // DelDec
            // 
            this.DelDec.Location = new System.Drawing.Point(10, 62);
            this.DelDec.Name = "DelDec";
            this.DelDec.Size = new System.Drawing.Size(140, 23);
            this.DelDec.TabIndex = 8;
            this.DelDec.Text = "Удалить декларацию";
            this.DelDec.UseVisualStyleBackColor = true;
            this.DelDec.Click += new System.EventHandler(this.DelDec_Click);
            // 
            // ContrDel
            // 
            this.ContrDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ContrDel.Location = new System.Drawing.Point(6, 368);
            this.ContrDel.Name = "ContrDel";
            this.ContrDel.Size = new System.Drawing.Size(140, 23);
            this.ContrDel.TabIndex = 7;
            this.ContrDel.Text = "Удалить контрагентов";
            this.ContrDel.UseVisualStyleBackColor = true;
            this.ContrDel.Click += new System.EventHandler(this.ContrDel_Click);
            // 
            // DelTtnBtn
            // 
            this.DelTtnBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DelTtnBtn.Location = new System.Drawing.Point(259, 369);
            this.DelTtnBtn.Name = "DelTtnBtn";
            this.DelTtnBtn.Size = new System.Drawing.Size(128, 23);
            this.DelTtnBtn.TabIndex = 6;
            this.DelTtnBtn.Text = "Удалить накладные";
            this.DelTtnBtn.UseVisualStyleBackColor = true;
            this.DelTtnBtn.Click += new System.EventHandler(this.DelTtnBtn_Click);
            // 
            // DeleteRecords
            // 
            this.DeleteRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteRecords.Location = new System.Drawing.Point(459, 369);
            this.DeleteRecords.Name = "DeleteRecords";
            this.DeleteRecords.Size = new System.Drawing.Size(105, 23);
            this.DeleteRecords.TabIndex = 5;
            this.DeleteRecords.Text = "Удалить записи";
            this.DeleteRecords.UseVisualStyleBackColor = true;
            this.DeleteRecords.Click += new System.EventHandler(this.DeleteRecords_Click);
            // 
            // prodCheckBox
            // 
            this.prodCheckBox.AutoSize = true;
            this.prodCheckBox.Location = new System.Drawing.Point(6, 91);
            this.prodCheckBox.Name = "prodCheckBox";
            this.prodCheckBox.Size = new System.Drawing.Size(163, 17);
            this.prodCheckBox.TabIndex = 4;
            this.prodCheckBox.Text = "Считать по производителю";
            this.prodCheckBox.UseVisualStyleBackColor = true;
            this.prodCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // recordListBox_
            // 
            this.recordListBox_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recordListBox_.FormattingEnabled = true;
            this.recordListBox_.Location = new System.Drawing.Point(665, 0);
            this.recordListBox_.Name = "recordListBox_";
            this.recordListBox_.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.recordListBox_.Size = new System.Drawing.Size(167, 355);
            this.recordListBox_.TabIndex = 3;
            // 
            // ttnListBox_
            // 
            this.ttnListBox_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ttnListBox_.FormattingEnabled = true;
            this.ttnListBox_.Location = new System.Drawing.Point(362, 0);
            this.ttnListBox_.Name = "ttnListBox_";
            this.ttnListBox_.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ttnListBox_.Size = new System.Drawing.Size(297, 355);
            this.ttnListBox_.TabIndex = 2;
            this.ttnListBox_.SelectedIndexChanged += new System.EventHandler(this.ttnListBox__SelectedIndexChanged);
            // 
            // orgListBox_
            // 
            this.orgListBox_.FormattingEnabled = true;
            this.orgListBox_.Location = new System.Drawing.Point(0, 116);
            this.orgListBox_.Name = "orgListBox_";
            this.orgListBox_.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.orgListBox_.Size = new System.Drawing.Size(356, 238);
            this.orgListBox_.TabIndex = 1;
            this.orgListBox_.SelectedIndexChanged += new System.EventHandler(this.orgListBox__SelectedIndexChanged);
            // 
            // decListBox_
            // 
            this.decListBox_.FormattingEnabled = true;
            this.decListBox_.Location = new System.Drawing.Point(0, 0);
            this.decListBox_.Name = "decListBox_";
            this.decListBox_.Size = new System.Drawing.Size(356, 56);
            this.decListBox_.TabIndex = 0;
            this.decListBox_.SelectedIndexChanged += new System.EventHandler(this.decListBox__SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.ContragentsAndTaxButton);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(766, 396);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Сумма/Контрагент";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // ContragentsAndTaxButton
            // 
            this.ContragentsAndTaxButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ContragentsAndTaxButton.Location = new System.Drawing.Point(547, 352);
            this.ContragentsAndTaxButton.Name = "ContragentsAndTaxButton";
            this.ContragentsAndTaxButton.Size = new System.Drawing.Size(108, 34);
            this.ContragentsAndTaxButton.TabIndex = 7;
            this.ContragentsAndTaxButton.Text = "Контрагентам и накладным";
            this.ContragentsAndTaxButton.UseVisualStyleBackColor = true;
            this.ContragentsAndTaxButton.Click += new System.EventHandler(this.ContragentsAndTaxButton_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(547, 322);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 24);
            this.button3.TabIndex = 6;
            this.button3.Text = "По типам";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(433, 352);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 24);
            this.button2.TabIndex = 5;
            this.button2.Text = "По накладным";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabBW
            // 
            this.tabBW.AutoScroll = true;
            this.tabBW.BackColor = System.Drawing.SystemColors.Control;
            this.tabBW.Controls.Add(this.btnIntoBase_);
            this.tabBW.Controls.Add(this.btnCopyAll_);
            this.tabBW.Controls.Add(this.nBaseCombo);
            this.tabBW.Controls.Add(this.bCombo);
            this.tabBW.Controls.Add(this.bButton_);
            this.tabBW.Controls.Add(this.bLabel_);
            this.tabBW.Location = new System.Drawing.Point(4, 22);
            this.tabBW.Name = "tabBW";
            this.tabBW.Padding = new System.Windows.Forms.Padding(3);
            this.tabBW.Size = new System.Drawing.Size(766, 396);
            this.tabBW.TabIndex = 2;
            this.tabBW.Text = "Остатки";
            // 
            // btnIntoBase_
            // 
            this.btnIntoBase_.Location = new System.Drawing.Point(155, 53);
            this.btnIntoBase_.Name = "btnIntoBase_";
            this.btnIntoBase_.Size = new System.Drawing.Size(125, 23);
            this.btnIntoBase_.TabIndex = 5;
            this.btnIntoBase_.Text = "Занести все в базу";
            this.btnIntoBase_.UseVisualStyleBackColor = true;
            this.btnIntoBase_.Visible = false;
            this.btnIntoBase_.Click += new System.EventHandler(this.btnIntoBase__Click);
            // 
            // btnCopyAll_
            // 
            this.btnCopyAll_.Location = new System.Drawing.Point(10, 53);
            this.btnCopyAll_.Name = "btnCopyAll_";
            this.btnCopyAll_.Size = new System.Drawing.Size(110, 23);
            this.btnCopyAll_.TabIndex = 4;
            this.btnCopyAll_.Text = "Скопировать все";
            this.btnCopyAll_.UseVisualStyleBackColor = true;
            this.btnCopyAll_.Visible = false;
            this.btnCopyAll_.Click += new System.EventHandler(this.btnCopyAll__Click);
            // 
            // nBaseCombo
            // 
            this.nBaseCombo.FormattingEnabled = true;
            this.nBaseCombo.Location = new System.Drawing.Point(98, 16);
            this.nBaseCombo.Name = "nBaseCombo";
            this.nBaseCombo.Size = new System.Drawing.Size(64, 21);
            this.nBaseCombo.TabIndex = 3;
            this.nBaseCombo.SelectedIndexChanged += new System.EventHandler(this.nBaseCombo_SelectedIndexChanged);
            // 
            // bCombo
            // 
            this.bCombo.FormattingEnabled = true;
            this.bCombo.Location = new System.Drawing.Point(10, 16);
            this.bCombo.Name = "bCombo";
            this.bCombo.Size = new System.Drawing.Size(64, 21);
            this.bCombo.TabIndex = 2;
            this.bCombo.Visible = false;
            this.bCombo.SelectedIndexChanged += new System.EventHandler(this.bCombo_SelectedIndexChanged);
            // 
            // bButton_
            // 
            this.bButton_.Location = new System.Drawing.Point(190, 14);
            this.bButton_.Name = "bButton_";
            this.bButton_.Size = new System.Drawing.Size(75, 23);
            this.bButton_.TabIndex = 1;
            this.bButton_.Text = "Открыть";
            this.bButton_.UseVisualStyleBackColor = true;
            this.bButton_.Click += new System.EventHandler(this.bButton__Click);
            // 
            // bLabel_
            // 
            this.bLabel_.AutoSize = true;
            this.bLabel_.Location = new System.Drawing.Point(271, 19);
            this.bLabel_.Name = "bLabel_";
            this.bLabel_.Size = new System.Drawing.Size(147, 13);
            this.bLabel_.TabIndex = 0;
            this.bLabel_.Text = "Откройте базу с остатками";
            // 
            // openBaseDialog_
            // 
            this.openBaseDialog_.FileName = "openBaseDialog";
            // 
            // BaseEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 433);
            this.Controls.Add(this.Tab);
            this.Name = "BaseEditor";
            this.Text = "Редактор базы и сумма по контрагентам";
            this.Load += new System.EventHandler(this.GetSumContragents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Tab.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabBW.ResumeLayout(false);
            this.tabBW.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabControl Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ContragentsAndTaxButton;
        private System.Windows.Forms.ListBox recordListBox_;
        private System.Windows.Forms.ListBox ttnListBox_;
        private System.Windows.Forms.ListBox orgListBox_;
        private System.Windows.Forms.ListBox decListBox_;
        private System.Windows.Forms.CheckBox prodCheckBox;
        private System.Windows.Forms.Button DelDec;
        private System.Windows.Forms.Button ContrDel;
        private System.Windows.Forms.Button DelTtnBtn;
        private System.Windows.Forms.Button DeleteRecords;
        private System.Windows.Forms.TabPage tabBW;
        private System.Windows.Forms.Label bLabel_;
        private System.Windows.Forms.OpenFileDialog openBaseDialog_;
        private System.Windows.Forms.ComboBox bCombo;
        private System.Windows.Forms.Button bButton_;
        private System.Windows.Forms.ComboBox nBaseCombo;
        private System.Windows.Forms.Button btnIntoBase_;
        private System.Windows.Forms.Button btnCopyAll_;
    }
}
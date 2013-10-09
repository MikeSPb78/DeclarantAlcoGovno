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
            this.tp2DeclarationCombo = new System.Windows.Forms.ComboBox();
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
            this.BaseToComboBox = new System.Windows.Forms.ComboBox();
            this.BaseFromComboBox = new System.Windows.Forms.ComboBox();
            this.bButton_ = new System.Windows.Forms.Button();
            this.bLabel_ = new System.Windows.Forms.Label();
            this.ContragentsTab = new System.Windows.Forms.TabPage();
            this.INNButton = new System.Windows.Forms.Button();
            this.OperationPanel = new System.Windows.Forms.Panel();
            this.ComboBoxOperations = new System.Windows.Forms.ComboBox();
            this.LicenceBox = new System.Windows.Forms.ListBox();
            this.OperationBox = new System.Windows.Forms.ListBox();
            this.ContragentBox = new System.Windows.Forms.ListBox();
            this.openBaseDialog_ = new System.Windows.Forms.OpenFileDialog();
            this.ButtonAddOperation = new System.Windows.Forms.Button();
            this.LabelVarVal = new System.Windows.Forms.Label();
            this.textBoxVarVal = new System.Windows.Forms.TextBox();
            this.ButtonExecute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Tab.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabBW.SuspendLayout();
            this.ContragentsTab.SuspendLayout();
            this.OperationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(537, 363);
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(993, 350);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 488);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Узнать количество остатков по декларации с номером:";
            // 
            // tp2DeclarationCombo
            // 
            this.tp2DeclarationCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tp2DeclarationCombo.FormattingEnabled = true;
            this.tp2DeclarationCombo.Location = new System.Drawing.Point(246, 366);
            this.tp2DeclarationCombo.Name = "tp2DeclarationCombo";
            this.tp2DeclarationCombo.Size = new System.Drawing.Size(171, 21);
            this.tp2DeclarationCombo.TabIndex = 4;
            this.tp2DeclarationCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Tab
            // 
            this.Tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tab.Controls.Add(this.tabPage2);
            this.Tab.Controls.Add(this.tabPage1);
            this.Tab.Controls.Add(this.tabBW);
            this.Tab.Controls.Add(this.ContragentsTab);
            this.Tab.Location = new System.Drawing.Point(-2, 2);
            this.Tab.Name = "Tab";
            this.Tab.SelectedIndex = 0;
            this.Tab.Size = new System.Drawing.Size(1000, 458);
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
            this.tabPage2.Size = new System.Drawing.Size(992, 432);
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
            this.ContrDel.Location = new System.Drawing.Point(10, 402);
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
            this.DelTtnBtn.Location = new System.Drawing.Point(362, 402);
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
            this.DeleteRecords.Location = new System.Drawing.Point(842, 402);
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
            this.recordListBox_.Location = new System.Drawing.Point(829, 0);
            this.recordListBox_.Name = "recordListBox_";
            this.recordListBox_.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.recordListBox_.Size = new System.Drawing.Size(167, 381);
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
            this.ttnListBox_.Size = new System.Drawing.Size(457, 381);
            this.ttnListBox_.TabIndex = 2;
            this.ttnListBox_.SelectedIndexChanged += new System.EventHandler(this.ttnListBox__SelectedIndexChanged);
            // 
            // orgListBox_
            // 
            this.orgListBox_.FormattingEnabled = true;
            this.orgListBox_.Location = new System.Drawing.Point(0, 116);
            this.orgListBox_.Name = "orgListBox_";
            this.orgListBox_.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.orgListBox_.Size = new System.Drawing.Size(356, 264);
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
            this.tabPage1.Controls.Add(this.tp2DeclarationCombo);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(992, 432);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Сумма/Контрагент";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // ContragentsAndTaxButton
            // 
            this.ContragentsAndTaxButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ContragentsAndTaxButton.Location = new System.Drawing.Point(537, 391);
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
            this.button3.Location = new System.Drawing.Point(423, 390);
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
            this.button2.Location = new System.Drawing.Point(423, 363);
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
            this.tabBW.Controls.Add(this.BaseToComboBox);
            this.tabBW.Controls.Add(this.BaseFromComboBox);
            this.tabBW.Controls.Add(this.bButton_);
            this.tabBW.Controls.Add(this.bLabel_);
            this.tabBW.Location = new System.Drawing.Point(4, 22);
            this.tabBW.Name = "tabBW";
            this.tabBW.Padding = new System.Windows.Forms.Padding(3);
            this.tabBW.Size = new System.Drawing.Size(992, 432);
            this.tabBW.TabIndex = 2;
            this.tabBW.Text = "Остатки";
            // 
            // btnIntoBase_
            // 
            this.btnIntoBase_.Location = new System.Drawing.Point(141, 43);
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
            this.btnCopyAll_.Location = new System.Drawing.Point(10, 43);
            this.btnCopyAll_.Name = "btnCopyAll_";
            this.btnCopyAll_.Size = new System.Drawing.Size(110, 23);
            this.btnCopyAll_.TabIndex = 4;
            this.btnCopyAll_.Text = "Скопировать все";
            this.btnCopyAll_.UseVisualStyleBackColor = true;
            this.btnCopyAll_.Visible = false;
            this.btnCopyAll_.Click += new System.EventHandler(this.btnCopyAll__Click);
            // 
            // BaseToComboBox
            // 
            this.BaseToComboBox.FormattingEnabled = true;
            this.BaseToComboBox.Location = new System.Drawing.Point(141, 16);
            this.BaseToComboBox.Name = "BaseToComboBox";
            this.BaseToComboBox.Size = new System.Drawing.Size(111, 21);
            this.BaseToComboBox.TabIndex = 3;
            this.BaseToComboBox.SelectedIndexChanged += new System.EventHandler(this.nBaseCombo_SelectedIndexChanged);
            // 
            // BaseFromComboBox
            // 
            this.BaseFromComboBox.FormattingEnabled = true;
            this.BaseFromComboBox.Location = new System.Drawing.Point(10, 16);
            this.BaseFromComboBox.Name = "BaseFromComboBox";
            this.BaseFromComboBox.Size = new System.Drawing.Size(125, 21);
            this.BaseFromComboBox.TabIndex = 2;
            this.BaseFromComboBox.Visible = false;
            this.BaseFromComboBox.SelectedIndexChanged += new System.EventHandler(this.bCombo_SelectedIndexChanged);
            // 
            // bButton_
            // 
            this.bButton_.Location = new System.Drawing.Point(278, 16);
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
            this.bLabel_.Location = new System.Drawing.Point(359, 19);
            this.bLabel_.Name = "bLabel_";
            this.bLabel_.Size = new System.Drawing.Size(147, 13);
            this.bLabel_.TabIndex = 0;
            this.bLabel_.Text = "Откройте базу с остатками";
            // 
            // ContragentsTab
            // 
            this.ContragentsTab.Controls.Add(this.ButtonExecute);
            this.ContragentsTab.Controls.Add(this.INNButton);
            this.ContragentsTab.Controls.Add(this.OperationPanel);
            this.ContragentsTab.Controls.Add(this.LicenceBox);
            this.ContragentsTab.Controls.Add(this.OperationBox);
            this.ContragentsTab.Controls.Add(this.ContragentBox);
            this.ContragentsTab.Location = new System.Drawing.Point(4, 22);
            this.ContragentsTab.Name = "ContragentsTab";
            this.ContragentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ContragentsTab.Size = new System.Drawing.Size(992, 432);
            this.ContragentsTab.TabIndex = 3;
            this.ContragentsTab.Text = "Контрагенты";
            this.ContragentsTab.UseVisualStyleBackColor = true;
            // 
            // INNButton
            // 
            this.INNButton.FlatAppearance.BorderSize = 0;
            this.INNButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.INNButton.Location = new System.Drawing.Point(394, 6);
            this.INNButton.Name = "INNButton";
            this.INNButton.Size = new System.Drawing.Size(44, 23);
            this.INNButton.TabIndex = 5;
            this.INNButton.Text = "ИНН";
            this.INNButton.UseVisualStyleBackColor = true;
            this.INNButton.Click += new System.EventHandler(this.INNButton_Click);
            // 
            // OperationPanel
            // 
            this.OperationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OperationPanel.Controls.Add(this.textBoxVarVal);
            this.OperationPanel.Controls.Add(this.LabelVarVal);
            this.OperationPanel.Controls.Add(this.ButtonAddOperation);
            this.OperationPanel.Controls.Add(this.ComboBoxOperations);
            this.OperationPanel.Location = new System.Drawing.Point(440, 331);
            this.OperationPanel.Name = "OperationPanel";
            this.OperationPanel.Size = new System.Drawing.Size(552, 101);
            this.OperationPanel.TabIndex = 4;
            // 
            // ComboBoxOperations
            // 
            this.ComboBoxOperations.FormattingEnabled = true;
            this.ComboBoxOperations.Location = new System.Drawing.Point(3, 3);
            this.ComboBoxOperations.Name = "ComboBoxOperations";
            this.ComboBoxOperations.Size = new System.Drawing.Size(543, 21);
            this.ComboBoxOperations.TabIndex = 0;
            this.ComboBoxOperations.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOperations_SelectedIndexChanged);
            // 
            // LicenceBox
            // 
            this.LicenceBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LicenceBox.FormattingEnabled = true;
            this.LicenceBox.Location = new System.Drawing.Point(0, 331);
            this.LicenceBox.Name = "LicenceBox";
            this.LicenceBox.Size = new System.Drawing.Size(388, 108);
            this.LicenceBox.TabIndex = 3;
            // 
            // OperationBox
            // 
            this.OperationBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OperationBox.FormattingEnabled = true;
            this.OperationBox.Location = new System.Drawing.Point(443, 0);
            this.OperationBox.Name = "OperationBox";
            this.OperationBox.Size = new System.Drawing.Size(549, 303);
            this.OperationBox.TabIndex = 2;
            // 
            // ContragentBox
            // 
            this.ContragentBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ContragentBox.FormattingEnabled = true;
            this.ContragentBox.Location = new System.Drawing.Point(0, 0);
            this.ContragentBox.Name = "ContragentBox";
            this.ContragentBox.Size = new System.Drawing.Size(388, 303);
            this.ContragentBox.TabIndex = 1;
            this.ContragentBox.SelectedIndexChanged += new System.EventHandler(this.ContragentBox_SelectedIndexChanged);
            // 
            // openBaseDialog_
            // 
            this.openBaseDialog_.FileName = "openBaseDialog";
            // 
            // ButtonAddOperation
            // 
            this.ButtonAddOperation.Location = new System.Drawing.Point(427, 75);
            this.ButtonAddOperation.Name = "ButtonAddOperation";
            this.ButtonAddOperation.Size = new System.Drawing.Size(122, 23);
            this.ButtonAddOperation.TabIndex = 1;
            this.ButtonAddOperation.Text = "Добавить операцию";
            this.ButtonAddOperation.UseVisualStyleBackColor = true;
            this.ButtonAddOperation.Click += new System.EventHandler(this.ButtonAddOperation_Click);
            // 
            // LabelVarVal
            // 
            this.LabelVarVal.AutoSize = true;
            this.LabelVarVal.Location = new System.Drawing.Point(252, 33);
            this.LabelVarVal.Name = "LabelVarVal";
            this.LabelVarVal.Size = new System.Drawing.Size(0, 13);
            this.LabelVarVal.TabIndex = 2;
            // 
            // textBoxVarVal
            // 
            this.textBoxVarVal.Location = new System.Drawing.Point(354, 30);
            this.textBoxVarVal.Name = "textBoxVarVal";
            this.textBoxVarVal.Size = new System.Drawing.Size(190, 20);
            this.textBoxVarVal.TabIndex = 3;
            // 
            // ButtonExecute
            // 
            this.ButtonExecute.Location = new System.Drawing.Point(841, 305);
            this.ButtonExecute.Name = "ButtonExecute";
            this.ButtonExecute.Size = new System.Drawing.Size(145, 23);
            this.ButtonExecute.TabIndex = 6;
            this.ButtonExecute.Text = "Выполнить операции";
            this.ButtonExecute.UseVisualStyleBackColor = true;
            this.ButtonExecute.Click += new System.EventHandler(this.ButtonExecute_Click);
            // 
            // BaseEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 461);
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
            this.ContragentsTab.ResumeLayout(false);
            this.OperationPanel.ResumeLayout(false);
            this.OperationPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tp2DeclarationCombo;
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
        private System.Windows.Forms.ComboBox BaseFromComboBox;
        private System.Windows.Forms.Button bButton_;
        private System.Windows.Forms.ComboBox BaseToComboBox;
        private System.Windows.Forms.Button btnIntoBase_;
        private System.Windows.Forms.Button btnCopyAll_;
        private System.Windows.Forms.TabPage ContragentsTab;
        private System.Windows.Forms.ListBox LicenceBox;
        private System.Windows.Forms.ListBox OperationBox;
        private System.Windows.Forms.ListBox ContragentBox;
        private System.Windows.Forms.Panel OperationPanel;
        private System.Windows.Forms.ComboBox ComboBoxOperations;
        private System.Windows.Forms.Button INNButton;
        private System.Windows.Forms.Button ButtonAddOperation;
        private System.Windows.Forms.TextBox textBoxVarVal;
        private System.Windows.Forms.Label LabelVarVal;
        private System.Windows.Forms.Button ButtonExecute;
    }
}
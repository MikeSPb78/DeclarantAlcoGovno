﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avalon
{

    public partial class BaseEditor : Form
    {
        //ИНН-КПП
        //--Код
        //----Объем
        Dictionary<String, Dictionary<String, String>> volumeEx_;
        Dictionary<String, Dictionary<String, String>> volumeNew_;

        BaseWork baseWork_;
        string _basename;
        string exbase_;
        private System.Collections.Generic.Dictionary<String, String> decTypeDict_;
        private System.Collections.Generic.Dictionary<String, String> decIdDict_;
        private System.Collections.Generic.Dictionary<String, String> orgNameId_;
        private System.Collections.Generic.Dictionary<String, String> ttnDic_;
        private System.Collections.Generic.Dictionary<String, String> recordDic_;
        ContragentsEditor _contragentsEditor;
  //      private System.Collections.Generic.Dictionary<String, int> _;
        public BaseEditor(string basenm)
        {
            _basename = basenm;
            baseWork_ = new BaseWork();
            decTypeDict_ = new Dictionary<String, String>();
            decIdDict_ = new Dictionary<string, string>();
            orgNameId_ = new Dictionary<String, String>();
            ttnDic_ = new Dictionary<String, String>();
            recordDic_ = new Dictionary<String, String>();
            volumeEx_ = new Dictionary<String, Dictionary<String, String>>();
            volumeNew_ = new Dictionary<string, Dictionary<string, string>>();


            string Con = "DataSource =" + _basename + "; Password=7338a7e6-fd3b-49d1-8d90-ddbbc1b39fa1";
            InitializeComponent();
            try
            {
                /*Недавно это делал, но коряво сделано*/
                DataRow[] dec = GetRow("select id,type_id, PrizPeriod, Yearotch from decheader");
                for (int i = 0; i < dec.Count(); i++)
                {
                    //Декларация|Тип
                    string index = dec[i][0].ToString() + " Тип: " + dec[i][1].ToString() + ", " +
                     (Convert.ToInt32(dec[i][2].ToString()) / 3).ToString() + "кв. " + dec[i][3].ToString() + " год";

                    tp2DeclarationCombo.Items.Add(dec[i][0] + "|" + dec[i][1]);
                    BaseToComboBox.Items.Add(index);
                    decListBox_.Items.Add(index);
                    decIdDict_[_basename + index] = ((int)dec[i][0]).ToString();
                    decTypeDict_[_basename + index] = ((int)dec[i][1]).ToString();
                }

            }
            catch (Exception ex)
            {
                this.Close();
            }


            /*Здесь будем описывать редактор Контрагентов*/
            INNButtonEffect = false;
            _contragentsEditor = new ContragentsEditor(_basename);
            _contragentsEditor.GetContragents(ref ContragentBox);
            _contragentsEditor.GetOperations(ref ComboBoxOperations);

        }
        void BaseListToCombo(ComboBox combo, string db )
        {
                /*Очевидно заполнялось методом Copy/Paste*/
                DataRow[] dec = GetRow("select id,type_id, PrizPeriod, Yearotch from decheader", db);
                for (int i = 0; i < dec.Count(); i++)
                {

                    string index = dec[i][0].ToString() + " Тип: " + dec[i][1].ToString() + ", " +
                        (Convert.ToInt32(dec[i][2].ToString()) / 3).ToString() + "кв. " + dec[i][3].ToString() + " год";

                    combo.Items.Add(index);
                    decIdDict_[db + index] = ((int)dec[i][0]).ToString();
                    decTypeDict_[db + index] = ((int)dec[i][1]).ToString();
                }
        }
        private DataRow[] GetRow(string query, string basename)
        {
            string ConSrc = "DataSource =" +  basename + " ; Password=7338a7e6-fd3b-49d1-8d90-ddbbc1b39fa1";

            DataSet DS = new DataSet("table");
            SqlCeConnection con = new SqlCeConnection(ConSrc);
            SqlCeCommand cmd = new SqlCeCommand(query, con);
            SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

            sda.Fill(DS, "table");
            return DS.Tables["table"].Select("");

        }
        private DataRow[] GetRow(string query)
        {
            return GetRow(query, _basename);

        }
        private DataTable GetDS(string query)
        {
            string ConSrc = "DataSource =" + _basename + " ; Password=7338a7e6-fd3b-49d1-8d90-ddbbc1b39fa1";

            DataSet DS = new DataSet("table");
            SqlCeConnection con = new SqlCeConnection(ConSrc);
            SqlCeCommand cmd = new SqlCeCommand(query, con);
            SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

            sda.Fill(DS, "table");
            return DS.Tables["table"];
        }
        private void query(string query, string basename)
        {
            string ConSrc = "DataSource =" + basename + " ; Password=7338a7e6-fd3b-49d1-8d90-ddbbc1b39fa1";

            DataSet DS = new DataSet("table");
            SqlCeConnection con = new SqlCeConnection(ConSrc);
            SqlCeCommand cmd = new SqlCeCommand(query, con);
            SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

            sda.Fill(DS, "table");
        }
        private void query(string queryst)
        {
            query(queryst, _basename);

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tp2DeclarationCombo.Items[tp2DeclarationCombo.SelectedIndex].ToString().Length != 0)
            {
                Char[] separator = new Char[] { '|' };
                string[] dec = tp2DeclarationCombo.Items[tp2DeclarationCombo.SelectedIndex].ToString().Split(separator);
                //Получаем тип и декларацию
                int declaration = Convert.ToInt32(dec[0]);
                int type = Convert.ToInt32(dec[1]);

                string query = "";
                if (type == 11)
                {
                    query = "SELECT  idPost, wrk_Contragents.OrgName, Sum([P216]) AS Сумма FROM wrk_Contragents INNER JOIN DecF11 ON wrk_Contragents.Id = DecF11.idPost Where DecF11.Hid = " + Convert.ToString(declaration) + " Group By idPost, wrk_Contragents.OrgName Order By wrk_Contragents.OrgName";
                }

                if (type == 12)
                {
                    query = "SELECT idPost, wrk_Contragents.OrgName, Sum([P212]) AS Сумма FROM wrk_Contragents INNER JOIN DecF12 ON wrk_Contragents.Id = DecF12.idPost Where DecF12.Hid = " + Convert.ToString(declaration) + " Group By idPost, wrk_Contragents.OrgName Order By wrk_Contragents.OrgName";
                }

                try
                {
                    dataGridView1.DataSource = GetDS(query);
                }
                catch (Exception ex) { }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(sender, e);
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void GetSumContragents_Load(object sender, EventArgs e)
        {

        }
        private void GetBy(String Field11, String Field12, string name)
        {
   
            if (tp2DeclarationCombo.Items[tp2DeclarationCombo.SelectedIndex].ToString().Length != 0)
            {
                Char[] separator = new Char[] { '|' };
                string[] dec = tp2DeclarationCombo.Items[tp2DeclarationCombo.SelectedIndex].ToString().Split(separator);
                //Получаем тип и декларацию
                int declaration = Convert.ToInt32(dec[0]);
                int type = Convert.ToInt32(dec[1]);

                string query = "";
                if (type == 11)
                {
                    String Field = Field11;
                    query = "SELECT  "+Field + " AS " + name +  ", Sum([P216]) AS Сумма FROM DecF11  Where DecF11.Hid = " + Convert.ToString(declaration) + " Group By " + Field +" ORDER BY " + Field;
                }

                if (type == 12)
                {
                    String Field = Field12;
                    query = "SELECT " + Field + "AS" + name + ", Sum([P212]) AS Сумма FROM  DecF12 Where DecF12.Hid = " + Convert.ToString(declaration) + " Group By " + Field + " ORDER BY " + Field;
                }

                try
                {
                    dataGridView1.DataSource = GetDS(query);
                }
                catch (Exception ex) { }

            }
        }
        private void GetBy(String field,String name)
        {
            GetBy(field, field, name);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            GetBy("P214", "P210","Накладная");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            GetBy("vidCode","Код");    
        }
        private void ContragentsAndTaxButton_Click(object sender, EventArgs e)
        {
            GetBy("idPost, P214", "idPost, P210", "Накладная");
        }
        private void GetOrgs()
        {
            try
            {
                string prod;

                if (prodCheckBox.Checked)
                    prod = "ProdId";
                else
                    prod = "idPost";

                /*Это конструктор запроса, причем примитивный*/
                String dec = "decf" + decTypeDict_[_basename+decListBox_.SelectedItem.ToString()];

                String query = "select distinct con.Id, con.OrgName, con.Inn, con.Kpp from " + dec
                    + " join wrk_Contragents as con ON con.id = " + dec + "." + prod
                    + " where Hid = " + decIdDict_[_basename+ decListBox_.SelectedItem.ToString()];
                DataRow[] orgRow = GetRow(query);

                orgListBox_.Items.Clear();
                orgNameId_.Clear();

                for (int i = 0; i < orgRow.Count(); i++)
                {
                    string orgFullName = orgRow[i][1] + " " + orgRow[i][2] + "/" + orgRow[i][3];
                    orgListBox_.Items.Add(orgFullName);
                    orgNameId_[orgFullName] = ((int)orgRow[i][0]).ToString();
                }
                
                ttnListBox_.Items.Clear();
                recordListBox_.Items.Clear();

            }
            catch (Exception ex)
            {
               
            }

        }
        private void decListBox__SelectedIndexChanged(object sender, EventArgs e)
        {
            GetOrgs();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            GetOrgs();
        }
        private void orgListBox__SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string prod;

                if (prodCheckBox.Checked)
                    prod = "ProdId";
                else
                    prod = "idPost";



                String dec = "decf" + decTypeDict_[_basename+decListBox_.SelectedItem.ToString()];
                String ttnField, dateField,valField;
                if (dec == "decf11")
                {
                    ttnField = "P214";
                    dateField = "P213";
                    valField = "P216";
                }
                else
                {
                    ttnField = "P210";
                    dateField = "P29";
                    valField = "P212";
                }
                String query = "select 1 as id, " + ttnField + "," + dateField + ", sum("+ valField +") from " + dec
                    + " where Hid = " + decIdDict_[_basename + decListBox_.SelectedItem.ToString()]
                    + " and " + prod + " = " + orgNameId_[orgListBox_.SelectedItem.ToString()]
                    + " group by  " + ttnField + "," + dateField ;

                DataRow[] ttnRow = GetRow(query);

                ttnListBox_.Items.Clear();
                recordListBox_.Items.Clear();
                ttnDic_.Clear();

                for (int i = 0; i < ttnRow.Count(); i++)
                {
                    String FullName = ttnRow[i][1] + " | " + ttnRow[i][2] + " | " + ttnRow[i][3];
                    ttnListBox_.Items.Add(FullName);
                    ttnDic_[FullName] = ttnRow[i][1].ToString();

                }

            }
            catch (Exception ex)
            {

            }
        }
        private void recordListBox__SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ttnListBox__SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string prod;

                if (prodCheckBox.Checked)
                    prod = "ProdId";
                else
                    prod = "idPost";



                String dec = "decf" + decTypeDict_[_basename+decListBox_.SelectedItem.ToString()];
                String valField,ttnField;
                if (dec == "decf11")
                {
                    ttnField = "P214";
                    valField = "P216";
                }
                else
                {
                    ttnField = "P210";
                    valField = "P212";
                }

                String query = "select id,vidCode, " + valField + "  from " + dec
                    + " where Hid = " + decIdDict_[ _basename + decListBox_.SelectedItem.ToString()]
                    + " and " + prod + " = " + orgNameId_[orgListBox_.SelectedItem.ToString()]
                    + " and " + ttnField + " = \'" + ttnDic_[ttnListBox_.SelectedItem.ToString()] + "\'"; 

                DataRow[] ttnRow = GetRow(query);


                recordListBox_.Items.Clear();
                recordDic_.Clear();
                for (int i = 0; i < ttnRow.Count(); i++)
                {
                    string FullName = ttnRow[i][2] + " | " + ttnRow[i][1] + " | " + ttnRow[i][0];
                    recordListBox_.Items.Add(FullName);
                    recordDic_[FullName] = ttnRow[i][0].ToString();
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void DeleteRecords_Click(object sender, EventArgs e)
        {
            try
            {
                String result = "";
                foreach (var item in recordListBox_.SelectedItems)
                {
                    result += recordDic_[item.ToString()] + ",";
                }
                result = result.TrimEnd(',');


                String dec = "decf" + decTypeDict_[_basename+decListBox_.SelectedItem.ToString()];
                query("delete from " + dec + " where id in (" + result + ")");
                ttnListBox__SelectedIndexChanged(sender, e);
            }
            catch (Exception ex) { }
        }
        private void DelTtnBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String result = "";
                foreach (var item in ttnListBox_.SelectedItems)
                {
                    result += "\'" + ttnDic_[item.ToString()] + "\',";
                }
                result = result.TrimEnd(',');

                String dec = "decf" + decTypeDict_[_basename+decListBox_.SelectedItem.ToString()];
                String ttnField, prod;
                if (dec == "decf11")
                {
                    ttnField = "P214";
                }
                else
                {
                    ttnField = "P210";
                }
                if (prodCheckBox.Checked)
                    prod = "ProdId";
                else
                    prod = "idPost";

                query("delete from " + dec + " where " + ttnField + " in (" + result + ")"
                    + " and " + prod + "= " + orgNameId_[orgListBox_.SelectedItem.ToString()]
                    + " and Hid = " + decIdDict_[_basename + decListBox_.SelectedItem.ToString()]);
                orgListBox__SelectedIndexChanged(sender, e);
            } catch(Exception ex){}
        }
        private void ContrDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить контрагента(ов)", "Удаление большого объема данных", MessageBoxButtons.YesNo)
                                 == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    String result = "";
                    foreach (var item in orgListBox_.SelectedItems)
                    {
                        result += "\'" + orgNameId_[item.ToString()] + "\',";
                    }
                    result = result.TrimEnd(',');

                    String dec = "decf" + decTypeDict_[_basename + decListBox_.SelectedItem.ToString()];
                    String ttnField, prod;
                    if (dec == "decf11")
                    {
                        ttnField = "P214";
                    }
                    else
                    {
                        ttnField = "P210";
                    }
                    if (prodCheckBox.Checked)
                        prod = "ProdId";
                    else
                        prod = "idPost";

                    query("delete from " + dec + " where " + prod + " in (" + result + ")"
                        + " and Hid = " + decIdDict_[_basename + decListBox_.SelectedItem.ToString()]);
                    decListBox__SelectedIndexChanged(sender, e);
                }
                catch (Exception ex) { }
            }
        }
        private void DelDec_Click(object sender, EventArgs e)
        {

              if ( MessageBox.Show("Удалить декларацию", "Удаление большого объема данных", MessageBoxButtons.YesNo)
                                     == System.Windows.Forms.DialogResult.Yes)
              {
                try
                {
               
                    String dec = "decf" + decTypeDict_[_basename+decListBox_.SelectedItem.ToString()];
                    query("delete from " + dec + " where Hid = " + decListBox_.SelectedItem.ToString());
                    query("delete from decheader where id = " + decListBox_.SelectedItem.ToString());

                }
                catch (Exception ex) { }
              }
            }
        private void bButton__Click(object sender, EventArgs e)
        {
            BaseFromComboBox.Items.Clear();
            openBaseDialog_ = new OpenFileDialog();
            openBaseDialog_.Filter = "SDF database | *.sdf";
            if (openBaseDialog_.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    BaseListToCombo(BaseFromComboBox, openBaseDialog_.FileName);
                    exbase_ = openBaseDialog_.FileName;
                    bLabel_.Text = exbase_;
                    BaseFromComboBox.Visible = true;
                }
                catch (Exception ex) { }

            }
        }
        private void GetParamFromBase(String type,ref Dictionary<String, Dictionary<String, String>> dict, 
            String basename, bool isFrom, ref ComboBox box)
        {
            dict.Clear();
            String Volume;
            if (!isFrom)
            {
                Volume = "P106";

            }
            else
            {
                if (type == "11")
                {
                    Volume = "P120";
                }
                else
                {
                    Volume = "P118";
                }
            }
            String tab = "decf" + type;
            String query = "SELECT c.INN, c.KPP, vidCode," + Volume + ",ProdId FROM " + tab + " AS dec "
                + " JOIN wrk_Contragents as c ON dec.ProdId = c.Id "
                + " AND dec.ttype = 1 "
                + " AND dec.hid = " + decIdDict_[basename + box.SelectedItem.ToString()]
                + " ORDER BY c.INN, c.KPP, vidCode ";

            DataRow[] dr = GetRow(query, basename);

            dict = new Dictionary<string,Dictionary<string,string>>();

            String sIK = "";
            for (int ixRow = 0; ixRow < dr.Count(); ixRow++)
            {
                if (sIK != dr[ixRow][0] + "/" + dr[ixRow][1] ) 
                {
                    sIK = dr[ixRow][0] + "/" + dr[ixRow][1];
                    dict[sIK] = new Dictionary<string,string>();
                }
                dict[sIK][(String)dr[ixRow][2] ] = dr[ixRow][3].ToString();

            }                
        }
        struct StringPair
        {
            public String outString;
            public String inString;
            public Label label;
            public TextBox textBox;
            public Label code;
        };
        String NanVar = "Nan";
        Dictionary<String, Dictionary<String, StringPair>> dataPairs;
        private Dictionary<String, Dictionary<String,StringPair>> 
            PrintDictionary( ref Dictionary<String, Dictionary<String, String>>  outd,
                                   ref Dictionary<String, Dictionary<String, String>> ind)
        {
            Dictionary<String, Dictionary<String, StringPair>> inDict;
            inDict = new Dictionary<string, Dictionary<string, StringPair>>();

            int yCoord = 70, step = 30;

            foreach (KeyValuePair<String, Dictionary<String, String>> kvOrg in outd)
            {
                inDict[kvOrg.Key] = new Dictionary<string, StringPair>();

                yCoord += 30;

                Label lab = new Label();
                lab.Location = new System.Drawing.Point(40, yCoord);
                lab.Size = new System.Drawing.Size(300, 25);
                lab.Text = "ИНН:" + kvOrg.Key.Replace("/", "  КПП:");
                tabBW.Controls.Add(lab);

                yCoord += step;

                foreach (KeyValuePair<String, String> kv in kvOrg.Value)
                {
                    StringPair pair;
                    pair.outString = kv.Value;

                    pair.label = new Label();
                    pair.textBox = new TextBox();
                    pair.code = new Label();

                    if (ind.ContainsKey(kvOrg.Key))
                    {
                        if (ind[kvOrg.Key].ContainsKey(kv.Key))
                        {
                            pair.inString = ind[kvOrg.Key][kv.Key];
                        }
                        else pair.inString = NanVar;
                    }
                    else pair.inString = NanVar;

                    pair.label.Text = pair.outString;
                    pair.textBox.Text = pair.inString;
                    pair.code.Text = kv.Key;

                    pair.label.Location = new System.Drawing.Point(40, yCoord);
                    pair.code.Location = new System.Drawing.Point(10, yCoord);
                    pair.textBox.Location = new System.Drawing.Point(150, yCoord);

                    pair.label.Size = new System.Drawing.Size(70, 25);
                    pair.textBox.Size = new System.Drawing.Size(70, 25);
                    pair.code.Size = new System.Drawing.Size(30, 25);

                    tabBW.Controls.Add(pair.label);
                    tabBW.Controls.Add(pair.code);
                    tabBW.Controls.Add(pair.textBox);

                    

                    yCoord += step;

                    inDict[kvOrg.Key][kv.Key] = pair;

                }
            }
            return inDict;
        }
        private void ShowElems()
        {
            dataPairs = PrintDictionary(ref volumeEx_, ref volumeNew_);
            btnCopyAll_.Visible = true;
            btnIntoBase_.Visible = true;
        }
        private void bCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetParamFromBase(decTypeDict_[exbase_+BaseFromComboBox.SelectedItem.ToString()],ref volumeEx_,exbase_,true, ref BaseFromComboBox);
            if (BaseToComboBox.SelectedIndex != -1)
            {
                ShowElems();
            }
            
        }
        private void nBaseCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetParamFromBase(decTypeDict_[_basename + BaseToComboBox.SelectedItem.ToString()], ref volumeNew_, _basename, false, ref BaseToComboBox);
            if (BaseFromComboBox.SelectedIndex != -1)
            {
                ShowElems();
            }
        }
        private void btnCopyAll__Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<String, Dictionary<String, StringPair>> iOrg in dataPairs)
            {
                foreach (KeyValuePair<String, StringPair> ix in dataPairs[iOrg.Key])
                {
                    ix.Value.textBox.Text = ix.Value.label.Text;
                }
            }
        }
        private void btnIntoBase__Click(object sender, EventArgs e)
        {
            String queryx = "SELECT id,INN,KPP FROM wrk_Contragents";
            DataRow[] ids = GetRow(queryx);

            Dictionary<String, String> idDic = new Dictionary<string,string>();

            for (int ix = 0; ix < ids.Count(); ix++)
            {
                idDic[ids[ix][1].ToString() + "/" + ids[ix][2].ToString()] = ((int)ids[ix][0]).ToString(); 
            }
            String dec,series, column, values;

            if (decTypeDict_[_basename + BaseToComboBox.SelectedItem.ToString()] == "11")
            {
                series = "Hid,VidCode,ProdId,P106,P107,P108,P109,P110,P111,P112,P113,P114,P115,P116,P117,P118,P119,P120,ttype,idOrg";
                values = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1)";
                column = "P106";
                dec = "DecF11";
            }
            else
            {
                series = "Hid,VidCode,ProdId,P106,P107,P108,P109,P110,P111,P112,P113,P114,P115,P116,P117,P118,ttype,idOrg";
                values = "0,0,0,0,0,0,0,0,0,0,0,0,1,1)";
                column = "P106";
                dec = "DecF12";
            }

            foreach (KeyValuePair<String, Dictionary<String, StringPair>> iter in dataPairs)
            {
                foreach (KeyValuePair<String, StringPair> sp in iter.Value)
                {
                    if (sp.Value.inString == NanVar)
                    {
                        if (sp.Value.textBox.Text != NanVar)
                        {
                            queryx = "INSERT INTO " + dec + "(" + series
                                + ") VALUES(" + BaseToComboBox.SelectedItem.ToString() + "," + sp.Key + "," +
                                idDic[iter.Key] + ","+ sp.Value.textBox.Text + ","+ values;
                            query(queryx);
                        }
                    }
                    else
                    {
                        queryx = "UPDATE " + dec + " SET " + column + " = " + sp.Value.textBox.Text
                            + "WHERE Hid = " + BaseToComboBox.SelectedItem.ToString() 
                            + " AND vidCode = " + sp.Key
                            + " AND ProdId = " + idDic[iter.Key]
                            + " AND ttype = 1";
                        query(queryx);
                    }
                }
            }
        }

        private void ContragentBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Contragent contr = (Contragent) ContragentBox.SelectedItem;
            _contragentsEditor.GetLicenceByContrId(contr.ContrId, ref LicenceBox);

        }



        bool INNButtonEffect;
        int ixContragentBox;
        private void INNButton_Click(object sender, EventArgs e)
        {
            if (!INNButtonEffect)
            {
                if (ContragentBox.SelectedIndex != -1)
                {
                    
                    ixContragentBox = ContragentBox.SelectedIndex;

                    /*Эффект*/
                    INNButton.FlatAppearance.BorderSize = 1;
                    INNButton.BackColor = Color.Silver;
                    
                    /*Тупо выбираем по ИНН элемента*/
                    _contragentsEditor.ContragentsByInnInListBox(
                        ((Contragent)ContragentBox.SelectedItem).INN,
                        ref ContragentBox);

                    INNButtonEffect = true;
                }
            }
            else
            {
                /*Эффект*/
                INNButton.FlatAppearance.BorderSize = 0;
                INNButton.BackColor = Color.White;

                /*Восстанавливаем все назад*/
                _contragentsEditor.GetContragents(ref ContragentBox);
                
                INNButtonEffect = false;

                ContragentBox.SetSelected(ixContragentBox,true);
            }

        }

        private void ButtonAddOperation_Click(object sender, EventArgs e)
        {
            if (ComboBoxOperations.SelectedIndex == -1)
                return;
            Contragent con;
            Licence lic;

            /*Все ли в порядке с контрагентом*/
            if (ContragentBox.SelectedIndex == -1)
            {
                con = null;
            }
            else
            {
                con = (Contragent)ContragentBox.SelectedItem;
            }

            /*Все ли в порядке с лицензией*/
            if (LicenceBox.SelectedIndex == -1)
            {
                lic = null;
            }
            else
            {
                lic = (Licence)LicenceBox.SelectedItem;
            }

            _contragentsEditor.CreateOperation(con, lic, ((ContragentsEditor.ListBoxItem)ComboBoxOperations.SelectedItem).operation,
                                                            textBoxVarVal.Text);
            _contragentsEditor.GetOperations(ref OperationBox);
        }

        private void ComboBoxOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Обзовем метку сообразно ее функциям*/
            ContragentsEditor.ListBoxItem lb = (ContragentsEditor.ListBoxItem)ComboBoxOperations.SelectedItem;
            if (lb.operation == (int)OpList.RENAME_CONTRAGENT_BY_INN_KPP_REGION)
            {
                LabelVarVal.Text = "Общее имя ";
                return;
            }

            LabelVarVal.Text = "";
        }

        private void ButtonExecute_Click(object sender, EventArgs e)
        {
            _contragentsEditor.RunOperations();
        }


    }
}

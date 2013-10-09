using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace Avalon
{

    public partial class MainForm : Form
    {
        SqlCeConnection Src, Dst;
        private System.Collections.Generic.Dictionary<String, String> comboList_;
        private BaseWork baseWork_;


        private String GetOrgNameFromBase(String basename)
        {
            string ConSrc = "DataSource ="+basename+"; Password=7338a7e6-fd3b-49d1-8d90-ddbbc1b39fa1";
            SqlCeConnection consrc = new SqlCeConnection(ConSrc);
            try
            {
                DataSet DS = new DataSet("table");
                SqlCeCommand cmd = new SqlCeCommand("SELECT OrgName FROM wrk_org", consrc);
                SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

                sda.Fill(DS, "table");
                DataRow[] dataRow = DS.Tables["table"].Select("");

                String ReturnValue = (String)dataRow[0][0];
                consrc.Close();
                return ReturnValue;

            }
            catch
            {
                return "Ошибка обработки";
            }
        }

        private void AddToCombo()
        {
  
            String[] dbFiles = Directory.GetFiles(Application.StartupPath, "*.sdf");
            foreach (var it in dbFiles)
            {
                String ComboItem;
                String db = it.Replace(Application.StartupPath+"\\", "");
                ComboItem = db + "  -  " + GetOrgNameFromBase(db);
                comboList_[ComboItem] = db;

                comboBoxFrom_.Items.Add(ComboItem);
                comboBoxIn_.Items.Add(ComboItem);
            }
            

        }

        public MainForm()
        {
            baseWork_  = new BaseWork();
            comboList_ = new Dictionary<String, String>();
            InitializeComponent();
            AddToCombo();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            baseWork_.CopyBases(comboList_[comboBoxFrom_.SelectedItem.ToString()], 
                comboBoxIn_.SelectedItem.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string ConSrc = "DataSource = " + comboList_[comboBoxFrom_.SelectedItem.ToString()]
                    + "; Password=7338a7e6-fd3b-49d1-8d90-ddbbc1b39fa1";
                Src = new SqlCeConnection(ConSrc);
               
            }
            catch (Exception ex) { }

        }
        private void button3_Click(object sender, EventArgs e)
        {            
            try
            {
                string ConSrc = "DataSource = " + comboList_[comboBoxIn_.SelectedItem.ToString()] + "; Password=7338a7e6-fd3b-49d1-8d90-ddbbc1b39fa1";
                Dst = new SqlCeConnection(ConSrc);
            }
            catch (Exception ex) { }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
            button3_Click(sender, e);

            ExplBases expl;
            expl = new ExplBases(Dst, Src);
            expl.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
            button3_Click(sender, e);
            BaseWork   bw = new BaseWork();

            bw.CLCpy(Src, Dst);
        }

        private void CntFromText_Click(object sender, EventArgs e)
        {
            FromText frm = new FromText(comboList_[comboBoxIn_.SelectedItem.ToString()]);

            try
            {
                frm.Show();
            } catch(Exception ex){
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EndsForm eds = new EndsForm(Src, Dst);
            eds.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BaseWork bw = new BaseWork();
            bw.CopyBases(comboList_[comboBoxFrom_.SelectedItem.ToString()], 
                comboList_[comboBoxIn_.SelectedItem.ToString()]);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button3_Click(sender,e);
            BaseWork bw = new BaseWork();
            int cnt = bw.KillProd(Dst, 11);
            label3.Text = "Из 11 - го типа удалено " + cnt.ToString() + " строк";
            cnt = bw.KillProd(Dst, 12);
            label4.Text = "Из 12 - го типа удалено " + cnt.ToString() + " строк";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }

        private void button9_Click(object sender, EventArgs e)
        {
            BaseEditor GetContr = new BaseEditor(comboList_[comboBoxIn_.SelectedItem.ToString()]);
            try
            {
                GetContr.ShowDialog();
            }
            catch (Exception ex) { }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            List<string> strList = new List<string>();
            //Решаем проблемы Зерг Рашем
            strList.Add("update wrk_contr_licenses set series = 'Д' , number='622472'  where series = '49 Б' and number = '097964'");
            strList.Add("update wrk_contr_licenses set series = 'Б' , number='097582'  where series = '21273 Б' and number = '097582'");
            strList.Add("update wrk_contr_licenses set series = 'Б' , number='097582'  where series = 'Б' and number = '097582'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='643296'  where series = 'Б097897' and number = ''");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='643296'  where series = 'Б' and number = '097897'");
            strList.Add("update wrk_contr_licenses set series = 'Б' , number='097897'  where series = 'Б' and number = '097897'");
            strList.Add("update wrk_contr_licenses set series = 'Д' , number='622472'  where series = 'Б 097964' and number = '49'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='600624'  where series = '18808А' and number = '600624'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='600624'  where series = 'А' and number = '600624'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='604497'  where series = '183 АП 0000282 А' and number = '604497'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='604497'  where series = '183АП0000282А' and number = '604497'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='604497'  where series = '183АП00002825А' and number = '604497'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='608826'  where series = '20816 А' and number = '608826'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='608826'  where series = '20816А' and number = '608826'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='608826'  where series = 'А' and number = '608826'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='608826'  where series = 'А 608826' and number = '20816'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='612894'  where series = '14549 А' and number = '612894'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='612894'  where series = 'А' and number = '612894'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='612894'  where series = 'А 612894' and number = '14549'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='643296'  where series = '18 ПСН 0001056А' and number = '643296'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='643296'  where series = '18ПСН0001056А' and number = '643296'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='643296'  where series = '18 ПСН 0001056 А' and number = '643296'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='647431'  where series = '21484 А' and number = '647431'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='647431'  where series = 'А' and number = '647431'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='647431'  where series = 'А' and number = 'А 647431'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='647431'  where series = '21484а' and number = '647431'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='647854'  where series = '21661 А' and number = '647854'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='647854'  where series = '21661А' and number = '647854'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='647854'  where series = 'А' and number = '647854'");
            strList.Add("update wrk_contr_licenses set series = 'А' , number='604497'  where series = '183' and number = 'АП000282а604497'");
            strList.Add("update wrk_contr_licenses set Vidana = 'Федеральная служба по регулированию алкогольного рынка'");
            strList.Add("update wrk_contr_licenses set dateBegin = '13.08.2012' , dateEnd ='12.04.2016'  where series = 'А' and number = '643296'");
    

            BaseWork bw = new BaseWork();
            foreach (string str in strList){
                bw.query(str,Dst);
            }
 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string query = "update DecF11 set P213 = ( SUBSTRING(P213,0,Len(P213)-2) ) + '.' + '20' + ( SUBSTRING(P213,Len(P213)-1,2) ) where Substring ( ( SUBSTRING(P213,Len(P213)-3,3) ), 2,1) = '.' and Len(P213) = 8";
            BaseWork bw = new BaseWork();
            bw.query(query, Dst);
            query = "update DecF12 set P29 = ( SUBSTRING(P29,0,Len(P29)-2) ) + '.' + '20' + ( SUBSTRING(P29,Len(P29)-1,2) ) where Substring ( ( SUBSTRING(P29,Len(P29)-3,3) ), 2,1) = '.' and Len(P29) = 8";
            bw.query(query, Dst);
        }

        private void BaseEditorButton_Click(object sender, EventArgs e)
        {
            try
            {
                BaseEditor GetContr = new BaseEditor(comboList_[comboBoxIn_.SelectedItem.ToString()]);

                try
                {
                    GetContr.ShowDialog();
                }
                catch (Exception ex) { }
                }
            catch (Exception ex)
            {
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Avalon
{
    public partial class FromText : Form
    {

        List<string> org;
        List<string> TTN;
        List<string> DTTN;
        String basename;
        Dictionary<String, String> DeclarationHelper;
        int countOfLines;
        int line;
        ~FromText()
        {

        }
        public FromText(String basen)
        {
            basename = basen;
            InitializeComponent();
            org = new List<string>();


            progressBar1.Visible = false;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            countOfLines = 0;
            DeclarationHelper = new Dictionary<string, string>();

            
            try
            {
                DataRow[] dec12 = GetRow("select id, PrizPeriod, Yearotch from decheader where type_id = 12");
                for (int i = 0; i < dec12.Count(); i++)
                {
                    String index = dec12[i][0].ToString() + " - " + (Convert.ToInt32(dec12[i][1].ToString()) / 3).ToString() + "кв. " + dec12[i][2] + " год";
                    DeclarationHelper[index] = dec12[i][0].ToString();
                    comboBoxF12Choosing.Items.Add(index);
                }

                DataRow[] dec11 = GetRow("select id, PrizPeriod, Yearotch from decheader where type_id = 11");
                for (int i = 0; i < dec11.Count(); i++)
                {
                    String index = dec11[i][0].ToString() + " - " + (Convert.ToInt32(dec11[i][1].ToString()) / 3).ToString() + "кв. " + dec11[i][2] + " год";
                    DeclarationHelper[index] = dec11[i][0].ToString();
                    comboBoxF11Choosing.Items.Add(index);
                }
            } catch (Exception ex){
                MessageBox.Show("Ошибка запроса/доступа к ресурсу: \n" + ex.Message);
                this.Close();
            }

        }

        private DataRow[] GetRow(string query)
        {
            string ConSrc = "DataSource =" + basename + " ; Password=7338a7e6-fd3b-49d1-8d90-ddbbc1b39fa1";

            DataSet DS = new DataSet("table");
            SqlCeConnection con = new SqlCeConnection(ConSrc);
            SqlCeCommand cmd = new SqlCeCommand(query, con);
            SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

            sda.Fill(DS, "table");
            return DS.Tables["table"].Select("id <> 0");

        }

        private void query(string query)
        {
            string ConSrc = "DataSource =" + basename +" ; Password=7338a7e6-fd3b-49d1-8d90-ddbbc1b39fa1";

            DataSet DS = new DataSet("table");
            SqlCeConnection con = new SqlCeConnection(ConSrc);
            SqlCeCommand cmd = new SqlCeCommand(query, con);
            SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

            sda.Fill(DS, "table");
        }

        private string[] GetElem(string st)
        {
            st = st.Replace("\t\t\t\t\t\t", "\t");
            st = st.Replace("\t\t\t\t\t", "\t");
            st = st.Replace("\t\t\t\t", "\t");
            st = st.Replace("\t\t\t", "\t");
            st = st.Replace("\t\t", "\t");
            st = st.Trim();
            Char[] sp = new Char[] { '\t' };
            string[] set = st.Split(sp);

            return set;
        }

        private void TimerProc(object state)
        {
            // The state object is the Timer object.
            System.Windows.Forms.Timer t = (System.Windows.Forms.Timer)state;
            t.Dispose();
            Console.WriteLine("The timer callback executes.");
        }

        private void RecordButton_Click(object sender, EventArgs e)
        {
            textBox1.Height -= 30;
            progressBar1.Visible = true;
            string path = textBoxF11.Text;
            string[] Text = File.ReadAllLines(path);

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
	        timer.Interval = 20;//ms


	        timer.Start();
  
            textBox1.Text = "";
            if (isBaseNotWrite.Checked)
            {
                textBox1.Text += "\r\nЗАПИСЬ В БАЗУ ОТКЛЮЧЕНА \r\n\r\n";

            }

            Dictionary<string, object> si;
            si = new Dictionary<string, object>();
            DataRow[] dr = GetRow("select id,INN,KPP from wrk_contragents");
            DataRow[] DTTN11, DTTN12;

            if (isBaseNotWrite.Checked)
            {
                TTN = new List<string>();
                DTTN = new List<string>();
                DTTN11 = GetRow("select P213,P214,id from decF11");
                DTTN12 = GetRow("select P29,P210,id from decF12");

                for (int i = 0; i < DTTN11.Count(); i++)
                {
                    if (!TTN.Contains(DTTN11[i][0] + "|" + DTTN11[i][1]))
                    {
                        TTN.Add(DTTN11[i][0] + "|" + DTTN11[i][1]);
                    }
                }

                for (int i = 0; i < DTTN12.Count(); i++)
                {
                    if (!TTN.Contains(DTTN12[i][0] + "|" + DTTN12[i][1]))
                    {
                        TTN.Add(DTTN12[i][0] + "|" + DTTN12[i][1]);
                    }
                }
            }

            foreach (DataRow contr in dr)
            {
                si[contr[1].ToString().Trim() + contr[2].ToString().Trim()] = contr[0];
            }

            //Lic
            Dictionary<object, object> lic;
            lic = new Dictionary<object, object>();
            dr = GetRow("select id,ref_contr_id from wrk_contr_licenses");
            foreach (DataRow lc in dr)
            {
                lic[lc[1]] = lc[0];
            }

            



            string prevprod = "", prevpost = "", prevkpp = "";
            line = 0;
            foreach (string s in Text)
            {
                line++;


                string[] rec = GetElem(s);
                //0 - код
                //1,2 - ИНН, КПП Производителя
                //3,4 - ИНН, КПП Поставщика
                //5 - дата
                //6 - ТТН
                //7 - объем
                string lcs = "", prod, post;
                if (rec.GetLength(0) != 8)
                {
                    textBox1.Text += "Строка '\t" + s.Trim() + "\t' имеет неверный формат \r\n";
                    continue;
                }
                for (int i = 0; i < 8; i++) rec[i] = rec[i].Trim();

                //Проверка на не осиливших форматирование в Excel
                if ((rec[1].Length == 9) && (rec[2].Length == 8))
                {
                    rec[1] = "0" + rec[1];
                    rec[2] = "0" + rec[2];
                }

                if ((rec[3].Length == 9) && (rec[4].Length == 8))
                {
                    rec[3] = "0" + rec[3];
                    rec[4] = "0" + rec[4];
                }
                
                //Проверяем наличие строк в базе
                if (isBaseNotWrite.Checked)
                {
                    string st = rec[5] + "|" + rec[6];
                    if (TTN.Contains(st))
                    {
                        if (!DTTN.Contains(st))
                        {
                            DTTN.Add(st);
                        }

                    }
                }

                try
                {
                    prod = si[rec[1] + rec[2]].ToString();


                }
                catch (KeyNotFoundException exept)
                {
                    if ((prevprod == rec[1]) && (prevkpp == rec[2])) continue;
                    textBox1.Text += "Не найден производитель  с ИНН " + rec[1] + " и КПП " + rec[2] + "\r\n";
                    prevprod = rec[1];
                    prevkpp = rec[2];
                    if (!org.Contains(rec[1] + "|" + rec[2]))
                    {
                        org.Add(rec[1] + "|" + rec[2]);
                    }

                    continue;
                }
                try
                {

                    post = si[rec[3].Trim() + rec[4].Trim()].ToString();
                    if (rec[0][0] != '5')
                    {
                        lcs = lic[si[rec[3] + rec[4]]].ToString();
                    }

                }
                catch (KeyNotFoundException exept)
                {

                    if (prevpost == rec[3]) continue;
                    textBox1.Text += "Поставщик с ИНН " + rec[3] + "\t' и КПП " + rec[4] + "\tлибо не найдена его лицензия \r\n";
                    prevpost = rec[3];
                    if (!org.Contains(rec[1] + "|" + rec[2]))
                    {
                        org.Add(rec[1] + "|" + rec[2]);
                    }
                    continue;
                }

                if (!isBaseNotWrite.Checked)
                {

                    
                    //здесь пишем в базу
                    try
                    {

                        ProgLabel.Text = "INN/KPP " + rec[3] + "/" + rec[4] + " Дата: " + rec[5] + " ТТН: " + rec[6] + " Объем: " + rec[7];
                        progressBar1.Value = line * 100 / countOfLines;
                        if (rec[0][0] == '5')
                        {//Это декларация по пиву и пивным продуктам не нужна ни лицензия, ничего
                            if (comboBoxF12Choosing.SelectedItem.ToString().Length == 0) break;
                            string CommandText = "insert into DecF12 ([Hid],[vidCode],[ProdId],[idPost],[P29],[P210],[P212],[TTYPE],[idOrg]) values (" + DeclarationHelper[comboBoxF12Choosing.SelectedItem.ToString()] + ",'" + rec[0] + "'," + prod + "," + post /*+ "," + indL[SrcRows[i][5]]*/ + ",'" + rec[5] + "','" + rec[6] + "'," + rec[7].Replace(",", ".") + ",2,1)";
                            query(CommandText);
                        }
                        else
                        {//Это декларация по остальному алкоголю
                            if (comboBoxF11Choosing.SelectedItem.ToString().Length == 0) break;
                            string CommandText = "insert into DecF11 ([Hid],[vidCode],[ProdId],[idPost],[idLic],[P213],[P214],[P216],[TTYPE],[idOrg]) values (" + DeclarationHelper[comboBoxF11Choosing.SelectedItem.ToString()] + ",'" + rec[0] + "'," + prod + "," + post + "," + lcs.Trim() + ",'" + rec[5] + "','" + rec[6] + "'," + rec[7].Replace(",", ".") + ",2,1)";
                            query(CommandText);
                        }
                    }
                    catch (Exception exc) {
         //               MessageBox.Show("Exception is: \n" + exc.Message);
                    }

                }

            }
            if (isBaseNotWrite.Checked)
            {
                ViewRec vr = new ViewRec(DTTN);
                vr.Show();
            }

            countOfLines = line;
            progressBar1.Visible = false;
            textBox1.Height += 30;
            timer.Stop();
            ProgLabel.Text = "";
            isBaseNotWrite.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ContrAddForm cfm = new ContrAddForm(org,basename);
            cfm.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string path = textBoxF11.Text;
            string[] Text = File.ReadAllLines(path);

            Dictionary<string, object> si, INN;
            si = new Dictionary<string, object>();
            DataRow[] dr = GetRow("select * from wrk_contragents");
            INN = new Dictionary<string, object>();
            foreach (DataRow contr in dr)
            {
                si[contr[1].ToString().Trim() + contr[2].ToString().Trim()] = contr[0];
                INN[contr[1].ToString().Trim()] = contr[0];
            }

            Dictionary<int, int> indexobj;
            indexobj = new Dictionary<int, int>();

            for (int i = 0; i < dr.Length; i++)
            {
                indexobj[Convert.ToInt32(dr[i][0])] = i;
            }

            int f = -1;


            foreach (string s in Text)
            {


                string[] rec = GetElem(s);
                //0 - код
                //1,2 - ИНН, КПП Производителя
                //3,4 - ИНН, КПП Поставщика
                //5 - дата
                //6 - ТТН
                //7 - объем
                string prod, post;
                if (rec.GetLength(0) != 8)
                {
                    continue;
                }
                for (int i = 0; i < 8; i++) rec[i] = rec[i].Trim();

                bool INNOK = true;

                try
                {
                    string inn = INN[rec[1]].ToString();

                }
                catch (KeyNotFoundException exept) { INNOK = false; }

                try
                {
                    prod = si[rec[1] + rec[2]].ToString();
                }

                catch (KeyNotFoundException exept)
                {
                    if (INNOK)
                    {
                        try
                        {
                            int index = Convert.ToInt32(INN[rec[1]]);
                            index = indexobj[index];
                            string connstring = "insert into wrk_contragents ([INN],[KPP],[OrgName],[CCode],[OrgType],[producer],[carrier]) Values ('" + rec[1] + "','" + rec[2] + "','" + dr[index][3] + "','" + dr[index][4] + "'," + dr[index][20] + "," + dr[index][21] + "," + dr[index][23] + ")";
                            connstring = connstring.Replace("True", "1");
                            connstring = connstring.Replace("False", "0");
                            query(connstring);
                            si[rec[1] + rec[2]] = 1;
                        }
                        catch (Exception ex)
                        {
                        }

                        //                        si.Add(rec[1] + rec[2], f--);


                    }

                }

                try
                {

                    post = si[rec[3].Trim() + rec[4].Trim()].ToString();


                }

                catch (KeyNotFoundException exept)
                {
                    if (INNOK)
                    {
                        int index = Convert.ToInt32(INN[rec[1]]);
                        index = indexobj[index];
                        string connstring = "insert into wrk_contragents ([INN],[KPP],[OrgName],[CCode],[OrgType],[producer],[carrier]) Values ('" + rec[3] + "','" + rec[4] + "','" + dr[index][3] + "','" + dr[index][4] + "'," + dr[index][20] + "," + dr[index][21] + "," + dr[index][23] + ")";
                        connstring = connstring.Replace("True", "1");
                        connstring = connstring.Replace("False", "0");
                        query(connstring);
                        si[rec[3] + rec[4]] = 1;
                        //                      si.Add(rec[1] + rec[2], f--);

                        //INN[rec[1]] = 1;
                    }

                }

            }
            isBaseNotWrite.Enabled = true;
        }

        private void FromText_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxF11Choosing_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avalon
{
    public partial class ContrAddForm : Form
    {
        List<string> INNKPP;
        string basename;
        public ContrAddForm(List<string> lst, string basen = "base.sdf")
        {
            basename = basen;
            InitializeComponent();
            INNKPP = lst;
            Char[] sp = new Char[] { '|' };
            for (int i = 0; i < lst.Count(); i++)
            {
                string[] IK = lst[i].Split(sp);
                listBox1.Items.Add("ИНН " + IK[0] + " КПП " + IK[1]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string st = listBox1.SelectedItem.ToString().Replace("ИНН", "");
            st = st.Replace("КПП", "");
            st = st.Trim();
            st = st.Replace("  ", " ");
            Char[] ch = new Char[]{' '};
            string[] IK = st.Split(ch);
            textBox1.Text = IK[0];
            textBox2.Text = IK[1];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string prod = "0";
            if (comboBox1.Items[comboBox1.SelectedIndex] == "Производитель") prod = "1";
            string query = "insert into wrk_contragents ([INN],[KPP],[OrgName],[CCOde],[RCode],[OrgType],[producer]) values ('" +
                textBox1.Text + "','" +
                textBox2.Text + "','" +
                textBox3.Text + "','" +
                "643','" + textBox2.Text.Substring(0, 2) + "',1,"+prod+")";
            BaseWork bw = new BaseWork();

            string ConDst = "DataSource = "+basename + "; Password=7338a7e6-fd3b-49d1-8d90-ddbbc1b39fa1";
            bw.query(query, new System.Data.SqlServerCe.SqlCeConnection(ConDst));

        }

        private void ContrAddForm_Load(object sender, EventArgs e)
        {

        }
    }
}

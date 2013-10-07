using System;
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
    public partial class CompareForm : Form
    {
        DataSet sqlDS1, sqlDS2;
        public CompareForm(int[] df11, int[] df12, SqlCeConnection con)
        {
            string query11, query12;

            query11 = "select * from DecF11 where id = 0";
            int cnt = 0;

            for (int i = 0; i < df11.Count(); i++){
                if (df11[i] != 0 ){
                    query11 += " or id=" + df11[i].ToString(); cnt++;
                }
            }
            cnt = cnt * 100 / df11.Count();



            InitializeComponent();

            label1.Text = label1.Text + "  " + cnt + "% ";

            sqlDS1 = new DataSet("table");
            SqlCeCommand cmd = new SqlCeCommand(query11, con);
            SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

            sda.Fill(sqlDS1, "table");
            dataGridView1.DataSource = sqlDS1.Tables["table"];



            query12 = "select * from DecF12 where id = 0";

            cnt = 0;
            for (int i = 0; i < df12.Count(); i++){
                if (df12[i] != 0 ){
                    query12 += " or id=" + df12[i].ToString();
                    cnt++;
                }
            }


            label2.Text = label2.Text + "  " + Convert.ToDouble(cnt * 100) / df12.Count() + "% ";

            sqlDS2 = new DataSet("table");
            cmd = new SqlCeCommand(query12, con);
            sda = new SqlCeDataAdapter(cmd);

            sda.Fill(sqlDS2, "table");
            dataGridView2.DataSource = sqlDS2.Tables["table"];

        }

        private void CompareForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

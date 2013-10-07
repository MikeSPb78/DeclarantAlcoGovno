using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Avalon
{
    public partial class ExplBases : Form
    {
        private SqlCeConnection inbase;
        private SqlCeConnection outbase;
        private DataSet sqlDS1, sqlDS2;

        public ExplBases(SqlCeConnection inb, SqlCeConnection outb)
        {
            inbase = inb;
            outbase = outb;
//            textBox1.Text = outb.ToString();
 //           textBox2.Text = inb.ToString();
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string t = listBox1.SelectedItem.ToString();
                sqlDS1 = new DataSet(t);

                    string CmdString = "SELECT * FROM " + t;
                    SqlCeCommand cmd = new SqlCeCommand(CmdString, outbase);
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

                    sda.Fill(sqlDS1, t);
                    //                DataRow[] copyRows = sqlDS.Tables[t].Select("TTYPE = 1");

                    dataGridView1.DataSource = sqlDS1.Tables[t];


            }
            catch (Exception ex)
            {
                MessageBox.Show("Отсутствует база-источник исключение : " + ex.Message);
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                string t = listBox2.SelectedItem.ToString();

                sqlDS2 = new DataSet(t);


                    string CmdString = "SELECT * FROM " + t;
                    SqlCeCommand cmd = new SqlCeCommand(CmdString, inbase);
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

                    sda.Fill(sqlDS2, t);
                    //                DataRow[] copyRows = sqlDS.Tables[t].Select("TTYPE = 1");

                    dataGridView2.DataSource = sqlDS2.Tables[t];


            }
            catch (Exception ex)
            {
                MessageBox.Show("Отсутствует база-приемник исключение : " + ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
 //           inbase =      textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
 //           outbase =    textBox2.Text ;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            outbase.Close();
            outbase = new SqlCeConnection("DataSource = " + textBox1.Text + "; Password=7338a7e6-fd3b-49d1-8d90-ddbbc1b39fa1");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            inbase.Close();
            inbase = new SqlCeConnection("DataSource = " + textBox2.Text + "; Password=7338a7e6-fd3b-49d1-8d90-ddbbc1b39fa1");

        }

        private void sqleq1_Click(object sender, EventArgs e)
        {

            DataSet sqlDS = new DataSet("table");

            string CmdString = textBox3.Text;
            SqlCeCommand cmd = new SqlCeCommand(CmdString, outbase);
            SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

            sda.Fill(sqlDS, "table");

        }

        private void sqleq2_Click(object sender, EventArgs e)
        {
            DataSet sqlDS = new DataSet("table");

            string CmdString = textBox4.Text;
            SqlCeCommand cmd = new SqlCeCommand(CmdString, inbase);
            SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

            sda.Fill(sqlDS, "table");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
  //              string t = listBox2.SelectedItem.ToString();
                string t = "table";
                sqlDS2 = new DataSet(t);


                string CmdString = textBox2.Text;
                SqlCeCommand cmd = new SqlCeCommand(CmdString, inbase);
                SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

                sda.Fill(sqlDS2, t);
                //                DataRow[] copyRows = sqlDS.Tables[t].Select("TTYPE = 1");

                dataGridView2.DataSource = sqlDS2.Tables[t];


            }
            catch (Exception ex)
            {
                MessageBox.Show("Отсутствует база-приемник исключение : " + ex.Message);
            }

        }
    }
}

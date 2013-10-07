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
    public partial class EndsForm : Form
    {
        SqlCeConnection Src, Dst;
        DataRow[] source;
        DataRow[] destin;
        public EndsForm(SqlCeConnection src,SqlCeConnection dest )
        {
            InitializeComponent();
            Src = src;
            Dst = dest;

            BaseWork bw = new BaseWork();
            source = bw.GetRow("select * from DecHeader", Src);
            destin = bw.GetRow("select * from DecHeader", Dst);
            for (int i = 0; i < source.Count(); i++)
            {
                sourceBox.Items.Add(source[i][0] + "|" + source[i][1]);
            }
            for (int i = 0; i < destin.Count(); i++)
            {
                destBox.Items.Add(destin[i][0] + "|" + destin[i][1]);
            }

        }

        private void EndsForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseWork bw;
            bw = new BaseWork();
            SText.Text = bw.EndsSet(Src,Dst,sourceBox.Text + "+" + destBox.Text);

        }
    }
}

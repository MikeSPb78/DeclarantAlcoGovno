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
    public partial class ViewRec : Form
    {
        public ViewRec(List<string> list)
        {
            InitializeComponent();
            for (int i = 0; i < list.Count(); i++)
            {
                textBox1.Text += list[i].Replace('|','\t') + "\r\n";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataSplitter
{
    public partial class Form3 : Form
    {
        public string heading_range;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            heading_range = headingRangeTextBox.Text;
            if (heading_range != "")
                this.DialogResult = DialogResult.OK;
        }
    }
}

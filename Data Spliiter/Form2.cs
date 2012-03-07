using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_Spliiter
{
    public partial class Form2 : Form
    {
        public DataSet headingSet { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            headingsDataGridView.DataSource = headingSet.Tables[0];
            foreach (DataGridViewRow r in headingsDataGridView.Rows)
            {
                headingsDataGridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
            headingsDataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders); 
        }
    }
}

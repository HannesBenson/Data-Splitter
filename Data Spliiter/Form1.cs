using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Excel=Microsoft.Office.Interop.Excel;


namespace DataSplitter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void inputFilebutton_Click(object sender, EventArgs e)
        {
            inputFileDialog.ShowDialog();
        }

        private void inputFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            inputFileNameTextBox.Text = inputFileDialog.FileName;
        }

        private void outputDirectoryButton_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFolderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                outputFolderTextBox.Text = saveFolderBrowserDialog.SelectedPath;
            }
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            Boolean valid_file = false;
            Boolean valid_directory = false;
            if (!File.Exists(inputFileNameTextBox.Text))
                MessageBox.Show("Please select a valid input file");
            else
                valid_file = true;

            if (!Directory.Exists(outputFolderTextBox.Text))
                MessageBox.Show("Please select a valid output directory");
            else
                valid_directory = true;
            if (valid_directory && valid_file)
            {
                SpreadsheetSplitter splitter = new SpreadsheetSplitter(inputFileNameTextBox.Text, outputFolderTextBox.Text);
                Form2 heading_form = new Form2();
                heading_form.headingSet = splitter.getHeadings();
                if (heading_form.ShowDialog() == DialogResult.OK) {
                    splitter.processFile(progressLabel, progressBar1);
                }
                else
                {
                    bool valid_range = false;
                    do
                    {
                        Form3 user_heading_form = new Form3();
                        user_heading_form.ShowDialog();
                        if (!String.IsNullOrEmpty(user_heading_form.heading_range))
                            valid_range = splitter.processHeadings(user_heading_form.heading_range);
                        if (!valid_range)
                            MessageBox.Show("Please enter a valid range!");
                    } while (!valid_range);
                    splitter.processFile(progressLabel, progressBar1);
                }
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

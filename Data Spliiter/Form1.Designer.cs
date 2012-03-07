namespace Data_Spliiter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.inputFileNameTextBox = new System.Windows.Forms.TextBox();
            this.inputFilebutton = new System.Windows.Forms.Button();
            this.outputDirectoryButton = new System.Windows.Forms.Button();
            this.outputFolderTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.quitButton = new System.Windows.Forms.Button();
            this.processButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputFileDialog
            // 
            this.inputFileDialog.FileName = "inputFileDialog";
            this.inputFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.inputFileDialog_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name";
            // 
            // inputFileNameTextBox
            // 
            this.inputFileNameTextBox.Location = new System.Drawing.Point(86, 91);
            this.inputFileNameTextBox.Name = "inputFileNameTextBox";
            this.inputFileNameTextBox.Size = new System.Drawing.Size(250, 20);
            this.inputFileNameTextBox.TabIndex = 1;
            // 
            // inputFilebutton
            // 
            this.inputFilebutton.Location = new System.Drawing.Point(342, 89);
            this.inputFilebutton.Name = "inputFilebutton";
            this.inputFilebutton.Size = new System.Drawing.Size(86, 23);
            this.inputFilebutton.TabIndex = 2;
            this.inputFilebutton.Text = "Select File";
            this.inputFilebutton.UseVisualStyleBackColor = true;
            this.inputFilebutton.Click += new System.EventHandler(this.inputFilebutton_Click);
            // 
            // outputDirectoryButton
            // 
            this.outputDirectoryButton.Location = new System.Drawing.Point(342, 152);
            this.outputDirectoryButton.Name = "outputDirectoryButton";
            this.outputDirectoryButton.Size = new System.Drawing.Size(86, 23);
            this.outputDirectoryButton.TabIndex = 5;
            this.outputDirectoryButton.Text = "Select Folder";
            this.outputDirectoryButton.UseVisualStyleBackColor = true;
            this.outputDirectoryButton.Click += new System.EventHandler(this.outputDirectoryButton_Click);
            // 
            // outputFolderTextBox
            // 
            this.outputFolderTextBox.Location = new System.Drawing.Point(86, 154);
            this.outputFolderTextBox.Name = "outputFolderTextBox";
            this.outputFolderTextBox.Size = new System.Drawing.Size(250, 20);
            this.outputFolderTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Folder Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Input File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Output directory";
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(250, 191);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(86, 23);
            this.quitButton.TabIndex = 8;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(342, 191);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(86, 23);
            this.processButton.TabIndex = 9;
            this.processButton.Text = "Process";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 13);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(410, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(16, 43);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(0, 13);
            this.progressLabel.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 225);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outputDirectoryButton);
            this.Controls.Add(this.outputFolderTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputFilebutton);
            this.Controls.Add(this.inputFileNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Split excel file";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog inputFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputFileNameTextBox;
        private System.Windows.Forms.Button inputFilebutton;
        private System.Windows.Forms.Button outputDirectoryButton;
        private System.Windows.Forms.TextBox outputFolderTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog saveFolderBrowserDialog;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressLabel;
    }
}


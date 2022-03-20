namespace WinFormsParallelLoopApp
{
    partial class ParallelLoopForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FileProcessorGroup = new System.Windows.Forms.GroupBox();
            this.ProcessJpgsButton = new System.Windows.Forms.Button();
            this.FolderResultsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FolderProcessButton = new System.Windows.Forms.Button();
            this.FolderBrowseButton = new System.Windows.Forms.Button();
            this.FolderToProcessTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderToProcessDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.CancelButton = new System.Windows.Forms.Button();
            this.FileProcessorGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileProcessorGroup
            // 
            this.FileProcessorGroup.Controls.Add(this.CancelButton);
            this.FileProcessorGroup.Controls.Add(this.ProcessJpgsButton);
            this.FileProcessorGroup.Controls.Add(this.FolderResultsTextBox);
            this.FileProcessorGroup.Controls.Add(this.label2);
            this.FileProcessorGroup.Controls.Add(this.FolderProcessButton);
            this.FileProcessorGroup.Controls.Add(this.FolderBrowseButton);
            this.FileProcessorGroup.Controls.Add(this.FolderToProcessTextBox);
            this.FileProcessorGroup.Controls.Add(this.label1);
            this.FileProcessorGroup.Location = new System.Drawing.Point(17, 20);
            this.FileProcessorGroup.Name = "FileProcessorGroup";
            this.FileProcessorGroup.Size = new System.Drawing.Size(1077, 344);
            this.FileProcessorGroup.TabIndex = 0;
            this.FileProcessorGroup.TabStop = false;
            this.FileProcessorGroup.Text = "File Processor";
            // 
            // ProcessJpgsButton
            // 
            this.ProcessJpgsButton.Location = new System.Drawing.Point(748, 28);
            this.ProcessJpgsButton.Name = "ProcessJpgsButton";
            this.ProcessJpgsButton.Size = new System.Drawing.Size(172, 46);
            this.ProcessJpgsButton.TabIndex = 6;
            this.ProcessJpgsButton.Text = "Process JPGs";
            this.ProcessJpgsButton.UseVisualStyleBackColor = true;
            this.ProcessJpgsButton.Click += new System.EventHandler(this.ProcessJpgsButton_Click);
            // 
            // FolderResultsTextBox
            // 
            this.FolderResultsTextBox.Location = new System.Drawing.Point(12, 188);
            this.FolderResultsTextBox.Multiline = true;
            this.FolderResultsTextBox.Name = "FolderResultsTextBox";
            this.FolderResultsTextBox.ReadOnly = true;
            this.FolderResultsTextBox.Size = new System.Drawing.Size(1042, 128);
            this.FolderResultsTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Results";
            // 
            // FolderProcessButton
            // 
            this.FolderProcessButton.Location = new System.Drawing.Point(927, 81);
            this.FolderProcessButton.Name = "FolderProcessButton";
            this.FolderProcessButton.Size = new System.Drawing.Size(127, 46);
            this.FolderProcessButton.TabIndex = 3;
            this.FolderProcessButton.Text = "Process";
            this.FolderProcessButton.UseVisualStyleBackColor = true;
            this.FolderProcessButton.Click += new System.EventHandler(this.FolderProcessButton_Click);
            // 
            // FolderBrowseButton
            // 
            this.FolderBrowseButton.Location = new System.Drawing.Point(748, 81);
            this.FolderBrowseButton.Name = "FolderBrowseButton";
            this.FolderBrowseButton.Size = new System.Drawing.Size(172, 46);
            this.FolderBrowseButton.TabIndex = 2;
            this.FolderBrowseButton.Text = "Browse";
            this.FolderBrowseButton.UseVisualStyleBackColor = true;
            this.FolderBrowseButton.Click += new System.EventHandler(this.FolderBrowseButton_Click);
            // 
            // FolderToProcessTextBox
            // 
            this.FolderToProcessTextBox.Location = new System.Drawing.Point(12, 88);
            this.FolderToProcessTextBox.Name = "FolderToProcessTextBox";
            this.FolderToProcessTextBox.Size = new System.Drawing.Size(722, 39);
            this.FolderToProcessTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder to Process";
            // 
            // folderToProcessDialog
            // 
            this.folderToProcessDialog.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            this.folderToProcessDialog.ShowNewFolderButton = false;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(927, 28);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(127, 46);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ParallelLoopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 384);
            this.Controls.Add(this.FileProcessorGroup);
            this.Name = "ParallelLoopForm";
            this.Text = "Parallel Loops";
            this.FileProcessorGroup.ResumeLayout(false);
            this.FileProcessorGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox FileProcessorGroup;
        private Button FolderProcessButton;
        private Button FolderBrowseButton;
        private TextBox FolderToProcessTextBox;
        private Label label1;
        private TextBox FolderResultsTextBox;
        private Label label2;
        private FolderBrowserDialog folderToProcessDialog;
        private Button ProcessJpgsButton;
        private Button CancelButton;
    }
}
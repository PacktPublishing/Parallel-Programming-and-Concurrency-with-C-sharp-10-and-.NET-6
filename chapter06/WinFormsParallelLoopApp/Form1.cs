using System.Text;

namespace WinFormsParallelLoopApp
{
    public partial class ParallelLoopForm : Form
    {
        public ParallelLoopForm()
        {
            InitializeComponent();
        }

        private void FolderBrowseButton_Click(object sender, EventArgs e)
        {
            var result = folderToProcessDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FolderToProcessTextBox.Text = folderToProcessDialog.SelectedPath;
            }
        }

        private void FolderProcessButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FolderToProcessTextBox.Text) &&
                Directory.Exists(FolderToProcessTextBox.Text))
            {
                string[] filesToProcess = Directory.GetFiles(FolderToProcessTextBox.Text);
                FileData? results = FileProcessor.GetInfoForFiles(filesToProcess);

                if (results == null)
                {
                    FolderResultsTextBox.Text = "";
                    return;
                }

                StringBuilder resultText = new();
                resultText.Append($"Total file count: {results.FileInfoList.Count}; ");
                resultText.AppendLine($"Total file size: {results.TotalSize} bytes");
                resultText.Append($"Last accessed file: {results.LastAccessedFileName} ");
                resultText.Append($"at {results.LastFileWriteTime}");
                FolderResultsTextBox.Text = resultText.ToString();
            }
        }
    }
}
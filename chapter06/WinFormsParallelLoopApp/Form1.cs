using System.Text;

namespace WinFormsParallelLoopApp
{
    public partial class ParallelLoopForm : Form
    {
        private CancellationTokenSource _cts;

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
                FileData? results = FileProcessor.GetInfoForFilesThreadLocal(filesToProcess);

                if (results == null)
                {
                    FolderResultsTextBox.Text = "";
                    return;
                }

                StringBuilder resultText = new();
                resultText.Append($"Total file count: {results.FileInfoList.Count}; ");
                resultText.AppendLine($"Total file size: {results.TotalSize} bytes");
                resultText.Append($"Last written file: {results.LastWrittenFileName} ");
                resultText.Append($"at {results.LastFileWriteTime}");
                FolderResultsTextBox.Text = resultText.ToString();
            }
        }

        private async void ProcessJpgsButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FolderToProcessTextBox.Text) &&
                Directory.Exists(FolderToProcessTextBox.Text))
            {
                _cts = new CancellationTokenSource();
                List<string> filesToProcess = Directory.GetFiles(FolderToProcessTextBox.Text).ToList();
                List<Bitmap> results = await FileProcessor.ConvertFilesToBitmapsAsync(filesToProcess, _cts);

                StringBuilder resultText = new();

                foreach (var bmp in results)
                {
                    resultText.AppendLine($"Bitmap height: {bmp.Height}");
                }

                FolderResultsTextBox.Text = resultText.ToString();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (_cts != null)
            {
                _cts.Cancel();
            }
        }
    }
}
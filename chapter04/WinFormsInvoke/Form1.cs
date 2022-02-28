namespace WinFormsInvoke
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRunInBackground_Click(object sender, EventArgs e)
        {
            Task.Run(UpdateUsername);
        }

        private void btnRunOnMainThread_Click(object sender, EventArgs e)
        {
            UpdateUsername();
        }

        private void UpdateUsername()
        {
            var updateAction = new Action(() =>
            {
                usernameTextBox.Text = "John Doe";
            });

            if (this.InvokeRequired)
            {
                this.Invoke(updateAction);
            }
            else
            {
                updateAction();
            }
        }
    }
}
namespace WorkingWithTimers
{
    public partial class TimerForm : Form
    {
        private TimerSample _timerSample;
        private ThreadingTimerSample _threadingTimerSample;

        public TimerForm()
        {
            InitializeComponent();

            _timerSample = new TimerSample();
            _threadingTimerSample = new ThreadingTimerSample();
        }

        private void startTimerButton_Click(object sender, EventArgs e)
        {
            _timerSample.StartTimer();
        }

        private void stopTimerButton_Click(object sender, EventArgs e)
        {
            _timerSample.StopTimer();
        }

        private void startThreadingTimerButton_Click(object sender, EventArgs e)
        {
            _threadingTimerSample.StartTimer();
        }

        private async void stopThreadingTimerButton_Click(object sender, EventArgs e)
        {
            await _threadingTimerSample.DisposeTimerAsync();
        }
    }
}
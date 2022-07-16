namespace MemoryExample
{
    public class WorkService
    {
        public void WorkWithTimer()
        {
            using var worker = new Worker();
            using var timer = new System.Timers.Timer(1000);
            timer.Elapsed += worker.DoWork;
            timer.Start();
            Thread.Sleep(5000);

            timer.Stop();
            timer.Elapsed -= worker.DoWork;
        }
    }
}
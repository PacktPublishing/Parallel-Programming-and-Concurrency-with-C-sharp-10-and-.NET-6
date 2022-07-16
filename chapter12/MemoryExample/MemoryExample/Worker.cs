namespace MemoryExample
{
    public class Worker : IDisposable
    {
        public void Dispose()
        {
            // dispose objects here
        }

        public void DoWork(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Parallel.For(0, 5, (x) =>
            {
                Thread.Sleep(100);
            });
        }
    }
}
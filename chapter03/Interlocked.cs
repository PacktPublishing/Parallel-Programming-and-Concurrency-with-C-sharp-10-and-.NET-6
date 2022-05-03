public class InterlockedSample
{
    private long _runningTotal;

    public void PerformCalculations()
    {
        _runningTotal = 3;
        Parallel.Invoke(() =>
        {
            AddValue().Wait();
        }, () =>
        {
            MultiplyValue().Wait();
        });
        Console.WriteLine($"Running total is {_runningTotal}");
    }
    private async Task AddValue()
    {
        await Task.Delay(100);
        Interlocked.Add(ref _runningTotal, 15);
    }
    private async Task MultiplyValue()
    {
        await Task.Delay(100);
        var currentTotal = Interlocked.Read(ref _runningTotal);
        Interlocked.Exchange(ref _runningTotal, currentTotal * 10);
    }
}
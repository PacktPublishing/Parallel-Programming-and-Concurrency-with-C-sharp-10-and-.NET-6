public class DeadlockSample
{
    private object _lock = new object();
    private List<string> _data;

    public DeadlockSample()
    {
        _data = new List<string>();
        _data.Add("First");
        _data.Add("Second");
        _data.Add("Third");
    }

    public void ProcessData()
    {
        lock (_lock)
        {
            foreach(var item in _data)
            {
                Console.WriteLine(item);
            }

            AddData();
        }
    }

    private void AddData()
    {
        if (Monitor.TryEnter(_lock, 1000))
        {  
            try
            {  
                _data.AddRange(GetMoreData());
            }  
            finally
            {  
                Monitor.Exit(_lock);  
            }  
        }  
        else
        {  
            Console.WriteLine($"AddData: Unable to acquire lock. Stack trace: {Environment.StackTrace}");
        }
    }

    private List<string> GetMoreData()
    {
        return new List<string> { "Fourth", "Fifth", "Sixth" };
    }

    private int _runningTotal;
    public void PerformCalculationsRace()
    {
        _runningTotal = 3;
        Parallel.Invoke(async () => {
            await AddValue();
        }, async () => {
            await MultiplyValue();
        });
        Console.WriteLine($"Running total is {_runningTotal}");
    }
    private async Task AddValue()
    {
        await Task.Delay(100);
        _runningTotal += 15;
    }
    private async Task MultiplyValue()
    {
        await Task.Delay(100);
        _runningTotal = _runningTotal * 10;
    }

    public async Task PerformCalculations()
    {
        _runningTotal = 3;
        await MultiplyValue().ContinueWith(async (Task) => {
            await AddValue();
            });
        Console.WriteLine($"Running total is {_runningTotal}");
    }
}
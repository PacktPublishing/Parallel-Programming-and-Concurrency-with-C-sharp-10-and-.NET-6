public class ThreadingLimitsSample
{
    public void ProcessParallelForEachWithLimits(List<string> items)
    {
        int max = Environment.ProcessorCount > 1 ? 
                    Environment.ProcessorCount / 2 : 1;
        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = max
        };
        Parallel.ForEach(items, options, y => {
            // Process items
        });
    }

    public bool ProcessPlinqWithLimits(List<string> items)
    {
        int max = Environment.ProcessorCount > 1 ? 
            Environment.ProcessorCount / 2 : 1;
        return items.AsParallel()
            .WithDegreeOfParallelism(max)
            .Any(i => CheckString(i));
    }
    private bool CheckString(string item)
    {
        return !string.IsNullOrWhiteSpace(item);
    }

    private void UpdateThreadPoolMax()
    {
        ThreadPool.GetMinThreads(out int workerMin, out int completionMin);
        int workerMax = GetProcessingMax(workerMin);
        int completionMax = GetProcessingMax(completionMin);
        ThreadPool.SetMaxThreads(workerMax, completionMax);
    }
    private int GetProcessingMax(int min)
    {
        return min < Environment.ProcessorCount ?
                     Environment.ProcessorCount * 2 :
                     min * 2;
    }
}
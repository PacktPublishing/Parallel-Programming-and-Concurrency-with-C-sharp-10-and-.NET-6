namespace ParallelExamples
{
    internal class ParallelForEachExample
    {
        internal void ExecuteParallelForEach(IList<int> numbers)
        {
            Parallel.ForEach(numbers, number =>
            {
                bool timeContainsNumber = DateTime.Now.ToLongTimeString().Contains(number.ToString());
                if (timeContainsNumber)
                {
                    Console.WriteLine($"The current time contains number {number}. Thread id: {Thread.CurrentThread.ManagedThreadId}");
                }
                else
                {
                    Console.WriteLine($"The current time does not contain number {number}. Thread id: {Thread.CurrentThread.ManagedThreadId}");
                }
            });
        }
    }
}
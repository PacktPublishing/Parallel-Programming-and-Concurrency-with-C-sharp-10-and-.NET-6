namespace ParallelExamples
{
    internal class ParallelInvokeExample
    {
        internal void DoWorkInParallel()
        {
            Parallel.Invoke(
                DoComplexWork,
                () => {
                    Console.WriteLine($"Hello from lambda expression. Thread id: {Thread.CurrentThread.ManagedThreadId}");
                },
                new Action(() =>
                {
                    Console.WriteLine($"Hello from Action. Thread id: {Thread.CurrentThread.ManagedThreadId}");
                }),
                delegate ()
                {
                    Console.WriteLine($"Hello from delegate. Thread id: {Thread.CurrentThread.ManagedThreadId}");
                }
            );
        }

        private void DoComplexWork()
        {
            Console.WriteLine($"Hello from DoComplexWork method. Thread id: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
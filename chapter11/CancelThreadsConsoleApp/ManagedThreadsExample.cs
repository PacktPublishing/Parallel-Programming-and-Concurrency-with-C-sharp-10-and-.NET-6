namespace CancelThreadsConsoleApp
{
    public class ManagedThreadsExample
    {
        public static void ProcessText(object? cancelToken)
        {
            var token = cancelToken as CancellationToken?;
            string text = "";

            for (int x = 0; x < 75000; x++)
            {
                if (token != null && token.Value.IsCancellationRequested)
                {
                    Console.WriteLine($"Cancellation request received. String value: {text}");
                    break;
                }
                text += x + " ";
                Thread.Sleep(500);
            }
        }

        public static void ProcessTextParallel(object? cancelToken)
        {
            var token = cancelToken as CancellationToken?;
            if (token == null) return;
            string text = "";
            ParallelOptions options = new()
            {
                CancellationToken = token.Value,
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
            try
            {
                Parallel.For(0, 75000, options, (x) =>
                {
                    text += x + " ";
                    Thread.Sleep(500);
                });
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"Text value: {text}. {Environment.NewLine} Exception encountered: {e.Message}");
            }
        }

        public static void ProcessNumsPlinq(object? cancelToken)
        {
            int[] input = Enumerable.Range(1, 25000000).ToArray();
            var token = cancelToken as CancellationToken?;
            if (token == null) return;
            int[]? result = null;
            try
            {
                result =
                    (from value in input.AsParallel().WithCancellation(token.Value)
                     where value % 7 == 0
                     orderby value
                     select value).ToArray();
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"Exception encountered: {e.Message}");
            }
        }
    }
}
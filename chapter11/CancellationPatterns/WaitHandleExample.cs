namespace CancellationPatterns
{
    public class WaitHandleExample
    {
        private static ManualResetEventSlim resetEvent = new(false);

        public static async Task CancelWithResetEvent()
        {
            using CancellationTokenSource tokenSource = new();
            var numbers = Enumerable.Range(0, 100000);
            _ = Task.Run(() => ProcessNumbers(numbers, tokenSource.Token), tokenSource.Token);
            Console.WriteLine("Use x to cancel, p to pause, or s to start or resume,");
            Console.WriteLine("Use any other key to quit the program.");

            bool running = true;
            while (running)
            {
                char key = Console.ReadKey(true).KeyChar;

                switch (key)
                {
                    case 'x':
                        tokenSource.Cancel();
                        break;
                    case 'p':
                        resetEvent.Reset();
                        break;
                    case 's':
                        resetEvent.Set();
                        break;
                    default:
                        running = false;
                        break;
                }
                await Task.Delay(100);
            }
        }

        private static void ProcessNumbers(IEnumerable<int> numbers, CancellationToken token)
        {
            foreach (var number in numbers)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Cancel requested");
                    token.ThrowIfCancellationRequested();
                }
                try
                {
                    resetEvent.Wait(token);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Operation canceled.");
                    break;
                }

                if (number % 2 == 0)
                    Console.WriteLine($"Found even number: {number}");
                Thread.Sleep(500);
            }
        }
    }
}
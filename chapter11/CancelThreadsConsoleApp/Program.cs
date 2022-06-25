namespace CancelThreadsConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CancelThread();
            //CancelParallelFor();
            CancelPlinq();
            Console.ReadKey();
        }

        private static void CancelThread()
        {
            using CancellationTokenSource tokenSource = new();
            Console.WriteLine("Starting operation.");
            ThreadPool.QueueUserWorkItem(new WaitCallback(ManagedThreadsExample.ProcessText), tokenSource.Token);
            Thread.Sleep(5000);
            Console.WriteLine("Requesting cancellation.");
            tokenSource.Cancel();
            Console.WriteLine("Cancellation requested.");
        }

        private static void CancelParallelFor()
        {
            using CancellationTokenSource tokenSource = new();
            Console.WriteLine("Press a key to start, then press 'x' to send cancellation.");
            Console.ReadKey();
            Task.Run(() =>
            {
                if (Console.ReadKey().KeyChar == 'x')
                    tokenSource.Cancel();
                Console.WriteLine();
                Console.WriteLine("press a key");
            });
            ManagedThreadsExample.ProcessTextParallel(tokenSource.Token);
        }

        private static void CancelPlinq()
        {
            using CancellationTokenSource tokenSource = new();
            Console.WriteLine("Press a key to start.");
            Console.ReadKey();
            Task.Run(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine("Requesting cancel.");
                tokenSource.Cancel();
                Console.WriteLine("Cancel requested.");
            });
            ManagedThreadsExample.ProcessTextPlinq(tokenSource.Token);
        }
    }
}
using System.Drawing;

namespace CancellationPatterns
{
    public class PollingExample
    {
        public static void CancelWithPolling()
        {
            using CancellationTokenSource tokenSource = new();
            CancelWithPolling(tokenSource);
        }

        public static void CancelWithPolling(CancellationTokenSource tokenSource)
        {
            Task.Run(() => FindSmallXValues(GeneratePoints(1000000), tokenSource.Token), tokenSource.Token);
            if (Console.ReadKey(true).KeyChar == 'x')
            {
                tokenSource.Cancel();
                Console.WriteLine("Press a key to quit");
            }
        }

        private static void FindSmallXValues(List<Point> points, CancellationToken token)
        {
            foreach (Point point in points)
            {
                if (point.X < 50)
                {
                    Console.WriteLine($"Point with small X coordinate found. Value: {point.X}");
                }
                if (token.IsCancellationRequested)
                {
                    break;
                }
                Thread.SpinWait(5000);
            }
        }

        private static List<Point> GeneratePoints(int count)
        {
            var rand = new Random();
            var points = new List<Point>();
            for (int i = 0; i <= count; i++)
            {
                points.Add(new Point(rand.Next(1, count * 2), 100));
            }
            return points;
        }
    }
}
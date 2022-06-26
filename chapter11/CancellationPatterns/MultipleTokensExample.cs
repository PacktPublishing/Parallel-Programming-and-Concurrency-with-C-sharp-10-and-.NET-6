namespace CancellationPatterns
{
    public class MultipleTokensExample
    {
        public static void CancelWithMultipleTokens(CancellationToken parentToken)
        {
            using CancellationTokenSource tokenSource = new();
            using CancellationTokenSource combinedSource = CancellationTokenSource.CreateLinkedTokenSource(parentToken, tokenSource.Token);
            PollingExample.CancelWithPolling(combinedSource);
            Thread.Sleep(1000);
            tokenSource.Cancel();
        }
    }
}
using System.Net;

namespace CancellationPatterns
{
    public class CallbackExample
    {
        public static async Task CancelWithCallback()
        {
            using CancellationTokenSource tokenSource = new();
            Console.WriteLine("Starting download");
            var task = DownloadAudioAsync(tokenSource.Token);
            tokenSource.Token.WaitHandle.WaitOne(TimeSpan.FromSeconds(3));
            tokenSource.Cancel();
            try
            {
                await task;
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"Download canceled. Exception: {ex.Message}");
            }
        }

        private static async Task DownloadAudioAsync(CancellationToken token)
        {
            const string url = "https://archive.org/download/lp_the-odyssey_homer-anthony-quayle/disc1/lp_the-odyssey_homer-anthony-quayle_disc1side1.flac";
            using WebClient webClient = new();
            token.Register(webClient.CancelAsync);
            try
            {
                await webClient.DownloadFileTaskAsync(url, GetDownloadFileName());
            }
            catch (WebException we)
            {
                if (we.Status == WebExceptionStatus.RequestCanceled)
                    throw new OperationCanceledException();
            }
            catch (AggregateException ae)
            {
                foreach (Exception ex in ae.InnerExceptions)
                {
                    if (ex is WebException exWeb &&
                        exWeb.Status == WebExceptionStatus.RequestCanceled)
                        throw new OperationCanceledException();
                }
            }
            catch (TaskCanceledException)
            {
                throw new OperationCanceledException();
            }
        }

        private static string GetDownloadFileName()
        {
            string path = System.Reflection.Assembly.GetAssembly(typeof(CallbackExample)).Location;
            string folder = Path.GetDirectoryName(path);
            return Path.Combine(folder, "audio.flac");
        }
    }
}
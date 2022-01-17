namespace BackgroundPingConsoleApp_cancel
{
    internal class NetworkingWork
    {
        public void CheckNetworkStatus(object data)
        {
            var cancelToken = (CancellationToken)data;

            while (!cancelToken.IsCancellationRequested)
            {
                bool isNetworkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                Console.WriteLine($"Is network available? Answer: {isNetworkUp}");
            }
        }
    }
}

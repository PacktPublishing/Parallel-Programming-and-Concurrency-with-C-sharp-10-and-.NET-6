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

        public void CheckNetworkStatus2(object data)
        {
            bool finish = false;
            var cancelToken = (CancellationToken)data;
            cancelToken.Register(() => {
                // Clean up and end pending work
                finish = true;
            });

            while (!finish)
            {
                bool isNetworkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                Console.WriteLine($"Is network available? Answer: {isNetworkUp}");
            }
        }
    }
}
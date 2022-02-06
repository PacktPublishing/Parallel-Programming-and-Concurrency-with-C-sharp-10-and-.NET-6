namespace AsyncConsoleExample
{
    internal class NetworkHelper
    {
        internal async Task CheckNetworkStatusAsync()
        {
            Task t = NetworkCheckInternalAsync();

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("Top level method working...");
                await Task.Delay(500);
            }

            await t;
        }

        private async Task NetworkCheckInternalAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                bool isNetworkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                Console.WriteLine($"Is network available? Answer: {isNetworkUp}");
                await Task.Delay(100);
            }
        }
    }
}
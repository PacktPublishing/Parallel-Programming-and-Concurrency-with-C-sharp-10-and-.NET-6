using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ThreadingStaticDataExample
{
    internal class WorkstationState
    {
        internal static string Name { get; set; }
        internal static string IpAddress { get; set;}
        internal static bool IsNetworkAvailable { get; set; }
        [ThreadStatic]
        internal static DateTime? NetworkConnectivityLastUpdated;
        static WorkstationState()
        {
            Name = Dns.GetHostName();
            IpAddress = GetLocalIPAddress(Name);
            IsNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
            NetworkConnectivityLastUpdated = DateTime.UtcNow;
            Thread.Sleep(2000);
        }
        private static string GetLocalIPAddress(string hostName)
        {
            var hostEntry = Dns.GetHostEntry(hostName);
            foreach (var address in hostEntry.AddressList
                                    .Where(a => a.AddressFamily == AddressFamily.InterNetwork))
            {
                return address.ToString();
            }
            return string.Empty;
        }
    }
}
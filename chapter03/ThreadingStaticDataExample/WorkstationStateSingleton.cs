using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ThreadingStaticDataExample
{
    public class WorkstationStateSingleton
    {
        private static WorkstationStateSingleton? _singleton = null;
        private static readonly object _lock = new();

        WorkstationStateSingleton()
        {
            Name = Dns.GetHostName();
            IpAddress = GetLocalIPAddress(Name);
            IsNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
            NetworkConnectivityLastUpdated = DateTime.UtcNow;
        }

        public static WorkstationStateSingleton Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_singleton == null)
                    {
                        _singleton = new WorkstationStateSingleton();
                    }
                    return _singleton;
                }
            }
        }

        public string Name { get; set; }
        public string IpAddress { get; set; }
        public bool IsNetworkAvailable { get; set; }
        public DateTime? NetworkConnectivityLastUpdated { get; set; }

        private string GetLocalIPAddress(string hostName)
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
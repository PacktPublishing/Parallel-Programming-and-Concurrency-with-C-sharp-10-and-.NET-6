using System.Net.NetworkInformation;

namespace ThreadingStaticDataExample
{
    internal class WorkstationHelper
    {
        private static object _workstationLock = new object();
        internal async Task<bool> GetNetworkAvailability()
        {
            await Task.Delay(100);
            lock( _workstationLock)
            {
                WorkstationState.IsNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
                WorkstationState.NetworkConnectivityLastUpdated = DateTime.UtcNow;
            }
            return WorkstationState.IsNetworkAvailable;
        }

        internal async Task<bool> GetNetworkAvailabilityFromSingleton()
        {
            await Task.Delay(100);
            var state = WorkstationStateSingleton.Instance;
            lock (_workstationLock)
            {
                state.IsNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
                state.NetworkConnectivityLastUpdated = DateTime.UtcNow;
            }
            return state.IsNetworkAvailable;
        }
    }
}
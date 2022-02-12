using ThreadingStaticDataExample;

Console.WriteLine("Hello, World!");
Console.WriteLine($"Current datetime: {DateTime.UtcNow}");

var helper = new WorkstationHelper();

// await helper.GetNetworkAvailability();

//Parallel.For(1, 30, async (x) =>
//{
//    await helper.GetNetworkAvailability();
//});

await helper.GetNetworkAvailabilityFromSingleton();
Console.WriteLine($"Network availability last updated {WorkstationState.NetworkConnectivityLastUpdated} for computer {WorkstationState.Name} at IP {WorkstationState.IpAddress}");

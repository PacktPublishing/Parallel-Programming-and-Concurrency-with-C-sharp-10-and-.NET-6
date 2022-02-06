using AsyncConsoleExample;

Console.WriteLine("Hello, async!");

var networkHelper = new NetworkHelper();
await networkHelper.CheckNetworkStatusAsync();

Console.WriteLine("Main method complete.");
Console.ReadKey();
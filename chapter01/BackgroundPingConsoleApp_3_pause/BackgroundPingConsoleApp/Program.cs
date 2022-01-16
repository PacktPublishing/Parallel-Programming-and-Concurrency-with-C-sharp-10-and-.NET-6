Console.WriteLine("Hello, World!");

var bgThread = new Thread((object? data) =>
{
    if (data is null) return;

    int counter = 0;
    var result = int.TryParse(data.ToString(), out int maxCount);
    if (!result) return;

    while (counter < maxCount)
    {
        bool isNetworkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        Console.WriteLine($"Is network available? Answer: {isNetworkUp}");
        Thread.Sleep(10);
        counter++;
    }
});

bgThread.Start(12);

for (int i = 0; i < 12; i++)
{
    Console.WriteLine("Main thread working...");
    Thread.Sleep(100);
}

Console.WriteLine("Done");
Console.ReadKey();
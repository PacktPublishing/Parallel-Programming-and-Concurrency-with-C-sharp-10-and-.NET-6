using BackgroundPingConsoleApp_cancel;

Console.WriteLine("Hello, World!");
var networkingWork = new NetworkingWork();

var pingThread = new Thread(networkingWork.CheckNetworkStatus);
var ctSource = new CancellationTokenSource();

pingThread.Start(ctSource.Token);

for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Main thread working...");
    Thread.Sleep(100);
}

ctSource.Cancel();
pingThread.Join();
ctSource.Dispose();

Console.WriteLine("Done");
Console.ReadKey();

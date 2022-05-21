using ConcurrentBag.PdfProcessor;
Console.WriteLine("Hello, ConcurrentBag!");
var pool = new PdfWorkerPool();

Parallel.For(0, 15, async (i) =>
{
    var parser = pool.Get();
    var data = new ImposterPdfData($"Data index: {i}");
    try
    {
        parser.SetPdf(data);
        parser.AppendString(DateTime.UtcNow.ToShortDateString());
        Console.WriteLine($"{parser.GetPdfAsString()}");
        Console.WriteLine($"Parser count: {pool.WorkerCount}");
        await Task.Delay(15);
    }
    finally
    {
        pool.Return(parser);
        await Task.Delay(200);
    }
});

Console.WriteLine("Press the Enter key to exit.");
Console.ReadLine();
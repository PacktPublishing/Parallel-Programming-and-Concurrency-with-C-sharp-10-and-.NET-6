using AsyncSamples;

Console.WriteLine("Start processing...");
var taskSample = new TaskSample();
await taskSample.DoThingsAsync();
Console.WriteLine("Continue processing...");
await taskSample.DoingThingsWrongAsync();
Console.WriteLine("Continue processing...");
await taskSample.DoBlockingThingsAsync();
Console.WriteLine("Done processing...");
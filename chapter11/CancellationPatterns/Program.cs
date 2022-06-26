// See https://aka.ms/new-console-template for more information
using CancellationPatterns;

//Console.WriteLine("Hello, World! Press a key to start, then press 'x' to cancel.");
//Console.ReadKey();
//PollingExample.CancelWithPolling();
//await CallbackExample.CancelWithCallback();
//await WaitHandleExample.CancelWithResetEvent();
CancellationTokenSource tokenSource = new();
MultipleTokensExample.CancelWithMultipleTokens(tokenSource.Token);
Console.ReadKey();
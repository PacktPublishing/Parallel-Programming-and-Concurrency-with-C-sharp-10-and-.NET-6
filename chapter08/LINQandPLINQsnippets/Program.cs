using LINQandPLINQsnippets;
//var exceptionExample = new PlinqExceptionsExample();
//exceptionExample.ProcessAdultsWhoVoteWithPlinq(GetPeople());
var timeFmt = "hh:mm:ss.fff tt";
//var orderExample = new OrderSamples();
//Console.WriteLine($"Start time: {DateTime.Now.ToString(timeFmt)}. AsParallel children:");
//OutputListToConsole(orderExample.GetImportantChildrenNoOrder(GetYoungPeople()).ToList());
//Console.WriteLine($"Start time: {DateTime.Now.ToString(timeFmt)}. AsUnordered children:");
//OutputListToConsole(orderExample.GetImportantChildrenUnordered(GetYoungPeople()).ToList());
//Console.WriteLine($"Start time: {DateTime.Now.ToString(timeFmt)}. Sequential after Where children:");
//OutputListToConsole(orderExample.GetImportantChildrenUnknownOrder(GetYoungPeople()).ToList());
//Console.WriteLine($"Start time: {DateTime.Now.ToString(timeFmt)}. AsOrdered children:");
//OutputListToConsole(orderExample.GetImportantChildrenPreserveOrder(GetYoungPeople()).ToList());
//Console.WriteLine($"Start time: {DateTime.Now.ToString(timeFmt)}. Reverse order children:");
//OutputListToConsole(orderExample.GetImportantChildrenReverseOrder(GetYoungPeople()).ToList());
//Console.WriteLine($"Finish time: {DateTime.Now.ToString(timeFmt)}");
//Console.ReadLine();

var mergeExample = new MergeSamples();
Console.WriteLine($"Start time: {DateTime.Now.ToString(timeFmt)}. NoMerge children:");
OutputListToConsole(mergeExample.GetImportantChildrenNoMergeSpecified(GetYoungPeople()).ToList());
Console.WriteLine($"Start time: {DateTime.Now.ToString(timeFmt)}. DefaultMerge children:");
OutputListToConsole(mergeExample.GetImportantChildrenDefaultMerge(GetYoungPeople()).ToList());
Console.WriteLine($"Start time: {DateTime.Now.ToString(timeFmt)}. AutoBuffered children:");
OutputListToConsole(mergeExample.GetImportantChildrenAutoBuffered(GetYoungPeople()).ToList());
Console.WriteLine($"Start time: {DateTime.Now.ToString(timeFmt)}. NotBuffered children:");
OutputListToConsole(mergeExample.GetImportantChildrenNotBuffered(GetYoungPeople()).ToList());
Console.WriteLine($"Start time: {DateTime.Now.ToString(timeFmt)}. FullyBuffered children:");
OutputListToConsole(mergeExample.GetImportantChildrenFullyBuffered(GetYoungPeople()).ToList());
Console.WriteLine($"Finish time: {DateTime.Now.ToString(timeFmt)}");
Console.ReadLine();

static List<Person> GetPeople()
{
    return new List<Person>
    {
        new Person { FirstName = "Bob", LastName = "Jones", Age = 23 },
        new Person { FirstName = "Sally", LastName = "Shen", Age = 2 },
        new Person { FirstName = "Joe", LastName = "Smith", Age = 45 },
        new Person { FirstName = "Lisa", LastName = "Samson", Age = 98 },
        new Person { FirstName = "Norman", LastName = "Patterson", Age = 121 },
        new Person { FirstName = "Steve", LastName = "Gates", Age = 40 },
        new Person { FirstName = "Richard", LastName = "Ng", Age = 18 }
    };
}

static List<Person> GetYoungPeople()
{
    return new List<Person>
    {
        new Person { FirstName = "Bob", LastName = "Jones", Age = 23 },
        new Person { FirstName = "Sally", LastName = "Shen", Age = 2, IsImportant = true },
        new Person { FirstName = "Joe", LastName = "Smith", Age = 5, IsImportant = true },
        new Person { FirstName = "Lisa", LastName = "Samson", Age = 9, IsImportant = true },
        new Person { FirstName = "Norman", LastName = "Patterson", Age = 17 },
        new Person { FirstName = "Steve", LastName = "Gates", Age = 20 },
        new Person { FirstName = "Richard", LastName = "Ng", Age = 16, IsImportant = true }
    };
}

static void OutputListToConsole(List<Person> list)
{
    foreach (var item in list)
    {
        Console.WriteLine(item.FirstName);
    }
}
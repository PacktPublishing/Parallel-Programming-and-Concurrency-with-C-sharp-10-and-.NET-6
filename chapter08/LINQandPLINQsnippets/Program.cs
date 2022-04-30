using LINQandPLINQsnippets;
var exceptionExample = new PlinqExceptionsExample();
exceptionExample.ProcessAdultsWhoVoteWithPlinq(GetPeople());
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
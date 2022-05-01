namespace LINQandPLINQsnippets
{
    internal class OrderSamples
    {
        internal IEnumerable<Person> GetImportantChildrenNoOrder(List<Person> people)
        {
            return people.AsParallel()
                .Where(p => p.IsImportant && p.Age < 18);
        }

        internal IEnumerable<Person> GetImportantChildrenUnordered(List<Person> people)
        {
            return people.AsParallel().AsUnordered()
                .Where(p => p.IsImportant && p.Age < 18);
        }

        internal IEnumerable<Person> GetImportantChildrenUnknownOrder(List<Person> people)
        {
            return people.AsParallel().Where(p => p.IsImportant)
                .AsSequential().Where(p => p.Age < 18);
        }

        internal IEnumerable<Person> GetImportantChildrenPreserveOrder(List<Person> people)
        {
            return people.AsParallel().AsOrdered()
                .Where(p => p.IsImportant && p.Age < 18);
        }

        internal IEnumerable<Person> GetImportantChildrenReverseOrder(List<Person> people)
        {
            return people.AsParallel().AsOrdered().Reverse()
                .Where(p => p.IsImportant && p.Age < 18);
        }
    }
}
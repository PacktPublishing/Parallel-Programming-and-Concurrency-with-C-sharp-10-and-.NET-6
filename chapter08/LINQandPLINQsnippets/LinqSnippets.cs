namespace LINQandPLINQsnippets
{
    internal class LinqSnippets
    {
        internal void QueryCities(List<string> cities)
        {
            // Query is executed with ToList call
            List<string> citiesWithS = cities.Where(s => s.StartsWith('S')).ToList();

            // Query is not executed here
            IEnumerable<string> citiesWithT = cities.Where(s => s.StartsWith('T'));

            // Query is executed here when enumerating
            foreach (string city in citiesWithT)
            {
                // Do something with citiesWithT
            }
        }

        internal void QueryAndGroupPeople(List<Person> people)
        {
            var results = people.AsParallel().Where(p => p.Age > 17)
                .AsSequential().GroupBy(p => p.LastName);
            foreach (var group in results)
            {
                Console.WriteLine($"Last name {group.Key} has {group.Count()} people.");
            }
            // Sample output:
            // Last name Jones has 4220 people.
            // Last name Xu has 3434 people.
            // Last name Patel has 4798 people.
            // Last name Smith has 3051 people.
            // Last name Sanchez has 3811 people.
            // ...
        }

        internal void QuerySyntaxAndMethodSyntax(List<Person> people)
        {
            var peopleQuery1 = people.AsParallel().Where(p => p.Age > 17);

            var peopleQuery2 = from person in people.AsParallel()
                               where person.Age > 17
                               select person;
        }

        internal void QueryOrderedPeople(List<Person> people)
        {
            var results = people.AsParallel().AsOrdered()
                .Where(p => p.LastName.StartsWith("H"));
        }

        internal void QueryUnorderedPeople(List<Person> people)
        {
            var results = people.AsParallel().AsUnordered()
                .Where(p => p.LastName.StartsWith("H"));
        }

        internal void ProcessAdultsWhoVote(List<Person> people)
        {
            foreach (var person in people)
            {
                if (person.Age < 18) continue;
                ProcessVoterActions(person);
            }
        }
        private void ProcessVoterActions(Person adult)
        {
            // Add adult to a voter database and process their data.
        }

        internal void ProcessAdultsWhoVoteInParallel(List<Person> people)
        {
            var adults = people.Where(p => p.Age > 17);
            Parallel.ForEach(adults, ProcessVoterActions);
        }

        internal void ProcessAdultsWhoVoteWithPlinq(List<Person> people)
        {
            var adults = people.AsParallel().Where(p => p.Age > 17);
            adults.ForAll(ProcessVoterActions);
        }
    }
}
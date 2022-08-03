namespace LINQandPLINQsnippets
{
    internal class PlinqExceptionsExample
    {
        internal void ProcessAdultsWhoVoteWithPlinq(List<Person> people)
        {
            try
            {
                var adults = people.AsParallel().Where(p => p.Age > 17);
                adults.ForAll(ProcessVoterActions);
            }
            catch (AggregateException ae)
            {
                foreach (var ex in ae.InnerExceptions)
                {
                    Console.WriteLine($"Exception encountered while processing voters. Message: {ex.Message}");
                }
            }
        }
        private void ProcessVoterActions(Person adult)
        {
            if (adult.Age > 120)
            {
                throw new ArgumentException("This person is too old!", nameof(adult));
            }
            // Add adult to a voter database and process their data.
        }
        private SpinLock _spinLock = new SpinLock();
        internal void ProcessAdultsWhoVoteWithPlinq2(List<Person> people)
        {
            var adults = people.AsParallel().Where(p => p.Age > 17);
            adults.ForAll(ProcessVoterActions2);
        }
        private void ProcessVoterActions2(Person adult)
        {
            var hasLock = false;
            if (adult.Age > 120)
            {
                try
                {
                    _spinLock.Enter(hasLock);
                    adult.Age = 120;
                }
                finally
                {
                    if (hasLock) _spinLock.Exit();
                }
            }
        } 
    }
}

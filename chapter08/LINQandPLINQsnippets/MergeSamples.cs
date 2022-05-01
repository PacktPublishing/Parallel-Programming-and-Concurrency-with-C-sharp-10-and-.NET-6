namespace LINQandPLINQsnippets
{
    internal class MergeSamples
    {
        internal IEnumerable<Person> GetImportantChildrenNoMergeSpecified(List<Person> people)
        {
            return people.AsParallel()
                .Where(p => p.IsImportant && p.Age < 18).Take(3);
        }
        internal IEnumerable<Person> GetImportantChildrenDefaultMerge(List<Person> people)
        {
            return people.AsParallel().WithMergeOptions(ParallelMergeOptions.Default)
                .Where(p => p.IsImportant && p.Age < 18).Take(3);
        }
        internal IEnumerable<Person> GetImportantChildrenAutoBuffered(List<Person> people)
        {
            return people.AsParallel().WithMergeOptions(ParallelMergeOptions.AutoBuffered)
                .Where(p => p.IsImportant && p.Age < 18).Take(3);
        }
        internal IEnumerable<Person> GetImportantChildrenNotBuffered(List<Person> people)
        {
            return people.AsParallel().WithMergeOptions(ParallelMergeOptions.NotBuffered)
                .Where(p => p.IsImportant && p.Age < 18).Take(3);
        }
        internal IEnumerable<Person> GetImportantChildrenFullyBuffered(List<Person> people)
        {
            return people.AsParallel().WithMergeOptions(ParallelMergeOptions.FullyBuffered)
                .Where(p => p.IsImportant && p.Age < 18).Take(3);
        }
    }
}
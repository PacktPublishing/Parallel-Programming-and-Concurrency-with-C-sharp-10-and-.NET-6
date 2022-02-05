namespace ParallelExamples
{
    internal class ParallelLinqExample
    {
        internal void ExecuteLinqQuery(IList<int> numbers)
        {
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            OutputNumbers(evenNumbers, "Regular");
        }

        internal void ExecuteParallelLinqQuery(IList<int> numbers)
        {
            var evenNumbers = numbers.AsParallel().Where(n => IsEven(n));
            OutputNumbers(evenNumbers, "Parallel");
        }

        private bool IsEven(int number)
        {
            Task.Delay(100);
            return number % 2 == 0;
        }

        private void OutputNumbers(IEnumerable<int> numbers, string loopType)
        {
            var numberString = string.Join(",", numbers);
            Console.WriteLine($"{loopType} number string: {numberString}");
        }
    }
}
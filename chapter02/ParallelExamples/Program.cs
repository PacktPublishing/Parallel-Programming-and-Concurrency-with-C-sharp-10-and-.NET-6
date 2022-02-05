using ParallelExamples;

var parallelExample = new ParallelInvokeExample();
parallelExample.DoWorkInParallel();

var numbers = new List<int> { 1, 3, 5, 7, 9, 0 };
var foreachExample = new ParallelForEachExample();
foreachExample.ExecuteParallelForEach(numbers);

var linqNumbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
var linqExample = new ParallelLinqExample();
linqExample.ExecuteLinqQuery(linqNumbers);
linqExample.ExecuteParallelLinqQuery(linqNumbers);
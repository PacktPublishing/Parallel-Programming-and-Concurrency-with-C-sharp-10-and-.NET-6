using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace JoinBlockExample
{
    public class DataJoiner
    {
        public static void JoinData()
        {
            var stringQueue = new BufferBlock<string>();
            var integerQueue = new BufferBlock<int>();

            var joinStringsAndIntegers = new JoinBlock<string, int>(
                new GroupingDataflowBlockOptions
                {
                    Greedy = false
                });

            var stringIntegerAction = new ActionBlock<Tuple<string, int>>(data =>
            {
                Console.WriteLine($"String received: {data.Item1}");
                Console.WriteLine($"Integer received: {data.Item2}");
            });

            stringQueue.LinkTo(joinStringsAndIntegers.Target1);
            integerQueue.LinkTo(joinStringsAndIntegers.Target2);
            joinStringsAndIntegers.LinkTo(stringIntegerAction);

            stringQueue.Post("one");
            stringQueue.Post("two");
            stringQueue.Post("three");

            integerQueue.Post(1);
            integerQueue.Post(2);
            integerQueue.Post(3);

            stringQueue.Complete();
            integerQueue.Complete();
            Thread.Sleep(1000);
            Console.WriteLine("Complete");
        }
    }
}

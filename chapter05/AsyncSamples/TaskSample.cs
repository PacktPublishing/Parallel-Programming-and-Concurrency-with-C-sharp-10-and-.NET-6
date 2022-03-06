namespace AsyncSamples
{
    public class TaskSample
    {
        public async Task DoThingsAsync()
        {
            Console.WriteLine($"Doing things in {nameof(DoThingsAsync)}");
            await DoFirstThingAsync();
            await DoSecondThingAsync();
            Console.WriteLine($"Did things in {nameof(DoThingsAsync)}");
        }

        public async Task DoingThingsWrongAsync()
        {
            Console.WriteLine($"Doing things in {nameof(DoingThingsWrongAsync)}");
            DoFirstThingAsync();
            await DoSecondThingAsync();
            Console.WriteLine($"Did things in {nameof(DoingThingsWrongAsync)}");
        }

        public async Task DoBlockingThingsAsync()
        {
            Console.WriteLine($"Doing things in {nameof(DoBlockingThingsAsync)}");
            DoFirstThingAsync().Wait();
            await DoSecondThingAsync();
            Console.WriteLine($"Did things in {nameof(DoBlockingThingsAsync)}");
        }

        private async Task DoFirstThingAsync()
        {
            Console.WriteLine($"Doing something in {nameof(DoFirstThingAsync)}");
            await DoAnotherThingAsync();
            Console.WriteLine($"Did something in {nameof(DoFirstThingAsync)}");
        }

        private async Task DoSecondThingAsync()
        {
            Console.WriteLine($"Doing something in {nameof(DoSecondThingAsync)}");
            await Task.Delay(500);
            Console.WriteLine($"Did something in {nameof(DoSecondThingAsync)}");
        }

        private async Task DoAnotherThingAsync()
        {
            Console.WriteLine($"Doing something in {nameof(DoAnotherThingAsync)}");
            await Task.Delay(1500);
            Console.WriteLine($"Did something in {nameof(DoAnotherThingAsync)}");
        }
    }
}
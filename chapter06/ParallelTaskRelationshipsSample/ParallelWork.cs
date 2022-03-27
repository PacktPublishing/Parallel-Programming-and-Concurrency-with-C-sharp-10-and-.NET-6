namespace ParallelTaskRelationshipsSample
{
    public class ParallelWork
    {
        public void DoAllWork()
        {
            Console.WriteLine("Starting DoAllWork");
            Task parentTask = Task.Factory.StartNew(() =>
            {
                var child1 = Task.Factory.StartNew(DoFirstItem);
                var child2 = Task.Factory.StartNew(DoSecondItem);
                var child3 = Task.Factory.StartNew(DoThirdItem);
            });
            parentTask.Wait();
            Console.WriteLine("Finishing DoAllWork");
        }

        public void DoAllWorkAttached()
        {
            Console.WriteLine("Starting DoAllWorkAttached");
            Task parentTask = Task.Factory.StartNew(() =>
            {
                var child1 = Task.Factory.StartNew(DoFirstItem, TaskCreationOptions.AttachedToParent);
                var child2 = Task.Factory.StartNew(DoSecondItem, TaskCreationOptions.AttachedToParent);
                var child3 = Task.Factory.StartNew(DoThirdItem, TaskCreationOptions.AttachedToParent);
            });
            parentTask.Wait();
            Console.WriteLine("Finishing DoAllWorkAttached");
        }

        public void DoAllWorkDenyAttach()
        {
            Console.WriteLine("Starting DoAllWorkDenyAttach");
            Task parentTask = Task.Factory.StartNew(() =>
            {
                var child1 = Task.Factory.StartNew(DoFirstItem, TaskCreationOptions.AttachedToParent);
                var child2 = Task.Factory.StartNew(DoSecondItem, TaskCreationOptions.AttachedToParent);
                var child3 = Task.Factory.StartNew(DoThirdItem, TaskCreationOptions.AttachedToParent);
            }, TaskCreationOptions.DenyChildAttach);
            parentTask.Wait();
            Console.WriteLine("Finishing DoAllWorkDenyAttach");
        }

        public void DoFirstItem()
        {
            Console.WriteLine("Starting DoFirstItem");
            Thread.SpinWait(1000000);
            Console.WriteLine("Finishing DoFirstItem");
        }

        public void DoSecondItem()
        {
            Console.WriteLine("Starting DoSecondItem");
            Thread.SpinWait(1000000);
            Console.WriteLine("Finishing DoSecondItem");
        }

        public void DoThirdItem()
        {
            Console.WriteLine("Starting DoThirdItem");
            Thread.SpinWait(1000000);
            Console.WriteLine("Finishing DoThirdItem");
        }
    }
}

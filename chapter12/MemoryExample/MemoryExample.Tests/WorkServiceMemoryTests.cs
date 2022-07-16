using JetBrains.dotMemoryUnit;

[assembly: SuppressXUnitOutputExceptionAttribute]
namespace MemoryExample.Tests
{
    public class WorkServiceMemoryTests
    {
        [Fact]
        public void WorkWithSquares_Releases_Memory_From_Bitmaps()
        {
            var service = new WorkService();
            service.WorkWithTimer();
            GC.Collect();
            // Make sure there are no Worker objects in memory
            dotMemory.Check(m => Assert.Equal(0, m.GetObjects(o =>
                    o.Type.Is<Worker>()).ObjectsCount));
        }
    }
}
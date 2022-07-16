namespace ParallelExample.Tests
{
    public class TextServiceTests
    {
        [Fact]
        public void ProcessText_Returns_Expected_Strings()
        {
            var service = new TextService();
            var fruits = new List<string> { "apple", "orange", "banana", "peach", "cherry" };
            var results = service.ProcessText(fruits);
            Assert.Equal(fruits.Count, results.Count);
        }

        [Fact]
        public void ProcessText_Throws_Exception_For_Empty_String()
        {
            var service = new TextService();
            var fruits = new List<string> { "apple", "orange", "banana", "peach", "" };
            Assert.Throws<AggregateException>(() => service.ProcessText(fruits));
        }

        [Fact]
        public async Task ProcessTextAsync_Returns_Expected_Strings()
        {
            var service = new TextService();
            var fruits = new List<string> { "apple", "orange", "banana", "peach", "cherry" };
            var results = await service.ProcessTextAsync(fruits);
            Assert.Equal(fruits.Count, results.Count);
        }

        [Fact]
        public async Task ProcessTextAsync_Throws_Exception_For_Empty_String()
        {
            var service = new TextService();
            var fruits = new List<string> { "apple", "orange", "banana", "peach", "" };
            await Assert.ThrowsAsync<Exception>(async () => await service.ProcessTextAsync(fruits));
        }
    }
}
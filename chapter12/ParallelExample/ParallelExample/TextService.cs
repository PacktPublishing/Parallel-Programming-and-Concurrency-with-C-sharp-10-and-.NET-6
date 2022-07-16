namespace ParallelExample
{
    public class TextService
    {
        public List<string> ProcessText(List<string> textValues)
        {
            List<string> result = new();
            Parallel.ForEach(textValues, (txt) => 
            {
                if (string.IsNullOrEmpty(txt))
                {
                    throw new Exception("Strings cannot be empty");
                }
                result.Add(string.Concat(txt, Environment.TickCount));
            });
            return result;
        }

        public async Task<List<string>> ProcessTextAsync(List<string> textValues)
        {
            List<string> result = new();
            await Parallel.ForEachAsync(textValues, async (txt, _) =>
            {
                if (string.IsNullOrEmpty(txt))
                {
                    throw new Exception("Strings cannot be empty");
                }
                result.Add(string.Concat(txt, Environment.TickCount));
                await Task.Delay(100);
            });
            return result;
        }
    }
}
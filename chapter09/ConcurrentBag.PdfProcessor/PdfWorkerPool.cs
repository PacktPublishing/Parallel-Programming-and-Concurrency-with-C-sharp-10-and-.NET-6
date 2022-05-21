using System.Collections.Concurrent;

namespace ConcurrentBag.PdfProcessor
{
    public class PdfWorkerPool
    {
        private ConcurrentBag<PdfParser> _workerPool = new();
        public PdfWorkerPool()
        {
            // Add initial worker
            _workerPool.Add(new PdfParser());
        }
        public PdfParser Get() => _workerPool.TryTake(out var parser) ? parser : new PdfParser();
        public void Return(PdfParser parser) => _workerPool.Add(parser);
        public int WorkerCount => _workerPool.Count();
    }
}
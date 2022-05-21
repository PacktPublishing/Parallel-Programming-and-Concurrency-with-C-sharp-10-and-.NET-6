namespace ConcurrentBag.PdfProcessor
{
    public class ImposterPdfData
    {
        private string _plainText;
        private byte[] _data;
        public ImposterPdfData(string plainText)
        {
            _plainText = plainText;
            _data = System.Text.Encoding.ASCII.GetBytes(plainText);
        }
        public string PlainText => _plainText;
        public byte[] PdfData => _data;
    }
}
namespace ConcurrentBag.PdfProcessor
{
    public class PdfParser
    {
        private ImposterPdfData? _pdf;
        public void SetPdf(ImposterPdfData pdf) => _pdf = pdf;
        public ImposterPdfData? GetPdf() => _pdf;
        public void AppendString(string data)
        {
            string newData;
            if (_pdf == null)
            {
                newData = data;
            }
            else
            {
                newData = _pdf.PlainText + Environment.NewLine + data;
            }
            _pdf = new ImposterPdfData(newData);
        }
        public string GetPdfAsString()
        {
            if (_pdf != null)
                return _pdf.PlainText;
            else
                return "";
        }
        public byte[] GetPdfBytes()
        {
            if (_pdf != null)
                return _pdf.PdfData;
            else
                return new byte[0];
        }
    }
}
namespace WinFormsParallelLoopApp
{
    public class FileData
    {
        public List<FileInfo> FileInfoList { get; set; } = new();
        public long TotalSize { get; set; } = 0;
        public string LastWrittenFileName { get; set; } = "";
        public DateTime LastFileWriteTime { get; set; }
    }
}
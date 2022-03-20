namespace WinFormsParallelLoopApp
{
    public class FileProcessor
    {
        public static FileData GetInfoForFiles(string[] files)
        {
            var results = new FileData();
            var fileInfos = new List<FileInfo>();
            long totalFileSize = 0;
            DateTime lastWriteTime = DateTime.MinValue;
            string lastFileWritten = "";
            object dateLock = new();

            Parallel.For(0, files.Length,
                   index => {
                       FileInfo fi = new(files[index]);
                       long size = fi.Length;
                       DateTime lastWrite = fi.LastWriteTimeUtc;
                       lock (dateLock)
                       {
                           if (lastWriteTime < lastWrite)
                           {
                               lastWriteTime = lastWrite;
                               lastFileWritten = fi.Name;
                           }
                       }
                       Interlocked.Add(ref totalFileSize, size);
                       fileInfos.Add(fi);
                   });

            results.FileInfoList = fileInfos;
            results.TotalSize = totalFileSize;
            results.LastFileWriteTime = lastWriteTime;
            results.LastWrittenFileName = lastFileWritten;

            return results;
        }
    }
}
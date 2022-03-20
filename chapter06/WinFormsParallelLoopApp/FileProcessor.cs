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

        public static FileData GetInfoForFilesThreadLocal(string[] files)
        {
            var results = new FileData();
            var fileInfos = new List<FileInfo>();
            long totalFileSize = 0;
            DateTime lastWriteTime = DateTime.MinValue;
            string lastFileWritten = "";
            object dateLock = new();

            Parallel.For<long>(0, files.Length, () => 0,
                (index, loop, subtotal) => {
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
                    subtotal += size;
                    fileInfos.Add(fi);
                    return subtotal;
                   },
                (runningTotal) => Interlocked.Add(ref totalFileSize, runningTotal)
            );

            results.FileInfoList = fileInfos;
            results.TotalSize = totalFileSize;
            results.LastFileWriteTime = lastWriteTime;
            results.LastWrittenFileName = lastFileWritten;

            return results;
        }

        public static List<Bitmap> ConvertFilesToBitmaps(List<string> files)
        {
            var result = new List<Bitmap>();

            Parallel.ForEach(files, file =>
            {
                FileInfo fi = new(file);
                string ext = fi.Extension.ToLower();

                if (ext == ".jpg" || ext == "jpeg")
                {
                    result.Add(ConvertJpgToBitmap(file));
                }
            });

            return result;
        }

        public static async Task<List<Bitmap>> ConvertFilesToBitmapsAsync(List<string> files, CancellationTokenSource cts)
        {
            ParallelOptions po = new()
            {
                CancellationToken = cts.Token,
                MaxDegreeOfParallelism = Environment.ProcessorCount == 1 ? 1
                                            : Environment.ProcessorCount - 1
            };

            var result = new List<Bitmap>();

            try
            {
                await Parallel.ForEachAsync(files, po, async (file, _cts) => 
                {
                    FileInfo fi = new(file);
                    string ext = fi.Extension.ToLower();

                    if (ext == ".jpg" || ext == "jpeg")
                    {
                        result.Add(ConvertJpgToBitmap(file));
                        await Task.Delay(2000, _cts);
                    }
                });
            }
            catch (OperationCanceledException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                cts.Dispose();
            }

            return result;
        }

        private static Bitmap ConvertJpgToBitmap(string fileName)
        {
            Bitmap bmp;
            using (Stream bmpStream = File.Open(fileName, FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);
                bmp = new Bitmap(image);
            }
            return bmp;
        }
    }
}
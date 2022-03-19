using System.IO;
using System.IO.Compression;

namespace ACME.Services
{
    public class ZipService : IZipService
    {
        public MemoryStream CreateZipStreamForOneFile(MemoryStream inputFileStream, string inputFileName, bool leaveOpen = false)
        {
            try
            {
                var zipFileStream = new MemoryStream();

                using (var archive = new ZipArchive(zipFileStream, ZipArchiveMode.Create, leaveOpen))
                {

                    var inputFileInBytes = inputFileStream.ToArray();
                    var zipEntry = archive.CreateEntry(inputFileName, CompressionLevel.Fastest);
                    using (var zipStream = zipEntry.Open())
                    {
                        zipStream.Write(inputFileInBytes, 0, inputFileInBytes.Length);
                    }
                }

                zipFileStream.Position = 0;

                return zipFileStream;
            }
            finally
            {
                if (leaveOpen == false)
                {
                    inputFileStream.Dispose();
                }
            }
        }
    }
}
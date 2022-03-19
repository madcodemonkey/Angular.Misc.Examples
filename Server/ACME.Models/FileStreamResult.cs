using System.IO;

namespace ACME.Models
{
    public class FileStreamResult
    {
        public string FileName { get; set; }
        public string MimeType { get; set; }

        public MemoryStream FileData { get; set; }
    }
}
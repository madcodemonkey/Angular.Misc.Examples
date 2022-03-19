using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using ACME.Models;
using CsvHelper;

namespace ACME.Services
{
    public class ToolReportService : IToolReportService
    {
        private readonly IZipService _zipService;

        public ToolReportService(IZipService zipService)
        {
            _zipService = zipService;
        }

        public async Task<FileStreamResult> GetReportAsync(int toolCount)
        {
            var result = new FileStreamResult {
                FileName = "Tool.zip",
                MimeType = "application/octet-stream",
            };

            if (toolCount == 0) return result;

            var tools = CreateToolItemList(toolCount);

            using var csvFileStream = new MemoryStream();

            using (var sw = new StreamWriter(csvFileStream, leaveOpen: true))
            using (var csvWriter = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
               await csvWriter.WriteRecordsAsync(tools);
            }

            csvFileStream.Position = 0;

            result.FileData = _zipService.CreateZipStreamForOneFile(csvFileStream, "Tool.csv", leaveOpen: true);
            result.FileData.Position = 0;

            return result;
        }

        private List<ToolItem> CreateToolItemList(int numberToCreate)
        {
            var result = new List<ToolItem>();

            Random rand = new Random(DateTime.Now.Millisecond);

            for (int i = 1; i <= numberToCreate; i++)
            {
                result.Add(new ToolItem()
                {
                    Id = i,
                    Name = $"Tool-{i}",
                    Cost = rand.Next(1,100) + (rand.Next(1, 100) * 0.01),
                    DateCreated = DateTime.Now.AddDays(rand.Next(200, 3000) * -1)
                });

            }

            return result;
        }

    }

}

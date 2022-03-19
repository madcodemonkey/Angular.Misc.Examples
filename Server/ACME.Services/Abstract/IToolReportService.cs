using System.Threading.Tasks;
using ACME.Models;

namespace ACME.Services
{
    public interface IToolReportService
    {
        Task<FileStreamResult> GetReportAsync(int toolCount);
    }
}
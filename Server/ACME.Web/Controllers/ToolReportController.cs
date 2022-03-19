using ACME.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ACME.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolReportController : ControllerBase
    {
        private readonly IToolReportService _toolReportService;

        public ToolReportController(IToolReportService toolReportService)
        {
            _toolReportService = toolReportService;
        }

        [HttpGet("{numberToCreate}")]
        public async Task<ActionResult> GetToolReport([FromRoute] int numberToCreate)
        {
            var fileResult = await _toolReportService.GetReportAsync(numberToCreate);

            if (fileResult.FileData == null) return new NoContentResult();

            Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

            return File(fileResult.FileData, fileResult.MimeType, fileResult.FileName);
        }
    }
}

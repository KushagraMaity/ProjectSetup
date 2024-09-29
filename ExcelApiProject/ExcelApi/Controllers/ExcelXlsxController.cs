using ExcelApi.LibraryIntegration;
using Microsoft.AspNetCore.Mvc;

namespace ExcelApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ExcelXlsxController : ControllerBase
    {
        private readonly string _contentType;
        private IExcelLib _xlsx;

        public ExcelXlsxController(IExcelLib xlsx)
        {
            _xlsx = xlsx;
            _contentType = _xlsx.contentType;//"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        }

        [HttpGet("CreateExcelFileWithDummy")]
        public IActionResult CreateExcelSheet()
        {
            var result = _xlsx.CreateMultipleExcelSheet();
            return File(result, _contentType, "DemoExcelFile.xlsx");
        }
    }
}

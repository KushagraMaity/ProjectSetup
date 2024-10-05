using ExcelApi.LibraryIntegration;
using ExcelApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExcelApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OpenXmlController : ControllerBase
    {
        private readonly string _contentType;
        private IOpenXmlLib _xlsx;
        private UserDetails _userDetails;

        public OpenXmlController(IOpenXmlLib xlsx,UserDetails userDetails)
        {
            _xlsx = xlsx;
            _contentType = _xlsx.contentType;//"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            _userDetails = userDetails;
        }

        [HttpGet("CreateExcelFileWithDummy")]
        public IActionResult CreateExcelSheet()
        {
            var table = _userDetails.ConvertModelToDataTable(_userDetails.GetEmployeeDummyData());
            var result = _xlsx.CreateExcelSheet(table);
            return File(result, _contentType, "DemoExcelFile.xlsx");
        }
    }
}

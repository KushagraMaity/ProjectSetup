using DocumentFormat.OpenXml.EMMA;
using ExcelApi.Model;
using ExcelLib.OpenXmlUtility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace ExcelApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OpenXmlController : ControllerBase
    {
        private readonly string _contentType;
        private OpenXml _openXml;
        private UserDetails _userDetails;

        public OpenXmlController(OpenXml openXml, UserDetails userDetails)
        {
            _openXml = openXml;
            _contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            _userDetails = userDetails;
        }

        [HttpGet("CreateExcelFile")]
        public IActionResult CreateExcelSheet()
        {
            var table = _userDetails.ConvertModelToDataTable(_userDetails.GetEmployeeDummyData());
            var result = _openXml.CreateExcel(table);
            return File(result, _contentType, "DemoExcelFile.openXml");
        }

        [HttpPost("ReadExcelFile")]
        public IActionResult ReadExcelSheet(IFormFile file)
        {

            FileValidationResp obj = new FileValidationResp(file);
            if (!obj.ValidateFileExcelFile().Status)
            {
                return Ok(obj.Message);
            }

            var result = _openXml.ReadExcel(file.OpenReadStream());
            var a = JsonConvert.SerializeObject(result,Formatting.Indented);
            return Ok(a);
        }

        [HttpPost("ReadExcelAsString")]
        public IActionResult ReadExcelAsString(IFormFile file)
        {

            FileValidationResp obj = new FileValidationResp(file);
            if (!obj.ValidateFileExcelFile().Status)
            {
                return Ok(obj.Message);
            }

            var result = _openXml.ReadExcelAsString(file.OpenReadStream());
            
            return Ok(result);
        }
    }
}

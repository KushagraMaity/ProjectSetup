using ExcelLib.OpenXmlUtility;
using System.Data;

namespace ExcelApi.LibraryIntegration
{
    public interface IOpenXmlLib
    {
        public string contentType { get; }
        byte[] CreateExcelSheet(DataTable dt);
        byte[] CreateMultipleExcelSheet();
    }

    public class OpenXmlLib : IOpenXmlLib
    {
        private OpenXml _openXml; 
        public string contentType => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public OpenXmlLib(OpenXml openXml)
        {
            _openXml = openXml;
        }
        public byte[] CreateExcelSheet(DataTable dt) => _openXml.CreateExcel(dt);
        
        public byte[] CreateMultipleExcelSheet() => _openXml.CreateDummyMultipleExcelSheet();

    }
}

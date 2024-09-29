using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System.Data;
#nullable disable

namespace ExcelLib.ExcelOperation
{
    public sealed class Xlsx : Excel
    {
        public override byte[] CreateDummyExcel() => base.CreateDummyExcel();
        
        public override byte[] CreateDummyMultipleExcelSheet() => base.CreateDummyMultipleExcelSheet();
           
    } 
}

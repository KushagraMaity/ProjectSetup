#nullable disable

using System.Data;

namespace ExcelLib.OpenXmlUtility
{
    public class OpenXml : BaseOpenXmlExcel
    {
        public override byte[] CreateExcel(DataTable table) => base.CreateExcel(table);
        public override byte[] CreateMultipleExcel(DataSet ds) => base.CreateMultipleExcel(ds);

        public override DataSet ReadExcel(Stream stream) => base.ReadExcel(stream);
        public override string ReadExcelAsString(Stream stream) => base.ReadExcelAsString(stream);
    }
}

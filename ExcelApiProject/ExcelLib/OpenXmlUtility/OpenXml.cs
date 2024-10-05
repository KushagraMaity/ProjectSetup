#nullable disable

using System.Data;

namespace ExcelLib.OpenXmlUtility
{
    public class OpenXml : BaseOpenXmlExcel
    {
        public override byte[] CreateDummyExcel() => base.CreateDummyExcel();
        public override byte[] CreateDummyMultipleExcelSheet() => base.CreateDummyMultipleExcelSheet();
        public override byte[] CreateExcel(DataTable table) => base.CreateExcel(table);

    }
}

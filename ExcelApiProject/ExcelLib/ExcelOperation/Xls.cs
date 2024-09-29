#nullable disable

namespace ExcelLib.ExcelOperation
{
    public sealed class Xls : Excel
    {
        public override byte[] CreateDummyExcel() => base.CreateDummyExcel();

        public override byte[] CreateDummyMultipleExcelSheet() => base.CreateDummyMultipleExcelSheet();

    }
}

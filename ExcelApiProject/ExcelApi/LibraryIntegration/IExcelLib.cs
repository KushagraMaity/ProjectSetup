using ExcelLib.ExcelOperation;

namespace ExcelApi.LibraryIntegration
{
    public interface IExcelLib
    {
        public string contentType { get; }
        byte[] CreateExcelSheet();
        byte[] CreateMultipleExcelSheet();
    }

    public class XlsxLib : IExcelLib
    {
        private Xlsx _xlsx; 
        public string contentType => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public XlsxLib(Xlsx xlsx)
        {
            _xlsx = xlsx;
        }
        public byte[] CreateExcelSheet() => _xlsx.CreateDummyExcel();
        
        public byte[] CreateMultipleExcelSheet() => _xlsx.CreateDummyMultipleExcelSheet();

    }
}

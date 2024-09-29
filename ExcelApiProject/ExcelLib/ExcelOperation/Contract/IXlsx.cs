using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Lib_OpenXml
{
    public interface IXlsx
    {
        public string contentType { get; }
        byte[] CreateExcelSheet();
        byte[] CreateMultipleExcelSheet();
    }

    public class Xlsx : BaseOperation, IXlsx
    {
        public string contentType => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public byte[] CreateExcelSheet()=> base.CreateDummyExcel();
        public byte[] CreateMultipleExcelSheet()=> base.CreateDummyExcel();

    }
}

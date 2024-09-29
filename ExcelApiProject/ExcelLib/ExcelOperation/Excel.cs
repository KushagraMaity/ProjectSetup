using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System.Data;

namespace ExcelLib.ExcelOperation
{
    public class Excel
    {
        public virtual byte[] CreateDummyExcel()
        {
            byte[] result;
            try
            {
                Employee emp = new Employee();
                DataTable table = ConvertModelToDataTable(emp.GetEmployeeDummyData());//JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(emp.GetEmployeeDummyData()));

                using (var memory = new MemoryStream())
                {
                    //Create Spread Sheet
                    using (var doc = SpreadsheetDocument.Create(memory, SpreadsheetDocumentType.Workbook))
                    {
                        //----------------------------Create Sheet Part Start--------------------------------------------
                        //Create WorkBook
                        WorkbookPart workbookPart = doc.AddWorkbookPart();
                        workbookPart.Workbook = new Workbook();

                        //Create Worksheet      1.Worksheet contain n*sheet
                        WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                        var sheetData = new SheetData();
                        worksheetPart.Worksheet = new Worksheet(sheetData);

                        //Create Sheets collection
                        Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                        //Create Sheet 1
                        Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };

                        //Adding sheet to Sheet collection
                        sheets.Append(sheet);

                        //----------------------------Create Sheet Part End--------------------------------------------


                        Row headerRow = new Row();

                        List<string> columns = new List<string>();

                        foreach (DataColumn column in table.Columns)
                        {
                            columns.Add(column.ColumnName);

                            Cell cell = new Cell();
                            cell.DataType = CellValues.String;
                            cell.CellValue = new CellValue(column.ColumnName);
                            headerRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(headerRow);

                        foreach (DataRow dsRow in table.Rows)
                        {
                            Row newRow = new Row();
                            foreach (string col in columns)
                            {
                                Cell cell = new Cell();
                                cell.DataType = CellValues.String;
                                cell.CellValue = new CellValue(dsRow[col].ToString());
                                newRow.AppendChild(cell);
                            }

                            sheetData.AppendChild(newRow);
                        }

                        workbookPart.Workbook.Save();
                        memory.Position = 0;
                    }
                    result = memory.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public virtual byte[] CreateDummyMultipleExcelSheet()
        {
            byte[] result;
            try
            {
                Employee emp = new Employee();

                //Data should be nested list form

                DataSet ds = ConvertModelToDataSet(emp.GetEmployeeDummyDataWithMultiList());

                using (var memory = new MemoryStream())
                {
                    //Create Spread Sheet
                    using (var doc = SpreadsheetDocument.Create(memory, SpreadsheetDocumentType.Workbook))
                    {

                        //Create WorkBook
                        WorkbookPart workbookPart = doc.AddWorkbookPart();
                        workbookPart.Workbook = new Workbook();


                        //Create Sheets collection
                        Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                        UInt16 i = 1;
                        foreach (DataTable table in ds.Tables)
                        {

                            //Create Worksheet     
                            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                            var sheetData = new SheetData();
                            worksheetPart.Worksheet = new Worksheet(sheetData);


                            //Create Sheet 1
                            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = i, Name = $"Sheet{i}" };

                            //Adding sheet to Sheet collection
                            sheets.Append(sheet);

                            //Data Insertion Part  --start
                            Row headerRow = new Row();

                            List<string> columns = new List<string>();

                            foreach (DataColumn column in table.Columns)
                            {
                                columns.Add(column.ColumnName);

                                Cell cell = new Cell();
                                cell.DataType = CellValues.String;
                                cell.CellValue = new CellValue(column.ColumnName);
                                headerRow.AppendChild(cell);
                            }

                            sheetData.AppendChild(headerRow);

                            foreach (DataRow dsRow in table.Rows)
                            {
                                Row newRow = new Row();
                                foreach (string col in columns)
                                {
                                    Cell cell = new Cell();
                                    cell.DataType = CellValues.String;
                                    cell.CellValue = new CellValue(dsRow[col].ToString());
                                    newRow.AppendChild(cell);

                                }

                                sheetData.AppendChild(newRow);
                            }
                            //Data Insertion Part  --end

                            i++;
                        }
                        workbookPart.Workbook.Save();
                        memory.Position = 0;
                    }
                    result = memory.ToArray();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public DataTable ConvertModelToDataTable(dynamic model)
        {
            return JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(model));
        }

        public DataSet ConvertModelToDataSet(dynamic model)
        {
            DataSet ds = new DataSet();
            foreach (var modelItem in model)
            {
                ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelItem)));
            }

            return ds;
        }
    }

    internal class Employee
    {
        public string? ID { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public List<Employee> GetEmployeeDummyData()
        {
            return new List<Employee> {
                new Employee { ID = "1001", Name = "ABCD", City = "City1", Country = "USA" },
                new Employee { ID = "1002", Name = "PQRS", City = "City2", Country = "INDIA" },
                new Employee { ID = "1003", Name = "XYZZ", City = "City3", Country = "CHINA" },
                new Employee { ID = "1004", Name = "LMNO", City = "City4", Country = "UK" },
            };
        }

        public List<List<Employee>> GetEmployeeDummyDataWithMultiList()
        {
            List<Employee> employees = new List<Employee> {
                new Employee { ID = "1001", Name = "ABCD", City = "City1", Country = "USA" },
                new Employee { ID = "1002", Name = "PQRS", City = "City2", Country = "INDIA" },
                new Employee { ID = "1003", Name = "XYZZ", City = "City3", Country = "CHINA" },
                new Employee { ID = "1004", Name = "LMNO", City = "City4", Country = "UK" },
            };
            List<Employee> employees1 = new List<Employee> {
                new Employee { ID = "1005", Name = "ABC1", City = "City5", Country = "USA" },
                new Employee { ID = "1006", Name = "PQR2", City = "City6", Country = "INDIA" },
                new Employee { ID = "1007", Name = "XYZ3", City = "City7", Country = "CHINA" },
                new Employee { ID = "1008", Name = "LMN4", City = "City8", Country = "UK" },
            };

            List<List<Employee>> emp = new List<List<Employee>>();
            emp.Add(employees);
            emp.Add(employees1);

            return emp;
        }
    }
}

using ExcelDataReader;
using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.IO;
using System.Linq;

namespace M360.Support
{
    public class ExcelData
    {
        public DataSet worksheets;
        public string testCaseId;

        public void ReadExcelData(string pathName)
        {
            using (var stream = File.Open(pathName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read())
                        {
                        }
                    } while (reader.NextResult());

                    worksheets = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                            FilterRow = rowReader =>
                            {
                                var hasData = false;
                                for (var i = 0; i < rowReader.FieldCount; i++)
                                {
                                    if (rowReader[i] == null || string.IsNullOrEmpty(rowReader[i].ToString()))
                                    {
                                        continue;
                                    }

                                    hasData = true;
                                    break;
                                }

                                return hasData;
                            }

                        }
                    });
                }
            }
        }

        public void ReadCSVData(string pathName)
        {
            using (var stream = File.Open(pathName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                {
                    do
                    {
                        while (reader.Read())
                        {
                        }
                    } while (reader.NextResult());

                    worksheets = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                            FilterRow = rowReader =>
                            {
                                var hasData = false;
                                for (var i = 0; i < rowReader.FieldCount; i++)
                                {
                                    if (rowReader[i] == null || string.IsNullOrEmpty(rowReader[i].ToString()))
                                    {
                                        continue;
                                    }

                                    hasData = true;
                                    break;
                                }

                                return hasData;
                            }

                        }
                    });
                }
            }
        }

        private System.Data.DataTable GetExcelWorkSheet(string workSheetName)
        {
            System.Data.DataTable workSheet = worksheets.Tables[workSheetName];

            if (workSheet == null)
            {
                throw new Exception(string.Format("The worksheet {0} does not exist, has an incorrect name, or does not have any data in the worksheet", workSheetName));
            }

            return workSheet;
        }

        public System.Data.DataTable GetExcelWorkSheet(int workSheetName)
        {
            System.Data.DataTable workSheet = worksheets.Tables[workSheetName];

            if (workSheet == null)
            {
                throw new Exception(string.Format("The worksheet {0} does not exist, has an incorrect name, or does not have any data in the worksheet", workSheetName));
            }

            return workSheet;
        }

        public string GetData(string workSheetName, string testCaseId, string columnName)
        {
            System.Data.DataTable workSheet = GetExcelWorkSheet(workSheetName);

            var rows = from DataRow row in workSheet.Rows
                       select row;


            var testRow = rows.FirstOrDefault(x => x.ItemArray[0].ToString() == testCaseId);
            var columnData = testRow[columnName].ToString();

            if (columnData == null)
            {
                throw new Exception(string.Format("The column {0} does not exist, has an incorrect name", columnName));
            }

            return columnData;
        }

        public string GetAllData(int workSheetName)
        {
            System.Data.DataTable workSheet = GetExcelWorkSheet(workSheetName);

            var rows = from DataRow row in workSheet.Rows
                       select row;
            var textAll = "";

            foreach (var row in rows)
            {
                foreach (var cell in row.ItemArray)
                {
                    textAll += cell.ToString() + ",";
                }
                textAll += ";";
            }
            return textAll;
        }

        public string GetCSVData(int rowNo, string columnName)
        {
            System.Data.DataTable workSheet = GetExcelWorkSheet(0);

            var rows = from DataRow row in workSheet.Rows
                       select row;


            var columnData = rows.ElementAt(rowNo).Table.Rows[0][columnName].ToString();

            if (columnData == null)
            {
                throw new Exception(string.Format("The column {0} does not exist, has an incorrect name", columnName));
            }

            return columnData;
        }

        public void ReplaceTextInExcelFile(string filename, string replace, string replacement)
        {
            object m = Type.Missing;

            // open excel.
            Application app = new Application();

            // open the workbook. 
            Workbook wb = app.Workbooks.Open(
                filename,
                m, false, m, m, m, m, m, m, m, m, m, m, m, m);

            // get the active worksheet. (Replace this if you need to.) 
            Worksheet ws = (Worksheet)wb.ActiveSheet;

            // get the used range. 
            Range r = (Range)ws.UsedRange;

            // call the replace method to replace instances. 
            var searchTerm = r.Find(replace);
            if (searchTerm != null)
            {
                bool success = (bool)r.Replace(
                    replace,
                    replacement,
                    XlLookAt.xlWhole,
                    XlSearchOrder.xlByRows,
                    true, m, m, m);
            }
            // save and close. 
            wb.Save();
            app.Quit();
            app = null;
        }
    }
}

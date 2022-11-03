using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ImportGraphObjectsTest.Engine
{
    class Storage
    {
        public static async Task ReadFileAsync(string path, Action<List<string>> actionOut, int limitLines = 10)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                List<string> outLines = new List<string>();
                string? line;

                while ((line = await reader.ReadLineAsync()) != null)
                {
                    outLines.Add(line);
                    if (outLines.Count >= limitLines)
                    {
                        actionOut(outLines);
                        outLines.Clear();
                    }
                }
                if (outLines.Any())
                    actionOut(outLines);
            }
        }

        public static string GetPathFromSelectedFile(string filter)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog() { Filter = filter };
            var result = openFileDialog.ShowDialog();
            if (result == false) return string.Empty;
            return openFileDialog.FileName;
        }

        //public static List<string> ReadExcel()
        //{
        //    string path = GetPathFromSelectedFile("file Excel (*.xlsx)|*.xlsx|file Excel (*.xls)|*.xls");
        //    if (string.IsNullOrEmpty(path))
        //        return null;

        //    dynamic objWorkExcel = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application", true));
        //    var objWorkBook = objWorkExcel.Workbooks.Open(path);
        //    var objWorkSheet = objWorkBook.Sheets[1];
        //    var typeCellTypeLastCell = Type.GetTypeFromProgID("Excel.XlCellType.xlCellTypeLastCell");
        //    var lastCell = objWorkSheet.Cells.SpecialCells(typeCellTypeLastCell);

        //    int lastRow = (int)lastCell.Row;
        //    List<string> lines = new List<string>();
        //    string line = string.Empty;

        //    for (int i = 1; i < lastRow; i++)
        //    {
        //        for (int j = 0; j < 5; j++)
        //        {
        //            var value = objWorkSheet.Cells[i + 1, j + 1].ToString();
        //            line += $"{value};";
        //        }
        //        lines.Add(line);
        //        line = string.Empty;
        //    }

        //    objWorkBook.Close(false, Type.Missing, Type.Missing);
        //    objWorkExcel.Quit();
        //    GC.Collect();
        //    return lines;
        //}

        public static List<string> ReadExcel()
        {
            string path = GetPathFromSelectedFile("file Excel (*.xlsx)|*.xlsx|file Excel (*.xls)|*.xls");
            if (string.IsNullOrEmpty(path))
                return null;

            Excel.Application objWorkExcel = new Excel.Application();
            Excel.Workbook objWorkBook = objWorkExcel.Workbooks.Open(path);
            Excel.Worksheet objWorkSheet = (Excel.Worksheet)objWorkBook.Sheets[1];
            var lastCell = objWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);

            //int lastColumn = (int)lastCell.Column;
            int lastRow = (int)lastCell.Row;
            List<string> lines = new List<string>();
            string line = string.Empty;

            for (int i = 1; i < lastRow; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var value = objWorkSheet.Cells[i + 1, j + 1].ToString();
                    line += $"{value};";
                }
                lines.Add(line);
                line = string.Empty;
            }

            objWorkBook.Close(false, Type.Missing, Type.Missing);
            objWorkExcel.Quit();
            GC.Collect();
            return lines;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel; //Microsoft Excel object in references->COM tab
using System.Runtime.InteropServices;





namespace FilesLibrary
{
    public class Class1
    {
      public static String SheetRead(String file_path)
      {
			//Create COM Objects. Create a COM object for everything that is referenced
			//String excel_dir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory() , @"\\מעודכן 27-10-21 תפוקות קווים.xls");
			Excel.Application xlApp = new Excel.Application();
			Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(file_path);
			Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
			Excel.Range xlRange = xlWorksheet.UsedRange;

			String file_contents = "";
			int rowCount = xlRange.Rows.Count;
			int colCount = xlRange.Columns.Count;
			//iterate over the rows and columns and print to the console as it appears in the file
			//excel is not zero based!!
			for (int i = 1; i <= rowCount; i++)
			{
				for (int j = 1; j <= colCount; j++)
				{
					//new line
					if (j == 1)	{
						file_contents += "\r\n";
						//Console.Write("\r\n");
					}

					//write the value to the console
					if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null){
						file_contents += "\t";
						//Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
					}

				}
			}
			//cleanup
			GC.Collect();
			GC.WaitForPendingFinalizers();
			//rule of thumb for releasing com objects:
			// never use two dots, all COM objects must be referenced and released individually
			// ex: [somthing].[something].[something] is bad
			//release com objects to fully kill excel process from running in the background
			Marshal.ReleaseComObject(xlRange);
			Marshal.ReleaseComObject(xlWorksheet);
			//close and release
			xlWorkbook.Close();
			Marshal.ReleaseComObject(xlWorkbook);
			//quit and release
			xlApp.Quit();
			Marshal.ReleaseComObject(xlApp);

			return file_contents;
		}
   }
}

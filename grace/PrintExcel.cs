using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grace
{
    internal class PrintExcel
    {

        public void Print(string fileName) {
            // Initialize Excel application
            var excelApp = new Microsoft.Office.Interop.Excel.Application();

            // Make Excel visible (optional)
            excelApp.Visible = true;


            // Open the Excel file you want to print
            Workbook workbook = excelApp.Workbooks.Open(fileName);

            // Get the first worksheet (index 1-based)
            Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

            // Set the page orientation to landscape
            worksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;

            // Set the paper size to legal (8.5" x 14")
            worksheet.PageSetup.PaperSize = XlPaperSize.xlPaperLegal;
            // Fit to page
            worksheet.PageSetup.FitToPagesWide = true;

            // Print the workbook
            workbook.PrintOut();

            // Close the workbook and Excel application
            workbook.Close(false);
            excelApp.Quit();

            // Release COM objects (important to prevent memory leaks)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            // Sleep for 1 second (1000 milliseconds)
            Thread.Sleep(1000);

        }
    }
}

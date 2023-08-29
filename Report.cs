using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grace
{
    class Report
    {

        public void WriteReport()
        {
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Add a new worksheet to the package
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Set the columns' horizontal alignment to Center
                worksheet.Column(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Column(2).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Column(3).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // Set the column names
                worksheet.Cells[1, 1].Value = "col1";
                worksheet.Cells[1, 2].Value = "col2";
                worksheet.Cells[1, 3].Value = "col3";

                // Save the Excel package to a file
                var fileInfo = new FileInfo("output.xlsx");
                package.SaveAs(fileInfo);
            }

            Console.WriteLine("Excel file created successfully.");
        }

    }
}

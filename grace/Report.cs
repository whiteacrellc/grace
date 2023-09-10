using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using System.Windows.Forms;

namespace grace
{
    public class Report
    {
        private Dictionary<string, List<string>> items;
        Dictionary<string, List<Row>> collections;
        private int currentRow = 0;
        private ExcelPackage package;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        Vivian vivian;
        private int endLastBlock = 0;
        private int currentPage = 0;

        public Report(Dictionary<string, List<Row>> collections, Dictionary<string, List<string>> items, Vivian vivian)
        {
            this.collections = collections;
            this.items = items;
            this.vivian = vivian;
            this.package = new ExcelPackage();
        }



        private int writeCollectoion(string collection, List<Row> rows, ExcelWorksheet worksheet)
        {
            int startRow = currentRow;
            endLastBlock = currentRow;
            int rowsWritten = 0;
            foreach (Row row in rows)
            {
                if (row == null || row.Sku == null) continue;
                var collist = items[row.Sku];

                worksheet.Cells[currentRow, 1].Value = row.Brand;
                worksheet.Cells[currentRow, 2].Value = row.Sku;
                worksheet.Cells[currentRow, 3].Value = row.Description;
                worksheet.Cells[currentRow, 4].Value = collection;

                int i = 0;
                foreach (var itemcol in collist)
                {
                    if (itemcol == null) break;
                    if (itemcol.Equals(collection)) continue;
                    worksheet.Cells[currentRow, 5 + i].Value = itemcol;
                    i++;
                }
                worksheet.Cells[currentRow, 10].Value = row.PreviousTotal;
                worksheet.Cells[currentRow, 11].Value = row.Total;
                if (row.PreviousTotal != row.Total)
                {
                    worksheet.Cells[currentRow, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[currentRow, 11].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                }
                currentRow++;
                currentPage++;
                rowsWritten++;

            }
            var borderCellRange = "A" + startRow + ":K" + currentRow;
            worksheet.Cells[borderCellRange].Style.Border.BorderAround(ExcelBorderStyle.Medium);

            return rowsWritten;
        }

        private void WriteHeader(ExcelWorksheet worksheet)
        {
            // Get the current date and format it as desired
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            // Create a header string with the current date
            string headerText = $"Report for {currentDate}";

            // Set the header text in the worksheet
            worksheet.HeaderFooter.OddHeader.CenteredText = headerText;
            worksheet.HeaderFooter.OddHeader.RightAlignedText = currentDate;
            // Make the RightAlignedText red
            



        }
        public void GenerateReport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


            // Sort the keys alphabetically
            var sortedKeys = collections.Keys.OrderBy(key => key).ToList();

            var worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells.Style.Font.Size = 14;

            // Set the row height to 10 for all rows
            worksheet.DefaultRowHeight = 20;

            // Set the column names
            worksheet.Cells["A1"].Value = "Brand";
            worksheet.Cells["B1"].Value = "Item Number";
            worksheet.Cells["C1"].Value = "Description";
            worksheet.Cells["D1:I1"].Merge = true;
            worksheet.Cells["D1:I1"].Value = "Collections";
            worksheet.Cells["J1"].Value = "Previous Count";
            worksheet.Cells["K1"].Value = "Total Count";
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            /*
            for (int columnIndex = 1; columnIndex <= 11; columnIndex++)
            {
                worksheet.Column(columnIndex).Width = 20;

            }
            worksheet.Column(3).Width = 40;
            worksheet.Column(10).Width = 15;
            worksheet.Column(11).Width = 15;
            */

            // Loop through the sorted dictionary and write out the values grouped by key.
            foreach (var key in sortedKeys)
            {
                logger.Info("Processing Collection = " + key);
                vivian.DisplayLogMessage("Processing Collection = " + key);
                currentRow += 2;
                List<Row> rows = collections[key];
                int rowsWritten = writeCollectoion(key, rows, worksheet);

                if (currentPage > 50)
                {
                    worksheet.Row(endLastBlock + 1).PageBreak = true;
                    currentPage = rowsWritten;
                }
            }

            using (var cells = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, 11])
            {
                cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            }

            vivian.DisplayLogMessage("End Processing, you can write the report now");
        }
        public void WriteReport(string fileName)
        {

            // Save the Excel package to a file
            try
            {
                var fileInfo = new FileInfo(fileName);
                if (package != null) package.SaveAs(fileInfo);
            }
            catch (Exception ex)
            {
                // Display an alert dialog with the exception message
                MessageBox.Show($"There was a problem writing the file:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

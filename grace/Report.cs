/*
 * Copyright (c) 2023 White Acre Software LLC
 * All rights reserved.
 *
 * This software is the confidential and proprietary information
 * of White Acre Software LLC. You shall not disclose such
 * Confidential Information and shall use it only in accordance
 * with the terms of the license agreement you entered into with
 * White Acre Software LLC.
 *
 * Year: 2023
 */
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
using System.IO;
using grace.data.models;
using System.Globalization;


namespace grace
{
    public class Report
    {
        private int currentRow;
        public ExcelPackage package { get; }
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private int endLastBlock;
        private int currentPage;

        public Report()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            this.package = new ExcelPackage();
        }



        private int WriteCollection(string collection, List<Grace> rows,
            ExcelWorksheet worksheet)
        {
            int startRow = currentRow;
            endLastBlock = currentRow;
            int rowsWritten = 0;
            var sortedRows =
                rows.OrderBy(p => p.Brand)
                    .ThenBy(p => p.Sku)
                    .ToArray();

            foreach (var row in sortedRows)
            {
                if (row == null || row.Sku == null) continue;

                worksheet.Cells[currentRow, 1].Value = row.Brand;
                worksheet.Cells[currentRow, 2].Value = row.Sku;
                worksheet.Cells[currentRow, 3].Value = row.Description;
                worksheet.Cells[currentRow, 4].Value = collection;

                // Get the collections and fill them in except for the
                // collection we are sorting on which is in the Col1 col1
                // column
                var collections = DataBase.GetCollections(row.ID);
                int i = 0;
                foreach (var c in collections) { 
                    var col = c.Name;
                    // Don't write out the current collection
                    if (col.Equals(collection)) {
                        continue;
                    }
                    switch (i)
                    {
                        case 0:
                            worksheet.Cells[currentRow, 5].Value = col;
                            break;
                        case 1:
                            worksheet.Cells[currentRow, 6].Value = col;
                            break;
                        case 2:
                            worksheet.Cells[currentRow, 7].Value = col;
                            break;
                        case 3:
                            worksheet.Cells[currentRow, 8].Value = col;
                            break;
                        case 4:
                            worksheet.Cells[currentRow, 9].Value = col;
                            break;
                        default:
                            break;
                    }
                    i++;
                }

                worksheet.Cells[currentRow, 10].Value = row.Availability;
                var total = DataBase.GetTotal(row.ID);
                worksheet.Cells[currentRow, 11].Value = total.CurrentTotal;

                // Highlight any negative totals by making the background
                // yellow
                if (total.CurrentTotal < 0)
                {
                    worksheet.Cells[currentRow, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[currentRow, 11].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                }

                // Put border around cells 
                for (int columnIndex = 1; columnIndex < 12; columnIndex++)
                {
                    worksheet.Cells[currentRow, columnIndex].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }
                currentRow++;
                currentPage++;
                rowsWritten++;

            }
            currentRow++;
            currentPage++;
            rowsWritten++;

            return rowsWritten;
        }

        private static void WritePrintHeader(ExcelWorksheet worksheet)
        {
            // Get the current date and format it as desired
            string currentDate = DateTime.Now.ToString("MMMM dd, yyyy");
            // Create a header string with the current date
            string headerText = $"Report for {currentDate}";

            // Set the header text in the worksheet
            worksheet.HeaderFooter.OddHeader.CenteredText = headerText;
            worksheet.HeaderFooter.OddHeader.RightAlignedText = currentDate;
            // Put the page number in the bottom right
            worksheet.HeaderFooter.OddFooter.RightAlignedText = "&P"; // "&P" is a placeholder for the page number

        }

        private void WriteHeader(ExcelWorksheet worksheet, int row)
        {
            // Set the height of the inserted row to 20
            worksheet.Row(row).Height = 60;

            // Add some data to the inserted row (modify as needed)
            worksheet.Cells[row, 1].Value = "Inserted Row Data";
            worksheet.Cells["A" + row].Value = "Brand";
            worksheet.Cells["B" + row].Value = "Item Number";
            worksheet.Cells["C" + row].Value = "Description";
            string spanIndex = "D" + row + ":I" + row;
            worksheet.Cells[spanIndex].Merge = true;
            worksheet.Cells[spanIndex].Value = "Collections";
            worksheet.Cells["J" + row].Value = "Reorder Status";
            worksheet.Cells["J" + row].Style.HorizontalAlignment.Equals(HorizontalAlignment.Center);
            worksheet.Cells["J" + row].Style.WrapText = true;
            worksheet.Cells["K" + row].Value = "Total";

            // Set the font size to 14 and make the text bold for the inserted row
            worksheet.Cells[row, 1, row, 10].Style.Font.Size = 16;
            worksheet.Cells[row, 11, row, 11].Style.Font.Size = 14;
            worksheet.Cells[row, 1, row, 11].Style.Font.Bold = true;
            worksheet.Cells[row, 11].Style.HorizontalAlignment.Equals(HorizontalAlignment.Center);
            worksheet.Cells[row, 11].Style.WrapText = true;

            currentRow++;
            currentPage++;

        }


        private void InsertHeader(ExcelWorksheet worksheet, int rowIndexToInsert)
        {
            worksheet.InsertRow(rowIndexToInsert, 1);

            // Set the height of the inserted row to 20
            WriteHeader(worksheet, rowIndexToInsert);

        }
        public void GenerateReport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


            // Sort the keys alphabetically
            var sortedKeys = DataBase.OrderedCollectionNames();

            var worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells.Style.Font.Size = 14;

            // Set the row height to 10 for all rows
            worksheet.DefaultRowHeight = Globals.GetInstance().RowHeight;

            currentRow = 1;
            currentPage = 1;
            WriteHeader(worksheet, 1);

            for (int columnIndex = 1; columnIndex < 12; columnIndex++)
            {
                worksheet.Column(columnIndex).Width = 20;

            }
            worksheet.Column(1).Width = 25;
            worksheet.Column(3).Width = 50;
            worksheet.Column(10).Width = 15;
            worksheet.Column(11).Width = 15;

            WritePrintHeader(worksheet);

            // Loop through the sorted dictionary and write out the values grouped by key.
            foreach (var group in sortedKeys)
            {
                var key = group.Key;
                var groupRows = group.Value;
                int rowsWritten = WriteCollection(key, groupRows, worksheet);

                var rowsPerPage = Globals.GetInstance().RowsPerPage;
                if (currentPage > rowsPerPage)
                {
                    worksheet.InsertRow(endLastBlock, 1);
                    //currentRow++;
                    worksheet.Row(endLastBlock).PageBreak = true;
                    currentPage = rowsWritten;
                    InsertHeader(worksheet, endLastBlock + 1);
                }
                worksheet.InsertRow(currentRow, 2);
                currentRow += 2;
                currentPage += 2;

            }

            using (var cells = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, 11])
            {
                cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }
        }
        public void WriteReport(string fileName)
        {

            // Save the Excel package to a file
            try
            {
                var fileInfo = new FileInfo(fileName);

                if (package != null)
                {
                    var worksheet = package.Workbook.Worksheets[0];


                    // Set the worksheet to portrait orientation
                    worksheet.PrinterSettings.Orientation = eOrientation.Landscape;

                    // Set the worksheet to legal paper size
                    worksheet.PrinterSettings.PaperSize = ePaperSize.Legal;

                    // Fit all columns to the page
                    worksheet.PrinterSettings.FitToPage = true;
                    worksheet.PrinterSettings.FitToWidth = 1; // 1 page wide
                    worksheet.PrinterSettings.FitToHeight = 0; // Auto height
                    worksheet.PrinterSettings.HorizontalCentered = true;
                    worksheet.PrinterSettings.LeftMargin = 0;
                    worksheet.PrinterSettings.RightMargin = 0;

                    package.SaveAs(fileInfo);
                }
            }
            catch (Exception ex)
            {
                // Display an alert dialog with the exception message
                MessageBox.Show($"There was a problem writing the file:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

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
using NLog;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;
using System.Globalization;
using System.IO;


namespace grace
{
    public class InventoryReport
    {

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private DataGridView dataGridView;
        private int numPageRows = 0;
        private int currentRow = 0;
        private int currentPage = 0;
        private System.Data.DataTable dataTable;

        public InventoryReport(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
            this.numPageRows = 30;
            this.dataTable = DataGridLoader.GetData();
        }

        private void WriteHeader(ExcelWorksheet worksheet, int row)
        {
            // Dictionary to map DbContext column names to desired DataGridView column names
            Dictionary<string, string> columnMappings = new()
            {
                {"Total", "Current Inventory"},
                {"Col1", "Collection 1"},
                {"Col2", "Collection 2"},
                {"Col3", "Collection 3"},
                {"Col4", "Collection 4"},
                {"Col5", "Collection 5"},
                {"Col6", "Collection 6"},
                {"Availability", "Reorder Status" },
                {"Sku", "Item #" },
                // Add more mappings as needed
            };

            int numCols = dataTable.Columns.Count;
            worksheet.Cells[row, 1, row, numCols + 1].Style.Font.Size = 16;
            worksheet.Cells[row, 1, row, numCols + 1].Style.Font.Bold = true;

            // Add the headers
            for (int col = 0; col < numCols; col++)
            {
                worksheet.Cells[row, col + 1].Value = dataTable.Columns[col].ColumnName;
                if (columnMappings.TryGetValue(dataTable.Columns[col].ColumnName, out string? value))
                {
                    // Set the HeaderText to the desired name
                    worksheet.Cells[row, col + 1].Value = value;
                }
            }
        }

        public void WriteReport(string filePath)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                var fileInfo = new FileInfo(filePath);

                using ExcelPackage package = new();
                // Add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");

                int numCols = dataGridView.Columns.Count;
                worksheet.Cells.Style.Font.Size = 14;

                // Set the row height to 10 for all rows
                // worksheet.DefaultRowHeight = Globals.GetInstance().RowHeight;

                currentRow = 1;
                currentPage = 1;
                WriteHeader(worksheet, 1);

                for (int columnIndex = 1; columnIndex < dataTable.Columns.Count + 1; columnIndex++)
                {
                    worksheet.Column(columnIndex).Width = 20;
                    worksheet.Column(columnIndex).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                }

                /*
                worksheet.Column(1).Width = 25;
                worksheet.Column(3).Width = 50;
                worksheet.Column(10).Width = 15;
                worksheet.Column(11).Width = 15;
                */

                WritePrintHeader(worksheet);




                // Add the data rows
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (currentPage > numPageRows)
                    {
                        currentRow += 2;
                        worksheet.InsertRow(currentRow++, 1);
                        worksheet.Row(currentRow++).PageBreak = true;
                        WriteHeader(worksheet, currentRow);
                        currentPage = 0;
                    }


                    for (int col = 0; col < dataTable.Columns.Count; col++)
                    {
                        var item = dataRow[col];
                        if (col == 13)
                        {
                            DateTime dateTime = (DateTime)item;

                            string formattedDate = dateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                            worksheet.Cells[currentRow + 1, col + 1].Value = formattedDate;
                        }
                        else
                        {
                            worksheet.Cells[currentRow + 1, col + 1].Value = item;
                        }
                    }
                    currentRow++;
                    currentPage++;

                }

                // Set column 5 to text format
                worksheet.Column(5).Style.Numberformat.Format = "@";
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Save the package to the specified file
                package.SaveAs(fileInfo);
            }
            catch (Exception ex)
            {
                // Display an alert dialog with the exception message
                MessageBox.Show($"There was a problem writing the file:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            // Put the page number in the botton right
            worksheet.HeaderFooter.OddFooter.RightAlignedText = "&P"; // "&P" is a placeholder for the page number

        }

    }
}

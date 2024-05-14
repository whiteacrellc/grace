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


namespace grace
{
    public class InventoryReport
    {
 
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private DataGridView dataGridView;


        public InventoryReport(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
        }

        public void writeReport(string filePath)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                var fileInfo = new FileInfo(filePath);

                using (ExcelPackage package = new ExcelPackage())
                {
                    // Add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");

                    int numCols = dataGridView.Columns.Count;

                    worksheet.Cells[1, 1, 1, numCols + 1].Style.Font.Size = 16;
                    worksheet.Cells[1, 1, 1, numCols + 1].Style.Font.Bold = true;

                    // Add the headers
                    for (int col = 0; col < dataGridView.Columns.Count; col++)
                    {
                        worksheet.Cells[1, col + 1].Value = dataGridView.Columns[col].HeaderText;
                    }

                    // Add the data rows
                    for (int row = 0; row < dataGridView.Rows.Count; row++)
                    {
                        for (int col = 0; col < dataGridView.Columns.Count; col++)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = dataGridView.Rows[row].Cells[col].Value;
                        }
                    }

                    // Set column 5 to text format
                    worksheet.Column(5).Style.Numberformat.Format = "@";
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Save the package to the specified file
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

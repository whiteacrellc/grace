/*
 * Copyright (c) 2023 White Acre Software LLC
 * All rights reserved.
 *
 * This software is the confidential and proprietary information
 * of White Acre Software LLC. You shall not disclose such
 * * Confidential Information and shall use it only in accordance
 * with the terms of the license agreement you entered into with
 * White Acre Software LLC.
 *
 * Year: 2025
 */
using grace.data;
using grace.data.models;
using NLog;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;
using System.IO;


namespace grace
{
    public class ArrangementReport
    {
        private int currentRow;
        private int currentPage;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private const int MAX_ROWS_PER_PAGE = 30;
        private const int MAX_COLS_PER_PAGE = 8; // 1 for arrangement name + 7 for collections

        public ExcelPackage package { get; }

        public ArrangementReport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            this.package = new ExcelPackage();
        }

        private static void WritePrintHeader(ExcelWorksheet worksheet)
        {
            // Get the current date and format it as desired
            string currentDate = DateTime.Now.ToString("MMMM dd, yyyy");
            // Create a header string with the current date
            string headerText = $"Arrangement Report for {currentDate}";

            // Set the header text in the worksheet
            worksheet.HeaderFooter.OddHeader.CenteredText = headerText;
            worksheet.HeaderFooter.OddHeader.RightAlignedText = currentDate;
            // Put the page number in the bottom right
            worksheet.HeaderFooter.OddFooter.RightAlignedText = "&P"; // "&P" is a placeholder for the page number
        }

        private void WriteHeader(ExcelWorksheet worksheet, int row, List<string> collectionNames, int startColIndex, int endColIndex)
        {
            // Set the height of the header row
            worksheet.Row(row).Height = 40;

            // First column is always "Arrangement Name"
            worksheet.Cells[row, 1].Value = "Arrangement Name";
            worksheet.Cells[row, 1].Style.Font.Size = 14;
            worksheet.Cells[row, 1].Style.Font.Bold = true;
            worksheet.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            // Add collection names as column headers (limited by page width)
            int colOffset = 2;
            for (int i = startColIndex; i < endColIndex && i < collectionNames.Count; i++)
            {
                worksheet.Cells[row, colOffset].Value = collectionNames[i];
                worksheet.Cells[row, colOffset].Style.Font.Size = 14;
                worksheet.Cells[row, colOffset].Style.Font.Bold = true;
                worksheet.Cells[row, colOffset].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[row, colOffset].Style.WrapText = true;
                colOffset++;
            }

            currentRow++;
            currentPage++;
        }

        private Dictionary<string, Dictionary<string, int?>> GetArrangementData()
        {
            using GraceDbContext dbContext = new();

            // Dictionary: Arrangement Name -> (Collection Name -> Total)
            Dictionary<string, Dictionary<string, int?>> arrangementData = new();

            // Get all non-deleted arrangements with their latest totals
            var arrangements = dbContext.Arrangement
                .Where(a => !a.IsDeleted)
                .OrderBy(a => a.Name)
                .ToList();

            foreach (var arrangement in arrangements)
            {
                if (!arrangementData.ContainsKey(arrangement.Name))
                {
                    arrangementData[arrangement.Name] = new Dictionary<string, int?>();
                }

                // Get the latest total for this arrangement in its collection
                var latestTotal = dbContext.ArrangementTotals
                    .Where(at => at.ArrangementId == arrangement.ID)
                    .OrderByDescending(at => at.LastUpdated)
                    .FirstOrDefault();

                if (latestTotal != null)
                {
                    arrangementData[arrangement.Name][arrangement.CollectionName] = latestTotal.CurrentTotal;
                }
                else
                {
                    arrangementData[arrangement.Name][arrangement.CollectionName] = null;
                }
            }

            return arrangementData;
        }

        private List<string> GetDistinctCollectionNames()
        {
            using GraceDbContext dbContext = new();

            // Get distinct collection names from Arrangement table where IsDeleted = false
            var collectionNames = dbContext.Arrangement
                .Where(a => !a.IsDeleted)
                .Select(a => a.CollectionName)
                .Distinct()
                .OrderBy(name => name)
                .ToList();

            return collectionNames;
        }

        public void GenerateReport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Get all data
            var arrangementData = GetArrangementData();
            var collectionNames = GetDistinctCollectionNames();

            if (arrangementData.Count == 0)
            {
                logger.Warn("No arrangement data found to generate report");
                return;
            }

            // Calculate how many pages we need based on columns
            int totalCollections = collectionNames.Count;
            int collectionsPerPage = MAX_COLS_PER_PAGE - 1; // Minus 1 for the arrangement name column
            int numPages = (int)Math.Ceiling((double)totalCollections / collectionsPerPage);

            // Create a worksheet for each page if we have more collections than fit on one page
            for (int pageIndex = 0; pageIndex < numPages; pageIndex++)
            {
                int startColIndex = pageIndex * collectionsPerPage;
                int endColIndex = Math.Min(startColIndex + collectionsPerPage, totalCollections);

                string worksheetName = numPages > 1 ? $"Report {pageIndex + 1}" : "Report";
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetName);
                worksheet.Cells.Style.Font.Size = 12;

                // Set the default row height
                worksheet.DefaultRowHeight = 20;

                currentRow = 1;
                currentPage = 1;

                // Write header
                WriteHeader(worksheet, currentRow, collectionNames, startColIndex, endColIndex);

                // Set column widths
                worksheet.Column(1).Width = 30; // Arrangement name column
                for (int col = 2; col < MAX_COLS_PER_PAGE + 1; col++)
                {
                    worksheet.Column(col).Width = 15;
                }

                WritePrintHeader(worksheet);

                // Write data rows
                foreach (var arrangementEntry in arrangementData.OrderBy(a => a.Key))
                {
                    string arrangementName = arrangementEntry.Key;
                    var collections = arrangementEntry.Value;

                    // Check if we need a page break
                    if (currentPage > MAX_ROWS_PER_PAGE)
                    {
                        worksheet.Row(currentRow).PageBreak = true;
                        currentRow++;
                        WriteHeader(worksheet, currentRow, collectionNames, startColIndex, endColIndex);
                        currentPage = 1;
                    }

                    // Write arrangement name in first column
                    worksheet.Cells[currentRow, 1].Value = arrangementName;
                    worksheet.Cells[currentRow, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    // Write totals for each collection in this page
                    int colOffset = 2;
                    for (int i = startColIndex; i < endColIndex && i < collectionNames.Count; i++)
                    {
                        string collectionName = collectionNames[i];

                        if (collections.ContainsKey(collectionName) && collections[collectionName].HasValue)
                        {
                            worksheet.Cells[currentRow, colOffset].Value = collections[collectionName].Value;
                        }
                        else
                        {
                            // Leave cell empty if no total available
                            worksheet.Cells[currentRow, colOffset].Value = "";
                        }

                        worksheet.Cells[currentRow, colOffset].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        worksheet.Cells[currentRow, colOffset].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        colOffset++;
                    }

                    currentRow++;
                    currentPage++;
                }

                // Center align all cells
                using var cells = worksheet.Cells[1, 1, currentRow - 1, endColIndex - startColIndex + 1];
                cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }
        }

        public void WriteReport(string fileName)
        {
            // Save the Excel package to a file
            try
            {
                var fileInfo = new FileInfo(fileName);

                if (package != null && package.Workbook.Worksheets.Count > 0)
                {
                    // Set printer settings for all worksheets
                    foreach (var worksheet in package.Workbook.Worksheets)
                    {
                        // Set the worksheet to landscape orientation
                        worksheet.PrinterSettings.Orientation = eOrientation.Landscape;

                        // Set the worksheet to letter paper size
                        worksheet.PrinterSettings.PaperSize = ePaperSize.Letter;

                        // Fit all columns to the page
                        worksheet.PrinterSettings.FitToPage = true;
                        worksheet.PrinterSettings.FitToWidth = 1; // 1 page wide
                        worksheet.PrinterSettings.FitToHeight = 0; // Auto height
                        worksheet.PrinterSettings.HorizontalCentered = true;
                        worksheet.PrinterSettings.LeftMargin = 0.25m;
                        worksheet.PrinterSettings.RightMargin = 0.25m;
                    }

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

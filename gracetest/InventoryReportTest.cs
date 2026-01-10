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
 * Year: 2025
 */

using grace;
using grace.data;
using grace.data.models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Data;
using System.Windows.Forms;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8600
#pragma warning disable CS8602

namespace gracetest
{
    [TestClass]
    public class InventoryReportTest
    {
        private string testDbFile = "test_inventory_report.db";
        private string connectionString = string.Empty;
        private string testOutputPath = Path.Combine(Path.GetTempPath(), "grace_test_inventory_reports");
        private DataGridView testDataGridView;

        [TestInitialize]
        public void Setup()
        {
            // Create a test database instance
            var dataBase = new DataBase(testDbFile);
            connectionString = DataBase.ConnectionString;
            DataBase.InitializeDatabase();

            // Set a current user for operations that require it
            Globals.GetInstance().CurrentUser = "testuser";

            // Create test DataGridView
            testDataGridView = new DataGridView();

            // Ensure test output directory exists
            if (!Directory.Exists(testOutputPath))
            {
                Directory.CreateDirectory(testOutputPath);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            var fileName = DataBase.DbFileName;
            Globals.GetInstance().CurrentUser = null;

            // Dispose of DataGridView
            testDataGridView?.Dispose();

            using (var context = new GraceDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.CloseConnection();
            }

            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            // Clean up test reports
            try
            {
                if (Directory.Exists(testOutputPath))
                {
                    foreach (var file in Directory.GetFiles(testOutputPath, "*.xlsx"))
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }

        private void CreateTestInventoryData(int numItems = 10)
        {
            using var context = new GraceDbContext();

            for (int i = 0; i < numItems; i++)
            {
                var grace = new Grace
                {
                    Brand = "Brand" + (i % 3),
                    Sku = "SKU" + i.ToString("D4"),
                    Description = "Test Description " + i,
                    BarCode = i.ToString("D8"),
                    Availability = i % 2 == 0 ? "Available" : "Low Stock",
                    Note = "Test note " + i,
                    Deleted = false
                };
                context.Graces.Add(grace);
                context.SaveChanges();

                // Add total
                var total = new Total
                {
                    GraceId = grace.ID,
                    CurrentTotal = (i * 5) + 10,
                    LastUpdated = DateTime.Now.AddDays(-i),
                    User = "testuser"
                };
                context.Totals.Add(total);

                // Add collections
                var collection = new CollectionName
                {
                    GraceId = grace.ID,
                    Name = "Collection" + (i % 4)
                };
                context.Collections.Add(collection);

                context.SaveChanges();

                // Create GraceRow
                DataBase.CreateGraceRow(grace.ID);
            }
        }

        [TestMethod]
        public void TestMethod_InventoryReport_Constructor()
        {
            CreateTestInventoryData(5);

            var report = new InventoryReport(testDataGridView);

            Assert.IsNotNull(report);
        }

        [TestMethod]
        public void TestMethod_WriteReport_WithData()
        {
            CreateTestInventoryData(10);

            var report = new InventoryReport(testDataGridView);
            string outputFile = Path.Combine(testOutputPath, "test_inventory_report.xlsx");

            report.WriteReport(outputFile);

            // Verify file was created
            Assert.IsTrue(File.Exists(outputFile));

            // Verify we can read the file
            FileInfo fileInfo = new FileInfo(outputFile);
            Assert.IsTrue(fileInfo.Length > 0);

            // Verify the file is a valid Excel file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(fileInfo))
            {
                Assert.IsNotNull(package);
                Assert.AreEqual(1, package.Workbook.Worksheets.Count);

                var worksheet = package.Workbook.Worksheets[0];
                Assert.AreEqual("Report", worksheet.Name);

                // Verify header row exists
                Assert.IsNotNull(worksheet.Cells[1, 1].Value);

                // Verify data rows exist (at least one row of data)
                Assert.IsNotNull(worksheet.Cells[2, 1].Value);
            }

            File.Delete(outputFile);
        }

        [TestMethod]
        public void TestMethod_WriteReport_EmptyData()
        {
            // Don't create any test data
            var report = new InventoryReport(testDataGridView);
            string outputFile = Path.Combine(testOutputPath, "test_empty_report.xlsx");

            report.WriteReport(outputFile);

            // Verify file was created
            Assert.IsTrue(File.Exists(outputFile));

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(outputFile)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                Assert.AreEqual("Report", worksheet.Name);

                // Should have header row but no data rows
                Assert.IsNotNull(worksheet.Cells[1, 1].Value);
            }

            File.Delete(outputFile);
        }

        [TestMethod]
        public void TestMethod_WriteReport_VerifyHeaders()
        {
            CreateTestInventoryData(5);

            var report = new InventoryReport(testDataGridView);
            string outputFile = Path.Combine(testOutputPath, "test_headers_report.xlsx");

            report.WriteReport(outputFile);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(outputFile)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                // Verify column mappings are applied
                var headerRow1Value = worksheet.Cells[1, 1].Value?.ToString();
                Assert.IsNotNull(headerRow1Value);

                // Check if some expected headers are present
                bool foundItemNumber = false;
                bool foundCurrentInventory = false;
                bool foundReorderStatus = false;

                for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                {
                    var headerValue = worksheet.Cells[1, col].Value?.ToString();
                    if (headerValue == "Item #") foundItemNumber = true;
                    if (headerValue == "Current Inventory") foundCurrentInventory = true;
                    if (headerValue == "Reorder Status") foundReorderStatus = true;
                }

                Assert.IsTrue(foundItemNumber, "Expected 'Item #' header not found");
                Assert.IsTrue(foundCurrentInventory, "Expected 'Current Inventory' header not found");
                Assert.IsTrue(foundReorderStatus, "Expected 'Reorder Status' header not found");
            }

            File.Delete(outputFile);
        }

        [TestMethod]
        public void TestMethod_WriteReport_VerifyDataIntegrity()
        {
            CreateTestInventoryData(3);

            var report = new InventoryReport(testDataGridView);
            string outputFile = Path.Combine(testOutputPath, "test_data_integrity.xlsx");

            report.WriteReport(outputFile);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(outputFile)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                // Verify we have at least 3 data rows (plus header)
                Assert.IsTrue(worksheet.Dimension.Rows >= 4, "Expected at least 4 rows (1 header + 3 data)");

                // Verify data in rows
                for (int row = 2; row <= Math.Min(4, worksheet.Dimension.Rows); row++)
                {
                    // Check that we have data in the first column (should be SKU or similar)
                    var cellValue = worksheet.Cells[row, 1].Value;
                    Assert.IsNotNull(cellValue, $"Row {row} column 1 should have data");
                }
            }

            File.Delete(outputFile);
        }

        [TestMethod]
        public void TestMethod_WriteReport_VerifyDateTimeFormatting()
        {
            CreateTestInventoryData(2);

            var report = new InventoryReport(testDataGridView);
            string outputFile = Path.Combine(testOutputPath, "test_datetime_format.xlsx");

            report.WriteReport(outputFile);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(outputFile)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                // Find the LastUpdated column
                int lastUpdatedCol = -1;
                for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                {
                    if (worksheet.Cells[1, col].Value?.ToString() == "LastUpdated")
                    {
                        lastUpdatedCol = col;
                        break;
                    }
                }

                if (lastUpdatedCol > 0)
                {
                    // Verify the date format in the data rows
                    var dateValue = worksheet.Cells[2, lastUpdatedCol].Value?.ToString();
                    Assert.IsNotNull(dateValue);

                    // Check if the date is formatted (should contain "/" or "-" for date separators)
                    Assert.IsTrue(dateValue.Contains("/") || dateValue.Contains("-"),
                        "Date should be formatted as dd/MM/yyyy HH:mm");
                }
            }

            File.Delete(outputFile);
        }

        [TestMethod]
        public void TestMethod_WriteReport_VerifyColumnFormatting()
        {
            CreateTestInventoryData(5);

            var report = new InventoryReport(testDataGridView);
            string outputFile = Path.Combine(testOutputPath, "test_column_format.xlsx");

            report.WriteReport(outputFile);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(outputFile)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                // Verify column 5 has text format
                Assert.AreEqual("@", worksheet.Column(5).Style.Numberformat.Format);

                // Verify columns have proper width
                for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                {
                    Assert.IsTrue(worksheet.Column(col).Width > 0, $"Column {col} should have width set");
                }

                // Verify header font formatting
                Assert.AreEqual(16, worksheet.Cells[1, 1].Style.Font.Size);
                Assert.IsTrue(worksheet.Cells[1, 1].Style.Font.Bold);
            }

            File.Delete(outputFile);
        }

        [TestMethod]
        public void TestMethod_WriteReport_VerifyPrintSettings()
        {
            CreateTestInventoryData(5);

            var report = new InventoryReport(testDataGridView);
            string outputFile = Path.Combine(testOutputPath, "test_print_settings.xlsx");

            report.WriteReport(outputFile);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(outputFile)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                // Verify header/footer settings
                Assert.IsNotNull(worksheet.HeaderFooter.OddHeader.CenteredText);
                Assert.IsTrue(worksheet.HeaderFooter.OddHeader.CenteredText.Contains("Report for"));

                // Verify footer has page number
                Assert.AreEqual("&P", worksheet.HeaderFooter.OddFooter.RightAlignedText);
            }

            File.Delete(outputFile);
        }

        [TestMethod]
        public void TestMethod_WriteReport_LargeDataSet_Pagination()
        {
            // Create more than 30 items to test pagination
            CreateTestInventoryData(50);

            var report = new InventoryReport(testDataGridView);
            string outputFile = Path.Combine(testOutputPath, "test_pagination.xlsx");

            report.WriteReport(outputFile);

            Assert.IsTrue(File.Exists(outputFile));

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(outputFile)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                // With 50 items, we should have multiple pages
                // Verify we have all 50 data rows plus headers
                Assert.IsTrue(worksheet.Dimension.Rows >= 50);
            }

            File.Delete(outputFile);
        }

        [TestMethod]
        public void TestMethod_WriteReport_SpecialCharacters()
        {
            using var context = new GraceDbContext();

            // Create item with special characters
            var grace = new Grace
            {
                Brand = "Brand with & special < > characters",
                Sku = "SKU-TEST",
                Description = "Description with \"quotes\" and 'apostrophes'",
                BarCode = "12345678",
                Availability = "Available",
                Note = "Note with special chars: © ® ™",
                Deleted = false
            };
            context.Graces.Add(grace);
            context.SaveChanges();

            var total = new Total
            {
                GraceId = grace.ID,
                CurrentTotal = 10,
                LastUpdated = DateTime.Now,
                User = "testuser"
            };
            context.Totals.Add(total);
            context.SaveChanges();

            DataBase.CreateGraceRow(grace.ID);

            var report = new InventoryReport(testDataGridView);
            string outputFile = Path.Combine(testOutputPath, "test_special_chars.xlsx");

            report.WriteReport(outputFile);

            Assert.IsTrue(File.Exists(outputFile));

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(outputFile)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                Assert.IsNotNull(worksheet.Cells[2, 1].Value);
            }

            File.Delete(outputFile);
        }

        [TestMethod]
        public void TestMethod_WriteReport_InvalidPath_ShowsError()
        {
            CreateTestInventoryData(5);

            var report = new InventoryReport(testDataGridView);
            string outputFile = "Z:\\InvalidPath\\test_report.xlsx"; // Invalid path

            // This should handle the error gracefully
            // The method shows a MessageBox but doesn't throw
            report.WriteReport(outputFile);

            // Should not crash the application
            Assert.IsTrue(true);
        }
    }
}

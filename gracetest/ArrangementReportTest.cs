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
using grace;
using grace.data;
using grace.data.models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Text;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8600
#pragma warning disable CS8602

namespace gracetest
{
    [TestClass]
    public class ArrangementReportTest
    {
        private string testDbFile = "test_arrangement_report.db";
        private string connectionString = string.Empty;
        private string testOutputPath = Path.Combine(Path.GetTempPath(), "grace_test_reports");

        [TestInitialize]
        public void Setup()
        {
            // Create a test database instance
            var dataBase = new DataBase(testDbFile);
            connectionString = DataBase.ConnectionString;
            DataBase.InitializeDatabase();

            // Set a current user for operations that require it
            Globals.GetInstance().CurrentUser = "testuser";

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

            // Clean up test reports (optional - comment out to inspect generated files)
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

        private void CreateSyntheticArrangementData(int numArrangements, int numCollections)
        {
            using var context = new GraceDbContext();

            List<string> collectionNames = new List<string>();
            for (int c = 0; c < numCollections; c++)
            {
                collectionNames.Add($"Collection{c:D2}");
            }

            // Create arrangements across all collections
            for (int a = 0; a < numArrangements; a++)
            {
                string arrangementName = $"Arrangement{a:D3}";

                foreach (var collectionName in collectionNames)
                {
                    var arrangement = new Arrangement
                    {
                        Name = arrangementName,
                        CollectionName = collectionName,
                        IsDeleted = false
                    };
                    context.Arrangement.Add(arrangement);
                    context.SaveChanges();

                    // Add a total for this arrangement in this collection
                    var arrangementTotal = new ArrangementTotal
                    {
                        ArrangementId = arrangement.ID,
                        CurrentTotal = (a + 1) * (collectionNames.IndexOf(collectionName) + 1),
                        LastUpdated = DateTime.Now.AddDays(-numArrangements + a),
                        User = "testuser"
                    };
                    context.ArrangementTotals.Add(arrangementTotal);
                }
            }

            context.SaveChanges();
        }

        [TestMethod]
        public void TestMethod_GenerateReport_WithSyntheticData()
        {
            // Create test data: 5 arrangements, 3 collections
            CreateSyntheticArrangementData(5, 3);

            var report = new ArrangementReport();
            report.GenerateReport();

            Assert.IsNotNull(report.package);
            Assert.AreEqual(1, report.package.Workbook.Worksheets.Count);

            var worksheet = report.package.Workbook.Worksheets[0];
            Assert.IsNotNull(worksheet);
            Assert.AreEqual("Report", worksheet.Name);

            // Verify header row
            Assert.AreEqual("Arrangement Name", worksheet.Cells[1, 1].Value);
            Assert.AreEqual("Collection00", worksheet.Cells[1, 2].Value);
            Assert.AreEqual("Collection01", worksheet.Cells[1, 3].Value);
            Assert.AreEqual("Collection02", worksheet.Cells[1, 4].Value);

            // Verify data rows (5 arrangements + 1 header = 6 rows)
            Assert.AreEqual("Arrangement000", worksheet.Cells[2, 1].Value);
            Assert.AreEqual("Arrangement001", worksheet.Cells[3, 1].Value);
            Assert.AreEqual("Arrangement002", worksheet.Cells[4, 1].Value);
            Assert.AreEqual("Arrangement003", worksheet.Cells[5, 1].Value);
            Assert.AreEqual("Arrangement004", worksheet.Cells[6, 1].Value);

            // Verify some totals
            Assert.AreEqual(1, worksheet.Cells[2, 2].Value); // Arrangement000, Collection00: (0+1)*(0+1) = 1
            Assert.AreEqual(2, worksheet.Cells[2, 3].Value); // Arrangement000, Collection01: (0+1)*(1+1) = 2
            Assert.AreEqual(3, worksheet.Cells[2, 4].Value); // Arrangement000, Collection02: (0+1)*(2+1) = 3
        }

        [TestMethod]
        public void TestMethod_GenerateReport_WithPagination()
        {
            // Create test data with many collections to trigger pagination
            CreateSyntheticArrangementData(3, 15); // 15 collections will span 3 pages (7 per page + 1 for name column)

            var report = new ArrangementReport();
            report.GenerateReport();

            Assert.IsNotNull(report.package);
            // With 15 collections and max 7 per page, we should have 3 worksheets
            Assert.AreEqual(3, report.package.Workbook.Worksheets.Count);

            // Verify worksheet names
            Assert.AreEqual("Report 1", report.package.Workbook.Worksheets[0].Name);
            Assert.AreEqual("Report 2", report.package.Workbook.Worksheets[1].Name);
            Assert.AreEqual("Report 3", report.package.Workbook.Worksheets[2].Name);

            // Verify first page has collections 0-6
            var ws1 = report.package.Workbook.Worksheets[0];
            Assert.AreEqual("Collection00", ws1.Cells[1, 2].Value);
            Assert.AreEqual("Collection06", ws1.Cells[1, 8].Value);

            // Verify second page has collections 7-13
            var ws2 = report.package.Workbook.Worksheets[1];
            Assert.AreEqual("Collection07", ws2.Cells[1, 2].Value);
            Assert.AreEqual("Collection13", ws2.Cells[1, 8].Value);

            // Verify third page has collections 14
            var ws3 = report.package.Workbook.Worksheets[2];
            Assert.AreEqual("Collection14", ws3.Cells[1, 2].Value);
        }

        [TestMethod]
        public void TestMethod_GenerateReport_EmptyData()
        {
            // Don't create any data
            var report = new ArrangementReport();
            report.GenerateReport();

            // Should handle empty data gracefully
            Assert.IsNotNull(report.package);
            Assert.AreEqual(0, report.package.Workbook.Worksheets.Count);
        }

        [TestMethod]
        public void TestMethod_GenerateReport_SingleArrangement()
        {
            CreateSyntheticArrangementData(1, 2);

            var report = new ArrangementReport();
            report.GenerateReport();

            Assert.IsNotNull(report.package);
            Assert.AreEqual(1, report.package.Workbook.Worksheets.Count);

            var worksheet = report.package.Workbook.Worksheets[0];

            // Should have 1 header row + 1 data row
            Assert.AreEqual("Arrangement Name", worksheet.Cells[1, 1].Value);
            Assert.AreEqual("Arrangement000", worksheet.Cells[2, 1].Value);
            Assert.IsNull(worksheet.Cells[3, 1].Value);
        }

        [TestMethod]
        public void TestMethod_GenerateReport_DeletedArrangements()
        {
            using var context = new GraceDbContext();

            // Create arrangements, some deleted
            var arrangement1 = new Arrangement
            {
                Name = "ActiveArrangement",
                CollectionName = "Collection1",
                IsDeleted = false
            };
            context.Arrangement.Add(arrangement1);
            context.SaveChanges();

            var total1 = new ArrangementTotal
            {
                ArrangementId = arrangement1.ID,
                CurrentTotal = 10,
                User = "testuser"
            };
            context.ArrangementTotals.Add(total1);

            var arrangement2 = new Arrangement
            {
                Name = "DeletedArrangement",
                CollectionName = "Collection1",
                IsDeleted = true // This should be excluded
            };
            context.Arrangement.Add(arrangement2);
            context.SaveChanges();

            var total2 = new ArrangementTotal
            {
                ArrangementId = arrangement2.ID,
                CurrentTotal = 20,
                User = "testuser"
            };
            context.ArrangementTotals.Add(total2);
            context.SaveChanges();

            var report = new ArrangementReport();
            report.GenerateReport();

            var worksheet = report.package.Workbook.Worksheets[0];

            // Should only have 1 active arrangement + header
            Assert.AreEqual("ActiveArrangement", worksheet.Cells[2, 1].Value);
            Assert.IsNull(worksheet.Cells[3, 1].Value); // No third row
        }

        [TestMethod]
        public void TestMethod_GenerateReport_MultipleCollections()
        {
            using var context = new GraceDbContext();

            // Create arrangement across 4 collections with distinct totals
            string arrangementName = "TestArrangement";
            var collectionData = new Dictionary<string, int>
            {
                { "Spring", 10 },
                { "Summer", 15 },
                { "Fall", 20 },
                { "Winter", 25 }
            };

            foreach (var kvp in collectionData)
            {
                var arrangement = new Arrangement
                {
                    Name = arrangementName,
                    CollectionName = kvp.Key,
                    IsDeleted = false
                };
                context.Arrangement.Add(arrangement);
                context.SaveChanges();

                var total = new ArrangementTotal
                {
                    ArrangementId = arrangement.ID,
                    CurrentTotal = kvp.Value,
                    User = "testuser"
                };
                context.ArrangementTotals.Add(total);
            }
            context.SaveChanges();

            var report = new ArrangementReport();
            report.GenerateReport();

            var worksheet = report.package.Workbook.Worksheets[0];

            // Verify collections are in alphabetical order in header
            Assert.AreEqual("Arrangement Name", worksheet.Cells[1, 1].Value);
            Assert.AreEqual("Fall", worksheet.Cells[1, 2].Value);
            Assert.AreEqual("Spring", worksheet.Cells[1, 3].Value);
            Assert.AreEqual("Summer", worksheet.Cells[1, 4].Value);
            Assert.AreEqual("Winter", worksheet.Cells[1, 5].Value);

            // Verify arrangement appears once
            Assert.AreEqual("TestArrangement", worksheet.Cells[2, 1].Value);

            // Verify all totals are present (in alphabetical order by collection name)
            Assert.AreEqual(20, worksheet.Cells[2, 2].Value); // Fall
            Assert.AreEqual(10, worksheet.Cells[2, 3].Value); // Spring
            Assert.AreEqual(15, worksheet.Cells[2, 4].Value); // Summer
            Assert.AreEqual(25, worksheet.Cells[2, 5].Value); // Winter

            // Verify all totals are numeric and non-zero
            for (int col = 2; col <= 5; col++)
            {
                Assert.IsNotNull(worksheet.Cells[2, col].Value);
                Assert.IsTrue((int)worksheet.Cells[2, col].Value > 0);
            }
        }

        [TestMethod]
        public void TestMethod_WriteReport()
        {
            CreateSyntheticArrangementData(3, 2);

            var report = new ArrangementReport();
            report.GenerateReport();

            string outputFile = Path.Combine(testOutputPath, "test_arrangement_report.xlsx");

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

                // Verify printer settings
                Assert.AreEqual(OfficeOpenXml.eOrientation.Landscape, worksheet.PrinterSettings.Orientation);
                Assert.AreEqual(OfficeOpenXml.ePaperSize.Letter, worksheet.PrinterSettings.PaperSize);
                Assert.IsTrue(worksheet.PrinterSettings.FitToPage);
                Assert.AreEqual(1, worksheet.PrinterSettings.FitToWidth);
            }

            // Clean up
            File.Delete(outputFile);
        }

        [TestMethod]
        public void TestMethod_GenerateReport_LatestTotalsOnly()
        {
            using var context = new GraceDbContext();

            // Create arrangement with multiple totals (historical data)
            var arrangement = new Arrangement
            {
                Name = "HistoricalArrangement",
                CollectionName = "TestCollection",
                IsDeleted = false
            };
            context.Arrangement.Add(arrangement);
            context.SaveChanges();

            // Add older total
            var oldTotal = new ArrangementTotal
            {
                ArrangementId = arrangement.ID,
                CurrentTotal = 50,
                LastUpdated = DateTime.Now.AddDays(-10),
                User = "testuser"
            };
            context.ArrangementTotals.Add(oldTotal);

            // Add middle total
            var middleTotal = new ArrangementTotal
            {
                ArrangementId = arrangement.ID,
                CurrentTotal = 75,
                LastUpdated = DateTime.Now.AddDays(-5),
                User = "testuser"
            };
            context.ArrangementTotals.Add(middleTotal);

            // Add newest total
            var newTotal = new ArrangementTotal
            {
                ArrangementId = arrangement.ID,
                CurrentTotal = 100,
                LastUpdated = DateTime.Now,
                User = "testuser"
            };
            context.ArrangementTotals.Add(newTotal);
            context.SaveChanges();

            var report = new ArrangementReport();
            report.GenerateReport();

            var worksheet = report.package.Workbook.Worksheets[0];

            // Should only show the latest total (100)
            Assert.AreEqual(100, worksheet.Cells[2, 2].Value);
        }

        [TestMethod]
        public void TestMethod_GenerateReport_NullTotals()
        {
            using var context = new GraceDbContext();

            // Create arrangement without any totals
            var arrangement = new Arrangement
            {
                Name = "NoTotalsArrangement",
                CollectionName = "EmptyCollection",
                IsDeleted = false
            };
            context.Arrangement.Add(arrangement);
            context.SaveChanges();

            var report = new ArrangementReport();
            report.GenerateReport();

            var worksheet = report.package.Workbook.Worksheets[0];

            // Arrangement should appear in report
            Assert.AreEqual("NoTotalsArrangement", worksheet.Cells[2, 1].Value);

            // But the total cell should be empty
            var cellValue = worksheet.Cells[2, 2].Value;
            Assert.IsTrue(cellValue == null || cellValue.ToString() == "");
        }

        [TestMethod]
        public void TestMethod_GenerateReport_VerifyFormatting()
        {
            CreateSyntheticArrangementData(2, 2);

            var report = new ArrangementReport();
            report.GenerateReport();

            var worksheet = report.package.Workbook.Worksheets[0];

            // Verify header formatting
            Assert.AreEqual(14, worksheet.Cells[1, 1].Style.Font.Size);
            Assert.IsTrue(worksheet.Cells[1, 1].Style.Font.Bold);
            Assert.AreEqual(OfficeOpenXml.Style.ExcelHorizontalAlignment.Center,
                worksheet.Cells[1, 1].Style.HorizontalAlignment);

            // Verify column widths
            Assert.AreEqual(30, worksheet.Column(1).Width);
            Assert.AreEqual(15, worksheet.Column(2).Width);

            // Verify data cell formatting
            Assert.AreEqual(OfficeOpenXml.Style.ExcelHorizontalAlignment.Center,
                worksheet.Cells[2, 2].Style.HorizontalAlignment);
            Assert.AreEqual(OfficeOpenXml.Style.ExcelVerticalAlignment.Center,
                worksheet.Cells[2, 2].Style.VerticalAlignment);
        }

        [TestMethod]
        public void TestMethod_GenerateReport_ProductionDatabase_Baseline()
        {
            // This test uses the production database to create a baseline
            // Skip if production database doesn't exist
            string prodDbPath = @"C:\Users\tom\source\Repos\whiteacrellc\grace\grace\database\grace.db";

            if (!File.Exists(prodDbPath))
            {
                Assert.Inconclusive("Production database not found at: " + prodDbPath);
                return;
            }

            // Create a connection to the production database
            var prodConnectionString = $"Data Source={prodDbPath};Mode=ReadOnly;Cache=Shared;";
            var optionsBuilder = new DbContextOptionsBuilder<GraceDbContext>();
            optionsBuilder.UseSqlite(prodConnectionString);

            // Get arrangement count and collection count from production DB
            int collectionCount;
            var arrangementNames = new List<string>();
            var collectionNames = new List<string>();

            using (var context = new GraceDbContext(optionsBuilder.Options))
            {
                collectionNames = context.Arrangement
                    .Where(a => !a.IsDeleted)
                    .Select(a => a.CollectionName)
                    .Distinct()
                    .OrderBy(name => name)
                    .ToList();
                collectionCount = collectionNames.Count;

                arrangementNames = context.Arrangement
                    .Where(a => !a.IsDeleted)
                    .Select(a => a.Name)
                    .Distinct()
                    .OrderBy(name => name)
                    .ToList();
            }

            // Store connection string temporarily
            var originalConnectionString = DataBase.ConnectionString;
            DataBase.ConnectionString = prodConnectionString;
            GraceDbContext.ConnectionString = prodConnectionString;

            // Debug output
            Console.WriteLine($"Arrangement names found: {arrangementNames.Count}");
            Console.WriteLine($"Collection count: {collectionCount}");
            Console.WriteLine($"Using connection string: {prodConnectionString}");

            try
            {
                var report = new ArrangementReport();
                report.GenerateReport();

                // Basic validation
                Assert.IsNotNull(report.package);
                Console.WriteLine($"Report generated with {report.package.Workbook.Worksheets.Count} worksheets");

                if (arrangementNames.Count > 0 && collectionCount > 0)
                {
                    Assert.IsTrue(report.package.Workbook.Worksheets.Count > 0,
                        "Report should have worksheets when there is arrangement data");

                    var worksheet = report.package.Workbook.Worksheets[0];

                    // Verify we have the expected structure
                    Assert.AreEqual("Arrangement Name", worksheet.Cells[1, 1].Value);

                    // Create a snapshot of the report for comparison
                    string baselineFile = Path.Combine(testOutputPath, "production_baseline.xlsx");
                    report.WriteReport(baselineFile);

                    Assert.IsTrue(File.Exists(baselineFile));

                    // Calculate a signature/hash of the report structure
                    var reportSignature = CalculateReportSignature(report.package);

                    // Output baseline information for reference
                    Console.WriteLine($"=== Production Database Baseline ===");
                    Console.WriteLine($"Distinct Arrangement Names: {arrangementNames.Count}");
                    Console.WriteLine($"Collection Count: {collectionCount}");
                    Console.WriteLine($"Worksheets: {report.package.Workbook.Worksheets.Count}");
                    Console.WriteLine($"Report Signature: {reportSignature}");
                    Console.WriteLine($"First 5 Arrangements: {string.Join(", ", arrangementNames.Take(5))}");
                    Console.WriteLine($"Collections: {string.Join(", ", collectionNames)}");
                    Console.WriteLine($"Baseline file saved to: {baselineFile}");

                    // Verify worksheet count matches expectations based on collection count
                    int expectedWorksheetCount = (int)Math.Ceiling((double)collectionCount / 7.0);
                    Assert.AreEqual(expectedWorksheetCount, report.package.Workbook.Worksheets.Count,
                        $"Expected {expectedWorksheetCount} worksheets for {collectionCount} collections");

                    // NOTE: To verify the report hasn't changed, compare the signature above
                    // with the signature from a previous test run. If they differ,
                    // the report structure or data has changed.
                    //
                    // BASELINE SIGNATURE (from first run):
                    // Compare this value on future runs to detect changes
                    Console.WriteLine($"\n=== SAVE THIS BASELINE FOR FUTURE COMPARISON ===");
                    Console.WriteLine($"Signature: {reportSignature}");
                    Console.WriteLine($"Collections: {string.Join(", ", collectionNames)}");
                    Console.WriteLine($"Arrangements: {string.Join(", ", arrangementNames)}");
                }
                else
                {
                    // No arrangement data found in production database
                    // Note: The report may still generate worksheets from test data due to connection string sharing
                    Console.WriteLine("Production database query returned no arrangement data");
                    Console.WriteLine($"However, report has {report.package.Workbook.Worksheets.Count} worksheets");
                    Console.WriteLine("This suggests the production database is empty or connection string wasn't used properly");

                    // Mark test as inconclusive rather than failed
                    Assert.Inconclusive("Production database has no arrangement data to validate against");
                }
            }
            finally
            {
                // Restore connection string
                DataBase.ConnectionString = originalConnectionString;
                GraceDbContext.ConnectionString = originalConnectionString;
            }
        }

        /// <summary>
        /// Calculates a signature/hash of the report structure for comparison
        /// </summary>
        private string CalculateReportSignature(ExcelPackage package)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Worksheets:{package.Workbook.Worksheets.Count}");

            foreach (var worksheet in package.Workbook.Worksheets)
            {
                sb.AppendLine($"Sheet:{worksheet.Name}");

                // Get dimensions
                var dimension = worksheet.Dimension;
                if (dimension != null)
                {
                    sb.AppendLine($"Rows:{dimension.Rows},Cols:{dimension.Columns}");

                    // Sample first row (headers)
                    for (int col = 1; col <= Math.Min(dimension.Columns, 10); col++)
                    {
                        var value = worksheet.Cells[1, col].Value;
                        sb.Append($"{value}|");
                    }
                    sb.AppendLine();

                    // Sample first data row
                    if (dimension.Rows > 1)
                    {
                        for (int col = 1; col <= Math.Min(dimension.Columns, 10); col++)
                        {
                            var value = worksheet.Cells[2, col].Value;
                            sb.Append($"{value}|");
                        }
                        sb.AppendLine();
                    }
                }
            }

            // Calculate MD5 hash of the signature
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(sb.ToString()));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}

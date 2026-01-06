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
using grace; // For InventoryReport, DataBase, DataGridLoader
using grace.data; // For GraceDbContext
using grace.data.models; // For User, Grace, Total, CollectionName etc.
using OfficeOpenXml; // For ExcelPackage

namespace gracetest
{
    [TestClass]
    public class InventoryReportTests
    {
        private const string TestDbName = "inventoryreport_test.db";
        private const string TestReportFileName = "test_inventory_report.xlsx";
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private DataBase TestDataBase;
        private GraceDbContext TestDbContext;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            // Set up the test database
            TestDataBase = new DataBase(TestDbName); // This sets the static ConnectionString
            TestDbContext = new GraceDbContext();    // Uses the static ConnectionString

            TestDbContext.Database.EnsureDeleted(); // Clean slate
            TestDbContext.Database.EnsureCreated();

            // Initialize necessary schema parts if DataBase.InitializeDatabase() is too broad
            // For InventoryReport, we primarily need data that DataGridLoader.GetData() would fetch.
            // DataGridLoader.GetData() relies on GraceRows, which are built from Grace, Total, Collection.
            DataBase.InitializeDatabase(); // This also calls AdminStuff.InitUserDB() and InitPrefs().
                                           // It also DELETES from Graces, so data must be added AFTER this.
            CreateInventoryTestData();
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestDbContext.Database.EnsureDeleted();
            TestDbContext.Dispose();

            string programDirectory = Directory.GetCurrentDirectory();
            string dbPath = Path.Combine(programDirectory, TestDbName);
            if (File.Exists(dbPath))
            {
                try { File.Delete(dbPath); }
                catch (IOException ex) { System.Diagnostics.Debug.WriteLine($"Could not delete test database: {dbPath}. Error: {ex.Message}"); }
            }

            string reportPath = Path.Combine(programDirectory, TestReportFileName);
            if (File.Exists(reportPath))
            {
                try { File.Delete(reportPath); }
                catch (IOException ex) { System.Diagnostics.Debug.WriteLine($"Could not delete test report file: {reportPath}. Error: {ex.Message}"); }
            }
        }

        private void CreateInventoryTestData()
        {
            // Adapted from ReportTest.cs, focuses on data relevant to DataGridLoader and InventoryReport
            // DataGridLoader.GetData() populates a DataTable from GraceRows.
            // GraceRows are created/updated by DataBase.CreateGraceRow or DataBase.UpdateGraceRow
            // which read from Grace, Totals, and Collections tables.

            for (var i = 0; i < 5; i++) // Create 5 items for the report
            {
                int graceId = 0;
                // 1. Create Grace item
                var graceItem = new Grace
                {
                    Brand = "Brand" + (i % 2), // Alternate brands
                    Sku = "SKU00" + i,
                    Description = "Test Item Description " + i,
                    BarCode = "BC0000" + i,
                    Availability = (i % 2 == 0) ? "In Stock" : "Out of Stock",
                    Note = "Note for item " + i
                };
                TestDbContext.Graces.Add(graceItem);
                TestDbContext.SaveChanges();
                graceId = graceItem.ID;

                // 2. Add Total for the item
                // Using DataBase.AddTotal requires Globals.GetInstance().CurrentUser, let's set a default for tests
                if (string.IsNullOrEmpty(Globals.GetInstance().CurrentUser))
                {
                    Globals.GetInstance().CurrentUser = "testuser"; // Or fetch from a seeded test user
                }
                DataBase.AddTotal(10 + i * 5, graceId); // Current inventory: 10, 15, 20, 25, 30

                // 3. Add Collections for the item
                DataBase.AddCollection("CollectionA" + (i % 3), graceId);
                if (i % 2 == 0) DataBase.AddCollection("CollectionB", graceId);
                if (i % 3 == 0) DataBase.AddCollection("CollectionC", graceId);

                // 4. Ensure GraceRow is created/updated (as DataGridLoader uses this)
                // This step is crucial as DataGridLoader.GetData() directly queries GraceRows table.
                // If GraceRows are not populated, DataGridLoader.GetData() will be empty.
                // DataBase.InitializeDatabase calls AdminStuff.InitUserDB and this will create users
                // We need to ensure that the current user is set for DataBase.AddTotal
                var existingGraceRow = TestDbContext.GraceRows.FirstOrDefault(gr => gr.GraceId == graceId);
                if (existingGraceRow != null)
                {
                    DataBase.UpdateGraceRow(graceId);
                }
                else
                {
                    DataBase.CreateGraceRow(graceId);
                }
            }
        }

        [TestMethod]
        public void GenerateReport_CreatesExcelFileWithCorrectData()
        {
            // Arrange
            string programDirectory = Directory.GetCurrentDirectory();
            string fullReportPath = Path.Combine(programDirectory, TestReportFileName);

            // DataGridView is a UI component. InventoryReport's constructor takes it,
            // but primarily uses DataGridLoader.GetData(). Passing null might work if
            // direct DataGridView properties (beyond Columns.Count for an initial style) aren't heavily used,
            // or if their absence doesn't cause a crash.
            // The critical part is that DataGridLoader.GetData() uses the DB, which we control.
            InventoryReport inventoryReport = new(null); // Passing null for DataGridView

            // Act
            Exception thrownException = null;
            try
            {
                inventoryReport.WriteReport(fullReportPath);
            }
            catch (Exception ex)
            {
                thrownException = ex;
            }

            // Assert
            Assert.IsNull(thrownException, $"WriteReport should not throw an exception. Exception: {thrownException?.Message}");
            Assert.IsTrue(File.Exists(fullReportPath), "Excel report file should be created.");

            using var package = new ExcelPackage(new FileInfo(fullReportPath));
            Assert.IsNotNull(package.Workbook, "Workbook should exist.");
            Assert.IsTrue(package.Workbook.Worksheets.Count > 0, "Workbook should have at least one worksheet.");

            var worksheet = package.Workbook.Worksheets[0]; // Using index as name might vary if locale affects "Report"
            Assert.AreEqual("Report", worksheet.Name, "Worksheet name should be 'Report'.");

            // Verify Headers (mapped names) - Row 1 after WriteHeader is called
            // These mappings are from InventoryReport.WriteHeader
            Assert.AreEqual("Item #", worksheet.Cells[1, 1].Text, "Header SKU mismatch."); // Sku -> Item #
            Assert.AreEqual("Brand", worksheet.Cells[1, 2].Text, "Header Brand mismatch.");
            Assert.AreEqual("Description", worksheet.Cells[1, 3].Text, "Header Description mismatch.");
            // ... (add more header checks based on DataGridLoader.COLUMN_ORDER and columnMappings)
            // Example: Total is column 10 in GraceRow, mapped to "Current Inventory"
            // Note: Column indices in DataGridLoader.COLUMN_ORDER need to be mapped to their actual position
            // For simplicity, let's check a few key ones based on expected GraceRow structure.
            // The actual column order is defined in DataGridLoader.GetData() and its internal DataTable.
            // DataGridLoader.GetData() creates a DataTable from GraceRows.
            // Let's assume standard GraceRow property order for now for a few checks.
            // Sku, Brand, Description, Col1, Col2, Col3, Col4, Col5, Col6, Total, PrevTotal, LastUpdated, Availability, Note, BarCode, GraceId, ID

            Assert.AreEqual("Current Inventory", worksheet.Cells[1, 10].Text, "Header Total (Current Inventory) mismatch.");
            Assert.AreEqual("Collection 1", worksheet.Cells[1, 4].Text, "Header Col1 (Collection 1) mismatch.");


            // Verify Data Rows (Number of rows = header + 5 data rows)
            // InventoryReport adds page breaks and extra headers, so direct row count is complex.
            // Let's focus on finding our data. The data starts at row 2.
            // There are 5 data items.
            int expectedDataRowCount = 5;
            // Simple check for now: ensure at least header + 5 rows exist (actual count will be more due to pagination logic)
            Assert.IsTrue(worksheet.Dimension.Rows >= expectedDataRowCount + 1, $"Worksheet should have at least {expectedDataRowCount + 1} rows (1 header + 5 data). Actual: {worksheet.Dimension.Rows}");

            // Verify some data cells for the first data row (SKU000)
            // Row 2 should be the first data item.
            Assert.AreEqual("SKU000", worksheet.Cells[2, 1].Text, "Data SKU000 mismatch.");
            Assert.AreEqual("Brand0", worksheet.Cells[2, 2].Text, "Data Brand0 mismatch.");
            Assert.AreEqual("Test Item Description 0", worksheet.Cells[2, 3].Text, "Data Description 0 mismatch.");
            Assert.AreEqual("10", worksheet.Cells[2, 10].Text, "Data Total for SKU000 mismatch."); // Total for SKU000 is 10
            Assert.AreEqual("CollectionA0", worksheet.Cells[2, 4].Text, "Data Collection1 for SKU000 mismatch."); // Col1
            Assert.AreEqual("CollectionB", worksheet.Cells[2, 5].Text, "Data Collection2 for SKU000 mismatch."); // Col2
            Assert.AreEqual("CollectionC", worksheet.Cells[2, 6].Text, "Data Collection3 for SKU000 mismatch."); // Col3

            // Verify some data for the second data row (SKU001) - starts at row 3
            Assert.AreEqual("SKU001", worksheet.Cells[3, 1].Text, "Data SKU001 mismatch.");
            Assert.AreEqual("Brand1", worksheet.Cells[3, 2].Text, "Data Brand1 mismatch.");
            Assert.AreEqual("15", worksheet.Cells[3, 10].Text, "Data Total for SKU001 mismatch."); // Total for SKU001 is 15
            Assert.AreEqual("CollectionA1", worksheet.Cells[3, 4].Text, "Data Collection1 for SKU001 mismatch.");
            // SKU001 doesn't have CollectionB or CollectionC based on i % 2 and i % 3 for i=1
            Assert.IsTrue(string.IsNullOrEmpty(worksheet.Cells[3, 5].Text), "Data Collection2 for SKU001 should be empty.");
            Assert.IsTrue(string.IsNullOrEmpty(worksheet.Cells[3, 6].Text), "Data Collection3 for SKU001 should be empty.");
        }

        [TestMethod]
        public void WriteReport_FormatsLastUpdatedColumnCorrectly()
        {
            // Arrange
            string programDirectory = Directory.GetCurrentDirectory();
            string fullReportPath = Path.Combine(programDirectory, "test_lastupdated_format.xlsx");

            InventoryReport inventoryReport = new(null);

            // Act
            inventoryReport.WriteReport(fullReportPath);

            // Assert
            Assert.IsTrue(File.Exists(fullReportPath), "Excel report file should be created.");

            using var package = new ExcelPackage(new FileInfo(fullReportPath));
            var worksheet = package.Workbook.Worksheets[0];

            // Find the LastUpdated column index in the header row
            int lastUpdatedColumnIndex = -1;
            for (int col = 1; col <= worksheet.Dimension.Columns; col++)
            {
                if (worksheet.Cells[1, col].Text == "LastUpdated")
                {
                    lastUpdatedColumnIndex = col;
                    break;
                }
            }

            Assert.IsTrue(lastUpdatedColumnIndex > 0, "LastUpdated column should exist in the report.");

            // Verify that the LastUpdated column contains formatted date strings (not DateTime objects)
            // Row 2 is the first data row
            string lastUpdatedValue = worksheet.Cells[2, lastUpdatedColumnIndex].Text;
            Assert.IsFalse(string.IsNullOrEmpty(lastUpdatedValue), "LastUpdated value should not be empty.");

            // Verify the date format: dd/MM/yyyy HH:mm
            // Expected format: "06/01/2026 12:30" (day/month/year hour:minute)
            Assert.IsTrue(lastUpdatedValue.Contains("/"), "LastUpdated should be formatted as a date string with '/'.");
            Assert.IsTrue(lastUpdatedValue.Contains(":"), "LastUpdated should include time with ':'.");

            // Verify the date can be parsed back (validation of format)
            bool isParsable = DateTime.TryParseExact(
                lastUpdatedValue,
                "dd/MM/yyyy HH:mm",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime parsedDate);

            Assert.IsTrue(isParsable, $"LastUpdated value '{lastUpdatedValue}' should be in 'dd/MM/yyyy HH:mm' format.");

            // Cleanup
            File.Delete(fullReportPath);
        }

        [TestMethod]
        public void WriteReport_HandlesMultipleRowsWithDifferentDates()
        {
            // Arrange
            string programDirectory = Directory.GetCurrentDirectory();
            string fullReportPath = Path.Combine(programDirectory, "test_multiple_dates.xlsx");

            InventoryReport inventoryReport = new(null);

            // Act
            inventoryReport.WriteReport(fullReportPath);

            // Assert
            Assert.IsTrue(File.Exists(fullReportPath), "Excel report file should be created.");

            using var package = new ExcelPackage(new FileInfo(fullReportPath));
            var worksheet = package.Workbook.Worksheets[0];

            // Find the LastUpdated column index
            int lastUpdatedColumnIndex = -1;
            for (int col = 1; col <= worksheet.Dimension.Columns; col++)
            {
                if (worksheet.Cells[1, col].Text == "LastUpdated")
                {
                    lastUpdatedColumnIndex = col;
                    break;
                }
            }

            Assert.IsTrue(lastUpdatedColumnIndex > 0, "LastUpdated column should exist.");

            // Verify that all data rows have formatted LastUpdated values
            // We created 5 test items, so check rows 2-6
            for (int row = 2; row <= 6; row++)
            {
                string lastUpdatedValue = worksheet.Cells[row, lastUpdatedColumnIndex].Text;
                Assert.IsFalse(string.IsNullOrEmpty(lastUpdatedValue),
                    $"Row {row} should have a LastUpdated value.");

                bool isParsable = DateTime.TryParseExact(
                    lastUpdatedValue,
                    "dd/MM/yyyy HH:mm",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime parsedDate);

                Assert.IsTrue(isParsable,
                    $"Row {row} LastUpdated value '{lastUpdatedValue}' should be in 'dd/MM/yyyy HH:mm' format.");
            }

            // Cleanup
            File.Delete(fullReportPath);
        }

        [TestMethod]
        public void WriteReport_DoesNotThrowExceptionWhenLastUpdatedColumnExists()
        {
            // Arrange
            string programDirectory = Directory.GetCurrentDirectory();
            string fullReportPath = Path.Combine(programDirectory, "test_no_exception.xlsx");

            InventoryReport inventoryReport = new(null);

            // Act & Assert - Should not throw any exceptions
            Exception thrownException = null;
            try
            {
                inventoryReport.WriteReport(fullReportPath);
            }
            catch (Exception ex)
            {
                thrownException = ex;
            }

            Assert.IsNull(thrownException,
                $"WriteReport should not throw an exception when processing LastUpdated column. Exception: {thrownException?.Message}");

            Assert.IsTrue(File.Exists(fullReportPath), "Report file should be created successfully.");

            // Cleanup
            File.Delete(fullReportPath);
        }

        [TestMethod]
        public void WriteReport_HeadersAreCorrectlyMapped()
        {
            // Arrange
            string programDirectory = Directory.GetCurrentDirectory();
            string fullReportPath = Path.Combine(programDirectory, "test_headers.xlsx");

            InventoryReport inventoryReport = new(null);

            // Act
            inventoryReport.WriteReport(fullReportPath);

            // Assert
            Assert.IsTrue(File.Exists(fullReportPath), "Excel report file should be created.");

            using var package = new ExcelPackage(new FileInfo(fullReportPath));
            var worksheet = package.Workbook.Worksheets[0];

            // Verify all expected header mappings from InventoryReport.WriteHeader
            var expectedHeaders = new Dictionary<int, string>
            {
                { 1, "Item #" },          // Sku -> Item #
                { 2, "Description" },
                { 3, "Brand" },
                { 4, "Reorder Status" },  // Availability -> Reorder Status
                { 5, "BarCode" },
                { 6, "Collection 1" },    // Col1 -> Collection 1
                { 7, "Collection 2" },    // Col2 -> Collection 2
                { 8, "Collection 3" },    // Col3 -> Collection 3
                { 9, "Collection 4" },    // Col4 -> Collection 4
                { 10, "Collection 5" },   // Col5 -> Collection 5
                { 11, "Collection 6" },   // Col6 -> Collection 6
                { 12, "Current Inventory" }, // Total -> Current Inventory
                { 13, "PrevTotal" },
                { 14, "LastUpdated" },
                { 15, "Note" }
            };

            foreach (var header in expectedHeaders)
            {
                Assert.AreEqual(header.Value, worksheet.Cells[1, header.Key].Text,
                    $"Header at column {header.Key} should be '{header.Value}'.");
            }

            // Cleanup
            File.Delete(fullReportPath);
        }

        [TestMethod]
        public void WriteReport_ColumnWidthAndFormattingApplied()
        {
            // Arrange
            string programDirectory = Directory.GetCurrentDirectory();
            string fullReportPath = Path.Combine(programDirectory, "test_formatting.xlsx");

            InventoryReport inventoryReport = new(null);

            // Act
            inventoryReport.WriteReport(fullReportPath);

            // Assert
            Assert.IsTrue(File.Exists(fullReportPath), "Excel report file should be created.");

            using var package = new ExcelPackage(new FileInfo(fullReportPath));
            var worksheet = package.Workbook.Worksheets[0];

            // Verify column widths are set (should be 20 as per WriteReport logic)
            for (int col = 1; col <= worksheet.Dimension.Columns; col++)
            {
                double columnWidth = worksheet.Column(col).Width;
                Assert.IsTrue(columnWidth > 0, $"Column {col} should have a width set.");
            }

            // Verify font size for headers (should be 16)
            Assert.AreEqual(16, worksheet.Cells[1, 1].Style.Font.Size,
                "Header font size should be 16.");

            // Verify headers are bold
            Assert.IsTrue(worksheet.Cells[1, 1].Style.Font.Bold,
                "Header should be bold.");

            // Verify column 5 (BarCode) has text format
            Assert.AreEqual("@", worksheet.Column(5).Style.Numberformat.Format,
                "Column 5 should have text format.");

            // Cleanup
            File.Delete(fullReportPath);
        }
    }
}

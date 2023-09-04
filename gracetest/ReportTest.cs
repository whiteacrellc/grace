using grace;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace Grace.Tests
{
    [TestClass]
    public class ReportTests
    {
        [TestMethod]
        public void WriteReport_SavesExcelFile()
        {
            // Arrange
            var collections = new Dictionary<string, List<Row>>();
            var items = new Dictionary<string, List<string>>();
            Row row = new Row();
            row.Sku = "SKU";
            row.Collection = "Collection1";
            row.Description = "Description";
            row.PreviousTotal = 10;
            row.Total = 20;
            List<Row> rows = new List<Row>();
            rows.Add(row);
            List<string> list = new List<string>();
            list.Add("Collections2");
            items.Add("SKU", list);
            collections.Add("Collections1", rows);
            row = new Row();
            row.Sku = "SKU2";
            row.Collection = "Collection2";
            row.Description = "Description";
            row.PreviousTotal = 20;
            row.Total = 20;
            rows = new List<Row>();
            rows.Add(row);
            list = new List<string>();
            list.Add("Collections1");
            items.Add("SKU2", list);
            collections.Add("Collections2", rows);


            var report = new Report(collections, items);

            // Use a temporary file for testing
            var tempFileName = Path.GetTempFileName();

            try
            {
                // Act
                report.WriteReport(tempFileName);

                // Assert
                // Add your assertions here to verify that the file was saved successfully.
                // For example, you can check if the file exists.
                Assert.IsTrue(File.Exists(tempFileName));
            }
            finally
            {
                // Clean up: Delete the temporary file
                File.Delete(tempFileName);
            }
        }
    }
}

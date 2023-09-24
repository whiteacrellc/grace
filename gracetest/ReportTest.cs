using grace;
using Microsoft.Office.Interop.Excel;
using Moq;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace gracetest
{
    [TestClass]
    public class ReportTests
    {
        Dictionary<string, List<Row>> collections = new Dictionary<string, List<Row>>();
        Dictionary<string, List<string>> items = new Dictionary<string, List<string>>();

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            collections = new Dictionary<string, List<Row>>();
            items = new Dictionary<string, List<string>>();
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
        }

        [TestMethod]
        public void WriteReport_GenerateReport()
        {
            var report = new Report(collections, items, new Vivian());
            report.GenerateReport();

            ExcelPackage package = report.package;
            Assert.IsNotNull(package);
            var worksheet = package.Workbook.Worksheets[0];
            Assert.AreEqual(worksheet.Name, "Report");
            int rowCount = worksheet.Dimension.Rows;
            Assert.AreEqual(rowCount, 5);
            int colCount = worksheet.Dimension.Columns;
            Assert.AreEqual(colCount, 12);

        }
    }
}

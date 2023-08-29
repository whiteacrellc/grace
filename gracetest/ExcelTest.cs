using grace;

namespace gracetest
{
    [TestClass]
    public class ExcelTest
    {
    
        private const string TestFilePath = "path_to_your_test_excel_file.xlsx"; // Update with your test Excel file path

        [TestMethod]
        public void TestReadExcelFile()
        {
            // Arrange
            var excelReader = new ExcelReader();

            // Act
            excelReader.ReadExcelFile(TestFilePath);

            // Assert
            // Add your assertions here to check if the data was read and processed correctly

            // Example assertion: Verify that at least one collection was added
            Assert.IsTrue(excelReader.Collections.Count > 0);

            // Example assertion: Verify that at least one item was added
            Assert.IsTrue(excelReader.Items.Count > 0);

            // Example assertion: Verify the specific content of a row
            var firstRow = excelReader.Collections.FirstOrDefault().Value.FirstOrDefault();
            Assert.IsNotNull(firstRow);
            Assert.AreEqual("Sample Brand", firstRow.Brand);
            Assert.AreEqual("Sample SKU", firstRow.Sku);
            // Add more assertions as needed
        }
    }
}
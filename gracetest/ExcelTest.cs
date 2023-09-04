using grace;

namespace gracetest
{
    [TestClass]
    public class ExcelTest
    {
    
        private const string TestFilePath = "C:\\Users\\tom\\source\\repos\\grace\\gracetest\\test_file.xlsx"; // Update with your test Excel file path

        [TestMethod]
        public void TestReadExcelFile()
        {
            // Arrange
            var excelReader = new ExcelReader();

            // Act
            excelReader.ReadExcelFile(TestFilePath);

            // Assert
            // Add your assertions here to check if the data was read and processed correctly

            //  Verify that 46 collections
            Assert.AreEqual(46, excelReader.Collections.Count);

            //  Verify that at there are 253 items
            Assert.AreEqual(253, excelReader.Items.Count);

            // Example assertion: Verify the specific content of a row
            var firstRow = excelReader.Collections.FirstOrDefault().Value.FirstOrDefault();
            Assert.IsNotNull(firstRow);
            Assert.AreEqual("Allstate", firstRow.Brand);
            Assert.AreEqual("FBA445-CR/GR", firstRow.Sku);
            Assert.AreEqual("Zoey Lee", firstRow.Collection);
            Assert.AreEqual(57, firstRow.PreviousTotal);
            Assert.AreEqual(57, firstRow.Total);

            // Add more assertions as needed
            var firstItem = excelReader.Items.FirstOrDefault().Value.FirstOrDefault();  
            Assert.IsNotNull(firstItem);
            Assert.AreEqual("Zoey Lee", firstItem);
        }
    }
}
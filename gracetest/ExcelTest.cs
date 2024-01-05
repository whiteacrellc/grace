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

namespace gracetest
{
    [TestClass]
    public class ExcelTest
    {
    
        private const string TestFilePath = "C:\\Users\\tom\\source\\repos\\" + 
            "grace\\gracetest\\test_file.xlsx";

        [TestMethod]
        public void TestReadExcelFile()
        {
            // Arrange
            var excelReader = new ExcelReader(new Vivian());

            // Act
            excelReader.ReadExcelFile(TestFilePath);

            // Assert
            // Add your assertions here to check if the data was read and processed correctly

            //  Verify that 18 collections
            Assert.AreEqual(18, excelReader.Collections.Count);

            //  Verify that at there are 19 items
            Assert.AreEqual(19, excelReader.Items.Count);

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
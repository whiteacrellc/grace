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
using grace.data.models;
using grace.data;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace gracetest
{
    [TestClass]
    public class ReportTests
    {
        private string testDbFile = "reportgrace.db";
        [TestInitialize]
        public void Setup()
        {
            // Create instances of these classes to set the debug database
            var dataBase = new DataBase(testDbFile);
            DataBase.InitializeDatabase();
            CreateTestData();
        }
        [TestCleanup]
        public void Cleanup()
        {
            var fileName = DataBase.DbFileName;
            Cleanup(fileName);
        }

        private void CreateTestData()
        {
            for (var i = 0; i < 20; i++)
            {
                int graceId = 0;
                using (var context = new GraceDbContext())
                {
                   
                    var grace = new Grace
                    {
                        Brand = "brand" + (i % 3),
                        Sku = "sku" + i,
                        Description = "Description" + i,
                        Barcode = "" + i + "0000",
                        Availability = "Availability",
                    };
                    context.Graces.Add(grace);
                    context.SaveChanges();
                    graceId = grace.ID;
                }
                DataBase.AddTotal(3 * i, graceId);
                var k = i % 4;
                DataBase.AddCollection("col1" + k, graceId);
                if (i % 3 == 0)
                {
                    DataBase.AddCollection("col2", graceId);
                }
                if (i % 4 == 0)
                {
                    DataBase.AddCollection("col3", graceId);
                }
                DataBase.CreateGraceRow(graceId);
            }
        }

        [TestMethod]
        public void WriteReport_GenerateReport()
        {
            var report = new Report();
            report.GenerateReport();

            ExcelPackage package = report.package;
            Assert.IsNotNull(package);
            var worksheet = package.Workbook.Worksheets[0];
            Assert.AreEqual(worksheet.Name, "Report");
            int rowCount = worksheet.Dimension.Rows;
            Assert.AreEqual(rowCount,50);
            int colCount = worksheet.Dimension.Columns;
            Assert.AreEqual(colCount, 12);

        }
        private void Cleanup(string databaseName)
        {
            using (var context = new GraceDbContext())
            {
                context.Database.CloseConnection();
            }

            try
            {
                if (File.Exists(databaseName))
                {
                    File.Delete(databaseName);
                }
                else
                {
                    Console.WriteLine("Database does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

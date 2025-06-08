
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

// Don't like warnings in my IDE for silly stuff
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8600
/*-----------------------------------------------------------------------------*/
namespace gracetest
{

    [TestClass]
    public class DataBaseTest
    {
        private string testDbFile = "testgrace.db";
        private string connectionString = string.Empty;
        private Dictionary<int, int> rowHash = new();


        [TestInitialize]
        public void Setup()
        {
            // Create a mock SQLite connection and command
            var dataBase = new DataBase(testDbFile);
            connectionString = DataBase.ConnectionString;
            DataBase.InitializeDatabase();
        }

        [TestCleanup]
        public void Cleanup()
        {
            var fileName = DataBase.DbFileName;
            Cleanup(fileName);
        }

        [TestMethod]
        public void Test_DataBase()
        {
            string testConnectString = "Data Source=C:\\Users\\tom\\source\\" +
                "repos\\whiteacrellc\\grace\\gracetest\\bin\\Debug\\net7.0-windows7.0\\" +
                "testgrace.db;Mode=ReadWriteCreate;Cache=Private";

            Assert.IsNotNull(connectionString);
            Assert.AreEqual(connectionString, testConnectString);
        }

        [TestMethod]
        public void TestMethod_LoadFromExcel()
        {
            string filename = "C:\\Users\\tom\\source\\repos\\whiteacrellc\\"
                + "grace\\gracetest\\test_file.xlsx";
            DataBase.LoadFromExcel(filename);

            using var context = new GraceDbContext();
            Assert.AreEqual(context.Graces.ToList().Count, 19);
            Assert.IsTrue(context.Collections.ToList().Count > 0);
            Assert.IsTrue(context.Totals.ToList().Count > 0);

            var result = context.Graces.ToList();
            foreach (var item in result)
            {
                Assert.AreEqual(item.BarCode, "33849104226");
                Assert.AreEqual(item.Sku, "FBA445-CR/GR");
                Assert.AreEqual(item.Brand, "Allstate");
                break;
            }
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
                        BarCode = "" + i + "0000",
                        Availability = "Availability",
                    };
                    context.Graces.Add(grace);
                    context.SaveChanges();
                    graceId = grace.ID;
                }
                DataBase.AddTotal((3 * i) + 1, graceId);
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
                int graceRowId = DataBase.CreateGraceRow(graceId);
                rowHash.Add(graceRowId, graceId);
            }
        }

        [TestMethod]
        public void TestMethod_CreateGraceRow()
        {
            CreateTestData();
            Assert.AreEqual(rowHash.Keys.Count, 20);

            // Delete grace row
            using var context = new GraceDbContext();
            // Find the value of the first element in the hash
            var firstElement = rowHash.FirstOrDefault();
            int graceId = firstElement.Value;
            var grace = context.Graces.Find(graceId);
            Assert.IsNotNull(grace);

            var sku = grace.Sku;
            Assert.IsNotNull(sku);

            var graceRow = DataBase.GetGraceRowFromSku(sku);
            Assert.IsNotNull(graceRow);
            Assert.IsTrue(graceRow.Total > 0);
            Assert.IsTrue(graceRow.Description.Contains("Description"));
            Assert.IsTrue(graceRow.Col1.Contains("col"));
            Assert.IsNull(graceRow.Col4);
            Assert.IsNull(graceRow.Col5);
            Assert.IsNull(graceRow.Col6);

            context.Graces.Remove(grace);
            context.SaveChanges();

            // Make sure grace row is deleted
            graceRow = context.GraceRows.
                FirstOrDefault(item => item.GraceId == graceId);
            Assert.IsNull(graceRow);

            // Make sure collection rows are deleted
            var collectionRows = context.Collections
                .Where(e => e.GraceId == graceId)
                .ToList();
            Assert.AreEqual(collectionRows.Count, 0);

            // No CurrentTotal rows
            var totalRows = context.Totals
                   .Where(e => e.GraceId == graceId)
                   .ToList();
            Assert.AreEqual(totalRows.Count, 0);

        }


        private void Cleanup(string databaseName)
        {
            using (var context = new GraceDbContext())
            {
                context.Database.EnsureDeleted();
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
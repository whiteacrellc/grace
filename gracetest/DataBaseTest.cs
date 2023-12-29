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
using System.Data.Entity;
using System.Data.SQLite;

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
        private DataBase dataBase;
        public GraceDbContext graceDb;

        [TestInitialize]
        public void Setup()
        {
            // Create a mock SQLite connection and command
            dataBase = new DataBase(testDbFile);
            connectionString = DataBase.ConnectionString;
            graceDb = new GraceDbContext();
        }

        [TestCleanup]
        public void Cleanup()
        {
            var fileName = dataBase.DbFileName;
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


            Assert.AreEqual(graceDb.Graces.ToList().Count, 19);
            Assert.IsTrue(graceDb.Collections.ToList().Count > 0);
            Assert.IsTrue(graceDb.Totals.ToList().Count > 0);

            var result = graceDb.Graces.ToList();
            foreach (var item in result)
            {
                Assert.AreEqual(item.Barcode, "33849104226");
                Assert.AreEqual(item.Sku, "FBA445-CR/GR");
                Assert.AreEqual(item.Brand, "Allstate");
                break;
            }

        }

        private int CreateTestData()
        {
            int graceId = 0;
            using (var context = new GraceDbContext())
            {
                var grace = new Grace
                {
                    Brand = "brand",
                    Sku = "sku",
                    Description = "Description",
                    Barcode = "1234",
                    Availability = "Availability",
                };
                context.Graces.Add(grace);
                context.SaveChanges();
                graceId = grace.ID;
            }
            DataBase.AddTotal(1234, graceId);
            DataBase.AddCollection("col1", graceId);
            DataBase.AddCollection("col2", graceId);
            DataBase.AddCollection("col3", graceId);
            return graceId;
        }

        [TestMethod]
        public void TestMethod_CreateGraceRow()
        {
            int graceId = CreateTestData();
            bool ret = DataBase.CreateGraceRow(graceId);
        
            Assert.IsFalse(ret);

            // Delete grace row
            using (var context = new GraceDbContext())
            {
                var grace = context.Graces.Find(graceId);
                Assert.IsNotNull(grace);

                var sku = grace.Sku;
                Assert.IsNotNull(sku);

                var graceRow = DataBase.GetGraceRowFromSku(sku);
                Assert.IsNotNull(graceRow);
                Assert.AreEqual(graceRow.Total, 1234);
                Assert.AreEqual(graceRow.Description, "Description");
                Assert.IsTrue(graceRow.Col1.Contains("col"));
                Assert.IsTrue(graceRow.Col2.Contains("col"));
                Assert.IsTrue(graceRow.Col3.Contains("col"));
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
                    .Select(e => e.GraceId == graceId)
                    .ToList();
                Assert.AreEqual(collectionRows.Count, 0);

                // No total rows
                var totalRows = context.Totals
                       .Select(e => e.GraceId == graceId)
                       .ToList();
                Assert.AreEqual(totalRows.Count, 0);

            }

        }


        private void Cleanup(string databaseName)
        {

            graceDb.Database.EnsureDeleted();
            graceDb.Database.CloseConnection();

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
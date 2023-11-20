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
                "repos\\grace\\gracetest\\bin\\Debug\\net6.0-windows\\" + 
                "testgrace.db;Mode=ReadWriteCreate;Cache=Private";

            Assert.IsNotNull(connectionString);
            Assert.AreEqual(connectionString, testConnectString);
        }

        [TestMethod]
        public void TestMethod_LoadFromExcel()
        {
            string filename = "C:\\Users\\tom\\source\\repos\\grace\\gracetest\\" 
                + "test_file.xlsx";
            dataBase.LoadFromExcel(filename);


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
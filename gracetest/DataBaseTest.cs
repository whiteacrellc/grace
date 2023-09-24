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

        [TestInitialize]
        public void Setup()
        {
            // Create a mock SQLite connection and command
            dataBase = new DataBase(testDbFile);
            connectionString = dataBase.ConnectionString;
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
                "testgrace.db;Version=3;";

            Assert.IsNotNull(connectionString);
            Assert.AreEqual(connectionString, testConnectString);
        }

        [TestMethod]
        public void TestMethod_LoadFromExcel()
        {
            string filename = "C:\\Users\\tom\\source\\repos\\grace\\gracetest\\" 
                + "test_file.xlsx";
            dataBase.LoadFromExcel(filename);

            string sql = "SELECT sku, description, brand, availability, barcode FROM Grace";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string sku = reader["sku"].ToString();
                            string brand = reader["brand"].ToString();
                            long barcode = Convert.ToInt64(reader["barcode"]);

                            Assert.AreEqual(barcode, 33849104226);
                            Assert.AreEqual(sku, "FBA445-CR/GR");
                            Assert.AreEqual(brand, "Allstate");
                            break;
                        }
                    }
                }
            }

        }


        private void Cleanup(string databaseName)
        {
            var sqliteConnection = new SQLiteConnection(connectionString);
            sqliteConnection.Open();

            string dropSql = "DROP TABLE IF EXISTS Grace;DROP TABLE IF EXISTS" 
                + " Collections;DROP TABLE IF EXISTS Totals;";
            using (SQLiteCommand command = new SQLiteCommand(dropSql, sqliteConnection))
            {
                command.ExecuteNonQuery();
            }
            sqliteConnection.Dispose();
          
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
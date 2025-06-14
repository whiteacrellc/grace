﻿/*
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
    public class DataGridLoaderTests
    {
        private string testDbFile = "testgrid.db";
        private string connectionString = string.Empty;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private DataBase dataBase;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.



        [TestInitialize]
        public void Setup()
        {
            // Create a mock SQLite connection and command
            dataBase = new DataBase(testDbFile);

            string filename = "C:\\Users\\tom\\source\\repos\\grace\\gracetest\\"
                + "test_file.xlsx";
            try
            {
                DataBase.LoadFromExcel(filename);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            var fileName = DataBase.DbFileName;
            Cleanup(fileName);
        }

        [TestMethod]
        public void Test_CreateLoadTable()
        {

            try
            {
                DataGridLoader.LoadBindingTable();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        private void Cleanup(string databaseName)
        {
            /* We don't need to do this since we are deleting the sqlite file
            var sqliteConnection = new SQLiteConnection(connectionString);
            sqliteConnection.Open();

            string dropSql = "DROP TABLE IF EXISTS Grace;DROP TABLE IF EXISTS"
                + " Collections;DROP TABLE IF EXISTS Totals;";
            using (SQLiteCommand command = new SQLiteCommand(dropSql, sqliteConnection))
            {
                command.ExecuteNonQuery();
            }
            sqliteConnection.Dispose();
            */

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

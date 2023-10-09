﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using grace;
using System.Data.SQLite;
using Moq;

namespace gracetests
{
    [TestClass]
    public class DataGridLoaderTests
    {
        private string testDbFile = "testgrid.db";
        private string connectionString = string.Empty;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private DataBase dataBase;
        private DataGridLoader loader;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        
        [TestInitialize]
        public void Setup()
        {
            // Create a mock SQLite connection and command
            dataBase = new DataBase(testDbFile);
            string filename = "C:\\Users\\tom\\source\\repos\\grace\\gracetest\\"
                + "test_file.xlsx";
            dataBase.LoadFromExcel(filename);
            connectionString = dataBase.ConnectionString;
            Globals.GetInstance().ConnectionString = connectionString;
            loader = new DataGridLoader(new Vivian());
        }

        [TestCleanup]
        public void Cleanup()
        {
            var fileName = dataBase.DbFileName;
            Cleanup(fileName);
        }

        [TestMethod]
        public void Test_CreateLoadTable()
        {

            var connectoion = dataBase.OpenConnection();
            try
            {
                loader.CreateLoadTable(connectoion);
                loader.MakeBindingTable(connectoion);
                loader.LoadBindingTable(connectoion);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                connectoion.Close();
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

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
using NLog;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: InternalsVisibleTo("gracetest")]

namespace grace
{

    public class DataBase
    {

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public string DbFileName { get; set; }
        public string ConnectionString { get; set; }

        private string dbName = "grace.db";

        public DataBase()

        {
            DbFileName = string.Empty;
            ConnectionString = CreateDatabaseFile();
            InitializeDatabase();
        }

        public DataBase(string fileName)
        {
            dbName = fileName;
            DbFileName = string.Empty;
            ConnectionString = CreateDatabaseFile();
            InitializeDatabase();
        }

        public string CreateDatabaseFile()
        {
            // Get the program's directory
            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Specify the database file path in the program's directory
            DbFileName = Path.Combine(programDirectory, dbName);

            // Check if the database file exists; if not, create it
            if (!File.Exists(DbFileName))
            {
                SQLiteConnection.CreateFile(DbFileName);
            }

            var connectionString = "Data Source=" + DbFileName
                + ";Version=3;";

            logger.Info(connectionString);

            return connectionString;
        }

        public SQLiteConnection OpenConnection()
        {
            var db = new SQLiteConnection(ConnectionString);
            return db;
        }

        public void LoadFromExcel(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming the first worksheet is the one to read

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++)
                {
                    var rowobj = worksheet.Cells[row, 1, row, worksheet.Dimension.Columns];

                    // Count non-empty cells in the row
                    int cellCount = rowobj.Count(c => !string.IsNullOrWhiteSpace(c.Text));


                    if (cellCount > 0)
                    {
                        string brand = (string)worksheet.Cells[row, 1].Value;
                        var bar_code = worksheet.Cells[row, 2].Value;
                        long barcode = 0;
                        if (bar_code != null)
                        {
                            barcode = Convert.ToInt64(bar_code);
                        }
                        string sku = checkString(worksheet.Cells[row, 3].Value);
                        string description = (string)worksheet.Cells[row, 4].Value;
                        var a = (worksheet.Cells[row, 11].Value);
                        string availabilty = "";
                        if (a != null)
                        {
                            availabilty = (string)a;
                        }
                        int previousTotal = Convert.ToInt32(worksheet.Cells[row, 12].Value);
                        int total = Convert.ToInt32(worksheet.Cells[row, 13].Value);

                        var sqliteConnection = OpenConnection();
                        sqliteConnection.Open();

                        long insertId = InsertRow(sqliteConnection, sku, description, brand,
                             availabilty, barcode);
                        AddTotal(sqliteConnection, total, insertId);
                        var col1 = (string)worksheet.Cells[row, 5].Value;
                        AddCollection(sqliteConnection, col1, insertId);

                        var col2 = (string)worksheet.Cells[row, 6].Value;
                        AddCollection(sqliteConnection, col2, insertId);

                        var col3 = (string)worksheet.Cells[row, 7].Value;
                        AddCollection(sqliteConnection, col3, insertId);

                        var col4 = (string)worksheet.Cells[row, 8].Value;
                        AddCollection(sqliteConnection, col4, insertId);

                        var col5 = (string)worksheet.Cells[row, 9].Value;
                        AddCollection(sqliteConnection, col5, insertId);

                        var col6 = (string)worksheet.Cells[row, 10].Value;
                        AddCollection(sqliteConnection, col6, insertId);

                        sqliteConnection.Close();
                    }
                }
            }
        }

        private void CreateDataSet()
        {
            string col1 = string.Empty;
            string col2 = string.Empty;
            string col3 = string.Empty;
            string col4 = string.Empty;
            string col5 = string.Empty;
            string col6 = string.Empty;
            int previousTotal = 0;
            int total = 0;


        }
        private void InitializeDatabase()
        {
            try
            {
                var sqliteConnection = OpenConnection();
                sqliteConnection.Open();
                CreateMainTable(sqliteConnection);
                CreateTotalTable(sqliteConnection);
                CreateCollectionTable(sqliteConnection);
                sqliteConnection.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        void CreateMainTable(SQLiteConnection sqliteConnection)
        {
            string createTableSQL = "CREATE TABLE IF NOT EXISTS Grace "
                + "(ID INTEGER PRIMARY KEY AUTOINCREMENT,"
                + " sku TEXT,"
                + " description TEXT,"
                + " brand TEXT,"
                + " availability TEXT,"
                + " barcode INTEGER"
                + ");";
            logger.Info(createTableSQL);
            using (SQLiteCommand command = new SQLiteCommand(createTableSQL, sqliteConnection))
            {
                command.ExecuteNonQuery();
            }
        }
            void CreateBindingTable(SQLiteConnection sqliteConnection)
            {
                string createTableSQL = "CREATE TABLE IF NOT EXISTS BindingTable "
                    + "(ID INTEGER PRIMARY KEY AUTOINCREMENT,"
                    + " sku TEXT,"
                    + " description TEXT,"
                    + " brand TEXT,"
                    + " availability TEXT,"
                    + " barcode INTEGER,"
                    + " col1 TEXT,"
                    + " col1 TEXT,"
                    + " col2 TEXT,"
                    + " col3 TEXT,"
                    + " col4 TEXT,"
                    + " col5 TEXT,"
                    + " col6 TEXT,"
                    + " previous_total INTEGER,"
                    + " total INTEGER,"
                    + "grace_id INTEGER,"
                    + "FOREIGN KEY(grace_id) REFERENCES grace(id));";
            logger.Info(createTableSQL);
                using (SQLiteCommand command = new SQLiteCommand(createTableSQL, sqliteConnection))
                {
                    command.ExecuteNonQuery();
                }

            }

            void CreateTotalTable(SQLiteConnection sqliteConnection)
            {
                string createTableSQL = "CREATE TABLE IF NOT EXISTS Totals ("
                   + "id INTEGER PRIMARY KEY AUTOINCREMENT,"
                   + "date_field DATE,"
                   + "total INTEGER,"
                   + "grace_id INTEGER,"
                   + "FOREIGN KEY(grace_id) REFERENCES grace(id));";
                logger.Info(createTableSQL);
                using (SQLiteCommand command = new SQLiteCommand(createTableSQL, sqliteConnection))
                {
                    command.ExecuteNonQuery();
                }

            }

            void CreateCollectionTable(SQLiteConnection sqliteConnection)
            {
                string createTableSQL = "CREATE TABLE IF NOT EXISTS Collections ("
                   + "id INTEGER PRIMARY KEY AUTOINCREMENT,"
                   + "name TEXT,"
                   + "grace_id INTEGER,"
                   + "FOREIGN KEY(grace_id) REFERENCES grace(id));";
                logger.Info(createTableSQL);
                using (SQLiteCommand command = new SQLiteCommand(createTableSQL, sqliteConnection))
                {
                    command.ExecuteNonQuery();
                }

            }

            long InsertRow(SQLiteConnection sqliteConnection, string sku, string description, string brand,
               string availability, long barcode)
            {
                long insertId = 0;


                using (SQLiteCommand command = sqliteConnection.CreateCommand())
                {
                    // Use parameterized query to insert data
                    command.CommandText = "INSERT INTO Grace (sku, description, brand, availability, barcode) " +
                                          "VALUES (@sku, @description, @brand, @availability, @barcode)";

                    // Add parameters with sanitized values
                    command.Parameters.AddWithValue("@sku", sku);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@brand", brand);
                    command.Parameters.AddWithValue("@availability", availability);
                    command.Parameters.AddWithValue("@barcode", barcode);
                    object result = command.ExecuteNonQuery();
                    if (result == null)
                    {
                        logger.Error("Unable to insert row.");
                    }
                }

                String idSql = "SELECT last_insert_rowid();";
                using (SQLiteCommand command = new SQLiteCommand(idSql, sqliteConnection))
                {
                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        insertId = Convert.ToInt64(result);
                    }
                    else
                    {
                        logger.Error("Failed to get the ID of the inserted row.");
                    }
                }
                logger.Info($"Insert row {insertId}");
                return insertId;

            }
            void AddCollection(SQLiteConnection sqliteConnection, string collection, long grace_id)
            {
                if (collection == null) return;
                string insertSql = "INSERT INTO Collections (name, grace_id)"
                     + "VALUES ('"
                     + collection.Trim() + "',"
                     + grace_id + ");";
                logger.Info(insertSql);
                using (SQLiteCommand insertCommand = new SQLiteCommand(insertSql, sqliteConnection))
                {
                    insertCommand.ExecuteNonQuery();
                }
            }

            void AddTotal(SQLiteConnection sqliteConnection, int total, long grace_id)
            {

                DateTime currentDate = DateTime.Now;
                string formattedDate = currentDate.ToString("yyyy-MM-dd");
                string insertSql = "INSERT INTO Totals (date_field, total, grace_id)"
                     + "VALUES ('"
                     + formattedDate + "',"
                     + total + ","
                     + grace_id + ");";
                logger.Info(insertSql);
                using (SQLiteCommand insertCommand = new SQLiteCommand(insertSql, sqliteConnection))
                {
                    insertCommand.ExecuteNonQuery();
                }
            }

            string checkString(object n)
            {
                string ret = "";
                try
                {
                    ret = Convert.ToString((string)n);
                    return ret.Trim();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    ret = ((double)n).ToString();
                    return ret.Trim();
                }
            }

        }

    }


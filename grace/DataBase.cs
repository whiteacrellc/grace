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
        private SQLiteConnection sqliteConnection;
        //private DbConnection sqliteConnection;
        public DataBase()

        {
            string connectionString = "Data Source=grace.db;Version=3;";
            sqliteConnection = new SQLiteConnection(connectionString);
            InitializeDatabase();
        }

        public DataBase(SQLiteConnection sqliteConnection)
        {
            this.sqliteConnection = sqliteConnection;
            InitializeDatabase();
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

                        long insertId = InsertRow(sku, description, brand,
                             availabilty, barcode);
                        AddTotal(total, insertId);
                        var col1 = (string)worksheet.Cells[row, 5].Value;
                        AddCollection(col1, insertId);

                        var col2 = (string)worksheet.Cells[row, 6].Value;
                        AddCollection(col2, insertId);

                        var col3 = (string)worksheet.Cells[row, 7].Value;
                        AddCollection(col3, insertId);

                        var col4 = (string)worksheet.Cells[row, 8].Value;
                        AddCollection(col4, insertId);

                        var col5 = (string)worksheet.Cells[row, 9].Value;
                        AddCollection(col5, insertId);

                        var col6 = (string)worksheet.Cells[row, 10].Value;
                        AddCollection(col6, insertId);

                    }
                }
            }
        }
        private void InitializeDatabase()
        {
            try
            {
                sqliteConnection.Open();
                CreateMainTable();
                CreateTotalTable();
                CreateCollectionTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

         void CreateMainTable()
        {
            string createTableSQL = "CREATE TABLE IF NOT EXISTS Grace (ID INTEGER PRIMARY KEY,"
                + " sku TEXT,"
                + " description TEXT,"
                + " brand TEXT,"
                + " availability TEXT,"
                + " barcode INTEGER,"
                + ");";

            using (SQLiteCommand command = new SQLiteCommand(createTableSQL, sqliteConnection))
            {
                command.ExecuteNonQuery();
            }

        }

         void CreateTotalTable()
        {
            string createTableSQL = "CREATE TABLE IF NOT EXISTS Totals ("
               + "id INTEGER PRIMARY KEY AUTOINCREMENT,"
               + "date_field DATE,"
               + "total INTEGER,"
               + "grace_id INTEGER,"
               + "FOREIGN KEY(grace_id) REFERENCES grace(id));";

            using (SQLiteCommand command = new SQLiteCommand(createTableSQL, sqliteConnection))
            {
                command.ExecuteNonQuery();
            }

        }

         void CreateCollectionTable()
        {
            string createTableSQL = "CREATE TABLE IF NOT EXISTS Collections ("
               + "id INTEGER PRIMARY KEY AUTOINCREMENT,"
               + "name TEXT,"
               + "grace_id INTEGER,"
               + "FOREIGN KEY(grace_id) REFERENCES grace(id));";

            using (SQLiteCommand command = new SQLiteCommand(createTableSQL, sqliteConnection))
            {
                command.ExecuteNonQuery();
            }

        }

         long InsertRow(string sku, string description, string brand,
            string availabilty, long barcode)
        {
            long insertId = 0;
            // Insert a row into the table and get the ID of the inserted row.
            string insertSql = "INSERT INTO Grace (sku, description, brand," +
                "availability, barcode) VALUES ('"
               + sku + "','"
               + description + "','"
               + brand + "','"
               + availabilty + "',"
               + barcode + ");"
               + "SELECT last_insert_rowid();";
            using (SQLiteCommand insertCommand = new SQLiteCommand(insertSql, sqliteConnection))
            {
                object result = insertCommand.ExecuteScalar();

                if (result != null)
                {
                    insertId = Convert.ToInt64(result);
                }
                else
                {
                    logger.Error("Failed to get the ID of the inserted row.");
                }
            }

            return insertId;

        }
         void AddCollection(string collection, long grace_id)
        {
            if (collection == null) return;
            string insertSql = "INSERT INTO Collections (name, grace_id)"
                 + "VALUES ('"
                 + collection.Trim() + "',"
                 + grace_id + ");";
            using (SQLiteCommand insertCommand = new SQLiteCommand(insertSql, sqliteConnection))
            {
                insertCommand.ExecuteScalar();
            }
        }

         void AddTotal(int total, long grace_id)
        {

            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("yyyy-MM-dd");
            string insertSql = "INSERT INTO Totals (date_field, total, grace_id)"
                 + "VALUES ('"
                 + formattedDate + "',"
                 + total + ","
                 + grace_id + ");";
            using (SQLiteCommand insertCommand = new SQLiteCommand(insertSql, sqliteConnection))
            {
                insertCommand.ExecuteScalar();
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


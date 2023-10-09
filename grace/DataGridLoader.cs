using NLog;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using static OfficeOpenXml.ExcelErrorValue;

namespace grace
{
    internal class DataGridLoader
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private Vivian vivian;
        private string connectionString;
        private DataTable dataTable = new DataTable();
        private Dictionary<long, GraceRow> graceRows = new Dictionary<long, GraceRow>();

        public DataGridLoader(Vivian vivian)
        {
            this.vivian = vivian;
            this.connectionString = Globals.GetInstance().ConnectionString;
        }

        private SQLiteConnection OpenConnection()
        {
            var db = new SQLiteConnection(connectionString);
            return db;
        }
        private void CloseConnection(SQLiteConnection connection)
        {
            // Close the connection
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void Load()
        {
            var sqliteConnection = OpenConnection();
            sqliteConnection.Open();

            string query = "SELECT * FROM BindingTable";

            // Create a DataAdapter and DataTable.
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, sqliteConnection);
            dataTable = new DataTable();

            // Fill the DataTable with data from the database.
            adapter.Fill(dataTable);

            // Bind the DataTable to the DataGridView.
            vivian.GetDataGridView().DataSource = dataTable;

            // Close connection
            CloseConnection(sqliteConnection);
        }

        internal void MakeBindingTable(SQLiteConnection sqliteConnection)
        {
            // Make the binding table
            CreateLoadTable(sqliteConnection);
            GetGrace(sqliteConnection);
            GetCollections(sqliteConnection);
            GetTotals(sqliteConnection);

        }
        private void ExecuteNonQuery(SQLiteConnection sqliteConnection, string sql)
        {
            logger.Info(sql);
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, sqliteConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        internal void CreateLoadTable(SQLiteConnection sqliteConnection)
        {
            string dropTableSQL = "DROP TABLE IF EXISTS BindingTable";
            ExecuteNonQuery(sqliteConnection, dropTableSQL);

            string createTableSQL = "CREATE TABLE BindingTable "
                   + "(ID INTEGER PRIMARY KEY AUTOINCREMENT,"
                   + " sku TEXT,"
                   + " description TEXT,"
                   + " brand TEXT,"
                   + " availability TEXT,"
                   + " barcode TEXT,"
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
            ExecuteNonQuery(sqliteConnection, createTableSQL);
        }

        internal void LoadBindingTable(SQLiteConnection sqliteConnection)
        {
            foreach (var kvp in graceRows)
            {
                long key = kvp.Key;
                GraceRow value = kvp.Value;

                // Define the SQL INSERT statement
                string insertSql = "INSERT INTO BindingTable (sku, description,"
                    + " brand, availability, barcode, col1, col2, col3, col4,"
                    + " col5, col6, previous_total, total) "
                    + "VALUES (@sku, @description, @brand, @availability,"
                    + " @barcode, @col1, @col2, @col3, @col4, @col5, @col6, "
                    + "@previous_total, @total)";

                using (SQLiteCommand command = new SQLiteCommand(insertSql, sqliteConnection))
                {
                    // Set parameters for the INSERT statement
                    command.Parameters.AddWithValue("@sku", value.Sku);
                    command.Parameters.AddWithValue("@description", value.Description);
                    command.Parameters.AddWithValue("@brand", value.Brand);
                    AddStringParameter(command, "@availability", value.Availability);
                    AddStringParameter(command, "@barcode", value.BarCode);
                    AddStringParameter(command, "@col1", value.Col1);
                    AddStringParameter(command, "@col2", value.Col2);
                    AddStringParameter(command, "@col3", value.Col3);
                    AddStringParameter(command, "@col4", value.Col4);
                    AddStringParameter(command, "@col5", value.Col5);
                    AddStringParameter(command, "@col6", value.Col6);
                    command.Parameters.AddWithValue("@previous_total", value.PreviousTotal);
                    command.Parameters.AddWithValue("@total", value.Total);

                    // Execute the INSERT statement
                    int rowsInserted = command.ExecuteNonQuery();
                    logger.Info($"Inserted {rowsInserted} rows into BindingTable.");
                }


            }
        }

        private void AddStringParameter(SQLiteCommand cmd, string param, string? value)
        {
            // Check if the value is null and handle accordingly
            if (value == null)
            {
                cmd.Parameters.Add(param, DbType.String).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add(param, DbType.String).Value = value;
            }
        }

        /*
         * Get the last two totals 
         */
        private void GetGrace(SQLiteConnection sqliteConnection)
        {

            string sql = "SELECT id,sku,description,brand,availability,"
              + "barcode FROM Grace";
            using (SQLiteCommand command = new SQLiteCommand(sql, sqliteConnection))
            {
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                {
                    // Create a DataTable to store the results
                    DataTable dataTable = new DataTable();

                    // Loop through the results and display them
                    foreach (DataRow row in dataTable.Rows)
                    {
                        GraceRow dataRow = new GraceRow();
                        dataRow.Id = Convert.ToInt64(row["id"]);
                        dataRow.Sku = (string)row["sku"];
                        dataRow.Description = (string)row["description"];
                        dataRow.Brand = (string)row["brand"];
                        dataRow.BarCode = row["barcode"]?.ToString();
                        dataRow.Availability = row["availability"]?.ToString();
                        graceRows[dataRow.Id] = dataRow;
                    }

                }
            }
        } // end GetGrace

        private void GetCollections(SQLiteConnection sqliteConnection)
        {


            // Loop through the keys
            foreach (long key in graceRows.Keys)
            {

                string sql = "SELECT name FROM Collections WHERE grace_id=" + key;
                GraceRow graceRow = graceRows[key];
                using (SQLiteCommand command = new SQLiteCommand(sql, sqliteConnection))
                {
                    // Create a DataTable to store the results
                    DataTable dataTable = new DataTable();
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {

                        int i = 0;
                        // Loop through the results and display them
                        foreach (DataRow row in dataTable.Rows)
                        {
                            switch (i)
                            {
                                case 0:
                                    graceRow.Col1 = row["name"]?.ToString();
                                    break;
                                case 1:
                                    graceRow.Col2 = row["name"]?.ToString();
                                    break;
                                case 2:
                                    graceRow.Col3 = row["name"]?.ToString();
                                    break;
                                case 3:
                                    graceRow.Col4 = row["name"]?.ToString();
                                    break;
                                case 4:
                                    graceRow.Col5 = row["name"]?.ToString();
                                    break;
                                case 5:
                                    graceRow.Col6 = row["name"]?.ToString();
                                    break;
                                default:
                                    logger.Warn("Number is not in the range 0 through 5");
                                    break;
                            }
                            i++;
                        }
                    }
                }
            }
        } // end GetCollections

        private void GetTotals(SQLiteConnection sqliteConnection)
        {
            string[] dates = new string[2];
            int[] totals = new int[2];

            // Loop through the keys
            foreach (long key in graceRows.Keys)
            {


                string sql = "SELECT date_field, total FROM Totals WHERE " +
                        "grace_id=@grace_id ORDER BY date_field DESC LIMIT 2";
                using (SQLiteCommand command = new SQLiteCommand(sql, sqliteConnection))
                {
                    command.Parameters.AddWithValue("@grace_id", key);

                    // Create a DataTable to store the results
                    DataTable dataTable = new DataTable();

                    // Create a DataAdapter to fill the DataTable
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        int i = 0;
                        // Loop through the results and display them
                        foreach (DataRow row in dataTable.Rows)
                        {
                            DateTime dateField = Convert.ToDateTime(row["date_field"]);
                            dates[i] = dateField.ToString("d", CultureInfo.CreateSpecificCulture("en-US"));
                            totals[i] = Convert.ToInt32(row["total"]);
                            i++;
                        }
                    }
                }
                graceRows[key].Total = totals[0];
                graceRows[key].PreviousTotal = totals[1];
            }
        }
    }
}

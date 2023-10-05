using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grace
{
    internal class DataGridLoader
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private Vivian vivian;
        private string connectionString;
        private DataTable dataTable = new DataTable();

        public DataGridLoader(Vivian vivian, string connectionString) {
            this.vivian = vivian;
            this.connectionString = connectionString;
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

        private void CreateLoadTable(SQLiteConnection sqliteConnection) { 
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
        /*
         * Get the last two totals 
         */
        private Row GetRow(SQLiteConnection sqliteConnection, int grace_id)
        {
            Row r = new Row();
            int[] totals = new int[2];
            string[] dates = new string[2];

            string sql = "SELECT date_field, total FROM Totals WHERE " +
                "grace_id=@grace_id ORDER BY date_field DESC LIMIT 2";


            using (SQLiteCommand command = new SQLiteCommand(sql, sqliteConnection))
            {
                command.Parameters.AddWithValue("@grace_id", grace_id);

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
            r.Total = totals[0];
            r.PreviousTotal = totals[1];

            return r;
        }
    }
}

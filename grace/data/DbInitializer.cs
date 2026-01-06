using Microsoft.Data.Sqlite;
using NLog;


namespace grace.data
{

    internal class DbInitializer
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();


        public static void CheckDbSchemaCurrent(GraceDbContext context)
        {
            EnsureArrangementTable();
            EnsureArrangementTotalTable();
            EnsureCheckedInColumn(context);
            EnsureLastUpdatedColumn(context);
            EnsureGraceNoteColumn(context);
            EnsureGraceDbNoteColumn(context);
            EnsureIsDeletedColumn(context);
            EnsureTotalsUsereColumn(context);
            EnsurePrevTotalColumn(context);
        }

        private static void EnsureIsDeletedColumn(GraceDbContext context)
        {
            const string columnName = "IsDeleted";
            const string tableName = "Collections";
            CreateColumn(columnName, tableName);
        }

        private static void EnsureLastUpdatedColumn(GraceDbContext context)
        {
            const string columnName = "LastUpdated";
            const string tableName = "GraceRows";
            CreateColumn(columnName, tableName);
        }

        private static void EnsureCheckedInColumn(GraceDbContext context)
        {
            const string columnName = "CheckedInAmount";
            const string tableName = "PulledDb";
            CreateColumn(columnName, tableName);
        }

        private static void EnsureGraceNoteColumn(GraceDbContext context)
        {
            const string columnName = "Note";
            const string tableName = "Graces";
            CreateColumnString(columnName, tableName);
        }

        private static void EnsureTotalsUsereColumn(GraceDbContext context)
        {
            const string columnName = "User";
            const string tableName = "Totals";
            CreateColumnString(columnName, tableName);
        }

        private static void EnsureGraceDbNoteColumn(GraceDbContext context)
        {
            const string columnName = "Note";
            const string tableName = "GraceRows";

            CreateColumnString(columnName, tableName);
        }

        private static void EnsurePrevTotalColumn(GraceDbContext context)
        {
            const string columnName = "PrevTotal";
            const string tableName = "GraceRows";
            CreateColumn(columnName, tableName);
        }

        private static void EnsureArrangementTable()
        {
            const string tableName = "Arrangement";
            const string createTableSql = @"
                CREATE TABLE Arrangement (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    IsDeleted INTEGER NOT NULL DEFAULT 0,
                    CollectionName TEXT NOT NULL,
                    UNIQUE(Name, CollectionName)
                )";
            EnsureTableExists(tableName, createTableSql);
        }

        private static void EnsureArrangementTotalTable()
        {
            const string tableName = "ArrangementTotals";
            const string createTableSql = @"
                CREATE TABLE ArrangementTotals (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    LastUpdated TEXT NOT NULL,
                    User TEXT NOT NULL,
                    CurrentTotal INTEGER NOT NULL DEFAULT 0,
                    ArrangementId INTEGER NOT NULL,
                    FOREIGN KEY (ArrangementId) REFERENCES Arrangement(ID) ON DELETE CASCADE
                )";
            EnsureTableExists(tableName, createTableSql);
        }

        private static void CreateColumn(string columnName, string tableName)
        {
            var connectionString = DataBase.ConnectionString;

            using var con = new SqliteConnection(connectionString);
            con.Open();

            // First check if table exists
            bool tableExists = false;
            using (var cmd = new SqliteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';", con))
            {
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tableExists = true;
                }
            }

            if (!tableExists)
            {
                // Table doesn't exist, skip column addition
                return;
            }

            // Check if column exists
            bool columnFound = false;
            using (var cmd = new SqliteCommand("PRAGMA table_info(" + tableName + ");", con))
            {
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["name"].ToString();
                    if (name == columnName)
                    {
                        columnFound = true;
                        break;
                    }
                }
            }

            if (!columnFound)
            {
                var sql = $"ALTER TABLE {tableName} ADD COLUMN {columnName} INTEGER DEFAULT 0;";
                using var cmd = new SqliteCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
        }

        private static void CreateColumnString(string columnName, string tableName)
        {
            var connectionString = DataBase.ConnectionString;

            using var con = new SqliteConnection(connectionString);
            con.Open();

            // First check if table exists
            bool tableExists = false;
            using (var cmd = new SqliteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';", con))
            {
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tableExists = true;
                }
            }

            if (!tableExists)
            {
                // Table doesn't exist, skip column addition
                return;
            }

            // Check if column exists
            bool columnFound = false;
            using (var cmd = new SqliteCommand("PRAGMA table_info(" + tableName + ");", con))
            {
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["name"].ToString();
                    if (name == columnName)
                    {
                        columnFound = true;
                        break;
                    }
                }
            }

            if (!columnFound)
            {
                var sql = $"ALTER TABLE {tableName} ADD COLUMN {columnName} TEXT DEFAULT ''";
                using var cmd = new SqliteCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Checks if a table exists in the database and creates it if it doesn't
        /// </summary>
        /// <param name="tableName">The name of the table to check/create</param>
        /// <param name="createTableSql">The SQL statement to create the table if it doesn't exist</param>
        public static void EnsureTableExists(string tableName, string createTableSql)
        {
            bool tableExists = false;
            string connectionString = DataBase.ConnectionString;

            using SqliteConnection con = new(connectionString);
            con.Open();

            // Check if table exists
            using (SqliteCommand cmd = new($"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';"))
            {
                cmd.Connection = con;
                using SqliteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tableExists = true;
                }
            }

            // Create table if it doesn't exist
            if (!tableExists)
            {
                logger.Info($"Table '{tableName}' does not exist. Creating it now.");
                using SqliteCommand cmd = new(createTableSql);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                logger.Info($"Table '{tableName}' created successfully.");
            }
            else
            {
                logger.Debug($"Table '{tableName}' already exists.");
            }

            con.Close();
        }

    }
}


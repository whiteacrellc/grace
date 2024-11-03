using NLog;
using Microsoft.Data.Sqlite;


namespace grace.data
{

    internal class DbInitializer
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();


        public static void CheckDbSchemaCurrent(GraceDbContext context)
        {
            EnsureCheckedInColumn(context);
            EnsureLastUpdatedColumn(context);
            EnsureGraceNoteColumn(context);
            EnsureGraceDbNoteColumn(context);
        }

        private static void EnsureLastUpdatedColumn(GraceDbContext context)
        {
            const string columnName = "LastUpdated";
            const string tableName = "GraceRows";
            createColumn(columnName, tableName);
        }

        private static void EnsureCheckedInColumn(GraceDbContext context)
        {
            const string columnName = "CheckedInAmount";
            const string tableName = "PulledDb";
            createColumn(columnName, tableName);
        }

        private static void EnsureGraceNoteColumn(GraceDbContext context)
        {
            const string columnName = "Note";
            const string tableName = "Graces";
            createColumnString(columnName, tableName);
        }

        private static void EnsureGraceDbNoteColumn(GraceDbContext context)
        {
            const string columnName = "Note";
            const string tableName = "GraceRows";

            createColumnString(columnName, tableName);
        }

        private static void createColumn(string columnName, string tableName)
        {
            logger.Info("creating column " + columnName + " in " + tableName);
            bool found = false;
            var connectionString = DataBase.ConnectionString;

            using (var con = new SqliteConnection(connectionString))
            {
                using (var cmd = new SqliteCommand("PRAGMA table_info(" + tableName + ");"))
                {
                    cmd.Connection = con;
                    cmd.Connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["name"].ToString();
                            if (name == columnName)
                            {
                                found = true;
                                break;
                            }
                            logger.Info($"name: {name}");
                        }
                    }
                }
                if (!found)
                {
                    var sql = $"alter table {tableName} ADD COLUMN {columnName} INT DEFAULT 0;";
                    using (var cmd = new SqliteCommand(sql))
                    {
                        cmd.Connection = con;
                        //cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
        }

        private static void createColumnString(string columnName, string tableName)
        {
            logger.Info("creating column " + columnName + " in " + tableName);
            bool found = false;
            var connectionString = DataBase.ConnectionString;

            using (var con = new SqliteConnection(connectionString))
            {
                using (var cmd = new SqliteCommand("PRAGMA table_info(" + tableName + ");"))
                {
                    cmd.Connection = con;
                    cmd.Connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["name"].ToString();
                            if (name == columnName)
                            {
                                found = true;
                                break;
                            }
                            logger.Info($"name: {name}");
                        }
                    }
                }
                if (!found)
                {
                    var sql = $"alter table {tableName} ADD COLUMN {columnName} TEXT DEFAULT ''";
                    using (var cmd = new SqliteCommand(sql))
                    {
                        cmd.Connection = con;
                        //cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
        }

    }
}


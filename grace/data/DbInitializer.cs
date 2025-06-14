﻿using Microsoft.Data.Sqlite;
using NLog;


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

        private static void CreateColumn(string columnName, string tableName)
        {
            bool found = false;
            var connectionString = DataBase.ConnectionString;

            using var con = new SqliteConnection(connectionString);
            using (var cmd = new SqliteCommand("PRAGMA table_info(" + tableName + ");"))
            {
                cmd.Connection = con;
                cmd.Connection.Open();

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["name"].ToString();
                    if (name == columnName)
                    {
                        found = true;
                        break;
                    }
                }
            }
            if (!found)
            {
                var sql = $"alter table {tableName} ADD COLUMN {columnName} INT DEFAULT 0;";
                using var cmd = new SqliteCommand(sql);
                cmd.Connection = con;
                //cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        private static void CreateColumnString(string columnName, string tableName)
        {
            bool found = false;
            string connectionString = DataBase.ConnectionString;

            using SqliteConnection con = new(connectionString);
            using (SqliteCommand cmd = new("PRAGMA table_info(" + tableName + ");"))
            {
                cmd.Connection = con;
                cmd.Connection.Open();

                using SqliteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["name"].ToString();
                    if (name == columnName)
                    {
                        found = true;
                        break;
                    }
                }
            }
            if (!found)
            {
                string sql = $"alter table {tableName} ADD COLUMN {columnName} TEXT DEFAULT ''";
                using SqliteCommand cmd = new(sql);
                cmd.Connection = con;
                //cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

    }
}


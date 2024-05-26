using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.FormattableString;

namespace grace.data
{

    internal class DbInitializer
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static void EnsureLastUpdatedColumn(GraceDbContext context)
        {
            const string columnName = "LastUpdated";
            const string tableName = "GraceRows";
            bool found = false;
            var connectionString = DataBase.ConnectionString;

            using (var con = new SQLiteConnection(connectionString))
            {
                using (var cmd = new SQLiteCommand("PRAGMA table_info(" + tableName + ");"))
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
                    var sql = $"ALTER TABLE {tableName} ADD COLUMN {columnName} DATETIME DEFAULT NULL";
                    using (var cmd = new SQLiteCommand(sql))
                    {
                        cmd.Connection = con;
                        //cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new SQLiteCommand($"DELETE FROM {tableName}"))
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


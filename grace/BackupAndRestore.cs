using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using NLog;
using grace.data;
using Microsoft.EntityFrameworkCore;

namespace grace
{
    internal class BackupAndRestore
    {
        private string sourcePath;
        private string connectionString;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        string restoredDatabasePath = "backup.db";

        public BackupAndRestore() {
            sourcePath = DataBase.DbFileName;
            connectionString = DataBase.ConnectionString;

        }

        public void BackupDatabase()
        {
            string backupFileName = GenerateFileName(restoredDatabasePath);
            BackupDatabase2(backupFileName);
        }

        internal string GenerateFileName(string baseFileName)
        {
            int version = 0;
            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Specify the database file path in the program's directory
            string newFileName = Path.Combine(programDirectory, baseFileName);
            string backupFileName = baseFileName;

            while (File.Exists(newFileName))
            {
                version++;
                backupFileName = $"{Path.GetFileNameWithoutExtension(baseFileName)}_{version}{Path.GetExtension(baseFileName)}";
                newFileName = Path.Combine(programDirectory, backupFileName);

            }

            return backupFileName;
        }

        public void RestoreDatabase()
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set properties for the file dialog
            openFileDialog.Title = "Select a .db File";
            openFileDialog.Filter = "Database Files (*.db)|*.db|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Show the file dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string selectedFilePath = openFileDialog.SafeFileName;

                // Check if the selected file has the .db extension
                if (Path.GetExtension(selectedFilePath).Equals(".db", StringComparison.OrdinalIgnoreCase))
                {
                    // Call the RestoreDatabase() function with the selected file path
                    RestoreDatabase2(selectedFilePath);
                }
                else
                {
                    MessageBox.Show("Please select a file with the .db extension.",
                        "Invalid File Type",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            

        }

        internal void BackupDatabase(string destinationPath)
        {
            logger.Info($"backing up {sourcePath} to {destinationPath}");

            using (SQLiteConnection sourceConnection = new SQLiteConnection(connectionString))
            {
                sourceConnection.Open();

                using (SQLiteConnection destinationConnection =
                    new SQLiteConnection($"Data Source={destinationPath};Mode=ReadWriteCreate;Cache=Private;"))
                {
                    destinationConnection.Open();

                    using (SQLiteCommand command = new SQLiteCommand($"ATTACH DATABASE '{destinationPath}' AS backup", sourceConnection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM sqlite_master WHERE type='table'", sourceConnection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tableName = reader["name"].ToString();
                                if (tableName.Equals("sqlite_sequence"))
                                {
                                    continue;
                                }
                                string createTableSql = reader["sql"].ToString();

                                using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableSql, destinationConnection))
                                {
                                    createTableCommand.ExecuteNonQuery();
                                }

                                using (SQLiteCommand copyTableCommand = new SQLiteCommand($"INSERT INTO backup.{tableName} SELECT * FROM {tableName}", sourceConnection))
                                {
                                    copyTableCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void RestoreDatabase(string backupDbPath)
        {
            using (SQLiteConnection sourceConnection = new SQLiteConnection($"Data Source={backupDbPath};Version=3;"))
            {
                sourceConnection.Open();

                using (SQLiteConnection destinationConnection = new SQLiteConnection($"Data Source={sourcePath};Version=3;"))
                {
                    destinationConnection.Open();

                    using (SQLiteCommand command = new SQLiteCommand($"ATTACH DATABASE '{backupDbPath}' AS backup", destinationConnection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM backup.sqlite_master WHERE type='table'", destinationConnection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tableName = reader["name"].ToString();
                                string createTableSql = reader["sql"].ToString();

                                // Delete existing table in the destination database
                                using (SQLiteCommand deleteTableCommand = new SQLiteCommand($"DROP TABLE IF EXISTS {tableName}", destinationConnection))
                                {
                                    deleteTableCommand.ExecuteNonQuery();
                                }

                                // Recreate the table in the destination database
                                using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableSql, destinationConnection))
                                {
                                    createTableCommand.ExecuteNonQuery();
                                }

                                // Copy data from source to destination
                                using (SQLiteCommand copyTableCommand = new SQLiteCommand($"INSERT INTO {tableName} SELECT * FROM backup.{tableName}", destinationConnection))
                                {
                                    copyTableCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
        }



        private void BackupDatabase2(string backupPath)
        {
            using (var context = new GraceDbContext())
            {
                context.Database.ExecuteSqlRaw($"ATTACH DATABASE '{backupPath}' AS backup");

                foreach (var entityType in context.Model.GetEntityTypes())
                {
                    var tableName = context.Model.FindEntityType(entityType.Name).GetTableName();

                    // Drop existing table in backup database
                    context.Database.ExecuteSqlRaw($"DROP TABLE IF EXISTS backup.{tableName}");

                    // Create table in backup database
                    context.Database.ExecuteSqlRaw($"CREATE TABLE backup.{tableName} AS SELECT * FROM {tableName}");
                }
            }
        }

        static void RestoreDatabase2(string backupPath)
        {
            using (var context = new GraceDbContext())
            {
                context.Database.ExecuteSqlRaw($"ATTACH DATABASE '{backupPath}' AS backup");

                foreach (var entityType in context.Model.GetEntityTypes())
                {
                    var tableName = context.Model.FindEntityType(entityType.Name).GetTableName();

                    // Drop existing table in destination database
                    context.Database.ExecuteSqlRaw($"DROP TABLE IF EXISTS {tableName}");

                    // Create table in destination database
                    context.Database.ExecuteSqlRaw($"CREATE TABLE {tableName} AS SELECT * FROM backup.{tableName}");
                }
            }
        }
    }
}



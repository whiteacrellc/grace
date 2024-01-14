using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using NLog;
using Microsoft.Extensions.Logging;

namespace grace
{
    internal class BackupAndRestore
    {
        private string sourcePath;
        private string connectionString;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();


        public BackupAndRestore() {
            sourcePath = DataBase.DbFileName;
            connectionString = DataBase.ConnectionString;

        }

        public void BackupDatabase()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set properties for the file dialog
            saveFileDialog.Title = "Create a Backup File";
            saveFileDialog.Filter = "Database Files (*.db)|*.db|All Files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            // Show the file dialog
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string selectedFilePath = saveFileDialog.FileName;

                // Ensure the selected file has the .db extension
                if (!Path.GetExtension(selectedFilePath).Equals(".db", StringComparison.OrdinalIgnoreCase))
                {
                    // Append .db extension if not present
                    selectedFilePath += ".db";
                }

                // Call the BackupDatabase() function with the selected file path
                BackupDatabase(selectedFilePath);
            }
        }

        public void RestoreDatabase()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set properties for the file dialog
            openFileDialog.Title = "Select a .db File";
            openFileDialog.Filter = "Database Files (*.db)|*.db|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            // Show the file dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string selectedFilePath = openFileDialog.FileName;

                // Check if the selected file has the .db extension
                if (Path.GetExtension(selectedFilePath).Equals(".db", StringComparison.OrdinalIgnoreCase))
                {
                    // Call the RestoreDatabase() function with the selected file path
                    RestoreDatabase(selectedFilePath);
                }
                else
                {
                    MessageBox.Show("Please select a file with the .db extension.", "Invalid File Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM backup.sqlite_master WHERE type='table'", sourceConnection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tableName = reader["name"].ToString();
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
    }
}



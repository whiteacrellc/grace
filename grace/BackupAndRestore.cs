/*
 * Copyright (c) 2025 White Acre Software LLC
 * All rights reserved.
 *
 * This software is the confidential and proprietary information
 * of White Acre Software LLC. You shall not disclose such
 * Confidential Information and shall use it only in accordance
 * with the terms of the license agreement you entered into with
 * White Acre Software LLC.
 *
 */

using grace.data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.IO;

namespace grace
{
    internal class BackupAndRestore
    {
        private readonly string connectionString;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly Mutex _mutex = new(false, "Backup_Mutex");


        public BackupAndRestore()
        {
            connectionString = DataBase.ConnectionString;
        }

        private static string ChooseBackupPath()
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "SQLite Database (*.db)|*.db",
                Title = "Choose Backup Destination"
            };
            saveFileDialog.ShowDialog();

            return saveFileDialog.FileName;
        }

        private string CheckBackUpDirectory()
        {
            string myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string graceDir = Path.Combine(myDocs, "grace");
            if (!Directory.Exists(graceDir))
            {
                // If it doesn't, create the directory
                Directory.CreateDirectory(graceDir);
            }
            string backupDir = Path.Combine(graceDir, "backup");
            if (!Directory.Exists(backupDir))
            {
                Directory.CreateDirectory(backupDir);
            }
            return backupDir;
        }

        public void BackupDatabaseToDocuments()
        {
            // Acquire the mutex
            _mutex.WaitOne();

            try
            {

                string backupDir = CheckBackUpDirectory();
                // Get the current date and time
                DateTime currentDate = DateTime.Now;

                // Format the date as YYYYMMDD
                string formattedDate = currentDate.ToString("yyyyMMdd");

                // Create the file name with the date
                string fileName = $"backup_{formattedDate}.db";
                string filePath = Path.Combine(backupDir, fileName);

                if (!File.Exists(filePath))
                {
                    BackupDatabaseToFile(filePath);
                }

            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }

        private void BackupDatabaseToFile(string backupPath)
        {
            if (string.IsNullOrEmpty(backupPath))
            {
                return;
            }

            SqliteConnection.ClearAllPools();

            // Backup the database
            if (File.Exists(backupPath))
            {
                File.Delete(backupPath);
            }

            try
            {
                logger.Info($"backing up database to {backupPath}");

                using (SqliteConnection sourceConn = new(connectionString))
                {
                    sourceConn.Open();
                    using (SqliteConnection backupConn = new($"Data Source={backupPath};Mode=ReadWriteCreate"))
                    {
                        backupConn.Open();

                        sourceConn.BackupDatabase(backupConn);

                        backupConn.Close();
                    }
                    sourceConn.Close();
                }
                logger.Info("done backing up database");
            }
            catch (IOException ex)
            {
                logger.Error($"An error occurred while deleting the file: {ex.Message}");
                // Handle the exception here
            }
            catch (Exception ex)
            {
                logger.Error($"An unexpected error occurred: {ex.Message}");
            }
        }

        public void BackupDatabase()
        {
            string backupPath = ChooseBackupPath();
            BackupDatabaseToFile(backupPath);
        }

        public void DeleteCurrentDb()
        {
            using (GraceDbContext context = new())
            {
                context.Database.EnsureDeleted();
                context.Database.CloseConnection();
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            SqliteConnection.ClearAllPools();

        }

        public void RestoreDatabase()
        {

            OpenFileDialog openFileDialog = new();

            if (openFileDialog == null)
            {
                return;
            }

            // Set properties for the file dialog
            openFileDialog.Title = "Select a .db File";
            openFileDialog.Filter = "Database Files (*.db)|*.db|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Show the file dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string selectedFilePath = openFileDialog.FileName;
                // Check if the selected file has the .db extension
                if (Path.GetExtension(selectedFilePath).Equals(".db", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        logger.Info($"restoring database from {selectedFilePath}");
                        //DeleteCurrentDb();
                        using (SqliteConnection sourceConn = new($"Data Source={selectedFilePath};Mode=ReadWriteCreate"))
                        {
                            sourceConn.Open();
                            using SqliteConnection destinationConn = new(connectionString);
                            destinationConn.Open();
                            sourceConn.BackupDatabase(destinationConn);
                        }
                        logger.Info("done restoring database");
                        DataGridLoader.LoadBindingTable(true);
                    }
                    catch (IOException ex)
                    {
                        logger.Error($"An error occurred while deleting the file: {ex.Message}");
                        // Handle the exception here
                    }
                    catch (Exception ex)
                    {
                        logger.Error($"An unexpected error occurred: {ex.Message}");
                    }
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
    }
}



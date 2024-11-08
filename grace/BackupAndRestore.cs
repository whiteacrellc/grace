﻿using System;

using System.IO;
using NLog;
using grace.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

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

        static string ChooseBackupPath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SQLite Database (*.db)|*.db";
            saveFileDialog.Title = "Choose Backup Destination";
            saveFileDialog.ShowDialog();

            return saveFileDialog.FileName;
        }

        public void BackupDatabaseToDocuments()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentsPath, "backup.db");

            if (File.Exists(filePath))
            {
                // Get the creation time of the file
                DateTime creationTime = File.GetLastAccessTime(filePath);

                // Calculate the time difference between now and the creation time
                TimeSpan difference = DateTime.Now - creationTime;

                // Only backup once a day. 
                if (difference.TotalHours > 24)
                {
                    string oldFilePath = Path.Combine(documentsPath, "backup_1.db");
                    if (File.Exists(oldFilePath))
                    {
                        // Attempt to delete the file
                        File.Delete(oldFilePath);
                    }
                    File.Move(filePath, oldFilePath);
                    BackupDatabaseToFile(filePath);
                }
            } else
            {
                BackupDatabaseToFile(filePath);
            }
        }

        private void BackupDatabaseToFile(string backupPath)
        {
            if (string.IsNullOrEmpty(backupPath))
            {
                return;
            }

            // Backup the database
            if (File.Exists(backupPath))
            {
                File.Delete(backupPath);
            }

            SqliteConnection.ClearAllPools();

            try
            {
                logger.Info($"backing up database to {backupPath}");

                using (var sourceConn = new SqliteConnection(connectionString))
                using (var backupConn = new SqliteConnection($"Data Source={backupPath};Version=3;"))
                {
                    sourceConn.Open();
                    backupConn.Open();

                    sourceConn.BackupDatabase(backupConn);
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
            using (var context = new GraceDbContext())
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

            OpenFileDialog openFileDialog = new OpenFileDialog();

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
                        using (var sourceConn = new SqliteConnection($"Data Source={selectedFilePath};Version=3;"))
                        using (var destinationConn = new SqliteConnection(connectionString))
                        {
                            sourceConn.Open();
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



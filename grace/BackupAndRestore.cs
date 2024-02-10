using System;
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

        public void BackupDatabase()
        {
            string backupPath = ChooseBackupPath();

            if (string.IsNullOrEmpty(backupPath))
            {
                return;
            }

            // Backup the database
            if (File.Exists(backupPath))
            {
                File.Delete(backupPath);
            }

            SQLiteConnection.ClearAllPools();

            try
            {
                logger.Info($"backing up database to {backupPath}");

                using (var sourceConn = new SQLiteConnection(connectionString))
                using (var backupConn = new SQLiteConnection($"Data Source={backupPath};Version=3;"))
                {
                    sourceConn.Open();
                    backupConn.Open();

                    sourceConn.BackupDatabase(backupConn, "main", "main", -1, null, 0);
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

        public void DeleteCurrentDb()
        {
            using (var context = new GraceDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.CloseConnection();
       
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            SQLiteConnection.ClearAllPools();

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
                string selectedFilePath = openFileDialog.FileName;
                // Check if the selected file has the .db extension
                if (Path.GetExtension(selectedFilePath).Equals(".db", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        logger.Info($"restoring database from {selectedFilePath}");
                        //DeleteCurrentDb();
                        using (var sourceConn = new SQLiteConnection($"Data Source={selectedFilePath};Version=3;"))
                        using (var destinationConn = new SQLiteConnection(connectionString))
                        {
                            sourceConn.Open();
                            destinationConn.Open();

                            sourceConn.BackupDatabase(destinationConn,
                                destinationConn.Database, sourceConn.Database,
                                -1, null, 10);
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



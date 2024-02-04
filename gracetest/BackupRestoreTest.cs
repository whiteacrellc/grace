using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using grace;

namespace gracetest
{
    [TestClass]
    public class BackupRestoreTest
    {
        [TestMethod]
        public void GenerateFileName_UniqueFileName()
        {
            // Arrange
            BackupAndRestore program = new BackupAndRestore();
            string baseFileName = "backup.db";
            string expectedFileName = baseFileName;

            // Act
            string result = program.GenerateFileName(baseFileName);

            // Assert
            Assert.AreEqual(expectedFileName, result);
        }

        [TestMethod]
        public void GenerateFileName_FileExists()
        {
            // Arrange
            BackupAndRestore program = new BackupAndRestore();
            string baseFileName = "backup.db";
            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string existingFilePath = Path.Combine(programDirectory, baseFileName);

            // Create a file with the same name to simulate an existing file
            File.Create(existingFilePath).Close();
            existingFilePath = Path.Combine(programDirectory, "backup_1.db");
            File.Create(existingFilePath).Close();

            // Act
            string result = program.GenerateFileName(baseFileName);

            // Assert
            Assert.AreEqual("backup_2.db", result); // The result should be different from the base file name

            // Clean up: Delete the created file
            File.Delete(existingFilePath);
            existingFilePath = Path.Combine(programDirectory, baseFileName);
            File.Delete(existingFilePath);
        }
    }
}

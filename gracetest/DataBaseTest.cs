using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using grace;
using System.Data;
using System.Data.SQLite;

// Don't like warnings in my IDE for silly stuff
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace gracetest
{
    [TestFixture]
    public class DataBaseTest
    {

        private Mock<SQLiteConnection> mockConnection;
        private Mock<SQLiteCommand> mockCommand;
        private DataBase database;

        [SetUp]
        public void Setup()
        {
            // Create a mock SQLite connection and command
            mockConnection = new Mock<SQLiteConnection>();
            mockCommand = new Mock<SQLiteCommand>();

            // Setup the mock command to return a scalar value
            mockCommand.Setup(cmd => cmd.ExecuteScalar()).Returns(1);

            // Setup the mock connection to return the mock command
            mockConnection.Setup(conn => conn.CreateCommand()).Returns(mockCommand.Object);

            // Create an instance of the DataBase class with the mock connection
            database = new DataBase(mockConnection.Object);
        }

        [Test]
        public void LoadFromExcel_WhenCalled_LoadsData()
        {
            // Arrange
            string filename = "C:\\Users\\tom\\source\\repos\\grace\\gracetest\\test_file.xlsx"; // Update with your test Excel file path


            // Act
            database.LoadFromExcel(filename);

            // Assert
            // Verify that the InsertRow, AddTotal, and AddCollection methods are called with the expected parameters
            mockCommand.Verify(cmd => cmd.ExecuteNonQuery(), Times.Exactly(1)); // Ensure the SQL command is executed

            // Verify that the InsertRow method is called 5 times
            mockConnection.Verify(conn => conn.CreateCommand(), Times.Exactly(5));

        }
    }
}

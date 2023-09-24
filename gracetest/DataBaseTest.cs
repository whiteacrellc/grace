using grace;
using System.Data.SQLite;

// Don't like warnings in my IDE for silly stuff
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
/*-----------------------------------------------------------------------------*/
namespace gracetest
{

    [TestClass]
    public class DataBaseTest
    {
        private string testDbFile = "testgrace.db";
        private string connectionString = string.Empty;

        [TestMethod]
        public void TestMethod_LoadFromExcel()
        {
            string testConnectString = "Data Source=C:\\Users\\tom\\source\\" + 
                "repos\\grace\\gracetest\\bin\\Debug\\net6.0-windows\\" + 
                "testgrace.db;Version=3;";

            // Create a mock SQLite connection and command
            DataBase database = new DataBase(testDbFile);
            connectionString = database.ConnectionString;
            Assert.IsNotNull(connectionString);

            Assert.AreEqual(connectionString, testConnectString);

            string filename = "C:\\Users\\tom\\source\\repos\\grace\\gracetest\\" 
                + "test_file.xlsx";
            database.LoadFromExcel(filename);

            var fileName = database.DbFileName;
            Cleanup(fileName);
        }

        private void Cleanup(string databaseName)
        {
            var sqliteConnection = new SQLiteConnection(connectionString);
            sqliteConnection.Open();

            string dropSql = "DROP TABLE IF EXISTS Grace;DROP TABLE IF EXISTS" 
                + " Collections;DROP TABLE IF EXISTS Totals;";
            using (SQLiteCommand command = new SQLiteCommand(dropSql, sqliteConnection))
            {
                command.ExecuteNonQuery();
            }
            sqliteConnection.Dispose();
          
            try
            {
                if (File.Exists(databaseName))
                {
                    File.Delete(databaseName);
                }
                else
                {
                    Console.WriteLine("Database does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


    }
}
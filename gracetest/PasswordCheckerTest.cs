/*
 * Copyright (c) 2023 White Acre Software LLC
 * All rights reserved.
 *
 * This software is the confidential and proprietary information
 * of White Acre Software LLC. You shall not disclose such
 * Confidential Information and shall use it only in accordance
 * with the terms of the license agreement you entered into with
 * White Acre Software LLC.
 *
 * Year: 2023
 */
using grace;
using grace.data;
using grace.data.models;
using grace.utils;

namespace gracetest
{
    [TestClass]
    public class PasswordCheckerTests
    {
        private const string TestDbName = "passwordchecker_test.db";
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private DataBase TestDataBase;
        private GraceDbContext TestDbContext;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            // This sets the static DataBase.ConnectionString, which GraceDbContext will pick up.
            TestDataBase = new DataBase(TestDbName);
            TestDbContext = new GraceDbContext(); // Uses the connection string from TestDataBase
            TestDbContext.Database.EnsureCreated();

            // Seed initial data
            SeedUsers();
        }

        private void SeedUsers()
        {
            var existingUser = TestDbContext.Users.FirstOrDefault(u => u.Username == "testuser");
            if (existingUser == null)
            {
                TestDbContext.Users.Add(new User { Username = "testuser", Password = "password123", Admin = false, ResetPassword = false, ResetAnswerIndex = 0, ResetAnswer = "" });
            }

            var adminUser = TestDbContext.Users.FirstOrDefault(u => u.Username == "adminuser");
            if (adminUser == null)
            {
                TestDbContext.Users.Add(new User { Username = "adminuser", Password = "adminpassword", Admin = true, ResetPassword = false, ResetAnswerIndex = 0, ResetAnswer = "" });
            }
            TestDbContext.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestDbContext.Database.EnsureDeleted();
            TestDbContext.Dispose(); // Dispose the context

            // DataBase class itself doesn't implement IDisposable,
            // but we ensure the file it created is deleted.
            // The actual DataBase.DbFileName is set within the DataBase class constructor.
            // We rely on the specific implementation detail that DataBase.CreateDatabaseFile()
            // sets DbFileName to be Path.Combine(programDirectory, this.DbName).
            // For tests, programDirectory is effectively the test execution directory.
            // GraceDbContext also uses DataBase.ConnectionString to establish its connection.
            // The DataBase class sets DbFileName based on the name passed to its constructor.
            // So, we need to construct the path to this db file to delete it.
            string programDirectory = Directory.GetCurrentDirectory();
            string dbPath = Path.Combine(programDirectory, TestDbName);

            if (File.Exists(dbPath))
            {
                try
                {
                    File.Delete(dbPath);
                }
                catch (IOException ex)
                {
                    // Log or handle error if file is locked
                    System.Diagnostics.Debug.WriteLine($"Could not delete test database: {dbPath}. Error: {ex.Message}");
                }
            }
        }

        [TestMethod]
        public void IsPasswordValid_PasswordMeetsCriteria_ReturnsTrue()
        {
            // Arrange
            string validPassword = "SecureP@ssw0rd";

            // Act
            bool isValid = PasswordChecker.IsPasswordValid(validPassword);

            // Assert
            Assert.IsTrue(isValid); // Current IsPasswordValid only checks length >= 4
        }

        [TestMethod]
        public void IsPasswordValid_PasswordTooShort_ReturnsFalse()
        {
            // Arrange
            string shortPassword = "Sho"; // Length 3

            // Act
            bool isValid = PasswordChecker.IsPasswordValid(shortPassword);

            // Assert
            Assert.IsFalse(isValid); // Current IsPasswordValid only checks length >= 4
        }

        /*
         * patster said that password security was not needed
        [TestMethod]
        public void PasswordWithoutUpperCase_ReturnsFalse()
        {
            // Arrange
            string passwordWithoutUpperCase = "nocapitalletters123!";

            // Act
            bool isValid = PasswordChecker.IsPasswordValid(passwordWithoutUpperCase);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void PasswordWithoutDigit_ReturnsFalse()
        {
            // Arrange
            string passwordWithoutDigit = "NoNumbersOrSpecialChar!";

            // Act
            bool isValid = PasswordChecker.IsPasswordValid(passwordWithoutDigit);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void PasswordWithoutSpecialCharacter_ReturnsFalse()
        {
            // Arrange
            string passwordWithoutSpecialChar = "NoSpecialCharacter123";

            // Act
            bool isValid = PasswordChecker.IsPasswordValid(passwordWithoutSpecialChar);

            // Assert
            Assert.IsFalse(isValid);
        }
        */

        // --- Tests for CheckPassword ---
        [TestMethod]
        public void CheckPassword_CorrectCredentials_ReturnsTrue()
        {
            // Arrange (User "testuser" with password "password123" is seeded in Setup)

            // Act
            bool result = PasswordChecker.CheckPassword("testuser", "password123");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckPassword_IncorrectPassword_ReturnsFalse()
        {
            // Arrange (User "testuser" is seeded)

            // Act
            bool result = PasswordChecker.CheckPassword("testuser", "wrongpassword");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckPassword_UserNotFound_ReturnsFalse()
        {
            // Arrange

            // Act
            bool result = PasswordChecker.CheckPassword("nonexistentuser", "anypassword");

            // Assert
            Assert.IsFalse(result);
        }

        // --- Tests for IsUserAdmin ---
        [TestMethod]
        public void IsUserAdmin_UserIsAdmin_ReturnsTrue()
        {
            // Arrange (User "adminuser" is seeded as admin)

            // Act
            bool result = PasswordChecker.IsUserAdmin("adminuser");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsUserAdmin_UserIsNotAdmin_ReturnsFalse()
        {
            // Arrange (User "testuser" is seeded as not admin)

            // Act
            bool result = PasswordChecker.IsUserAdmin("testuser");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsUserAdmin_UserNotFound_ReturnsFalse()
        {
            // Arrange

            // Act
            bool result = PasswordChecker.IsUserAdmin("nonexistentuser");

            // Assert
            Assert.IsFalse(result);
        }

        // --- Tests for ResetPassword ---
        [TestMethod]
        public void ResetPassword_UserRequiresReset_ReturnsTrue()
        {
            // Arrange
            var user = TestDbContext.Users.First(u => u.Username == "testuser");
            user.ResetPassword = true;
            TestDbContext.SaveChanges();

            // Act
            bool result = PasswordChecker.ResetPassword("testuser");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ResetPassword_UserDoesNotRequireReset_ReturnsFalse()
        {
            // Arrange
            var user = TestDbContext.Users.First(u => u.Username == "testuser");
            user.ResetPassword = false;
            TestDbContext.SaveChanges();

            // Act
            bool result = PasswordChecker.ResetPassword("testuser");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ResetPassword_UserNotFound_ReturnsFalse()
        {
            // Arrange
            // No specific arrangement needed as user won't be found

            // Act
            bool result = PasswordChecker.ResetPassword("nonexistentuser");

            // Assert
            Assert.IsFalse(result);
        }

        // --- Tests for SetResetFlag ---
        [TestMethod]
        public void SetResetFlag_UserExists_SetsFlagAndReturnsTrue()
        {
            // Arrange
            var user = TestDbContext.Users.First(u => u.Username == "testuser");
            user.ResetPassword = false; // Ensure it's initially false
            TestDbContext.SaveChanges();

            // Act
            bool result = PasswordChecker.SetResetFlag("testuser");

            // Assert
            Assert.IsTrue(result);
            TestDbContext.Entry(user).Reload(); // Reload user from DB to check updated value
            Assert.IsTrue(user.ResetPassword);
        }

        [TestMethod]
        public void SetResetFlag_UserNotFound_ReturnsFalse()
        {
            // Arrange

            // Act
            bool result = PasswordChecker.SetResetFlag("nonexistentuser");

            // Assert
            Assert.IsFalse(result);
        }

        // --- Tests for ResetIndex ---
        [TestMethod]
        public void ResetIndex_UserExists_ReturnsCorrectIndex()
        {
            // Arrange
            var user = TestDbContext.Users.First(u => u.Username == "testuser");
            user.ResetAnswerIndex = 5;
            TestDbContext.SaveChanges();

            // Act
            int result = PasswordChecker.ResetIndex("testuser");

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void ResetIndex_UserNotFound_ReturnsMinusOne()
        {
            // Arrange

            // Act
            int result = PasswordChecker.ResetIndex("nonexistentuser");

            // Assert
            Assert.AreEqual(-1, result);
        }

        // --- Tests for UpdateResetAnswer ---
        [TestMethod]
        public void UpdateResetAnswer_UserExists_UpdatesAnswerAndIndexAndReturnsTrue()
        {
            // Arrange
            var user = TestDbContext.Users.First(u => u.Username == "testuser");
            user.ResetAnswer = "old_answer";
            user.ResetAnswerIndex = 1;
            TestDbContext.SaveChanges();

            // Act
            bool result = PasswordChecker.UpdateResetAnswer("testuser", 2, "new_answer");

            // Assert
            Assert.IsTrue(result);
            TestDbContext.Entry(user).Reload();
            Assert.AreEqual("new_answer", user.ResetAnswer);
            Assert.AreEqual(2, user.ResetAnswerIndex);
        }

        [TestMethod]
        public void UpdateResetAnswer_UserNotFound_ReturnsFalse()
        {
            // Arrange

            // Act
            bool result = PasswordChecker.UpdateResetAnswer("nonexistentuser", 1, "any_answer");

            // Assert
            Assert.IsFalse(result);
        }
    }
}

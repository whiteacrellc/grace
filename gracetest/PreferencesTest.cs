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
using grace; // For DataBase, Globals
using grace.data; // For Preferences, GraceDbContext
using grace.data.models; // For Prefs

namespace gracetest
{
    [TestClass]
    public class PreferencesTests
    {
        private const string TestDbName = "preferences_test.db";
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private DataBase TestDataBase;
        private GraceDbContext TestDbContext;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            TestDataBase = new DataBase(TestDbName); // Sets static DB connection string
            TestDbContext = new GraceDbContext();    // Uses the static connection string

            TestDbContext.Database.EnsureDeleted(); // Clean slate for each test
            TestDbContext.Database.EnsureCreated();

            // InitializeDatabase calls InitPrefs, which might be important for default preference setup
            // or ensuring the Prefs table is correctly configured if it relies on initial values.
            // It also clears some tables (like Graces), so it's good for a clean start.
            DataBase.InitializeDatabase();
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestDbContext.Database.EnsureDeleted();
            TestDbContext.Dispose();

            string programDirectory = Directory.GetCurrentDirectory();
            string dbPath = Path.Combine(programDirectory, TestDbName);
            if (File.Exists(dbPath))
            {
                try { File.Delete(dbPath); }
                catch (IOException ex) { System.Diagnostics.Debug.WriteLine($"Could not delete test database: {dbPath}. Error: {ex.Message}"); }
            }
        }

        // --- Test AddOrUpdateStringPreference ---
        [TestMethod]
        public void AddOrUpdateStringPreference_AddNew_SavesToDb()
        {
            // Arrange
            var prefKey = Preferences.Preference.RowHeight; // Using an existing enum for test
            string testValue = "TestValue123";

            // Act
            Preferences.AddOrUpdateStringPreference(prefKey, testValue);

            // Assert
            var prefInDb = TestDbContext.PrefsDb.FirstOrDefault(p => p.Name == prefKey.ToString());
            Assert.IsNotNull(prefInDb, "Preference should be saved to the database.");
            Assert.AreEqual(testValue, prefInDb.Value, "Saved value mismatch.");
        }

        [TestMethod]
        public void AddOrUpdateStringPreference_UpdateExisting_UpdatesInDb()
        {
            // Arrange
            var prefKey = Preferences.Preference.RowsPerPage;
            string initialValue = "Initial";
            string updatedValue = "Updated";
            Preferences.AddOrUpdateStringPreference(prefKey, initialValue); // Add initial

            // Act
            Preferences.AddOrUpdateStringPreference(prefKey, updatedValue); // Update

            // Assert
            var prefInDb = TestDbContext.PrefsDb.FirstOrDefault(p => p.Name == prefKey.ToString());
            Assert.IsNotNull(prefInDb);
            Assert.AreEqual(updatedValue, prefInDb.Value, "Value should be updated.");
            Assert.AreEqual(1, TestDbContext.PrefsDb.Count(p => p.Name == prefKey.ToString()), "Should only be one entry for the preference.");
        }

        // --- Test AddOrUpdateIntPreference ---
        [TestMethod]
        public void AddOrUpdateIntPreference_AddNew_SavesToDbAsString()
        {
            // Arrange
            var prefKey = Preferences.Preference.HeaderHeight;
            int testValue = 123;

            // Act
            Preferences.AddOrUpdateIntPreference(prefKey, testValue);

            // Assert
            var prefInDb = TestDbContext.PrefsDb.FirstOrDefault(p => p.Name == prefKey.ToString());
            Assert.IsNotNull(prefInDb);
            Assert.AreEqual(testValue.ToString(), prefInDb.Value, "Integer value should be saved as string.");
        }

        // --- Test AddOrUpdateBooleanPreference ---
        [TestMethod]
        public void AddOrUpdateBooleanPreference_AddNewTrue_SavesToDbAsLowercaseTrueString()
        {
            // Arrange
            var prefKey = Preferences.Preference.BarCodeAutoOpen;
            bool testValue = true;

            // Act
            Preferences.AddOrUpdateBooleanPreference(prefKey, testValue);

            // Assert
            var prefInDb = TestDbContext.PrefsDb.FirstOrDefault(p => p.Name == prefKey.ToString());
            Assert.IsNotNull(prefInDb);
            Assert.AreEqual("true", prefInDb.Value.ToLowerInvariant(), "Boolean true should be saved as 'true' (case-insensitive check).");
        }

        [TestMethod]
        public void AddOrUpdateBooleanPreference_AddNewFalse_SavesToDbAsLowercaseFalseString()
        {
            // Arrange
            var prefKey = Preferences.Preference.Tuesday; // Using another enum member
            bool testValue = false;

            // Act
            Preferences.AddOrUpdateBooleanPreference(prefKey, testValue);

            // Assert
            var prefInDb = TestDbContext.PrefsDb.FirstOrDefault(p => p.Name == prefKey.ToString());
            Assert.IsNotNull(prefInDb);
            Assert.AreEqual("false", prefInDb.Value.ToLowerInvariant(), "Boolean false should be saved as 'false' (case-insensitive check).");
        }

        // --- Test GetStringValue ---
        [TestMethod]
        public void GetStringValue_Existing_ReturnsCorrectValue()
        {
            // Arrange
            var prefKey = Preferences.Preference.RowHeight;
            string expectedValue = "Test Str";
            Preferences.AddOrUpdateStringPreference(prefKey, expectedValue);

            // Act
            string actualValue = Preferences.GetStringValue(prefKey);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void GetStringValue_NonExistent_ReturnsNull()
        {
            // Arrange
            var nonExistentKey = Preferences.Preference.Tuesday; // Assuming this wasn't added by InitPrefs or other tests

            // Act
            string actualValue = Preferences.GetStringValue(nonExistentKey);

            // Assert
            Assert.IsNull(actualValue, "Getting a non-existent string preference should return null.");
        }

        // --- Test GetIntValue ---
        [TestMethod]
        public void GetIntValue_ExistingAndValid_ReturnsCorrectValue()
        {
            // Arrange
            var prefKey = Preferences.Preference.RowsPerPage;
            int expectedValue = 42;
            Preferences.AddOrUpdateIntPreference(prefKey, expectedValue);

            // Act
            int actualValue = Preferences.GetIntValue(prefKey);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void GetIntValue_NonExistent_ReturnsZero()
        {
            // Arrange
            var nonExistentKey = Preferences.Preference.HeaderHeight;

            // Act
            int actualValue = Preferences.GetIntValue(nonExistentKey);

            // Assert
            Assert.AreEqual(0, actualValue, "Getting a non-existent int preference should return 0.");
        }

        [TestMethod]
        public void GetIntValue_InvalidFormatInDb_ReturnsZero()
        {
            // Arrange
            var prefKey = Preferences.Preference.RowHeight;
            // Manually insert an invalid integer format
            TestDbContext.PrefsDb.Add(new Prefs { Name = prefKey.ToString(), Value = "not-an-int" });
            TestDbContext.SaveChanges();

            // Act
            int actualValue = Preferences.GetIntValue(prefKey);

            // Assert
            Assert.AreEqual(0, actualValue, "Getting an int preference with invalid format should return 0.");
            // Also, NLog would log an error, but direct log output testing is complex here.
        }

        // --- Test GetBooleanValue ---
        [TestMethod]
        public void GetBooleanValue_ExistingAndTrue_ReturnsTrue()
        {
            // Arrange
            var prefKey = Preferences.Preference.BarCodeAutoOpen;
            Preferences.AddOrUpdateBooleanPreference(prefKey, true);

            // Act
            bool actualValue = Preferences.GetBooleanValue(prefKey);

            // Assert
            Assert.IsTrue(actualValue);
        }

        [TestMethod]
        public void GetBooleanValue_ExistingAndFalse_ReturnsFalse()
        {
            // Arrange
            var prefKey = Preferences.Preference.BarCodeAutoOpen;
            Preferences.AddOrUpdateBooleanPreference(prefKey, false);

            // Act
            bool actualValue = Preferences.GetBooleanValue(prefKey);

            // Assert
            Assert.IsFalse(actualValue);
        }

        [TestMethod]
        public void GetBooleanValue_ExistingAndMixedCaseTrueString_ReturnsTrue()
        {
            // Arrange
            var prefKey = Preferences.Preference.BarCodeAutoOpen;
            TestDbContext.PrefsDb.Add(new Prefs { Name = prefKey.ToString(), Value = "TrUe" });
            TestDbContext.SaveChanges();

            // Act
            bool actualValue = Preferences.GetBooleanValue(prefKey);

            // Assert
            Assert.IsTrue(actualValue, "Boolean.Parse should handle mixed case 'true'.");
        }


        [TestMethod]
        public void GetBooleanValue_NonExistent_ReturnsFalse()
        {
            // Arrange
            var nonExistentKey = Preferences.Preference.Tuesday;

            // Act
            bool actualValue = Preferences.GetBooleanValue(nonExistentKey);

            // Assert
            Assert.IsFalse(actualValue, "Getting a non-existent boolean preference should return false.");
        }

        [TestMethod]
        public void GetBooleanValue_InvalidFormatInDb_ReturnsFalse()
        {
            // Arrange
            var prefKey = Preferences.Preference.BarCodeAutoOpen;
            TestDbContext.PrefsDb.Add(new Prefs { Name = prefKey.ToString(), Value = "not-a-bool" });
            TestDbContext.SaveChanges();

            // Act
            bool actualValue = Preferences.GetBooleanValue(prefKey);

            // Assert
            Assert.IsFalse(actualValue, "Getting a boolean preference with invalid format should return false.");
        }
    }
}

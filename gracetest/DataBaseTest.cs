
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
using Microsoft.EntityFrameworkCore;
using System.Data;

// Don't like warnings in my IDE for silly stuff
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8600
/*-----------------------------------------------------------------------------*/
namespace gracetest
{

    [TestClass]
    public class DataBaseTest
    {
        private string testDbFile = "test_grace.db";
        private string connectionString = string.Empty;
        private Dictionary<int, int> rowHash = new();
        private int testUserId;
        private int testCollectionId;

        [TestInitialize]
        public void Setup()
        {
            // Create a test database instance
            var dataBase = new DataBase(testDbFile);
            connectionString = DataBase.ConnectionString;
            DataBase.InitializeDatabase();

            // Set a current user for operations that require it
            Globals.GetInstance().CurrentUser = "testuser";

            // Create test users
            CreateTestUsers();
        }

        [TestCleanup]
        public void Cleanup()
        {
            var fileName = DataBase.DbFileName;
            Globals.GetInstance().CurrentUser = null;
            Cleanup(fileName);
        }

        private void CreateTestUsers()
        {
            using var context = new GraceDbContext();
            var user1 = new User
            {
                Username = "testuser",
                Password = "password123",
                Admin = true,
                ResetPassword = false,
                Deleted = false
            };
            context.Users.Add(user1);

            var user2 = new User
            {
                Username = "regularuser",
                Password = "password456",
                Admin = false,
                ResetPassword = false,
                Deleted = false
            };
            context.Users.Add(user2);

            context.SaveChanges();
            testUserId = user1.ID;
        }

        private void CreateTestData()
        {
            for (var i = 0; i < 20; i++)
            {
                int graceId = 0;
                using (var context = new GraceDbContext())
                {
                    var grace = new Grace
                    {
                        Brand = "Brand" + (i % 3),
                        Sku = "SKU" + i.ToString("D4"),
                        Description = "Test Description " + i,
                        BarCode = i.ToString("D8"),
                        Availability = "Available",
                        Note = "Test note " + i,
                        Deleted = false
                    };
                    context.Graces.Add(grace);
                    context.SaveChanges();
                    graceId = grace.ID;
                }

                // Add total with some variation
                DataBase.AddTotal((i * 5) + 10, graceId);

                // Add multiple totals for some items to test history
                if (i % 3 == 0)
                {
                    System.Threading.Thread.Sleep(10); // Ensure different timestamps
                    DataBase.AddTotal((i * 5) + 15, graceId);
                }

                // Add collections with different patterns
                var collectionNum = i % 4;
                var collectionId1 = DataBase.AddCollection("Collection" + collectionNum, graceId);
                if (i == 0)
                {
                    testCollectionId = collectionId1;
                }

                if (i % 3 == 0)
                {
                    DataBase.AddCollection("Premium", graceId);
                }
                if (i % 4 == 0)
                {
                    DataBase.AddCollection("Special", graceId);
                }

                // Always add "Other" collection
                DataBase.AddCollection("Other", graceId);

                // Create the denormalized GraceRow
                int graceRowId = DataBase.CreateGraceRow(graceId);
                rowHash.Add(graceRowId, graceId);

                // Create some pulled records for checkout testing
                if (i % 5 == 0)
                {
                    using var context = new GraceDbContext();
                    var pulled = new Pulled
                    {
                        GraceId = graceId,
                        UserId = testUserId,
                        CollectionId = collectionId1,
                        Amount = 5,
                        CurrentTotal = (i * 5) + 10,
                        LastUpdated = DateTime.Now,
                        IsCompleted = false,
                        Comment = "Test checkout"
                    };
                    context.PulledDb.Add(pulled);
                    context.SaveChanges();
                }
            }
        }

        [TestMethod]
        public void TestMethod_CreateGraceRow()
        {
            CreateTestData();
            Assert.AreEqual(20, rowHash.Keys.Count);

            // Verify GraceRow was created correctly
            using var context = new GraceDbContext();
            var firstElement = rowHash.FirstOrDefault();
            int graceId = firstElement.Value;
            var grace = context.Graces.Find(graceId);
            Assert.IsNotNull(grace);

            var sku = grace.Sku;
            Assert.IsNotNull(sku);

            var graceRow = DataBase.GetGraceRowFromSku(sku);
            Assert.IsNotNull(graceRow);
            Assert.IsTrue(graceRow.Total > 0);
            Assert.IsTrue(graceRow.Description.Contains("Description"));
            Assert.IsNotNull(graceRow.Col1);
            Assert.IsTrue(graceRow.Col1.Contains("Collection") || graceRow.Col1.Contains("Premium") || graceRow.Col1.Contains("Special"));
            Assert.IsNull(graceRow.Col4);
            Assert.IsNull(graceRow.Col5);
            Assert.IsNull(graceRow.Col6);

            // Test cascade deletion
            context.Graces.Remove(grace);
            context.SaveChanges();

            // Make sure grace row is deleted
            graceRow = context.GraceRows.FirstOrDefault(item => item.GraceId == graceId);
            Assert.IsNull(graceRow);

            // Make sure collection rows are deleted
            var collectionRows = context.Collections
                .Where(e => e.GraceId == graceId)
                .ToList();
            Assert.AreEqual(0, collectionRows.Count);

            // Make sure total rows are deleted
            var totalRows = context.Totals
                   .Where(e => e.GraceId == graceId)
                   .ToList();
            Assert.AreEqual(0, totalRows.Count);
        }

        [TestMethod]
        public void TestMethod_UpdateGraceRow()
        {
            CreateTestData();

            using var context = new GraceDbContext();
            var firstElement = rowHash.FirstOrDefault();
            int graceId = firstElement.Value;

            // Update the Grace entity
            var grace = context.Graces.Find(graceId);
            Assert.IsNotNull(grace);
            grace.Description = "Updated Description";
            grace.Note = "Updated Note";
            context.SaveChanges();

            // Update the GraceRow
            DataBase.UpdateGraceRow(graceId);

            // Verify the update
            var graceRow = context.GraceRows.FirstOrDefault(gr => gr.GraceId == graceId);
            Assert.IsNotNull(graceRow);
            Assert.AreEqual("Updated Description", graceRow.Description);
            Assert.AreEqual("Updated Note", graceRow.Note);
        }

        [TestMethod]
        public void TestMethod_GetPulledGrid()
        {
            CreateTestData();

            var pulledGrid = DataBase.GetPulledGrid();

            Assert.IsNotNull(pulledGrid);
            Assert.AreEqual(20, pulledGrid.Rows.Count);
            Assert.IsTrue(pulledGrid.Columns.Contains("Sku"));
            Assert.IsTrue(pulledGrid.Columns.Contains("Description"));
            Assert.IsTrue(pulledGrid.Columns.Contains("Brand"));
            Assert.IsTrue(pulledGrid.Columns.Contains("BarCode"));
            Assert.IsTrue(pulledGrid.Columns.Contains("Total"));
            Assert.IsTrue(pulledGrid.Columns.Contains("GraceId"));
        }

        [TestMethod]
        public void TestMethod_GetPulledGridFromBarCode()
        {
            CreateTestData();

            // Test with a specific barcode
            var filteredView = DataBase.GetPulledGridFromBarCode("00000005");

            Assert.IsNotNull(filteredView);
            Assert.IsTrue(filteredView.Count > 0);

            // Verify the filtered results contain the barcode
            foreach (DataRowView row in filteredView)
            {
                var barcode = row["BarCode"].ToString();
                Assert.IsTrue(barcode.Contains("00000005"));
            }
        }

        [TestMethod]
        public void TestMethod_GetPulledGridFromBarCode_Empty()
        {
            CreateTestData();

            // Test with empty barcode returns all rows
            var allView = DataBase.GetPulledGridFromBarCode("");

            Assert.IsNotNull(allView);
            Assert.AreEqual(20, allView.Count);
        }

        [TestMethod]
        public void TestMethod_GetCheckedOutGrid()
        {
            CreateTestData();

            var checkedOutGrid = DataBase.GetCheckedOutGrid(testUserId);

            Assert.IsNotNull(checkedOutGrid);
            // We created pulled records for items where i % 5 == 0, so 4 items (0, 5, 10, 15)
            Assert.AreEqual(4, checkedOutGrid.Rows.Count);
            Assert.IsTrue(checkedOutGrid.Columns.Contains("UserName"));
            Assert.IsTrue(checkedOutGrid.Columns.Contains("Sku"));
            Assert.IsTrue(checkedOutGrid.Columns.Contains("Collection"));
            Assert.IsTrue(checkedOutGrid.Columns.Contains("UserTotal"));
        }

        [TestMethod]
        public void TestMethod_GetCheckedOutGridAll()
        {
            CreateTestData();

            var allCheckedOut = DataBase.GetCheckedOutGridAll();

            Assert.IsNotNull(allCheckedOut);
            Assert.AreEqual(4, allCheckedOut.Rows.Count);
        }

        [TestMethod]
        public void TestMethod_GetCheckedOutReport()
        {
            CreateTestData();

            var reportTable = DataBase.GetCheckedOutReport();

            Assert.IsNotNull(reportTable);
            Assert.IsTrue(reportTable.Rows.Count > 0);
            Assert.IsTrue(reportTable.Columns.Contains("Sku"));
            Assert.IsTrue(reportTable.Columns.Contains("Brand"));
            Assert.IsTrue(reportTable.Columns.Contains("User"));
            Assert.IsTrue(reportTable.Columns.Contains("Total"));
            Assert.IsTrue(reportTable.Columns.Contains("PrevTotal"));
            Assert.IsTrue(reportTable.Columns.Contains("LastUpdated"));
        }

        [TestMethod]
        public void TestMethod_AddTotal_NoDuplicate()
        {
            CreateTestData();

            using var context = new GraceDbContext();
            var firstGrace = context.Graces.First();
            int graceId = firstGrace.ID;

            // Get current total count
            var initialCount = context.Totals.Count(t => t.GraceId == graceId);

            // Get the current total value
            var currentTotal = context.Totals
                .Where(t => t.GraceId == graceId)
                .OrderByDescending(t => t.ID)
                .First();

            // Try to add the same total - should not create a new record
            var result = DataBase.AddTotal(currentTotal.CurrentTotal, graceId);

            var finalCount = context.Totals.Count(t => t.GraceId == graceId);

            // Count should remain the same
            Assert.AreEqual(initialCount, finalCount);
        }

        [TestMethod]
        public void TestMethod_AddTotal_WithChange()
        {
            CreateTestData();

            using var context = new GraceDbContext();
            var firstGrace = context.Graces.First();
            int graceId = firstGrace.ID;

            var initialCount = context.Totals.Count(t => t.GraceId == graceId);

            // Add a different total - should create a new record
            var newTotalId = DataBase.AddTotal(999, graceId);

            var finalCount = context.Totals.Count(t => t.GraceId == graceId);

            Assert.AreEqual(initialCount + 1, finalCount);
            Assert.IsTrue(newTotalId > 0);

            // Verify the new total was saved correctly
            var savedTotal = context.Totals.Find(newTotalId);
            Assert.IsNotNull(savedTotal);
            Assert.AreEqual(999, savedTotal.CurrentTotal);
            Assert.AreEqual("testuser", savedTotal.User);
        }

        [TestMethod]
        public void TestMethod_GetGraceIdFromSku()
        {
            CreateTestData();

            var sku = "SKU0000";
            var graceId = DataBase.GetGraceIdFromSku(sku);

            Assert.IsTrue(graceId > 0);

            using var context = new GraceDbContext();
            var grace = context.Graces.Find(graceId);
            Assert.IsNotNull(grace);
            Assert.AreEqual(sku, grace.Sku);
        }

        [TestMethod]
        public void TestMethod_GetGraceIdFromSku_NotFound()
        {
            CreateTestData();

            var graceId = DataBase.GetGraceIdFromSku("NONEXISTENT");

            Assert.AreEqual(0, graceId);
        }

        [TestMethod]
        public void TestMethod_GetGraceRowFromSku()
        {
            CreateTestData();

            var sku = "SKU0001";
            var graceRow = DataBase.GetGraceRowFromSku(sku);

            Assert.IsNotNull(graceRow);
            Assert.AreEqual(sku, graceRow.Sku);
            Assert.IsTrue(graceRow.Total > 0);
        }

        [TestMethod]
        public void TestMethod_GetUserIdFromName()
        {
            var userId = DataBase.GetUserIdFromName("testuser");

            Assert.IsTrue(userId > 0);
            Assert.AreEqual(testUserId, userId);
        }

        [TestMethod]
        public void TestMethod_GetUserIdFromName_NotFound()
        {
            var userId = DataBase.GetUserIdFromName("nonexistentuser");

            Assert.AreEqual(0, userId);
        }

        [TestMethod]
        public void TestMethod_GetCollections()
        {
            CreateTestData();

            var collections = DataBase.GetCollections();

            Assert.IsNotNull(collections);
            Assert.IsTrue(collections.Count > 0);
            // "Other" should be excluded
            Assert.IsFalse(collections.Contains("Other"));
            // Should be ordered alphabetically
            Assert.IsTrue(collections.Contains("Collection0"));
            Assert.IsTrue(collections.Contains("Premium"));
        }

        [TestMethod]
        public void TestMethod_GetBrandNames()
        {
            CreateTestData();

            var brands = DataBase.GetBrandNames();

            Assert.IsNotNull(brands);
            Assert.IsTrue(brands.Count > 0);
            Assert.IsTrue(brands.Contains("Brand0"));
            Assert.IsTrue(brands.Contains("Brand1"));
            Assert.IsTrue(brands.Contains("Brand2"));
        }

        [TestMethod]
        public void TestMethod_AddCollectionRow()
        {
            CreateTestData();

            using var context = new GraceDbContext();
            var firstGrace = context.Graces.First();
            int graceId = firstGrace.ID;

            // Add a new collection
            var result = DataBase.AddCollectionRow(graceId, "NewCollection");

            Assert.IsTrue(result);

            // Verify it was added
            var collection = context.Collections
                .FirstOrDefault(c => c.GraceId == graceId && c.Name == "NewCollection");
            Assert.IsNotNull(collection);

            // Try to add the same collection again - should return false
            var duplicateResult = DataBase.AddCollectionRow(graceId, "NewCollection");
            Assert.IsFalse(duplicateResult);
        }

        [TestMethod]
        public void TestMethod_DeleteCollectionRow()
        {
            CreateTestData();

            using var context = new GraceDbContext();
            var firstGrace = context.Graces.First();
            int graceId = firstGrace.ID;

            // Get an existing collection
            var existingCollection = context.Collections
                .First(c => c.GraceId == graceId && c.Name != "Other");
            string collectionName = existingCollection.Name;

            // Delete it
            var result = DataBase.DeleteCollectionRow(graceId, collectionName);

            Assert.IsTrue(result);

            // Verify it was deleted
            var deleted = context.Collections
                .FirstOrDefault(c => c.GraceId == graceId && c.Name == collectionName);
            Assert.IsNull(deleted);

            // Try to delete again - should return false
            var secondResult = DataBase.DeleteCollectionRow(graceId, collectionName);
            Assert.IsFalse(secondResult);
        }

        [TestMethod]
        public void TestMethod_CheckCollectionExists()
        {
            CreateTestData();

            var exists = DataBase.CheckCollectionExists("Collection0");
            Assert.IsTrue(exists);

            var notExists = DataBase.CheckCollectionExists("NonExistentCollection");
            Assert.IsFalse(notExists);
        }

        [TestMethod]
        public void TestMethod_GetCollections_ByGraceId()
        {
            CreateTestData();

            using var context = new GraceDbContext();
            var firstGrace = context.Graces.First();
            int graceId = firstGrace.ID;

            var collections = DataBase.GetCollections(graceId);

            Assert.IsNotNull(collections);
            Assert.IsTrue(collections.Count > 0);

            // "Other" should be excluded
            foreach (var collection in collections)
            {
                Assert.AreNotEqual("Other", collection.Name);
            }
        }

        [TestMethod]
        public void TestMethod_GetTotal()
        {
            CreateTestData();

            using var context = new GraceDbContext();
            var firstGrace = context.Graces.First();
            int graceId = firstGrace.ID;

            var total = DataBase.GetTotal(graceId);

            Assert.IsNotNull(total);
            Assert.AreEqual(graceId, total.GraceId);
            Assert.IsTrue(total.CurrentTotal >= 0);
        }

        [TestMethod]
        public void TestMethod_FilterTableBySku()
        {
            CreateTestData();

            var pulledGrid = DataBase.GetPulledGrid();
            var filteredView = DataBase.FilterTableBySku(pulledGrid, "SKU0001");

            Assert.IsNotNull(filteredView);
            Assert.IsTrue(filteredView.Count > 0);

            foreach (DataRowView row in filteredView)
            {
                var sku = row["Sku"].ToString();
                Assert.IsTrue(sku.Contains("SKU0001"));
            }
        }

        [TestMethod]
        public void TestMethod_InsertRow()
        {
            var graceId = DataBase.InsertRow(
                "TESTSKU001",
                "Test Product Description",
                "Test Brand",
                "Available",
                "12345678"
            );

            Assert.IsTrue(graceId > 0);

            using var context = new GraceDbContext();
            var grace = context.Graces.Find(graceId);
            Assert.IsNotNull(grace);
            Assert.AreEqual("TESTSKU001", grace.Sku);
            Assert.AreEqual("Test Product Description", grace.Description);
            Assert.AreEqual("Test Brand", grace.Brand);
            Assert.AreEqual("Available", grace.Availability);
            Assert.AreEqual("12345678", grace.BarCode);
        }

        [TestMethod]
        public void TestMethod_HaveData()
        {
            CreateTestData();

            var haveData = DataBase.HaveData();

            Assert.IsTrue(haveData);
        }

        [TestMethod]
        public void TestMethod_HaveData_Empty()
        {
            // Don't create test data
            var haveData = DataBase.HaveData();

            Assert.IsFalse(haveData);
        }

        [TestMethod]
        public void TestMethod_OrderedCollectionNames()
        {
            CreateTestData();

            var orderedCollections = DataBase.OrderedCollectionNames();

            Assert.IsNotNull(orderedCollections);
            Assert.IsTrue(orderedCollections.Count > 0);

            // Verify collections are ordered alphabetically
            var keys = orderedCollections.Keys.ToList();
            for (int i = 0; i < keys.Count - 1; i++)
            {
                Assert.IsTrue(string.Compare(keys[i], keys[i + 1]) <= 0);
            }

            // Verify each collection has Grace items
            foreach (var kvp in orderedCollections)
            {
                Assert.IsTrue(kvp.Value.Count > 0);
            }
        }

        private void Cleanup(string databaseName)
        {
            using (var context = new GraceDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.CloseConnection();
            }

            try
            {
                if (File.Exists(databaseName))
                {
                    File.Delete(databaseName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

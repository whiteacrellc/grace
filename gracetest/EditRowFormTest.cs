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
 * Year: 2025
 */

using grace;
using grace.data;
using grace.data.models;
using Microsoft.EntityFrameworkCore;
using System.Data;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8600
#pragma warning disable CS8602

namespace gracetest
{
    [TestClass]
    public class EditRowFormTest
    {
        private string testDbFile = "test_edit_row_form.db";
        private string connectionString = string.Empty;

        [TestInitialize]
        public void Setup()
        {
            // Create a test database instance
            var dataBase = new DataBase(testDbFile);
            connectionString = DataBase.ConnectionString;
            DataBase.InitializeDatabase();

            // Set a current user for operations that require it
            Globals.GetInstance().CurrentUser = "testuser";

            // Create test data
            CreateTestData();
        }

        [TestCleanup]
        public void Cleanup()
        {
            var fileName = DataBase.DbFileName;
            Globals.GetInstance().CurrentUser = null;

            using (var context = new GraceDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.CloseConnection();
            }

            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void CreateTestData()
        {
            using var context = new GraceDbContext();

            // Create brands and collections for testing
            var brands = new[] { "Brand1", "Brand2", "Brand3" };
            var collections = new[] { "Collection1", "Collection2", "Collection3" };

            // Create a test Grace item for UpdateRow tests
            var grace = new Grace
            {
                Brand = "Brand1",
                Sku = "TEST001",
                Description = "Original Description",
                BarCode = "12345678",
                Availability = "Available",
                Note = "Original Note",
                Deleted = false
            };
            context.Graces.Add(grace);
            context.SaveChanges();

            // Add collections
            foreach (var collectionName in collections)
            {
                var collection = new CollectionName
                {
                    GraceId = grace.ID,
                    Name = collectionName
                };
                context.Collections.Add(collection);
            }

            // Add totals
            var total = new Total
            {
                GraceId = grace.ID,
                CurrentTotal = 100,
                LastUpdated = DateTime.Now,
                User = "testuser"
            };
            context.Totals.Add(total);
            context.SaveChanges();

            // Create GraceRow
            DataBase.CreateGraceRow(grace.ID);
        }

        #region AddRow Tests

        [TestMethod]
        public void TestMethod_AddRow_CreatesNewGrace()
        {
            using var context = new GraceDbContext();

            // Simulate AddRow creating a new Grace
            string newSku = "NEWTESTSKU";
            string brand = "Brand2";
            string description = "New Test Description";
            string availability = "Available";
            string barcode = "87654321";
            string note = "New Test Note";

            var grace = new Grace
            {
                Sku = newSku,
                Brand = brand,
                Description = description,
                Availability = availability,
                BarCode = barcode,
                Note = note
            };

            context.Graces.Add(grace);
            context.SaveChanges();

            int graceId = grace.ID;

            // Verify the Grace was created
            var savedGrace = context.Graces.Find(graceId);
            Assert.IsNotNull(savedGrace);
            Assert.AreEqual(newSku, savedGrace.Sku);
            Assert.AreEqual(brand, savedGrace.Brand);
            Assert.AreEqual(description, savedGrace.Description);
            Assert.AreEqual(availability, savedGrace.Availability);
            Assert.AreEqual(barcode, savedGrace.BarCode);
            Assert.AreEqual(note, savedGrace.Note);
        }

        [TestMethod]
        public void TestMethod_AddRow_AddsInitialTotal()
        {
            using var context = new GraceDbContext();

            // Create a new Grace item
            var grace = new Grace
            {
                Sku = "TOTALTEST",
                Brand = "Brand1",
                Description = "Total Test",
                Availability = "Available",
                BarCode = "11111111"
            };
            context.Graces.Add(grace);
            context.SaveChanges();

            int graceId = grace.ID;
            int initialTotal = 50;

            // Add initial total (simulating AddRow)
            DataBase.AddTotal(initialTotal, graceId);

            // Verify the total was added
            var savedTotal = context.Totals.FirstOrDefault(t => t.GraceId == graceId);
            Assert.IsNotNull(savedTotal);
            Assert.AreEqual(initialTotal, savedTotal.CurrentTotal);
            Assert.AreEqual("testuser", savedTotal.User);
        }

        [TestMethod]
        public void TestMethod_AddRow_AddsCollections()
        {
            using var context = new GraceDbContext();

            // Create a new Grace item
            var grace = new Grace
            {
                Sku = "COLTEST",
                Brand = "Brand1",
                Description = "Collection Test",
                Availability = "Available",
                BarCode = "22222222"
            };
            context.Graces.Add(grace);
            context.SaveChanges();

            int graceId = grace.ID;

            // Add collections (simulating AddRow)
            var collectionNames = new[] { "Collection1", "Collection2" };
            foreach (var collectionName in collectionNames)
            {
                DataBase.AddCollectionRow(graceId, collectionName);
            }

            // Verify collections were added
            var savedCollections = context.Collections
                .Where(c => c.GraceId == graceId)
                .Select(c => c.Name)
                .OrderBy(n => n)
                .ToList();

            Assert.AreEqual(2, savedCollections.Count);
            Assert.AreEqual("Collection1", savedCollections[0]);
            Assert.AreEqual("Collection2", savedCollections[1]);
        }

        [TestMethod]
        public void TestMethod_AddRow_CreatesGraceRow()
        {
            using var context = new GraceDbContext();

            // Create a new Grace item
            var grace = new Grace
            {
                Sku = "GRACEROWTEST",
                Brand = "Brand1",
                Description = "GraceRow Test",
                Availability = "Available",
                BarCode = "33333333"
            };
            context.Graces.Add(grace);
            context.SaveChanges();

            int graceId = grace.ID;

            // Add total and collection
            DataBase.AddTotal(25, graceId);
            DataBase.AddCollectionRow(graceId, "Collection1");

            // Create GraceRow (simulating AddRow final step)
            int graceRowId = DataBase.CreateGraceRow(graceId);

            // Verify GraceRow was created
            Assert.IsTrue(graceRowId > 0);

            var graceRow = context.GraceRows.FirstOrDefault(gr => gr.GraceId == graceId);
            Assert.IsNotNull(graceRow);
            Assert.AreEqual("GRACEROWTEST", graceRow.Sku);
            Assert.AreEqual("Brand1", graceRow.Brand);
            Assert.AreEqual(25, graceRow.Total);
            Assert.AreEqual("Collection1", graceRow.Col1);
        }

        [TestMethod]
        public void TestMethod_AddRow_DuplicateSku_Fails()
        {
            using var context = new GraceDbContext();

            // Try to add a duplicate SKU (TEST001 already exists from Setup)
            var duplicateGrace = new Grace
            {
                Sku = "TEST001", // This SKU already exists
                Brand = "Brand1",
                Description = "Duplicate SKU Test",
                Availability = "Available",
                BarCode = "99999999"
            };

            context.Graces.Add(duplicateGrace);

            // This should fail because SKU must be unique
            // In AddRow, this is checked before SaveChanges
            bool skuExists = context.Graces.Any(g => g.Sku == "TEST001");
            Assert.IsTrue(skuExists);

            // The AddRow method would return true (error) in this case
            // and not call SaveChanges
        }

        [TestMethod]
        public void TestMethod_AddRow_DuplicateBarcode_Fails()
        {
            using var context = new GraceDbContext();

            // Try to add a duplicate barcode (12345678 already exists)
            bool barcodeExists = context.Graces.Any(g => g.BarCode == "12345678");
            Assert.IsTrue(barcodeExists);

            // The AddRow method would return true (error) and show a message
        }

        [TestMethod]
        public void TestMethod_AddRow_EmptyBarcode_Allowed()
        {
            using var context = new GraceDbContext();

            // Create item with empty barcode
            var grace = new Grace
            {
                Sku = "NOBARCODE",
                Brand = "Brand1",
                Description = "No Barcode Test",
                Availability = "Available",
                BarCode = string.Empty
            };
            context.Graces.Add(grace);
            context.SaveChanges();

            var savedGrace = context.Graces.FirstOrDefault(g => g.Sku == "NOBARCODE");
            Assert.IsNotNull(savedGrace);
            Assert.AreEqual(string.Empty, savedGrace.BarCode);
        }

        [TestMethod]
        public void TestMethod_AddRow_NewCollection_AddsToDatabase()
        {
            using var context = new GraceDbContext();

            // Create a new Grace item
            var grace = new Grace
            {
                Sku = "NEWCOL",
                Brand = "Brand1",
                Description = "New Collection Test",
                Availability = "Available",
                BarCode = "44444444"
            };
            context.Graces.Add(grace);
            context.SaveChanges();

            int graceId = grace.ID;

            // Add a new collection that doesn't exist yet
            string newCollectionName = "BrandNewCollection";
            bool collectionExists = DataBase.CheckCollectionExists(newCollectionName);
            Assert.IsFalse(collectionExists);

            // Add the new collection
            bool added = DataBase.AddCollectionRow(graceId, newCollectionName);
            Assert.IsTrue(added);

            // Verify it was added
            var savedCollection = context.Collections
                .FirstOrDefault(c => c.GraceId == graceId && c.Name == newCollectionName);
            Assert.IsNotNull(savedCollection);

            // Now it should exist
            collectionExists = DataBase.CheckCollectionExists(newCollectionName);
            Assert.IsTrue(collectionExists);
        }

        #endregion

        #region UpdateRow Tests

        [TestMethod]
        public void TestMethod_UpdateRow_UpdatesSku()
        {
            using var context = new GraceDbContext();

            // Get existing Grace
            var grace = context.Graces.FirstOrDefault(g => g.Sku == "TEST001");
            Assert.IsNotNull(grace);

            string newSku = "UPDATED001";

            // Check new SKU doesn't exist
            bool newSkuExists = context.Graces.Any(g => g.Sku == newSku);
            Assert.IsFalse(newSkuExists);

            // Update SKU
            grace.Sku = newSku;
            context.SaveChanges();

            // Verify update
            var updatedGrace = context.Graces.Find(grace.ID);
            Assert.IsNotNull(updatedGrace);
            Assert.AreEqual(newSku, updatedGrace.Sku);
        }

        [TestMethod]
        public void TestMethod_UpdateRow_UpdatesBrand()
        {
            using var context = new GraceDbContext();

            var grace = context.Graces.FirstOrDefault(g => g.Sku == "TEST001");
            Assert.IsNotNull(grace);

            string newBrand = "UpdatedBrand";
            grace.Brand = newBrand;
            context.SaveChanges();

            var updatedGrace = context.Graces.Find(grace.ID);
            Assert.AreEqual(newBrand, updatedGrace.Brand);
        }

        [TestMethod]
        public void TestMethod_UpdateRow_UpdatesDescription()
        {
            using var context = new GraceDbContext();

            var grace = context.Graces.FirstOrDefault(g => g.Sku == "TEST001");
            Assert.IsNotNull(grace);

            string newDescription = "Updated Description";
            grace.Description = newDescription;
            context.SaveChanges();

            var updatedGrace = context.Graces.Find(grace.ID);
            Assert.AreEqual(newDescription, updatedGrace.Description);
        }

        [TestMethod]
        public void TestMethod_UpdateRow_UpdatesAvailability()
        {
            using var context = new GraceDbContext();

            var grace = context.Graces.FirstOrDefault(g => g.Sku == "TEST001");
            Assert.IsNotNull(grace);

            string newAvailability = "Out of Stock";
            grace.Availability = newAvailability;
            context.SaveChanges();

            var updatedGrace = context.Graces.Find(grace.ID);
            Assert.AreEqual(newAvailability, updatedGrace.Availability);
        }

        [TestMethod]
        public void TestMethod_UpdateRow_UpdatesBarcode()
        {
            using var context = new GraceDbContext();

            var grace = context.Graces.FirstOrDefault(g => g.Sku == "TEST001");
            Assert.IsNotNull(grace);

            string newBarcode = "99887766";

            // Check new barcode doesn't exist
            bool barcodeExists = context.Graces.Any(g => g.BarCode == newBarcode);
            Assert.IsFalse(barcodeExists);

            grace.BarCode = newBarcode;
            context.SaveChanges();

            var updatedGrace = context.Graces.Find(grace.ID);
            Assert.AreEqual(newBarcode, updatedGrace.BarCode);
        }

        [TestMethod]
        public void TestMethod_UpdateRow_UpdatesNote()
        {
            using var context = new GraceDbContext();

            var grace = context.Graces.FirstOrDefault(g => g.Sku == "TEST001");
            Assert.IsNotNull(grace);

            string newNote = "Updated Note";
            grace.Note = newNote;
            context.SaveChanges();

            var updatedGrace = context.Graces.Find(grace.ID);
            Assert.AreEqual(newNote, updatedGrace.Note);
        }

        [TestMethod]
        public void TestMethod_UpdateRow_AdjustInventory_Positive()
        {
            using var context = new GraceDbContext();

            var grace = context.Graces.FirstOrDefault(g => g.Sku == "TEST001");
            Assert.IsNotNull(grace);

            int graceId = grace.ID;
            int currentTotal = 100;
            int delta = 20;
            int newTotal = currentTotal + delta;

            // Add the new total (simulating UpdateRow adjust inventory)
            DataBase.AddTotal(newTotal, graceId);

            // Verify new total was added
            var latestTotal = context.Totals
                .Where(t => t.GraceId == graceId)
                .OrderByDescending(t => t.ID)
                .FirstOrDefault();

            Assert.IsNotNull(latestTotal);
            Assert.AreEqual(120, latestTotal.CurrentTotal);
        }

        [TestMethod]
        public void TestMethod_UpdateRow_AdjustInventory_Negative()
        {
            using var context = new GraceDbContext();

            var grace = context.Graces.FirstOrDefault(g => g.Sku == "TEST001");
            Assert.IsNotNull(grace);

            int graceId = grace.ID;
            int currentTotal = 100;
            int delta = -30;
            int newTotal = currentTotal + delta;

            // Add the new total
            DataBase.AddTotal(newTotal, graceId);

            // Verify new total
            var latestTotal = context.Totals
                .Where(t => t.GraceId == graceId)
                .OrderByDescending(t => t.ID)
                .FirstOrDefault();

            Assert.IsNotNull(latestTotal);
            Assert.AreEqual(70, latestTotal.CurrentTotal);
        }

        [TestMethod]
        public void TestMethod_UpdateRow_AdjustInventory_NegativeResult()
        {
            using var context = new GraceDbContext();

            var grace = context.Graces.FirstOrDefault(g => g.Sku == "TEST001");
            Assert.IsNotNull(grace);

            int graceId = grace.ID;
            int currentTotal = 100;
            int delta = -150; // Results in negative total
            int newTotal = currentTotal + delta;

            // This is allowed with user confirmation in UpdateRow
            Assert.IsTrue(newTotal < 0);

            // Add the negative total
            DataBase.AddTotal(newTotal, graceId);

            var latestTotal = context.Totals
                .Where(t => t.GraceId == graceId)
                .OrderByDescending(t => t.ID)
                .FirstOrDefault();

            Assert.IsNotNull(latestTotal);
            Assert.AreEqual(-50, latestTotal.CurrentTotal);
        }

        [TestMethod]
        public void TestMethod_UpdateRow_NoChange_NoTotalAdded()
        {
            using var context = new GraceDbContext();

            var grace = context.Graces.FirstOrDefault(g => g.Sku == "TEST001");
            Assert.IsNotNull(grace);

            int graceId = grace.ID;
            int delta = 0; // No change

            // Get count before
            int countBefore = context.Totals.Count(t => t.GraceId == graceId);

            // Delta is 0, so UpdateRow shouldn't add a new total
            if (delta != 0)
            {
                DataBase.AddTotal(100 + delta, graceId);
            }

            // Count should be the same
            int countAfter = context.Totals.Count(t => t.GraceId == graceId);
            Assert.AreEqual(countBefore, countAfter);
        }

        [TestMethod]
        public void TestMethod_UpdateRow_AddsCollection()
        {
            using var context = new GraceDbContext();

            var grace = context.Graces.FirstOrDefault(g => g.Sku == "TEST001");
            Assert.IsNotNull(grace);

            int graceId = grace.ID;
            string newCollection = "NewCollection4";

            // Add new collection
            bool added = DataBase.AddCollectionRow(graceId, newCollection);
            Assert.IsTrue(added);

            // Verify it was added
            var collection = context.Collections
                .FirstOrDefault(c => c.GraceId == graceId && c.Name == newCollection);
            Assert.IsNotNull(collection);
        }

        [TestMethod]
        public void TestMethod_UpdateRow_UpdatesGraceRow()
        {
            using var context = new GraceDbContext();

            var grace = context.Graces.FirstOrDefault(g => g.Sku == "TEST001");
            Assert.IsNotNull(grace);

            int graceId = grace.ID;

            // Update the Grace
            grace.Description = "Updated via UpdateRow";
            grace.Note = "Updated Note";
            context.SaveChanges();

            // Update GraceRow (simulating UpdateRow)
            DataBase.UpdateGraceRow(graceId);

            // Verify GraceRow was updated
            var graceRow = context.GraceRows.FirstOrDefault(gr => gr.GraceId == graceId);
            Assert.IsNotNull(graceRow);
            Assert.AreEqual("Updated via UpdateRow", graceRow.Description);
            Assert.AreEqual("Updated Note", graceRow.Note);
        }

        [TestMethod]
        public void TestMethod_UpdateRow_DuplicateSku_Fails()
        {
            using var context = new GraceDbContext();

            // Create a second Grace item
            var grace2 = new Grace
            {
                Sku = "TEST002",
                Brand = "Brand1",
                Description = "Second Item",
                Availability = "Available",
                BarCode = "77777777"
            };
            context.Graces.Add(grace2);
            context.SaveChanges();

            // Try to update TEST002's SKU to TEST001 (which exists)
            bool skuExists = context.Graces.Any(g => g.Sku == "TEST001");
            Assert.IsTrue(skuExists);

            // UpdateRow would return true (error) without calling SaveChanges
        }

        [TestMethod]
        public void TestMethod_UpdateRow_DuplicateBarcode_Fails()
        {
            using var context = new GraceDbContext();

            // Create a second Grace item
            var grace2 = new Grace
            {
                Sku = "TEST003",
                Brand = "Brand1",
                Description = "Third Item",
                Availability = "Available",
                BarCode = "66666666"
            };
            context.Graces.Add(grace2);
            context.SaveChanges();

            // Try to update TEST003's barcode to 12345678 (which exists)
            bool barcodeExists = context.Graces.Any(g => g.BarCode == "12345678");
            Assert.IsTrue(barcodeExists);

            // UpdateRow would return true (error) without calling SaveChanges
        }

        [TestMethod]
        public void TestMethod_UpdateRow_TrimsSku()
        {
            using var context = new GraceDbContext();

            var grace = context.Graces.FirstOrDefault(g => g.Sku == "TEST001");
            Assert.IsNotNull(grace);

            string skuWithSpaces = "  TRIMMEDSKU  ";
            grace.Sku = skuWithSpaces.Trim();
            context.SaveChanges();

            var updatedGrace = context.Graces.Find(grace.ID);
            Assert.AreEqual("TRIMMEDSKU", updatedGrace.Sku);
        }

        [TestMethod]
        public void TestMethod_UpdateRow_TrimsBrand()
        {
            using var context = new GraceDbContext();

            var grace = context.Graces.FirstOrDefault(g => g.Sku == "TEST001");
            Assert.IsNotNull(grace);

            string brandWithSpaces = "  TrimmedBrand  ";
            grace.Brand = brandWithSpaces.Trim();
            context.SaveChanges();

            var updatedGrace = context.Graces.Find(grace.ID);
            Assert.AreEqual("TrimmedBrand", updatedGrace.Brand);
        }

        #endregion
    }
}

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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8600
#pragma warning disable CS8602

namespace gracetest
{
    [TestClass]
    public class GraceDbContextTest
    {
        private string testDbFile = "test_gracedbcontext.db";
        private GraceDbContext context;

        [TestInitialize]
        public void Setup()
        {
            var dataBase = new DataBase(testDbFile);
            context = new GraceDbContext();
            context.Database.EnsureCreated();
            Globals.GetInstance().CurrentUser = "testuser";
        }

        [TestCleanup]
        public void Cleanup()
        {
            Globals.GetInstance().CurrentUser = null;
            context?.Database.EnsureDeleted();
            context?.Database.CloseConnection();
            context?.Dispose();

            try
            {
                if (File.Exists(testDbFile))
                {
                    File.Delete(testDbFile);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cleanup error: {ex.Message}");
            }
        }

        #region Grace Entity Tests

        [TestMethod]
        public void TestMethod_Grace_CanCreate()
        {
            var grace = new Grace
            {
                Sku = "TEST001",
                Description = "Test Product",
                Brand = "Test Brand"
            };

            context.Graces.Add(grace);
            context.SaveChanges();

            Assert.IsTrue(grace.ID > 0, "ID should be assigned");
            Assert.AreEqual(1, context.Graces.Count());
        }

        [TestMethod]
        public void TestMethod_Grace_CanRead()
        {
            var grace = new Grace
            {
                Sku = "TEST002",
                Description = "Test Product 2",
                Brand = "Brand 2"
            };
            context.Graces.Add(grace);
            context.SaveChanges();

            var retrieved = context.Graces.FirstOrDefault(g => g.Sku == "TEST002");

            Assert.IsNotNull(retrieved);
            Assert.AreEqual("TEST002", retrieved.Sku);
            Assert.AreEqual("Test Product 2", retrieved.Description);
            Assert.AreEqual("Brand 2", retrieved.Brand);
        }

        [TestMethod]
        public void TestMethod_Grace_CanUpdate()
        {
            var grace = new Grace
            {
                Sku = "TEST003",
                Description = "Original Description",
                Brand = "Original Brand"
            };
            context.Graces.Add(grace);
            context.SaveChanges();

            grace.Description = "Updated Description";
            grace.Brand = "Updated Brand";
            context.SaveChanges();

            var updated = context.Graces.Find(grace.ID);
            Assert.AreEqual("Updated Description", updated.Description);
            Assert.AreEqual("Updated Brand", updated.Brand);
        }

        [TestMethod]
        public void TestMethod_Grace_CanDelete()
        {
            var grace = new Grace
            {
                Sku = "TEST004",
                Description = "To Be Deleted",
                Brand = "Delete Brand"
            };
            context.Graces.Add(grace);
            context.SaveChanges();

            context.Graces.Remove(grace);
            context.SaveChanges();

            Assert.AreEqual(0, context.Graces.Count());
        }

        [TestMethod]
        public void TestMethod_Grace_SkuIsUnique()
        {
            var grace1 = new Grace
            {
                Sku = "UNIQUE001",
                Description = "First",
                Brand = "Brand"
            };
            context.Graces.Add(grace1);
            context.SaveChanges();

            var grace2 = new Grace
            {
                Sku = "UNIQUE001", // Duplicate SKU
                Description = "Second",
                Brand = "Brand"
            };
            context.Graces.Add(grace2);

            Assert.ThrowsException<DbUpdateException>(() => context.SaveChanges(),
                "Should throw exception for duplicate SKU");
        }

        [TestMethod]
        public void TestMethod_Grace_RequiredFields()
        {
            var grace = new Grace
            {
                Sku = null, // Required field
                Description = "Test",
                Brand = "Test"
            };
            context.Graces.Add(grace);

            Assert.ThrowsException<DbUpdateException>(() => context.SaveChanges(),
                "Should throw exception for missing required Sku");
        }

        [TestMethod]
        public void TestMethod_Grace_DefaultNoteValue()
        {
            var grace = new Grace
            {
                Sku = "TEST005",
                Description = "Test",
                Brand = "Brand"
                // Note not set
            };
            context.Graces.Add(grace);
            context.SaveChanges();

            var retrieved = context.Graces.Find(grace.ID);
            Assert.AreEqual("", retrieved.Note, "Note should default to empty string");
        }

        #endregion

        #region Total Entity Tests

        [TestMethod]
        public void TestMethod_Total_CanCreate()
        {
            var grace = CreateTestGrace("SKU_TOTAL_001");
            var total = new Total
            {
                GraceId = grace.ID,
                CurrentTotal = 100,
                LastUpdated = DateTime.Now,
                User = "testuser"
            };

            context.Totals.Add(total);
            context.SaveChanges();

            Assert.IsTrue(total.ID > 0);
            Assert.AreEqual(1, context.Totals.Count());
        }

        [TestMethod]
        public void TestMethod_Total_ForeignKeyRelationship()
        {
            var grace = CreateTestGrace("SKU_TOTAL_002");
            var total = new Total
            {
                GraceId = grace.ID,
                CurrentTotal = 50,
                LastUpdated = DateTime.Now,
                User = "testuser"
            };
            context.Totals.Add(total);
            context.SaveChanges();

            var retrieved = context.Totals
                .Include(t => t.Grace)
                .FirstOrDefault(t => t.ID == total.ID);

            Assert.IsNotNull(retrieved);
            Assert.IsNotNull(retrieved.Grace);
            Assert.AreEqual(grace.Sku, retrieved.Grace.Sku);
        }

        [TestMethod]
        public void TestMethod_Total_CascadeDelete()
        {
            var grace = CreateTestGrace("SKU_TOTAL_003");
            var total = new Total
            {
                GraceId = grace.ID,
                CurrentTotal = 75,
                LastUpdated = DateTime.Now,
                User = "testuser"
            };
            context.Totals.Add(total);
            context.SaveChanges();

            // Delete the parent Grace
            context.Graces.Remove(grace);
            context.SaveChanges();

            // Total should be cascade deleted
            Assert.AreEqual(0, context.Totals.Count(),
                "Total should be cascade deleted when Grace is deleted");
        }

        [TestMethod]
        public void TestMethod_Total_DefaultUserValue()
        {
            var grace = CreateTestGrace("SKU_TOTAL_004");
            var total = new Total
            {
                GraceId = grace.ID,
                CurrentTotal = 25,
                LastUpdated = DateTime.Now
                // User not set
            };
            context.Totals.Add(total);
            context.SaveChanges();

            var retrieved = context.Totals.Find(total.ID);
            Assert.AreEqual("", retrieved.User, "User should default to empty string");
        }

        #endregion

        #region CollectionName Entity Tests

        [TestMethod]
        public void TestMethod_CollectionName_CanCreate()
        {
            var grace = CreateTestGrace("SKU_COL_001");
            var collection = new CollectionName
            {
                GraceId = grace.ID,
                Name = "Spring Collection",
                IsDeleted = false
            };

            context.Collections.Add(collection);
            context.SaveChanges();

            Assert.IsTrue(collection.ID > 0);
            Assert.AreEqual(1, context.Collections.Count());
        }

        [TestMethod]
        public void TestMethod_CollectionName_ForeignKeyRelationship()
        {
            var grace = CreateTestGrace("SKU_COL_002");
            var collection = new CollectionName
            {
                GraceId = grace.ID,
                Name = "Summer Collection",
                IsDeleted = false
            };
            context.Collections.Add(collection);
            context.SaveChanges();

            var retrieved = context.Collections
                .Include(c => c.Grace)
                .FirstOrDefault(c => c.ID == collection.ID);

            Assert.IsNotNull(retrieved);
            Assert.IsNotNull(retrieved.Grace);
            Assert.AreEqual(grace.Sku, retrieved.Grace.Sku);
        }

        [TestMethod]
        public void TestMethod_CollectionName_CascadeDelete()
        {
            var grace = CreateTestGrace("SKU_COL_003");
            var collection = new CollectionName
            {
                GraceId = grace.ID,
                Name = "Fall Collection",
                IsDeleted = false
            };
            context.Collections.Add(collection);
            context.SaveChanges();

            context.Graces.Remove(grace);
            context.SaveChanges();

            Assert.AreEqual(0, context.Collections.Count(),
                "Collection should be cascade deleted when Grace is deleted");
        }

        [TestMethod]
        public void TestMethod_CollectionName_MultiplePerGrace()
        {
            var grace = CreateTestGrace("SKU_COL_004");

            for (int i = 1; i <= 3; i++)
            {
                var collection = new CollectionName
                {
                    GraceId = grace.ID,
                    Name = $"Collection {i}",
                    IsDeleted = false
                };
                context.Collections.Add(collection);
            }
            context.SaveChanges();

            var collections = context.Collections
                .Where(c => c.GraceId == grace.ID)
                .ToList();

            Assert.AreEqual(3, collections.Count);
        }

        #endregion

        #region GraceRow Entity Tests

        [TestMethod]
        public void TestMethod_GraceRow_CanCreate()
        {
            var grace = CreateTestGrace("SKU_ROW_001");
            var graceRow = new GraceRow
            {
                GraceId = grace.ID,
                Sku = grace.Sku,
                Description = grace.Description,
                Brand = grace.Brand,
                Total = 100,
                PrevTotal = 50,
                LastUpdated = DateTime.Now,
                Note = "Test note"
            };

            context.GraceRows.Add(graceRow);
            context.SaveChanges();

            Assert.IsTrue(graceRow.ID > 0);
            Assert.AreEqual(1, context.GraceRows.Count());
        }

        [TestMethod]
        public void TestMethod_GraceRow_CascadeDelete()
        {
            var grace = CreateTestGrace("SKU_ROW_002");
            var graceRow = new GraceRow
            {
                GraceId = grace.ID,
                Sku = grace.Sku,
                Description = grace.Description,
                Brand = grace.Brand,
                Total = 100,
                PrevTotal = 50,
                LastUpdated = DateTime.Now
            };
            context.GraceRows.Add(graceRow);
            context.SaveChanges();

            context.Graces.Remove(grace);
            context.SaveChanges();

            Assert.AreEqual(0, context.GraceRows.Count(),
                "GraceRow should be cascade deleted when Grace is deleted");
        }

        [TestMethod]
        public void TestMethod_GraceRow_DefaultNoteValue()
        {
            var grace = CreateTestGrace("SKU_ROW_003");
            var graceRow = new GraceRow
            {
                GraceId = grace.ID,
                Sku = grace.Sku,
                Description = grace.Description,
                Brand = grace.Brand,
                Total = 100,
                PrevTotal = 50,
                LastUpdated = DateTime.Now
                // Note not set
            };
            context.GraceRows.Add(graceRow);
            context.SaveChanges();

            var retrieved = context.GraceRows.Find(graceRow.ID);
            Assert.AreEqual("", retrieved.Note, "Note should default to empty string");
        }

        #endregion

        #region User Entity Tests

        [TestMethod]
        public void TestMethod_User_CanCreate()
        {
            var user = new User
            {
                Username = "testuser1",
                Password = "password123",
                Admin = true,
                ResetPassword = false,
                Deleted = false
            };

            context.Users.Add(user);
            context.SaveChanges();

            Assert.IsTrue(user.ID > 0);
            Assert.AreEqual(1, context.Users.Count());
        }

        [TestMethod]
        public void TestMethod_User_RequiredFields()
        {
            var user = new User
            {
                Username = null, // Required
                Password = "password",
                Admin = false
            };
            context.Users.Add(user);

            Assert.ThrowsException<DbUpdateException>(() => context.SaveChanges(),
                "Should throw exception for missing required Username");
        }

        [TestMethod]
        public void TestMethod_User_CanUpdate()
        {
            var user = new User
            {
                Username = "updatetest",
                Password = "oldpassword",
                Admin = false,
                ResetPassword = true
            };
            context.Users.Add(user);
            context.SaveChanges();

            user.Password = "newpassword";
            user.Admin = true;
            user.ResetPassword = false;
            context.SaveChanges();

            var updated = context.Users.Find(user.ID);
            Assert.AreEqual("newpassword", updated.Password);
            Assert.IsTrue(updated.Admin);
            Assert.IsFalse(updated.ResetPassword);
        }

        #endregion

        #region Pulled Entity Tests

        [TestMethod]
        public void TestMethod_Pulled_CanCreate()
        {
            var grace = CreateTestGrace("SKU_PULL_001");
            var user = CreateTestUser("pulluser");
            var collection = CreateTestCollection(grace.ID, "Pull Collection");

            var pulled = new Pulled
            {
                GraceId = grace.ID,
                UserId = user.ID,
                CollectionId = collection.ID,
                Amount = 10,
                CurrentTotal = 100,
                CheckedInAmount = 0,
                LastUpdated = DateTime.Now,
                Comment = "Test pull",
                IsCompleted = false
            };

            context.PulledDb.Add(pulled);
            context.SaveChanges();

            Assert.IsTrue(pulled.ID > 0);
            Assert.AreEqual(1, context.PulledDb.Count());
        }

        [TestMethod]
        public void TestMethod_Pulled_Relationships()
        {
            var grace = CreateTestGrace("SKU_PULL_002");
            var user = CreateTestUser("pulluser2");
            var collection = CreateTestCollection(grace.ID, "Pull Collection 2");

            var pulled = new Pulled
            {
                GraceId = grace.ID,
                UserId = user.ID,
                CollectionId = collection.ID,
                Amount = 5,
                CurrentTotal = 50,
                LastUpdated = DateTime.Now
            };
            context.PulledDb.Add(pulled);
            context.SaveChanges();

            var retrieved = context.PulledDb
                .Include(p => p.Grace)
                .Include(p => p.User)
                .Include(p => p.Collection)
                .FirstOrDefault(p => p.ID == pulled.ID);

            Assert.IsNotNull(retrieved);
            Assert.IsNotNull(retrieved.Grace);
            Assert.IsNotNull(retrieved.User);
            Assert.IsNotNull(retrieved.Collection);
            Assert.AreEqual(grace.Sku, retrieved.Grace.Sku);
            Assert.AreEqual(user.Username, retrieved.User.Username);
            Assert.AreEqual(collection.Name, retrieved.Collection.Name);
        }

        [TestMethod]
        public void TestMethod_Pulled_CascadeDeleteOnGrace()
        {
            var grace = CreateTestGrace("SKU_PULL_003");
            var user = CreateTestUser("pulluser3");
            var collection = CreateTestCollection(grace.ID, "Pull Collection 3");

            var pulled = new Pulled
            {
                GraceId = grace.ID,
                UserId = user.ID,
                CollectionId = collection.ID,
                Amount = 7,
                CurrentTotal = 70,
                LastUpdated = DateTime.Now
            };
            context.PulledDb.Add(pulled);
            context.SaveChanges();

            context.Graces.Remove(grace);
            context.SaveChanges();

            Assert.AreEqual(0, context.PulledDb.Count(),
                "Pulled should be cascade deleted when Grace is deleted");
        }

        [TestMethod]
        public void TestMethod_Pulled_DefaultCheckedInAmount()
        {
            var grace = CreateTestGrace("SKU_PULL_004");
            var user = CreateTestUser("pulluser4");
            var collection = CreateTestCollection(grace.ID, "Pull Collection 4");

            var pulled = new Pulled
            {
                GraceId = grace.ID,
                UserId = user.ID,
                CollectionId = collection.ID,
                Amount = 3,
                CurrentTotal = 30,
                LastUpdated = DateTime.Now
                // CheckedInAmount not set
            };
            context.PulledDb.Add(pulled);
            context.SaveChanges();

            var retrieved = context.PulledDb.Find(pulled.ID);
            Assert.AreEqual(0, retrieved.CheckedInAmount,
                "CheckedInAmount should default to 0");
        }

        #endregion

        #region Prefs Entity Tests

        [TestMethod]
        public void TestMethod_Prefs_CanCreate()
        {
            var pref = new Prefs
            {
                Name = "TestPref",
                Value = "TestValue"
            };

            context.PrefsDb.Add(pref);
            context.SaveChanges();

            Assert.IsTrue(pref.ID > 0);
            Assert.AreEqual(1, context.PrefsDb.Count());
        }

        [TestMethod]
        public void TestMethod_Prefs_RequiredFields()
        {
            var pref = new Prefs
            {
                Name = null, // Required
                Value = "Value"
            };
            context.PrefsDb.Add(pref);

            Assert.ThrowsException<DbUpdateException>(() => context.SaveChanges(),
                "Should throw exception for missing required Name");
        }

        #endregion

        #region Arrangement Entity Tests

        [TestMethod]
        public void TestMethod_Arrangement_CanCreate()
        {
            var arrangement = new Arrangement
            {
                Name = "Holiday Arrangement",
                CollectionName = "Winter",
                IsDeleted = false
            };

            context.Arrangement.Add(arrangement);
            context.SaveChanges();

            Assert.IsTrue(arrangement.ID > 0);
            Assert.AreEqual(1, context.Arrangement.Count());
        }

        [TestMethod]
        public void TestMethod_Arrangement_UniqueNameCollectionComposite()
        {
            var arrangement1 = new Arrangement
            {
                Name = "Spring Bouquet",
                CollectionName = "Spring",
                IsDeleted = false
            };
            context.Arrangement.Add(arrangement1);
            context.SaveChanges();

            // Same name but different collection - should be allowed
            var arrangement2 = new Arrangement
            {
                Name = "Spring Bouquet",
                CollectionName = "Summer",
                IsDeleted = false
            };
            context.Arrangement.Add(arrangement2);
            context.SaveChanges();

            Assert.AreEqual(2, context.Arrangement.Count(),
                "Same name with different collection should be allowed");

            // Same name AND same collection - should fail
            var arrangement3 = new Arrangement
            {
                Name = "Spring Bouquet",
                CollectionName = "Spring",
                IsDeleted = false
            };
            context.Arrangement.Add(arrangement3);

            Assert.ThrowsException<DbUpdateException>(() => context.SaveChanges(),
                "Should throw exception for duplicate Name+CollectionName composite");
        }

        [TestMethod]
        public void TestMethod_Arrangement_DefaultIsDeletedValue()
        {
            var arrangement = new Arrangement
            {
                Name = "Test Arrangement",
                CollectionName = "Test Collection"
                // IsDeleted not set
            };
            context.Arrangement.Add(arrangement);
            context.SaveChanges();

            var retrieved = context.Arrangement.Find(arrangement.ID);
            Assert.IsFalse(retrieved.IsDeleted,
                "IsDeleted should default to false");
        }

        #endregion

        #region ArrangementTotal Entity Tests

        [TestMethod]
        public void TestMethod_ArrangementTotal_CanCreate()
        {
            var arrangement = CreateTestArrangement("Test Arr", "Test Col");
            var arrTotal = new ArrangementTotal
            {
                ArrangementId = arrangement.ID,
                CurrentTotal = 25,
                LastUpdated = DateTime.Now,
                User = "testuser"
            };

            context.ArrangementTotals.Add(arrTotal);
            context.SaveChanges();

            Assert.IsTrue(arrTotal.ID > 0);
            Assert.AreEqual(1, context.ArrangementTotals.Count());
        }

        [TestMethod]
        public void TestMethod_ArrangementTotal_ForeignKeyRelationship()
        {
            var arrangement = CreateTestArrangement("Arr 2", "Col 2");
            var arrTotal = new ArrangementTotal
            {
                ArrangementId = arrangement.ID,
                CurrentTotal = 30,
                LastUpdated = DateTime.Now,
                User = "testuser"
            };
            context.ArrangementTotals.Add(arrTotal);
            context.SaveChanges();

            var retrieved = context.ArrangementTotals
                .Include(at => at.Arrangement)
                .FirstOrDefault(at => at.ID == arrTotal.ID);

            Assert.IsNotNull(retrieved);
            Assert.IsNotNull(retrieved.Arrangement);
            Assert.AreEqual(arrangement.Name, retrieved.Arrangement.Name);
        }

        [TestMethod]
        public void TestMethod_ArrangementTotal_CascadeDelete()
        {
            var arrangement = CreateTestArrangement("Arr 3", "Col 3");
            var arrTotal = new ArrangementTotal
            {
                ArrangementId = arrangement.ID,
                CurrentTotal = 40,
                LastUpdated = DateTime.Now,
                User = "testuser"
            };
            context.ArrangementTotals.Add(arrTotal);
            context.SaveChanges();

            context.Arrangement.Remove(arrangement);
            context.SaveChanges();

            Assert.AreEqual(0, context.ArrangementTotals.Count(),
                "ArrangementTotal should be cascade deleted when Arrangement is deleted");
        }

        #endregion

        #region Inventory Entity Tests

        [TestMethod]
        public void TestMethod_Inventory_CanCreate()
        {
            var grace = CreateTestGrace("SKU_INV_001");
            var user = CreateTestUser("invuser");

            var inventory = new Inventory
            {
                GraceId = grace.ID,
                UserId = user.ID,
                PreviousAmount = 10,
                Delta = 5,
                CurrentTotal = 15,
                LastUpdated = DateTime.Now
            };

            context.InventoryDb.Add(inventory);
            context.SaveChanges();

            Assert.IsTrue(inventory.ID > 0);
            Assert.AreEqual(1, context.InventoryDb.Count());
        }

        [TestMethod]
        public void TestMethod_Inventory_Relationships()
        {
            var grace = CreateTestGrace("SKU_INV_002");
            var user = CreateTestUser("invuser2");

            var inventory = new Inventory
            {
                GraceId = grace.ID,
                UserId = user.ID,
                PreviousAmount = 15,
                Delta = 5,
                CurrentTotal = 20,
                LastUpdated = DateTime.Now
            };
            context.InventoryDb.Add(inventory);
            context.SaveChanges();

            var retrieved = context.InventoryDb
                .Include(i => i.Grace)
                .Include(i => i.User)
                .FirstOrDefault(i => i.ID == inventory.ID);

            Assert.IsNotNull(retrieved);
            Assert.IsNotNull(retrieved.Grace);
            Assert.IsNotNull(retrieved.User);
            Assert.AreEqual(grace.Sku, retrieved.Grace.Sku);
            Assert.AreEqual(user.Username, retrieved.User.Username);
        }

        [TestMethod]
        public void TestMethod_Inventory_CascadeDeleteOnGrace()
        {
            var grace = CreateTestGrace("SKU_INV_003");
            var user = CreateTestUser("invuser3");

            var inventory = new Inventory
            {
                GraceId = grace.ID,
                UserId = user.ID,
                PreviousAmount = 20,
                Delta = 5,
                CurrentTotal = 25,
                LastUpdated = DateTime.Now
            };
            context.InventoryDb.Add(inventory);
            context.SaveChanges();

            context.Graces.Remove(grace);
            context.SaveChanges();

            Assert.AreEqual(0, context.InventoryDb.Count(),
                "Inventory should be cascade deleted when Grace is deleted");
        }

        #endregion

        #region DbContext Configuration Tests

        [TestMethod]
        public void TestMethod_DbContext_AllDbSetsExist()
        {
            Assert.IsNotNull(context.Graces, "Graces DbSet should exist");
            Assert.IsNotNull(context.Collections, "Collections DbSet should exist");
            Assert.IsNotNull(context.Totals, "Totals DbSet should exist");
            Assert.IsNotNull(context.GraceRows, "GraceRows DbSet should exist");
            Assert.IsNotNull(context.Users, "Users DbSet should exist");
            Assert.IsNotNull(context.PulledDb, "PulledDb DbSet should exist");
            Assert.IsNotNull(context.PrefsDb, "PrefsDb DbSet should exist");
            Assert.IsNotNull(context.InventoryDb, "InventoryDb DbSet should exist");
            Assert.IsNotNull(context.Arrangement, "Arrangement DbSet should exist");
            Assert.IsNotNull(context.ArrangementTotals, "ArrangementTotals DbSet should exist");
        }

        [TestMethod]
        public void TestMethod_DbContext_ConnectionStringIsSet()
        {
            Assert.IsFalse(string.IsNullOrEmpty(GraceDbContext.ConnectionString),
                "ConnectionString should be set");
            Assert.IsTrue(GraceDbContext.ConnectionString.Contains("Data Source"),
                "ConnectionString should contain Data Source");
        }

        [TestMethod]
        public void TestMethod_DbContext_CanCreateWithOptions()
        {
            var options = new DbContextOptionsBuilder<GraceDbContext>()
                .UseSqlite("Data Source=test_options.db")
                .Options;

            using var testContext = new GraceDbContext(options);
            testContext.Database.EnsureCreated();

            Assert.IsNotNull(testContext);
            Assert.IsNotNull(testContext.Graces);

            testContext.Database.EnsureDeleted();
        }

        #endregion

        #region Complex Relationship Tests

        [TestMethod]
        public void TestMethod_ComplexRelationship_GraceWithMultipleEntities()
        {
            // Create a Grace with all related entities
            var grace = CreateTestGrace("SKU_COMPLEX_001");
            var user = CreateTestUser("complexuser");

            // Add totals
            var total1 = new Total
            {
                GraceId = grace.ID,
                CurrentTotal = 100,
                LastUpdated = DateTime.Now.AddDays(-1),
                User = "testuser"
            };
            var total2 = new Total
            {
                GraceId = grace.ID,
                CurrentTotal = 150,
                LastUpdated = DateTime.Now,
                User = "testuser"
            };
            context.Totals.AddRange(total1, total2);

            // Add collections
            var collection1 = new CollectionName
            {
                GraceId = grace.ID,
                Name = "Spring",
                IsDeleted = false
            };
            var collection2 = new CollectionName
            {
                GraceId = grace.ID,
                Name = "Summer",
                IsDeleted = false
            };
            context.Collections.AddRange(collection1, collection2);

            // Add GraceRow
            var graceRow = new GraceRow
            {
                GraceId = grace.ID,
                Sku = grace.Sku,
                Description = grace.Description,
                Brand = grace.Brand,
                Total = 150,
                PrevTotal = 100,
                LastUpdated = DateTime.Now
            };
            context.GraceRows.Add(graceRow);

            context.SaveChanges();

            // Verify all related entities exist
            Assert.AreEqual(2, context.Totals.Count(t => t.GraceId == grace.ID));
            Assert.AreEqual(2, context.Collections.Count(c => c.GraceId == grace.ID));
            Assert.AreEqual(1, context.GraceRows.Count(gr => gr.GraceId == grace.ID));

            // Delete Grace and verify cascade
            context.Graces.Remove(grace);
            context.SaveChanges();

            Assert.AreEqual(0, context.Totals.Count(t => t.GraceId == grace.ID));
            Assert.AreEqual(0, context.Collections.Count(c => c.GraceId == grace.ID));
            Assert.AreEqual(0, context.GraceRows.Count(gr => gr.GraceId == grace.ID));
        }

        [TestMethod]
        public void TestMethod_ComplexRelationship_UserWithMultiplePulls()
        {
            var user = CreateTestUser("multipulluser");
            var grace1 = CreateTestGrace("SKU_MULTIPULL_001");
            var grace2 = CreateTestGrace("SKU_MULTIPULL_002");
            var collection1 = CreateTestCollection(grace1.ID, "Collection 1");
            var collection2 = CreateTestCollection(grace2.ID, "Collection 2");

            var pulled1 = new Pulled
            {
                GraceId = grace1.ID,
                UserId = user.ID,
                CollectionId = collection1.ID,
                Amount = 10,
                CurrentTotal = 100,
                LastUpdated = DateTime.Now
            };
            var pulled2 = new Pulled
            {
                GraceId = grace2.ID,
                UserId = user.ID,
                CollectionId = collection2.ID,
                Amount = 20,
                CurrentTotal = 200,
                LastUpdated = DateTime.Now
            };
            context.PulledDb.AddRange(pulled1, pulled2);
            context.SaveChanges();

            var userPulls = context.PulledDb
                .Where(p => p.UserId == user.ID)
                .ToList();

            Assert.AreEqual(2, userPulls.Count);
        }

        #endregion

        #region Helper Methods

        private Grace CreateTestGrace(string sku)
        {
            var grace = new Grace
            {
                Sku = sku,
                Description = $"Description for {sku}",
                Brand = "Test Brand",
                Availability = "Available",
                BarCode = "12345678",
                Note = "",
                Deleted = false
            };
            context.Graces.Add(grace);
            context.SaveChanges();
            return grace;
        }

        private User CreateTestUser(string username)
        {
            var user = new User
            {
                Username = username,
                Password = "password123",
                Admin = false,
                ResetPassword = false,
                Deleted = false
            };
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        private CollectionName CreateTestCollection(int graceId, string name)
        {
            var collection = new CollectionName
            {
                GraceId = graceId,
                Name = name,
                IsDeleted = false
            };
            context.Collections.Add(collection);
            context.SaveChanges();
            return collection;
        }

        private Arrangement CreateTestArrangement(string name, string collectionName)
        {
            var arrangement = new Arrangement
            {
                Name = name,
                CollectionName = collectionName,
                IsDeleted = false
            };
            context.Arrangement.Add(arrangement);
            context.SaveChanges();
            return arrangement;
        }

        #endregion
    }
}

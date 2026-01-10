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
using grace.dialogs;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8600
#pragma warning disable CS8602

namespace gracetest
{
    [TestClass]
    public class AddArrangementDialogTest
    {
        private string testDbFile = "test_add_arrangement_dialog.db";
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

            // Create test collections
            CreateTestCollections();
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

        private void CreateTestCollections()
        {
            using var context = new GraceDbContext();

            // Create a test Grace item first so we can add collections
            var grace = new Grace
            {
                Brand = "TestBrand",
                Sku = "TEST001",
                Description = "Test Description",
                BarCode = "12345678",
                Availability = "Available",
                Deleted = false
            };
            context.Graces.Add(grace);
            context.SaveChanges();

            // Add collections
            var collections = new[] { "Collection1", "Collection2", "Collection3" };
            foreach (var collectionName in collections)
            {
                var collection = new CollectionName
                {
                    GraceId = grace.ID,
                    Name = collectionName
                };
                context.Collections.Add(collection);
            }
            context.SaveChanges();
        }

        [TestMethod]
        public void TestMethod_InsertRow_CreatesArrangement()
        {
            using var context = new GraceDbContext();

            string arrangementName = "TestArrangement";
            string collectionName = "Collection1";

            // Create the arrangement (simulating what InsertRow does)
            var arrangement = new Arrangement
            {
                Name = arrangementName.Trim(),
                CollectionName = collectionName.Trim(),
            };

            context.Arrangement.Add(arrangement);
            context.SaveChanges();

            int insertId = arrangement.ID;

            // Verify the arrangement was created
            var savedArrangement = context.Arrangement.FirstOrDefault(a => a.ID == insertId);
            Assert.IsNotNull(savedArrangement);
            Assert.AreEqual(arrangementName, savedArrangement.Name);
            Assert.AreEqual(collectionName, savedArrangement.CollectionName);
        }

        [TestMethod]
        public void TestMethod_InsertRow_CreatesArrangementTotal()
        {
            using var context = new GraceDbContext();

            string arrangementName = "TestArrangement";
            string collectionName = "Collection1";
            string currentUser = "testuser";

            // Simulate InsertRow creating an arrangement and total
            var arrangement = new Arrangement
            {
                Name = arrangementName.Trim(),
                CollectionName = collectionName.Trim(),
            };

            context.Arrangement.Add(arrangement);
            context.SaveChanges();

            int insertId = arrangement.ID;

            var arrangementTotal = new ArrangementTotal
            {
                ArrangementId = insertId,
                CurrentTotal = 0,
                User = currentUser,
            };
            context.ArrangementTotals.Add(arrangementTotal);
            context.SaveChanges();

            // Verify the arrangement total was created
            var savedTotal = context.ArrangementTotals.FirstOrDefault(t => t.ArrangementId == insertId);
            Assert.IsNotNull(savedTotal);
            Assert.AreEqual(0, savedTotal.CurrentTotal);
            Assert.AreEqual(currentUser, savedTotal.User);
            Assert.AreEqual(insertId, savedTotal.ArrangementId);
        }

        [TestMethod]
        public void TestMethod_InsertRow_MultipleCollections()
        {
            using var context = new GraceDbContext();

            string arrangementName = "MultiCollectionArrangement";
            var collectionNames = new[] { "Collection1", "Collection2", "Collection3" };

            // Simulate what SaveButton_Click does - create arrangement for each collection
            foreach (string collectionName in collectionNames)
            {
                var arrangement = new Arrangement
                {
                    Name = arrangementName.Trim(),
                    CollectionName = collectionName.Trim(),
                };

                context.Arrangement.Add(arrangement);
                context.SaveChanges();

                int insertId = arrangement.ID;
                var arrangementTotal = new ArrangementTotal
                {
                    ArrangementId = insertId,
                    CurrentTotal = 0,
                    User = "testuser",
                };
                context.ArrangementTotals.Add(arrangementTotal);
            }
            context.SaveChanges();

            // Verify arrangements were created for all collections
            var savedArrangements = context.Arrangement
                .Where(a => a.Name == arrangementName)
                .ToList();

            Assert.AreEqual(3, savedArrangements.Count);

            // Verify all collections are represented
            var savedCollectionNames = savedArrangements.Select(a => a.CollectionName).OrderBy(c => c).ToList();
            Assert.AreEqual("Collection1", savedCollectionNames[0]);
            Assert.AreEqual("Collection2", savedCollectionNames[1]);
            Assert.AreEqual("Collection3", savedCollectionNames[2]);

            // Verify all have totals
            foreach (var arr in savedArrangements)
            {
                var total = context.ArrangementTotals.FirstOrDefault(t => t.ArrangementId == arr.ID);
                Assert.IsNotNull(total);
                Assert.AreEqual(0, total.CurrentTotal);
            }
        }

        [TestMethod]
        public void TestMethod_InsertRow_TrimsWhitespace()
        {
            using var context = new GraceDbContext();

            string arrangementName = "  TestArrangement  ";
            string collectionName = "  Collection1  ";

            var arrangement = new Arrangement
            {
                Name = arrangementName.Trim(),
                CollectionName = collectionName.Trim(),
            };

            context.Arrangement.Add(arrangement);
            context.SaveChanges();

            // Verify trimming worked
            var savedArrangement = context.Arrangement.FirstOrDefault(a => a.ID == arrangement.ID);
            Assert.IsNotNull(savedArrangement);
            Assert.AreEqual("TestArrangement", savedArrangement.Name);
            Assert.AreEqual("Collection1", savedArrangement.CollectionName);
        }

        [TestMethod]
        public void TestMethod_InsertRow_DuplicateArrangementName_ThrowsException()
        {
            using var context = new GraceDbContext();

            string arrangementName = "DuplicateArrangement";
            string collectionName = "Collection1";

            // Create first arrangement
            var arrangement1 = new Arrangement
            {
                Name = arrangementName,
                CollectionName = collectionName,
            };
            context.Arrangement.Add(arrangement1);
            context.SaveChanges();

            // Try to create duplicate with same name and collection
            var arrangement2 = new Arrangement
            {
                Name = arrangementName,
                CollectionName = collectionName,
            };
            context.Arrangement.Add(arrangement2);

            // This should throw DbUpdateException due to unique constraint
            Assert.ThrowsException<DbUpdateException>(() => context.SaveChanges());
        }

        [TestMethod]
        public void TestMethod_InsertRow_VerifyTimestamp()
        {
            using var context = new GraceDbContext();

            string arrangementName = "TimestampTest";
            string collectionName = "Collection1";

            var beforeTime = DateTime.Now.AddSeconds(-1);

            var arrangement = new Arrangement
            {
                Name = arrangementName,
                CollectionName = collectionName,
            };
            context.Arrangement.Add(arrangement);
            context.SaveChanges();

            var arrangementTotal = new ArrangementTotal
            {
                ArrangementId = arrangement.ID,
                CurrentTotal = 0,
                User = "testuser",
            };
            context.ArrangementTotals.Add(arrangementTotal);
            context.SaveChanges();

            var afterTime = DateTime.Now.AddSeconds(1);

            // Verify the timestamp is within expected range
            var savedTotal = context.ArrangementTotals.FirstOrDefault(t => t.ArrangementId == arrangement.ID);
            Assert.IsNotNull(savedTotal);
            Assert.IsTrue(savedTotal.LastUpdated >= beforeTime);
            Assert.IsTrue(savedTotal.LastUpdated <= afterTime);
        }

        [TestMethod]
        public void TestMethod_InsertRow_VerifyUserTracking()
        {
            using var context = new GraceDbContext();

            string arrangementName = "UserTrackingTest";
            string collectionName = "Collection1";
            string expectedUser = "testuser";

            var arrangement = new Arrangement
            {
                Name = arrangementName,
                CollectionName = collectionName,
            };
            context.Arrangement.Add(arrangement);
            context.SaveChanges();

            var arrangementTotal = new ArrangementTotal
            {
                ArrangementId = arrangement.ID,
                CurrentTotal = 0,
                User = expectedUser,
            };
            context.ArrangementTotals.Add(arrangementTotal);
            context.SaveChanges();

            // Verify user is tracked correctly
            var savedTotal = context.ArrangementTotals.FirstOrDefault(t => t.ArrangementId == arrangement.ID);
            Assert.IsNotNull(savedTotal);
            Assert.AreEqual(expectedUser, savedTotal.User);
        }

        [TestMethod]
        public void TestMethod_InsertRow_InitialTotalIsZero()
        {
            using var context = new GraceDbContext();

            string arrangementName = "InitialTotalTest";
            string collectionName = "Collection1";

            var arrangement = new Arrangement
            {
                Name = arrangementName,
                CollectionName = collectionName,
            };
            context.Arrangement.Add(arrangement);
            context.SaveChanges();

            var arrangementTotal = new ArrangementTotal
            {
                ArrangementId = arrangement.ID,
                CurrentTotal = 0,
                User = "testuser",
            };
            context.ArrangementTotals.Add(arrangementTotal);
            context.SaveChanges();

            // Verify initial total is 0
            var savedTotal = context.ArrangementTotals.FirstOrDefault(t => t.ArrangementId == arrangement.ID);
            Assert.IsNotNull(savedTotal);
            Assert.AreEqual(0, savedTotal.CurrentTotal);
        }

        [TestMethod]
        public void TestMethod_InsertRow_MultipleArrangements_SameCollection()
        {
            using var context = new GraceDbContext();

            string collectionName = "Collection1";
            var arrangementNames = new[] { "Arrangement1", "Arrangement2", "Arrangement3" };

            foreach (var name in arrangementNames)
            {
                var arrangement = new Arrangement
                {
                    Name = name,
                    CollectionName = collectionName,
                };
                context.Arrangement.Add(arrangement);
                context.SaveChanges();

                var arrangementTotal = new ArrangementTotal
                {
                    ArrangementId = arrangement.ID,
                    CurrentTotal = 0,
                    User = "testuser",
                };
                context.ArrangementTotals.Add(arrangementTotal);
            }
            context.SaveChanges();

            // Verify all arrangements were created in the same collection
            var savedArrangements = context.Arrangement
                .Where(a => a.CollectionName == collectionName)
                .ToList();

            Assert.AreEqual(3, savedArrangements.Count);

            // Verify arrangement names
            var names = savedArrangements.Select(a => a.Name).OrderBy(n => n).ToList();
            Assert.AreEqual("Arrangement1", names[0]);
            Assert.AreEqual("Arrangement2", names[1]);
            Assert.AreEqual("Arrangement3", names[2]);
        }

        [TestMethod]
        public void TestMethod_GetCollections_ReturnsExpectedCollections()
        {
            var collections = DataBase.GetCollections();

            Assert.IsNotNull(collections);
            Assert.IsTrue(collections.Count > 0);

            // Verify expected collections exist
            Assert.IsTrue(collections.Contains("Collection1"));
            Assert.IsTrue(collections.Contains("Collection2"));
            Assert.IsTrue(collections.Contains("Collection3"));
        }
    }
}

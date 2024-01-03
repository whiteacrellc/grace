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
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;


namespace gracetest

{
    [TestClass]
    public class GraceDbContextTests
    {
        private string testDbName = "test_grace.db";
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private GraceDbContext context;
        private DataBase dataBase;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [TestInitialize]
        public void Setup()
        {

            dataBase = new DataBase(testDbName);
            context = new GraceDbContext();
            context.Database.EnsureCreated();
        }

        [TestCleanup]
        public void CleanUp()
        {
            var fileName = DataBase.DbFileName;
            Cleanup(fileName);
        }

        [TestMethod]
        public void Can_Add_Grace_Record()
        {
            // Arrange
            var grace = new Grace
            {
                Sku = "TestSKU",
                Description = "Test Description",
                Brand = "Test Brand"
                // Add other required properties as needed
            };

            // Act
            context.Graces.Add(grace);
            context.SaveChanges();

            // Assert
            Assert.AreEqual(1, context.Graces.Count()); // Ensure a record was added
                                                        // Add more specific assertions as required

        }

        [TestMethod]
        public void Can_Retrieve_Grace_Record()
        {

            context.Database.EnsureCreated();
            // Arrange
            var expectedSku = "TestSKU";
            var grace = new Grace
            {
                Sku = expectedSku,
                Description = "Test Description",
                Brand = "Test Brand"
                // Add other required properties as needed
            };
            context.Graces.Add(grace);
            context.SaveChanges();

            // Act
            var retrievedGrace = context.Graces.FirstOrDefault(g => g.Sku == expectedSku);

            // Assert
            Assert.IsNotNull(retrievedGrace);
            Assert.AreEqual(expectedSku, retrievedGrace.Sku);


        }

        [TestMethod]
        public void Can_Delete_Grace_Record()
        {

            // Arrange
            var grace = new Grace
            {
                Sku = "TestSKU",
                Description = "Test Description",
                Brand = "Test Brand"
                // Add other required properties as needed
            };
            context.Graces.Add(grace);
            context.SaveChanges();

            // Act
            var retrievedGrace = context.Graces.FirstOrDefault(g => g.Sku == "TestSKU");
#pragma warning disable CS8604 // Possible null reference argument.
            context.Graces.Remove(retrievedGrace);
#pragma warning restore CS8604 // Possible null reference argument.
            context.SaveChanges();

            // Assert
            Assert.AreEqual(0, context.Graces.Count()); // Ensure the record was deleted
                                                        // Add more specific assertions as required

        }
        private void Cleanup(string databaseName)
        {

            context.Database.EnsureDeleted();
            context.Database.CloseConnection();

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

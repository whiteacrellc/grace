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
using grace.data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NLog;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: InternalsVisibleTo("gracetest")]

namespace grace
{

    public class DataBase : IDisposable
    {
        public static Logger Logger => logger;

        public static string ConnectionString { get => connectionString; set => connectionString = value; }
        public string DbName { get => dbName; set => dbName = value; }
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public string DbFileName { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CA2211 // Non-constant fields should not be visible
        private static string connectionString;
#pragma warning restore CA2211 // Non-constant fields should not be visible
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private string dbName = "grace.db";
        private bool disposedValue;

        public GraceDbContext graceDb { get; private set; }

        public DataBase()

        {
            DbFileName = string.Empty;
            ConnectionString = CreateDatabaseFile();
            graceDb = new GraceDbContext(ConnectionString);
            graceDb.Database.EnsureCreated();
        }

        public DataBase(string fileName)
        {
            DbName = fileName;
            DbFileName = string.Empty;
            ConnectionString = CreateDatabaseFile();
            graceDb = new GraceDbContext();
            graceDb.Database.EnsureCreated();

        }

        public string CreateDatabaseFile()
        {
            // Get the program's directory
            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Specify the database file path in the program's directory
            DbFileName = Path.Combine(programDirectory, DbName);

            var connectionString = new SqliteConnectionStringBuilder()
            {
                DataSource = DbFileName,
                Mode = SqliteOpenMode.ReadWriteCreate,
                Cache = SqliteCacheMode.Private
            }.ToString();

            Logger.Info(connectionString);
            return connectionString;
        }

        public bool HaveData()
        {
            int numrows = graceDb.Graces.ToList().Count;
            return (numrows > 0) ? true : false;
        }

        public void LoadFromExcel(string filename)
        {
            // Delete the old databases
            InitializeDatabase();

            FileInfo fileInfo = new FileInfo(filename);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming the first worksheet is the one to read

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++)
                {
                    var rowobj = worksheet.Cells[row, 1, row, worksheet.Dimension.Columns];

                    // if the first column is not null we assume we have a
                    // valid row
                    var firstCol = worksheet.Cells[row, 1].Value;
                    if (firstCol != null)
                    {
                        string brand = (string)worksheet.Cells[row, 1].Value;
                        string barcode = checkString(worksheet.Cells[row, 2].Value);
                        string sku = checkString(worksheet.Cells[row, 3].Value);
                        string description = (string)worksheet.Cells[row, 4].Value;
                        var a = (worksheet.Cells[row, 11].Value);
                        string availabilty = checkString(worksheet.Cells[row, 11].Value);
                        int previousTotal = Convert.ToInt32(worksheet.Cells[row, 12].Value);
                        int total = Convert.ToInt32(worksheet.Cells[row, 13].Value);



                        int insertId = InsertRow(sku, description, brand,
                             availabilty, barcode);
                        AddTotal(previousTotal, total, insertId);
                        var col1 = (string)worksheet.Cells[row, 5].Value;
                        AddCollection(col1, insertId);

                        var col2 = (string)worksheet.Cells[row, 6].Value;
                        AddCollection(col2, insertId);

                        var col3 = (string)worksheet.Cells[row, 7].Value;
                        AddCollection(col3, insertId);

                        var col4 = (string)worksheet.Cells[row, 8].Value;
                        AddCollection(col4, insertId);

                        var col5 = (string)worksheet.Cells[row, 9].Value;
                        AddCollection(col5, insertId);

                        var col6 = (string)worksheet.Cells[row, 10].Value;
                        AddCollection(col6, insertId);
                    }
                }
            }
        }

        public void InitializeDatabase()
        {
            graceDb.Database.EnsureCreated();
            graceDb.Database.ExecuteSqlRaw("DELETE FROM Graces");
            InitPrefs();
            AdminStuff.InitUserDB();
        }

        private void InitPrefs()
        {
            bool created = graceDb.PrefsDb.Any();
            if (created == false)
            {
                Preferences prefs = new Preferences();
                prefs.AddOrUpdateIntPreference("rowheight", 35);
                prefs.AddOrUpdateIntPreference("rowsperpage", 45);
                prefs.AddOrUpdateIntPreference("headerheight", 40);
            }

        }

        int InsertRow(string sku, string description, string brand,
          string availability, string barcode)
        {
            int insertId = 0;


            // Create a new Grace object to insert
            var newGrace = new Grace
            {
                Sku = sku,
                Description = description,
                Brand = brand,
                Availability = availability,
                Barcode = barcode
            };

            // Add the new Grace object to the DbContext
            graceDb.Graces.Add(newGrace);

            // Save the changes to the database
            graceDb.SaveChanges();

            insertId = newGrace.ID;

            return insertId;

        }
        internal void AddCollection(string collection, int grace_id)
        {
            if (collection == null) return;


            var newCollection = new CollectionName
            {
                Name = collection,
                GraceId = grace_id
            };

            graceDb.Collections.Add(newCollection);
            graceDb.SaveChanges();

        }

        void AddTotal(int previous_total, int total, int grace_id)
        {
            var newTotal = new Total
            {
                date_field = Globals.GetInstance().currentHeaderDate,
                total = total,
                GraceId = grace_id
            };
            graceDb.Totals.Add(newTotal);

            newTotal = new Total
            {
                date_field = Globals.GetInstance().previousHeaderDate,
                total = previous_total,
                GraceId = grace_id
            };
            graceDb.Totals.Add(newTotal);
            graceDb.SaveChanges();

        }

        private static string checkString(object n)
        {
            string ret = "";
            if (n is string)
            {
                ret = Convert.ToString(n);
            }
            else if (n is double)
            {
                ret = ((double)n).ToString();
            }
            else if (n is int)
            {
                ret = ((int)n).ToString();
            }
            else
            {
                Logger.Error("cannot convert " + n);
            }
            return ret.Trim();
        }
        public void CleanUp()
        {
            graceDb.Database.EnsureDeleted();
        }

        public GraceRow? GetGraceRowFromSku(string sku)
        {
            var graceRowsData =
                        graceDb.GraceRows.FirstOrDefault(item => item.Sku == sku);
            if (graceRowsData != null)
            {
               return graceRowsData;
            }
            return null;
        }

        public Grace? GetGraceFromSku(string sku)
        {
            var graceData =
                        graceDb.Graces.FirstOrDefault(item => item.Sku == sku);
            if (graceData != null)
            {
                return graceData;
            }
            return null;
        }

        public List<string?> CollectionNames
        {
            get
            {
                var distinctCollectionNames = graceDb.Collections
                    .Select(e => e.Name)
                    .Distinct()
                    .ToList();
                return distinctCollectionNames ?? new List<string?>();
            }
        }

        public void UpdateGraceRowRow(GraceRow graceRow)
        {
            var gracesRow =
                 graceDb.Graces.FirstOrDefault(item => item.ID == graceRow.GraceId);

            var totals = graceDb.Totals
                .Where(c => c.GraceId == graceRow.GraceId)
                .OrderByDescending(c => c.date_field) // Assuming you have a DateTime property in your CollectionName entity
                .Take(2)
                .ToList();

            var collections = graceDb.Collections
                .Where(c => c.GraceId == graceRow.GraceId)
                .ToList();

            var graceRowToUpdate = graceDb.GraceRows
               .SingleOrDefault(row => row.ID == graceRow.ID);

            var graceToUpdate = graceDb.Graces.SingleOrDefault(row => row.ID == graceRow.GraceId);

            if (graceToUpdate == null)
            {
                logger.Fatal("can't find graces row from gracerow in UpdateGraceRow_Row");
                return;
            }

            if (graceRowToUpdate != null)
            {
                // Update field from Graces table
                if (graceRowToUpdate.Description != graceRow.Description)
                {
                    graceRowToUpdate.Description = graceRow.Description;
                    graceToUpdate.Description = graceRow.Description;
                }
                if (graceRowToUpdate.Sku != graceRow.Sku)
                {
                    graceRowToUpdate.Sku = graceRow.Sku;
                    graceToUpdate.Sku = graceRow.Sku;
                }
                if (graceRowToUpdate.Brand != graceRow.Brand)
                {
                    graceRowToUpdate.Brand = graceRow.Brand;
                    graceToUpdate.Brand = graceRow.Brand;
                }
                if (graceRowToUpdate.Availability != graceRow.Availability)
                {
                    graceRowToUpdate.Availability = graceRow.Availability;
                    graceToUpdate.Availability = graceRow.Availability;
                }
                if (graceRowToUpdate.BarCode != graceRow.BarCode)
                {
                    graceRowToUpdate.BarCode = graceRow.BarCode;
                    graceToUpdate.Barcode = graceRow.BarCode;
                }

                var lastTotal = totals.First();
                if (lastTotal != null)
                {
                    if (lastTotal.total != graceRowToUpdate.Total)
                    {
                        var newTotal = new Total
                        {
                            date_field = DateTime.Now,
                            total = graceRowToUpdate.Total
                        };

                        // Add the new Total object to the context
                        graceDb.Totals.Add(newTotal);

                    }
                }

            }


        }

        public void DeleteCollectionRow (int GraceId, string name)
        {
            // Find the row to check if it exists
            var rowToDelete = graceDb.Collections
                .SingleOrDefault(c => c.GraceId == GraceId && c.Name == name);

            if (rowToDelete != null)
            {
                // Row exists, so delete it
                graceDb.Collections.Remove(rowToDelete);
                graceDb.SaveChanges();
            }
        }
    

        public void AddCollectionRow(int GraceId, string name)
        {
            bool rowExists = graceDb.Collections
                .Any(c => c.GraceId == GraceId && c.Name == name);
            if (rowExists)
            {
                return;
            }

            // Row does not exist, so insert a new row
            var newRow = new CollectionName
            {
                GraceId = GraceId,
                Name = name
                // Set other properties as needed
            };

            graceDb.Collections.Add(newRow);
            graceDb.SaveChanges();
        }

        public void UpadeGraceRowCollection(int GraceId)
        {
            // First null out the columns

            // Find the GraceRow entities with the specified GraceId
            var graceRow = graceDb.GraceRows
                .Where(row => row.GraceId == GraceId)
                .SingleOrDefault();

            if (graceRow is not null)
            {
                // Set Col1 to Col6 to null
                graceRow.Col1 = null;
                graceRow.Col2 = null;
                graceRow.Col3 = null;
                graceRow.Col4 = null;
                graceRow.Col5 = null;
                graceRow.Col6 = null;

                var collectionRows = graceDb.Collections.
                    Where(row => row.GraceId == GraceId)
                    .ToList();
                for (int i = 0; i < collectionRows.Count; i++)
                {
                    var collectionRow = collectionRows[i];
                    switch (i)
                    {
                        case 0:
                            graceRow.Col1 = collectionRow.Name;
                            break;
                        case 1:
                            graceRow.Col2 = collectionRow.Name;
                            break;
                        case 2:
                            graceRow.Col3 = collectionRow.Name;
                            break;
                        case 3:
                            graceRow.Col4 = collectionRow.Name;
                            break;
                        case 4:
                            graceRow.Col5 = collectionRow.Name;
                            break;
                        case 5:
                            graceRow.Col6 = collectionRow.Name;
                            break;
                        default:
                            logger.Error($"Too many collections for graceId {GraceId}");
                            break;
                    }
                }
                // save changes to the changed row
                graceDb.SaveChanges();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    graceDb.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        ~DataBase()
        {
             Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

}


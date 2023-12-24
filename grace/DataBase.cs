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
using grace.data.models;

[assembly: InternalsVisibleTo("gracetest")]

namespace grace
{

    public class DataBase
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


        public DataBase()

        {
            DbFileName = string.Empty;
            ConnectionString = CreateDatabaseFile();
            using (var context = new GraceDbContext(ConnectionString))
            {
                context.Database.EnsureCreated();
            }
        }

        public DataBase(string fileName)
        {
            DbName = fileName;
            DbFileName = string.Empty;
            ConnectionString = CreateDatabaseFile();
            using (var context = new GraceDbContext())
            {
                context.Database.EnsureCreated();
            }

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

        public static bool HaveData()
        {
            int numrows = 0;
            using (var context = new GraceDbContext())
            {
                numrows = context.Graces.ToList().Count;
            }
            return (numrows > 0) ? true : false;
        }

        public static void LoadFromExcel(string filename)
        {
            // Delete the old databases
            InitializeDatabase();

            try
            {

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
                            int total = Convert.ToInt32(worksheet.Cells[row, 13].Value);



                            int insertId = InsertRow(sku, description, brand,
                                 availabilty, barcode);
                            AddTotal(total, insertId);
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
            } catch (Exception ex) {
                var exstring = ex.ToString();
                MessageBox.Show($"Error Loading file {exstring}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void InitializeDatabase()
        {
            using (var context = new GraceDbContext())
            {
                context.Database.EnsureCreated();
                context.Database.ExecuteSqlRaw("DELETE FROM Graces");
            }
            InitPrefs();
            AdminStuff.InitUserDB();
        }

        private static void InitPrefs()
        {
            using (var context = new GraceDbContext())
            {
                bool created = context.PrefsDb.Any();
                if (created == false)
                {
                    Preferences prefs = new Preferences();
                    prefs.AddOrUpdateIntPreference("rowheight", 35);
                    prefs.AddOrUpdateIntPreference("rowsperpage", 45);
                    prefs.AddOrUpdateIntPreference("headerheight", 40);
                }
            }
        }

        public static int InsertRow(string sku, string description, string brand,
          string availability, string barcode)
        {
            int insertId = 0;

            using (var context = new GraceDbContext())
            {

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
                context.Graces.Add(newGrace);

                // Save the changes to the database
                context.SaveChanges();

                insertId = newGrace.ID;
            }
            return insertId;

        }
        public static int AddCollection(string collection, int graceId)
        {
            int id = 0;
            using (var context = new GraceDbContext())
            {
                var newCollection = new CollectionName
                {
                    Name = collection,
                    GraceId = graceId
                };

                context.Collections.Add(newCollection);
                context.SaveChanges();


                id = newCollection.ID;
            }
            return id;
        }

        public static int AddTotal(int total, int graceId)
        {
            int id = 0;
            using (var context = new GraceDbContext())
            {
                var newTotal = new Total
                {
                    date_field = Globals.GetInstance().currentHeaderDate,
                    total = total,
                    GraceId = graceId
                };
                context.Totals.Add(newTotal);
                context.SaveChanges();
                id = newTotal.ID;
            }
            return id;
        }

        public static bool CreateGraceRow(int graceId)
        {
            using (var context = new GraceDbContext())
            {
                GraceRow graceRow = new GraceRow();
                var grace = context.Graces.Find(graceId);
                if (grace != null)
                {
                    graceRow.Sku = grace.Sku;
                    graceRow.BarCode = grace.Barcode;
                    graceRow.Brand = grace.Brand;
                    graceRow.Description = grace.Description;
                    graceRow.Availability = grace.Availability;
                }
                else
                {
                    return true;
                }
                graceRow.Total = GetTotal(graceId);

                // Set columns
                graceRow.Col1 = null;
                graceRow.Col2 = null;
                graceRow.Col3 = null;
                graceRow.Col4 = null;
                graceRow.Col5 = null;
                graceRow.Col6 = null;

                var collectionRows = context.Collections.
                    Where(row => row.GraceId == graceId)
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
                            logger.Error($"Too many collections for graceId {graceId}");
                            break;
                    }
                }
                context.GraceRows.Add( graceRow );
                context.SaveChanges();
            }
            return false;
        }
#pragma warning disable CS8600
#pragma warning disable CA1305
        private static string? checkString(object n)
        {
            string ret = string.Empty;
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
            return ret;
        }
#pragma warning restore CS8600
#pragma warning restore CA1305

        public static GraceRow? GetGraceRowFromSku(string sku)
        {
            GraceRow? row;
            using (var context = new GraceDbContext())
            {
                row = context.GraceRows.FirstOrDefault(item => item.Sku == sku);
            }
            return row;
        }

        public static Grace? GetGraceFromSku(string sku)
        {
            Grace? row;
            using (var context = new GraceDbContext())
            {
                row = context.Graces.FirstOrDefault(item => item.Sku == sku);
            }
            return row;
        }

        public static List<string?> CollectionNames
        {
            get
            {
                var list = new List<string?>();
                using (var context = new GraceDbContext())
                {
                    var distinctCollectionNames = context.Collections
                    .Select(e => e.Name)
                    .Distinct()
                    .ToList();
                    list = distinctCollectionNames ?? new List<string?>();
                }
                return list;
            }
        }

       

        public static void DeleteCollectionRow (int GraceId, string name)
        {
            using (var context = new GraceDbContext())
            {
                // Find the row to check if it exists
                var rowToDelete = context.Collections
                .SingleOrDefault(c => c.GraceId == GraceId && c.Name == name);

                if (rowToDelete != null)
                {
                    // Row exists, so delete it
                    context.Collections.Remove(rowToDelete);
                    context.SaveChanges();
                }
            }
        }
    

        public static void AddCollectionRow(int GraceId, string name)
        {
            using (var context = new GraceDbContext())
            {
                bool rowExists = context.Collections
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

                context.Collections.Add(newRow);
                context.SaveChanges();
            }
        }

        public static int GetTotal(int graceId)
        {
            int total = 0;
            using (var context = new GraceDbContext())
            {
                var totalList = context.Totals
                    .Where(t => t.GraceId == graceId)
                    .OrderByDescending(t => t.date_field)
                    .Take(1)
                    .ToList();
                if (totalList.Count > 0)
                {
                    total = totalList[0].total;
                }
            }
            return total;
        }

        public static void UpdateGraceRowCollection(int GraceId)
        {

            using (var context = new GraceDbContext())
            {
                // Find the GraceRow entities with the specified GraceId
                var graceRow = context.GraceRows
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

                    var collectionRows = context.Collections.
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
                    context.SaveChanges();
                }
            }
        }

    }

}


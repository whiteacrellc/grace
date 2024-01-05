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
using System.Data.Entity;
using Microsoft.Office.Interop.Excel;
using System.Xml.Linq;

[assembly: InternalsVisibleTo("gracetest")]

namespace grace
{

    public class DataBase
    {
        public static Logger Logger => logger;

        public static string ConnectionString { get => connectionString; set => connectionString = value; }
        public string DbName { get => dbName; set => dbName = value; }
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static string DbFileName { get; set; }

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

        public class CheckOut
        {
            public string Sku { get; set; }
            public string Description { get; set; }
            public string Brand { get; set; }
            public string Barcode { get; set; }
            public int Total {  get; set; }
            public int GraceId { get; set; }
        }

        public static List<CheckOut> GetPulledGrid()
        {
            using (var dbContext = new GraceDbContext()) {
                var result = (
                    from graces in dbContext.Graces
                    join total in dbContext.Totals on graces.ID equals total.GraceId
                    orderby graces.Sku descending
                    select new CheckOut
                    {
                        Sku = graces.Sku,
                        Description = graces.Description,
                        Brand = graces.Brand,
                        Barcode = graces.Barcode,
                        Total = total.total,
                        GraceId = graces.ID
                    }
                ).ToList();
                return result;
            }
        }

        public static List<CheckOut> GetPulledGridFromBarCode(string scannedBarcode)
        {
            using (var dbContext = new GraceDbContext())
            {
                var filteredProducts = (
                    from graces in dbContext.Graces
                    join total in dbContext.Totals on graces.ID equals total.GraceId
                    where (graces.Barcode != null && graces.Barcode.Equals(scannedBarcode))
                    orderby graces.Sku descending
                    select new CheckOut
                    {
                        Sku = graces.Sku,
                        Description = graces.Description,
                        Brand = graces.Brand,
                        Barcode = graces.Barcode,
                        Total = total.total,
                        GraceId = graces.ID
                    }
                ).ToList();
                return filteredProducts;
            }
        }


        public static List<CheckOut> GetFilteredPulledGrid(string searchTerm)
        {
            using (var dbContext = new GraceDbContext())
            {
                var filteredProducts = (
                    from graces in dbContext.Graces
                    join total in dbContext.Totals on graces.ID equals total.GraceId
                    where (searchTerm == null || (graces.Sku.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) ||
                    graces.Description.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)))
                    orderby graces.Sku descending
                    select new CheckOut
                    {
                        Sku = graces.Sku,
                        Description = graces.Description,
                        Brand = graces.Brand,
                        Barcode = graces.Barcode,
                        Total = total.total,
                        GraceId = graces.ID
                    }
                ).ToList();
                return filteredProducts;
            }
        }
        public class CheckInData
        {
            public string UserName { get; set; }
            public string Sku { get; set; }
            public string Brand { get; set; }
            public string Description { get; set; }
            public string? BarCode { get; set; }
            public DateTime LastUpdated { get; set; }
            public string Collection { get; set; }
            public int UserTotal { get; set; }
            public string CheckIn { get; set; } = string.Empty;
            public int GraceId { get; set; }
        }
        public static List<CheckInData> GetCheckedOutGrid(int user_id)
        {
            using (var dbContext = new GraceDbContext())
            {
                // Performing the join and projection
                var result = (
                    from gr in dbContext.GraceRows
                            join pulled in dbContext.PulledDb on gr.GraceId equals pulled.GraceId
                            join user in dbContext.Users on pulled.UserId equals user.ID
                            join collection in dbContext.Collections on pulled.CollectionId equals collection.ID
                            where user.ID == user_id && pulled.IsCompleted == false
                            orderby pulled.LastUpdated ascending, pulled.CurrentTotal descending
                            select new CheckInData
                            {
                                 UserName = user.Username,
                                 Sku = gr.Sku,
                                 Brand = gr.Brand,
                                 Description = gr.Description,
                                 BarCode = gr.BarCode,
                                 Collection = collection.Name,
                                 LastUpdated = pulled.LastUpdated,
                                 UserTotal = pulled.Amount,
                                 CheckIn = string.Empty,
                                 GraceId = gr.GraceId
                            }).ToList();
                return result;
            }
        }

        public static List<CheckInData> GetCheckedOutGridAll()
        {
            using (var dbContext = new GraceDbContext())
            {
                // Performing the join and projection
                var result = (
                    from gr in dbContext.GraceRows
                    join pulled in dbContext.PulledDb on gr.GraceId equals pulled.GraceId
                    join user in dbContext.Users on pulled.UserId equals user.ID
                    join collection in dbContext.Collections on pulled.CollectionId equals collection.ID
                    where pulled.IsCompleted == false
                    orderby user.Username descending, pulled.LastUpdated ascending, pulled.CurrentTotal descending
                    select new CheckInData
                    {
                        UserName = user.Username,
                        Sku = gr.Sku,
                        Brand = gr.Brand,
                        Description = gr.Description,
                        BarCode = gr.BarCode,
                        Collection = collection.Name,
                        LastUpdated = pulled.LastUpdated,
                        UserTotal = pulled.Amount,
                        CheckIn = string.Empty,
                        GraceId = gr.GraceId
                    }).ToList();
                return result;
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
                    Preferences.AddOrUpdateIntPreference(Preferences.Preference.RowHeight, 35);
                    Preferences.AddOrUpdateIntPreference(Preferences.Preference.RowsPerPage, 45);
                    Preferences.AddOrUpdateIntPreference(Preferences.Preference.HeaderHeight, 40);
                    Preferences.AddOrUpdateBooleanPreference(Preferences.Preference.BarCodeAutoOpen, true);
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
        public static int AddCollection(string? collection, int graceId)
        {
            int id = 0;
            if (collection != null)
            {
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

        

        public static int CreateGraceRow(int graceId)
        {
            using (var context = new GraceDbContext())
            {
                int newGraceId = 0;
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
                    return 0;
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
                graceRow.GraceId =  graceId;
                context.GraceRows.Add( graceRow );
                context.SaveChanges();
                newGraceId = graceRow.ID;
                return newGraceId;
            }
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
            using (var context = new GraceDbContext())
            {
                return context.GraceRows.FirstOrDefault(item => item.Sku == sku);
            }
        }

        public static List<GraceRow> GetGraceRows(List<CollectionName> names)
        {
            using (var context = new GraceDbContext())
            {
                List<GraceRow> result = new List<GraceRow> ();
                foreach (var name in names)
                {
                    var row = context.GraceRows.FirstOrDefault(e => e.GraceId ==
                        name.GraceId);
                    if (row != null)
                    {
                        result.Add(row);
                    }
                }
                return result;
            }
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

        public static int GetUserIdFromName(string name)
        {
            int id = 0;
            using (var context = new GraceDbContext())
            {
                var user = context.Users.FirstOrDefault(item => item.Username == name);
                if (user != null)
                {
                    id = user.ID;
                }
            }
            return id;
        }

        public static List<IGrouping<string, CollectionName>> OrderedCollectionNames()
        {
        
            using (var context = new GraceDbContext())
            {
                // Group by Name and order by Name alphabetically
                var collections = context.Collections
                    .OrderBy(cn => cn.Name) // Order by Name
                    .GroupBy(cn => cn.Name) // Group by Name
                    .ToList();
                return collections;
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

        public static int GetCollectionId(int graceId, string name)
        {
            using (var context = new GraceDbContext())
            {
                var row = context.Collections
                    .SingleOrDefault(c => c.GraceId == graceId && c.Name == name);
                return row.GraceId;
            }
        }

        public static int GetTotal(int graceId)
        {

            using (var context = new GraceDbContext())
            {
                var total = context.Totals
                    .Where(t => t.GraceId == graceId)
                    .OrderByDescending(t => t.date_field)
                    .Take(1)
                    .First();
                return total.total;
            }
        }

        public static void UpdateGraceRowTotal(int graceId, int newTotal)
        {
       
            using (var context = new GraceDbContext())
            {
                var graceRow = context.GraceRows.FirstOrDefault(e =>  e.GraceId == graceId);
                graceRow.Total = newTotal;
                context.SaveChanges();
            }
           
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


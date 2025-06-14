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
using grace.data.models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NLog;
using OfficeOpenXml;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("gracetest")]

namespace grace
{
#pragma warning disable CS8601
#pragma warning disable CS8619
    public class DataBase
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static string ConnectionString { get => connectionString; set => connectionString = value; }
        public string DbName { get => dbName; set => dbName = value; }
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
            var optionsBuilder = new DbContextOptionsBuilder<GraceDbContext>();
            optionsBuilder.UseSqlite(connectionString);
            using (var context = new GraceDbContext(optionsBuilder.Options))
            {
                var created = context.Database.EnsureCreated();
                if (!created)
                {
                    logger.Info("Database already exists");
                }
            }
            using (var context = new GraceDbContext(optionsBuilder.Options))
            {
                DbInitializer.CheckDbSchemaCurrent(context);
            }
        }

        public DataBase(string fileName)
        {
            DbName = fileName;
            DbFileName = string.Empty;
            ConnectionString = CreateDatabaseFile();
            var optionsBuilder = new DbContextOptionsBuilder<GraceDbContext>();
            optionsBuilder.UseSqlite(connectionString);
            using (var context = new GraceDbContext(optionsBuilder.Options))
            {
                var created = context.Database.EnsureCreated();
                if (!created)
                {
                    logger.Error("create database failed");
                    throw new InvalidOperationException("Create database failed");
                }
            }
            using (var context = new GraceDbContext(optionsBuilder.Options))
            {
                DbInitializer.CheckDbSchemaCurrent(context);
            }
        }

        public class CheckOut
        {
            public string Sku { get; set; }
            public string Description { get; set; }
            public string Brand { get; set; }
            public string BarCode { get; set; }
            public int Total { get; set; }
            public int GraceId { get; set; }
        }

        public static System.Data.DataTable GetPulledGrid()
        {

            System.Data.DataTable table = new();

            // Define columns
            table.Columns.Add("Sku", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Brand", typeof(string));
            table.Columns.Add("BarCode", typeof(string));
            table.Columns.Add("Total", typeof(int));
            table.Columns.Add("GraceId", typeof(int));

            using var dbContext = new GraceDbContext();

            var result = (
                from graces in dbContext.Graces
                join total in dbContext.Totals on graces.ID equals total.GraceId
                where total.LastUpdated == dbContext.Totals
                                              .Where(t => t.GraceId == graces.ID)
                                              .OrderByDescending(t => t.ID)
                                              .Max(t => t.LastUpdated)
                orderby graces.Sku ascending
                select new CheckOut
                {
                    Sku = graces.Sku,
                    Description = graces.Description,
                    Brand = graces.Brand,
                    BarCode = graces.BarCode,
                    Total = total.CurrentTotal,
                    GraceId = graces.ID
                }
            ).ToList();

            foreach (CheckOut? checkOut in result)
            {
                table.Rows.Add(checkOut.Sku, checkOut.Description,
                    checkOut.Brand, checkOut.BarCode, checkOut.Total,
                    checkOut.GraceId);
            }

            return table;
        }

        public static List<CheckOut> GetPulledItem(int pulledId)
        {
            using var dbContext = new GraceDbContext();

            var result = (
                from graces in dbContext.Graces
                join total in dbContext.Totals on graces.ID equals total.GraceId
                where total == dbContext.Totals
                                              .Where(t => t.GraceId == graces.ID)
                                              .OrderByDescending(t => t.ID)
                orderby graces.Sku ascending
                select new CheckOut
                {
                    Sku = graces.Sku,
                    Description = graces.Description,
                    Brand = graces.Brand,
                    BarCode = graces.BarCode,
                    Total = total.CurrentTotal,
                    GraceId = graces.ID
                }
            ).ToList();
            return result;
        }

        public static DataView GetPulledGridFromBarCode(string scannedBarcode)
        {
            DataTable dataTable = GetPulledGrid();

            if (scannedBarcode == null || scannedBarcode == string.Empty)
            {
                return new DataView(dataTable);
            }

            DataView view = new(dataTable)
            {
                RowFilter = "BarCode LIKE '%" + scannedBarcode + "%'"
            };
            return view;

        }


        public static DataView FilterTableBySku(System.Data.DataTable dataTable, string searchTerm)
        {
            DataView view = new(dataTable)
            {
                RowFilter = "Sku LIKE '%" + searchTerm + "%'"
            };
            return view;
        }
        public class CheckInData
        {
            public string UserName { get; set; }
            public string Sku { get; set; }
            public string Brand { get; set; }
            public string Description { get; set; }
            public string? BarCode { get; set; }
            public DateTime LastUpdated { get; set; }
            public int GraceId { get; set; }
            public string Collection { get; set; }
            public int UserTotal { get; set; }
            public string CheckIn { get; set; } = string.Empty;
        }
        public static System.Data.DataTable GetCheckedOutGrid(int user_id)
        {
            System.Data.DataTable table = new();

            // Define columns
            table.Columns.Add("UserName", typeof(string));
            table.Columns.Add("Sku", typeof(string));
            table.Columns.Add("Brand", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("BarCode", typeof(string));
            table.Columns.Add("Collection", typeof(string));
            table.Columns.Add("LastUpdated", typeof(DateTime));
            table.Columns.Add("UserTotal", typeof(int));
            table.Columns.Add("CheckIn", typeof(string));
            table.Columns.Add("GraceId", typeof(int));

            using GraceDbContext dbContext = new();
            // Performing the join and projection
            List<CheckInData> result = [.. (
                    from gr in dbContext.GraceRows
                    join pulled in dbContext.PulledDb on gr.GraceId equals pulled.GraceId
                    join user in dbContext.Users on pulled.UserId equals user.ID
                    join collection in dbContext.Collections on pulled.CollectionId equals collection.ID
                    where pulled.UserId == user_id && !pulled.IsCompleted
                    orderby pulled.LastUpdated descending, pulled.CurrentTotal descending
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
                    })];

            foreach (CheckInData data in result)
            {
                table.Rows.Add(data.UserName, data.Sku, data.Brand,
                    data.Description, data.BarCode, data.Collection,
                    data.LastUpdated, data.UserTotal, data.CheckIn,
                    data.GraceId);
            }

            return table;

        }

        public static System.Data.DataTable GetCheckedOutGridAll()
        {

            System.Data.DataTable table = new();

            // Define columns
            table.Columns.Add("UserName", typeof(string));
            table.Columns.Add("Sku", typeof(string));
            table.Columns.Add("Brand", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("BarCode", typeof(string));
            table.Columns.Add("Collection", typeof(string));
            table.Columns.Add("LastUpdated", typeof(DateTime));
            table.Columns.Add("UserTotal", typeof(int));
            table.Columns.Add("CheckIn", typeof(string));
            table.Columns.Add("GraceId", typeof(int));

            using GraceDbContext dbContext = new();
            // Performing the join and projection
            List<CheckInData> result = [.. (
                from gr in dbContext.GraceRows
                join pulled in dbContext.PulledDb on gr.GraceId equals pulled.GraceId
                join user in dbContext.Users on pulled.UserId equals user.ID
                join collection in dbContext.Collections on pulled.CollectionId equals collection.ID
                where !pulled.IsCompleted
                orderby user.Username ascending, pulled.LastUpdated descending, pulled.CurrentTotal descending
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
                })];

            foreach (CheckInData data in result)
            {
                table.Rows.Add(data);
            }

            return table;
        }

        public class ReportData
        {
            public string Sku { get; set; }
            public string Brand { get; set; }
            public string Description { get; set; }
            public string User { get; set; }
            public int Total { get; set; }
            public int PrevTotal { get; set; } = 0;
            public DateTime LastUpdated { get; set; }
            public string Note { get; set; }
            public int GraceId { get; set; }
        }

        public static System.Data.DataTable GetCheckedOutReport()
        {
            System.Data.DataTable table = new();

            // Define columns
            table.Columns.Add("Sku", typeof(string));
            table.Columns.Add("Brand", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("User", typeof(string));
            table.Columns.Add("Total", typeof(int));
            table.Columns.Add("PrevTotal", typeof(int));
            table.Columns.Add("LastUpdated", typeof(DateTime));
            table.Columns.Add("Note", typeof(string));


            using GraceDbContext dbContext = new();
            List<ReportData> result = [.. (
                from gr in dbContext.GraceRows
                join totals in dbContext.Totals on gr.GraceId equals totals.GraceId
                let prevTotal = dbContext.Totals
                    .Where(t => t.GraceId == gr.GraceId && t.LastUpdated < totals.LastUpdated)
                    .OrderByDescending(t => t.LastUpdated)
                    .Select(t => t.CurrentTotal)
                    .FirstOrDefault()
                orderby totals.LastUpdated descending, totals.CurrentTotal descending
                select new ReportData
                {
                    Sku = gr.Sku,
                    Brand = gr.Brand,
                    Description = gr.Description,
                    User = totals.User,
                    Total = totals.CurrentTotal,
                    PrevTotal = prevTotal,
                    LastUpdated = totals.LastUpdated,
                    Note = gr.Note,
                    GraceId = gr.GraceId
                }
            )];

            /*
            // Performing the join and projection
            List<ReportData> result = [.. (
                    from gr in dbContext.GraceRows
                    join totals in dbContext.Totals on gr.GraceId equals totals.GraceId
                    orderby totals.LastUpdated descending, totals.CurrentTotal descending
                    select new ReportData
                    {
                        Sku = gr.Sku,
                        Brand = gr.Brand,
                        Description = gr.Description,
                        User = totals.User,
                        Total = totals.CurrentTotal,
                        LastUpdated = totals.LastUpdated,
                        Note = gr.Note,
                        GraceId = gr.GraceId
                    })];
            */

            foreach (ReportData? report in result)
            {
                table.Rows.Add(report.Sku, report.Brand,
                    report.Description, report.User, report.Total, report.PrevTotal,
                    report.LastUpdated, report.Note);
            }
            return table;
        }


        private string CheckDbDirectory()
        {
            string myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string graceDir = Path.Combine(myDocs, "grace");
            if (!Directory.Exists(graceDir))
            {
                // If it doesn't, create the directory
                Directory.CreateDirectory(graceDir);
            }
            string dbDir = Path.Combine(graceDir, "live");
            if (!Directory.Exists(dbDir))
            {
                Directory.CreateDirectory(dbDir);
            }
            return dbDir;
        }


        public string CreateDatabaseFile()
        {
            // Get the program's directory
            string programDirectory = CheckDbDirectory();

            // Specify the database file path in the program's directory
            DbFileName = Path.Combine(programDirectory, DbName);

            var connectionString = new SqliteConnectionStringBuilder()
            {
                DataSource = DbFileName,
                Mode = SqliteOpenMode.ReadWriteCreate,
                Cache = SqliteCacheMode.Shared,
                Pooling = true,
            }.ToString();

            logger.Info(connectionString);
            return connectionString;
        }

        public static bool HaveData()
        {
            int numrows = 0;
            using (GraceDbContext context = new())
            {
                numrows = context.Graces.ToList().Count;
            }
            return numrows > 0;
        }

        public static void LoadFromExcel(string filename)
        {
            // Delete the old databases
            InitializeDatabase();

            try
            {

                FileInfo fileInfo = new(filename);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using ExcelPackage package = new(fileInfo);
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming the first worksheet is the one to read

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;
                int insertId = 0;

                for (int row = 2; row <= rowCount; row++)
                {
                    ExcelRange rowobj = worksheet.Cells[row, 1, row, worksheet.Dimension.Columns];

                    // if the first column is not null we assume we have a
                    // valid row
                    var firstCol = worksheet.Cells[row, 1].Value;
                    if (firstCol != null)
                    {
                        string brand = (string)worksheet.Cells[row, 1].Value;
                        string barcode = CheckString(worksheet.Cells[row, 2].Value);
                        string sku = CheckString(worksheet.Cells[row, 3].Value);
                        string description = (string)worksheet.Cells[row, 4].Value;
                        var a = worksheet.Cells[row, 11].Value;
                        string availability = (a == null) ? string.Empty : a as string;
                        int total = Convert.ToInt32(worksheet.Cells[row, 13].Value);



                        insertId = InsertRow(sku, description, brand,
                             availability, barcode);
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
                    // we need to add Other into the collection 
                    AddCollection("Other", insertId);
                }
            }
            catch (Exception ex)
            {
                string exstring = ex.ToString();
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

        public static void CloseDatabase()
        {
            using GraceDbContext context = new();
            context.Database.CloseConnection();
        }

        private static void InitPrefs()
        {
            using var context = new GraceDbContext();
            bool created = context.PrefsDb.Any();
            if (!created)
            {
                Preferences.AddOrUpdateIntPreference(Preferences.Preference.RowHeight, 35);
                Preferences.AddOrUpdateIntPreference(Preferences.Preference.RowsPerPage, 45);
                Preferences.AddOrUpdateIntPreference(Preferences.Preference.HeaderHeight, 40);
                Preferences.AddOrUpdateBooleanPreference(Preferences.Preference.BarCodeAutoOpen, true);
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
                    Sku = sku.Trim(),
                    Description = description.Trim(),
                    Brand = brand.Trim(),
                    Availability = availability.Trim(),
                    BarCode = barcode.Trim()
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
            if (string.IsNullOrEmpty(collection) == false)
            {
                using var context = new GraceDbContext();
                var newCollection = new CollectionName
                {
                    Name = collection.Trim(),
                    GraceId = graceId
                };

                context.Collections.Add(newCollection);
                context.SaveChanges();


                id = newCollection.ID;
            }
            return id;
        }

        public static CollectionName? getCollection(string collection, int graceId)
        {
            if (string.IsNullOrEmpty(collection) == false)
            {
                using var context = new GraceDbContext();
                CollectionName? c =
                    context.Collections.FirstOrDefault(e => e.Name == collection
                    && e.GraceId == graceId);
                return c;
            }
            return null;
        }

        public static int AddTotal(int total, int graceId)
        {
            int id = 0;
            String currentUser = Globals.GetInstance().CurrentUser;
            using (GraceDbContext context = new())
            {
                Total newTotal = new()
                {
                    LastUpdated = DateTime.Now,
                    CurrentTotal = total,
                    GraceId = graceId,
                    User = currentUser
                };
                context.Totals.Add(newTotal);
                context.SaveChanges();
                id = newTotal.ID;
            }
            return id;
        }

        public static void UpdateGraceRow(int graceId)
        {
            using GraceDbContext context = new();
            using Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                GraceRow? graceRow = context.GraceRows.FirstOrDefault(e => e.GraceId == graceId);
                Grace? grace = context.Graces.Find(graceId);
                if (grace != null)
                {
                    graceRow.Sku = grace.Sku;
                    graceRow.BarCode = grace.BarCode;
                    graceRow.Brand = grace.Brand;
                    graceRow.Description = grace.Description;
                    graceRow.Availability = grace.Availability;
                    graceRow.Note = grace.Note;
                }
                else
                {
                    logger.Error($"UpdateGraceRow couldn't find {graceId}");
                    return;
                }

                IQueryable<Total> currentTotal = context.Totals
                    .Where(t => t.GraceId == graceId)
                    .OrderByDescending(t => t.ID)
                    .Take(2);

                Total total1 = currentTotal.FirstOrDefault(); // Get the first result or null if none.
                Total total2 = currentTotal.Skip(1).FirstOrDefault(); // Get the second result or null if none.

                graceRow.LastUpdated = total1.LastUpdated;
                graceRow.Total = total1.CurrentTotal;
                graceRow.PrevTotal = (total2 == null) ? 0 : total2.CurrentTotal;

                // Set columns
                graceRow.Col1 = null;
                graceRow.Col2 = null;
                graceRow.Col3 = null;
                graceRow.Col4 = null;
                graceRow.Col5 = null;
                graceRow.Col6 = null;

                var collectionRows = context.Collections.
                    Where(row => row.GraceId == graceId && row.Name != "Other")
                    .ToList();
                for (int i = 0; i < collectionRows.Count; i++)
                {
                    var collectionRow = collectionRows[i];
                    if (collectionRow.Name == "Other")
                    {
                        continue;
                    }
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
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                logger.Error(ex);
            }

        }

        public static int GetGraceIdFromSku(string sku)
        {
            using GraceDbContext context = new();
            int graceId = 0;
            Grace? grace = context.Graces.FirstOrDefault(item => item.Sku == sku);
            if (grace != null)
            {
                graceId = grace.ID;
            }
            return graceId;
        }

        public static int CreateGraceRow(int graceId)
        {
            using GraceDbContext context = new();
            int newGraceId = 0;
            GraceRow graceRow = new();
            var grace = context.Graces.Find(graceId);
            if (grace != null)
            {
                graceRow.Sku = grace.Sku;
                graceRow.BarCode = grace.BarCode;
                graceRow.Brand = grace.Brand;
                graceRow.Description = grace.Description;
                graceRow.Availability = grace.Availability;
            }
            else
            {
                return 0;
            }

            IQueryable<Total> currentTotal = context.Totals
                .Where(t => t.GraceId == graceId)
                .OrderByDescending(t => t.ID)
                .Take(2);

            Total total1 = currentTotal.FirstOrDefault(); // Get the first result or null if none.
            Total total2 = currentTotal.Skip(1).FirstOrDefault(); // Get the second result or null if none.

            graceRow.LastUpdated = total1.LastUpdated;
            graceRow.Total = total1.CurrentTotal;
            graceRow.PrevTotal = (total2 == null) ? 0 : total2.CurrentTotal;

            // Set columns
            graceRow.Col1 = null;
            graceRow.Col2 = null;
            graceRow.Col3 = null;
            graceRow.Col4 = null;
            graceRow.Col5 = null;
            graceRow.Col6 = null;

            var collectionRows = context.Collections.
                Where(row => row.GraceId == graceId && row.Name != "Other")
                .ToList();
            for (int i = 0; i < collectionRows.Count; i++)
            {
                var collectionRow = collectionRows[i];
                if (collectionRow.Name == "Other")
                {
                    continue;
                }
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
            graceRow.GraceId = graceId;
            context.GraceRows.Add(graceRow);
            context.SaveChanges();
            newGraceId = graceRow.ID;
            return newGraceId;
        }
#pragma warning disable CS8600
#pragma warning disable CA1305
        private static string? CheckString(object n)
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
                logger.Error("cannot convert " + n);
            }
            return ret;
        }
#pragma warning restore CS8600
#pragma warning restore CA1305

        public static GraceRow? GetGraceRowFromSku(string sku)
        {
            using GraceDbContext context = new();
            return context.GraceRows.FirstOrDefault(item => item.Sku == sku);
        }

        public static int GetUserIdFromName(string name)
        {
            int id = 0;
            using GraceDbContext context = new();
            User? user = context.Users.FirstOrDefault(item => item.Username == name);
            if (user != null)
            {
                id = user.ID;
            }
            return id;
        }

        public class ReportGroup
        {
            public string CollectionName { get; set; }
            public List<GraceRow> GraceRows { get; set; }
        }

        public static List<string> GetCollections()
        {
            using GraceDbContext dbContext = new();
            var distinctNames = dbContext.Collections
                .Where(c => c.Name != "Other")
                .Select(c => c.Name)
                .Distinct()
                .OrderBy(name => name).ToList();
            return distinctNames;
        }

        public static Dictionary<string, List<Grace>> OrderedCollectionNames()
        {
            using GraceDbContext dbContext = new();
            Dictionary<string, List<Grace>> dict = new();
            IOrderedQueryable<string> distinctNames = dbContext.Collections
                 .Where(c => c.Name != "Other")
                .Select(c => c.Name)
                .Distinct()
                .OrderBy(name => name);

            foreach (string collectionName in distinctNames)
            {
                List<Grace> graces = [.. dbContext.Graces
                        .Join(
                            dbContext.Collections.Where(c => c.Name == collectionName),
                            graces => graces.ID,
                            collection => collection.GraceId,
                            (graces, collection) => new Grace
                            {
                                ID = graces.ID,
                                Sku = graces.Sku,
                                Description = graces.Description,
                                Brand = graces.Brand,
                                Availability = graces.Availability,
                                BarCode = graces.BarCode,
                                Note = graces.Note
                            })];

                dict.Add(collectionName, graces);
            }

            foreach (KeyValuePair<string, List<Grace>> kvp in dict)
            {
                logger.Debug($"Collection Name: {kvp.Key}");
                foreach (Grace graceRow in kvp.Value)
                {
                    logger.Debug($"  GraceRow: {graceRow}");
                }
            }
            return dict;
        }

        public static bool DeleteCollectionRow(int GraceId, string name)
        {
            using var context = new GraceDbContext();
            // Find the row to check if it exists
            CollectionName? rowToDelete = context.Collections
                .SingleOrDefault(c => c.GraceId == GraceId && c.Name == name);

            if (rowToDelete != null)
            {
                // Row exists, so delete it
                context.Collections.Remove(rowToDelete);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool CheckCollectionExists(string name)
        {
            using var context = new GraceDbContext();
            bool rowExists = context.Collections
              .Any(c => c.Name == name);
            return rowExists;
        }

        public static bool AddCollectionRow(int GraceId, string name)
        {
            using var context = new GraceDbContext();
            bool rowExists = context.Collections
                .Any(c => c.GraceId == GraceId && c.Name == name);
            if (rowExists)
            {
                return false;
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
            return true;
        }

        public static int GetCollectionId(int graceId, string name)
        {
            using var context = new GraceDbContext();
            var row = context.Collections
                .SingleOrDefault(c => c.GraceId == graceId && c.Name == name);
            return row.ID;
        }

        public static List<CollectionName> GetCollections(int graceId)
        {
            using var context = new GraceDbContext();
            List<CollectionName> collectionRows = [.. context.Collections
                    .Where(c => c.Name != "Other" && c.GraceId == graceId)
                    .OrderBy(c => c.Name)];
            return collectionRows;
        }

        public static Total GetTotal(int graceId)
        {

            using var context = new GraceDbContext();
            var total = context.Totals
                .Where(t => t.GraceId == graceId)
                .OrderByDescending(t => t.ID)
                .Take(2).ToList();
            var currentTotal = total[0];
            return currentTotal;
        }

    }
#pragma warning restore CS8601
#pragma warning restore CS8619
}


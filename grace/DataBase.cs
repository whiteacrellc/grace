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
using System.ComponentModel.DataAnnotations;
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
                // EnsureCreated returns true if database was created, false if it already existed
                // Both cases are acceptable - we just need the database to exist
                context.Database.EnsureCreated();
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

            // Load all graces and totals in single queries, then join in memory
            var graces = dbContext.Graces.AsNoTracking().ToList();

            // Get latest total for each GraceId by loading all totals once
            var latestTotals = dbContext.Totals
                .AsNoTracking()
                .OrderByDescending(t => t.ID)
                .ToList()
                .GroupBy(t => t.GraceId)
                .ToDictionary(g => g.Key, g => g.First());

            var result = graces
                .Where(g => latestTotals.ContainsKey(g.ID))
                .OrderBy(g => g.Sku)
                .Select(g => new CheckOut
                {
                    Sku = g.Sku,
                    Description = g.Description,
                    Brand = g.Brand,
                    BarCode = g.BarCode,
                    Total = latestTotals[g.ID].CurrentTotal,
                    GraceId = g.ID
                })
                .ToList();

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

            // Load all graces and get latest totals in memory
            var graces = dbContext.Graces.AsNoTracking().ToList();

            var latestTotals = dbContext.Totals
                .AsNoTracking()
                .OrderByDescending(t => t.ID)
                .ToList()
                .GroupBy(t => t.GraceId)
                .ToDictionary(g => g.Key, g => g.First());

            var result = graces
                .Where(g => latestTotals.ContainsKey(g.ID))
                .OrderBy(g => g.Sku)
                .Select(g => new CheckOut
                {
                    Sku = g.Sku,
                    Description = g.Description,
                    Brand = g.Brand,
                    BarCode = g.BarCode,
                    Total = latestTotals[g.ID].CurrentTotal,
                    GraceId = g.ID
                })
                .ToList();

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
                    from grace in dbContext.Graces
                    join pulled in dbContext.PulledDb on grace.ID equals pulled.GraceId
                    join user in dbContext.Users on pulled.UserId equals user.ID
                    join collection in dbContext.Collections on pulled.CollectionId equals collection.ID
                    where pulled.UserId == user_id && !pulled.IsCompleted
                    orderby pulled.LastUpdated descending, pulled.CurrentTotal descending
                    select new CheckInData
                    {
                        UserName = user.Username,
                        Sku = grace.Sku,
                        Brand = grace.Brand,
                        Description = grace.Description,
                        BarCode = grace.BarCode,
                        Collection = collection.Name,
                        LastUpdated = pulled.LastUpdated,
                        UserTotal = pulled.Amount,
                        CheckIn = string.Empty,
                        GraceId = grace.ID
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
                from grace in dbContext.Graces
                join pulled in dbContext.PulledDb on grace.ID equals pulled.GraceId
                join user in dbContext.Users on pulled.UserId equals user.ID
                join collection in dbContext.Collections on pulled.CollectionId equals collection.ID
                where !pulled.IsCompleted
                orderby user.Username ascending, pulled.LastUpdated descending, pulled.CurrentTotal descending
                select new CheckInData
                {
                    UserName = user.Username,
                    Sku = grace.Sku,
                    Brand = grace.Brand,
                    Description = grace.Description,
                    BarCode = grace.BarCode,
                    Collection = collection.Name,
                    LastUpdated = pulled.LastUpdated,
                    UserTotal = pulled.Amount,
                    CheckIn = string.Empty,
                    GraceId = grace.ID
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


        public class ArrangementData
        {
            public string Name { get; set; }
            public int Total { get; set; }
        }

        public static System.Data.DataTable GetArrangementNameGrid(string collectionName)
        {

            System.Data.DataTable table = new();

            // Define columns
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Total", typeof(int));

            using GraceDbContext dbContext = new();

            // Load arrangements for this collection
            var arrangements = dbContext.Arrangement
                .AsNoTracking()
                .Where(a => a.CollectionName == collectionName)
                .ToList();

            // Load all arrangement totals once and get latest for each
            var latestTotals = dbContext.ArrangementTotals
                .AsNoTracking()
                .OrderByDescending(t => t.ID)
                .ToList()
                .GroupBy(t => t.ArrangementId)
                .ToDictionary(g => g.Key, g => g.First());

            var result = arrangements
                .Where(a => latestTotals.ContainsKey(a.ID))
                .OrderBy(a => a.Name)
                .Select(a => new ArrangementData
                {
                    Name = a.Name,
                    Total = latestTotals[a.ID].CurrentTotal
                })
                .ToList();

            foreach (ArrangementData? at in result)
            {
                table.Rows.Add(at.Name, at.Total);
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

            // Load all data in single queries
            var graces = dbContext.Graces.AsNoTracking().ToDictionary(g => g.ID);
            var allTotals = dbContext.Totals.AsNoTracking().ToList();

            // Group totals by GraceId and order by LastUpdated descending
            var totalsByGrace = allTotals
                .GroupBy(t => t.GraceId)
                .ToDictionary(g => g.Key, g => g.OrderByDescending(t => t.LastUpdated).ToList());

            // Build result with previous totals calculated in memory
            var result = new List<ReportData>();
            foreach (var total in allTotals.OrderByDescending(t => t.LastUpdated).ThenByDescending(t => t.CurrentTotal))
            {
                if (!graces.TryGetValue(total.GraceId, out var grace))
                    continue;

                // Find previous total in memory
                int prevTotal = 0;
                if (totalsByGrace.TryGetValue(total.GraceId, out var graceTotals))
                {
                    var prev = graceTotals.FirstOrDefault(t => t.LastUpdated < total.LastUpdated);
                    prevTotal = prev?.CurrentTotal ?? 0;
                }

                result.Add(new ReportData
                {
                    Sku = grace.Sku,
                    Brand = grace.Brand,
                    Description = grace.Description,
                    User = total.User,
                    Total = total.CurrentTotal,
                    PrevTotal = prevTotal,
                    LastUpdated = total.LastUpdated,
                    Note = grace.Note,
                    GraceId = grace.ID
                });
            }

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
            using GraceDbContext context = new();
            return context.Graces.Any();
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

                string currentUser = Globals.GetInstance().CurrentUser ?? "System";

                // Use a single context for batched operations
                using var context = new GraceDbContext();

                // Collect all entities first
                var gracesToAdd = new List<Grace>();
                var rowData = new List<(int index, int total, string[] collections)>();

                for (int row = 2; row <= rowCount; row++)
                {
                    // if the first column is not null we assume we have a valid row
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

                        var grace = new Grace
                        {
                            Sku = sku?.Trim() ?? string.Empty,
                            Description = description?.Trim() ?? string.Empty,
                            Brand = brand?.Trim() ?? string.Empty,
                            Availability = availability?.Trim() ?? string.Empty,
                            BarCode = barcode?.Trim() ?? string.Empty
                        };
                        gracesToAdd.Add(grace);

                        // Collect collection names for this row
                        string[] collections = [
                            (string)worksheet.Cells[row, 5].Value,
                            (string)worksheet.Cells[row, 6].Value,
                            (string)worksheet.Cells[row, 7].Value,
                            (string)worksheet.Cells[row, 8].Value,
                            (string)worksheet.Cells[row, 9].Value,
                            (string)worksheet.Cells[row, 10].Value,
                            "Other"
                        ];

                        rowData.Add((gracesToAdd.Count - 1, total, collections));
                    }
                }

                // Batch insert all Grace entities
                context.Graces.AddRange(gracesToAdd);
                context.SaveChanges();

                // Now add totals and collections with the generated IDs
                var totalsToAdd = new List<Total>();
                var collectionsToAdd = new List<CollectionName>();

                foreach (var (index, total, collections) in rowData)
                {
                    int graceId = gracesToAdd[index].ID;

                    // Add total
                    totalsToAdd.Add(new Total
                    {
                        LastUpdated = DateTime.Now,
                        CurrentTotal = total,
                        GraceId = graceId,
                        User = currentUser
                    });

                    // Add collections
                    foreach (var col in collections)
                    {
                        if (!string.IsNullOrEmpty(col))
                        {
                            collectionsToAdd.Add(new CollectionName
                            {
                                Name = col.Trim(),
                                GraceId = graceId
                            });
                        }
                    }
                }

                // Batch insert all totals and collections
                context.Totals.AddRange(totalsToAdd);
                context.Collections.AddRange(collectionsToAdd);
                context.SaveChanges();
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

        public static Arrangement? GetArrangement(string collectionName, string name)
        {

            using GraceDbContext context = new();
            return context.Arrangement.FirstOrDefault(e => e.Name == name
                    && e.CollectionName == collectionName);
        }

        public static int AddTotal(int total, int graceId)
        {
            int id = 0;
            String currentUser = Globals.GetInstance().CurrentUser;
            using (GraceDbContext context = new())
            {
                // Check if the most recent total for this graceId has the same value
                var mostRecentTotal = context.Totals
                    .Where(t => t.GraceId == graceId)
                    .OrderByDescending(t => t.ID)
                    .FirstOrDefault();

                // If the current total in the database equals the new total, don't insert
                if (mostRecentTotal != null && mostRecentTotal.CurrentTotal == total)
                {
                    return mostRecentTotal.ID;
                }

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

        public static Grace? GetGraceFromSku(string sku)
        {
            using GraceDbContext context = new();
            return context.Graces.FirstOrDefault(item => item.Sku == sku);
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
            public List<Grace> Graces { get; set; }
        }

        public static List<string> GetCollections()
        {
            using GraceDbContext context = new();
            return [.. context.Collections
                    .Where(e => e.Name != "Other")
                    .Select(e => e.Name)
                    .Distinct()
                    .OrderBy(name => name)];
        }

        public static List<string> GetArrangements()
        {
            using GraceDbContext context = new();
            return [.. context.Arrangement
                    .Select(e => e.Name)
                    .Distinct()
                    .OrderBy(name => name)];
        }

        public static List<string> GetBrandNames()
        {
            using GraceDbContext context = new();
            return [.. context.Graces
                    .Select(c => c.Brand)
                    .Distinct()
                    .OrderBy(brand => brand)];
        }


        public static Dictionary<string, List<Grace>> OrderedCollectionNames()
        {
            using GraceDbContext dbContext = new();

            // Load all data in single queries
            var allGraces = dbContext.Graces.AsNoTracking().ToDictionary(g => g.ID);
            var allCollections = dbContext.Collections
                .AsNoTracking()
                .Where(c => c.Name != "Other")
                .ToList();

            // Group in memory instead of querying per collection
            Dictionary<string, List<Grace>> dict = allCollections
                .GroupBy(c => c.Name)
                .OrderBy(g => g.Key)
                .ToDictionary(
                    g => g.Key,
                    g => g.Where(c => allGraces.ContainsKey(c.GraceId))
                          .Select(c => {
                              var grace = allGraces[c.GraceId];
                              return new Grace
                              {
                                  ID = grace.ID,
                                  Sku = grace.Sku,
                                  Description = grace.Description,
                                  Brand = grace.Brand,
                                  Availability = grace.Availability,
                                  BarCode = grace.BarCode,
                                  Note = grace.Note
                              };
                          })
                          .ToList()
                );

            foreach (KeyValuePair<string, List<Grace>> kvp in dict)
            {
                logger.Debug($"Collection Name: {kvp.Key}");
                foreach (Grace grace in kvp.Value)
                {
                    logger.Debug($"  Grace: {grace}");
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
              .Any(c => c.Name.ToLower() == name.ToLower());
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

        public static void UpdateArrangementWithNewCollection(string collectionName)
        {
            string currentUser = Globals.GetInstance().CurrentUser ?? "System";
            using GraceDbContext context = new();
            List<string> arrangementNames = [.. context.Arrangement
                    .Select(e => e.Name)
                    .Distinct()
                    .OrderBy(name => name)];

            // First, add all arrangements
            var arrangementsToAdd = new List<Arrangement>();
            foreach (string arrangementName in arrangementNames)
            {
                arrangementsToAdd.Add(new Arrangement
                {
                    Name = arrangementName,
                    CollectionName = collectionName
                });
            }

            context.Arrangement.AddRange(arrangementsToAdd);
            context.SaveChanges();

            // Now add all arrangement totals with the generated IDs
            var totalsToAdd = arrangementsToAdd.Select(a => new ArrangementTotal
            {
                ArrangementId = a.ID,
                CurrentTotal = 0,
                User = currentUser,
            }).ToList();

            context.ArrangementTotals.AddRange(totalsToAdd);
            context.SaveChanges();
        }

        public static void RenameArrangement(string oldName, string newName)
        {
            using var context = new GraceDbContext();
            var arrangementsToRename = context.Arrangement
                .Where(a => a.Name == oldName)
                .ToList();

            foreach (var arrangement in arrangementsToRename)
            {
                arrangement.Name = newName;
            }

            context.SaveChanges();
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

        /// <summary>
        /// Gets all latest totals indexed by GraceId for bulk operations.
        /// Much more efficient than calling GetTotal() in a loop.
        /// </summary>
        public static Dictionary<int, Total> GetAllLatestTotals()
        {
            using var context = new GraceDbContext();
            return context.Totals
                .AsNoTracking()
                .OrderByDescending(t => t.ID)
                .ToList()
                .GroupBy(t => t.GraceId)
                .ToDictionary(g => g.Key, g => g.First());
        }

        /// <summary>
        /// Gets all collections indexed by GraceId for bulk operations.
        /// Much more efficient than calling GetCollections() in a loop.
        /// </summary>
        public static Dictionary<int, List<CollectionName>> GetAllCollections()
        {
            using var context = new GraceDbContext();
            return context.Collections
                .AsNoTracking()
                .Where(c => c.Name != "Other")
                .OrderBy(c => c.Name)
                .ToList()
                .GroupBy(c => c.GraceId)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        #region Async Methods for UI Responsiveness

        /// <summary>
        /// Async version of GetPulledGrid for non-blocking UI updates.
        /// </summary>
        public static async Task<System.Data.DataTable> GetPulledGridAsync()
        {
            return await Task.Run(() => GetPulledGrid());
        }

        /// <summary>
        /// Async version of GetCheckedOutGrid for non-blocking UI updates.
        /// </summary>
        public static async Task<System.Data.DataTable> GetCheckedOutGridAsync(int user_id)
        {
            return await Task.Run(() => GetCheckedOutGrid(user_id));
        }

        /// <summary>
        /// Async version of GetCheckedOutGridAll for non-blocking UI updates.
        /// </summary>
        public static async Task<System.Data.DataTable> GetCheckedOutGridAllAsync()
        {
            return await Task.Run(() => GetCheckedOutGridAll());
        }

        /// <summary>
        /// Async version of HaveData for non-blocking startup.
        /// </summary>
        public static async Task<bool> HaveDataAsync()
        {
            return await Task.Run(() => HaveData());
        }

        #endregion

    }
#pragma warning restore CS8601
#pragma warning restore CS8619
}


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
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Data;


namespace grace
{
    internal class DataGridLoader
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Async version of GetData for non-blocking UI updates.
        /// </summary>
        public static async Task<DataTable> GetDataAsync()
        {
            return await Task.Run(() => GetData());
        }

        public static DataTable GetData()
        {
            System.Data.DataTable table = new();
            table.Columns.Add("Sku", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Brand", typeof(string));
            table.Columns.Add("Availability", typeof(string));
            table.Columns.Add("BarCode", typeof(string));
            table.Columns.Add("Col1", typeof(string));
            table.Columns.Add("Col2", typeof(string));
            table.Columns.Add("Col3", typeof(string));
            table.Columns.Add("Col4", typeof(string));
            table.Columns.Add("Col5", typeof(string));
            table.Columns.Add("Col6", typeof(string));
            table.Columns.Add("Total", typeof(int));
            table.Columns.Add("PrevTotal", typeof(int));
            table.Columns.Add("LastUpdated", typeof(DateTime));
            table.Columns.Add("Note", typeof(string));
            table.Columns.Add("GraceId", typeof(int));

            using (GraceDbContext context = new())
            {
                // Load all Grace items
                List<Grace> graces = [.. context.Graces.AsNoTracking()];

                // Batch load all totals at once and create lookup dictionary
                // Group totals by GraceId and get top 2 for each item
                var allTotals = context.Totals
                    .AsNoTracking()
                    .OrderByDescending(t => t.ID)
                    .ToList()
                    .GroupBy(t => t.GraceId)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Take(2).ToList()
                    );

                // Batch load all collections at once and create lookup dictionary
                var allCollections = context.Collections
                    .AsNoTracking()
                    .ToList()
                    .GroupBy(c => c.GraceId)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Where(c => c.Name != "Other").ToList()
                    );

                // Build DataTable rows directly
                foreach (Grace item in graces.OrderBy(g => g.Sku))
                {
                    int total = 0;
                    int prevTotal = 0;
                    DateTime lastUpdated = DateTime.Now;

                    // Get totals from the pre-loaded dictionary
                    if (allTotals.TryGetValue(item.ID, out var totals) && totals.Count > 0)
                    {
                        Total total1 = totals[0];
                        Total? total2 = totals.Count > 1 ? totals[1] : null;

                        total = total1.CurrentTotal;
                        lastUpdated = total1.LastUpdated;
                        prevTotal = total2?.CurrentTotal ?? 0;
                    }

                    // Get collections from the pre-loaded dictionary
                    string? col1 = null, col2 = null, col3 = null, col4 = null, col5 = null, col6 = null;
                    if (allCollections.TryGetValue(item.ID, out var collectionList))
                    {
                        int i = 0;
                        foreach (CollectionName col in collectionList)
                        {
                            switch (i)
                            {
                                case 0: col1 = col.Name; break;
                                case 1: col2 = col.Name; break;
                                case 2: col3 = col.Name; break;
                                case 3: col4 = col.Name; break;
                                case 4: col5 = col.Name; break;
                                case 5: col6 = col.Name; break;
                                default:
                                    logger.Info("More than 6 collections for item");
                                    break;
                            }
                            i++;
                        }
                    }

                    table.Rows.Add(
                        item.Sku,
                        item.Description,
                        item.Brand,
                        item.Availability,
                        item.BarCode,
                        col1, col2, col3, col4, col5, col6,
                        total,
                        prevTotal,
                        lastUpdated,
                        item.Note,
                        item.ID
                    );
                }
            }

            return table;
        }


        public static DataView GetFilteredData(DataTable table, string searchTerm)
        {
            DataView view = new(table)
            {
                RowFilter = "Sku LIKE '%" + searchTerm +
                    "%' OR Description LIKE '%"
                    + searchTerm + "%'"
            };
            return view;
        }


        public static DataView GetFilteredBarCode(DataTable table, string searchTerm)
        {
            DataView view = new(table)
            {
                RowFilter = "BarCode LIKE '%" + searchTerm + "%'"
            };
            return view;
        }

        public static void RefreshData()
        {
            // This method is now a no-op since we build the DataTable on demand
            // Kept for API compatibility
        }

    }
}

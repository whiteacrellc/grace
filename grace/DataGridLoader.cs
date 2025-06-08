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
using NLog;
using System.Data;


namespace grace
{
    internal class DataGridLoader
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static DataTable GetData()
        {
            System.Data.DataTable table = new();
            // table.Columns.Add("ID", typeof(int));
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
            // table.Columns.Add("GraceId", typeof(int));

            List<GraceRow> list = [];
            using (GraceDbContext context = new())
            {
                list = [.. context.GraceRows];
                list = [.. list.OrderBy(row => row.Sku)];
            }

            // Populate rows
            foreach (GraceRow graceRow in list)
            {
                table.Rows.Add(graceRow.Sku, graceRow.Description,
                    graceRow.Brand, graceRow.Availability, graceRow.BarCode,
                    graceRow.Col1, graceRow.Col2, graceRow.Col3, graceRow.Col4,
                    graceRow.Col5, graceRow.Col6, graceRow.Total, graceRow.PrevTotal,
                    graceRow.LastUpdated, graceRow.Note);
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

        internal static void LoadBindingTable(bool refresh = false)
        {
            using GraceDbContext context = new();
            if (refresh)
            {
                List<GraceRow> allGraceRows = context.GraceRows.ToList();
                if (allGraceRows != null)
                {
                    // Remove all rows from the DbSet
                    context.GraceRows.RemoveRange(allGraceRows);

                    // Save changes to the database
                    context.SaveChanges();
                }
            }

            if (context.GraceRows.ToList().Count > 0)
            {
                return;
            }

            List<GraceRow> rows = [];
            List<Grace> result = [.. context.Graces];
            foreach (Grace item in result)
            {
                GraceRow row = new()
                {
                    GraceId = item.ID,
                    Sku = item.Sku,
                    BarCode = item.BarCode,
                    Brand = item.Brand,
                    Description = item.Description,
                    Note = item.Note,
                    Availability = item.Availability
                };

                // Lets get the two totals
                IQueryable<Total> currentTotal = context.Totals
                    .Where(t => t.GraceId == item.ID)
                    .OrderByDescending(t => t.ID)
                    .Take(2);

                Total total1 = currentTotal.FirstOrDefault(); // Get the first result or null if none.
                Total total2 = currentTotal.Skip(1).FirstOrDefault(); // Get the second result or null if none.

                row.Total = total1.CurrentTotal;
                row.LastUpdated = total1.LastUpdated;
                row.PrevTotal = (total2 == null) ? 0 : total2.CurrentTotal;

                var collectionList = context.Collections.Where(t => t.GraceId == item.ID);

                int i = 0;
                foreach (CollectionName? col in collectionList)
                {
                    if (col.Name == "Other") { continue; }
                    switch (i)
                    {
                        case 0:
                            row.Col1 = col.Name;
                            break;
                        case 1:
                            row.Col2 = col.Name;
                            break;
                        case 2:
                            row.Col3 = col.Name;
                            break;
                        case 3:
                            row.Col4 = col.Name;
                            break;
                        case 4:
                            row.Col5 = col.Name;
                            break;
                        case 5:
                            row.Col6 = col.Name;
                            break;
                        default:
                            logger.Info("Should never see this");
                            break;
                    }
                    i++;
                }
                context.GraceRows.Add(row);
            }
            context.SaveChanges();
        }

    }
}

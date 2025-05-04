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

        public static DataTable GetInventoryData()
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

            List<GraceRow> list = GetGraceRows();

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

        private static List<GraceRow> GetGraceRows()
        {
            List<Grace> list = DataBase.GetGraces();
            List<GraceRow> graceRows = [];
            using GraceDbContext context = new();
            foreach (Grace grace in list)
            {
                GraceRow row = new()
                {
                    Sku = grace.Sku,
                    Description = grace.Description,
                    Brand = grace.Brand,
                    Availability = grace.Availability,
                    BarCode = grace.BarCode,
                    Note = grace.Note
                };

                IQueryable<Total> currentTotal = context.Totals
                .Where(t => t.GraceId == grace.ID)
                .OrderByDescending(t => t.ID)
                .Take(2);

                Total total1 = currentTotal.FirstOrDefault(); // Get the first result or null if none.
                Total total2 = currentTotal.Skip(1).FirstOrDefault(); // Get the second result or null if none.

                row.LastUpdated = total1.LastUpdated;
                row.Total = total1.CurrentTotal;
                row.PrevTotal = (total2 == null) ? 0 : total2.CurrentTotal;

                row.Col1 = null;
                row.Col2 = null;
                row.Col3 = null;
                row.Col4 = null;
                row.Col5 = null;
                row.Col6 = null;

                List<CollectionName> collectionRows =
                    [.. context.Collections.Where(row => row.GraceId == grace.ID && row.Name != "Other")];
                for (int i = 0; i < collectionRows.Count; i++)
                {
                    CollectionName collectionRow = collectionRows[i];
                    if (collectionRow.Name == "Other")
                    {
                        continue;
                    }
                    switch (i)
                    {
                        case 0:
                            row.Col1 = collectionRow.Name;
                            break;
                        case 1:
                            row.Col2 = collectionRow.Name;
                            break;
                        case 2:
                            row.Col3 = collectionRow.Name;
                            break;
                        case 3:
                            row.Col4 = collectionRow.Name;
                            break;
                        case 4:
                            row.Col5 = collectionRow.Name;
                            break;
                        case 5:
                            row.Col6 = collectionRow.Name;
                            break;
                        default:
                            logger.Error($"Too many collections for SKU {grace.Sku}");
                            break;
                    }
                }
                graceRows.Add(row);

            }
            return graceRows;
        }

        public static DataTable LoadGraceDataTable()
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

            List<GraceRow> graceRows = GetGraceRows();

            // Populate rows
            foreach (GraceRow graceRow in graceRows)
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


    }
}

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
using System.ComponentModel.Design;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Globalization;
using static grace.DataBase;
using static OfficeOpenXml.ExcelErrorValue;

namespace grace
{
    internal class DataGridLoader
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static List<GraceRow> getData()
        {
            List<GraceRow> list = new List<GraceRow>();
            using (var context = new GraceDbContext())
            {
                list = context.GraceRows.ToList();
                list = list.OrderBy(row => row.Sku).ToList();
            }
            return list;
        }


        public static DataSet GetDataSet(List<GraceRow> graceRowsList)
        {

            // Convert the List<GraceRow> to a DataTable
            DataTable graceRowsTable = ConvertToDataTable(graceRowsList);

            // Create a new DataSet and add the DataTable to it
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(graceRowsTable);
            return dataSet;
        }

        public static DataTable ConvertToDataTable(List<GraceRow> graceRowsList)
        {
            DataTable table = new DataTable();

            // Define columns
            table.Columns.Add("ID", typeof(int));
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
            table.Columns.Add("LastUpdated", typeof(DateTime));
            table.Columns.Add("GraceId", typeof(int));

            // Populate rows
            foreach (var graceRow in graceRowsList)
            {
                table.Rows.Add(graceRow.ID, graceRow.Sku, graceRow.Description,
                    graceRow.Brand, graceRow.Availability, graceRow.BarCode,
                    graceRow.Col1, graceRow.Col2, graceRow.Col3, graceRow.Col4,
                    graceRow.Col5, graceRow.Col6, graceRow.Total,
                    graceRow.LastUpdated, graceRow.GraceId);
            }

            return table;
        }

        public static DataView getFilteredData(DataTable table, string searchTerm)
        {
            DataView view = new DataView(table)
            {
                RowFilter = "Sku LIKE '%" + searchTerm +
                    "%' OR Description LIKE '%"
                    + searchTerm + "%'"
            };
            return view;
        }

    public static List<GraceRow> getFilteredData(string searchTerm)
        {
            List<GraceRow> result = new List<GraceRow>();
            var list = getData();
            if (searchTerm == null || searchTerm == string.Empty)
            {
                return list;
            }

            // Look through the list for either matches in the sku or
            // description
            foreach (var graceRow in list)
            {
                if (graceRow.Sku.Contains(searchTerm,
                    StringComparison.CurrentCultureIgnoreCase) ||
                    graceRow.Description.Contains(searchTerm,
                    StringComparison.CurrentCultureIgnoreCase) ||
                    graceRow.BarCode.Contains(searchTerm))
                {
                    result.Add(graceRow);
                }
            }
            return result;
        }

        public static List<GraceRow> getFilteredBarCode(string searchTerm)
        {
            List<GraceRow> result = new List<GraceRow>();
            var list = getData();
            if (searchTerm == null || searchTerm == string.Empty)
            {
                return list;
            }

            // Look through the list for either matches in the sku or
            // description
            foreach (var graceRow in list)
            {
                if (graceRow.BarCode.Contains(searchTerm,
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    result.Add(graceRow);
                }
            }
            return result;
        }

        public static DataView getFilteredBarCode(DataTable table, string searchTerm)
        {
            DataView view = new DataView(table)
            {
                RowFilter = "Barcode LIKE '%" + searchTerm + "%'"
            };
            return view;
        }

        internal static void LoadBindingTable(bool refresh = false)
        {
            using (var context = new GraceDbContext())
            {
                if (refresh)
                {
                    var allGraceRows = context.GraceRows.ToList();
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

                List<GraceRow> rows = new List<GraceRow>();
                var result = context.Graces.ToList();
                foreach (var item in result)
                {
                    GraceRow row = new GraceRow();
                    row.GraceId = item.ID;
                    row.Sku = item.Sku;
                    row.BarCode = item.BarCode;
                    row.Brand = item.Brand;
                    row.Description = item.Description;

                    // Lets get the two totals
                    var currentTotal = context.Totals
                        .Where(t => t.GraceId == item.ID)
                        .OrderByDescending(t => t.ID)
                        .Take(1)
                        .First();

                    row.Total = currentTotal.CurrentTotal;
                    row.LastUpdated = currentTotal.LastUpdated;

                    var collectionList = context.Collections.Where(t => t.GraceId == item.ID);

                    int i = 0;
                    foreach (var col in collectionList)
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
}

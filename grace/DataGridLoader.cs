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
using System.ComponentModel.Design;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using static OfficeOpenXml.ExcelErrorValue;

namespace grace
{
    internal class DataGridLoader : IDisposable
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private DataTable dataTable = new DataTable();
        private Dictionary<long, GraceRow> graceRows = new Dictionary<long, GraceRow>();
        private bool disposed;

        public GraceDbContext graceDb { get; private set; }

        public DataGridLoader()
        {
            graceDb = new GraceDbContext();
      
        }

        public List<GraceRow> getData()
        {
            return graceDb.GraceRows.ToList();
        }

        internal void LoadBindingTable()
        {

            if (graceDb.GraceRows.ToList().Count > 0) {
                return;
            }

            List<GraceRow> rows = new List<GraceRow>();
            var result = graceDb.Graces.ToList();
            foreach (var item in result)
            {
                GraceRow row = new GraceRow();
                row.GraceId = item.ID;
                row.Sku = item.Sku;
                row.BarCode = item.Barcode;
                row.Brand = item.Brand;
                row.Description = item.Description;

                // Lets get the two totals
                var totalList = graceDb.Totals
                    .Where(t => t.GraceId == item.ID)
                    .OrderByDescending(t => t.date_field)
                    .Take(1)
                    .ToList();

                if (totalList != null)
                {
                    if (totalList.Count == 1)
                    {
                        row.Total = totalList[0].total;
                    }
                    else
                    {
                        logger.Info("No totals found");
                    }
                }

                var collectionList = graceDb.Collections.Where(t => t.GraceId == item.ID);

                int i = 0;
                foreach (var col in collectionList)
                {
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
                graceDb.GraceRows.Add(row);
            }
            graceDb.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected method for actual resource cleanup
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    graceDb.Dispose();
                }

                disposed = true;
            }
        }

        // Destructor (Finalizer) to ensure cleanup in case Dispose is not called
        ~DataGridLoader()
        {
            Dispose(false);
        }
    }


}

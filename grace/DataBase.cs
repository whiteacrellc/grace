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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: InternalsVisibleTo("gracetest")]

namespace grace
{

    public class DataBase
    {

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public string DbFileName { get; set; }
        public string ConnectionString { get; set; }

        private string dbName = "grace.db";

        public GraceDbContext graceDb { get; private set; }

        public DataBase()

        {
            DbFileName = string.Empty;
            ConnectionString = CreateDatabaseFile();
            graceDb = new GraceDbContext();
            graceDb.Database.EnsureCreated();
        }

        public DataBase(string fileName)
        {
            dbName = fileName;
            DbFileName = string.Empty;
            ConnectionString = CreateDatabaseFile();
            graceDb = new GraceDbContext();
            graceDb.Database.EnsureCreated();

        }

        ~DataBase()
        {
            graceDb.Dispose();
        }

        public string CreateDatabaseFile()
        {
            // Get the program's directory
            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Specify the database file path in the program's directory
            DbFileName = Path.Combine(programDirectory, dbName);

            var baseConnectionString = "Data Source=" + DbFileName + ";Cache=Shared";
            var connectionString = new SqliteConnectionStringBuilder(baseConnectionString)
            {
                Mode = SqliteOpenMode.ReadWriteCreate,
            }.ToString();



            logger.Info(connectionString);
            Globals.GetInstance().ConnectionString = connectionString;

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
            try
            {
                graceDb.Database.EnsureDeleted();
                graceDb.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
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


            var newCollection = new Collection
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

        private string checkString(object n)
        {
            string ret = "";
            if (n is string)
            {
                ret = Convert.ToString((string)n);
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
            return ret.Trim();
        }
        public void CleanUp()
        {
            graceDb.Database.EnsureDeleted();
        }
    }



}


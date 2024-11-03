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
using NLog;
using OfficeOpenXml;
using System.Globalization;
using System.Text.RegularExpressions;
using LicenseContext = OfficeOpenXml.LicenseContext;
using System.IO;

namespace grace
{
    public class Row
    {
        public Row()
        {
            Collection = null;
            Sku = null;
            Brand = null;
            Description = null;
            Total = 0;
            BarCode = null;

        }

        public string? Collection { get; set; }
        public string? Sku { get; set; }
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public string? Availabilty { get; set; }
        public int PreviousTotal { get; set; }
        public int Total { get; set; }
        public string? BarCode { get; set; }
    }

    public class ExcelReader
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private Dictionary<string, List<string>> items = new Dictionary<string, List<string>>();
        private Dictionary<string, List<Row>> collections = new Dictionary<string, List<Row>>();

        public Dictionary<string, List<Row>> Collections { get; }
        public Dictionary<string, List<string>> Items { get; }
        public string PreviousColumnHeader { get; set; }
        public string CurrentColumnHeader { get; set; }

        private Vivian vivian;


        public ExcelReader(Vivian vivian)
        {
            this.vivian = vivian;
            Collections = collections;
            Items = items;
            PreviousColumnHeader = "Previous Count";
            CurrentColumnHeader = "Total Count";
        }
        private void addCollection(string key, Row r)
        {
            if (key == null)
            {
                return;
            }
            var trimmedKey = key.Trim();
            r.Collection = trimmedKey;
            if (collections.TryGetValue(trimmedKey, out List<Row>? value))
            {
                List<Row> rows = value;
                rows.Add(r);
                collections[trimmedKey] = rows;
            }
            else
            {
                List<Row> rowList = new List<Row>();
                rowList.Add(r);
                collections[trimmedKey] = rowList;
            }
        }
        private void addItem(string key, string col)
        {
            if (key == null || col == null)
            {
                return;
            }
            var trimmedkey = key.Trim();
            var tcol = col.Trim();
            if (items.TryGetValue(trimmedkey, out List<string>? value))
            {
                List<string> skus = value;
                skus.Add(tcol);
            }
            else
            {
                List<string> skuList = new List<string>();
                skuList.Add(tcol);
                items[trimmedkey] = skuList;
            }

        }

        private static int checkInt(object n)
        {
            int ret = 0;
            try
            {
                ret = Convert.ToInt32((double)n);
            }
            catch
            {
                try
                {
                    ret = int.Parse((string)n);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            return ret;
        }
        private static string checkString(object n)
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

        private static string parseColumnHeader(string header, int daysBack, out DateTime dateTime)
        {
            dateTime = DateTime.Now.AddDays(daysBack);

            // Format the date as "MMM dd, yyyy"
            string format = "MMM dd, yyyy";
            string formattedDate = dateTime.ToString(format);

            string pattern = @"\b(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sept|Oct|Nov|Dec)\s\d{1,2},\s\d{4}\b";

            // Create a regular expression object
            Regex regex = new Regex(pattern);

            // Match the regular expression pattern in the input string
            MatchCollection matches = regex.Matches(header);

            // Extract and print the matched dates
            foreach (Match match in matches)
            {
                formattedDate = match.Value;
                if (DateTime.TryParseExact(formattedDate, format, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out dateTime))
                {
                    logger.Info("Parsed date: " + formattedDate);
                }
                else
                {
                    logger.Info("Failed to parse the date string.");
                }
            }
            return $"Total {formattedDate}";
        }

        public void ReadExcelFile(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming the first worksheet is the one to read

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                DateTime dateTime = DateTime.Now;
                PreviousColumnHeader = parseColumnHeader((string)worksheet.Cells["L1"].Value, -14, out dateTime);
                Globals.GetInstance().previousHeaderDate = dateTime;
                CurrentColumnHeader = parseColumnHeader((string)worksheet.Cells["M1"].Value, 0, out dateTime);
                Globals.GetInstance().currentHeaderDate = dateTime;

                for (int row = 2; row <= rowCount; row++)
                {
                    // if the first column is not null we assume we have a
                    // valid row
                    var firstCol = worksheet.Cells[row, 1].Value;
                    if (firstCol != null)
                    {
                        Row r = new Row();


                        r.Brand = (string)worksheet.Cells[row, 1].Value;
                        r.BarCode = checkString(worksheet.Cells[row, 2].Value);
                        r.Sku = checkString(worksheet.Cells[row, 3].Value);
                        r.Description = (string)worksheet.Cells[row, 4].Value;
                        var availabilty = (worksheet.Cells[row, 11].Value);
                        if (availabilty != null)
                        {
                            r.Availabilty = (string)availabilty;
                        }
                        r.PreviousTotal = Convert.ToInt32(worksheet.Cells[row, 12].Value);
                        r.Total = Convert.ToInt32(worksheet.Cells[row, 13].Value);

                        var col1 = (string)worksheet.Cells[row, 5].Value;
                        addCollection(col1, r);
                        addItem(r.Sku, col1);
                        var col2 = (string)worksheet.Cells[row, 6].Value;
                        addCollection(col2, r);
                        addItem(r.Sku, col2);
                        var col3 = (string)worksheet.Cells[row, 7].Value;
                        addCollection(col3, r);
                        addItem(r.Sku, col3);
                        var col4 = (string)worksheet.Cells[row, 8].Value;
                        addCollection(col4, r);
                        addItem(r.Sku, col4);
                        var col5 = (string)worksheet.Cells[row, 9].Value;
                        addCollection(col5, r);
                        addItem(r.Sku, col5);
                        var col6 = (string)worksheet.Cells[row, 10].Value;
                        addCollection(col6, r);
                        addItem(r.Sku, col6);
                    }
                    else
                    {
                        logger.Warn("Empty row " + row);
                    }

                }
            }
        }
    }
}

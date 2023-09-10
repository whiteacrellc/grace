using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }

        public string? Collection { get; set; }
        public string? Sku { get; set; }
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public int PreviousTotal { get; set; }
        public int Total { get; set; }
    }

    public class ExcelReader
    {
        private Dictionary<string, List<string>> items = new Dictionary<string, List<string>>();
        private Dictionary<string, List<Row>> collections = new Dictionary<string, List<Row>>();

        public Dictionary<string, List<Row>> Collections { get; }
        public Dictionary<string, List<string>> Items { get; }
        private Vivian vivian;

        public ExcelReader(Vivian vivian)
        {
            this.vivian = vivian;
            Collections = collections;
            Items = items;
        }
        private void addCollection(string key, Row r)
        {
            if (key == null)
            {
                return;
            }
            var trimmedKey = key.Trim();
            r.Collection = trimmedKey;
            if (collections.ContainsKey(trimmedKey))
            {
                List<Row> rows = collections[trimmedKey];
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
            if (items.ContainsKey(trimmedkey))
            {
                List<string> skus = items[trimmedkey];
                skus.Add(tcol);
            }
            else
            {
                List<string> skuList = new List<string>();
                skuList.Add(tcol);
                items[trimmedkey] = skuList;
            }

        }

        private int checkInt(object n)
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
        private string checkString(object n)
        {
            string ret = "";
            try
            {
                ret = Convert.ToString((string)n);
                return ret.Trim();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ret = ((double)n).ToString();
                return ret.Trim();
            }
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

                for (int row = 2; row <= rowCount; row++)
                {
                    var entireRow = worksheet.Cells.EntireRow;

                    if (entireRow != null)
                    {

                        vivian.DisplayLogMessage(entireRow.ToString());
                        Row r = new Row();
                        r.Brand = (string)worksheet.Cells[row, 1].Value;
                        r.Sku = checkString(worksheet.Cells[row, 2].Value);
                        var sku = r.Sku;

                        r.Description = (string)worksheet.Cells[row, 3].Value;
                        r.PreviousTotal = Convert.ToInt32(worksheet.Cells[row, 10].Value);
                        r.Total = Convert.ToInt32(worksheet.Cells[row, 11].Value);

                        var col1 = (string)worksheet.Cells[row, 4].Value;
                        addCollection(col1, r);
                        addItem(r.Sku, col1);
                        var col2 = (string)worksheet.Cells[row, 5].Value;
                        addCollection(col2, r);
                        addItem(r.Sku, col2);
                        var col3 = (string)worksheet.Cells[row, 6].Value;
                        addCollection(col3, r);
                        addItem(r.Sku, col3);
                        var col4 = (string)worksheet.Cells[row, 7].Value;
                        addCollection(col4, r);
                        addItem(r.Sku, col4);
                        var col5 = (string)worksheet.Cells[row, 8].Value;
                        addCollection(col5, r);
                        addItem(r.Sku, col5);
                        var col6 = (string)worksheet.Cells[row, 9].Value;
                        addCollection(col6, r);
                        addItem(r.Sku, col6);
                    }

                }
            }
        }
    }
}

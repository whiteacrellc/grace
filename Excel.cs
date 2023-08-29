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
        public string Collection { get; set; }
        public string Sku { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Total { get; set; }
    }

    public class ExcelReader
    {
        private Dictionary<string, List<string>> items = new Dictionary<string, List<string>>();
        private Dictionary<string, List<Row>> collections = new Dictionary<string, List<Row>>();

        public Dictionary<string, List<Row>> Collections { get; }
        public Dictionary<string, List<string>> Items { get; }

        public ExcelReader()
        {
            Collections = collections;
            Items = items;
        }
        private void addCollection(string key, Row r)
        {
            if (key == null)
            {
                return;
            }
            if (collections.ContainsKey(key))
            {
                List<Row> rows = collections[key];
                rows.Add(r);
            }
            else
            {
                List<Row> rowList = new List<Row>();
                rowList.Add(r);
                collections[key] = rowList;
            }
        }
        private void addItem(string key, string col)
        {
            if (key == null)
            {
                return;
            }
            if (items.ContainsKey(key))
            {
                List<string> skus = items[key];
                skus.Add(col);
            }
            else
            {
                List<string> skuList = new List<string>();
                skuList.Add(col);
                items[key] = skuList;
            }

        }

        private string checkString(object n)
        {
            try
            {
                return (string)n;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return ((double)n).ToString();
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

                    Console.WriteLine(entireRow);
                    Row r = new Row();
                    r.Brand = (string)worksheet.Cells[row, 1].Value;
                    r.Sku = checkString(worksheet.Cells[row, 2].Value);
                    r.Description = (string)worksheet.Cells[row, 3].Value;
                    var total = worksheet.Cells[row, 11].Value;
                    try
                    {
                        r.Total = Convert.ToInt32((double)total);
                    }
                    catch
                    {
                        try
                        {
                            r.Total = int.Parse((string)total);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            r.Total = 0;
                        }

                    }



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

                    Console.WriteLine();
                }
            }
        }
    }
}

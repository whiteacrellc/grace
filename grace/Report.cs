using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grace
{
    class Report
    {
        private Dictionary<string, List<string>> items;
        Dictionary<string, List<Row>> collections;
        private int currentRow = 0;

        public Report(Dictionary<string, List<Row>> collections, Dictionary<string, List<string>> items)
        {
            this.collections = collections;
            this.items = items;
        }


        private void writeCollectoion(KeyValuePair<string, List<Row>> kvp, ExcelWorksheet worksheet)
        {
            int startRow = currentRow;
            foreach (var row in kvp.Value)
            {
                if (row.Sku != null && items.TryGetValue(row.Sku, out var list))
                {
                    worksheet.Cells[currentRow, 1].Value = row.Collection;
                    worksheet.Cells[currentRow, 2].Value = row.Sku;
                    worksheet.Cells[currentRow, 3].Value = row.Description;
                    int i = 0;
                    foreach (var itemcol in list)
                    {
                        worksheet.Cells[currentRow, 4 + 1].Value = list[i];
                        i++;
                    }
                    worksheet.Cells[currentRow, 10].Value = row.PreviousTotal;
                    worksheet.Cells[currentRow, 11].Value = row.Total;

                }

            }
            var borderCellRange = "A" + startRow + ":K" + currentRow;
            worksheet.Cells[borderCellRange].Style.Border.BorderAround(ExcelBorderStyle.Medium);

        }
        public void WriteReport()
        {
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Sort the dictionary by keys.
                var sortedCollections = this.collections.OrderBy(pair => pair.Key);
                var worksheet = package.Workbook.Worksheets.Add("Report");

                // Set the column names
                worksheet.Cells["A1"].Value = "Brand";
                worksheet.Cells["B1"].Value = "Item Number";
                worksheet.Cells["C1"].Value = "Description";
                worksheet.Cells["D1:I1"].Merge = true;
                worksheet.Cells["D1:I1"].Value = "Collections";
                worksheet.Cells["J1"].Value = "Previous Count";
                worksheet.Cells["K1"].Value = "Total Count";

                // Loop through the sorted dictionary and write out the values grouped by key.
                foreach (var kvp in sortedCollections)
                {
                    currentRow += 2;
                    writeCollectoion(kvp, worksheet);

                }

                // Save the Excel package to a file
                var fileInfo = new FileInfo("output.xlsx");
                package.SaveAs(fileInfo);
            }

            Console.WriteLine("Excel file created successfully.");
        }

    }
}

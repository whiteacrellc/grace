using grace.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grace.tabs
{

    internal class CheckOutTab
    {
        private Vivian vivian;
        private DataGridView checkOutDataGrid;
        private BindingSource checkoutBindingSource;
        private TextBox checkOutSearchTextBox;
        private TextBox textBoxBarCode;

        private string scannedBarcode = string.Empty;

        internal CheckOutTab(Vivian v)
        {
            vivian = v;
            checkOutDataGrid = vivian.checkOutDataGrid;
            checkoutBindingSource = vivian.checkoutBindingSource;
            checkOutSearchTextBox = vivian.checkOutSearchTextBox;
            textBoxBarCode = vivian.textBoxBarcode;

        }

        public void Load()
        {
           InitializeDataGridView();
            // Add callbacks
            checkOutSearchTextBox.TextChanged += checkOutSearchTextBox_TextChanged;
            textBoxBarCode.KeyPress += textBoxBarcode_KeyPress;
        }

        private void InitializeDataGridView()
        {

            checkOutDataGrid.DataSource = checkoutBindingSource;

            using (var context = new GraceDbContext())
            {

                // Fetch data from the DbContext
                var graceRowsData = context.GraceRows.Select(row => new
                {
                    Sku = row.Sku,
                    Brand = row.Brand,
                    Description = row.Description,
                    BarCode = row.BarCode,
                    Total = row.Total
                }).ToList();

                // Bind data to the DataGridView
                checkoutBindingSource.DataSource = graceRowsData;
            }

        }

        internal void checkOutSearchTextBox_TextChanged(object? sender, EventArgs e)
        {
            string searchTerm = checkOutSearchTextBox.Text;

            using (var context = new GraceDbContext())
            {
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    // Query the DbContext to filter products based on the "Sku" column
                    var filteredProducts = context.GraceRows.Select(row => new
                    {
                        Sku = row.Sku,
                        Brand = row.Brand,
                        Description = row.Description,
                        BarCode = row.BarCode,
                        Total = row.Total
                    }).Where(p => p.Description.Contains(searchTerm))
                    .ToList();

                    // Bind the filtered products to the DataGridView
                    checkoutBindingSource.DataSource = filteredProducts;
                }
                else
                {
                    // Reset to normal view
                    var graceRowsData = context.GraceRows.Select(row => new
                    {
                        Sku = row.Sku,
                        Brand = row.Brand,
                        Description = row.Description,
                        BarCode = row.BarCode,
                        Total = row.Total
                    }).ToList();

                    // Bind data to the DataGridView
                    checkoutBindingSource.DataSource = graceRowsData; ;
                    // dataGridView.DataSource = dataGridLoader.graceDb.GraceRows.ToList();
                }
            }
        }

        private void textBoxBarcode_KeyPress(object? sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is a number (0-9) or Enter (Carriage Return)
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Enter)
            {
                // Handle the keypress
                if (e.KeyChar != (char)Keys.Enter)
                {
                    // Append the digit to the scanned barcode
                    scannedBarcode += e.KeyChar;
                }
                else
                {
                    using (var context = new GraceDbContext())
                    {
               

                        // Query the DbContext to filter products based on the "Sku" column
                        var filteredProducts = context.GraceRows.Select(row => new
                        {
                            Sku = row.Sku,
                            Brand = row.Brand,
                            Description = row.Description,
                            BarCode = row.BarCode,
                            Total = row.Total
                        }).FirstOrDefault(item => item.BarCode == scannedBarcode);
                        //    .ToList();

                        // Bind the filtered products to the DataGridView
                        checkoutBindingSource.DataSource = filteredProducts;

                        // Reset the scanned barcode for the next scan
                        scannedBarcode = string.Empty;
                    }

                    // Mark the keypress as handled to prevent it from being processed further
                    e.Handled = true;
                }
            }
        }


    }
}

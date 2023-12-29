using grace.data;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
        private Button coResetButton;

        private string scannedBarcode = string.Empty;
        private int user_id = 0;

        internal CheckOutTab(Vivian v)
        {
            vivian = v;
            checkOutDataGrid = vivian.checkOutDataGrid;
            checkoutBindingSource = vivian.checkoutBindingSource;
            checkOutSearchTextBox = vivian.checkOutSearchTextBox;
            textBoxBarCode = vivian.textBoxBarcode;
            coResetButton = vivian.coResetButton;
        }

        public void Load()
        {
            // Add callbacks
            checkOutSearchTextBox.TextChanged += checkOutSearchTextBox_TextChanged;
            textBoxBarCode.KeyPress += textBoxBarcode_KeyPress;
            coResetButton.Click += coResetButton_Click;
            checkOutDataGrid.CellMouseDoubleClick += checkOutDataGrid_CellMouseDoubleClick;
        }

        public void InitializeDataGridView()
        {
            var username = Globals.GetInstance().CurrentUser;
            user_id = DataBase.GetUserIdFromName(username);
            LoadDataGrid();
        }

        private void checkOutDataGrid_CellMouseDoubleClick(object? sender,
            DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = checkOutDataGrid.Rows[rowIndex];
            var sku = row.Cells["Sku"].Value as string;
            using (CheckOutForm editRowForm = new CheckOutForm(sku))
            {
                DialogResult result = editRowForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // we need to reload the grid.
                    LoadDataGrid();
                }
            }
        }

        internal void LoadDataGrid()
        {
            checkOutDataGrid.DataSource = checkoutBindingSource;

            using (var context = new GraceDbContext())
            {

                var graceRowsData = (
                    from graceRow in context.GraceRows
                    join pulledItem in context.PulledDb on graceRow.ID equals pulledItem.GraceId into
                    pulledItemsGroup
                    from pulledItem in pulledItemsGroup.DefaultIfEmpty() // Left outer join
                    where pulledItem == null || pulledItem.UserId == user_id
                    orderby pulledItem != null ? pulledItem.CurrentTotal : 0 descending
                    select new
                    {
                        Sku = graceRow.Sku,
                        Brand = graceRow.Brand,
                        Description = graceRow.Description,
                        BarCode = graceRow.BarCode,
                        Total = graceRow.Total,
                        UserTotal = pulledItem != null ? pulledItem.CurrentTotal : 0
                    }
                ).ToList();

                // Bind data to the DataGridView
                checkoutBindingSource.DataSource = graceRowsData;
            }
        }
        internal void coResetButton_Click(object? sender, EventArgs e)
        {

            InitializeDataGridView();
            textBoxBarCode.Text = string.Empty;
            checkOutSearchTextBox.Text = string.Empty;

        }

        internal void checkOutSearchTextBox_TextChanged(object? sender, EventArgs e)
        {
            string searchTerm = checkOutSearchTextBox.Text;

            using (var context = new GraceDbContext())
            {
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    var filteredProducts = (
                         from graceRow in context.GraceRows
                         join pulledItem in context.PulledDb on graceRow.ID equals pulledItem.GraceId into pulledItemsGroup
                         from pulledItem in pulledItemsGroup.DefaultIfEmpty() // Left outer join
                         where (pulledItem == null || pulledItem.UserId == user_id) &&
                               (searchTerm == null || graceRow.Description.Contains(searchTerm))
                         orderby pulledItem != null ? pulledItem.CurrentTotal : 0 descending
                         select new
                         {
                             Sku = graceRow.Sku,
                             Brand = graceRow.Brand,
                             Description = graceRow.Description,
                             BarCode = graceRow.BarCode,
                             Total = graceRow.Total,
                             UserTotal = pulledItem != null ? pulledItem.CurrentTotal : 0
                         }
                     ).ToList();

                    // Bind the filtered products to the DataGridView
                    checkoutBindingSource.DataSource = filteredProducts;
                }
                else
                {
                    // Reset to normal view
                    LoadDataGrid();
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

                        var filteredProducts = (
                            from graceRow in context.GraceRows
                            join pulledItem in context.PulledDb on graceRow.ID equals pulledItem.GraceId into pulledItemsGroup
                            from pulledItem in pulledItemsGroup.DefaultIfEmpty() // Left outer join
                            where (pulledItem == null || pulledItem.UserId == user_id) &&
                                  (graceRow.BarCode != null && graceRow.BarCode.Equals(scannedBarcode))
                            orderby pulledItem != null ? pulledItem.CurrentTotal : 0 descending
                            select new
                            {
                                Sku = graceRow.Sku,
                                Brand = graceRow.Brand,
                                Description = graceRow.Description,
                                BarCode = graceRow.BarCode,
                                Total = graceRow.Total,
                                UserTotal = pulledItem != null ? pulledItem.CurrentTotal : 0
                            }
                        ).ToList();

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

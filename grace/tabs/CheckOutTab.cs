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
        private CheckBox autoOpenCheckBox;
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
            autoOpenCheckBox = vivian.autoOpenOnScanCheckBox;
        }

        public void Load()
        {
            // Add callbacks
            checkOutSearchTextBox.TextChanged += checkOutSearchTextBox_TextChanged;
            textBoxBarCode.KeyPress += textBoxBarcode_KeyPress;
            coResetButton.Click += coResetButton_Click;
            checkOutDataGrid.CellMouseDoubleClick += checkOutDataGrid_CellMouseDoubleClick;
            autoOpenCheckBox.CheckedChanged += AutoOpenCheckBox_CheckedChanged;
            // Set row height and font
            SetDataGridViewStyle();
        }

        public void InitializeDataGridView()
        {
            var username = Globals.GetInstance().CurrentUser;
            user_id = DataBase.GetUserIdFromName(username);
            LoadDataGrid();
        }

        private void SetDataGridViewStyle()
        {
            // Set the default cell style
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Veranda", 12),
                // Set other style properties if needed
            };

            checkOutDataGrid.DefaultCellStyle = cellStyle;

            // Set the row height
            //checkOutDataGrid.RowTemplate.Height = 18;
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

        private void ChangeColumnNames()
        {
            // Dictionary to map DbContext column names to desired DataGridView column names
            Dictionary<string, string> columnMappings = new Dictionary<string, string>
        {
            {"Total", "Available" },
            {"UserTotal", "Checked Out"},
            // Add more mappings as needed
        };

            // Iterate through the columns in the DataGridView
            foreach (DataGridViewColumn dataGridViewColumn in checkOutDataGrid.Columns)
            {
                // Check if there is a mapping for the current column name
                if (columnMappings.TryGetValue(dataGridViewColumn.DataPropertyName, out string? value))
                {
                    // Set the HeaderText to the desired name
                    dataGridViewColumn.HeaderText = value;
                }
            }
        }

        internal void LoadDataGrid()
        {
            checkOutDataGrid.DataSource = checkoutBindingSource;

            var graceRowsData = DataBase.GetPulledGrid(user_id);

            // Bind data to the DataGridView
            checkoutBindingSource.DataSource = graceRowsData;
            
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
                    var filteredProducts =
                        DataBase.GetFilteredPulledGrid(user_id, searchTerm);

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
                    var filteredProducts =
                        DataBase.GetPulledGridFromBarCode(user_id, scannedBarcode);

                    // Bind the filtered products to the DataGridView
                    checkoutBindingSource.DataSource = filteredProducts;

                    // Reset the scanned barcode for the next scan
                    scannedBarcode = string.Empty;

                    // Mark the keypress as handled to prevent it from being processed further
                    e.Handled = true;

                    if (autoOpenCheckBox.Checked)
                    {
                        if (filteredProducts.Count > 0)
                        {
                            var sku = filteredProducts[0].Sku;
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
                    }

                }
            }
        }

        private void AutoOpenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Callback function to handle checkbox state change
            if (autoOpenCheckBox.Checked)
            {
                MessageBox.Show("Checkbox is checked!");
            }
            else
            {
                MessageBox.Show("Checkbox is unchecked!");
            }
        }


    }
}

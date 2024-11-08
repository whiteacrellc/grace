using grace.data;
using grace.utils;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
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
        private TabPage checkOutTabPage;
        private DataTable dataTable;

        internal CheckOutTab(Vivian v)
        {
            vivian = v;
            checkOutDataGrid = vivian.checkOutDataGrid;
            checkoutBindingSource = vivian.checkoutBindingSource;
            checkOutSearchTextBox =  vivian.checkOutSearchTextBox;
            textBoxBarCode = vivian.textBoxBarcode;
            coResetButton = vivian.coResetButton;
            checkOutTabPage = vivian.tabControl.TabPages[2];
        }

        public void Load()
        {
            // Add callbacks
            checkOutSearchTextBox.TextChanged += checkOutSearchTextBox_TextChanged;
            checkOutDataGrid.DataBindingComplete += CheckOutDataGrid_DataBindingComplete;
            textBoxBarCode.KeyPress += textBoxBarcode_KeyPress;
            coResetButton.Click += coResetButton_Click;
            checkOutDataGrid.CellMouseDoubleClick += checkOutDataGrid_CellMouseDoubleClick;
            //autoOpenCheckBox.CheckedChanged += AutoOpenCheckBox_CheckedChanged;
            //autoOpenCheckBox.Checked = Globals.GetInstance().BarCodeAutoOpen;
            checkOutTabPage.Enter += CheckOutTabPage_Enter;
            // Set row height and font
            SetDataGridViewStyle();
        }

        public void InitializeDataGridView()
        {
            var username = Globals.GetInstance().CurrentUser;
            user_id = DataBase.GetUserIdFromName(username);
            checkOutDataGrid.DataSource = checkoutBindingSource;
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

        private void CheckOutTabPage_Enter(object? sender, EventArgs e)
        {
            // Initialize the data grid when the user enters the page
            InitializeDataGridView();
        }

        private void checkOutDataGrid_CellMouseDoubleClick(object? sender,
            DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = checkOutDataGrid.Rows[rowIndex];
            var sku = row.Cells["Sku"].Value as string;
            using (CheckOutForm editRowForm = new CheckOutForm(sku))
            {
                DialogResult result = editRowForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    textBoxBarCode.Clear();
                    checkOutSearchTextBox.Clear();
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
                {"UserTotal", "Checked Out" }
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

        internal async void LoadDataGrid()
        {
            dataTable = await LoadDataAsync();
            checkoutBindingSource.DataSource = dataTable;
            ChangeColumnNames();
        }
        
        internal void coResetButton_Click(object? sender, EventArgs e)
        {

            LoadDataGrid();
            textBoxBarCode.Clear();
            checkOutSearchTextBox.Clear();

        }

        private async Task<DataTable> LoadDataAsync()
        {
            // Simulate an asynchronous data retrieval (replace with your actual async data retrieval logic)
            return await Task.Run(() =>
            {
                return DataBase.GetPulledGrid();
            });
        }

        internal void checkOutSearchTextBox_TextChanged(object? sender, EventArgs e)
        {
            string searchTerm = checkOutSearchTextBox.Text;
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var data = DataBase.GetFilteredPulledGrid(dataTable, searchTerm) ;
                checkoutBindingSource.DataSource = data;
            }
            else
            {
                LoadDataGrid();
            }
        }
        private void CheckOutDataGrid_DataBindingComplete(object? sender,
            DataGridViewBindingCompleteEventArgs e)
        {
            Utils.RemoveColumnByName(checkOutDataGrid, "GraceId");
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
                    scannedBarcode = Utils.RemoveLeadingZero(scannedBarcode);
             

                    if (scannedBarcode == null | scannedBarcode == string.Empty)
                    {
                        LoadDataGrid();
                    }
                    else
                    {
                        var filteredProducts =
                            DataBase.GetPulledGridFromBarCode(scannedBarcode);
                        // Bind the filtered products to the DataGridView
                        checkoutBindingSource.DataSource = filteredProducts;


                        ChangeColumnNames();
                        // Reset the scanned barcode for the next scan
                        scannedBarcode = string.Empty;

                        // Mark the keypress as handled to prevent it from being processed further
                        e.Handled = true;

                        if (Globals.GetInstance().BarCodeAutoOpen)
                        {
                            if (filteredProducts.Count > 0)
                            {
                                var sku = filteredProducts[0]["Sku"].ToString();
                                using (CheckOutForm editRowForm = new CheckOutForm(sku))
                                {
                                    DialogResult result = editRowForm.ShowDialog();
                                    if (result == DialogResult.OK)
                                    {
                                        // we need to reload the grid.
                                        LoadDataGrid();
                                        textBoxBarCode.Clear();
                                        checkOutSearchTextBox.Clear();
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }

        private void AutoOpenCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            // Callback function to handle checkbox state change
            if (autoOpenCheckBox.Checked)
            {
                Globals.GetInstance().BarCodeAutoOpen = true;
            }
            else
            {
                Globals.GetInstance().BarCodeAutoOpen = false;
            }
        }


    }
}

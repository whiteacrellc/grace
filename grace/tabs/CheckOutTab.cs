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
 * Year
 */
using grace.utils;
using System.Data;

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
        private TabPage checkOutTabPage;
        private DataTable dataTable;

        internal CheckOutTab(Vivian v)
        {
            vivian = v;
            checkOutDataGrid = vivian.checkOutDataGrid;
            checkoutBindingSource = vivian.checkoutBindingSource;
            checkOutSearchTextBox = vivian.checkOutSearchTextBox;
            textBoxBarCode = vivian.textBoxBarcode;
            coResetButton = vivian.coResetButton;
            checkOutTabPage = vivian.tabControl.TabPages[1];
        }

        public void Load()
        {
            // Add callbacks
            checkOutSearchTextBox.TextChanged += CheckOutSearchTextBox_TextChanged;
            checkOutDataGrid.DataBindingComplete += CheckOutDataGrid_DataBindingComplete;
            textBoxBarCode.KeyPress += TextBoxBarcode_KeyPress;
            coResetButton.Click += CoResetButton_Click;
            checkOutDataGrid.CellMouseDoubleClick += CheckOutDataGrid_CellMouseDoubleClick;
            //autoOpenCheckBox.CheckedChanged += AutoOpenCheckBox_CheckedChanged;
            //autoOpenCheckBox.Checked = Globals.GetInstance().BarCodeAutoOpen;
            checkOutTabPage.Enter += CheckOutTabPage_Enter;
            // Set row height and font
            SetDataGridViewStyle();
        }

        public void InitializeDataGridView()
        {
            checkOutDataGrid.DataSource = checkoutBindingSource;
            LoadDataGrid();
        }

        private void SetDataGridViewStyle()
        {
            // Set the default cell style
            DataGridViewCellStyle cellStyle = new()
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

        private void CheckOutDataGrid_CellMouseDoubleClick(object? sender,
            DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = checkOutDataGrid.Rows[rowIndex];
            string? sku = row.Cells["Sku"].Value as string;
            using CheckOutForm editRowForm = new(sku);
            DialogResult result = editRowForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxBarCode.Clear();
                checkOutSearchTextBox.Clear();
                // we need to reload the grid.
                LoadDataGrid();
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

        internal void LoadDataGrid()
        {
            dataTable = DataBase.GetPulledGrid();
            checkoutBindingSource.DataSource = dataTable;
            ChangeColumnNames();
        }

        internal void CoResetButton_Click(object? sender, EventArgs e)
        {

            LoadDataGrid();
            textBoxBarCode.Clear();
            checkOutSearchTextBox.Clear();

        }

        internal void CheckOutSearchTextBox_TextChanged(object? sender, EventArgs e)
        {
            string searchTerm = checkOutSearchTextBox.Text;
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var data = DataBase.FilterTableBySku(dataTable, searchTerm);
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

        private void TextBoxBarcode_KeyPress(object? sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is a number (0-9) or Enter (Carriage Return)
            // Handle the keypress
            if (char.IsDigit(e.KeyChar))
            {
                // Append the digit to the scanned barcode
                //textBoxBarCode.Text += e.KeyChar;
                scannedBarcode += e.KeyChar;
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                scannedBarcode = textBoxBarCode.Text;
                scannedBarcode = Utils.RemoveLeadingZero(scannedBarcode);


                if (scannedBarcode == null | scannedBarcode == string.Empty)
                {
                    LoadDataGrid();
                }
                else
                {
                    DataView filteredProducts =
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
                            string? sku = filteredProducts[0]["Sku"].ToString();
                            using CheckOutForm editRowForm = new(sku);
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
            else
            {
                e.Handled = true;
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

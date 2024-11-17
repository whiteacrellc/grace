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
 *
 *  This file contains all the code related to the admin tab in the 
 *  Vivian class. It looks like that the only way to define a callback
 *  in a separate class is by making it static. 
 *  
 */
using grace.data.models;
using grace.utils;
using NLog;
using System.Data;


namespace grace.tabs
{
    public class DataTab : IDisposable
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8602
#pragma warning disable CS8600
        private TabPage dataTabPage;
        private Vivian vivian;

        // Data table controls
        private TextBox filterSkuTextBox;
        private Button clearFilterButton;
        private Button addRowButton;
        private DataGridView dataGridView;
        private BindingSource bindingSource;
        private ToolStripMenuItem setInventoryFontSizeToolStripMenuItem;
        private ToolStripMenuItem saveInventoryReportToolStripMenuItem;
        private bool disposedValue;
        private TextBox filterBarCodeTextBox;
        private DataTable dataTable = new DataTable();

        public DataTab(Vivian v)
        {
            vivian = v;
            // set the tab page
            dataTabPage = vivian.tabControl.TabPages[1];

            // set the controls in the page. 
            filterSkuTextBox = vivian.filterSkuTextBox;
            addRowButton = vivian.addRowButton;
            dataGridView = vivian.dataGridView;
            clearFilterButton = vivian.clearFilterButton;
            setInventoryFontSizeToolStripMenuItem =
                vivian.setInventoryFontSizeToolStripMenuItem;
            filterBarCodeTextBox = vivian.filterBarcodeTextBox;
            saveInventoryReportToolStripMenuItem =
                vivian.saveInventoryReportToolStripMenuItem;
        }

        internal void Load()
        {
            dataGridView.AutoGenerateColumns = true;
            // Callbacks 
            dataGridView.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
            dataGridView.CellFormatting += DataGridView_CellFormatting;
            dataTabPage.Enter += DataTabPage_Enter;
            addRowButton.Click += AddRowButton_Click;
            filterSkuTextBox.TextChanged += FilterSkuTextBox_TextChanged;
            clearFilterButton.Click += ClearFilterButton_Click;
            setInventoryFontSizeToolStripMenuItem.Click
                += SetInventoryFontSizeToolStripMenuItem_Click;
            filterBarCodeTextBox.KeyDown += FilterBarCodeTextBox_KeyDown;
            saveInventoryReportToolStripMenuItem.Click +=
                SaveInventoryReportToolStripMenuItem_Click;

            // Setup data connection to grid view
            bindingSource = [];
        }

        private void ChangeColumnNames()
        {
            // Dictionary to map DbContext column names to desired DataGridView column names
            Dictionary<string, string> columnMappings = new Dictionary<string, string>
            {
                {"Total", "Current Inventory"},
                {"Col1", "Collection 1"},
                {"Col2", "Collection 2"},
                {"Col3", "Collection 3"},
                {"Col4", "Collection 4"},
                {"Col5", "Collection 5"},
                {"Col6", "Collection 6"},
                {"Reorder Status", "Availability" }
                // Add more mappings as needed
            };

            // Iterate through the columns in the DataGridView
            foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns)
            {
                // Check if there is a mapping for the current column name
                if (columnMappings.TryGetValue(dataGridViewColumn.DataPropertyName, out string? value))
                {
                    // Set the HeaderText to the desired name
                    dataGridViewColumn.HeaderText = value;
                }
            }
        }
        internal void BindDataSource(bool refresh = false)
        {
            // Show the "working" cursor
            Cursor.Current = Cursors.WaitCursor;


            RefreshData(refresh);
            UpdateDataGridView();

            Cursor.Current = Cursors.Default;

        }
        private void DataTabPage_Enter(object? sender, EventArgs e)
        {
            filterSkuTextBox.Clear();
            BindDataSource(true);
        }

        internal void RefreshData(bool refresh = false)
        {
            DataGridLoader.LoadBindingTable(refresh);
            dataTable = DataGridLoader.GetData();
            dataGridView.DataSource = dataTable;
        }
        internal void UpdateDataGridView()
        {
            ChangeColumnNames();
            FixColumns();
            LoadSavedFont();
        }

        internal void FixColumns()
        {
            // Make sure this has been initialized before calling. 
            if (dataGridView.ColumnCount == 0)
            {
                return;
            }
            Utils.RemoveColumnByName(dataGridView, "ID");
            Utils.RemoveColumnByName(dataGridView, "GraceId");
            dataGridView.Sort(dataGridView.Columns["Sku"], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void AddRowButton_Click(object? sender, EventArgs e)
        {
            using (EditRowForm editRowForm = new EditRowForm(null))
            {
                DialogResult dialogResult = editRowForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    filterSkuTextBox.Clear();
                    BindDataSource(true);
                }
            }
        }

        // Callback for data binding complete for dataGridView Widget
        private void DataGridView_DataBindingComplete(object? sender,
            DataGridViewBindingCompleteEventArgs e)
        {
            FixColumns();
        }

        private void DataGridView_CellMouseDoubleClick(object? sender,
            DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                logger.Warn("Cell mouse double click has index less than zero");
                return;
            }
            DataGridViewRow row = dataGridView.Rows[rowIndex];
            using (EditRowForm editRowForm = new EditRowForm(row))
            {
                DialogResult result = editRowForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // we need to reload the grid.
                    BindDataSource();
                }
            }
        }


        private void ClearFilterButton_Click(object? sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Enabled = false;

            filterSkuTextBox.Clear();
            filterBarCodeTextBox.Clear();
            BindDataSource();

            button.Enabled = true;
        }

        internal void FilterSkuTextBox_TextChanged(object? sender, EventArgs e)
        {
            string searchTerm = filterSkuTextBox.Text;
            if (string.IsNullOrEmpty(searchTerm))
            {
                bindingSource.DataSource = dataTable;
            }
            else
            {
                bindingSource.DataSource = DataGridLoader.GetFilteredData(dataTable, searchTerm);
            }
            dataGridView.DataSource = bindingSource;
            dataGridView.Sort(dataGridView.Columns["Sku"], System.ComponentModel.ListSortDirection.Ascending);
        }

        internal void FilterBarCodeTextBox_KeyDown(object? sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                TextBox box = (TextBox)sender;
                var str = box.Text.Trim();
                str = Utils.RemoveLeadingZero(str);

                if (string.IsNullOrEmpty(str))
                {
                    bindingSource.DataSource = dataTable;

                }
                else
                {
                    bindingSource.DataSource = DataGridLoader.GetFilteredBarCode(dataTable, str);
                }

                FixColumns();
            }
        }

        private void DataGridView_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 11)
            {
                return;
            }
            // Check if the cell contains a numeric value and is in the desired column
            if (e.Value != null && e.ColumnIndex == 11 && IsNumeric(e.Value))
            {
                // Convert the cell value to a numeric type (assuming it's a number)
                double cellValue = Convert.ToDouble(e.Value);

                // Check if the number is negative
                if (cellValue < 0)
                {
                    // Set the background color to yellow for cells with negative numbers
                    e.CellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private void SaveSelectedFont(Font font)
        {
            try
            {
                Properties.Settings.Default.Reload();
                // Save the font to application settings
                Properties.Settings.Default.DataGridFont = font;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
        }

        private void LoadSavedFont()
        {
            try
            {
                // Load the saved font from application settings
                Font savedFont = Properties.Settings.Default.DataGridFont;

                // If the saved font is null (first run), set a default font
                if (savedFont != null)
                {
                    ApplyFontToDataGridViewRows(savedFont);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
        }

        private void SetInventoryFontSizeToolStripMenuItem_Click(object? sender, EventArgs e)
        {

            // Create a FontDialog
            using (FontDialog fontDialog = new FontDialog())
            {
                // Show the dialog and get the selected font
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    // Apply the selected font to the rows
                    // ApplyFontToDataGridViewRows(fontDialog.Font);
                    dataGridView.RowsDefaultCellStyle.Font = fontDialog.Font;

                    // Save the selected font
                    SaveSelectedFont(fontDialog.Font);
                }
            }
        }

        private void ApplyFontToDataGridViewRows(Font font)
        {
            // Loop through all rows in the DataGridView and set the font
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.DefaultCellStyle.Font = font;
            }
        }

        private void SaveInventoryReportToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            vivian.EnableReportMenuItems(false);

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = $"inventory_{DateTime.Now.ToString("yyyyMMdd")}.xlsx";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                // saveFileDialog.Multiselect = true;
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";  // File filter


                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string filePath = saveFileDialog.FileName;
                InventoryReport ir = new InventoryReport(dataGridView);
                ir.writeReport(filePath);
            }

            vivian.EnableReportMenuItems(true);
        }

        // Helper method to check if a value is numeric
        private bool IsNumeric(object value)
        {
            return value is int || value is double || value is float || value is decimal;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    bindingSource.Dispose();
                }

                disposedValue = true;
            }
        }

        ~DataTab()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602
#pragma warning restore CS8618
#pragma warning restore CS8600
    }
}


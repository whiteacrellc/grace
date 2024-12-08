/*
 * Copyright (c) 2024 White Acre Software LLC
 * All rights reserved.
 *
 * This software is the confidential and proprietary information
 * of White Acre Software LLC. You shall not disclose such
 * Confidential Information and shall use it only in accordance
 * with the terms of the license agreement you entered into with
 * White Acre Software LLC.
 *
 * Year: 2024
 */
using grace.utils;
using NLog;
using System.Data;


namespace grace.tabs
{
    internal class ReportTab : IDisposable
    {
        private readonly Vivian vivian;
        private DataGridView reportGridView;
        private BindingSource bindingSource;
        private Button refreshButton;
        private TextBox filterTextBox;
        TabPage reportTabPage;
        private DataTable dataTable = new();
        private bool disposedValue = false;

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        internal ReportTab(Vivian v)
        {
            this.vivian = v;
            this.reportGridView = vivian.reportGridView;
            this.refreshButton = vivian.refreshButton;
            this.filterTextBox = vivian.reportFilterTextBox;
            reportTabPage = vivian.tabControl.TabPages[4];
        }


        public void Load()
        {

            reportTabPage.Enter += ReportTabPage_Enter;

            // reportGridView.CellMouseDoubleClick += ReportGridView_CellMouseDoubleClick;
            refreshButton.Click += RefreshButton_Click;
            filterTextBox.TextChanged += FilterTextBox_TextChanged;

            // Setup data connection to grid view
            bindingSource = [];


        }

        private void ReportTabPage_Enter(object? sender, EventArgs e)
        {
            BindDataSource(true);
        }

        private void ChangeColumnNames()
        {
            // Dictionary to map DbContext column names to desired DataGridView column names
            Dictionary<string, string> columnMappings = new()
            {
               // {"LastUpdated", "Total" },
                {"Sku", "Item #" },
                // Add more mappings as needed
            };

            // Iterate through the columns in the DataGridView
            foreach (DataGridViewColumn dataGridViewColumn in reportGridView.Columns)
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

            if (refresh)
            {
                RefreshData();
            }
            UpdateDataGridView();

            // Return the cursor to normal
            Cursor.Current = Cursors.Default;
        }

        internal void RefreshData()
        {
            dataTable = DataBase.GetCheckedOutReport();
        }
        internal void UpdateDataGridView()
        {
            reportGridView.DataSource = dataTable;
            ChangeColumnNames();
            Utils.RemoveColumnByName(reportGridView, "GraceId");
            reportGridView.Sort(reportGridView.Columns["Sku"], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void RefreshButton_Click(object? sender, EventArgs e)
        {
            Button button = (Button)sender;


            // Disable the button to prevent multiple clicks
            button.Enabled = false;

            // Clear the filter text box
            filterTextBox.Clear();

            // Bind the whole dataset
            BindDataSource(true);

            // Enable the button
            button.Enabled = true;
        }

        internal void FilterTextBox_TextChanged(object? sender, EventArgs e)
        {
            string searchTerm = filterTextBox.Text;
            reportGridView.DataSource = string.IsNullOrEmpty(searchTerm) ? dataTable : GetFilteredData(dataTable, searchTerm);
            reportGridView.Sort(reportGridView.Columns["LastUpdated"], System.ComponentModel.ListSortDirection.Ascending);
        }

        public static DataView GetFilteredData(DataTable table, string searchTerm)
        {
            DataView view = new(table)
            {
                RowFilter = "Sku LIKE '%" + searchTerm +
                    "%' OR Description LIKE '%"
                    + searchTerm + "%'",
                Sort = "LastUpdated DESC"
            };
            return view;
        }


        private void ReportGridView_CellMouseDoubleClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                logger.Warn("Cell mouse double click has index less than zero");
                return;
            }
            DataGridViewRow row = reportGridView.Rows[rowIndex];
            using EditRowForm editRowForm = new(row);
            DialogResult result = editRowForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // we need to reload the grid.
                BindDataSource();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dataTable.Dispose();
                    bindingSource.Dispose();
                }

                disposedValue = true;
            }
        }

        ~ReportTab()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

using grace.data;
using grace.data.models;
using grace.utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grace.tabs
{
    internal class ReportTab : IDisposable
    {
        private readonly Vivian vivian;
        private DataGridView reportGridView;
        private BindingSource bindingSource;
        private DateTimePicker startTimePicker;
        private DateTimePicker endTimePicker;
        private Button refreshButton;
        private Button showAllButton;
        private TextBox filterTextBox;
        TabPage reportTabPage;
        DateTime startDateRange;
        DateTime endDateRange;
        private DataTable dataTable = new DataTable();
        private bool disposedValue = false;

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        internal ReportTab(Vivian v)
        {
            this.vivian = v;
            this.reportGridView = vivian.reportGridView;
            this.startTimePicker = vivian.startTimePicker;
            this.endTimePicker = vivian.endTimePicker;
            this.refreshButton = vivian.refreshButton;
            this.filterTextBox = vivian.reportFilterTextBox;
            this.showAllButton = vivian.showAllButton;
            reportTabPage = vivian.tabControl.TabPages[4];
        }


        public void Load()
        {

            DateTime? latestTime = GetLatestTotal();
            if (latestTime != null)
            {
                endTimePicker.Value = latestTime.Value;
                endDateRange = latestTime.Value;
                startDateRange = latestTime.Value.AddDays(-14);
            }
            else
            {
                endTimePicker.Value = DateTime.Now;
                endDateRange = DateTime.Now;
                startDateRange = DateTime.Now.AddDays(-140);
            }

            reportTabPage.Enter += ReportTabPage_Enter;

            reportGridView.CellMouseDoubleClick += reportGridView_CellMouseDoubleClick;
            startTimePicker.ValueChanged += StartTimePicker_ValueChanged;
            endTimePicker.ValueChanged += EndTimePicker_ValueChanged;
            refreshButton.Click += RefreshButton_Click;
            filterTextBox.TextChanged += FilterTextBox_TextChanged;
            showAllButton.Click += ShowAllButton_Click;

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
            Dictionary<string, string> columnMappings = new Dictionary<string, string>
            {
                {"LastUpdated", "Total" },
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
           
            startDateRange = startTimePicker.Value;
            logger.Info(startDateRange.ToString("dd/MM/yyyy"));
            endDateRange = endTimePicker.Value;
            logger.Info(endDateRange.ToString("dd/MM/yyyy"));
            dataTable = DataBase.GetCheckedOutReport(startDateRange, endDateRange);
            reportGridView.DataSource = dataTable;
            ChangeColumnNames();
            Utils.RemoveColumnByName(reportGridView, "GraceId");
            reportGridView.Sort(reportGridView.Columns["LastUpdated"], System.ComponentModel.ListSortDirection.Descending);
        }

        private void EndTimePicker_ValueChanged(object? sender, EventArgs e)
        {
            filterTextBox.Clear();
            BindDataSource(true);
        }

        private void StartTimePicker_ValueChanged(object? sender, EventArgs e)
        {
            filterTextBox.Clear();
            BindDataSource(true);
        }

        private void RefreshButton_Click(object? sender, EventArgs e)
        {
            filterTextBox.Clear();
            BindDataSource(true);
        }

        private void ShowAllButton_Click(object? sender, EventArgs e)
        {
            DateTime? earliest = GetEarliestTotal();
            if (earliest != null)
            {
                startDateRange = (DateTime)earliest;
                endTimePicker.Value = (DateTime)earliest;
            }
            filterTextBox.Clear();
            BindDataSource(true);
        }

        internal void FilterTextBox_TextChanged(object? sender, EventArgs e)
        {
            string searchTerm = filterTextBox.Text;
            if (string.IsNullOrEmpty(searchTerm))
            {
                bindingSource.DataSource = dataTable;
            }
            else
            {
                bindingSource.DataSource = getFilteredData(dataTable, searchTerm);
            }
            reportGridView.DataSource = bindingSource;
        }

        public static DataView getFilteredData(DataTable table, string searchTerm)
        {
            DataView view = new DataView(table)
            {
                RowFilter = "Sku LIKE '%" + searchTerm +
                    "%' OR Description LIKE '%"
                    + searchTerm + "%'"
            };
            return view;
        }

       
        public DateTime? GetEarliestTotal()
        {
            using (var context = new GraceDbContext())
            {
                var lastTotal = context.Totals
                    .Min(t => (DateTime?)t.LastUpdated);
                return lastTotal;
            }
        }

        private void reportGridView_CellMouseDoubleClick(object? sender,
    DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                logger.Warn("Cell mouse double click has index less than zero");
                return;
            }
            DataGridViewRow row = reportGridView.Rows[rowIndex];
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

        public  DateTime? GetLatestTotal()
        {
            using (var context = new GraceDbContext())
            {
                var lastTotal = context.Totals
                    .Max(t => (DateTime?)t.LastUpdated);
                return lastTotal;
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

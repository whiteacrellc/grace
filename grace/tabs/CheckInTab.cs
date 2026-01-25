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
 * Year: 2024
 */
using grace.data;
using grace.data.models;
using grace.utils;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Data;

namespace grace.tabs
{
    internal class CheckInTab
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly Vivian vivian;
        private DataGridView checkInDataGrid;
        private int user_id;
        private BindingSource checkInBindingSource;
        private TabPage checkInTabPage;
        private CheckBox allUsersCheckBox;
        private TextBox skuFilterTextBox;
        private Button applyChangesButton;
        private DataTable dataTable;

        internal CheckInTab(Vivian v)
        {
            this.vivian = v;
            Setup();
        }

        private void Setup()
        {

            this.skuFilterTextBox = vivian.skuFilterTextBox;
            this.checkInDataGrid = vivian.checkInDataGrid;
            this.checkInTabPage = vivian.tabControl.TabPages[2];
            this.allUsersCheckBox = vivian.allUsersCheckBox;
            this.applyChangesButton = vivian.applyChangesButton;
        }

        public void Load()
        {
            checkInBindingSource = vivian.checkInBindingSource;
            checkInDataGrid.AutoGenerateColumns = true;
            // Callbacks 
            checkInDataGrid.CellMouseDoubleClick += CheckInDataGrid_CellMouseDoubleClick;
            checkInDataGrid.KeyPress += checkInDataGrid_KeyPress;
            checkInDataGrid.CellBeginEdit += CheckInDataGrid_CellBeginEdit;
            checkInDataGrid.CellFormatting += CheckInDataGrid_CellFormatting;
            checkInDataGrid.CellEndEdit += CheckInDataGrid_CellEndEdit;
            checkInTabPage.Enter += CheckInTabPage_Enter;
            allUsersCheckBox.CheckedChanged += AllUsersCheckBox_CheckedChanged;
            applyChangesButton.Click += ApplyChangesButton_Click;
            skuFilterTextBox.TextChanged += SkuFilterTextBox_TextChanged;
        }

        public void InitializeDataGridView()
        {
            checkInDataGrid.DataSource = checkInBindingSource;
            var username = Globals.GetInstance().CurrentUser;
            user_id = DataBase.GetUserIdFromName(username);

            LoadDataGrid();
        }

        public async Task InitializeDataGridViewAsync()
        {
            checkInDataGrid.DataSource = checkInBindingSource;
            var username = Globals.GetInstance().CurrentUser;
            user_id = DataBase.GetUserIdFromName(username);

            await LoadDataGridAsync();
        }

        internal void LoadDataGrid()
        {
            checkInDataGrid.DataSource = checkInBindingSource;

            if (allUsersCheckBox.Checked)
            {
                // Bind data to the DataGridView
                dataTable = DataBase.GetCheckedOutGridAll();
                checkInBindingSource.DataSource = dataTable;
            }
            else
            {
                dataTable = DataBase.GetCheckedOutGrid(user_id);
                checkInBindingSource.DataSource = dataTable;

            }

            ApplyGridStyling();
        }

        internal async Task LoadDataGridAsync()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                checkInDataGrid.DataSource = checkInBindingSource;

                if (allUsersCheckBox.Checked)
                {
                    // Bind data to the DataGridView asynchronously
                    dataTable = await DataBase.GetCheckedOutGridAllAsync();
                    checkInBindingSource.DataSource = dataTable;
                }
                else
                {
                    dataTable = await DataBase.GetCheckedOutGridAsync(user_id);
                    checkInBindingSource.DataSource = dataTable;
                }

                ApplyGridStyling();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ApplyGridStyling()
        {
            // Make all but UserTotal column have a gray background.
            checkInDataGrid.Columns["Sku"].DefaultCellStyle.BackColor = Color.LightGray;
            checkInDataGrid.Columns["Brand"].DefaultCellStyle.BackColor = Color.LightGray;
            checkInDataGrid.Columns["Collection"].DefaultCellStyle.BackColor = Color.LightGray;
            checkInDataGrid.Columns["Description"].DefaultCellStyle.BackColor = Color.LightGray;
            checkInDataGrid.Columns["UserTotal"].DefaultCellStyle.BackColor = Color.LightGray;
            checkInDataGrid.Columns["BarCode"].DefaultCellStyle.BackColor = Color.LightGray;
            checkInDataGrid.Columns["UserName"].DefaultCellStyle.BackColor = Color.LightGray;
            checkInDataGrid.Columns["LastUpdated"].DefaultCellStyle.BackColor = Color.LightGray;
            checkInDataGrid.Columns["GraceId"].DefaultCellStyle.BackColor = Color.LightGray;
            ChangeColumnNames();
            Utils.RemoveColumnByName(checkInDataGrid, "GraceId");

            // Disable sorting on all columns to prevent data integrity issues
            // when processing check-ins (see ApplyChangesButton_Click)
            foreach (DataGridViewColumn column in checkInDataGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        internal void SkuFilterTextBox_TextChanged(object? sender, EventArgs e)
        {
            string searchTerm = skuFilterTextBox.Text;
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                DataView data = DataBase.FilterTableBySku(dataTable, searchTerm);
                checkInBindingSource.DataSource = data;
            }
            else
            {
                LoadDataGrid();
            }

        }
        private void CheckInDataGrid_CellMouseDoubleClick(object? sender,
            DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = checkInDataGrid.Rows[rowIndex];
            using CheckInDialog editRowForm = new(row);
            DialogResult result = editRowForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // we need to reload the grid.
                LoadDataGrid();
            }
        }

        private void ChangeColumnNames()
        {
            // Dictionary to map DbContext column names to desired DataGridView column names
            Dictionary<string, string> columnMappings = new()
            {
            {"UserTotal", "Checked Out" },
            {"dateTime", "Date"},
            // Add more mappings as needed
        };

            // Iterate through the columns in the DataGridView
            foreach (DataGridViewColumn dataGridViewColumn in checkInDataGrid.Columns)
            {
                // Check if there is a mapping for the current column name
                if (columnMappings.TryGetValue(dataGridViewColumn.DataPropertyName, out string? value))
                {
                    // Set the HeaderText to the desired name
                    dataGridViewColumn.HeaderText = value;
                }
            }
        }
        private async void CheckInTabPage_Enter(object? sender, EventArgs e)
        {
            // Only reload if data has changed or this is the first load
            if (Globals.GetInstance().CheckInDataDirty || dataTable == null || dataTable.Rows.Count == 0)
            {
                await InitializeDataGridViewAsync();
                Globals.GetInstance().CheckInDataDirty = false;
            }
        }

        // Only allow positive integers in the text box
        private void checkInDataGrid_KeyPress(object? sender,
            KeyPressEventArgs e)
        {
            // Allow digits (0-9) and control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the keypress if the entered character
                // is not a digit or control key
                e.Handled = true;
            }
        }
        private void CheckInDataGrid_CellBeginEdit(object? sender,
            DataGridViewCellCancelEventArgs e)
        {
            // Allow editing only for the "Total" column
            if (e.ColumnIndex != checkInDataGrid.Columns["CheckIn"].Index)
            {
                e.Cancel = true;
            }
        }

        private void CheckInDataGrid_CellFormatting(object? sender,
            DataGridViewCellFormattingEventArgs e)
        {
            TimeZoneInfo systemTimeZone = TimeZoneInfo.Local;

            // Check if the formatting is for the DateTime column
            if (checkInDataGrid.Columns[e.ColumnIndex].Name == "dateTime"
                && e.Value != null)
            {

                // Format the DateTime value to the desired format
                if (e.Value is DateTime dateTimeValue)
                {
                    DateTime systemTime =
                        TimeZoneInfo.ConvertTimeFromUtc(dateTimeValue.ToUniversalTime(),
                        systemTimeZone);

                    e.Value = systemTime.ToString("dd/MM/yyyy HH:mm:s");
                    e.FormattingApplied = true;
                }
            }
        }

        private void CheckInDataGrid_CellEndEdit(object? sender,
            DataGridViewCellEventArgs e)
        {
            // Check if the edited row index is valid
            if (e.RowIndex >= 0)
            {
                // Get the DataGridView instance

                if (sender is DataGridView gridView)
                {

                    // Get the row that was edited
                    DataGridViewRow editedRow = gridView.Rows[e.RowIndex];

                    // Collect values from all cells in the row
                    List<string> cellValues = [];
                    foreach (DataGridViewCell cell in editedRow.Cells)
                    {
                        cellValues.Add(cell.Value?.ToString() ?? "null"); // Handle null values
                    }

                    // Display the collected values (or use them in your logic)
                    logger.Info(string.Join(", ", cellValues), "Row Values");
                }
            }
        }

        private void AllUsersCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            // Callback function to handle checkbox state change
            LoadDataGrid();
        }


        private void ApplyChangesButton_Click(object? sender, EventArgs e)
        {
            // Check if the edit is in the "Total" column
            int numrows = checkInDataGrid.Rows.Count;
            bool changed = false;

            // Collect all changes first, then batch process
            var changesToApply = new List<(string sku, int updatedValue, string collectionName, string username, DateTime dateTime)>();

            for (int i = 0; i < numrows; i++)
            {
                DataGridViewRow row = checkInDataGrid.Rows[i];
                if (row.Cells["CheckIn"].Value is string value && value != string.Empty)
                {
                    changed = true;
                    int updatedValue = Convert.ToInt32(value);
                    string sku = row.Cells["Sku"].Value.ToString() ?? string.Empty;
                    string collectionName = row.Cells["Collection"].Value.ToString() ?? string.Empty;
                    string username = row.Cells["Username"].Value.ToString() ?? string.Empty;
                    DateTime dateTime = (DateTime)row.Cells["LastUpdated"].Value;

                    changesToApply.Add((sku, updatedValue, collectionName, username, dateTime));
                }
            }

            if (changed)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    // Batch process all changes with preloaded lookups
                    ApplyChangesBatched(changesToApply);

                    // Mark related data as dirty for other tabs
                    Globals.GetInstance().GraceDataDirty = true;
                    Globals.GetInstance().CheckOutDataDirty = true;

                    LoadDataGrid();
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void ApplyChangesBatched(List<(string sku, int updatedValue, string collectionName, string username, DateTime dateTime)> changes)
        {
            using var context = new GraceDbContext();

            // Preload all needed data in bulk
            var skus = changes.Select(c => c.sku).Distinct().ToList();
            var usernames = changes.Select(c => c.username).Distinct().ToList();

            // Load all graces by SKU
            var gracesBySku = context.Graces
                .Where(g => skus.Contains(g.Sku))
                .ToDictionary(g => g.Sku, g => g.ID);

            // Load all users by name
            var usersByName = context.Users
                .Where(u => usernames.Contains(u.Username))
                .ToDictionary(u => u.Username, u => u.ID);

            // Load all latest totals
            var latestTotals = context.Totals
                .OrderByDescending(t => t.ID)
                .ToList()
                .GroupBy(t => t.GraceId)
                .ToDictionary(g => g.Key, g => g.First().CurrentTotal);

            // Load all collections for the graces
            var graceIds = gracesBySku.Values.ToList();
            var collectionsLookup = context.Collections
                .Where(c => graceIds.Contains(c.GraceId))
                .ToList()
                .GroupBy(c => (c.GraceId, c.Name))
                .ToDictionary(g => g.Key, g => g.First().ID);

            string currentUser = Globals.GetInstance().CurrentUser ?? "System";
            var totalsToAdd = new List<Total>();
            var pulledToUpdate = new List<(DateTime dateTime, int userId, int collectionId, int graceId, int updatedValue)>();

            foreach (var (sku, updatedValue, collectionName, username, dateTime) in changes)
            {
                if (!gracesBySku.TryGetValue(sku, out int graceId))
                {
                    logger.Error("GraceId not found for SKU: " + sku);
                    continue;
                }

                if (!usersByName.TryGetValue(username, out int userId))
                {
                    logger.Error("UserId not found for username: " + username);
                    continue;
                }

                if (!collectionsLookup.TryGetValue((graceId, collectionName), out int colId))
                {
                    logger.Error($"Collection not found for GraceId {graceId}, Collection {collectionName}");
                    continue;
                }

                int currentTotal = latestTotals.GetValueOrDefault(graceId, 0);
                int newTotal = currentTotal + updatedValue;

                // Check if total actually changed before adding
                if (currentTotal != newTotal)
                {
                    totalsToAdd.Add(new Total
                    {
                        LastUpdated = DateTime.Now,
                        CurrentTotal = newTotal,
                        GraceId = graceId,
                        User = currentUser
                    });
                    // Update the cached value for subsequent calculations
                    latestTotals[graceId] = newTotal;
                }

                pulledToUpdate.Add((dateTime, userId, colId, graceId, updatedValue));
            }

            // Batch add all totals
            if (totalsToAdd.Count > 0)
            {
                context.Totals.AddRange(totalsToAdd);
            }

            // Batch update all pulled entries
            foreach (var (dateTime, userId, collectionId, graceId, updatedValue) in pulledToUpdate)
            {
                var pulled = context.PulledDb.SingleOrDefault(e =>
                    e.UserId == userId &&
                    e.CollectionId == collectionId &&
                    e.GraceId == graceId &&
                    e.LastUpdated == dateTime);

                if (pulled != null)
                {
                    pulled.IsCompleted = true;
                    pulled.CheckedInAmount = updatedValue;
                }
            }

            // Single SaveChanges for all operations
            context.SaveChanges();
        }
    }
}

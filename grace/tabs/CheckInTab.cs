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
using NLog;
using System.Data;
using grace.utils;

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
            using (CheckInDialog editRowForm = new CheckInDialog(row))
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
        private void CheckInTabPage_Enter(object? sender, EventArgs e)
        {
            // Initialize the data grid when the user enters the page
            InitializeDataGridView();
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
            String currentUser = Globals.GetInstance().CurrentUser;
            for (int i = 0; i < numrows; i++)
            {
                DataGridViewRow row = checkInDataGrid.Rows[i];
                if (row.Cells["CheckIn"].Value is string value && value != string.Empty)
                {
                    changed = true;
                    // Get the updated value
                    int updatedValue = Convert.ToInt32(value);
                    // TODO: need to test if sorting or filtering breaks this.
                    // for now don't allow sorting or filtering
                    string sku = row.Cells["Sku"].Value.ToString();
                    int graceId = DataBase.GetGraceIdFromSku(sku);
                    if (graceId == 0)
                    {
                        MessageBox.Show("Processing error for SKU " + sku, "Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Error("GraceId not found for SKU: " + sku);
                        continue;
                    }
                    string collectionName = row.Cells["Collection"].Value.ToString();
                    string username = row.Cells["Username"].Value.ToString();
                    DateTime dateTime = (DateTime)row.Cells["LastUpdated"].Value;
                    int user_id = DataBase.GetUserIdFromName(username);
                    int col_id = DataBase.GetCollectionId(graceId, collectionName);
                    int currentTotal = DataBase.GetTotal(graceId).CurrentTotal;
                    int newTotal = currentTotal + updatedValue;

                    using (GraceDbContext context = new())
                    {
                        // Add Totals in CurrentTotal db
                        Total total = new()
                        {
                            LastUpdated = DateTime.Now,
                            GraceId = graceId,
                            CurrentTotal = newTotal,
                            User = currentUser,
                        };
                        context.Totals.Add(total);
                        context.SaveChanges();
                    }
                    PulledEntrySetComplete(dateTime, user_id, col_id, graceId, updatedValue);
                }
            }
            if (changed)
            {
                LoadDataGrid();
            }
        }
        private void PulledEntrySetComplete(DateTime dateTime, int userId,
            int collectionId, int graceId, int updatedValue)
        {
            using (var context = new GraceDbContext())
            {
                Pulled? pulled = context.PulledDb.SingleOrDefault(e => e.UserId
                    == userId && e.CollectionId == collectionId
                    && e.GraceId == graceId && e.LastUpdated == dateTime);
                if (pulled != null)
                {
                    pulled.IsCompleted = true;
                    pulled.CheckedInAmount = updatedValue;
                    context.SaveChanges();
                }
            }
        }
    }
}

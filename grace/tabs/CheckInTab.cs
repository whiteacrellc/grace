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
using static grace.DataBase;

namespace grace.tabs
{
    internal class CheckInTab
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly Vivian vivian;
        private readonly DataGridView checkInDataGrid;
        private int user_id;
        private BindingSource checkInBindingSource;
        private TabPage checkInTabPage;
        private CheckBox allUsersCheckBox;
        private List<CheckInData> checkInDataList = [];
        private Button applyChangesButton;

        internal CheckInTab(Vivian v)
        {
            vivian = v;
            checkInDataGrid = vivian.checkInDataGrid;
            checkInDataGrid.AutoGenerateColumns = true;
            checkInBindingSource = vivian.checkInBindingSource;
            checkInTabPage = vivian.tabControl.TabPages[3];
            allUsersCheckBox = vivian.allUsersCheckBox;
            applyChangesButton = vivian.applyChangesButton;
        }

        public void Load()
        {
            checkInDataGrid.AutoGenerateColumns = true;
            // Callbacks 
            checkInDataGrid.CellMouseDoubleClick += checkInDataGrid_CellMouseDoubleClick;
            checkInDataGrid.KeyPress += checkInDataGrid_KeyPress;
            checkInDataGrid.CellBeginEdit += CheckInDataGrid_CellBeginEdit;
            checkInDataGrid.CellFormatting += CheckInDataGrid_CellFormatting;
            checkInDataGrid.CellEndEdit += CheckInDataGrid_CellEndEdit;
            checkInTabPage.Enter += CheckInTabPage_Enter;
            allUsersCheckBox.CheckedChanged += AllUsersCheckBox_CheckedChanged;
            applyChangesButton.Click += ApplyChangesButton_Click;
        }

        public void InitializeDataGridView()
        {
            var username = Globals.GetInstance().CurrentUser;
            user_id = DataBase.GetUserIdFromName(username);

            LoadDataGrid();
        }

        internal void LoadDataGrid()
        {
            checkInDataGrid.DataSource = checkInBindingSource;

            if (allUsersCheckBox.Checked)
            {
                List<CheckInData> graceRowsData = DataBase.GetCheckedOutGridAll();
                // Bind data to the DataGridView
                checkInBindingSource.DataSource = graceRowsData;
                checkInDataList = graceRowsData;
            }
            else
            {
                List<CheckInData> graceRowsData = DataBase.GetCheckedOutGrid(user_id);
                // Bind data to the DataGridView
                checkInBindingSource.DataSource = graceRowsData;
                checkInDataList = graceRowsData;
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
            //Utils.RemoveColumnByName(checkInDataGrid, "GraceId");

        }
        private void checkInDataGrid_CellMouseDoubleClick(object? sender,
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
                    object newValue = gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    string columnHeader = gridView.Columns[e.ColumnIndex].HeaderText;

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
            var numrows = checkInDataGrid.Rows.Count;
            bool changed = false;
            for (int i = 0; i < numrows; i++)
            {
                var row = checkInDataGrid.Rows[i];
                var value = row.Cells["CheckIn"].Value as string;
                if (value != null && value != string.Empty)
                {
                    changed = true;
                    // Get the updated value
                    int updatedValue = Convert.ToInt32(value);
                    // TODO: need to test if sorting or filtering breaks this.
                    // for now don't allow sorting or filtering
                    CheckInData checkInData = checkInDataList[i];
                    int graceId = checkInData.GraceId;
                    string collectionName = checkInData.Collection;
                    string username = checkInData.UserName;
                    DateTime dateTime = checkInData.LastUpdated;
                    var user_id = DataBase.GetUserIdFromName(username);
                    int col_id = DataBase.GetCollectionId(graceId, collectionName);
                    int currentTotal = DataBase.GetTotal(graceId).CurrentTotal;
                    int newTotal = currentTotal + updatedValue;

                    using (var context = new GraceDbContext())
                    {

                        // Add Totals in CurrentTotal db
                        Total total = new()
                        {
                            LastUpdated = DateTime.Now,
                            GraceId = graceId,
                            CurrentTotal = newTotal
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
                var pulled = context.PulledDb.SingleOrDefault(e => e.UserId
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

using grace.data;
using grace.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static grace.DataBase;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace grace.tabs
{
    internal class CheckInTab
    {
        private readonly Vivian vivian;
        private DataGridView checkInDataGrid;
        private int user_id;
        private BindingSource checkInBindingSource;
        private TabPage checkInTabPage;
        private CheckBox allUsersCheckBox;
        private List<CheckInData> checkInDataList = new List<CheckInData>();

        internal CheckInTab(Vivian v)
        {
            vivian = v;
            checkInDataGrid = vivian.checkInDataGrid;
            checkInDataGrid.AutoGenerateColumns = true;
            checkInBindingSource = vivian.checkInBindingSource;
            checkInTabPage = vivian.tabControl.TabPages[3];
            allUsersCheckBox = vivian.allUsersCheckBox;
        }

        public void Load()
        {
            checkInDataGrid.KeyPress += checkInDataGrid_KeyPress;
            checkInDataGrid.CellBeginEdit += checkInDataGrid_CellBeginEdit;
            checkInDataGrid.DataBindingComplete += checkInDataGrid_DataBindingComplete;
            checkInDataGrid.CellEndEdit += checkInDataGrid_CellEndEdit; 
            checkInTabPage.Enter += CheckInTabPage_Enter;
            allUsersCheckBox.CheckedChanged += AllUsersCheckBox_CheckedChanged;
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
                var graceRowsData = DataBase.GetCheckedOutGridAll();
                // Bind data to the DataGridView
                checkInBindingSource.DataSource = graceRowsData;
                checkInDataList = graceRowsData;
            }
            else
            {
                var graceRowsData = DataBase.GetCheckedOutGrid(user_id);
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
            ChangeColumnNames();
            Utils.RemoveColumnByName(checkInDataGrid, "GraceId");

        }

        private void ChangeColumnNames()
        {
            // Dictionary to map DbContext column names to desired DataGridView column names
            Dictionary<string, string> columnMappings = new Dictionary<string, string>
        {
            {"CheckIn", "Checked In" },
            {"UserTotal", "Checked Out"},
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
        private void checkInDataGrid_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // Allow digits (0-9) and control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the keypress if the entered character is not a digit or control key
                e.Handled = true;
            }
        }
        private void checkInDataGrid_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
        {
            // Allow editing only for the "Total" column
            if (e.ColumnIndex != checkInDataGrid.Columns["CheckIn"].Index)
            {
                e.Cancel = true;
            }
        }

        private void checkInDataGrid_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            // Check if the edit is in the "Total" column
            if (e.ColumnIndex == checkInDataGrid.Columns["CheckIn"].Index)
            {
                // Get the updated value
                int updatedValue =
                    Convert.ToInt32(checkInDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                CheckInData checkInData = checkInDataList[e.RowIndex];
                int graceId = checkInData.GraceId;
                string collectionName = checkInData.Collection;
                string username = checkInData.UserName;
                var user_id = DataBase.GetUserIdFromName(username);
                int col_id = DataBase.GetCollectionId(graceId, collectionName);
                int currentTotal = DataBase.GetTotal(graceId);
                int newTotal = currentTotal - updatedValue;

                using (var context = new GraceDbContext())
                {
                    /*
                    // Add to pulled table
                    Pulled pulled = new Pulled
                    {

                        UserId = user_id,
                        GraceId = graceId,
                        CollectionId = col_id,
                        Amount = updatedValue,
                        CurrentTotal = newTotal,
                    };
                    context.PulledDb.Add(pulled);
                    context.SaveChanges();
                    // Add Totals in total db
                    Total total = new Total
                    {
                        date_field = DateTime.Now,
                        GraceId = graceId,
                        total = newTotal
                    };
                    context.Totals.Add(total);
                    context.SaveChanges();
                    LoadDataGrid();
                    */
                }
            }
        }

        private void AllUsersCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            // Callback function to handle checkbox state change
            LoadDataGrid();
        }
        private void checkInDataGrid_DataBindingComplete(object? sender, EventArgs e)
        {
            // Remove Collection Id Column
            Utils.RemoveColumnByName(checkInDataGrid, "GraceId");
        }
    }
}

using grace.data;
using grace.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grace.tabs
{
    internal class CollectionTab : IDisposable
    {
        private Vivian vivian;
        private DataGridView collGridView;
        private DataTable dataTable;
        private ComboBox colReportComboBox;
        private TabPage collectionTab;
        private Report report;
        private Button clearComboButton;


        internal CollectionTab(Vivian v)
        {
            vivian = v;
            this.collGridView = v.collGridView;
            this.colReportComboBox = v.colReportComboBox;
            this.clearComboButton = v.clearComboButton;
            this.collectionTab = vivian.tabControl.TabPages[5];
            this.report = new Report();
        }

        public void Load()
        {

            colReportComboBox.SelectedIndexChanged += ColReportComboBox_SelectedIndexChanged;
            collectionTab.Enter += CollectionTab_Enter;
            clearComboButton.Click += ClearComboButton_Click;

            BuildCollectionInfo();
        }

        private void BuildCollectionInfo()
        {
            using GraceDbContext context = new();
            List<string> distinctCollectionNames = [];
            // Fill checkbox list with collection names
            distinctCollectionNames = [.. context.Collections
                .Where(e => e.Name != "Other")
                .Select(e => e.Name)
                .Distinct()
                .OrderBy(name => name)];

            foreach (string d in distinctCollectionNames)
            {
                colReportComboBox.Items.Add(d);
            }
            this.dataTable = report.CreateCollectionTable();
            colReportComboBox.SelectedIndex = -1;
        }

        private void ClearComboButton_Click(object? sender, EventArgs e)
        {

            colReportComboBox.SelectedIndex = -1;
            BindDataSource();
            UpdateDataGridView();
        }

        private void CollectionTab_Enter(object? sender, EventArgs e)
        {
            if (Globals.GetInstance().CollectionDirty)
            {
                BuildCollectionInfo();
                Globals.GetInstance().CollectionDirty = false;
            }
            colReportComboBox.SelectedIndex = -1;
            RefreshData();
            BindDataSource();
        }

        private void ChangeColumnNames()
        {
            // Dictionary to map DbContext column names to desired DataGridView column names
            Dictionary<string, string> columnMappings = new()
            {
                {"Total", "Current Inventory"},
                { "Availability", "Reorder Status" },
                {"Sku", "Item #" },
                // Add more mappings as needed
            };

            // Iterate through the columns in the DataGridView
            foreach (DataGridViewColumn dataGridViewColumn in collGridView.Columns)
            {
                // Check if there is a mapping for the current column name
                if (columnMappings.TryGetValue(dataGridViewColumn.DataPropertyName, out string? value))
                {
                    // Set the HeaderText to the desired name
                    dataGridViewColumn.HeaderText = value;
                }
            }
        }
        internal void BindDataSource()
        {
            // Show the "working" cursor
            Cursor.Current = Cursors.WaitCursor;


            RefreshData();
            UpdateDataGridView();

            Cursor.Current = Cursors.Default;

        }

        public void ColReportComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {

            if (sender is ComboBox comboBox)
            {
                // Get the selected item
                string selectedItem = comboBox.SelectedItem?.ToString() ?? "None";

                if (selectedItem == "None")
                {
                    BindDataSource();
                    UpdateDataGridView();
                }
                else
                {
                    DataView view = GetFilteredData(dataTable, selectedItem);
                    collGridView.DataSource = view;
                    UpdateDataGridView();
                }
            }
        }

        private DataView GetFilteredData(DataTable table, string collection)
        {
            DataView view = new(table)
            {
                RowFilter = "Collection = '" + collection + "'",
                Sort = "Sku ASC"
            };
            return view;
        }

        internal void RefreshData()
        {
            collGridView.DataSource = dataTable;
        }
        internal void UpdateDataGridView()
        {
            if (collGridView.ColumnCount == 0)
            {
                return;
            }
            Utils.RemoveColumnByName(collGridView, "Collections");
            ChangeColumnNames();
            //collGridView.Sort(collGridView.Columns["Collection"], System.ComponentModel.ListSortDirection.Ascending);
        }


        public void Dispose()
        {
            
        }
    }
}

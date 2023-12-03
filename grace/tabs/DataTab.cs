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
using grace.data;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grace.tabs
{
    public class DataTab
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
        private Button addRowButton;
        private DataGridView dataGridView;
        private DataGridLoader dataGridLoader;
        private BindingSource bindingSource;

        public DataTab(Vivian v)
        {
            vivian = v;
            // set the tab page
            dataTabPage = vivian.tabControl.TabPages[1];

            // set the controls in the page. 
            filterSkuTextBox = vivian.filterSkuTextBox;
            addRowButton = vivian.addRowButton;
            dataGridView = vivian.dataGridView;
            dataGridLoader = vivian.dataGridLoader;
            bindingSource = vivian.bindingSource;

        }

        internal void Load()
        {
            dataGridView.CellMouseDoubleClick += dataGridView_CellMouseDoubleClick;
            dataGridView.DataBindingComplete += dataGridView_DataBindingComplete;
            addRowButton.Click += addRowButton_Click;
            filterSkuTextBox.TextChanged += filterSkuTextBox_TextChanged;
            dataGridView.CellBeginEdit += dataGridView_CellBeginEdit;
            dataGridView.CellEndEdit += dataGridView_CellEndEdit;
            dataGridView.Paint += dataGridView_Paint;

            dataGridLoader = new DataGridLoader();
            bindingSource.DataSource = dataGridLoader.getData();
            RemoveColumnsByName("ID", "Grace", "GraceId");

            // Change column names in the DataGridView
            ChangeColumnNames();

        }
        private void ChangeColumnNames()
        {
            // Dictionary to map DbContext column names to desired DataGridView column names
            Dictionary<string, string> columnMappings = new Dictionary<string, string>
        {
            {"Total", "Current Inventory"},
            {"PreviousTotal", "Previous Inventory"},
            {"Col1", "Collection 1"},
            {"Col2", "Collection 2"},
            // Add more mappings as needed
        };

            // Iterate through the columns in the DataGridView
            foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns)
            {
                // Check if there is a mapping for the current column name
                if (columnMappings.ContainsKey(dataGridViewColumn.DataPropertyName))
                {
                    // Set the HeaderText to the desired name
                    dataGridViewColumn.HeaderText = columnMappings[dataGridViewColumn.DataPropertyName];
                }
            }
        }
        internal void BindDataSource()
        {
            if (dataGridLoader == null)
            {
                dataGridLoader = new DataGridLoader();
                dataGridView.DataSource = bindingSource;
            }
            dataGridLoader.LoadBindingTable();
            bindingSource.DataSource = dataGridLoader.graceDb.GraceRows.ToList();
            RemoveColumnsByName("ID", "Grace", "GraceId");
        }

        private void addRowButton_Click(object? sender, EventArgs e)
        {
            using (EditRowForm editRowForm = new EditRowForm(null))
            {
                DialogResult dialogResult = editRowForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    bindingSource.DataSource = dataGridLoader.getData();
                    RemoveColumnsByName("ID", "Grace", "GraceId");
                }
            }
        }

        private void dataGridView_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            RemoveColumnsByName("ID", "Grace", "GraceId");
        }

        private void dataGridView_CellMouseDoubleClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView.Rows[rowIndex];
            using (EditRowForm editRowForm = new EditRowForm(row))
            {
                DialogResult result = editRowForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // we need to reload the grid.
                    bindingSource.DataSource = dataGridLoader.getData();
                    RemoveColumnsByName("ID", "Grace", "GraceId");
                }
            }
        }

        internal void filterSkuTextBox_TextChanged(object? sender, EventArgs e)
        {
            string searchTerm = filterSkuTextBox.Text;


            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                // Query the DbContext to filter products based on the "Sku" column
                var filteredProducts = dataGridLoader.graceDb.GraceRows
                    .Where(p => p.Sku.Contains(searchTerm))
                    .ToList();

                // Bind the filtered products to the DataGridView
                bindingSource.DataSource = filteredProducts;
                // dataGridView.DataSource = filteredProducts;
            }
            else
            {
                // If the search box is empty, show all products
                bindingSource.DataSource = dataGridLoader.getData();
                // dataGridView.DataSource = dataGridLoader.graceDb.GraceRows.ToList();
            }
            RemoveColumnsByName("ID", "Grace", "GraceId");
        }

        private void RemoveColumnsByName(params string[] columnNames)
        {
            foreach (string columnName in columnNames)
            {
                if (dataGridView.Columns.Contains(columnName))
                {
                    dataGridView.Columns.Remove(columnName);
                }
            }
        }

        private void dataGridView_Paint(object? sender, PaintEventArgs e)
        {
            formatTotals();
        }

        private void dataGridView_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            string User = Globals.GetInstance().CurrentUser;

            // Get the modified cell value and the corresponding product
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            object cellValue = dataGridView.Rows[rowIndex].Cells[columnIndex].Value;

            try
            {
                int newTotal = Convert.ToInt32(cellValue);

                if (columnIndex == 12) // Assuming the second column is the "Totals" column
                {
                    // Update the corresponding product in the DbContext
                    int id = Convert.ToInt32(dataGridView.Rows[rowIndex].Cells[0].Value); // Assuming the first column is the "Id" column
                    var graceRow = dataGridLoader.graceDb.GraceRows.Find(id);
                    if (graceRow != null)
                    {
                        //var graceRow = dataGridLoader.graceDb.GraceRows.Where(t => t.GraceId == grace.ID);
                        var grace = dataGridLoader.graceDb.Graces.First(t => t.ID == graceRow.GraceId);

                        if (grace != null)
                        {
                            var total = new Total
                            {
                                date_field = DateTime.Now,
                                total = newTotal,
                                GraceId = id
                            };
                            grace.Totals.Add(total);
                            graceRow.PreviousTotal = graceRow.Total;
                            graceRow.Total = newTotal;
                            dataGridLoader.graceDb.SaveChanges(); // Save changes to the database
                            logger.Info($"{total.date_field} {User} changed {grace.Sku} total to {newTotal}");
                        }
                    }
                }
            }
            catch
            {
                int id = (int)dataGridView.Rows[rowIndex].Cells[0].Value;
                var graceRow = dataGridLoader.graceDb.GraceRows.Find(id);
                if (graceRow != null)
                {
                    if (columnIndex == 12) // Assuming the second column is the "Name" column
                    {
                        dataGridView.Rows[rowIndex].Cells[13].Value = graceRow.Total;
                    }
                }
            }

        }

        private void dataGridView_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            if (columnIndex < 13)
            {
                e.Cancel = true; // Cancel the edit for the first 12 columns
            }
        }

        private void formatTotals()
        {

            int numRows = dataGridView.Rows.Count;
            int numCols = dataGridView.Columns.Count;
            if (numCols > 14)
            {
                return;
            }
            for (int i = 0; i < numRows; i++)
            {
                DataGridViewRow row = dataGridView.Rows[i];

                if (row == null || row.Cells["PreviousTotal"].Value == null) { continue; }

                // Compare the values of the two columns
                int value1 = (int)row.Cells["Total"].Value;
                int value2 = (int)row.Cells["PreviousTotal"].Value;

                if (value1 != value2)
                {
                    // Set the background color to yellow if values are not equal
                    row.Cells["Total"].Style.BackColor = Color.Yellow;
                }
            }

        }

#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602
#pragma warning restore CS8618
#pragma warning restore CS8600
    }
}


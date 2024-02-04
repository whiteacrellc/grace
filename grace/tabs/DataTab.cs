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
using MaterialSkin.Controls;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private MaterialButton clearFilterButton;
        private Button addRowButton;
        private DataGridView dataGridView;
        private BindingSource bindingSource;
        private bool disposedValue;
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
        }

        internal void Load()
        {
            dataGridView.AutoGenerateColumns = true;
            // Callbacks 
            dataGridView.CellMouseDoubleClick += dataGridView_CellMouseDoubleClick;
            dataGridView.DataBindingComplete += dataGridView_DataBindingComplete;
            dataGridView.CellFormatting += DataGridView_CellFormatting;
            dataTabPage.Enter += DataTabPage_Enter;
            addRowButton.Click += addRowButton_Click;
            filterSkuTextBox.TextChanged += filterSkuTextBox_TextChanged;
            clearFilterButton.Click += clearFilterButton_Click;

            // Setup data connection to grid view
            bindingSource = new BindingSource();
    
        }

        private void DataGridView_CellFormatting1(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ChangeColumnNames()
        {
            // Dictionary to map DbContext column names to desired DataGridView column names
            Dictionary<string, string> columnMappings = new Dictionary<string, string>
            {
                {"Total", "Current Inventory"},
                {"Col1", "Collection 1"},
                {"Col2", "Collection 2"},
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
            if (bindingSource == null)
            {
                bindingSource = new BindingSource();
            }
            dataGridView.DataSource = bindingSource;
            DataGridLoader.LoadBindingTable(refresh);
            bindingSource.DataSource = DataGridLoader.getData();
            Utils.RemoveColumnByName(dataGridView, "ID");
            Utils.RemoveColumnByName(dataGridView,"Grace");
            Utils.RemoveColumnByName(dataGridView, "GraceId");
            ChangeColumnNames();
        }

        private void DataTabPage_Enter(object? sender, EventArgs e)
        {
            filterSkuTextBox.Clear();
            BindDataSource(true);
        }

        private void addRowButton_Click(object? sender, EventArgs e)
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
        private void dataGridView_DataBindingComplete(object? sender,
            DataGridViewBindingCompleteEventArgs e)
        {
            Utils.RemoveColumnByName(dataGridView, "ID");
            Utils.RemoveColumnByName(dataGridView, "Grace");
            Utils.RemoveColumnByName(dataGridView, "GraceId");
        }

        private void dataGridView_CellMouseDoubleClick(object? sender,
            DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
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


        private void clearFilterButton_Click(object? sender, EventArgs e)
        {
            filterSkuTextBox.Clear();
            BindDataSource();
        }

            internal void filterSkuTextBox_TextChanged(object? sender, EventArgs e)
        {
            string searchTerm = filterSkuTextBox.Text;
            bindingSource.DataSource = DataGridLoader.getFilteredData(searchTerm);
            Utils.RemoveColumnByName(dataGridView, "ID");
            Utils.RemoveColumnByName(dataGridView, "Grace");
            Utils.RemoveColumnByName(dataGridView, "GraceId");
        }

        private void DataGridView_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 11) {
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


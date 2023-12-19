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
        private Button addRowButton;
        private DataGridView dataGridView;
        private DataGridLoader dataGridLoader;
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

        }

        internal void Load()
        {
            dataGridView.CellMouseDoubleClick += dataGridView_CellMouseDoubleClick;
            dataGridView.DataBindingComplete += dataGridView_DataBindingComplete;
            addRowButton.Click += addRowButton_Click;
            filterSkuTextBox.TextChanged += filterSkuTextBox_TextChanged;
            bindingSource = new BindingSource();
            dataGridView.DataSource = bindingSource;
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
            {"Col1", "CollectionName 1"},
            {"Col2", "CollectionName 2"},
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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dataGridLoader.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
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


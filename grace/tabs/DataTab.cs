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
#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8602
#pragma warning disable CS8600
        private static TabPage dataTabPage;
        private static Vivian vivian;

        // Data table controls
        private static TextBox filterSkuTextBox;
        private static Button addRowButton;
        private static DataGridView dataGridView;
        private static DataGridLoader dataGridLoader;
        private static BindingSource bindingSource;

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

            dataGridLoader = new DataGridLoader();
            bindingSource.DataSource = dataGridLoader.getData();
            RemoveColumnsByName("ID", "Grace", "GraceId");
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

        internal static void filterSkuTextBox_TextChanged(object sender, EventArgs e)
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

        private static void RemoveColumnsByName(params string[] columnNames)
        {
            foreach (string columnName in columnNames)
            {
                if (dataGridView.Columns.Contains(columnName))
                {
                    dataGridView.Columns.Remove(columnName);
                }
            }
        }

#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602
#pragma warning restore CS8618
#pragma warning restore CS8600
    }
}


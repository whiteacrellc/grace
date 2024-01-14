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
 */
using grace.data;
using grace.data.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grace
{
    public partial class EditRowForm : Form
    {
        DataGridViewRow? row;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private string Sku = string.Empty;
        private string Brand = string.Empty;
        private string Description = string.Empty;
        private List<string> colList = new List<string>();
        private bool newRow;
        private StringBuilder sb = new StringBuilder();
        private bool readyForNewCode = true;
        private GraceRow? graceRow;
        private bool updateGraceRow = false;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EditRowForm(DataGridViewRow? row)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            this.row = row;
            if (row is null)
            {
                newRow = true;
            }
            else
            {
                newRow = false;
            }
        }

        private void EditRowForm_Load(object sender, EventArgs e)
        {

            // We will need this to newRow the database
            if (row != null)
            {
                var sku = row.Cells["Sku"].Value as string;
                graceRow = DataBase.GetGraceRowFromSku(sku);
                if (graceRow == null)
                {
                    MessageBox.Show("There was a problem loading the row.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
            var distinctCollectionNames = new List<string?>();
            using (var context = new GraceDbContext())
            {
                // Fill checkbox list with collection names
                distinctCollectionNames = context.Collections
                    .Select(e => e.Name)
                    .Distinct()
                    .ToList();
            }

            checkedListBox.Items.Clear();
            foreach (var d in distinctCollectionNames)
            {
                if (d != null)
                {
                    colList.Add(d);
                    checkedListBox.Items.Add(d);
                }
            }

            if (row != null && row.Cells.Count > 11)
            {
                if (graceRow != null)
                {
                    skuTextBox.Text = graceRow.Sku;
                    brandTextBox.Text = graceRow.Brand;
                    descTextBox.Text = graceRow.Description;
                    if (graceRow.Availability != null)
                    {
                        availabilityTextBox.Text = graceRow.Availability;
                    }
                    var obj = row.Cells[4].Value;
                    if (obj != null)
                    {
                        barCodeTextBox.Text = obj.ToString();
                    }
                    checkItem(row.Cells[5].Value);
                    checkItem(row.Cells[6].Value);
                    checkItem(row.Cells[7].Value);
                    checkItem(row.Cells[8].Value);
                    checkItem(row.Cells[9].Value);
                    checkItem(row.Cells[10].Value);

                    currentTextBox.Text = row.Cells["Total"].Value.ToString();
                    addTextBox.Text = "0";
                    deleteTextBox.Text = "0";
                }
            }

            if (newRow)
            {
                saveButton.Text = "Add Row";
                deleteButton.Enabled = false;
                deleteButton.Hide();
                adjustInventoryLabel.Hide();
                addTextBox.Hide();
                currentTextBox.ReadOnly = false;
                deleteTextBox.Hide();
                deleteInventoryLabel.Hide();
            }
            else
            {
                saveButton.Text = "Update";
                deleteButton.Enabled = true;
                deleteButton.Show();
                adjustInventoryLabel.Show();
                addTextBox.Show();
                currentTextBox.ReadOnly = true;
            }
        }

        private void checkItem(object var)
        {
            if (var != null)
            {
                if (checkedListBox.Items.Contains((string)var))
                {
                    int i = checkedListBox.Items.IndexOf((string)var);
                    //checkedListBox.SetItemChecked(i, true);
                    checkedListBox.SetItemCheckState(i, CheckState.Checked);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            if (newRow)
            {
                if (addRow())
                {
                    return;
                }
            }
            else
            {
                if (updateRow())
                {
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }
#pragma warning disable CS8602
#pragma warning disable CA1305
        private bool updateRow()
        {
            bool ret = false;
            if (checkFields())
            {
                return true;
            }
            int graceId = 0;
            // Update Graces DB
            using (var context = new GraceDbContext())
            {
                var grace =
                        context.Graces.FirstOrDefault(item => item.Sku == graceRow.Sku);

                if (grace != null)
                {
                    graceId = grace.ID;
                    if (grace.Sku != skuTextBox.Text)
                    {
                        var sku = skuTextBox.Text;
                        if (string.IsNullOrEmpty(sku))
                        {
                            MessageBox.Show("SKU Must have a Value.",
                                "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return true;
                        }
                        grace.Sku = sku.Trim();
                        updateGraceRow = true;
                    }
                    if (grace.Brand != brandTextBox.Text)
                    {
                        var brand = brandTextBox.Text;
                        if (!string.IsNullOrEmpty(brand))
                        {
                            brand = brand.Trim();
                        }
                        grace.Brand = brand;
                        updateGraceRow = true;
                    }
                    if (grace.Description != descTextBox.Text)
                    {
                        var desc = descTextBox.Text;
                        if (!string.IsNullOrEmpty(desc)) { desc = desc.Trim(); }
                        grace.Description = desc;
                        updateGraceRow = true;
                    }
                    if (grace.Availability != availabilityTextBox.Text)
                    {
                        var availability = availabilityTextBox.Text;
                        if (!string.IsNullOrEmpty(availability))
                        {
                            availability = availability.Trim();
                        }
                        grace.Availability = availability;
                        updateGraceRow = true;
                    }
                    if (updateGraceRow)
                    {
                        context.SaveChanges();
                    }
                }
            }

            try
            {
                int delta = 0;

                delta = Convert.ToInt32(addTextBox.Text);

                if (delta == 0)
                {
                    delta = -Convert.ToInt32(deleteTextBox.Text);
                }

                int newTotal = Convert.ToInt32(currentTextBox.Text) + delta;

                if (delta != 0)
                {
                    if (newTotal < 0)
                    {
                        DialogResult result = MessageBox.Show(
                            $"The new CurrentTotal is less than zero {newTotal} " +
                            "are you sure you want to enter this?", "Question",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            return true;
                        }

                    }
                    DataBase.AddTotal(newTotal, graceRow.GraceId);

                    var sku = skuTextBox.Text.Trim();
                    using (var context = new GraceDbContext())
                    {
                        graceRow = context.GraceRows.FirstOrDefault(item => item.Sku == sku);
                        graceRow.Total = newTotal;
                        context.SaveChanges();
                    }
                    updateGraceRow = true;
                }
                if (updateGraceRow)
                {
                    DataBase.UpdateGraceRow(graceId);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ret = true;
            }

            return ret;
        }


        private bool checkFields()
        {
            bool ret = false;

            if (skuTextBox.Text == string.Empty)
            {
                skuTextBox.BackColor = System.Drawing.Color.Yellow;
                ret = true;
            }
            if (brandTextBox.Text == string.Empty)
            {
                brandTextBox.BackColor = System.Drawing.Color.Yellow;
                ret = true;
            }
            if (descTextBox.Text == string.Empty)
            {
                descTextBox.BackColor = System.Drawing.Color.Yellow;
                ret = true;
            }
            if (currentTextBox.Text == string.Empty)
            {
                currentTextBox.BackColor = System.Drawing.Color.Yellow;
                ret = true;
            }
            if (checkedListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("You need to select at least one category.",
                    "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return true;
            }
            return ret;
        }

        private bool addRow()
        {
            bool ret = false;
            if (checkFields())
            {
                return true;
            }

            Grace grace = new Grace();

            int graceId = 0;
            // Update Graces DB
            using (var context = new GraceDbContext())
            {

                grace.Sku = skuTextBox.Text;
                grace.Brand = brandTextBox.Text;
                grace.Description = descTextBox.Text;
                if (availabilityTextBox.Text.Length > 0)
                {
                    grace.Availability = availabilityTextBox.Text;
                }
                else
                {
                    grace.Availability = string.Empty;
                }
                if (barCodeTextBox.Text.Length > 0)
                {
                    grace.BarCode = barCodeTextBox.Text;
                }
                else
                {
                    grace.BarCode = string.Empty;
                }
                context.Graces.Add(grace);
                context.SaveChanges();
                graceId = grace.ID;
            }

            // Add the CurrentTotal from the currentTextBox 
            try
            {
                int newTotal = Convert.ToInt32(currentTextBox.Text);

                if (newTotal < 1)
                {
                    DialogResult result = MessageBox.Show(
                        $"The new CurrentTotal is less than one {newTotal} " +
                        "are you sure you want to enter this?", "Question",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return true;

                    }
                }
                DataBase.AddTotal(newTotal, graceId);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            var selectedList = checkedListBox.SelectedItems.Cast<string>().ToList();
            foreach (var selected in selectedList)
            {
                DataBase.AddCollectionRow(graceId, selected);
            }

            // Now add the grace row. 
            DataBase.CreateGraceRow(graceId);

            return ret;
        }
#pragma warning restore CS8602
#pragma warning restore CA1305

        private void barCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == e.KeyCode)
            {
                if (readyForNewCode)
                {
                    barCodeTextBox.Clear();
                    readyForNewCode = false;
                    sb.Clear();
                }
                TextBox box = (TextBox)sender;
                sb.Append(box.Text);
                //textBoxBarcode.Text = sb.ToString();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                barCodeTextBox.Text = sb.ToString();
                readyForNewCode = true;
                // Process the scanned data as needed (e.g., send it to a database, perform actions)
                // Example: ProcessScannedData(scannedData);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            using (var context = new GraceDbContext())
            {
                var grace = context.Graces.FirstOrDefault(item => item.Sku == graceRow.Sku);
                context.Graces.Remove(grace);
                context.SaveChanges();
            }
            DialogResult = DialogResult.OK;
            Close();
   
        }

        private int GetCollectionId(string collectionName)
        {
            int ret = -1;

            using (var context = new GraceDbContext())
            {
                // LINQ query to get the ID based on the conditions
                var result = context.Collections
                    .Where(c => c.Name == collectionName && c.GraceId == graceRow.GraceId)
                    .Select(c => c.ID)
                    .FirstOrDefault();

                if (result is not 0)
                {
                    ret = result;
                }
            }
            return ret;
        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (newRow)
            {
                return;
            }

            string? itemName = checkedListBox.Items[e.Index].ToString();
            if (itemName != null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    updateGraceRow = DataBase.AddCollectionRow(graceRow.GraceId, itemName);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    updateGraceRow = DataBase.DeleteCollectionRow(graceRow.GraceId, itemName);
                }
            }
        }

        private void deltaTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ensure the entered text is a valid integer
            if (!int.TryParse(addTextBox.Text, out int result))
            {
                // If not a valid integer, clear the TextBox
                addTextBox.Text = "";
            }
        }

    }
}

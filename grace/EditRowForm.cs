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
        private List<string> brandList = new List<string>();
        private List<string> newColList = new List<string>();


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

            var distintBrandNames = new List<string>();
            var distinctCollectionNames = new List<string>();
            using (var context = new GraceDbContext())
            {
                // Fill checkbox list with collection names
                distinctCollectionNames = context.Collections
                    .Where(e => e.Name != "Other")
                    .Select(e => e.Name)
                    .Distinct()
                    .OrderBy(name => name)
                    .ToList();
                // Fill in drop down for brand name
                distintBrandNames = context.Graces
                    .Select(c => c.Brand)
                    .Distinct()
                    .OrderBy(brand => brand)
                    .ToList();
            }

            checkedListBox.Items.Clear();
            foreach (var d in distinctCollectionNames)
            {
                colList.Add(d);
                checkedListBox.Items.Add(d);
            }

            brandComboBox.Items.Clear();
            foreach (var d in distintBrandNames)
            {
                brandComboBox.Items.Add(d);
            }

            if (row != null && row.Cells.Count > 11)
            {
                if (graceRow != null)
                {
                    skuTextBox.Text = graceRow.Sku;
                    brandComboBox.SelectedItem = graceRow.Brand;
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
                    adjustTextBox.Text = "0";
                }
            }

            if (newRow)
            {
                saveButton.Text = "Add Row";
                deleteButton.Enabled = false;
                deleteButton.Hide();
                adjustInventoryLabel.Hide();
                adjustTextBox.Hide();
                currentTextBox.ReadOnly = false;
            }
            else
            {
                saveButton.Text = "Update";
                deleteButton.Enabled = true;
                deleteButton.Show();
                adjustInventoryLabel.Show();
                adjustTextBox.Show();
                adjustTextBox.MouseHover += AddTextBox_MouseHover;
                adjustTextBox.Text = "0";
                currentTextBox.ReadOnly = true;

            }

            // Add help provider stuff
            helpProvider.SetShowHelp(addCollectionLabel, true);
            helpProvider.SetHelpString(addCollectionLabel,
                "Add a new collection and assign it to the current item.");
            helpProvider.SetShowHelp(addCollectionTextBox, true);
            helpProvider.SetHelpString(addCollectionTextBox,
                "Add a new collection and assign it to the current item.");

            toolTip.UseAnimation = true;
        }

        private void AddTextBox_MouseHover(object? sender, EventArgs e)
        {
            // Show the tool tip when the mouse hovers over the TextBox
            toolTip.ToolTipTitle = "Inventory Help";
            toolTip.Show("You can enter negative numbers in this field",
                adjustTextBox, 0, -30, 2000);
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

                if (string.IsNullOrEmpty(addCollectionTextBox.Text) == false)
                {
                    var cname = addCollectionTextBox.Text.Trim();
                    if (DataBase.CheckCollectionExists(cname))
                    {
                        MessageBox.Show("Trying to add a new collection" + cname
                            + " which already exists. Please use the Collections"
                            + " widget above to choose this collection.",
                        "Oh Noes!", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        addCollectionTextBox.Text = string.Empty;
                        return true;
                    }
                    else
                    {
                        // Row does not exist, so insert a new row
                        var newRow = new CollectionName
                        {
                            GraceId = grace.ID,
                            Name = cname
                            // Set other properties as needed
                        };

                        context.Collections.Add(newRow);
                        updateGraceRow = true;
                    }
                }

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
                    // Make sure SKU is not a duplicate
                    bool skuExists = context.Graces.Any(entity => entity.Sku == grace.Sku);
                    if (skuExists)
                    {
                        MessageBox.Show($"SKU {grace.Sku} already exists. Please "
                            + "use update to modify it",
                            "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                        return true;
                    }
                    updateGraceRow = true;
                }
                if (grace.Brand != (string)brandComboBox.SelectedItem)
                {
                    var brand = (string)brandComboBox.SelectedItem;
                    if (!string.IsNullOrEmpty(brand))
                    {
                        brand = brand.Trim();
                        grace.Brand = brand;
                        updateGraceRow = true;
                    }
                    else
                    {
                        MessageBox.Show("You need to select a brand.",
                            "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                        return true;
                    }
                }
                if (grace.Description != descTextBox.Text)
                {
                    var desc = descTextBox.Text;
                    if (!string.IsNullOrEmpty(desc))
                    {
                        desc = desc.Trim();
                        grace.Description = desc;
                        updateGraceRow = true;
                    }
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
                if (grace.BarCode != barCodeTextBox.Text)
                {
                    var barcode = barCodeTextBox.Text;
                    if (!string.IsNullOrEmpty(barcode))
                    {
                        barcode = barcode.Trim();
                    }

                    // Make sure we don't add duplicate barcodes. 
                    bool barcodeExists = context.Graces.Any(entity => entity.BarCode == barcode);
                    if (barcodeExists)
                    {
                        MessageBox.Show($"Bar Code {barcode} already exists. Please "
                            + "check your entry and try again.",
                            "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                        return true;
                    }
                    grace.BarCode = barcode;
                    updateGraceRow = true;
                }

                if (updateGraceRow)
                {
                    context.SaveChanges();
                }
            }

            try
            {
                //int delta = 0;

                if (!int.TryParse(adjustTextBox.Text, out int delta))
                {
                    var str = adjustTextBox.Text;
                    // If not a valid integer, clear the TextBox
                    adjustTextBox.Text = "";
                    MessageBox.Show($"The entry in the Adjust Inventory box {str}"
                        + " is not a valid number", "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return true;
                }

                //delta = Convert.ToInt32(adjustTextBox.Text);

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
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ret = true;
            }

            if (!ret && updateGraceRow)
            {
                DataBase.UpdateGraceRow(graceId);
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
            var brand = (string)brandComboBox.SelectedItem;
            if (!string.IsNullOrEmpty(brand))
            {
                brand = brand.Trim();
            }
            else
            {
                MessageBox.Show("You need to select a brand.",
                    "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                return true;
            }

            bool updateCollection = false;
            if (string.IsNullOrEmpty(addCollectionTextBox.Text) == false)
            {
                var cName = addCollectionTextBox.Text.Trim();
                if (DataBase.CheckCollectionExists(cName))
                {
                    MessageBox.Show("Trying to add a new collection" + cName
                        + " which already exists. Please use the Collections"
                        + " widget above to choose this collection.",
                    "Oh Noes!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    addCollectionTextBox.Text = string.Empty;
                    return true;
                }
                else
                {
                    updateCollection = true;
                }
            }

            using (var context = new GraceDbContext())
            {

                grace.Sku = skuTextBox.Text;

                // Make sure SKU is not a duplicate
                bool skuExists = context.Graces.Any(entity => entity.Sku == grace.Sku);
                if (skuExists)
                {
                    MessageBox.Show($"SKU {grace.Sku} already exists. Please "
                        + "use update to modify it",
                        "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                    return true;
                }

                grace.Brand = brand;
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
                    // Make sure SKU is not a duplicate
                    bool barcodeExists = context.Graces.Any(entity => entity.BarCode == grace.BarCode);
                    if (barcodeExists)
                    {
                        MessageBox.Show($"Bar Code {grace.BarCode} already exists. Please "
                            + "check your entry and try again.",
                            "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                        return true;
                    }
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


            foreach (var selected in newColList)
            {
                DataBase.AddCollectionRow(graceId, selected);
            }

            if (updateCollection)
            {
                var cName = addCollectionTextBox.Text.Trim();
                DataBase.AddCollectionRow(graceId, cName);
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

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            string? itemName = checkedListBox.Items[e.Index].ToString();
            if (itemName != null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (newRow)
                    {
                        if (newColList.Contains(itemName) == false)
                        {
                            newColList.Add(itemName);
                        }
                    }
                    else
                    {
                        updateGraceRow = DataBase.AddCollectionRow(graceRow.GraceId, itemName);

                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    if (newRow)
                    {
                        newColList.Remove(itemName);
                    }
                    else
                    {
                        updateGraceRow = DataBase.DeleteCollectionRow(graceRow.GraceId, itemName);
                    }
                }
                // Make sure the grace row is updated when the save button is
                // hit.
                if (!newRow)
                {
                    updateGraceRow = true;
                }
            }
        }

        private void deltaTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ensure the entered text is a valid integer
            if (!int.TryParse(adjustTextBox.Text, out int result))
            {
                // If not a valid integer, clear the TextBox
                adjustTextBox.Text = "";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void skuTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(skuTextBox.Text))
            {
                return;
            }

            // Convert the text in the TextBox to uppercase
            skuTextBox.Text = skuTextBox.Text.ToUpper(System.Globalization.CultureInfo.CurrentCulture);
            // Set the cursor position at the end of the text
            skuTextBox.SelectionStart = skuTextBox.Text.Length;
        }

        private void textBox1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

        }

        private void label9_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

        }

        private void addCollectionTextBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.ToolTipTitle = "Add Collection";
            toolTip.Show("Add a new collection and assign it to the current item.",
                addCollectionTextBox, 0, -30, 2000);
        }

        private void addCollectionLabel_MouseHover(object sender, EventArgs e)
        {
            // Show help when mouse hovers over the TextBox
            toolTip.ToolTipTitle = "Add Collection";
            toolTip.Show("Add a new collection and assign it to the current item.",
                addCollectionTextBox, 0, -30, 2000);
        }

        private void adjustInventoryLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

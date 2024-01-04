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
        private Dictionary<string, int> collectionHash = new Dictionary<string, int>();
        private string Sku = string.Empty;
        private string Brand = string.Empty;
        private string Description = string.Empty;
        private List<string> colList = new List<string>();
        private bool update;
        private StringBuilder sb = new StringBuilder();
        private bool readyForNewCode = true;
        private GraceRow? graceRow;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EditRowForm(DataGridViewRow? row)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            this.row = row;
            if (row is null)
            {
                update = false;
            } else
            {
                update = true;
            }
        }

        private void EditRowForm_Load(object sender, EventArgs e)
        {
            collectionHash.Clear();

            // We will need this to update the database
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
                    int fk = GetCollectionId(d);
                    if (fk >= 0)
                    {
                        collectionHash.Add(d, fk);
                    }
                }
            }

            if (row != null && row.Cells.Count > 11)
            {
                if (graceRow != null)
                {
                    skuTextBox.Text = graceRow.Sku;
                    skuTextBox.Enabled = false;
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
                    deltalTextBox.Text = "0";
                }
            }

            if (!update)
            {
                saveButton.Text = "Add Row";
                deleteButton.Enabled = false;
                deleteButton.Hide();
                adjustInventoryLabel.Hide();
                deltalTextBox.Hide();
                currentTextBox.ReadOnly = false;
            }
            else
            {
                saveButton.Text = "Update";
                deleteButton.Enabled = true;
                deleteButton.Show();
                adjustInventoryLabel.Show();
                deltalTextBox.Show();
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
                    checkedListBox.SetItemChecked(i, true);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            if (update)
            {
                if (updateRow())
                {
                    return;
                }
            }
            else
            {
                if (addRow())
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

            // Update Graces DB
            using (var context = new GraceDbContext())
            {
                var grace =
                        context.Graces.FirstOrDefault(item => item.Sku == graceRow.Sku);
                bool update = false;

                if (grace != null)
                {
                    if (grace.Sku != skuTextBox.Text)
                    {
                        grace.Sku = skuTextBox.Text;
                        update = true;
                    }
                    if (grace.Brand != brandTextBox.Text)
                    {
                        grace.Brand = brandTextBox.Text;
                        update = true;
                    }
                    if (grace.Description != descTextBox.Text)
                    {
                        grace.Description = descTextBox.Text;
                        update = true;
                    }
                    if (update)
                    {
                        context.SaveChanges();
                    }
                }
            }

            try
            {
                int newTotal = Convert.ToInt32(currentTextBox.Text) +
                    Convert.ToInt32(deltalTextBox.Text);

                if (newTotal < 0)
                {
                    DialogResult result = MessageBox.Show(
                        $"The new total is less than zero {newTotal} " +
                        "are you sure you want to enter this?", "Question",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return true;
                    }

                }
                DataBase.AddTotal(newTotal, graceRow.GraceId);
            } catch (Exception ex)
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
            if (checkedListBox.SelectedItems.Count == 0)
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
                    grace.Barcode = barCodeTextBox.Text;
                }
                else
                {
                    grace.Barcode = string.Empty;
                }
                context.Graces.Add(grace);
                context.SaveChanges();
                graceId = grace.ID;
            }

            // Add the total from the currentTextBox 
            try
            {
                int newTotal = Convert.ToInt32(currentTextBox.Text);

                if (newTotal < 1)
                {
                    DialogResult result = MessageBox.Show(
                        $"The new total is less than one {newTotal} " +
                        "are you sure you want to enter this?", "Question",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return true;
                       
                    }
                    DataBase.AddTotal(newTotal, graceId);
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            for (int i = 0; i < checkedListBox.SelectedItems.Count; i++)
            {
                var name = checkedListBox.SelectedItems[i].ToString();
                int cid = DataBase.AddCollection(name, graceId);
                collectionHash.Add(name, cid);
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

        private void deleteButton_Click(
            object sender, EventArgs e)
        {
            if (update == true && row != null)
            {
                var obj = row.Cells[0].Value;
                if (obj != null)
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string sku = obj.ToString();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    using (var context = new GraceDbContext())
                    {
                        var grace = context.Graces.First(t => t.Sku.Equals(sku,
                            StringComparison.Ordinal));
                        context.Graces.Remove(grace);
                        context.SaveChanges();
                    }
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    DialogResult = DialogResult.None;
                }

            }
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

        private void checkedListBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string? itemName = checkedListBox.Items[e.Index].ToString();
            if (itemName != null)
            {
                int graceId = collectionHash[itemName];
                if (e.NewValue == CheckState.Checked)
                {
                    DataBase.AddCollectionRow(graceId, itemName);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    DataBase.DeleteCollectionRow(graceId, itemName);
                }
            }
        }

        private void deltalTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ensure the entered text is a valid integer
            if (!int.TryParse(deltalTextBox.Text, out int result))
            {
                // If not a valid integer, clear the TextBox
                deltalTextBox.Text = "";
            }
        }
    }
}

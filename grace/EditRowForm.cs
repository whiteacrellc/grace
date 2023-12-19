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
using Microsoft.EntityFrameworkCore;
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

        private DataBase dataBase;
        private GraceDbContext graceDb;
        DataGridViewRow? row;
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
        }

        private void EditRowForm_Load(object sender, EventArgs e)
        {
            collectionHash.Clear();
            dataBase = new DataBase();
            graceDb = dataBase.graceDb;


            // We will need this to update the database
            if (row != null)
            {
                var sku = row.Cells["Sku"].ToString();
                graceRow = dataBase.GetGraceRowFromSku(sku);
                if (graceRow == null)
                {
                    MessageBox.Show("There was a problem loading the row.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }

            var distinctCollectionNames = graceDb.Collections
                .Select(e => e.Name)
                .Distinct()
                .ToList();

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
                update = true;
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
                graceRow = new GraceRow();
            }
            else
            {
                saveButton.Text = "Update";
                deleteButton.Enabled = true;
                deleteButton.Show();
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
            if (!update)
            {
                saveFormToDb();
                DialogResult = DialogResult.OK;
            }
            Close();
        }

        private void saveFormToDb()
        {
            Grace? grace = new Grace();
            if (update && row is not null)
            {
                var sku = row.Cells["Sku"].ToString();
                grace = dataBase.GetGraceFromSku(sku);
            }
            if (grace is not null && graceRow is not null)
            {

                if (update is false) { 
                    graceRow.Sku = skuTextBox.Text;
                    grace.Sku = graceRow.Sku;
                    graceRow.Brand = brandTextBox.Text;
                    grace.Brand = graceRow.Brand;
                    graceRow.Description = descTextBox.Text;
                    if (availabilityTextBox.Text.Length > 0)
                    {
                        graceRow.Availability = availabilityTextBox.Text;
                    }
                    if (barCodeTextBox.Text.Length > 0)
                    {
                        graceRow.BarCode = barCodeTextBox.Text;
                    }
                }
                if (grace.Sku != skuTextBox.Text)
                {
                    grace.Sku = skuTextBox.Text;
                }
                if (grace.Sku != skuTextBox.Text)
                {
                    grace.Sku = skuTextBox.Text;
                }

            }
            try
            {
                int deltaTotal = Int32.Parse(deltalTextBox.Text);
            }
            catch (Exception ex)
            {

            }

            // Save the changes to the database
            graceDb.SaveChanges();

        }

        void AddTotal(int previous_total, int total, int grace_id)
        {
            var newTotal = new Total
            {
                date_field = DateTime.Now,
                total = total,
                GraceId = grace_id
            };
            graceDb.Totals.Add(newTotal);

            newTotal = new Total
            {
                date_field = DateTime.Now.AddDays(-14),
                total = previous_total,
                GraceId = grace_id
            };
            graceDb.Totals.Add(newTotal);
            graceDb.SaveChanges();

        }

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
                    var grace = graceDb.Graces.First(t => t.Sku.Equals(sku));
                    graceDb.Graces.Remove(grace);
                    graceDb.SaveChanges();
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
                    dataBase.AddCollectionRow(graceId, itemName);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    dataBase.DeleteCollectionRow(graceId, itemName);
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

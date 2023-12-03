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
        GraceDbContext graceDb;
        DataGridViewRow? row;
        private string Sku = string.Empty;
        private string Brand = string.Empty;
        private string Description = string.Empty;
        List<string> colList = new List<string>();
        private bool update = false;
        private StringBuilder sb = new StringBuilder();
        private bool readyForNewCode = true;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EditRowForm(DataGridViewRow? row)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            this.row = row;
        }

        private void EditRowForm_Load(object sender, EventArgs e)
        {
            dataBase = new DataBase();
            graceDb = dataBase.graceDb;

            var distinctFooValues = graceDb.Collections
                .Select(e => e.Name)
                .Distinct()
                .ToList();
            foreach (var d in distinctFooValues)
            {
                if (d != null)
                {
                    colList.Add(d);
                    checkedListBox.Items.Add(d);
                }
            }

            if (row != null && row.Cells.Count > 11)
            {
                update = true;
                skuTextBox.Text = row.Cells[0].Value.ToString();
                skuTextBox.Enabled = false;
                brandTextBox.Text = row.Cells[2].Value.ToString();
                descTextBox.Text = row.Cells[1].Value.ToString();
                var obj = row.Cells[3].Value;
                if (obj != null)
                {
                    availabilityTextBox.Text = obj.ToString();
                }
                obj = row.Cells[4].Value;
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

                prevTotTextBox.Text = row.Cells["PreviousTotal"].Value.ToString();
                totalTextBox.Text = row.Cells["Total"].Value.ToString();
            }

            if (!update)
            {
                saveButton.Text = "Add Row";
                deleteButton.Enabled = false;
                deleteButton.Hide();
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
            //graceDb.Dispose();
            //graceDb.Database.OpenConnection();

            var newGrace = new Grace
            {
                Sku = skuTextBox.Text,
                Brand = brandTextBox.Text,
                Description = descTextBox.Text,
            };
            if (availabilityTextBox.Text.Length > 0)
            {
                newGrace.Availability = availabilityTextBox.Text;
            }
            if (barCodeTextBox.Text.Length > 0)
            {
                newGrace.Barcode = barCodeTextBox.Text;
            }

            // Add the new Grace object to the DbContext
            graceDb.Graces.Add(newGrace);


            int insertId = newGrace.ID;

            int total = -1;
            int prevTotal = -1;
            try
            {
                var obj = totalTextBox.Text;
                if (obj == null)
                {
                    totalTextBox.BackColor = System.Drawing.Color.Yellow;
                    return;
                }
                total = Convert.ToInt32(obj);
            } catch
            {
                totalTextBox.BackColor = System.Drawing.Color.Yellow;
            }
            try
            {
                var obj = prevTotTextBox.Text;
                if (obj == null)
                {
                    prevTotTextBox.BackColor = System.Drawing.Color.Yellow;
                    return;
                }
                prevTotal = Convert.ToInt32(obj);
            }
            catch
            {
                totalTextBox.BackColor = System.Drawing.Color.Yellow;
            }

            if (prevTotal >= 0 && total >= 0)
            {
                var totalrow = new Total
                {
                    total = prevTotal,
                    date_field = DateTime.Now.AddDays(-14),
                    GraceId = insertId
                };
                graceDb.Totals.Add(totalrow);
                totalrow = new Total
                {
                    total = total,
                    date_field = DateTime.Now,
                    GraceId = insertId
                };
                graceDb.Totals.Add(totalrow);
            }


            var selectedList = checkedListBox.SelectedItems;
            foreach (var item in selectedList)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string val = item.ToString();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                var collection = new Collection
                {
                    Name = val,
                    GraceId = insertId
                };
                graceDb.Collections.Add(collection);
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

        private void deleteButton_Click(object sender, EventArgs e)
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
    }
}

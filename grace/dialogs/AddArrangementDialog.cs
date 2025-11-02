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
 * Year: 2025
 */

using grace.data.models;
using grace.data;
using Microsoft.EntityFrameworkCore;

namespace grace.dialogs
{
    public partial class AddArrangementDialog : Form
    {
        public AddArrangementDialog()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var collectionName = collectionDropDown.SelectedItem?.ToString();
            if (collectionName == null)
            {
                MessageBox.Show("You must select a collection.",
                    "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            var arrangementName = nameTextBox.Text;
            if (string.IsNullOrWhiteSpace(arrangementName))
            {
                MessageBox.Show("You must enter an arrangement name.",
                    "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            if (int.TryParse(initialAmountTextBox.Text, out int initialAmount))
            {
                InsertRow(arrangementName, collectionName, initialAmount);
            }
            else
            {
                MessageBox.Show("Initial Amount must be a valid integer.",
                    "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void AddArrangementDialog_Load(object sender, EventArgs e)
        {
            List<string> collectionNames = DataBase.GetCollections();
            collectionDropDown.Items.Clear();
            foreach (string d in collectionNames)
            {
                collectionDropDown.Items.Add(d);
            }
            if (collectionDropDown.Items.Count > 0)
            {
                collectionDropDown.SelectedIndex = 0;
            }

        }

        private void InsertRow(string name, string collectionName, int initialValue)
        {
            using GraceDbContext context = new();
            try
            {
                // Create a new Grace object to insert
                Arrangement arrangement = new()
                {
                    Name = name.Trim(),
                    CollectionName = collectionName.Trim(),
                };

                // Add the new Grace object to the DbContext
                context.Arrangement.Add(arrangement);

                // Save the changes to the database
                context.SaveChanges();

                int insertId = arrangement.ID;
                ArrangementTotal arrangementTotal = new()
                {
                    ArrangementId = insertId,
                    CurrentTotal = initialValue,
                };
                context.ArrangementTotals.Add(arrangementTotal);
                context.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Error adding arrangement: " + ex.Message,
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void InitialAmountTextBox_KeyPressHandler(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // If the key is anything else, set e.Handled to true.
                // This prevents the character from appearing in the TextBox.
                e.Handled = true;
            }
        }
    }
}

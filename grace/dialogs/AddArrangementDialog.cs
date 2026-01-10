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
        string currentUser = Globals.GetInstance().CurrentUser;
        private List<string> collectionNames = [];

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
            string arrangementName = nameTextBox.Text;
            if (string.IsNullOrWhiteSpace(arrangementName))
            {
                MessageBox.Show("You must enter an arrangement name.",
                    "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                foreach (string collectionName in collectionNames)
                {
                    InsertRow(arrangementName, collectionName);
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Attempted to add duplicate arrangement name",
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void AddArrangementDialog_Load(object sender, EventArgs e)
        {

            collectionNames = DataBase.GetCollections();
            progressBar.Maximum = collectionNames.Count;
            progressBar.Value = 0;
            progressBar.Step = 1;
        }

        void InsertRow(string name, string collectionName)
        {
            using GraceDbContext context = new();

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
                CurrentTotal = 0,
                User = currentUser,
            };
            context.ArrangementTotals.Add(arrangementTotal);
            context.SaveChanges();

            progressBar.PerformStep();

            // Sleep so people see the progress
            Thread.Sleep(100);


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

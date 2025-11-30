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

using grace.data;
using Microsoft.EntityFrameworkCore;

namespace grace.dialogs
{
    public partial class RenameArrangementDialog : Form
    {
        private readonly string oldName;

        public RenameArrangementDialog(string currentName)
        {
            InitializeComponent();
            oldName = currentName;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string newName = newNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("You must enter a new arrangement name.",
                    "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (newName.Trim() == oldName.Trim())
            {
                MessageBox.Show("The new name must be different from the current name.",
                    "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                DataBase.RenameArrangement(oldName, newName.Trim());
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Error renaming arrangement. The new name may already exist.",
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error renaming arrangement: {ex.Message}",
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void RenameArrangementDialog_Load(object sender, EventArgs e)
        {
            currentNameLabel.Text = $"Current Name: {oldName}";
        }
    }
}

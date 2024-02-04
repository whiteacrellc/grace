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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grace
{
    public partial class SettingsForm : Form
    {
        private Globals globals = Globals.GetInstance();
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Load the current setting into the form control
            textBoxRowsPerPage.Text = globals.RowsPerPage.ToString();
            rowHeighrTextBox.Text = globals.RowHeight.ToString();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Close the dialog without saving changes
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private int parseeTextBox(TextBox textBox)

        {
            int result = -1;
            if (int.TryParse(textBox.Text, out int boxValue))
            {
                // Update the setting value
                result = boxValue;
            }
            return result;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Parse the user input and newRow the setting
            int rowHeight = parseeTextBox(textBoxRowsPerPage);
            if (rowHeight > 0)
            {
                globals.RowsPerPage = rowHeight;
            }
            int rowsPerPage = parseeTextBox(rowHeighrTextBox);
            if (rowHeight > 0)
            {
                globals.RowHeight = rowHeight;
                // Save the settings
                Properties.Settings.Default.Save();
            }

            // Close the dialog with DialogResult.OK
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ValidateNumber_Callback(object sender, KeyPressEventArgs e)
        {
            // Allow digits (0-9) and control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the keypress if the entered character is not a digit or control key
                e.Handled = true;
            }
        }
    }
}

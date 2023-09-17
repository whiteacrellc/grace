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
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Load the current setting into the form control
            textBoxRowsPerPage.Text = Properties.Settings.Default.rowsperpage.ToString();
            rowHeighrTextBox.Text = Properties.Settings.Default.rowheight.ToString();
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
            // Parse the user input and update the setting
            int rowHeight = parseeTextBox(textBoxRowsPerPage);
            if (rowHeight > 0)
            {
                Properties.Settings.Default.rowsperpage = rowHeight;
                // Save the settings
                Properties.Settings.Default.Save();
            }
            int rowsPerPage = parseeTextBox(rowHeighrTextBox);
            if (rowHeight > 0)
            {
                Properties.Settings.Default.rowheight = rowHeight;
                // Save the settings
                Properties.Settings.Default.Save();
            }

            // Close the dialog with DialogResult.OK
            DialogResult = DialogResult.OK;
            Close();
        }

        private void rowHeighrTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxRowsPerPage_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(textBoxRowsPerPage.Text, out _))
            {
                MessageBox.Show("Invalid input. Please enter a valid integer.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Prevent the control from losing focus
            }
        }

        private void rowHeighrTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(textBoxRowsPerPage.Text, out _))
            {
                MessageBox.Show("Invalid input. Please enter a valid integer.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Prevent the control from losing focus
            }
        }
    }
}

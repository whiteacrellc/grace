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
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Close the dialog without saving changes
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Parse the user input and update the setting
            if (int.TryParse(textBoxRowsPerPage.Text, out int rowsPerPage))
            {
                // Update the setting value
                Properties.Settings.Default.rowsperpage = rowsPerPage;

                // Save the settings
                Properties.Settings.Default.Save();

                // Close the dialog with DialogResult.OK
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                // Display an error message if the input is not a valid integer
                MessageBox.Show("Invalid input. Please enter a valid integer.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

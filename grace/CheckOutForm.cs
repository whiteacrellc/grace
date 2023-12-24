using grace.data;
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
    public partial class CheckOutForm : Form
    {
        private string sku;

        public CheckOutForm(string sku)
        {
            InitializeComponent();
            this.sku = sku;
        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            numCheckOutTextBox.Text = "0";
            using (var context = new GraceDbContext())
            {
                int fk_key = 0;
                // Fetch data from the DbContext
                var graceRowsData =
                    context.GraceRows.FirstOrDefault(item => item.Sku == sku);
                if (graceRowsData != null)
                {
                    skuLabel.Text = graceRowsData.Sku;
                    brandLabel.Text = graceRowsData.Brand;
                    descriptionLabel.Text = graceRowsData.Description;
                    totalLabel.Text = graceRowsData.Total.ToString();
                    fk_key = graceRowsData.GraceId;
                }
                else
                {
                    MessageBox.Show("There was a problem",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Abort;
                    this.Close();
                }
                var collections =
                    context.Collections.Where(item => item.ID == fk_key).ToList();
                if (collections.Any())
                {
                    collectionComboBox.Items.Clear();
                    // Use the retrieved rows (collections) as needed
                    foreach (var collection in collections)
                    {
                        collectionComboBox.Items.Add(collection);
                    }
                    if (collectionComboBox.Items.Count > 0)
                    {
                        collectionComboBox.SelectedIndex = 0;
                    }
                }
            }
        }

        // Only allow positive integers in the text box
        private void numCheckOutTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits (0-9) and control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the keypress if the entered character is not a digit or control key
                e.Handled = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string username = Globals.GetInstance().CurrentUser;
            if (string.IsNullOrEmpty(username))
            {
                DialogResult = DialogResult.Abort;
                Close();
            }



        }
    }
}

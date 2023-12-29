using grace.data;
using grace.data.models;
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
        private int currentTotal = 0;
        private int graceId = 0;
        private Dictionary<string, int> collectionHash = new Dictionary<string, int>();

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
                // Fetch data from the DbContext
                var graceRowsData =
                    context.GraceRows.FirstOrDefault(item => item.Sku == sku);
                if (graceRowsData != null)
                {
                    skuLabel.Text = graceRowsData.Sku;
                    brandLabel.Text = graceRowsData.Brand;
                    descriptionLabel.Text = graceRowsData.Description;
                    totalLabel.Text = graceRowsData.Total.ToString();
                    currentTotal = graceRowsData.Total;
                    graceId = graceRowsData.GraceId;
                }
                else
                {
                    MessageBox.Show("There was a problem",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Abort;
                    this.Close();
                }
                var collections =
                    context.Collections.Where(item => item.ID == graceId).ToList();
                if (collections.Any())
                {
                    collectionComboBox.Items.Clear();
                    // Use the retrieved rows (collections) as needed
                    foreach (var collection in collections)
                    {
                        collectionComboBox.Items.Add(collection.Name);
                        collectionHash.Add(collection.Name, collection.ID);
                    }
                    collectionComboBox.Items.Add("Other");
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

            var commentText = commentBox.Text;
            var collectionName = collectionComboBox.SelectedIndex;
            if (collectionName > 0)
            {
                MessageBox.Show("You must choose a collection. If this isn't " +
                    "for a collection please choose Other",
                    "Information", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);

                collectionComboBox.BackColor = System.Drawing.Color.Yellow;
                return;
            }

            if (numCheckOutTextBox.Text is null)
            {
                MessageBox.Show("You must enter a number to check out.",
                    "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                numCheckOutTextBox.BackColor = System.Drawing.Color.Yellow;
                return;
            }

            int checkoutTotal = Convert.ToInt32(numCheckOutTextBox.Text);
            int newTotal = currentTotal - checkoutTotal;
            if (newTotal < 0)
            {
                DialogResult dialogResult = MessageBox.Show($"The new total {newTotal} "
                    + "is less than zero. Do you want to proceed?",
                    "Confirmation", MessageBoxButtons.YesNo);

                // Check the user's choice
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

            }

            // Get fkeys for PulledDB 
            var user_id = DataBase.GetUserIdFromName(username);
            var col_id = collectionHash[collectionComboBox.SelectedItem.ToString()];

            using (var context = new GraceDbContext())
            {
                // Add to pulled table
                Pulled pulled = new Pulled
                {

                    UserId = user_id,
                    GraceId = graceId,
                    CollectionId = col_id,
                    Amount = checkoutTotal,
                    CurrentTotal = newTotal,
                };
                if (commentBox.Text is not null)
                {
                    pulled.Comment = commentBox.Text;
                }
                context.PulledDb.Add(pulled);

                // Add Totals in total db
                Total total = new Total
                {
                    date_field = DateTime.Now,
                    GraceId = graceId,
                    total = newTotal
                };
                context.Totals.Add(total);
                context.SaveChanges();
            }
            // update the GraceRow
            DataBase.UpdateGraceRowTotal(graceId, newTotal);
        }

        private void label6_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            ToolTip myToolTip = new ToolTip();
            myToolTip.SetToolTip((Control)sender,
                "If you are not working on a collection please choose Other.");

            // You can customize the tooltip properties here if needed
            // For example:
            // myToolTip.BackColor = System.Drawing.Color.Yellow;
            // myToolTip.ForeColor = System.Drawing.Color.Blue;
            // myToolTip.InitialDelay = 500; // milliseconds

        }
    }
}

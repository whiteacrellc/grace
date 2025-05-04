using grace.data;
using grace.data.models;
using NLog;
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
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public CheckOutForm(string sku)
        {
            InitializeComponent();
            this.sku = sku;
        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            numCheckOutTextBox.Text = "0";
            using GraceDbContext context = new();
            // Fetch data from the DbContext
            Grace? graceData =
                context.Graces.FirstOrDefault(item => item.Sku == sku);
            if (graceData != null)
            {
                skuLabel.Text = graceData.Sku;
                brandLabel.Text = graceData.Brand;
                descriptionLabel.Text = graceData.Description;
                graceId = graceData.ID;

                Total? total = context.Totals
                    .Where(t => t.GraceId == graceData.ID)
                    .OrderByDescending(t => t.ID)
                    .FirstOrDefault();
                if (total != null)
                {
                    currentTotal = total.CurrentTotal;
                    totalLabel.Text = total.CurrentTotal.ToString();
                }
                else
                {
                    MessageBox.Show("There was a problem getting the current total",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("There was a problem",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
                this.Close();
            }
            List<CollectionName> collections =
                context.Collections.Where(item => item.GraceId == graceId
                && item.Name != "Other").OrderBy(item => item.Name).ToList();
            if (collections.Any())
            {
                collectionComboBox.Items.Clear();
                // Use the retrieved rows (collections) as needed
                foreach (CollectionName? collection in collections)
                {
                    collectionComboBox.Items.Add(collection.Name);
                }
                collectionComboBox.Items.Add("Other");
                if (collectionComboBox.Items.Count > 0)
                {
                    collectionComboBox.SelectedIndex = 0;
                }
            }
        }

        // Only allow positive integers in the text box
        private void NumCheckOutTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits (0-9) and control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the keypress if the entered character is not a digit or control key
                e.Handled = true;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string username = Globals.GetInstance().CurrentUser;
                if (string.IsNullOrEmpty(username))
                {
                    DialogResult = DialogResult.Abort;
                    Close();
                }

                string commentText = commentBox.Text;

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
                    DialogResult dialogResult = MessageBox.Show($"The new CurrentTotal {newTotal} "
                        + "is less than zero. Do you want to proceed?",
                        "Confirmation", MessageBoxButtons.YesNo);

                    // Check the user's choice
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }

                }

                // Get fkeys for PulledDB 
                int user_id = DataBase.GetUserIdFromName(username);
                string? collectionName = collectionComboBox.SelectedItem as string;
                int col_id = DataBase.GetCollectionId(graceId, collectionName);

                using GraceDbContext context = new();
                // Add to pulled table
                Pulled pulled = new()
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
                context.SaveChanges();

                DataBase.AddTotal(newTotal, graceId);
                // newRow the GraceRow
                // DataBase.UpdateGraceRow(graceId);
            }
            catch (Exception ex)
            {
                var exString = ex.ToString();
                MessageBox.Show(this, $"Error Loading file {exString}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.TryAgain;
                Close();
            }

            DialogResult = DialogResult.OK;
            Close();
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

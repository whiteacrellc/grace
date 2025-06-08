using grace.data;
using grace.data.models;
using NLog;

namespace grace
{

    public partial class CheckInDialog : Form
    {
        private DataGridViewRow row;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public CheckInDialog(DataGridViewRow row)
        {
            this.row = row;
            InitializeComponent();
        }

        private void CheckInDialog_Load(object sender, EventArgs e)
        {

            // Set labels
            skuLabel.Text = row.Cells["Sku"].Value.ToString();
            descriptionLabel.Text = row.Cells["Description"].Value.ToString();
            brandLabel.Text = row.Cells["Brand"].Value.ToString();
            // Put total in text box
            userTotalTextBox.Text = row.Cells["UserTotal"].Value.ToString();
            // create combo box with collection names
            List<string> collections = DataBase.GetCollections();
            foreach (var collection in collections)
            {
                collectionComboBox.Items.Add(collection);
            }
            // make the current collection selected
            collectionComboBox.Text = row.Cells["Collection"].Value.ToString();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string col = collectionComboBox.Text;
                string? rowCol = row.Cells["Collection"].Value.ToString();
                int newTotal = int.Parse(userTotalTextBox.Text);
                int originalTotal = int.Parse(row.Cells["UserTotal"].Value.ToString());
                string? user = row.Cells["UserName"].Value.ToString();
                int graceId = int.Parse(row.Cells["GraceId"].Value.ToString());

                // nothing has changed so bail
                if (col.Equals(rowCol) && newTotal == originalTotal)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {

                    CollectionName? newCollection = DataBase.getCollection(col.Trim(), graceId);
                    int newCollectionId = 0;
                    if (newCollection == null)
                    {
                        newCollectionId = DataBase.AddCollection(col.Trim(), graceId);
                    }
                    else
                    {
                        newCollectionId = newCollection.ID;
                    }
                    CollectionName? originalCollection = DataBase.getCollection(rowCol.Trim(), graceId);
                    int userId = DataBase.GetUserIdFromName(user);


                    String currentUser = Globals.GetInstance().CurrentUser;
                    using (GraceDbContext context = new())
                    {


                        Pulled? pulled =
                        context.PulledDb.FirstOrDefault(e =>
                            e.Amount == originalTotal
                            && e.CollectionId == originalCollection.ID
                            && e.UserId == userId
                            && e.GraceId == graceId
                            && !e.IsCompleted);
                        if (pulled == null)
                        {
                            DialogResult = DialogResult.No;
                            Close();
                            return;
                        }

                        int updateDelta = pulled.Amount - newTotal;
                        int newCurrentTotal = pulled.CurrentTotal += updateDelta;
                        if (updateDelta != 0)
                        {

                            pulled.Amount = newTotal;
                            pulled.CurrentTotal += updateDelta;


                            Total total = new()
                            {
                                LastUpdated = DateTime.Now,
                                GraceId = graceId,
                                CurrentTotal = newCurrentTotal,
                                User = currentUser,
                            };
                            context.Totals.Add(total);

                        }
                        if (newCollectionId != originalCollection.ID)
                        {
                            pulled.CollectionId = newCollectionId;
                        }
                        context.PulledDb.Update(pulled);
                        context.SaveChanges();

                        // Now we need to update the new 

                        DialogResult = DialogResult.OK;

                    }

                    // newRow the GraceRow
                    DataBase.UpdateGraceRow(graceId);

                }
            }
            catch (Exception ex)
            {
                var exString = ex.ToString();
                MessageBox.Show(this, $"Error Loading file {exString}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.No;
            }
            Close();
            return;
        }
    }
}

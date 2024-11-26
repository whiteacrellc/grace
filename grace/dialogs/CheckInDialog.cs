﻿using grace.data;
using grace.data.models;
using Microsoft.Extensions.Logging;
using Microsoft.Office.Interop.Excel;
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
using System.Xml.Linq;
using static grace.DataBase;

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

        private void label1_Click(object sender, EventArgs e)
        {

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
            var collections = DataBase.GetCollections();
            var selectedCollection = row.Cells["Collection"].Value.ToString();
            foreach (var collection in collections)
            {
                collectionComboBox.Items.Add(collection);
            }
            // make the current collection selected
            collectionComboBox.Text = row.Cells["Collection"].Value.ToString();
        }

        private DateTime? ConvertBackToUTC(string ft)
        {
            DateTime ftDateTime;
            if (DateTime.TryParseExact(ft, "M/d/yyyy h:mm:ss tt", null, System.Globalization.DateTimeStyles.None, out ftDateTime))
            {
                // Assuming systemTimeZone is your target time zone
                TimeZoneInfo systemTimeZone = TimeZoneInfo.Local; // Example: Local time zone

                // Convert the local time to UTC
                DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(ftDateTime, systemTimeZone);

                // Now, utcTime contains the UTC equivalent of ftDateTime
                logger.Info("UTC Time: " + utcTime.ToString("dd/MM/yyyy HH:mm"));
            }
            else
            {
               logger.Info("Invalid date format " + ft);
                return null;
            }
            return ftDateTime;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var col = collectionComboBox.Text;
                var rowCol = row.Cells["Collection"].Value.ToString();
                var newTotal = int.Parse(userTotalTextBox.Text);
                var originalTotal = int.Parse(row.Cells["UserTotal"].Value.ToString());
                var user = row.Cells["UserName"].Value.ToString();
                var graceId = int.Parse(row.Cells["GraceId"].Value.ToString());

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



                    using (var context = new GraceDbContext())
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
                                CurrentTotal = newCurrentTotal
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

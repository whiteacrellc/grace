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
using grace.data;
using grace.data.models;
using NLog;
using System.Data;


namespace grace
{
    public partial class EditRowForm : Form
    {
        private readonly DataGridViewRow? row;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly bool newRow = false;
        private GraceRow? graceRow;
        private bool updateGraceRow = false;
        private List<string> newColList = [];
        private bool isReport = false;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EditRowForm(DataGridViewRow? row)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();

            this.row = row;
            this.newRow = row is null;
        }

        private void EditRowForm_Load(object sender, EventArgs e)
        {
            List<string> colList = [];
            // We will need this to newCol the database
            if (row != null)
            {
                string? sku = row.Cells["Sku"].Value as string;
                graceRow = DataBase.GetGraceRowFromSku(sku);
                if (graceRow == null)
                {
                    MessageBox.Show("There was a problem loading the row.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }

            List<string> distinctBrandNames = DataBase.GetBrandNames();
            List<string> distinctCollectionNames = DataBase.GetCollections();
   
            checkedListBox.Items.Clear();
            foreach (string d in distinctCollectionNames)
            {
                colList.Add(d);
                checkedListBox.Items.Add(d);
            }

            brandComboBox.Items.Clear();
            foreach (string d in distinctBrandNames)
            {
                brandComboBox.Items.Add(d);
            }

            if (row != null && graceRow != null)
            {
                if (row.Cells.Count > 11)
                {
                    skuTextBox.Text = graceRow.Sku;
                    brandComboBox.SelectedItem = graceRow.Brand;
                    descTextBox.Text = graceRow.Description;
                    if (graceRow.Note != null)
                    {
                        noteTextBox.Text = graceRow.Note;
                    }
                    if (graceRow.Availability != null)
                    {
                        availabilityTextBox.Text = graceRow.Availability;
                    }
                    object obj = row.Cells[4].Value;
                    if (obj != null)
                    {
                        barCodeTextBox.Text = obj.ToString();
                    }
                    CheckItem(row.Cells[5].Value);
                    CheckItem(row.Cells[6].Value);
                    CheckItem(row.Cells[7].Value);
                    CheckItem(row.Cells[8].Value);
                    CheckItem(row.Cells[9].Value);
                    CheckItem(row.Cells[10].Value);

                    currentTextBox.Text = row.Cells["Total"].Value.ToString();
                    adjustTextBox.Text = "0";
                }
                else
                {
                    isReport = true;
                    skuTextBox.Text = graceRow.Sku;
                    brandComboBox.SelectedItem = graceRow.Brand;
                    descTextBox.Text = graceRow.Description;
                    if (graceRow.Note != null)
                    {
                        noteTextBox.Text = graceRow.Note;
                    }
                    if (graceRow.Availability != null)
                    {
                        availabilityTextBox.Text = graceRow.Availability;
                    }
                    currentTextBox.Text = row.Cells["Total"].Value.ToString();
                    adjustTextBox.Text = "0";
                    noteTextBox.Text = row.Cells["Note"].Value.ToString();
                    addCollectionLabel.Hide();
                    addCollectionTextBox.Hide();
                    checkedListBox.Hide();
                    collectionLabel.Hide();
                }
            }

            if (newRow)
            {
                saveButton.Text = "Add Row";
                deleteButton.Enabled = false;
                deleteButton.Hide();
                adjustInventoryLabel.Hide();
                adjustTextBox.Hide();
                currentTextBox.ReadOnly = false;
            }
            else
            {
                saveButton.Text = "Update";
                deleteButton.Enabled = true;
                deleteButton.Show();
                adjustInventoryLabel.Show();
                adjustTextBox.Show();
                adjustTextBox.MouseHover += AddTextBox_MouseHover;
                adjustTextBox.Text = "0";
                currentTextBox.ReadOnly = true;

            }

            // Add help provider stuff
            helpProvider.SetShowHelp(addCollectionLabel, true);
            helpProvider.SetHelpString(addCollectionLabel,
                "Add a new collection and assign it to the current item.");
            helpProvider.SetShowHelp(addCollectionTextBox, true);
            helpProvider.SetHelpString(addCollectionTextBox,
                "Add a new collection and assign it to the current item.");

            // Set cursor to help cursor for addCollectionLabel to indicate tooltip
            addCollectionLabel.Cursor = Cursors.Help;

            // Wire up the TextChanged event handler for addCollectionTextBox
            addCollectionTextBox.TextChanged += addCollectionTextBox_TextChanged;

            toolTip.UseAnimation = true;
        }

        private void AddTextBox_MouseHover(object? sender, EventArgs e)
        {
            // Show the tool tip when the mouse hovers over the TextBox
            toolTip.ToolTipTitle = "Inventory Help";
            toolTip.Show("You can enter negative numbers in this field",
                adjustInventoryLabel, 0, -30, 2000);
        }

        private void CheckItem(object var)
        {
            if (var == null || var == DBNull.Value)
            {
                return;
            }
            if (checkedListBox.Items.Contains((string)var))
            {
                int i = checkedListBox.Items.IndexOf((string)var);
                //checkedListBox.SetItemChecked(i, true);
                checkedListBox.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (newRow)
            {
                if (AddRow())
                {
                    return;
                }
            }
            else
            {
                if (UpdateRow())
                {
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }
#pragma warning disable CS8602
#pragma warning disable CA1305
        private bool UpdateRow()
        {
            bool ret = false;
            if (CheckFields(isReport))
            {
                return true;
            }
            int graceId = 0;
            // Update Graces DB
            using (GraceDbContext context = new())
            {
                Grace? grace =
                        context.Graces.FirstOrDefault(item => item.Sku == graceRow.Sku);

                // Reports don't have collection info
                if (!isReport)
                {
                    if (!string.IsNullOrEmpty(addCollectionTextBox.Text))
                    {
                        string cname = addCollectionTextBox.Text.Trim();
                        if (DataBase.CheckCollectionExists(cname))
                        {
                            MessageBox.Show("Trying to add a new collection" + cname
                                + " which already exists. Please use the Collections"
                                + " widget above to choose this collection.",
                            "Oh Noes!", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                            addCollectionTextBox.Text = string.Empty;
                            return true;
                        }
                        else
                        {
                            // Row does not exist, so insert a new row
                            CollectionName newCol = new()
                            {
                                GraceId = grace.ID,
                                Name = cname
                                // Set other properties as needed
                            };

                            context.Collections.Add(newCol);
                            updateGraceRow = true;
                            Globals.GetInstance().CollectionDirty = true;
                        }
                    }
                }

                graceId = grace.ID;
                if (grace.Sku != skuTextBox.Text)
                {
                    string sku = skuTextBox.Text;
                    if (string.IsNullOrEmpty(sku))
                    {
                        MessageBox.Show("SKU Must have a Value.",
                            "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return true;
                    }
                    grace.Sku = sku.Trim();
                    // Make sure SKU is not a duplicate
                    bool skuExists = context.Graces.Any(entity => entity.Sku == grace.Sku);
                    if (skuExists)
                    {
                        MessageBox.Show($"SKU {grace.Sku} already exists. Please "
                            + "use update to modify it",
                            "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                        return true;
                    }
                    updateGraceRow = true;
                }
                if (grace.Brand != (string)brandComboBox.SelectedItem)
                {
                    string? brand = (string)brandComboBox.SelectedItem;
                    if (!string.IsNullOrEmpty(brand))
                    {
                        brand = brand.Trim();
                        grace.Brand = brand;
                        updateGraceRow = true;
                    }
                    else
                    {
                        MessageBox.Show("You need to select a brand.",
                            "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                        return true;
                    }
                }
                if (grace.Description != descTextBox.Text)
                {
                    string desc = descTextBox.Text;
                    if (!string.IsNullOrEmpty(desc))
                    {
                        desc = desc.Trim();
                        grace.Description = desc;
                        updateGraceRow = true;
                    }
                }
                if (grace.Availability != availabilityTextBox.Text)
                {
                    var availability = availabilityTextBox.Text;
                    if (!string.IsNullOrEmpty(availability))
                    {
                        availability = availability.Trim();
                    }
                    grace.Availability = availability;
                    updateGraceRow = true;
                }
                if (!isReport)
                {
                    if (grace.BarCode != barCodeTextBox.Text)
                    {
                        var barcode = barCodeTextBox.Text;
                        if (!string.IsNullOrEmpty(barcode))
                        {
                            barcode = barcode.Trim();
                        }

                        // Make sure we don't add duplicate barcodes. 
                        bool barcodeExists = context.Graces.Any(entity => entity.BarCode == barcode);
                        if (barcodeExists)
                        {
                            MessageBox.Show($"Bar Code {barcode} already exists. Please "
                                + "check your entry and try again.",
                                "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                            return true;
                        }
                        grace.BarCode = barcode;
                        updateGraceRow = true;
                    }
                }
                if (grace.Note != noteTextBox.Text)
                {
                    if (string.IsNullOrEmpty(noteTextBox.Text))
                    {
                        grace.Note = noteTextBox.Text.Trim();
                        grace.Note = string.Empty;
                    }
                    else
                    {
                        grace.Note = noteTextBox.Text.Trim();
                    }
                    updateGraceRow = true;
                }
                if (updateGraceRow)
                {
                    context.SaveChanges();
                }
            }

            try
            {
                //int delta = 0;

                if (!int.TryParse(adjustTextBox.Text, out int delta))
                {
                    var str = adjustTextBox.Text;
                    // If not a valid integer, clear the TextBox
                    adjustTextBox.Text = "";
                    MessageBox.Show($"The entry in the Adjust Inventory box {str}"
                        + " is not a valid number", "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return true;
                }

                //delta = Convert.ToInt32(adjustTextBox.Text);

                int newTotal = Convert.ToInt32(currentTextBox.Text) + delta;

                if (delta != 0)
                {
                    if (newTotal < 0)
                    {
                        DialogResult result = MessageBox.Show(
                            $"The new CurrentTotal is less than zero {newTotal} " +
                            "are you sure you want to enter this?", "Question",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            return true;
                        }

                    }
                    DataBase.AddTotal(newTotal, graceRow.GraceId);

                    string sku = skuTextBox.Text.Trim();
                    using (GraceDbContext context = new())
                    {
                        graceRow = context.GraceRows.FirstOrDefault(item => item.Sku == sku);
                        graceRow.Total = newTotal;
                        graceRow.PrevTotal = Convert.ToInt32(currentTextBox.Text);
                        context.SaveChanges();
                    }
                    updateGraceRow = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ret = true;
            }

            if (!ret && updateGraceRow)
            {
                DataBase.UpdateGraceRow(graceId);
            }

            return ret;
        }


        private bool CheckFields(bool skipCollectionCheck = false)
        {
            bool ret = false;

            if (skuTextBox.Text == string.Empty)
            {
                skuTextBox.BackColor = System.Drawing.Color.Yellow;
                ret = true;
            }
            if (descTextBox.Text == string.Empty)
            {
                descTextBox.BackColor = System.Drawing.Color.Yellow;
                ret = true;
            }
            if (currentTextBox.Text == string.Empty)
            {
                currentTextBox.BackColor = System.Drawing.Color.Yellow;
                ret = true;
            }
            if (!skipCollectionCheck)
            {
                if (checkedListBox.CheckedItems.Count == 0 &&
                    string.IsNullOrEmpty(addCollectionTextBox.Text))
                {
                    MessageBox.Show("You need to select at least one category," +
                        "Or enter a new one. ",
                        "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return true;
                }
            }
            return ret;
        }

        private bool AddRow()
        {
            bool ret = false;
            if (CheckFields())
            {
                return true;
            }

            Grace grace = new();

            int graceId = 0;
            // Update Graces DB
            string? brand = (string)brandComboBox.SelectedItem;
            if (!string.IsNullOrEmpty(brand))
            {
                brand = brand.Trim();
            }
            else
            {
                MessageBox.Show("You need to select a brand.",
                    "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                return true;
            }

            bool updateCollection = false;
            if (!string.IsNullOrEmpty(addCollectionTextBox.Text))
            {
                string cName = addCollectionTextBox.Text.Trim();
                if (DataBase.CheckCollectionExists(cName))
                {
                    MessageBox.Show("Trying to add a new collection" + cName
                        + " which already exists. Please use the Collections"
                        + " widget above to choose this collection.",
                    "Oh Noes!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    addCollectionTextBox.Text = string.Empty;
                    return true;
                }
                else
                {
                    updateCollection = true;
                }
            }

            using (GraceDbContext context = new())
            {

                grace.Sku = skuTextBox.Text;

                // Make sure SKU is not a duplicate
                bool skuExists = context.Graces.Any(entity => entity.Sku == grace.Sku);
                if (skuExists)
                {
                    MessageBox.Show($"SKU {grace.Sku} already exists. Please "
                        + "use update to modify it",
                        "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                    return true;
                }

                grace.Brand = brand;
                grace.Description = descTextBox.Text;
                grace.Availability = availabilityTextBox.Text.Length > 0 ? availabilityTextBox.Text : string.Empty;
                if (barCodeTextBox.Text.Length > 0)
                {
                    grace.BarCode = barCodeTextBox.Text;
                    // Make sure SKU is not a duplicate
                    bool barcodeExists = context.Graces.Any(entity => entity.BarCode == grace.BarCode);
                    if (barcodeExists)
                    {
                        MessageBox.Show($"Bar Code {grace.BarCode} already exists. Please "
                            + "check your entry and try again.",
                            "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                        return true;
                    }
                }
                else
                {
                    grace.BarCode = string.Empty;
                }
                grace.Note = !string.IsNullOrEmpty(noteTextBox.Text) ? noteTextBox.Text : string.Empty;
                context.Graces.Add(grace);
                context.SaveChanges();
                graceId = grace.ID;
            }

            // Add the CurrentTotal from the currentTextBox 
            try
            {
                int newTotal = Convert.ToInt32(currentTextBox.Text);

                if (newTotal < 1)
                {
                    DialogResult result = MessageBox.Show(
                        $"The new CurrentTotal is less than one {newTotal} " +
                        "are you sure you want to enter this?", "Question",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return true;

                    }
                }
                DataBase.AddTotal(newTotal, graceId);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }


            foreach (string selected in newColList)
            {
                DataBase.AddCollectionRow(graceId, selected);
            }

            if (updateCollection)
            {
                string cName = addCollectionTextBox.Text.Trim();
                DataBase.AddCollectionRow(graceId, cName);
                Globals.GetInstance().CollectionDirty = true;
            }

            // Now add the grace row. 
            DataBase.CreateGraceRow(graceId);

            return ret;
        }
#pragma warning restore CS8602
#pragma warning restore CA1305

        private void BarCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode is Keys.Enter or Keys.Return)
            {
                TextBox box = (TextBox)sender;
                string str = box.Text.Trim();
                if (string.IsNullOrEmpty(str))
                {
                    return;
                }
                barCodeTextBox.Text = str;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                 "Are you sure you want to delete this row", "Question",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using GraceDbContext context = new();
                Grace? grace = context.Graces.FirstOrDefault(item => item.Sku == graceRow.Sku);
                context.Graces.Remove(grace);
                context.SaveChanges();
            }
            DialogResult = DialogResult.OK;
            Close();

        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            string? itemName = checkedListBox.Items[e.Index].ToString();
            if (itemName != null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (newRow)
                    {
                        if (newColList.Contains(itemName) == false)
                        {
                            newColList.Add(itemName);
                        }
                    }
                    else
                    {
                        updateGraceRow = DataBase.AddCollectionRow(graceRow.GraceId, itemName);

                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    if (newRow)
                    {
                        newColList.Remove(itemName);
                    }
                    else
                    {
                        updateGraceRow = DataBase.DeleteCollectionRow(graceRow.GraceId, itemName);
                    }
                }
                // Make sure the grace row is updated when the save button is
                // hit.
                if (!newRow)
                {
                    updateGraceRow = true;
                }
            }
        }

        private void deltaTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ensure the entered text is a valid integer
            if (!int.TryParse(adjustTextBox.Text, out int result))
            {
                // If not a valid integer, clear the TextBox
                adjustTextBox.Text = "";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void skuTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(skuTextBox.Text))
            {
                return;
            }

            // Convert the text in the TextBox to uppercase
            skuTextBox.Text = skuTextBox.Text.ToUpper(System.Globalization.CultureInfo.CurrentCulture);
            // Set the cursor position at the endDateRange of the text
            skuTextBox.SelectionStart = skuTextBox.Text.Length;
        }

        private void addCollectionLabel_MouseHover(object sender, EventArgs e)
        {
            // Show help when mouse hovers over the TextBox
            toolTip.ToolTipTitle = "Add Collection";
            toolTip.Show("All Collection Names must begin with a capital letter.",
                addCollectionLabel, 0, -30, 2000);
        }

        private void addCollectionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(addCollectionTextBox.Text))
            {
                return;
            }

            string text = addCollectionTextBox.Text;

            // Capitalize the first letter of the first word
            if (text.Length > 0 && char.IsLower(text[0]))
            {
                string capitalizedText = char.ToUpper(text[0], System.Globalization.CultureInfo.CurrentCulture) + text.Substring(1);

                // Store the current cursor position
                int selectionStart = addCollectionTextBox.SelectionStart;

                // Update the text
                addCollectionTextBox.Text = capitalizedText;

                // Restore the cursor position
                addCollectionTextBox.SelectionStart = selectionStart;
            }
        }

    }
}

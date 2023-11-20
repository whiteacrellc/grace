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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic.ApplicationServices;
using NLog;
using OfficeOpenXml;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace grace
{
    public partial class Vivian : Form
    {
        public ExcelReader er { get; }
        Report? report;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public string User { get; set; }
        private StringBuilder sb = new StringBuilder();
        private bool readyForNewCode = true;
        private DataGridLoader dataGridLoader;
        private BindingSource bindingSource1;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Vivian()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            er = new ExcelReader(this);
            EnableReportButton(false);
            User = "";


            dataGridView.AutoGenerateColumns = true;
            bindingSource1 = new BindingSource();
            dataGridView.DataSource = bindingSource1;

            // Init the globals


        }

        private void generateReport()
        {
            try
            {
                var collections = er.Collections;
                var items = er.Items;
                report = new Report(collections, items, this);
                report.GenerateReport();
            }
            catch (Exception ex)
            {
                // Display an alert dialog with the exception message
                MessageBox.Show($"There was a problem generating the report :\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EnableReportButton(bool enable)
        {
            if (enable)
            {
                saveReportToolStripMenuItem.Enabled = true;
            }
            else
            {
                saveReportToolStripMenuItem.Enabled = false;
            }

        }

        public void DisplayLogMessage(string? message)
        {
            if (message == null) return;
            // also log to file
            logger.Info(message);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    // Settings were modified, update the MainForm
                    // UpdateFormWithSettings();
                }
            }
        }

        private void Vivian_Load(object sender, EventArgs e)
        {
            // Loads the preferences into the globals singleton
            DataBase data = new DataBase();

            InitializeComboBox();

            adminPage.Hide();
            dataPage.Hide();
            adminPage.Hide();
            checkoutPage.Hide();

            if (data.HaveData() == false)
            {
                dataPage.Hide();
            }
            else
            {
                try
                {
                    dataGridLoader = new DataGridLoader();
                    bindingSource1.DataSource = dataGridLoader.getData();
                    RemoveColumnsByName("ID", "Grace", "GraceId");

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    data.InitializeDatabase();
                }
            }

            tabControl.Height = this.Height;
            tabControl.Width = this.Width;
            dataGridView.Height = tabControl.Height;
            dataGridView.Width = tabControl.Width;
            dataPage.Height = dataGridView.Height;
            dataPage.Width = tabControl.Width;

        }

        private void InitializeComboBox()
        {
            // Clear existing items in the ComboBox
            comboBoxUsers.Items.Clear();
            AdminStuff adminStuff = new AdminStuff();
            adminStuff.InitUserDB();

            List<string> users = adminStuff.getUserNames();
            foreach (var user in users)
            {
                comboBoxUsers.Items.Add(user);
            }

            // Optionally, set the default selected item (first item in the list)
            if (comboBoxUsers.Items.Count > 0)
            {
                comboBoxUsers.SelectedIndex = 0;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }

        private void importInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FilterIndex = 1;  // Index of the filter that is selected by default
            EnableReportButton(false);


            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.CheckFileExists = true;
                    // openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.GetCommandLineArgs);
                    // openFileDialog.Multiselect = true;
                    openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";  // File filter


                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                        return;

                    string filePath = openFileDialog.FileName;
                    er.ReadExcelFile(filePath);

                    DataBase data = new DataBase();
                    data.LoadFromExcel(filePath);
                }
            }
            catch (Exception ex)
            {
                // Display an alert dialog with the exception message
                MessageBox.Show($"There was a problem reading the file:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            generateReport();

            EnableReportButton(true);
            if (dataGridLoader == null)
            {
                dataGridLoader = new DataGridLoader();
                dataGridView.DataSource = bindingSource1;
            }
            dataGridLoader.LoadBindingTable();
            bindingSource1.DataSource = dataGridLoader.graceDb.GraceRows.ToList();
            RemoveColumnsByName("ID", "Grace", "GraceId");
        }

        private void saveReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = $"report_{DateTime.Now.ToString("yyyyMMdd")}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                if (report != null) report.WriteReport(filePath);
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RadioButton radioButton in groupBox1.Controls.OfType<RadioButton>())
            {
                if (radioButton.Checked)
                {
                    // Display the selected user's name in a label
                    User = radioButton.Text;
                    break;
                }
            }
        }

        private void chooseUserButton_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = dataPage;
        }

        private void textBoxBarcode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == e.KeyCode)
            {
                if (readyForNewCode)
                {
                    textBoxBarcode.Clear();
                    readyForNewCode = false;
                    sb.Clear();
                }
                System.Windows.Forms.TextBox box = (System.Windows.Forms.TextBox)sender;
                sb.Append(box.Text);
                //textBoxBarcode.Text = sb.ToString();
            }
            else
            if (e.KeyCode == Keys.Enter)
            {
                textBoxBarcode.Text = sb.ToString();
                readyForNewCode = true;
                // Process the scanned data as needed (e.g., send it to a database, perform actions)
                // Example: ProcessScannedData(scannedData);
            }
        }

        private void textBoxBarcode_TextChanged(object sender, EventArgs e)
        {
            //TextBox box = (TextBox)sender;
            //textBoxBarcode.Text += box.Text;
        }

        private void formatTotals()
        {

            int numRows = dataGridView.Rows.Count;
            int numCols = dataGridView.Columns.Count;
            if (numCols > 14)
            {
                return;
            }
            for (int i = 0; i < numRows; i++)
            {
                DataGridViewRow row = dataGridView.Rows[i];

                if (row == null || row.Cells[12].Value == null) { continue; }

                // Compare the values of the two columns
                int value1 = (int)row.Cells[12].Value;
                int value2 = (int)row.Cells[11].Value;

                if (value1 != value2)
                {
                    // Set the background color to yellow if values are not equal
                    row.Cells[12].Style.BackColor = Color.Yellow;
                }
            }

        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            RemoveColumnsByName("ID", "Grace", "GraceId");
        }

        private void Vivian_Resize(object sender, EventArgs e)
        {

            tabControl.Height = this.Height;
            tabControl.Width = this.Width;
            dataGridView.Height = tabControl.Height;
            dataGridView.Width = tabControl.Width;
            dataPage.Height = dataGridView.Height;
            dataPage.Width = tabControl.Width;
        }

        private void dataGridView_Resize(object sender, EventArgs e)
        {


        }

        private void checkoutPage_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text;


            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                // Query the DbContext to filter products based on the "Sku" column
                var filteredProducts = dataGridLoader.graceDb.GraceRows
                    .Where(p => p.Sku.Contains(searchTerm))
                    .ToList();

                // Bind the filtered products to the DataGridView
                bindingSource1.DataSource = filteredProducts;
                // dataGridView.DataSource = filteredProducts;
            }
            else
            {
                // If the search box is empty, show all products
                bindingSource1.DataSource = dataGridLoader.getData();
                // dataGridView.DataSource = dataGridLoader.graceDb.GraceRows.ToList();
            }
            RemoveColumnsByName("ID", "Grace", "GraceId");
        }

        private void RemoveColumnsByName(params string[] columnNames)
        {
            foreach (string columnName in columnNames)
            {
                if (dataGridView.Columns.Contains(columnName))
                {
                    dataGridView.Columns.Remove(columnName);
                }
            }
        }

        private void dataGridView_Paint(object sender, PaintEventArgs e)
        {
            formatTotals();
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Get the modified cell value and the corresponding product
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            object cellValue = dataGridView.Rows[rowIndex].Cells[columnIndex].Value;

            try
            {
                int newTotal = Convert.ToInt32(cellValue);

                if (columnIndex == 12) // Assuming the second column is the "Totals" column
                {
                    // Update the corresponding product in the DbContext
                    int id = Convert.ToInt32(dataGridView.Rows[rowIndex].Cells[0].Value); // Assuming the first column is the "Id" column
                    var graceRow = dataGridLoader.graceDb.GraceRows.Find(id);
                    if (graceRow != null)
                    {
                        //var graceRow = dataGridLoader.graceDb.GraceRows.Where(t => t.GraceId == grace.ID);
                        var grace = dataGridLoader.graceDb.Graces.First(t => t.ID == graceRow.GraceId);

                        if (grace != null)
                        {
                            var total = new Total
                            {
                                date_field = DateTime.Now,
                                total = newTotal,
                                GraceId = id
                            };
                            grace.Totals.Add(total);
                            graceRow.PreviousTotal = graceRow.Total;
                            graceRow.Total = newTotal;
                            dataGridLoader.graceDb.SaveChanges(); // Save changes to the database
                            logger.Info($"{total.date_field} {User} changed {grace.Sku} total to {newTotal}");
                        }
                    }
                }
            }
            catch
            {
                int id = (int)dataGridView.Rows[rowIndex].Cells[0].Value;
                var graceRow = dataGridLoader.graceDb.GraceRows.Find(id);
                if (graceRow != null)
                {
                    if (columnIndex == 12) // Assuming the second column is the "Name" column
                    {
                        dataGridView.Rows[rowIndex].Cells[13].Value = graceRow.Total;
                    }
                }
            }

        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView.Rows[rowIndex];
            using (EditRowForm editRowForm = new EditRowForm(row))
            {
                DialogResult result = editRowForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // we need to reload the grid.
                    bindingSource1.DataSource = dataGridLoader.getData();
                    RemoveColumnsByName("ID", "Grace", "GraceId");
                }
            }
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            if (columnIndex < 13)
            {
                e.Cancel = true; // Cancel the edit for the first 12 columns
            }
        }

        private void adminPage_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void addRowButton_Click(object sender, EventArgs e)
        {
            using (EditRowForm editRowForm = new EditRowForm(null))
            {
                DialogResult dialogResult = editRowForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    bindingSource1.DataSource = dataGridLoader.getData();
                    RemoveColumnsByName("ID", "Grace", "GraceId");
                }
            }
        }

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Method 1: Get selected text using the Text property
            string selectedText = comboBoxUsers.Text;
#pragma warning disable CS8600
            // Method 2: Get selected text using the SelectedItem property
            string selectedTextItem = comboBoxUsers.SelectedItem.ToString();
#pragma warning restore CS8600

            passwordTextBox.Focus();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            string password = passwordTextBox.Text;
            if (password.Equals("changeme"))
            { 
            }
        }
    }
}

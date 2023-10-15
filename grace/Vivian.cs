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
using NLog;
using OfficeOpenXml;
using System.Text;

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

        public Vivian()
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
                printReportToolStripMenuItem.Enabled = true;
            }
            else
            {
                saveReportToolStripMenuItem.Enabled = false;
                printReportToolStripMenuItem.Enabled = false;
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
            Globals globals = Globals.GetInstance();
            DataBase data = new DataBase();
            Globals.GetInstance().ConnectionString = data.ConnectionString;

            if (data.HaveData() == false)
            {
                tabControl.TabPages[1].Hide();
            }
            else
            {
                dataGridLoader = new DataGridLoader(this);
                dataGridLoader.LoadBindingTable();
                bindingSource1.DataSource = dataGridLoader.getData();
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
            // dataGridLoader.LoadBindingTable();
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
                TextBox box = (TextBox)sender;
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

        private void tabControl1_Enter(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            DataGridLoader dataGridLoader = new DataGridLoader(this);
            bindingSource1.DataSource = dataGridLoader.getData();

        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == 11) // Assuming you want to compare Column1 and Column2
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];

                // Compare the values of the two columns
                //    string value1 = row.Cells["Total"].Value.ToString();
                //    string value2 = row.Cells["Previous Total"].Value.ToString();

                //     if (value1 != value2)
                //     {
                // Set the background color to yellow if values are not equal
                //         e.CellStyle.BackColor = Color.Yellow;
                //    }
            }

        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
    }
}

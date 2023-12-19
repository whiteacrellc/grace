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
using grace.tabs;
using grace.utils;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace grace
{
    public partial class Vivian : Form
    {

        public ExcelReader er { get; }
        Report? report;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private StringBuilder sb = new StringBuilder();
        private bool readyForNewCode = true;



        // To keep this file a reasonable size put all tab code and callbacks
        // in their own class
        private HomeTab homeTab;
        private AdminTab adminTab;
        private DataTab dataTab;
        private CheckInTab checkInTab;
        private CheckOutTab checkOutTab;


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


            dataGridView.AutoGenerateColumns = true;


            // Init the tab page classes
            homeTab = new HomeTab(this);
            adminTab = new AdminTab(this);
            dataTab = new DataTab(this);
            checkOutTab = new CheckOutTab(this);
            checkInTab = new CheckInTab(this);

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

            // Load all the tab classes
            homeTab.Load();
            adminTab.Load();

            if (data.HaveData())
            {
                try
                {
                    dataTab.Load();

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    data.InitializeDatabase();
                }
            }
            checkInTab.Load();
            checkOutTab.Load();

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

            dataTab.BindDataSource();
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

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            string username = Globals.GetInstance().CurrentUser;
            bool isadmin = PasswordChecker.IsUserAdmin(username);
            if (!isadmin)
            {
                int tabIndex = e.TabPageIndex;
                if (tabIndex == 1 || tabIndex == 4)
                {
                    e.Cancel = true;
                    MessageBox.Show("You can't select this tab.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void passwordGroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}

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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.ApplicationServices;
using NLog;
using OfficeOpenXml;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace grace
{
    public partial class Vivian : Form
    {
        Report? report;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private StringBuilder sb = new StringBuilder();
        private bool readyForNewCode = true;

        public void ConfigureServices(IServiceCollection services)
    => services.AddDbContext<GraceDbContext>();



        // To keep this file a reasonable size put all tab code and callbacks
        // in their own class
        private HomeTab homeTab;
        private AdminTab adminTab;
        private DataTab dataTab;
        internal CheckInTab checkInTab { get; set; }
        internal CheckOutTab checkOutTab { get; }
        internal ReportTab reportTab;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Vivian()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Font;

            EnableReportMenuItems(false);

            // Init the tab page classes
            homeTab = new HomeTab(this);
            adminTab = new AdminTab(this);
            dataTab = new DataTab(this);
            checkOutTab = new CheckOutTab(this);
            checkInTab = new CheckInTab(this);
            reportTab = new ReportTab(this);
        }

        private void InitializeLogger()
        {
            // Set up NLog configuration. This can be done in the NLog.config file as well.
            var config = new NLog.Config.LoggingConfiguration();

            // Create targets and rules
            var textboxTarget = new NLog.Targets.MethodCallTarget("textboxTarget", LogToTextBox);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, textboxTarget);

            // Create file target
            var fileTarget = new NLog.Targets.FileTarget("fileTarget")
            {
                FileName = @"C:\Users\tom\OneDrive\Desktop\grace.log",
                Layout = "${longdate} ${level:uppercase=true} ${message}"
            };
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, fileTarget);

            // Apply configuration
            LogManager.Configuration = config;
        }

        private void LogToTextBox(LogEventInfo logEvent, object[] arg2)
        {
            // This method is called when a log event occurs
            string logMessage = logEvent.FormattedMessage;

            // Use Invoke to update UI from another thread (e.g., if logging from a background thread)
            loggingTextBox.Invoke(new Action(() =>
            {
                loggingTextBox.AppendText(logMessage + Environment.NewLine);
                loggingTextBox.ScrollToCaret(); // Scroll to the endDateRange to show the latest log entry
            }));
        }

        private void generateReport()
        {
            try
            {
                report = new Report();
                report.GenerateReport();
            }
            catch (Exception ex)
            {
                // Display an alert dialog with the exception message
                MessageBox.Show($"There was a problem generating the report :\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EnableReportMenuItems(bool enable)
        {
            if (enable)
            {
                saveReportToolStripMenuItem.Enabled = true;
                saveInventoryReportToolStripMenuItem.Enabled = true;
            }
            else
            {
                saveReportToolStripMenuItem.Enabled = false;
                saveInventoryReportToolStripMenuItem.Enabled = false;
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
                    // Settings were modified, newRow the MainForm
                    // UpdateFormWithSettings();
                }
            }
        }

        private void Vivian_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;

            InitializeLogger();

            // Loads the preferences into the globals singleton
            DataBase data = new DataBase();

            // Load all the tab classes
            homeTab.Load();
            adminTab.Load();

            if (DataBase.HaveData())
            {
                try
                {
                    dataTab.Load();

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    DataBase.InitializeDatabase();
                }
            }
            checkInTab.Load();
            checkOutTab.Load();
            reportTab.Load();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }

        private void importInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FilterIndex = 1;  // Index of the filter that is selected by default
            EnableReportMenuItems(false);


            try
            {
                if (MessageBox.Show(
                "This will completely erase the database"
                + " and startDateRange the program from scratch. You will lose all"
                + " stored information. Are you sure you want to do this?",
                "Danger! Danger!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
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
                        //er.ReadExcelFile(filePath);
                        DataBase.LoadFromExcel(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an alert dialog with the exception message
                MessageBox.Show($"There was a problem reading the file:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataTab.BindDataSource();
        }

        private void saveReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = $"report_{DateTime.Now.ToString("yyyyMMdd")}.xlsx",
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                EnableReportMenuItems(false);
                generateReport();
                report.WriteReport(filePath);
                EnableReportMenuItems(true);
            }
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            string username = Globals.GetInstance().CurrentUser;
            bool isAdmin = PasswordChecker.IsUserAdmin(username);
            int tabIndex = e.TabPageIndex;
            if (!isAdmin)
            {

                if (tabIndex == 1 || tabIndex == 5)
                {
                    e.Cancel = true;
                    MessageBox.Show("You can't select this tab.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                if (tabIndex == 1)
                {
                    // SizeForm();
                }
            }
        }

        private void checkOutDataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                logger.Error(e.ToString());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {

            TabPage page = tabControl.TabPages[e.Index];
            int currentIndex = tabControl.SelectedIndex;
            e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);

            var c = Color.LightBlue;
            if (e.Index == currentIndex)
            {
                c = Color.Black;
            }
            TextRenderer.DrawText(e.Graphics, page.Text, e.Font, paddedBounds, c);
        }

        private void dataPage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void filterRowsLabel_MouseHover(object sender, EventArgs e)
        {
            toolTip.ToolTipTitle = "Row Filter";
            toolTip.Show("Use this to filter on SKU, Description or Barcode."
                + " If using the barcode scanner use the Scan Barcode field.",
                filterRowsLabel, 0, -30, 2000);
        }

        private void scanBarcodeLabel_MouseHover(object sender, EventArgs e)
        {

            toolTip.ToolTipTitle = "BarCode Filter";
            toolTip.Show("Use this to filter using the Barcode Scanner."
                + " To manually filter on barcodes use the other search box.",
                scanBarcodeLabel, 0, -30, 2000);
        }

        private void dataPage_Click(object sender, EventArgs e)
        {

        }

    }
}

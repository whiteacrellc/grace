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
using System.Drawing;
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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace grace
{
    public partial class Vivian : Form
    {
        Report? report;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private StringBuilder sb = new();

        // To keep this file a reasonable size put all tab code and callbacks
        // in their own class
        private HomeTab homeTab;
        private AdminTab adminTab;
        private DataTab dataTab;
        internal CheckInTab checkInTab { get; set; }
        internal CheckOutTab checkOutTab { get; }
        internal ReportTab reportTab;
        internal CollectionTab collectionTab;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Vivian()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            // this.AutoScaleMode = AutoScaleMode.Font; // Removed to keep Dpi scaling

            EnableReportMenuItems(false);

            // Init the tab page classes
            homeTab = new HomeTab(this);
            adminTab = new AdminTab(this);
            dataTab = new DataTab(this);
            checkOutTab = new CheckOutTab(this);
            checkInTab = new CheckInTab(this);
            reportTab = new ReportTab(this);
            collectionTab = new CollectionTab(this);
        }

        private void InitializeLogger()
        {
            // Set up NLog configuration. This can be done in the NLog.config file as well.
            NLog.Config.LoggingConfiguration config = new();

            // Create targets and rules
            NLog.Targets.MethodCallTarget textboxTarget = new("textboxTarget", LogToTextBox);
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
            if (message == null)
            {
                return;
            }
            // also log to file
            logger.Info(message);
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SettingsForm settingsForm = new();
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                // Settings were modified, newRow the MainForm
                // UpdateFormWithSettings();
            }
        }

        private void Vivian_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;

            InitializeLogger();

            // Loads the preferences into the globals singleton
            _ = new DataBase();

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
            collectionTab.Load();

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }

        private void ImportInventoryToolStripMenuItem_Click(object sender, EventArgs e)
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


                    using OpenFileDialog openFileDialog = new();
                    openFileDialog.CheckFileExists = true;
                    // openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.GetCommandLineArgs);
                    // openFileDialog.Multiselect = true;
                    openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";  // File filter


                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        EnableReportMenuItems(true);
                        return;
                    }

                    string filePath = openFileDialog.FileName;
                    //er.ReadExcelFile(filePath);
                    DataBase.LoadFromExcel(filePath);
                }
            }
            catch (Exception ex)
            {
                // Display an alert dialog with the exception message
                MessageBox.Show($"There was a problem reading the file:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataTab.BindDataSource();
            EnableReportMenuItems(true);
        }

        private void SaveReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = $"report_{DateTime.Now:yyyyMMdd}.xlsx",
                RestoreDirectory = true
            };
            EnableReportMenuItems(false);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                generateReport();
                report.WriteReport(filePath);
            }
            EnableReportMenuItems(true);
        }

        private void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            string username = Globals.GetInstance().CurrentUser;
            bool isAdmin = PasswordChecker.IsUserAdmin(username);
            int tabIndex = e.TabPageIndex;
            if (!isAdmin)
            {

                if (tabIndex is 1 or 6)
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

        private void CheckOutDataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {

            TabPage page = tabControl.TabPages[e.Index];
            int currentIndex = tabControl.SelectedIndex;

            // Set page backcolor - might be redundant if already set in Designer, but ensures consistency
            page.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");

            // Background of the tab itself
            using (SolidBrush backBrush = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#FFF5EE")))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1; // Keep existing yOffset logic
            paddedBounds.Offset(1, yOffset);

            Color textColor;
            if (e.Index == currentIndex) // Selected tab
            {
                textColor = System.Drawing.ColorTranslator.FromHtml("#B76E79"); // Rose Gold
                // Optionally, draw a selection indicator (e.g., an underline or different background for the tab header)
                // For example, a simple underline:
                // e.Graphics.DrawLine(new Pen(System.Drawing.ColorTranslator.FromHtml("#CFB53B"), 2), e.Bounds.Left, e.Bounds.Bottom -1, e.Bounds.Right, e.Bounds.Bottom-1);
            }
            else // Unselected tab
            {
                textColor = System.Drawing.ColorTranslator.FromHtml("#36454F"); // Charcoal
            }

            // Draw tab text
            TextRenderer.DrawText(e.Graphics, page.Text, e.Font, paddedBounds, textColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }

        private void FilterRowsLabel_MouseHover(object sender, EventArgs e)
        {
            reportToolTip.ToolTipTitle = "Row Filter";
            reportToolTip.Show("Use this to filter on SKU, Description or Barcode."
                + " If using the barcode scanner use the Scan Barcode field.",
                filterRowsLabel, 0, -30, 2000);
        }

        private void ScanBarcodeLabel_MouseHover(object sender, EventArgs e)
        {

            reportToolTip.ToolTipTitle = "BarCode Filter";
            reportToolTip.Show("Use this to filter using the Barcode Scanner."
                + " To manually filter on barcodes use the other search box.",
                scanBarcodeLabel, 0, -30, 2000);
        }

        private void Vivian_Paint(object sender, PaintEventArgs e)
        {
            //if (VisualStyleRenderer.IsElementDefined(
            //    VisualStyleElement.Window.HorizontalScroll.Normal))
            //{
            //    VisualStyleRenderer renderer =
            //         new(VisualStyleElement.Window.HorizontalScroll.Normal);
            //    Rectangle rectangle1 = new(10, 50, 50, 50);
            //    renderer.DrawBackground(e.Graphics, rectangle1);
            //    e.Graphics.DrawString("VisualStyleElement.Window.HorizontalScroll.Normal",
            //         this.Font, Brushes.Black, new Point(10, 10));
            //}
            //else
            //    e.Graphics.DrawString("This element is not defined in the current visual style.",
            //         this.Font, Brushes.Black, new Point(10, 10));

        }

        private void ResetComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }

            // Get the item text
            string username = resetComboBox.Items[e.Index].ToString();

            // Determine font and colors based on selection state and admin status
            Font itemFont;
            Brush textBrush;
            Brush backgroundBrush;

            bool isAdmin = PasswordChecker.IsUserAdmin(username);

            if (isAdmin)
            {
                itemFont = new Font("Segoe UI", 10f, FontStyle.Bold);
            }
            else
            {
                itemFont = new Font("Segoe UI", 10f, FontStyle.Regular);
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                // Selected item
                backgroundBrush = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#E0C97F")); // Lighter Gold
                textBrush = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#36454F"));       // Charcoal
            }
            else
            {
                // Unselected item
                backgroundBrush = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#FFFAF0")); // FloralWhite (ComboBox item background)
                textBrush = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#36454F"));       // Charcoal
            }

            // Draw the background
            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);

            // Draw the item text
            e.Graphics.DrawString(username, itemFont, textBrush, e.Bounds.X, e.Bounds.Y + (e.Bounds.Height - itemFont.Height) / 2); // Centered vertically

            // Dispose of brushes and font if created
            textBrush.Dispose();
            backgroundBrush.Dispose();
            if (itemFont.Name != e.Font.Name || itemFont.Style != e.Font.Style) // Dispose only if new font was created
            {
                itemFont.Dispose();
            }

            // Draw focus rectangle if the item has focus
            e.DrawFocusRectangle();
        }

        private void ReportInfoLabel_MouseHover(object sender, EventArgs e)
        {
            reportToolTip.Show("This report shows a chronological log of inventory changes to an item", reportInfoLabel);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using AboutBox aboutBox = new();
            DialogResult result = aboutBox.ShowDialog();
            logger.Info("WHat is it all about anyway?");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

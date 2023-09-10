using OfficeOpenXml;
using System.Windows.Forms;
using NLog;

namespace grace
{
    public partial class Vivian : Form
    {
        private ExcelReader er;
        Report? report;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();


    public Vivian()
        {
            InitializeComponent();
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            er = new ExcelReader(this);
        }

        private void openFileButtonClick(object sender, EventArgs e)
        {
            openFileDialog.FilterIndex = 1;  // Index of the filter that is selected by default
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
                }
            }
            catch (Exception ex)
            {
                // Display an alert dialog with the exception message
                MessageBox.Show($"There was a problem reading the file:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            generateReport();

        }

        private void generateReport()
        {
            try
            {
                var collections = er.Collections;
                var items = er.Items;
                report = new Report(collections, items, this);
                report.GenerateReport();
                report.GenerateReport();
            }
            catch (Exception ex)
            {
                // Display an alert dialog with the exception message
                MessageBox.Show($"There was a problem generating the report :\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DisplayLogMessage(string? message)
        {
            if (message == null) return;
            // Append the message to a TextBox named "logTextBox" or another control
            debugTextBox.AppendText(message + Environment.NewLine);
            // also log to file
            logger.Info(message);
        }

        private void generateAndSaveReport(object sender, EventArgs e)
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

    }
}

using OfficeOpenXml;
using System.Windows.Forms;
using NLog;
using System.IO.Packaging;

namespace grace
{
    public partial class Vivian : Form
    {
        public ExcelReader er { get; }
        Report? report;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public Globals globals { get; }

        public string User { get; set; }

        public Vivian()
        {
            InitializeComponent();
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            er = new ExcelReader(this);
            EnableReportButton(false);
            globals = new Globals();
            User = "";
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

        private void printReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintExcel printExcel = new PrintExcel();
            string dir = Path.GetTempPath();
            string tempFileName = dir + "//foo.xlxs";
            if (report != null)
            {
                report.WriteReport(tempFileName);
                printExcel.Print(tempFileName);

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
            tabControl1.SelectedTab = dataPage;
        }
    }
}

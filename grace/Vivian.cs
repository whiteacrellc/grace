using OfficeOpenXml;
using System.Windows.Forms;

namespace grace
{
    public partial class Vivian : Form
    {
        private ExcelReader er = new ExcelReader();

        public Vivian()
        {
            InitializeComponent();
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private void openFileButtonClick(object sender, EventArgs e)
        {
            openFileDialog.FilterIndex = 1;  // Index of the filter that is selected by default
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    openFileDialog.Multiselect = true;
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
                var collections = er.Collections;
                var items = er.Items;
                Report report = new Report(collections, items);
                report.WriteReport(filePath);
            }

        }

    }
}

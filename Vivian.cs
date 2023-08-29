using System.Windows.Forms;

namespace grace
{
    public partial class Vivian : Form
    {
        public Vivian()
        {
            InitializeComponent();
        }

        private void openFileButtonClick(object sender, EventArgs e)
        {
            openFileDialog.FilterIndex = 1;  // Index of the filter that is selected by default

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file's path
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "C:\\Users\tom";  // Initial directory
                    openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";  // File filter
                    string filePath = openFileDialog.FileName;
                    ExcelReader er = new ExcelReader();
                    er.ReadExcelFile(filePath);
                    // Read and process the file here
                    // For demonstration, let's display the file path in a MessageBox
                    //MessageBox.Show("Selected file: " + filePath, "File Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
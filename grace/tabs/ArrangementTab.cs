using grace.data;
using grace.data.models;
using NLog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grace.tabs
{
    internal class ArrangementTab
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly Vivian vivian;
        private DataGridView arragementDataGrid;
        private Button createArrangementButton;
        private Button deleteArrangementButton;
        private ComboBox collectionDropDown;
        private BindingSource bindingSource;
        private Label currentCollectionLabel;
        private StatusStrip statusStrip;
        private readonly string currentUser = Globals.GetInstance().CurrentUser;
        private Button printButton;
        private TabPage arrangementPage;
        internal ArrangementTab(Vivian v)
        {
            this.vivian = v;
            Setup();
        }

        private void Setup()
        {
            arragementDataGrid = vivian.arrangementDataGrid;
            createArrangementButton = vivian.createArrangementButton;
            deleteArrangementButton = vivian.deleteArrangementButton;
            collectionDropDown = vivian.collectionDropDown;
            currentCollectionLabel = vivian.currentCollectionLabel;
            statusStrip = vivian.statusStrip;
            printButton = vivian.printButton;
            arrangementPage = vivian.arrangementPage;
        }

        public void Load()
        {
            bindingSource = [];
            arrangementPage.Enter += ArrangementPage_Enter;
            createArrangementButton.Click += CreateArrangementButton_Click;
            deleteArrangementButton.Click += DeleteArrangementButton_Click;
            printButton.Click += PrintArrangementButton_Click;
            collectionDropDown.SelectedValueChanged += CollectionDropDown_SelectedValueChanged;
            arragementDataGrid.CellEndEdit += ArrangementDataGrid_CellEndEdit;
            arragementDataGrid.EditingControlShowing += ArrangementDataGrid_EditingControlShowing;
            InitializeComboBox();
            LoadData();
            SetTimeOfDayGreeting();
            // Set row height and font
            SetDataGridViewStyle();
        }

        private void ArrangementPage_Enter(object? sender, EventArgs e)
        {
            InitializeComboBox();
        }

        private void PrintArrangementButton_Click(object? sender, EventArgs e)
        {
            ArrangementReport arrangementReport = new();
            arrangementReport.GenerateReport();
            using SaveFileDialog saveFileDialog = new()
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Save Arrangement Report",
                FileName = "ArrangementReport.xlsx"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    arrangementReport.WriteReport(saveFileDialog.FileName);
                    if (statusStrip.Items["toolStripStatusLabel1"] is ToolStripStatusLabel statusLabel)
                    {
                        statusLabel.Text = $"Arrangement report saved to {saveFileDialog.FileName}";
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Error saving arrangement report to {FileName}", saveFileDialog.FileName);
                    MessageBox.Show($"Error saving report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetDataGridViewStyle()
        {
            // Set the default cell style to match collGridView and checkOutDataGrid
            DataGridViewCellStyle defaultCellStyle = new()
            {
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.FromArgb(255, 250, 240),
                ForeColor = Color.FromArgb(54, 69, 79),
                SelectionBackColor = Color.FromArgb(224, 201, 127),
                SelectionForeColor = Color.FromArgb(54, 69, 79),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                WrapMode = DataGridViewTriState.False
            };

            // Set the alternating rows style
            DataGridViewCellStyle alternatingRowsStyle = new()
            {
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.FromArgb(248, 240, 227),
                ForeColor = Color.FromArgb(54, 69, 79),
                SelectionBackColor = Color.FromArgb(224, 201, 127),
                SelectionForeColor = Color.FromArgb(54, 69, 79)
            };

            arragementDataGrid.DefaultCellStyle = defaultCellStyle;
            arragementDataGrid.AlternatingRowsDefaultCellStyle = alternatingRowsStyle;
        }


        /// <summary>
        /// Callback function that executes after a cell edit is completed.
        /// </summary>
        private void ArrangementDataGrid_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            // 1. Get a reference to the specific row that was edited
            DataGridViewRow editedRow = arragementDataGrid.Rows[e.RowIndex];

            // --- Retrieve the 'Name' Value (assuming it's a string) ---
            string name = string.Empty;
            // Check if the 'Name' column exists to prevent errors
            if (arragementDataGrid.Columns.Contains("Name"))
            {
                // Get the value from the 'Name' column in the edited row
                object nameValue = editedRow.Cells["Name"].Value;
                name = nameValue?.ToString() ?? string.Empty;
            }


            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            if (arragementDataGrid.Columns.Contains("Total"))
            {
                object totalValue = editedRow.Cells["Total"].Value;
                // Attempt to parse the value as an integer
                if (int.TryParse(totalValue?.ToString(), out int total))
                {
                    UpdateArrangementTotal(name, total);
                }
            }

        }

        private void SetTimeOfDayGreeting()
        {
            // We will update the status label (assumed to be named 'toolStripStatusLabel1')
            if (statusStrip.Items["toolStripStatusLabel1"] is not ToolStripStatusLabel statusLabel)
            {
                Console.WriteLine("Error: ToolStripStatusLabel 'toolStripStatusLabel1' not found.");
                return; // Can't update if the label doesn't exist.
            }

            DateTime currentTime = DateTime.Now;
            string greeting = currentTime.Hour is >= 0 and < 12 ? "Good Morning" : currentTime.Hour is >= 12 and < 17 ? "Good Afternoon" : "Good Evening";

            // Combine greeting with the currentUser variable (assumed to exist in Form1)
            statusLabel.Text = $"{greeting}, {currentUser}!";
        }


        // Placeholder for a function that might update your database
        private void UpdateArrangementTotal(string name, int total)
        {
            string? collectionName = collectionDropDown.SelectedItem?.ToString();
            Arrangement? arrangement = DataBase.GetArrangement(collectionName, name);
            if (arrangement != null)
            {
                try
                {
                    using GraceDbContext context = new();
                    ArrangementTotal arrangementTotal = new()
                    {
                        CurrentTotal = total,
                        ArrangementId = arrangement.ID,
                        User = currentUser
                    };
                    context.ArrangementTotals.Add(arrangementTotal);

                    // Save the changes to the database
                    context.SaveChanges();
                    if (statusStrip.Items["toolStripStatusLabel1"] is ToolStripStatusLabel statusLabel)
                    {
                        statusLabel.Text = $"Successfully updated total for '{name}' to {total}.";
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Error updating arrangement total for {Name} in collection {CollectionName}", name, collectionName);
                }
            }
        }

        private void CollectionDropDown_SelectedValueChanged(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string? collectionName = collectionDropDown.SelectedItem?.ToString();
            currentCollectionLabel.Text = $"Current Collection: {collectionName}";
            bindingSource.DataSource = DataBase.GetArrangementNameGrid(collectionName);
            arragementDataGrid.DataSource = bindingSource;
            arragementDataGrid.Columns["Name"].ReadOnly = true;
        }

        private void InitializeComboBox()
        {
            List<string> collectionNames = DataBase.GetCollections();
            collectionDropDown.Items.Clear();
            foreach (string d in collectionNames)
            {
                collectionDropDown.Items.Add(d);
            }
            if (collectionDropDown.Items.Count > 0)
            {
                collectionDropDown.SelectedIndex = 0;
            }
        }

        public void CreateArrangementButton_Click(object? sender, EventArgs e)
        {
            using dialogs.AddArrangementDialog addArrangementDialog = new();
            DialogResult result = addArrangementDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (statusStrip.Items["toolStripStatusLabel1"] is ToolStripStatusLabel statusLabel)
                {
                    statusLabel.Text = $"Successfully added arrangement";
                }
                LoadData();
            }
            else if (result == DialogResult.Cancel)
            {
                if (statusStrip.Items["toolStripStatusLabel1"] is ToolStripStatusLabel statusLabel)
                {
                    statusLabel.Text = $"Add arrangement cancelled.";
                }
            }
        }
        public void DeleteArrangementButton_Click(object? sender, EventArgs e)
        {
            // Check if a row is selected
            if (arragementDataGrid.SelectedRows.Count == 0 && arragementDataGrid.CurrentRow == null)
            {
                MessageBox.Show("You must select a row to delete", "No Row Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected row (prefer SelectedRows, fallback to CurrentRow)
            DataGridViewRow selectedRow = arragementDataGrid.SelectedRows.Count > 0
                ? arragementDataGrid.SelectedRows[0]
                : arragementDataGrid.CurrentRow;

            // Get the value of the Name column
            string name = string.Empty;
            if (arragementDataGrid.Columns.Contains("Name"))
            {
                object nameValue = selectedRow.Cells["Name"].Value;
                name = nameValue?.ToString() ?? string.Empty;
            }

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Cannot delete: Name is empty", "Invalid Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show confirmation dialog
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete {name}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            // Delete all arrangements with the given name in the current collection
            try
            {
                using GraceDbContext context = new();

                // Find all arrangements with the given name in the current collection
                List<Arrangement> arrangementsToDelete = [.. context.Arrangement.Where(a => a.Name == name)];

                if (arrangementsToDelete.Count == 0)
                {
                    MessageBox.Show($"No arrangement found with name '{name}'",
                        "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                // Delete the arrangements
                context.Arrangement.RemoveRange(arrangementsToDelete);

                // Save changes
                context.SaveChanges();

                // Update status label
                if (statusStrip.Items["toolStripStatusLabel1"] is ToolStripStatusLabel statusLabel)
                {
                    statusLabel.Text = $"Successfully deleted arrangement '{name}'.";
                }

                // Reload the data to refresh the grid
                LoadData();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error deleting arrangement {Name}", name);
                MessageBox.Show($"Error deleting arrangement: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ArrangementDataGrid_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Check if the currently edited column is the one you want to validate
            string columnName = "Total"; // Replace with your actual column name

            if (arragementDataGrid.CurrentCell.OwningColumn.Name == columnName)
            {
                // Cast the editing control to a TextBox
                if (e.Control is TextBox txt)
                {
                    // First, remove any previous handler to prevent multiple executions
                    txt.KeyPress -= new KeyPressEventHandler(TxtKeyPressHandler);

                    // Now, attach the new handler
                    txt.KeyPress += new KeyPressEventHandler(TxtKeyPressHandler);
                }
            }
            else
            {
                // Ensure other columns don't inherit the KeyPress restriction
                if (e.Control is TextBox txt)
                {
                    txt.KeyPress -= new KeyPressEventHandler(TxtKeyPressHandler);
                }
            }
        }
        private void TxtKeyPressHandler(object sender, KeyPressEventArgs e)
        {
            // Allow digits (0-9)
            // Allow the Backspace key (ASCII 8)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Stop the key from being processed if it's not a digit or Backspace
                e.Handled = true;
            }
        }
    }
}

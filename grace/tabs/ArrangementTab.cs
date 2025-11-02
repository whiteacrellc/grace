using grace.data;
using grace.data.models;
using NLog;
using System;
using System.Collections.Generic;
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
        }

        public void Load()
        {
            bindingSource = [];
            createArrangementButton.Click += CreateArrangementButton_Click;
            deleteArrangementButton.Click += DeleteArrangementButton_Click;
            collectionDropDown.SelectedValueChanged += CollectionDropDown_SelectedValueChanged;
            arragementDataGrid.CellEndEdit += ArrangementDataGrid_CellEndEdit;
            arragementDataGrid.EditingControlShowing += ArrangementDataGrid_EditingControlShowing;
            InitializeComboBox();
            LoadData();
            // Set row height and font
            SetDataGridViewStyle();
        }

        private void SetDataGridViewStyle()
        {
            // Set the default cell style
            DataGridViewCellStyle cellStyle = new()
            {
                Font = new Font("Veranda", 12),
                // Set other style properties if needed
            };

            arragementDataGrid.DefaultCellStyle = cellStyle;
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
                        ArrangementId = arrangement.ID
                    };
                    context.ArrangementTotals.Add(arrangementTotal);

                    // Save the changes to the database
                    context.SaveChanges();
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
                LoadData();
            }
        }

        public void DeleteArrangementButton_Click(object? sender, EventArgs e)
        {
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

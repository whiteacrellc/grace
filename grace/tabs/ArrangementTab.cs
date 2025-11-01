using grace.data;
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
        }

        public void Load()
        {
            bindingSource = [];
            createArrangementButton.Click += CreateArrangementButton_Click;
            deleteArrangementButton.Click += DeleteArrangementButton_Click;

            InitializeComboBox();
        }

        private void LoadData()
        {
            var collectionName = collectionDropDown.SelectedItem?.ToString();
            using (GraceDbContext context = new())
            {
                var arrangements = context.Arrangement.ToList();
                bindingSource.DataSource = arrangements;
                arragementDataGrid.DataSource = bindingSource;
            }
        }

        private void InitializeComboBox()
        {

            List<string> distinctCollectionNames = [];
            using (GraceDbContext context = new())
            {
                // Fill checkbox list with collection names
                distinctCollectionNames = [.. context.Collections
                    .Where(e => e.Name != "Other")
                    .Select(e => e.Name)
                    .Distinct()
                    .OrderBy(name => name)];

            }
            var collectionNames = DataBase.GetCollections();
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
                // Refresh the arrangement data grid or perform any necessary actions
            }
        }

        public void DeleteArrangementButton_Click(object? sender, EventArgs e)
        {
        }
    }

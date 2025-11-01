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
            collectionDropDown = vivian.collectionDropDown;
        }

        public void Load()
        {
            bindingSource = [];
            createArrangementButton.Click += CreateArrangementButton_Click;


            InitializeComboBox();
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

            collectionDropDown.Items.Clear();
            foreach (string d in distinctCollectionNames)
            {
                collectionDropDown.Items.Add(d);
            }
        }

        public void CreateArrangementButton_Click(object? sender, EventArgs e)
        {
        }
}

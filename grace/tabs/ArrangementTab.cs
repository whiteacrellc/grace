using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }
}

using grace.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grace.tabs
{

    internal class CheckOutTab
    {
        private Vivian vivian;
        private DataGridView checkOutDataGrid;
        private BindingSource checkoutBindingSource;

        internal CheckOutTab(Vivian v)
        {
            vivian = v;
            checkOutDataGrid = vivian.checkOutDataGrid;
            checkoutBindingSource = vivian.checkoutBindingSource;

        }

        public void Load()
        {
           InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {

            checkOutDataGrid.DataSource = checkoutBindingSource;

            using (var context = new GraceDbContext())
            {
                // Fetch data from the DbContext
                var graceRowsData = context.GraceRows.Select(row => new
                {
                    Sku = row.Sku,
                    Brand = row.Brand,
                    Description = row.Description,
                    BarCode = row.BarCode,
                    Total = row.Total
                }).ToList();

                // Bind data to the DataGridView
                checkoutBindingSource.DataSource = graceRowsData;
            }

        }

    }
}

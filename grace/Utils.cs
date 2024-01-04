using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grace
{
    public class Utils
    {
        public static void RemoveColumnByName(DataGridView dataGridView,
            string columnName)
        {
            if (dataGridView.Columns.Contains(columnName))
            {
                dataGridView.Columns.Remove(columnName);
            }  
        }
    }
}

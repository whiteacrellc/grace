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

        public static string RemoveLeadingZero(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str; // Return empty string if input is null or empty
            }

            if (str.StartsWith("0") && str.Length > 1)
            {
                return str.Substring(1);
            }
            else
            {
                return str;
            }
        }
    }
}

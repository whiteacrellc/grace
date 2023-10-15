using grace.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grace
{
    public partial class EditRowForm : Form
    {
        private int rowIndex;
        private DataBase dataBase;
        GraceDbContext graceDb;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EditRowForm(int rowIndex)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            this.rowIndex = rowIndex;
        }

        private void EditRowForm_Load(object sender, EventArgs e)
        {
            dataBase = new DataBase();
            graceDb = dataBase.graceDb;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grace
{
    public partial class AddUserDialog : Form
    {
        public AddUserDialog()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var username = usernameTextBox.Text.Trim();
            var password = passwordTextBox.Text.Trim();
            bool resetPassword = forcePasswordUpdateCheckBox.Checked;
            bool isAdmin = adminCheckBox.Checked;
            bool ok = AdminStuff.CreateUser(username, password,
                resetPassword, isAdmin);
            if (ok)
            {
                DialogResult = DialogResult.OK;
            } else
            {
                usernameTextBox.Clear();
            }
        }
    }
}

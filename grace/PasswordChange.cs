using grace.data;
using grace.data.models;
using grace.utils;
using OfficeOpenXml.ConditionalFormatting;
using OfficeOpenXml.Drawing.Slicer.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace grace
{
    public partial class PasswordChange : Form
    {

        private readonly string username;
        private bool reset = false;

        public PasswordChange(string username)
        {
            InitializeComponent();
            this.username = username;
        }


        private void chkShowOrginalPassword_CheckedChanged(object sender,
            EventArgs e)
        {
            currentPasswordTextBox.PasswordChar
                = chkShowOrginalPassword.Checked ? '\0' : '*';
        }

        private void chkShowNewPassword_CheckedChanged(object sender, EventArgs e)
        {
            newPasswordTextBox.PasswordChar
                = chkShowNewPassword.Checked ? '\0' : '*';
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ProcessLogin()
        {
            string oldPassword = currentPasswordTextBox.Text.Trim();
            string newPassword = newPasswordTextBox.Text.Trim();
            string confirmPassword = confirmTextBox.Text.Trim();



            if (string.IsNullOrEmpty(newPassword)
                || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (reset == false && string.IsNullOrEmpty(oldPassword))
            {
                MessageBox.Show("Please fill in old password.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!PasswordChecker.IsPasswordValid(newPassword))
            {
                MessageBox.Show("Passwords must be at least 3 characters long.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                newPasswordTextBox.Clear();
                confirmTextBox.Clear();
            }
            else if (newPassword.Equals(confirmPassword, StringComparison.Ordinal) == false)
            {
                MessageBox.Show("Passwords don't match.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                newPasswordTextBox.Clear();
                confirmTextBox.Clear();
            }
            else
            {
                using (var dbContext = new GraceDbContext())
                {
                    // Retrieve the user from the database
                    User? user = dbContext.Users
                        .FirstOrDefault(u => u.Username == username);
                    if (user == null)
                    {
                        MessageBox.Show("User not in database, please contact admin.",
                            "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        string dbPassword = user.Password;
                        if ((reset == false) && (dbPassword.Equals(oldPassword) == false))
                        {
                            MessageBox.Show("Current password is incorrect.",
                                "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            currentPasswordTextBox.Clear();
                        }
                        else
                        {
                            Globals.GetInstance().CurrentUser = username;
                            user.Password = newPassword;
                            user.ResetPassword = false;
                            dbContext.SaveChanges();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ProcessLogin())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            return;
           
        }

        private void currentPasswordShow(bool show)
        {
            if (show)
            {
                currentPasswordTextBox.Show();
                currentPasswordLabel.Show();
                chkShowOrginalPassword.Show();
            }
            else
            {
                currentPasswordTextBox.Hide();
                currentPasswordLabel.Hide();
                chkShowOrginalPassword.Hide();
            }
        }

        private void PasswordChange_Load(object sender, EventArgs e)
        {
            changePasswordLabel.Text = "Change Password for " + username;

            reset = PasswordChecker.ResetPassword(username);
            if (reset)
            {
                currentPasswordShow(false);
            }
            else
            {
                currentPasswordShow(true);
            }
        }

        private void confirmTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                // Prevent the Enter key from being processed by the TextBox
                e.Handled = true;

                // Call the processLogin function
                if (ProcessLogin())
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}

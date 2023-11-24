using grace.data;
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            string oldpassowrd = currentPasswordTextBox.Text.Trim();
            string newpassword = newPasswordTextBox.Text.Trim();
            string confirmpass = confirmTextBox.Text.Trim();



            if (string.IsNullOrEmpty(newpassword)
                || string.IsNullOrEmpty(confirmpass))
            {
                MessageBox.Show("Please fill in all fields.", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (reset == false && string.IsNullOrEmpty(oldpassowrd))
            {
                MessageBox.Show("Please fill in old password.", "Error",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!PasswordChecker.IsPasswordValid(newpassword))
            {
                MessageBox.Show("Passwords must be at least 3 characters long.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                newPasswordTextBox.Text = string.Empty;
                confirmTextBox.Text = string.Empty;
            }
            else if (newpassword.Equals(confirmpass) == false)
            {
                MessageBox.Show("Passwords don't match.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                newPasswordTextBox.Text = string.Empty;
                confirmTextBox.Text = string.Empty;
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
                        DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                    else
                    {
                        string dbpass = user.Password;
                        if ((reset == false) && (dbpass.Equals(oldpassowrd) == false))
                        {
                            MessageBox.Show("Current password is incorrect.",
                                "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        else
                        {
                            Globals.GetInstance().CurrentUser = username;
                            user.Password = newpassword;
                            user.ResetPassword = false;
                            dbContext.SaveChanges();
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }

            }
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

            string resetanswer = PasswordChecker.ResetAnswer(username);
            int resetindex = PasswordChecker.ResetIndex(username);

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

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

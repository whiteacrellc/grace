using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using grace.utils;
using System.Collections.Generic; // Added for List<string>

namespace grace
{
    public partial class LoginForm : Form
    {
        public string LoggedInUsername { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.


        public LoginForm()
        {
            InitializeComponent();

            this.loginButton.Click += loginButton_Click;
            this.changePasswordButton.Click += changePasswordButton_Click;
            this.passwordTextBox.KeyPress += PasswordTextBox_KeyPress;
            this.comboBoxUsers.SelectedIndexChanged += comboBoxUsers_SelectedIndexChanged;
        }

        public void loginButton_Click(object? sender, EventArgs e)
        {
            ProcessLogin();
        }

        public void changePasswordButton_Click(object? sender, EventArgs e)
        {
            if (this.comboBoxUsers.SelectedItem == null)
            {
                MessageBox.Show("Please select a user.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string? username = this.comboBoxUsers.SelectedItem.ToString();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Selected username is invalid.", "Invalid User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (PasswordChange passwordChange = new PasswordChange(username))
            {
                DialogResult dialogResult = passwordChange.ShowDialog(this); // Show as a child of LoginForm
                if (dialogResult == DialogResult.OK)
                {
                    MessageBox.Show(this, "Password updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void PasswordTextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessLogin();
                e.Handled = true; // Prevent the Enter key from being processed further
            }
        }

        private void ProcessLogin()
        {
            string password = this.passwordTextBox.Text;
            if (this.comboBoxUsers.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a user.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string? username = this.comboBoxUsers.SelectedItem.ToString();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show(this, "Selected username is invalid.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool reset = PasswordChecker.ResetPassword(username);

            if (string.IsNullOrEmpty(password))
            {
                if (reset)
                {
                    MessageBox.Show(this, "Your password needs to be reset. Please use the 'Change Password' button after entering your username.", "Password Reset Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Optionally, open the PasswordChange dialog directly:
                    // using (PasswordChange passwordChange = new PasswordChange(username))
                    // {
                    //     DialogResult dialogResult = passwordChange.ShowDialog(this);
                    //     if (dialogResult == DialogResult.OK)
                    //     {
                    //         MessageBox.Show(this, "Password updated successfully. Please try logging in again.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //     }
                    // }
                }
                else
                {
                    MessageBox.Show(this, "Password cannot be empty.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return; // Return after handling empty password or reset info
            }
            // This case should ideally be handled by the changePasswordButton workflow if a user knows they need to reset.
            // If they type a password when reset is true, it's ambiguous. For now, let's prioritize checking the typed password.
            // else if (PasswordChecker.ResetPassword(username)) // This was in original, but might be confusing if they also entered a password.
            // {
            //     // This path might be redundant if IsNullOrEmpty(password) already suggests using Change Password button for resets.
            // }
            else if (PasswordChecker.CheckPassword(username, password) == false)
            {
                MessageBox.Show(this, "Incorrect password, please try again.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.passwordTextBox.Clear();
                this.passwordTextBox.Focus();
            }
            else
            {
                // Successful login
                this.LoggedInUsername = username;
                Globals.GetInstance().CurrentUser = username; // Set current user in Globals

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public void comboBoxUsers_SelectedIndexChanged(object? sender, EventArgs e)
        {
            this.passwordTextBox.Focus();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Loads the preferences into the globals singleton
            _ = new DataBase();

            // Clear existing items in the ComboBox
            this.comboBoxUsers.Items.Clear();
            AdminStuff.InitUserDB(); // Assumes AdminStuff is accessible

            List<string> users = AdminStuff.getUserNames();
            foreach (var user in users)
            {
                this.comboBoxUsers.Items.Add(user);
            }

            // Optionally, set the default selected item (first item in the list)
            if (this.comboBoxUsers.Items.Count > 0)
            {
                this.comboBoxUsers.SelectedIndex = 0;
            }

        }
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8604 // Possible null reference argument.
    }
}

/*
 * Copyright (c) 2023 White Acre Software LLC
 * All rights reserved.
 *
 * This software is the confidential and proprietary information
 * of White Acre Software LLC. You shall not disclose such
 * Confidential Information and shall use it only in accordance
 * with the terms of the license agreement you entered into with
 * White Acre Software LLC.
 *
 * Year: 2023
 *
 *  This file contains all the code related to the home tab in the 
 *  Vivian class. It looks like that the only way to define a callback
 *  in a separate class is by making it static. 
 *  
 */
using grace.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

namespace grace.tabs
{
    public class HomeTab
    {


#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8602
#pragma warning disable CS8600
        private Vivian vivian;
        private TabPage homeTabPage;
        private ComboBox comboBoxUsers;
        private TextBox passwordTextBox;
        private GroupBox passwordGroupBox;
        private GroupBox loggedInBox;
        private Label loggedInLabel;
        private TabControl tabControl;
        private Button loginButton;
        private Button changePasswordButton;
        private Button logoutButton;

        public HomeTab(Vivian v) {
            vivian = v;

            // Set the controls in this tab
            homeTabPage = vivian.tabControl.TabPages[0];
            comboBoxUsers = vivian.comboBoxUsers;
            passwordTextBox = vivian.passwordTextBox;
            passwordGroupBox = vivian.passwordGroupBox;
            loggedInBox = vivian.loggedInBox;
            loggedInLabel = vivian.loggedInLabel;
            tabControl = vivian.tabControl;
            loginButton = vivian.loginButton;
            changePasswordButton = vivian.changePasswordButton;
            logoutButton = vivian.logoutButton;
        }

        internal void Load()
        {
            // setup callbacks. 
            loginButton.Click += loginButton_Click;
            changePasswordButton.Click += changePasswordButton_Click;
            passwordTextBox.KeyPress += passwordTextBox_KeyPress;
            logoutButton.Click += logoutButton_Click;
            comboBoxUsers.SelectedIndexChanged += comboBoxUsers_SelectedIndexChanged;

            InitializeComboBox();
            loggedInBox.Hide();
        }

        // Callback for Login button in HomePage table. 
        public void loginButton_Click(object? sender, EventArgs e)
        {
            processLogin();
        }

        // Callback for change password button
        public void changePasswordButton_Click(object? sender, EventArgs e)
        {
            string? username = comboBoxUsers.SelectedItem.ToString();

            if (string.IsNullOrEmpty(username))
            {
                return;
            }

            using (PasswordChange passwordChange = new PasswordChange(username))
            {
                DialogResult dialogResult = passwordChange.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    MessageBox.Show("Password updated succefully.", "Yay",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Callback the will log someone in if they hit return in the password
        // textbox 
        public void passwordTextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                // Call the processLogin function
                processLogin();

                // Prevent the Enter key from being processed by the TextBox
                e.Handled = true;
            }
        }

        public void logoutButton_Click(object? sender, EventArgs e)
        {
            Globals.GetInstance().CurrentUser = "";
            passwordGroupBox.Show();
            loggedInBox.Hide();
            passwordTextBox.Text = string.Empty;
        }



        private void InitializeComboBox()
        {

            // Clear existing items in the ComboBox
            comboBoxUsers.Items.Clear();
            AdminStuff.InitUserDB();

            List<string> users = AdminStuff.getUserNames();
            foreach (var user in users)
            {
                comboBoxUsers.Items.Add(user);
            }

            // Optionally, set the default selected item (first item in the list)
            if (comboBoxUsers.Items.Count > 0)
            {
                comboBoxUsers.SelectedIndex = 0;
            }
        }

        private void processLogin()
        {
            string password = passwordTextBox.Text;
            string? username = comboBoxUsers.SelectedItem.ToString();


            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Null username.", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool reset = PasswordChecker.ResetPassword(username);

            if (string.IsNullOrEmpty(password))
            {
                if (reset)
                {
                    using (PasswordChange passwordChange = new PasswordChange(username))
                    {
                        DialogResult dialogResult = passwordChange.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Password updated succefully.", "Yay",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Password is empty.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (PasswordChecker.ResetPassword(username))
            {
                using (PasswordChange passwordChange = new PasswordChange(username))
                {
                    DialogResult dialogResult = passwordChange.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        MessageBox.Show("Password updated succefully.", "Yay",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (PasswordChecker.CheckPassword(username, password) == false)
            {
                MessageBox.Show("Incorrect password, please try again.",
                    "Incorrect Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LoginUser(username);
            }
        }

        private void LoginUser(string username)
        {
            Globals.GetInstance().CurrentUser = username;
            passwordGroupBox.Hide();
            loggedInLabel.Text = username;
            loggedInBox.Show();

            // Since the checkout tab grid depends on the logged in user
            // we initialize it here. 
            vivian.checkOutTab.InitializeDataGridView();
            if (PasswordChecker.IsUserAdmin(username))
            {
                tabControl.SelectedTab = vivian.tabControl.TabPages[1];
            }
            else
            {
                tabControl.SelectedTab = vivian.tabControl.TabPages[2];
            }
        }

        // Move the focus to the password box when a person selects a user
        // in the combo box. 
        public void comboBoxUsers_SelectedIndexChanged(object? sender, EventArgs e)
        {
            passwordTextBox.Focus();
        }

#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602
#pragma warning restore CS8618
#pragma warning restore CS8600
    }
}

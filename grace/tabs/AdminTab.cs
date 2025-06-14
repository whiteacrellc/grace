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
 *  This file contains all the code related to the admin tab in the 
 *  Vivian class. It looks like that the only way to define a callback
 *  in a separate class is by making it static. 
 *  
 */
using grace.utils;
using NLog;

namespace grace.tabs
{
    public class AdminTab
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8602
#pragma warning disable CS8600

        private Button resetPasswordButton;
        private Button restoreDatabaseButton;
        private Button backupButton;
        private Button deleteUserButton;
        private Button addUserButton;
        private ComboBox resetComboBox;
        private CheckBox adminCheckBox;
        private TabPage adminTabPage;
        private Vivian vivian;

        internal AdminTab(Vivian v)
        {
            this.vivian = v;
            this.resetPasswordButton = v.resetPasswordButton;
            this.restoreDatabaseButton = v.restoreDatabaseButton;
            this.backupButton = v.backupButton;
            this.deleteUserButton = v.deleteUserButton;
            this.addUserButton = v.addUserButton;
            this.resetComboBox = v.resetComboBox;
            this.adminCheckBox = v.adminCheckBox;
        }


        public void Load()
        {
            adminTabPage = vivian.tabControl.TabPages[5];
            resetPasswordButton.Click += ResetButton_Click;
            backupButton.Click += BackupButton_Click;
            restoreDatabaseButton.Click += RestoreDatabaseButton_Click;
            deleteUserButton.Click += DeleteUserButton_Click;
            addUserButton.Click += AddUserButton_Click;
            resetComboBox.SelectedValueChanged += ResetComboBox_SelectedValueChanged;
            adminTabPage.Enter += AdminTabPage_Enter;
            InitializeComboBox();
            WriteBackupFile();
        }

        private void AdminTabPage_Enter(object? sender, EventArgs e)
        {
            string currentUser = Globals.GetInstance().CurrentUser;
            if (currentUser != null)
            {
                adminCheckBox.Checked = PasswordChecker.IsUserAdmin(currentUser);
            }
        }

        private void ResetComboBox_SelectedValueChanged(object? sender, EventArgs e)
        {
            string user = resetComboBox.Text;
            string currentUser = Globals.GetInstance().CurrentUser;
            if (currentUser == null || user == null)
            {
                return;
            }
            adminCheckBox.Checked = PasswordChecker.IsUserAdmin(user);
        }

        private static void WriteBackupFile()
        {
            BackupAndRestore backup = new();
            backup.BackupDatabaseToDocuments();
        }

        private void BackupButton_Click(object? sender, EventArgs e)
        {
            BackupAndRestore backup = new();
            backup.BackupDatabase();
        }
        private void DeleteUserButton_Click(object? sender, EventArgs e)
        {
            ComboBox resetComboBox = this.resetComboBox;
            string user = resetComboBox.Text;

            string currentUser = Globals.GetInstance().CurrentUser;
            if (user.Equals(currentUser))
            {
                MessageBox.Show("You can't delete the current user.", "Bad " + currentUser,
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult response = MessageBox.Show("Are you sure you want to delete "
                + user + "?", "User Delete",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.Yes)
            {
                AdminStuff.DeleteUser(user);
                InitializeComboBox();
            }
        }

        private void AddUserButton_Click(object? sender, EventArgs e)
        {
            AddUserDialog addUserDialog = new();
            DialogResult result = addUserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                logger.Info("Successfully added user");
                InitializeComboBox();
            }
        }

        private void RestoreDatabaseButton_Click(object? sender, EventArgs e)
        {
            BackupAndRestore backup = new();
            backup.RestoreDatabase();
        }

        private void InitializeComboBox()
        {
            ComboBox resetComboBox = this.resetComboBox;


            // Clear existing items in the ComboBox
            resetComboBox.Items.Clear();
            AdminStuff.InitUserDB();

            List<string> users = AdminStuff.getUserNames();
            foreach (string user in users)
            {
                resetComboBox.Items.Add(user);
            }

            // Optionally, set the default selected item (first item in the list)
            if (resetComboBox.Items.Count > 0)
            {
                resetComboBox.SelectedIndex = 0;
            }
        }

        public void ResetButton_Click(object? sender, EventArgs e)
        {
            string? username = this.resetComboBox.SelectedItem.ToString();
            if (string.IsNullOrEmpty(username))
            {
                return;
            }
            DialogResult response =
                MessageBox.Show("Are you sure you want to reset "
                                + username + "'s password?", "Password Reset",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.Yes)
            {
                PasswordChecker.SetResetFlag(username);
            }
        }
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602
#pragma warning restore CS8618
#pragma warning restore CS8600
    }
}

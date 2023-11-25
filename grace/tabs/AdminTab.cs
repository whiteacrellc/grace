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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grace.tabs
{
    public class AdminTab
    {


#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8602
#pragma warning disable CS8600
        private static TabPage adminTabPage;
        private static Vivian vivian;

        public AdminTab(Vivian v) {
            vivian = v;
            // Possible null reference assignment.
            adminTabPage = vivian.tabControl.TabPages[4];

        }

        
        public void InitializeComboBox()
        {
            ComboBox resetComboBox = vivian.resetComboBox;


            // Clear existing items in the ComboBox
            resetComboBox.Items.Clear();
            AdminStuff adminStuff = new AdminStuff();
            adminStuff.InitUserDB();

            List<string> users = adminStuff.getUserNames();
            foreach (var user in users)
            {
                resetComboBox.Items.Add(user);
            }

            // Optionally, set the default selected item (first item in the list)
            if (resetComboBox.Items.Count > 0)
            {
                resetComboBox.SelectedIndex = 0;
            }
        }


        public static void resetButton_Click(object sender, EventArgs e)
        {
            ComboBox resetComboBox = vivian.resetComboBox;
            string? username = resetComboBox.SelectedItem.ToString();
            if (string.IsNullOrEmpty(username))
            {
                return;
            }
            PasswordChecker.SetResetFlag(username);
        }
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602
#pragma warning restore CS8618
#pragma warning restore CS8600
    }
}

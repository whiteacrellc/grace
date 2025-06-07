﻿/*
 * Copyright (c) 2024 White Acre Software LLC
 * All rights reserved.
 *
 * This software is the confidential and proprietary information
 * of White Acre Software LLC. You shall not disclose such
 * Confidential Information and shall use it only in accordance
 * with the terms of the license agreement you entered into with
 * White Acre Software LLC.
 *
 */
 namespace grace
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {

            // Format the build date and time as "yyyyMMddHHmm"
            string versionString = "2.0.11";
            buildLabel.Text = "Version: " + versionString;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

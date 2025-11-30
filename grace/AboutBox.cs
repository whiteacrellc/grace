/*
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
using System.Diagnostics;

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
            string versionString = "2.1.2";
            buildLabel.Text = "Version: " + versionString;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkLabelReleases_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Mark the link as visited
                linkLabelReleases.LinkVisited = true;

                // Open the releases page in the default browser
                string url = "https://github.com/whiteacrellc/grace/releases";

                // Use ProcessStartInfo for better cross-platform compatibility
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open link: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

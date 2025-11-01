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
            string versionString = "2.0.14";
            buildLabel.Text = "Version: " + versionString;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelReleases_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Navigate to the URL.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://github.com/whiteacrellc/grace/releases",
                    UseShellExecute = true // Important for opening URLs in the default browser
                });
            }
            catch (System.Exception ex)
            {
                // Optionally, handle any exceptions that might occur when trying to open the link
                // For example, log the error or show a message to the user
                // System.Windows.Forms.MessageBox.Show($"Unable to open link: {ex.Message}");
            }
        }
    }
}

namespace grace
{
    partial class PasswordChange
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chkShowNewPassword = new CheckBox();
            chkShowOrginalPassword = new CheckBox();
            label4 = new Label();
            label3 = new Label();
            currentPasswordLabel = new Label();
            newPasswordTextBox = new TextBox();
            confirmTextBox = new TextBox();
            currentPasswordTextBox = new TextBox();
            saveButton = new Button();
            cancelButton = new Button();
            changePasswordLabel = new Label();
            SuspendLayout();
            // 
            // chkShowNewPassword
            // 
            chkShowNewPassword.AutoSize = true;
            chkShowNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            chkShowNewPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            chkShowNewPassword.Location = new Point(312, 185);
            chkShowNewPassword.Name = "chkShowNewPassword";
            chkShowNewPassword.Size = new Size(108, 19);
            chkShowNewPassword.TabIndex = 17;
            chkShowNewPassword.Text = "Show Password";
            chkShowNewPassword.UseVisualStyleBackColor = true;
            chkShowNewPassword.Click += chkShowNewPassword_CheckedChanged;
            // 
            // chkShowOrginalPassword
            // 
            chkShowOrginalPassword.AutoSize = true;
            chkShowOrginalPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            chkShowOrginalPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            chkShowOrginalPassword.Location = new Point(312, 140);
            chkShowOrginalPassword.Name = "chkShowOrginalPassword";
            chkShowOrginalPassword.Size = new Size(108, 19);
            chkShowOrginalPassword.TabIndex = 16;
            chkShowOrginalPassword.Text = "Show Password";
            chkShowOrginalPassword.UseVisualStyleBackColor = true;
            chkShowOrginalPassword.Click += chkShowOrginalPassword_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            label4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            label4.Location = new Point(43, 184);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 18;
            label4.Text = "New Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            label3.Location = new Point(23, 227);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 19;
            label3.Text = "Confirm Password";
            // 
            // currentPasswordLabel
            // 
            currentPasswordLabel.AutoSize = true;
            currentPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            currentPasswordLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            currentPasswordLabel.Location = new Point(27, 141);
            currentPasswordLabel.Name = "currentPasswordLabel";
            currentPasswordLabel.Size = new Size(100, 15);
            currentPasswordLabel.TabIndex = 20;
            currentPasswordLabel.Text = "Current Password";
            // 
            // newPasswordTextBox
            // 
            newPasswordTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            newPasswordTextBox.BorderStyle = BorderStyle.FixedSingle;
            newPasswordTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            newPasswordTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            newPasswordTextBox.Location = new Point(138, 181);
            newPasswordTextBox.Name = "newPasswordTextBox";
            newPasswordTextBox.PasswordChar = '*';
            newPasswordTextBox.Size = new Size(159, 23);
            newPasswordTextBox.TabIndex = 14;
            // 
            // confirmTextBox
            // 
            confirmTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            confirmTextBox.BorderStyle = BorderStyle.FixedSingle;
            confirmTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            confirmTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            confirmTextBox.Location = new Point(138, 224);
            confirmTextBox.Name = "confirmTextBox";
            confirmTextBox.PasswordChar = '*';
            confirmTextBox.Size = new Size(159, 23);
            confirmTextBox.TabIndex = 15;
            confirmTextBox.KeyPress += confirmTextBox_KeyPress;
            // 
            // currentPasswordTextBox
            // 
            currentPasswordTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            currentPasswordTextBox.BorderStyle = BorderStyle.FixedSingle;
            currentPasswordTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            currentPasswordTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            currentPasswordTextBox.Location = new Point(138, 138);
            currentPasswordTextBox.Name = "currentPasswordTextBox";
            currentPasswordTextBox.PasswordChar = '*';
            currentPasswordTextBox.Size = new Size(159, 23);
            currentPasswordTextBox.TabIndex = 13;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            saveButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            saveButton.FlatAppearance.BorderSize = 1;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            saveButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            saveButton.Location = new Point(82, 268);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 21;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            cancelButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            cancelButton.FlatAppearance.BorderSize = 1;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            cancelButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            cancelButton.Location = new Point(430, 268); // Adjusted X for Right anchor
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 22;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // changePasswordLabel
            // 
            changePasswordLabel.AutoSize = true;
            changePasswordLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            changePasswordLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            changePasswordLabel.Location = new Point(43, 88);
            changePasswordLabel.Name = "changePasswordLabel";
            changePasswordLabel.Size = new Size(119, 15);
            changePasswordLabel.TabIndex = 23;
            changePasswordLabel.Text = "Change Password for";
            // 
            // PasswordChange
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
            ClientSize = new Size(517, 321);
            Controls.Add(changePasswordLabel);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(currentPasswordTextBox);
            Controls.Add(chkShowNewPassword);
            Controls.Add(confirmTextBox);
            Controls.Add(chkShowOrginalPassword);
            Controls.Add(newPasswordTextBox);
            Controls.Add(label4);
            Controls.Add(currentPasswordLabel);
            Controls.Add(label3);
            Name = "PasswordChange";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Password Change";
            Load += PasswordChange_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox chkShowNewPassword;
        private CheckBox chkShowOrginalPassword;
        private Label label4;
        private Label label3;
        private Label currentPasswordLabel;
        private TextBox newPasswordTextBox;
        private TextBox currentPasswordTextBox;
        private TextBox confirmTextBox;
        private Button saveButton;
        private Button cancelButton;
        private Label changePasswordLabel;
    }
}

﻿namespace grace
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
            changePasswordLabel = new Label();
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
            SuspendLayout();
            // 
            // changePasswordLabel
            // 
            changePasswordLabel.AutoSize = true;
            changePasswordLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            changePasswordLabel.Location = new Point(22, 20);
            changePasswordLabel.Name = "changePasswordLabel";
            changePasswordLabel.Size = new Size(169, 25);
            changePasswordLabel.TabIndex = 10;
            changePasswordLabel.Text = "Change Password";
            // 
            // chkShowNewPassword
            // 
            chkShowNewPassword.AutoSize = true;
            chkShowNewPassword.Location = new Point(312, 104);
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
            chkShowOrginalPassword.Location = new Point(312, 59);
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
            label4.Location = new Point(43, 103);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 18;
            label4.Text = "New Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 146);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 19;
            label3.Text = "Confirm Password";
            // 
            // currentPasswordLabel
            // 
            currentPasswordLabel.AutoSize = true;
            currentPasswordLabel.Location = new Point(27, 60);
            currentPasswordLabel.Name = "currentPasswordLabel";
            currentPasswordLabel.Size = new Size(100, 15);
            currentPasswordLabel.TabIndex = 20;
            currentPasswordLabel.Text = "Current Password";
            // 
            // newPasswordTextBox
            // 
            newPasswordTextBox.Location = new Point(138, 100);
            newPasswordTextBox.Name = "newPasswordTextBox";
            newPasswordTextBox.PasswordChar = '*';
            newPasswordTextBox.Size = new Size(159, 23);
            newPasswordTextBox.TabIndex = 14;
            // 
            // confirmTextBox
            // 
            confirmTextBox.Location = new Point(138, 143);
            confirmTextBox.Name = "confirmTextBox";
            confirmTextBox.PasswordChar = '*';
            confirmTextBox.Size = new Size(159, 23);
            confirmTextBox.TabIndex = 15;
            confirmTextBox.KeyPress += confirmTextBox_KeyPress;
            // 
            // currentPasswordTextBox
            // 
            currentPasswordTextBox.Location = new Point(138, 57);
            currentPasswordTextBox.Name = "currentPasswordTextBox";
            currentPasswordTextBox.PasswordChar = '*';
            currentPasswordTextBox.Size = new Size(159, 23);
            currentPasswordTextBox.TabIndex = 13;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(82, 187);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 21;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(212, 187);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 22;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // PasswordChange
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 222);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(changePasswordLabel);
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
            Text = "Password Change";
            Load += PasswordChange_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label changePasswordLabel;
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
    }
}

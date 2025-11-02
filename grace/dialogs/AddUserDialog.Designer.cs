namespace grace
{
    partial class AddUserDialog
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
            saveButton = new Button();
            usernameTextBox = new TextBox();
            label1 = new Label();
            forcePasswordUpdateCheckBox = new CheckBox();
            label2 = new Label();
            passwordTextBox = new TextBox();
            adminCheckBox = new CheckBox();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.BackColor = Color.FromArgb(245, 245, 245);
            saveButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            saveButton.FlatAppearance.BorderSize = 1;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            saveButton.ForeColor = Color.FromArgb(54, 69, 79);
            saveButton.Location = new Point(48, 235);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 28);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            //
            // usernameTextBox
            //
            usernameTextBox.BackColor = Color.FromArgb(255, 250, 240);
            usernameTextBox.BorderStyle = BorderStyle.FixedSingle;
            usernameTextBox.Font = new Font("Segoe UI", 10F);
            usernameTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            usernameTextBox.Location = new Point(149, 46);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(140, 25);
            usernameTextBox.TabIndex = 1;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.FromArgb(54, 69, 79);
            label1.Location = new Point(54, 47);
            label1.Name = "label1";
            label1.Size = new Size(69, 17);
            label1.TabIndex = 2;
            label1.Text = "Username";
            //
            // forcePasswordUpdateCheckBox
            //
            forcePasswordUpdateCheckBox.AutoSize = true;
            forcePasswordUpdateCheckBox.Checked = true;
            forcePasswordUpdateCheckBox.CheckState = CheckState.Checked;
            forcePasswordUpdateCheckBox.Font = new Font("Segoe UI", 10F);
            forcePasswordUpdateCheckBox.ForeColor = Color.FromArgb(54, 69, 79);
            forcePasswordUpdateCheckBox.Location = new Point(54, 146);
            forcePasswordUpdateCheckBox.Name = "forcePasswordUpdateCheckBox";
            forcePasswordUpdateCheckBox.Size = new Size(178, 19);
            forcePasswordUpdateCheckBox.TabIndex = 3;
            forcePasswordUpdateCheckBox.Text = "Make User Change Password";
            forcePasswordUpdateCheckBox.UseVisualStyleBackColor = true;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = Color.FromArgb(54, 69, 79);
            label2.Location = new Point(54, 91);
            label2.Name = "label2";
            label2.Size = new Size(66, 17);
            label2.TabIndex = 4;
            label2.Text = "Password";
            //
            // passwordTextBox
            //
            passwordTextBox.BackColor = Color.FromArgb(255, 250, 240);
            passwordTextBox.BorderStyle = BorderStyle.FixedSingle;
            passwordTextBox.Font = new Font("Segoe UI", 10F);
            passwordTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            passwordTextBox.Location = new Point(149, 90);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(140, 25);
            passwordTextBox.TabIndex = 5;
            passwordTextBox.Text = "password";
            //
            // adminCheckBox
            //
            adminCheckBox.AutoSize = true;
            adminCheckBox.Font = new Font("Segoe UI", 10F);
            adminCheckBox.ForeColor = Color.FromArgb(54, 69, 79);
            adminCheckBox.Location = new Point(54, 182);
            adminCheckBox.Name = "adminCheckBox";
            adminCheckBox.Size = new Size(120, 19);
            adminCheckBox.TabIndex = 6;
            adminCheckBox.Text = "Make User Admin";
            adminCheckBox.UseVisualStyleBackColor = true;
            //
            // cancelButton
            //
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.BackColor = Color.FromArgb(245, 245, 245);
            cancelButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            cancelButton.FlatAppearance.BorderSize = 1;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            cancelButton.ForeColor = Color.FromArgb(54, 69, 79);
            cancelButton.Location = new Point(310, 235); // Adjusted X for Right anchor
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 28);
            cancelButton.TabIndex = 7;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            //
            // AddUserDialog
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(255, 245, 238);
            CancelButton = cancelButton;
            ClientSize = new Size(432, 309);
            Controls.Add(cancelButton);
            Controls.Add(adminCheckBox);
            Controls.Add(passwordTextBox);
            Controls.Add(label2);
            Controls.Add(forcePasswordUpdateCheckBox);
            Controls.Add(label1);
            Controls.Add(usernameTextBox);
            Controls.Add(saveButton);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(54, 69, 79);
            Name = "AddUserDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add User";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveButton;
        private TextBox usernameTextBox;
        private Label label1;
        private CheckBox forcePasswordUpdateCheckBox;
        private Label label2;
        private TextBox passwordTextBox;
        private CheckBox adminCheckBox;
        private Button cancelButton;
    }
}
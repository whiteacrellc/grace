namespace grace
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pictureBox1 = new PictureBox();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            comboBoxUsers = new ComboBox();
            passwordLabel = new Label();
            pickUserLabel = new Label();
            changePasswordButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(70, 21);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(259, 89);
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = Color.FromArgb(255, 250, 240);
            passwordTextBox.BorderStyle = BorderStyle.FixedSingle;
            passwordTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            passwordTextBox.Location = new Point(181, 192);
            passwordTextBox.Margin = new Padding(4, 3, 4, 3);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(268, 25);
            passwordTextBox.TabIndex = 2;
            // 
            // loginButton
            // 
            loginButton.AutoSize = true;
            loginButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loginButton.BackColor = Color.FromArgb(245, 245, 245);
            loginButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginButton.ForeColor = Color.FromArgb(54, 69, 79);
            loginButton.Location = new Point(181, 243);
            loginButton.Margin = new Padding(4, 3, 4, 3);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(58, 31);
            loginButton.TabIndex = 3;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            // 
            // comboBoxUsers
            // 
            comboBoxUsers.BackColor = Color.FromArgb(255, 250, 240);
            comboBoxUsers.FlatStyle = FlatStyle.Flat;
            comboBoxUsers.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBoxUsers.ForeColor = Color.FromArgb(54, 69, 79);
            comboBoxUsers.FormattingEnabled = true;
            comboBoxUsers.Location = new Point(181, 152);
            comboBoxUsers.Margin = new Padding(4, 3, 4, 3);
            comboBoxUsers.Name = "comboBoxUsers";
            comboBoxUsers.Size = new Size(268, 25);
            comboBoxUsers.TabIndex = 1;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordLabel.ForeColor = Color.FromArgb(54, 69, 79);
            passwordLabel.Location = new Point(70, 195);
            passwordLabel.Margin = new Padding(4, 0, 4, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(73, 19);
            passwordLabel.TabIndex = 23;
            passwordLabel.Text = "Password";
            // 
            // pickUserLabel
            // 
            pickUserLabel.AutoSize = true;
            pickUserLabel.BackColor = Color.Transparent;
            pickUserLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pickUserLabel.ForeColor = Color.FromArgb(54, 69, 79);
            pickUserLabel.Location = new Point(70, 156);
            pickUserLabel.Margin = new Padding(4, 0, 4, 0);
            pickUserLabel.Name = "pickUserLabel";
            pickUserLabel.Size = new Size(76, 19);
            pickUserLabel.TabIndex = 16;
            pickUserLabel.Text = "Username";
            // 
            // changePasswordButton
            // 
            changePasswordButton.AutoSize = true;
            changePasswordButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            changePasswordButton.BackColor = Color.FromArgb(245, 245, 245);
            changePasswordButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            changePasswordButton.FlatStyle = FlatStyle.Flat;
            changePasswordButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            changePasswordButton.ForeColor = Color.FromArgb(54, 69, 79);
            changePasswordButton.Location = new Point(280, 243);
            changePasswordButton.Margin = new Padding(4, 3, 4, 3);
            changePasswordButton.Name = "changePasswordButton";
            changePasswordButton.Size = new Size(139, 31);
            changePasswordButton.TabIndex = 4;
            changePasswordButton.Text = "Change Password";
            changePasswordButton.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 245, 238);
            ClientSize = new Size(534, 315);
            Controls.Add(changePasswordButton);
            Controls.Add(pickUserLabel);
            Controls.Add(passwordLabel);
            Controls.Add(comboBoxUsers);
            Controls.Add(loginButton);
            Controls.Add(passwordTextBox);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4, 3, 4, 3);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label pickUserLabel;
        private System.Windows.Forms.Button changePasswordButton;
    }
}

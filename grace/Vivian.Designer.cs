using MaterialSkin.Controls;

namespace grace
{

    partial class Vivian : MaterialForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vivian));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            openFileDialog = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            editToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            importInventoryToolStripMenuItem = new ToolStripMenuItem();
            saveReportToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            tabControl = new TabControl();
            loginPage = new TabPage();
            passwordGroupBox = new GroupBox();
            loginButton = new Button();
            passwordTextBox = new TextBox();
            comboBoxUsers = new ComboBox();
            label4 = new Label();
            changePasswordButton = new Button();
            label2 = new Label();
            loggedInBox = new GroupBox();
            logoutButton = new Button();
            loggedInLabel = new Label();
            dataPage = new TabPage();
            addRowButton = new Button();
            label1 = new Label();
            filterSkuTextBox = new TextBox();
            dataGridView = new DataGridView();
            checkoutPage = new TabPage();
            label8 = new Label();
            label6 = new Label();
            label7 = new Label();
            autoOpenOnScanCheckBox = new CheckBox();
            coResetButton = new Button();
            checkOutSearchTextBox = new TextBox();
            checkOutDataGrid = new DataGridView();
            textBoxBarcode = new TextBox();
            checkinPage = new TabPage();
            applyChangesButton = new Button();
            allUsersCheckBox = new CheckBox();
            label3 = new Label();
            checkInDataGrid = new DataGridView();
            adminPage = new TabPage();
            loggingTextBox = new TextBox();
            restoreDatabaseButton = new MaterialButton();
            backupButton = new MaterialButton();
            resetPasswordButton = new Button();
            resetComboBox = new ComboBox();
            label5 = new Label();
            errorProvider1 = new ErrorProvider(components);
            checkoutBindingSource = new BindingSource(components);
            checkInBindingSource = new BindingSource(components);
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl.SuspendLayout();
            loginPage.SuspendLayout();
            passwordGroupBox.SuspendLayout();
            loggedInBox.SuspendLayout();
            dataPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            checkoutPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)checkOutDataGrid).BeginInit();
            checkinPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)checkInDataGrid).BeginInit();
            adminPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkoutBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkInBindingSource).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem });
            menuStrip1.Location = new Point(3, 64);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(2137, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, importInventoryToolStripMenuItem, saveReportToolStripMenuItem, exitToolStripMenuItem });
            editToolStripMenuItem.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point);
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(45, 24);
            editToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(200, 24);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // importInventoryToolStripMenuItem
            // 
            importInventoryToolStripMenuItem.Name = "importInventoryToolStripMenuItem";
            importInventoryToolStripMenuItem.Size = new Size(200, 24);
            importInventoryToolStripMenuItem.Text = "Import Inventory";
            importInventoryToolStripMenuItem.Click += importInventoryToolStripMenuItem_Click;
            // 
            // saveReportToolStripMenuItem
            // 
            saveReportToolStripMenuItem.Name = "saveReportToolStripMenuItem";
            saveReportToolStripMenuItem.Size = new Size(200, 24);
            saveReportToolStripMenuItem.Text = "Save Report";
            saveReportToolStripMenuItem.Click += saveReportToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(200, 24);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.AccessibleDescription = "Logo";
            pictureBox1.AccessibleName = "Logo";
            pictureBox1.BackColor = SystemColors.ControlLight;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(10, 17);
            pictureBox1.Margin = new Padding(5, 2, 5, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(348, 123);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(loginPage);
            tabControl.Controls.Add(dataPage);
            tabControl.Controls.Add(checkoutPage);
            tabControl.Controls.Add(checkinPage);
            tabControl.Controls.Add(adminPage);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            tabControl.HotTrack = true;
            tabControl.ItemSize = new Size(200, 40);
            tabControl.Location = new Point(3, 92);
            tabControl.Margin = new Padding(5, 2, 5, 2);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(5, 5);
            tabControl.SelectedIndex = 0;
            tabControl.ShowToolTips = true;
            tabControl.Size = new Size(2137, 1176);
            tabControl.TabIndex = 9;
            tabControl.TabStop = false;
            tabControl.Selecting += tabControl_Selecting;
            // 
            // loginPage
            // 
            loginPage.BorderStyle = BorderStyle.Fixed3D;
            loginPage.Controls.Add(passwordGroupBox);
            loginPage.Controls.Add(pictureBox1);
            loginPage.Controls.Add(loggedInBox);
            loginPage.Location = new Point(4, 44);
            loginPage.Margin = new Padding(5, 2, 5, 2);
            loginPage.Name = "loginPage";
            loginPage.Padding = new Padding(5, 2, 5, 2);
            loginPage.Size = new Size(2129, 1128);
            loginPage.TabIndex = 0;
            loginPage.Text = "Home";
            loginPage.ToolTipText = "Login Page";
            loginPage.UseVisualStyleBackColor = true;
            // 
            // passwordGroupBox
            // 
            passwordGroupBox.Controls.Add(loginButton);
            passwordGroupBox.Controls.Add(passwordTextBox);
            passwordGroupBox.Controls.Add(comboBoxUsers);
            passwordGroupBox.Controls.Add(label4);
            passwordGroupBox.Controls.Add(changePasswordButton);
            passwordGroupBox.Controls.Add(label2);
            passwordGroupBox.Location = new Point(427, 66);
            passwordGroupBox.Name = "passwordGroupBox";
            passwordGroupBox.Size = new Size(470, 242);
            passwordGroupBox.TabIndex = 16;
            passwordGroupBox.TabStop = false;
            // 
            // loginButton
            // 
            loginButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            loginButton.Location = new Point(185, 161);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(121, 29);
            loginButton.TabIndex = 19;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(210, 89);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(198, 26);
            passwordTextBox.TabIndex = 18;
            // 
            // comboBoxUsers
            // 
            comboBoxUsers.FormattingEnabled = true;
            comboBoxUsers.Location = new Point(210, 46);
            comboBoxUsers.Name = "comboBoxUsers";
            comboBoxUsers.Size = new Size(198, 26);
            comboBoxUsers.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 92);
            label4.Name = "label4";
            label4.Size = new Size(88, 18);
            label4.TabIndex = 23;
            label4.Text = "Password";
            // 
            // changePasswordButton
            // 
            changePasswordButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            changePasswordButton.Location = new Point(36, 161);
            changePasswordButton.Name = "changePasswordButton";
            changePasswordButton.Size = new Size(129, 29);
            changePasswordButton.TabIndex = 22;
            changePasswordButton.Text = "Change Password";
            changePasswordButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Location = new Point(36, 54);
            label2.Name = "label2";
            label2.Size = new Size(84, 18);
            label2.TabIndex = 16;
            label2.Text = "Pick User";
            // 
            // loggedInBox
            // 
            loggedInBox.Controls.Add(logoutButton);
            loggedInBox.Controls.Add(loggedInLabel);
            loggedInBox.Location = new Point(427, 91);
            loggedInBox.Name = "loggedInBox";
            loggedInBox.Size = new Size(374, 196);
            loggedInBox.TabIndex = 24;
            loggedInBox.TabStop = false;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(54, 86);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(127, 26);
            logoutButton.TabIndex = 1;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = true;
            // 
            // loggedInLabel
            // 
            loggedInLabel.AutoSize = true;
            loggedInLabel.Location = new Point(54, 39);
            loggedInLabel.Name = "loggedInLabel";
            loggedInLabel.Size = new Size(57, 18);
            loggedInLabel.TabIndex = 0;
            loggedInLabel.Text = "label5";
            // 
            // dataPage
            // 
            dataPage.Controls.Add(addRowButton);
            dataPage.Controls.Add(label1);
            dataPage.Controls.Add(filterSkuTextBox);
            dataPage.Controls.Add(dataGridView);
            dataPage.Location = new Point(4, 44);
            dataPage.Name = "dataPage";
            dataPage.Padding = new Padding(11, 12, 11, 12);
            dataPage.Size = new Size(2109, 1085);
            dataPage.TabIndex = 1;
            dataPage.Text = "Inventory";
            dataPage.ToolTipText = "Inventory for Patti";
            dataPage.UseVisualStyleBackColor = true;
            // 
            // addRowButton
            // 
            addRowButton.Location = new Point(480, 4);
            addRowButton.Name = "addRowButton";
            addRowButton.Size = new Size(103, 38);
            addRowButton.TabIndex = 4;
            addRowButton.Text = "Add Row";
            addRowButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(337, 18);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(90, 18);
            label1.TabIndex = 3;
            label1.Text = "Filter SKU";
            // 
            // filterSkuTextBox
            // 
            filterSkuTextBox.Location = new Point(15, 15);
            filterSkuTextBox.Margin = new Padding(4, 3, 4, 3);
            filterSkuTextBox.Name = "filterSkuTextBox";
            filterSkuTextBox.Size = new Size(314, 26);
            filterSkuTextBox.TabIndex = 2;
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(-4, 46);
            dataGridView.Margin = new Padding(5, 2, 5, 2);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 82;
            dataGridView.RowTemplate.Height = 41;
            dataGridView.Size = new Size(1973, 736);
            dataGridView.TabIndex = 1;
            // 
            // checkoutPage
            // 
            checkoutPage.Controls.Add(label8);
            checkoutPage.Controls.Add(label6);
            checkoutPage.Controls.Add(label7);
            checkoutPage.Controls.Add(autoOpenOnScanCheckBox);
            checkoutPage.Controls.Add(coResetButton);
            checkoutPage.Controls.Add(checkOutSearchTextBox);
            checkoutPage.Controls.Add(checkOutDataGrid);
            checkoutPage.Controls.Add(textBoxBarcode);
            checkoutPage.Location = new Point(4, 44);
            checkoutPage.Margin = new Padding(7);
            checkoutPage.Name = "checkoutPage";
            checkoutPage.Size = new Size(2129, 1128);
            checkoutPage.TabIndex = 2;
            checkoutPage.Text = "Check Out";
            checkoutPage.ToolTipText = "Checkout Items";
            checkoutPage.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1483, 126);
            label8.Name = "label8";
            label8.Size = new Size(104, 18);
            label8.TabIndex = 12;
            label8.Text = "Search SKU";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1483, 58);
            label6.Name = "label6";
            label6.Size = new Size(118, 18);
            label6.TabIndex = 11;
            label6.Text = "Scan Barcode";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.Highlight;
            label7.Location = new Point(1507, 258);
            label7.Name = "label7";
            label7.Size = new Size(397, 77);
            label7.TabIndex = 9;
            label7.Text = "Please go to the Check In screen\r\n to see a list of what you have \r\nchecked out.";
            // 
            // autoOpenOnScanCheckBox
            // 
            autoOpenOnScanCheckBox.AutoSize = true;
            autoOpenOnScanCheckBox.Location = new Point(1483, 88);
            autoOpenOnScanCheckBox.Name = "autoOpenOnScanCheckBox";
            autoOpenOnScanCheckBox.Size = new Size(395, 22);
            autoOpenOnScanCheckBox.TabIndex = 8;
            autoOpenOnScanCheckBox.Text = "Automatically Open Checkout Dialog On Scan";
            autoOpenOnScanCheckBox.UseVisualStyleBackColor = true;
            // 
            // coResetButton
            // 
            coResetButton.Location = new Point(1480, 176);
            coResetButton.Name = "coResetButton";
            coResetButton.Size = new Size(160, 31);
            coResetButton.TabIndex = 7;
            coResetButton.Text = "Show All Data";
            coResetButton.UseVisualStyleBackColor = true;
            // 
            // checkOutSearchTextBox
            // 
            checkOutSearchTextBox.Location = new Point(1650, 118);
            checkOutSearchTextBox.Name = "checkOutSearchTextBox";
            checkOutSearchTextBox.Size = new Size(265, 26);
            checkOutSearchTextBox.TabIndex = 6;
            // 
            // checkOutDataGrid
            // 
            checkOutDataGrid.AllowUserToAddRows = false;
            checkOutDataGrid.AllowUserToDeleteRows = false;
            checkOutDataGrid.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkOutDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            checkOutDataGrid.BorderStyle = BorderStyle.Fixed3D;
            checkOutDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle1.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new Padding(0, 2, 10, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            checkOutDataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            checkOutDataGrid.Location = new Point(0, 374);
            checkOutDataGrid.MultiSelect = false;
            checkOutDataGrid.Name = "checkOutDataGrid";
            checkOutDataGrid.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Padding = new Padding(0, 0, 10, 0);
            checkOutDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            checkOutDataGrid.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            checkOutDataGrid.RowTemplate.DefaultCellStyle.Padding = new Padding(0, 0, 10, 0);
            checkOutDataGrid.RowTemplate.Height = 25;
            checkOutDataGrid.RowTemplate.Resizable = DataGridViewTriState.True;
            checkOutDataGrid.Size = new Size(1177, 758);
            checkOutDataGrid.TabIndex = 4;
            checkOutDataGrid.DataError += checkOutDataGrid_DataError;
            // 
            // textBoxBarcode
            // 
            textBoxBarcode.Location = new Point(1650, 50);
            textBoxBarcode.Margin = new Padding(7);
            textBoxBarcode.Name = "textBoxBarcode";
            textBoxBarcode.Size = new Size(265, 26);
            textBoxBarcode.TabIndex = 2;
            // 
            // checkinPage
            // 
            checkinPage.AutoScroll = true;
            checkinPage.Controls.Add(applyChangesButton);
            checkinPage.Controls.Add(allUsersCheckBox);
            checkinPage.Controls.Add(label3);
            checkinPage.Controls.Add(checkInDataGrid);
            checkinPage.Location = new Point(4, 44);
            checkinPage.Name = "checkinPage";
            checkinPage.Size = new Size(2109, 1085);
            checkinPage.TabIndex = 4;
            checkinPage.Text = "Check In";
            checkinPage.ToolTipText = "Check In Items";
            checkinPage.UseVisualStyleBackColor = true;
            // 
            // applyChangesButton
            // 
            applyChangesButton.Location = new Point(1730, 81);
            applyChangesButton.Name = "applyChangesButton";
            applyChangesButton.Size = new Size(181, 34);
            applyChangesButton.TabIndex = 3;
            applyChangesButton.Text = "Apply Changes";
            applyChangesButton.UseVisualStyleBackColor = true;
            // 
            // allUsersCheckBox
            // 
            allUsersCheckBox.AutoSize = true;
            allUsersCheckBox.Location = new Point(1730, 38);
            allUsersCheckBox.Name = "allUsersCheckBox";
            allUsersCheckBox.Size = new Size(149, 22);
            allUsersCheckBox.TabIndex = 2;
            allUsersCheckBox.Text = "Show All Users";
            allUsersCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1034, 38);
            label3.Name = "label3";
            label3.Size = new Size(0, 18);
            label3.TabIndex = 1;
            // 
            // checkInDataGrid
            // 
            checkInDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkInDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            checkInDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            checkInDataGrid.BorderStyle = BorderStyle.Fixed3D;
            checkInDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            checkInDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            checkInDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            checkInDataGrid.Location = new Point(-30, 3);
            checkInDataGrid.Name = "checkInDataGrid";
            checkInDataGrid.RowTemplate.Height = 25;
            checkInDataGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            checkInDataGrid.Size = new Size(1689, 781);
            checkInDataGrid.TabIndex = 0;
            // 
            // adminPage
            // 
            adminPage.AutoScroll = true;
            adminPage.BackColor = SystemColors.Control;
            adminPage.BorderStyle = BorderStyle.Fixed3D;
            adminPage.Controls.Add(loggingTextBox);
            adminPage.Controls.Add(restoreDatabaseButton);
            adminPage.Controls.Add(backupButton);
            adminPage.Controls.Add(resetPasswordButton);
            adminPage.Controls.Add(resetComboBox);
            adminPage.Controls.Add(label5);
            adminPage.Location = new Point(4, 44);
            adminPage.Name = "adminPage";
            adminPage.Size = new Size(2109, 1085);
            adminPage.TabIndex = 3;
            adminPage.Text = "Admin";
            adminPage.ToolTipText = "Admin Settings";
            // 
            // loggingTextBox
            // 
            loggingTextBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            loggingTextBox.Location = new Point(560, 63);
            loggingTextBox.Multiline = true;
            loggingTextBox.Name = "loggingTextBox";
            loggingTextBox.Size = new Size(593, 553);
            loggingTextBox.TabIndex = 6;
            // 
            // restoreDatabaseButton
            // 
            restoreDatabaseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            restoreDatabaseButton.Density = MaterialButton.MaterialButtonDensity.Default;
            restoreDatabaseButton.Depth = 0;
            restoreDatabaseButton.HighEmphasis = true;
            restoreDatabaseButton.Icon = null;
            restoreDatabaseButton.Location = new Point(53, 266);
            restoreDatabaseButton.Margin = new Padding(4, 6, 4, 6);
            restoreDatabaseButton.MouseState = MaterialSkin.MouseState.HOVER;
            restoreDatabaseButton.Name = "restoreDatabaseButton";
            restoreDatabaseButton.NoAccentTextColor = Color.Empty;
            restoreDatabaseButton.Size = new Size(162, 36);
            restoreDatabaseButton.TabIndex = 5;
            restoreDatabaseButton.Text = "Restore Database";
            restoreDatabaseButton.Type = MaterialButton.MaterialButtonType.Contained;
            restoreDatabaseButton.UseAccentColor = false;
            restoreDatabaseButton.UseVisualStyleBackColor = true;
            // 
            // backupButton
            // 
            backupButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            backupButton.Density = MaterialButton.MaterialButtonDensity.Default;
            backupButton.Depth = 0;
            backupButton.HighEmphasis = true;
            backupButton.Icon = null;
            backupButton.Location = new Point(55, 205);
            backupButton.Margin = new Padding(4, 6, 4, 6);
            backupButton.MouseState = MaterialSkin.MouseState.HOVER;
            backupButton.Name = "backupButton";
            backupButton.NoAccentTextColor = Color.Empty;
            backupButton.Size = new Size(156, 36);
            backupButton.TabIndex = 4;
            backupButton.Text = "Backup Database";
            backupButton.Type = MaterialButton.MaterialButtonType.Contained;
            backupButton.UseAccentColor = false;
            backupButton.UseVisualStyleBackColor = true;
            // 
            // resetPasswordButton
            // 
            resetPasswordButton.Location = new Point(192, 84);
            resetPasswordButton.Name = "resetPasswordButton";
            resetPasswordButton.Size = new Size(194, 29);
            resetPasswordButton.TabIndex = 2;
            resetPasswordButton.Text = "Reset Password";
            resetPasswordButton.UseVisualStyleBackColor = true;
            // 
            // resetComboBox
            // 
            resetComboBox.FormattingEnabled = true;
            resetComboBox.Location = new Point(243, 43);
            resetComboBox.Name = "resetComboBox";
            resetComboBox.Size = new Size(143, 26);
            resetComboBox.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(72, 43);
            label5.Name = "label5";
            label5.Size = new Size(141, 18);
            label5.TabIndex = 0;
            label5.Text = "Reset Password";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Vivian
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(2143, 1271);
            Controls.Add(tabControl);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5, 2, 5, 2);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Vivian";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "VivianGrace";
            Load += Vivian_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl.ResumeLayout(false);
            loginPage.ResumeLayout(false);
            loginPage.PerformLayout();
            passwordGroupBox.ResumeLayout(false);
            passwordGroupBox.PerformLayout();
            loggedInBox.ResumeLayout(false);
            loggedInBox.PerformLayout();
            dataPage.ResumeLayout(false);
            dataPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            checkoutPage.ResumeLayout(false);
            checkoutPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)checkOutDataGrid).EndInit();
            checkinPage.ResumeLayout(false);
            checkinPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)checkInDataGrid).EndInit();
            adminPage.ResumeLayout(false);
            adminPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkoutBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkInBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openFileDialog;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem saveReportToolStripMenuItem;
        private PictureBox pictureBox1;
        private TabPage dataPage;
        private TabPage checkoutPage;
        private Label label1;
        private TabPage adminPage;
        private ErrorProvider errorProvider1;
        private Label label4;
        private Label label2;
        private Label label5;
        private TabPage checkinPage;
        public Label loggedInLabel;
        public ComboBox resetComboBox;
        public Button resetPasswordButton;
        public TabControl tabControl;
        public GroupBox passwordGroupBox;
        public Button loginButton;
        public TextBox passwordTextBox;
        public ComboBox comboBoxUsers;
        public GroupBox loggedInBox;
        internal TextBox filterSkuTextBox;
        internal Button addRowButton;
        internal DataGridView dataGridView;
        internal Button changePasswordButton;
        internal Button logoutButton;
        internal DataGridView checkOutDataGrid;
        internal BindingSource checkoutBindingSource;
        internal TextBox checkOutSearchTextBox;
        internal TextBox textBoxBarcode;
        internal Button coResetButton;
        internal CheckBox autoOpenOnScanCheckBox;
        internal DataGridView checkInDataGrid;
        internal BindingSource checkInBindingSource;
        private Label label3;
        internal CheckBox allUsersCheckBox;
        internal Button applyChangesButton;
        internal ToolStripMenuItem importInventoryToolStripMenuItem;
        private Label label7;
        internal MaterialSkin.Controls.MaterialButton restoreDatabaseButton;
        internal MaterialSkin.Controls.MaterialButton backupButton;
        internal TextBox loggingTextBox;
        internal TabPage loginPage;
        private Label label8;
        private Label label6;
    }
}

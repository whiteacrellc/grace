

namespace grace
{

    partial class Vivian : Form
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
            loggedInLabel = new Label();
            logoutButton = new Button();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            comboBoxUsers = new ComboBox();
            passwordLabel = new Label();
            pickUserLabel = new Label();
            changePasswordButton = new Button();
            dataPage = new TabPage();
            label1 = new Label();
            addRowButton = new Button();
            dataGridView = new DataGridView();
            clearFilterButton = new Button();
            filterSkuTextBox = new TextBox();
            checkoutPage = new TabPage();
            textBoxBarcode = new TextBox();
            checkOutSearchTextBox = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            coResetButton = new Button();
            checkOutDataGrid = new DataGridView();
            checkinPage = new TabPage();
            allUsersCheckBox = new CheckBox();
            applyChangesButton = new Button();
            label3 = new Label();
            checkInDataGrid = new DataGridView();
            adminPage = new TabPage();
            label5 = new Label();
            resetComboBox = new ComboBox();
            button1 = new Button();
            label9 = new Label();
            resetPasswordButton = new Button();
            addUserButton = new Button();
            loggingTextBox = new TextBox();
            restoreDatabaseButton = new Button();
            backupButton = new Button();
            errorProvider1 = new ErrorProvider(components);
            checkoutBindingSource = new BindingSource(components);
            checkInBindingSource = new BindingSource(components);
            textBox1 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl.SuspendLayout();
            loginPage.SuspendLayout();
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
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1620, 28);
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
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(loginPage);
            tabControl.Controls.Add(dataPage);
            tabControl.Controls.Add(checkoutPage);
            tabControl.Controls.Add(checkinPage);
            tabControl.Controls.Add(adminPage);
            tabControl.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            tabControl.HotTrack = true;
            tabControl.ItemSize = new Size(200, 40);
            tabControl.Location = new Point(3, 59);
            tabControl.Margin = new Padding(5, 2, 5, 2);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(5, 5);
            tabControl.SelectedIndex = 0;
            tabControl.ShowToolTips = true;
            tabControl.Size = new Size(2638, 895);
            tabControl.TabIndex = 9;
            tabControl.TabStop = false;
            tabControl.Selecting += tabControl_Selecting;
            // 
            // loginPage
            // 
            loginPage.BorderStyle = BorderStyle.Fixed3D;
            loginPage.Controls.Add(loggedInLabel);
            loginPage.Controls.Add(logoutButton);
            loginPage.Controls.Add(passwordTextBox);
            loginPage.Controls.Add(loginButton);
            loginPage.Controls.Add(comboBoxUsers);
            loginPage.Controls.Add(passwordLabel);
            loginPage.Controls.Add(pictureBox1);
            loginPage.Controls.Add(pickUserLabel);
            loginPage.Controls.Add(changePasswordButton);
            loginPage.Location = new Point(4, 44);
            loginPage.Margin = new Padding(5, 2, 5, 2);
            loginPage.Name = "loginPage";
            loginPage.Padding = new Padding(5, 2, 5, 2);
            loginPage.Size = new Size(2630, 847);
            loginPage.TabIndex = 0;
            loginPage.Text = "Home";
            loginPage.ToolTipText = "Login Page";
            loginPage.UseVisualStyleBackColor = true;
            // 
            // loggedInLabel
            // 
            loggedInLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loggedInLabel.AutoSize = true;
            loggedInLabel.Location = new Point(572, 352);
            loggedInLabel.Name = "loggedInLabel";
            loggedInLabel.Size = new Size(57, 18);
            loggedInLabel.TabIndex = 0;
            loggedInLabel.Text = "label5";
            // 
            // logoutButton
            // 
            logoutButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logoutButton.AutoSize = true;
            logoutButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            logoutButton.Location = new Point(572, 395);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(75, 28);
            logoutButton.TabIndex = 1;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = true;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(690, 193);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(198, 26);
            passwordTextBox.TabIndex = 18;
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loginButton.AutoSize = true;
            loginButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loginButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            loginButton.Location = new Point(800, 246);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(73, 35);
            loginButton.TabIndex = 19;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            // 
            // comboBoxUsers
            // 
            comboBoxUsers.FormattingEnabled = true;
            comboBoxUsers.Location = new Point(690, 153);
            comboBoxUsers.Name = "comboBoxUsers";
            comboBoxUsers.Size = new Size(198, 26);
            comboBoxUsers.TabIndex = 17;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(561, 201);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(88, 18);
            passwordLabel.TabIndex = 23;
            passwordLabel.Text = "Password";
            // 
            // pickUserLabel
            // 
            pickUserLabel.AutoSize = true;
            pickUserLabel.BackColor = SystemColors.Control;
            pickUserLabel.Location = new Point(561, 161);
            pickUserLabel.Name = "pickUserLabel";
            pickUserLabel.Size = new Size(84, 18);
            pickUserLabel.TabIndex = 16;
            pickUserLabel.Text = "Pick User";
            // 
            // changePasswordButton
            // 
            changePasswordButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            changePasswordButton.AutoSize = true;
            changePasswordButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            changePasswordButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            changePasswordButton.Location = new Point(584, 246);
            changePasswordButton.Name = "changePasswordButton";
            changePasswordButton.Size = new Size(179, 35);
            changePasswordButton.TabIndex = 22;
            changePasswordButton.Text = "Change Password";
            changePasswordButton.UseVisualStyleBackColor = true;
            // 
            // dataPage
            // 
            dataPage.Controls.Add(label1);
            dataPage.Controls.Add(addRowButton);
            dataPage.Controls.Add(dataGridView);
            dataPage.Controls.Add(clearFilterButton);
            dataPage.Controls.Add(filterSkuTextBox);
            dataPage.Location = new Point(4, 44);
            dataPage.Name = "dataPage";
            dataPage.Padding = new Padding(11, 12, 11, 12);
            dataPage.Size = new Size(2630, 847);
            dataPage.TabIndex = 1;
            dataPage.Text = "Inventory";
            dataPage.ToolTipText = "Inventory for Patster";
            dataPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(90, 18);
            label1.TabIndex = 3;
            label1.Text = "Filter SKU";
            // 
            // addRowButton
            // 
            addRowButton.Location = new Point(869, 18);
            addRowButton.Name = "addRowButton";
            addRowButton.Size = new Size(135, 48);
            addRowButton.TabIndex = 4;
            addRowButton.Text = "Add Item";
            addRowButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(15, 87);
            dataGridView.Margin = new Padding(5, 2, 5, 2);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 82;
            dataGridView.RowTemplate.Height = 41;
            dataGridView.ScrollBars = ScrollBars.Vertical;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(2601, 738);
            dataGridView.TabIndex = 1;
            // 
            // clearFilterButton
            // 
            clearFilterButton.AutoSize = true;
            clearFilterButton.Location = new Point(599, 20);
            clearFilterButton.Margin = new Padding(4, 6, 4, 6);
            clearFilterButton.Name = "clearFilterButton";
            clearFilterButton.Size = new Size(211, 46);
            clearFilterButton.TabIndex = 5;
            clearFilterButton.Text = "Clear Filter";
            clearFilterButton.UseVisualStyleBackColor = true;
            // 
            // filterSkuTextBox
            // 
            filterSkuTextBox.Location = new Point(244, 20);
            filterSkuTextBox.Margin = new Padding(4, 3, 4, 3);
            filterSkuTextBox.Name = "filterSkuTextBox";
            filterSkuTextBox.Size = new Size(314, 26);
            filterSkuTextBox.TabIndex = 2;
            // 
            // checkoutPage
            // 
            checkoutPage.Controls.Add(textBoxBarcode);
            checkoutPage.Controls.Add(checkOutSearchTextBox);
            checkoutPage.Controls.Add(label6);
            checkoutPage.Controls.Add(label7);
            checkoutPage.Controls.Add(label8);
            checkoutPage.Controls.Add(coResetButton);
            checkoutPage.Controls.Add(checkOutDataGrid);
            checkoutPage.Location = new Point(4, 44);
            checkoutPage.Margin = new Padding(7);
            checkoutPage.Name = "checkoutPage";
            checkoutPage.Size = new Size(2630, 847);
            checkoutPage.TabIndex = 2;
            checkoutPage.Text = "Check Out";
            checkoutPage.ToolTipText = "Checkout Items";
            checkoutPage.UseVisualStyleBackColor = true;
            // 
            // textBoxBarcode
            // 
            textBoxBarcode.Location = new Point(1431, 144);
            textBoxBarcode.Name = "textBoxBarcode";
            textBoxBarcode.Size = new Size(246, 26);
            textBoxBarcode.TabIndex = 13;
            // 
            // checkOutSearchTextBox
            // 
            checkOutSearchTextBox.Location = new Point(1431, 225);
            checkOutSearchTextBox.Name = "checkOutSearchTextBox";
            checkOutSearchTextBox.Size = new Size(259, 26);
            checkOutSearchTextBox.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1146, 152);
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
            label7.Location = new Point(1146, 417);
            label7.Name = "label7";
            label7.Size = new Size(397, 77);
            label7.TabIndex = 9;
            label7.Text = "Please go to the Check In screen\r\n to see a list of what you have \r\nchecked out.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1163, 233);
            label8.Name = "label8";
            label8.Size = new Size(104, 18);
            label8.TabIndex = 12;
            label8.Text = "Search SKU";
            // 
            // coResetButton
            // 
            coResetButton.AutoSize = true;
            coResetButton.Location = new Point(1146, 325);
            coResetButton.Name = "coResetButton";
            coResetButton.Size = new Size(259, 46);
            coResetButton.TabIndex = 7;
            coResetButton.Text = "Show All Data";
            coResetButton.UseVisualStyleBackColor = true;
            // 
            // checkOutDataGrid
            // 
            checkOutDataGrid.AllowUserToAddRows = false;
            checkOutDataGrid.AllowUserToDeleteRows = false;
            checkOutDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkOutDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            checkOutDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
            checkOutDataGrid.Location = new Point(0, 0);
            checkOutDataGrid.MultiSelect = false;
            checkOutDataGrid.Name = "checkOutDataGrid";
            checkOutDataGrid.ReadOnly = true;
            checkOutDataGrid.RowHeadersWidth = 82;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Padding = new Padding(0, 0, 10, 0);
            checkOutDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            checkOutDataGrid.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            checkOutDataGrid.RowTemplate.DefaultCellStyle.Padding = new Padding(0, 0, 10, 0);
            checkOutDataGrid.RowTemplate.Height = 25;
            checkOutDataGrid.RowTemplate.Resizable = DataGridViewTriState.True;
            checkOutDataGrid.Size = new Size(1095, 836);
            checkOutDataGrid.TabIndex = 4;
            checkOutDataGrid.DataError += checkOutDataGrid_DataError;
            // 
            // checkinPage
            // 
            checkinPage.AutoScroll = true;
            checkinPage.Controls.Add(allUsersCheckBox);
            checkinPage.Controls.Add(applyChangesButton);
            checkinPage.Controls.Add(label3);
            checkinPage.Controls.Add(checkInDataGrid);
            checkinPage.Location = new Point(4, 44);
            checkinPage.Name = "checkinPage";
            checkinPage.Size = new Size(2630, 847);
            checkinPage.TabIndex = 4;
            checkinPage.Text = "Check In";
            checkinPage.ToolTipText = "Check In Items";
            checkinPage.UseVisualStyleBackColor = true;
            // 
            // allUsersCheckBox
            // 
            allUsersCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            allUsersCheckBox.AutoSize = true;
            allUsersCheckBox.Location = new Point(1451, 70);
            allUsersCheckBox.Name = "allUsersCheckBox";
            allUsersCheckBox.Size = new Size(149, 22);
            allUsersCheckBox.TabIndex = 2;
            allUsersCheckBox.Text = "Show All Users";
            allUsersCheckBox.UseVisualStyleBackColor = true;
            // 
            // applyChangesButton
            // 
            applyChangesButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            applyChangesButton.AutoSize = true;
            applyChangesButton.Location = new Point(1303, 150);
            applyChangesButton.Name = "applyChangesButton";
            applyChangesButton.Size = new Size(273, 46);
            applyChangesButton.TabIndex = 3;
            applyChangesButton.Text = "Apply Changes";
            applyChangesButton.UseVisualStyleBackColor = true;
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
            checkInDataGrid.Location = new Point(3, 0);
            checkInDataGrid.Name = "checkInDataGrid";
            checkInDataGrid.RowHeadersWidth = 82;
            checkInDataGrid.RowTemplate.Height = 25;
            checkInDataGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            checkInDataGrid.Size = new Size(1247, 836);
            checkInDataGrid.TabIndex = 0;
            // 
            // adminPage
            // 
            adminPage.AutoScroll = true;
            adminPage.BackColor = SystemColors.Control;
            adminPage.BorderStyle = BorderStyle.Fixed3D;
            adminPage.Controls.Add(button5);
            adminPage.Controls.Add(button4);
            adminPage.Controls.Add(button3);
            adminPage.Controls.Add(button2);
            adminPage.Controls.Add(textBox1);
            adminPage.Controls.Add(label5);
            adminPage.Controls.Add(resetComboBox);
            adminPage.Controls.Add(button1);
            adminPage.Controls.Add(label9);
            adminPage.Controls.Add(resetPasswordButton);
            adminPage.Controls.Add(addUserButton);
            adminPage.Controls.Add(loggingTextBox);
            adminPage.Controls.Add(restoreDatabaseButton);
            adminPage.Controls.Add(backupButton);
            adminPage.Location = new Point(4, 44);
            adminPage.Name = "adminPage";
            adminPage.Size = new Size(2630, 847);
            adminPage.TabIndex = 3;
            adminPage.Text = "Admin";
            adminPage.ToolTipText = "Admin Settings";
            adminPage.Click += adminPage_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(49, 97);
            label5.Name = "label5";
            label5.Size = new Size(84, 18);
            label5.TabIndex = 0;
            label5.Text = "Pick User";
            // 
            // resetComboBox
            // 
            resetComboBox.FormattingEnabled = true;
            resetComboBox.Location = new Point(255, 94);
            resetComboBox.Name = "resetComboBox";
            resetComboBox.Size = new Size(194, 26);
            resetComboBox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(49, 239);
            button1.Name = "button1";
            button1.Size = new Size(400, 50);
            button1.TabIndex = 8;
            button1.Text = "Delete User";
            button1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(1089, 34);
            label9.Name = "label9";
            label9.Size = new Size(224, 23);
            label9.TabIndex = 9;
            label9.Text = "Application Logging";
            // 
            // resetPasswordButton
            // 
            resetPasswordButton.Location = new Point(79, 164);
            resetPasswordButton.Name = "resetPasswordButton";
            resetPasswordButton.Size = new Size(380, 53);
            resetPasswordButton.TabIndex = 2;
            resetPasswordButton.Text = "Reset Password";
            resetPasswordButton.UseVisualStyleBackColor = true;
            // 
            // addUserButton
            // 
            addUserButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addUserButton.Location = new Point(38, 318);
            addUserButton.Margin = new Padding(4, 6, 4, 6);
            addUserButton.Name = "addUserButton";
            addUserButton.Size = new Size(411, 57);
            addUserButton.TabIndex = 9;
            addUserButton.Text = "Add User";
            addUserButton.UseVisualStyleBackColor = true;
            // 
            // loggingTextBox
            // 
            loggingTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            loggingTextBox.BackColor = Color.FromArgb(255, 255, 255);
            loggingTextBox.BorderStyle = BorderStyle.FixedSingle;
            loggingTextBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            loggingTextBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            loggingTextBox.Location = new Point(1234, 94);
            loggingTextBox.Multiline = true;
            loggingTextBox.Name = "loggingTextBox";
            loggingTextBox.ScrollBars = ScrollBars.Vertical;
            loggingTextBox.Size = new Size(1365, 732);
            loggingTextBox.TabIndex = 7;
            loggingTextBox.TextChanged += loggingTextBox_TextChanged;
            // 
            // restoreDatabaseButton
            // 
            restoreDatabaseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            restoreDatabaseButton.Location = new Point(36, 472);
            restoreDatabaseButton.Margin = new Padding(4, 6, 4, 6);
            restoreDatabaseButton.Name = "restoreDatabaseButton";
            restoreDatabaseButton.Size = new Size(162, 56);
            restoreDatabaseButton.TabIndex = 5;
            restoreDatabaseButton.Text = "Restore Database";
            restoreDatabaseButton.UseVisualStyleBackColor = true;
            // 
            // backupButton
            // 
            backupButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            backupButton.Location = new Point(38, 411);
            backupButton.Margin = new Padding(4, 6, 4, 6);
            backupButton.Name = "backupButton";
            backupButton.Size = new Size(183, 49);
            backupButton.TabIndex = 4;
            backupButton.Text = "Backup Database";
            backupButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(542, 128);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(217, 26);
            textBox1.TabIndex = 11;
            // 
            // button2
            // 
            button2.Location = new Point(542, 179);
            button2.Name = "button2";
            button2.Size = new Size(154, 38);
            button2.TabIndex = 12;
            button2.Text = "Add Category";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(1236, 402);
            button3.Name = "button3";
            button3.Size = new Size(154, 38);
            button3.TabIndex = 13;
            button3.Text = "Add Category";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(1244, 410);
            button4.Name = "button4";
            button4.Size = new Size(154, 38);
            button4.TabIndex = 14;
            button4.Text = "Add Category";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(542, 239);
            button5.Name = "button5";
            button5.Size = new Size(154, 33);
            button5.TabIndex = 15;
            button5.Text = "Delete Category";
            button5.UseVisualStyleBackColor = true;
            // 
            // Vivian
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(1620, 957);
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
        private TabPage adminPage;
        private ErrorProvider errorProvider1;
        private Label label5;
        private TabPage checkinPage;
        public Label loggedInLabel;
        public ComboBox resetComboBox;
        public Button resetPasswordButton;
        public TabControl tabControl;
        public Button loginButton;
        public TextBox passwordTextBox;
        public ComboBox comboBoxUsers;
        internal Button changePasswordButton;
        internal Button logoutButton;
        internal DataGridView checkOutDataGrid;
        internal BindingSource checkoutBindingSource;
        internal Button coResetButton;
        internal DataGridView checkInDataGrid;
        internal BindingSource checkInBindingSource;
        private Label label3;
        internal CheckBox allUsersCheckBox;
        internal Button applyChangesButton;
        internal ToolStripMenuItem importInventoryToolStripMenuItem;
        private Label label7;
        internal Button restoreDatabaseButton;
        internal Button backupButton;
        internal TabPage loginPage;
        private Label label8;
        private Label label6;
        internal TextBox loggingTextBox;
        internal TextBox checkOutSearchTextBox;
        internal TextBox textBoxBarcode;
        private Button addUserButton;
        public Button button1;
        private Label label9;
        private Label label1;
        internal DataGridView dataGridView;
        internal Button addRowButton;
        internal Button clearFilterButton;
        internal TextBox filterSkuTextBox;
        internal Label passwordLabel;
        internal Label pickUserLabel;
        private TextBox textBox1;
        private Button button2;
        private Button button5;
        private Button button4;
        private Button button3;
    }
}

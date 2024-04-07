

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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
            clearFilterButton = new Button();
            addRowButton = new Button();
            label1 = new Label();
            filterSkuTextBox = new TextBox();
            dataGridView = new DataGridView();
            checkoutPage = new TabPage();
            checkOutSearchTextBox = new TextBox();
            textBoxBarcode = new TextBox();
            label8 = new Label();
            label6 = new Label();
            label7 = new Label();
            autoOpenOnScanCheckBox = new CheckBox();
            coResetButton = new Button();
            checkOutDataGrid = new DataGridView();
            checkinPage = new TabPage();
            applyChangesButton = new Button();
            allUsersCheckBox = new CheckBox();
            label3 = new Label();
            checkInDataGrid = new DataGridView();
            adminPage = new TabPage();
            addUserButton = new Button();
            button1 = new Button();
            loggingTextBox = new TextBox();
            restoreDatabaseButton = new Button();
            backupButton = new Button();
            resetPasswordButton = new Button();
            resetComboBox = new ComboBox();
            label5 = new Label();
            errorProvider1 = new ErrorProvider(components);
            checkoutBindingSource = new BindingSource(components);
            checkInBindingSource = new BindingSource(components);
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            label9 = new Label();
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
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
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
            menuStrip1.Size = new Size(2348, 28);
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
            tabControl.Location = new Point(3, 30);
            tabControl.Margin = new Padding(5, 2, 5, 2);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(5, 5);
            tabControl.SelectedIndex = 0;
            tabControl.ShowToolTips = true;
            tabControl.Size = new Size(2342, 924);
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
            loginPage.Size = new Size(2334, 876);
            loginPage.TabIndex = 0;
            loginPage.Text = "Home";
            loginPage.ToolTipText = "Login Page";
            loginPage.UseVisualStyleBackColor = true;
            // 
            // passwordGroupBox
            // 
            passwordGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            passwordGroupBox.AutoSize = true;
            passwordGroupBox.Controls.Add(loginButton);
            passwordGroupBox.Controls.Add(passwordTextBox);
            passwordGroupBox.Controls.Add(comboBoxUsers);
            passwordGroupBox.Controls.Add(label4);
            passwordGroupBox.Controls.Add(changePasswordButton);
            passwordGroupBox.Controls.Add(label2);
            passwordGroupBox.Location = new Point(545, 73);
            passwordGroupBox.Name = "passwordGroupBox";
            passwordGroupBox.Size = new Size(445, 542);
            passwordGroupBox.TabIndex = 16;
            passwordGroupBox.TabStop = false;
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loginButton.AutoSize = true;
            loginButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loginButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            loginButton.Location = new Point(210, 163);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(50, 27);
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
            changePasswordButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            changePasswordButton.AutoSize = true;
            changePasswordButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            changePasswordButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            changePasswordButton.Location = new Point(47, 163);
            changePasswordButton.Name = "changePasswordButton";
            changePasswordButton.Size = new Size(122, 27);
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
            loggedInBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loggedInBox.AutoSize = true;
            loggedInBox.Controls.Add(logoutButton);
            loggedInBox.Controls.Add(loggedInLabel);
            loggedInBox.Location = new Point(615, 89);
            loggedInBox.Name = "loggedInBox";
            loggedInBox.Size = new Size(298, 136);
            loggedInBox.TabIndex = 24;
            loggedInBox.TabStop = false;
            // 
            // logoutButton
            // 
            logoutButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logoutButton.AutoSize = true;
            logoutButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            logoutButton.Location = new Point(54, 86);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(75, 28);
            logoutButton.TabIndex = 1;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = true;
            // 
            // loggedInLabel
            // 
            loggedInLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loggedInLabel.AutoSize = true;
            loggedInLabel.Location = new Point(54, 39);
            loggedInLabel.Name = "loggedInLabel";
            loggedInLabel.Size = new Size(57, 18);
            loggedInLabel.TabIndex = 0;
            loggedInLabel.Text = "label5";
            // 
            // dataPage
            // 
            dataPage.Controls.Add(groupBox1);
            dataPage.Controls.Add(dataGridView);
            dataPage.Location = new Point(4, 44);
            dataPage.Name = "dataPage";
            dataPage.Padding = new Padding(11, 12, 11, 12);
            dataPage.Size = new Size(2334, 876);
            dataPage.TabIndex = 1;
            dataPage.Text = "Inventory";
            dataPage.ToolTipText = "Inventory for Patster";
            dataPage.UseVisualStyleBackColor = true;
            // 
            // clearFilterButton
            // 
            clearFilterButton.AutoSize = true;
            clearFilterButton.Location = new Point(591, 25);
            clearFilterButton.Margin = new Padding(4, 6, 4, 6);
            clearFilterButton.Name = "clearFilterButton";
            clearFilterButton.Size = new Size(127, 38);
            clearFilterButton.TabIndex = 5;
            clearFilterButton.Text = "Clear Filter";
            clearFilterButton.UseVisualStyleBackColor = true;
            // 
            // addRowButton
            // 
            addRowButton.Location = new Point(734, 25);
            addRowButton.Name = "addRowButton";
            addRowButton.Size = new Size(122, 38);
            addRowButton.TabIndex = 4;
            addRowButton.Text = "Add Item";
            addRowButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(97, 35);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(90, 18);
            label1.TabIndex = 3;
            label1.Text = "Filter SKU";
            // 
            // filterSkuTextBox
            // 
            filterSkuTextBox.Location = new Point(233, 35);
            filterSkuTextBox.Margin = new Padding(4, 3, 4, 3);
            filterSkuTextBox.Name = "filterSkuTextBox";
            filterSkuTextBox.Size = new Size(314, 26);
            filterSkuTextBox.TabIndex = 2;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(5, 92);
            dataGridView.Margin = new Padding(5, 2, 5, 2);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 82;
            dataGridView.RowTemplate.Height = 41;
            dataGridView.ScrollBars = ScrollBars.Vertical;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(2329, 784);
            dataGridView.TabIndex = 1;
            // 
            // checkoutPage
            // 
            checkoutPage.Controls.Add(groupBox2);
            checkoutPage.Controls.Add(checkOutDataGrid);
            checkoutPage.Location = new Point(4, 44);
            checkoutPage.Margin = new Padding(7);
            checkoutPage.Name = "checkoutPage";
            checkoutPage.Size = new Size(2334, 876);
            checkoutPage.TabIndex = 2;
            checkoutPage.Text = "Check Out";
            checkoutPage.ToolTipText = "Checkout Items";
            checkoutPage.UseVisualStyleBackColor = true;
            // 
            // checkOutSearchTextBox
            // 
            checkOutSearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkOutSearchTextBox.Location = new Point(164, 109);
            checkOutSearchTextBox.Name = "checkOutSearchTextBox";
            checkOutSearchTextBox.Size = new Size(203, 26);
            checkOutSearchTextBox.TabIndex = 14;
            // 
            // textBoxBarcode
            // 
            textBoxBarcode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxBarcode.Location = new Point(164, 46);
            textBoxBarcode.Name = "textBoxBarcode";
            textBoxBarcode.Size = new Size(203, 26);
            textBoxBarcode.TabIndex = 13;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(28, 117);
            label8.Name = "label8";
            label8.Size = new Size(104, 18);
            label8.TabIndex = 12;
            label8.Text = "Search SKU";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(28, 49);
            label6.Name = "label6";
            label6.Size = new Size(118, 18);
            label6.TabIndex = 11;
            label6.Text = "Scan Barcode";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.Highlight;
            label7.Location = new Point(17, 287);
            label7.Name = "label7";
            label7.Size = new Size(397, 77);
            label7.TabIndex = 9;
            label7.Text = "Please go to the Check In screen\r\n to see a list of what you have \r\nchecked out.";
            // 
            // autoOpenOnScanCheckBox
            // 
            autoOpenOnScanCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            autoOpenOnScanCheckBox.AutoSize = true;
            autoOpenOnScanCheckBox.Location = new Point(28, 161);
            autoOpenOnScanCheckBox.Name = "autoOpenOnScanCheckBox";
            autoOpenOnScanCheckBox.Size = new Size(395, 22);
            autoOpenOnScanCheckBox.TabIndex = 8;
            autoOpenOnScanCheckBox.Text = "Automatically Open Checkout Dialog On Scan";
            autoOpenOnScanCheckBox.UseVisualStyleBackColor = true;
            // 
            // coResetButton
            // 
            coResetButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            coResetButton.AutoSize = true;
            coResetButton.Location = new Point(28, 194);
            coResetButton.Name = "coResetButton";
            coResetButton.Size = new Size(132, 28);
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle3.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(0, 2, 10, 0);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            checkOutDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            checkOutDataGrid.Location = new Point(0, 0);
            checkOutDataGrid.MultiSelect = false;
            checkOutDataGrid.Name = "checkOutDataGrid";
            checkOutDataGrid.ReadOnly = true;
            checkOutDataGrid.RowHeadersWidth = 82;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Padding = new Padding(0, 0, 10, 0);
            checkOutDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            checkOutDataGrid.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            checkOutDataGrid.RowTemplate.DefaultCellStyle.Padding = new Padding(0, 0, 10, 0);
            checkOutDataGrid.RowTemplate.Height = 25;
            checkOutDataGrid.RowTemplate.Resizable = DataGridViewTriState.True;
            checkOutDataGrid.Size = new Size(1095, 873);
            checkOutDataGrid.TabIndex = 4;
            checkOutDataGrid.DataError += checkOutDataGrid_DataError;
            // 
            // checkinPage
            // 
            checkinPage.AutoScroll = true;
            checkinPage.Controls.Add(groupBox3);
            checkinPage.Controls.Add(label3);
            checkinPage.Controls.Add(checkInDataGrid);
            checkinPage.Location = new Point(4, 44);
            checkinPage.Name = "checkinPage";
            checkinPage.Size = new Size(2334, 876);
            checkinPage.TabIndex = 4;
            checkinPage.Text = "Check In";
            checkinPage.ToolTipText = "Check In Items";
            checkinPage.UseVisualStyleBackColor = true;
            // 
            // applyChangesButton
            // 
            applyChangesButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            applyChangesButton.AutoSize = true;
            applyChangesButton.Location = new Point(56, 89);
            applyChangesButton.Name = "applyChangesButton";
            applyChangesButton.Size = new Size(139, 28);
            applyChangesButton.TabIndex = 3;
            applyChangesButton.Text = "Apply Changes";
            applyChangesButton.UseVisualStyleBackColor = true;
            // 
            // allUsersCheckBox
            // 
            allUsersCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            allUsersCheckBox.AutoSize = true;
            allUsersCheckBox.Location = new Point(56, 46);
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
            checkInDataGrid.Location = new Point(3, 0);
            checkInDataGrid.Name = "checkInDataGrid";
            checkInDataGrid.RowHeadersWidth = 82;
            checkInDataGrid.RowTemplate.Height = 25;
            checkInDataGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            checkInDataGrid.Size = new Size(1247, 873);
            checkInDataGrid.TabIndex = 0;
            // 
            // adminPage
            // 
            adminPage.AutoScroll = true;
            adminPage.BackColor = SystemColors.Control;
            adminPage.BorderStyle = BorderStyle.Fixed3D;
            adminPage.Controls.Add(label9);
            adminPage.Controls.Add(groupBox4);
            adminPage.Controls.Add(addUserButton);
            adminPage.Controls.Add(loggingTextBox);
            adminPage.Controls.Add(restoreDatabaseButton);
            adminPage.Controls.Add(backupButton);
            adminPage.Location = new Point(4, 44);
            adminPage.Name = "adminPage";
            adminPage.Size = new Size(2334, 876);
            adminPage.TabIndex = 3;
            adminPage.Text = "Admin";
            adminPage.ToolTipText = "Admin Settings";
            // 
            // addUserButton
            // 
            addUserButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addUserButton.Location = new Point(684, 142);
            addUserButton.Margin = new Padding(4, 6, 4, 6);
            addUserButton.Name = "addUserButton";
            addUserButton.Size = new Size(90, 36);
            addUserButton.TabIndex = 9;
            addUserButton.Text = "Add User";
            addUserButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(188, 158);
            button1.Name = "button1";
            button1.Size = new Size(194, 29);
            button1.TabIndex = 8;
            button1.Text = "Delete User";
            button1.UseVisualStyleBackColor = true;
            // 
            // loggingTextBox
            // 
            loggingTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            loggingTextBox.BackColor = Color.FromArgb(255, 255, 255);
            loggingTextBox.BorderStyle = BorderStyle.FixedSingle;
            loggingTextBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            loggingTextBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            loggingTextBox.Location = new Point(1075, 88);
            loggingTextBox.Multiline = true;
            loggingTextBox.Name = "loggingTextBox";
            loggingTextBox.ScrollBars = ScrollBars.Vertical;
            loggingTextBox.Size = new Size(1071, 770);
            loggingTextBox.TabIndex = 7;
            loggingTextBox.TextChanged += loggingTextBox_TextChanged;
            // 
            // restoreDatabaseButton
            // 
            restoreDatabaseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            restoreDatabaseButton.Location = new Point(36, 472);
            restoreDatabaseButton.Margin = new Padding(4, 6, 4, 6);
            restoreDatabaseButton.Name = "restoreDatabaseButton";
            restoreDatabaseButton.Size = new Size(162, 36);
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
            backupButton.Size = new Size(156, 36);
            backupButton.TabIndex = 4;
            backupButton.Text = "Backup Database";
            backupButton.UseVisualStyleBackColor = true;
            // 
            // resetPasswordButton
            // 
            resetPasswordButton.Location = new Point(188, 113);
            resetPasswordButton.Name = "resetPasswordButton";
            resetPasswordButton.Size = new Size(194, 29);
            resetPasswordButton.TabIndex = 2;
            resetPasswordButton.Text = "Reset Password";
            resetPasswordButton.UseVisualStyleBackColor = true;
            // 
            // resetComboBox
            // 
            resetComboBox.FormattingEnabled = true;
            resetComboBox.Location = new Point(188, 72);
            resetComboBox.Name = "resetComboBox";
            resetComboBox.Size = new Size(194, 26);
            resetComboBox.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(68, 72);
            label5.Name = "label5";
            label5.Size = new Size(84, 18);
            label5.TabIndex = 0;
            label5.Text = "Pick User";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(addRowButton);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(clearFilterButton);
            groupBox1.Controls.Add(filterSkuTextBox);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(879, 91);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(checkOutSearchTextBox);
            groupBox2.Controls.Add(textBoxBarcode);
            groupBox2.Controls.Add(coResetButton);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(autoOpenOnScanCheckBox);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(1164, 28);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(433, 386);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox3.Controls.Add(allUsersCheckBox);
            groupBox3.Controls.Add(applyChangesButton);
            groupBox3.Location = new Point(1437, 34);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(257, 146);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            groupBox4.AutoSize = true;
            groupBox4.Controls.Add(resetComboBox);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(button1);
            groupBox4.Controls.Add(resetPasswordButton);
            groupBox4.Location = new Point(24, 88);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(473, 239);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "Edit Users";
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
            // Vivian
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(2348, 957);
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
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
        internal Button coResetButton;
        internal CheckBox autoOpenOnScanCheckBox;
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
        internal Button clearFilterButton;
        private Button addUserButton;
        public Button button1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label9;
        private GroupBox groupBox4;
    }
}



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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            openFileDialog = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            editToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            importInventoryToolStripMenuItem = new ToolStripMenuItem();
            saveInventoryReportToolStripMenuItem = new ToolStripMenuItem();
            saveReportToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            setInventoryFontSizeToolStripMenuItem = new ToolStripMenuItem();
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
            filterBarcodeTextBox = new TextBox();
            scanBarcodeLabel = new Label();
            filterRowsLabel = new Label();
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
            reportPage = new TabPage();
            filterLable = new Label();
            reportFilterTextBox = new TextBox();
            refreshButton = new Button();
            label2 = new Label();
            label1 = new Label();
            endTimePicker = new DateTimePicker();
            startTimePicker = new DateTimePicker();
            reportGridView = new DataGridView();
            adminPage = new TabPage();
            label5 = new Label();
            resetComboBox = new ComboBox();
            deleteUserButton = new Button();
            label9 = new Label();
            resetPasswordButton = new Button();
            addUserButton = new Button();
            loggingTextBox = new TextBox();
            restoreDatabaseButton = new Button();
            backupButton = new Button();
            errorProvider1 = new ErrorProvider(components);
            checkoutBindingSource = new BindingSource(components);
            checkInBindingSource = new BindingSource(components);
            toolTip = new ToolTip(components);
            showAllButton = new Button();
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
            reportPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)reportGridView).BeginInit();
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
            menuStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, viewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1539, 29);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, importInventoryToolStripMenuItem, saveInventoryReportToolStripMenuItem, saveReportToolStripMenuItem, exitToolStripMenuItem });
            editToolStripMenuItem.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold);
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(45, 25);
            editToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(235, 24);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // importInventoryToolStripMenuItem
            // 
            importInventoryToolStripMenuItem.Name = "importInventoryToolStripMenuItem";
            importInventoryToolStripMenuItem.Size = new Size(235, 24);
            importInventoryToolStripMenuItem.Text = "Import Inventory";
            importInventoryToolStripMenuItem.Click += importInventoryToolStripMenuItem_Click;
            // 
            // saveInventoryReportToolStripMenuItem
            // 
            saveInventoryReportToolStripMenuItem.Name = "saveInventoryReportToolStripMenuItem";
            saveInventoryReportToolStripMenuItem.Size = new Size(235, 24);
            saveInventoryReportToolStripMenuItem.Text = "Save Inventory Report";
            // 
            // saveReportToolStripMenuItem
            // 
            saveReportToolStripMenuItem.Name = "saveReportToolStripMenuItem";
            saveReportToolStripMenuItem.Size = new Size(235, 24);
            saveReportToolStripMenuItem.Text = "Save Collection Report";
            saveReportToolStripMenuItem.Click += saveReportToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(235, 24);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setInventoryFontSizeToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(60, 25);
            viewToolStripMenuItem.Text = "View";
            // 
            // setInventoryFontSizeToolStripMenuItem
            // 
            setInventoryFontSizeToolStripMenuItem.Name = "setInventoryFontSizeToolStripMenuItem";
            setInventoryFontSizeToolStripMenuItem.Size = new Size(256, 26);
            setInventoryFontSizeToolStripMenuItem.Text = "Set Inventory Font Size";
            // 
            // pictureBox1
            // 
            pictureBox1.AccessibleDescription = "Logo";
            pictureBox1.AccessibleName = "Logo";
            pictureBox1.BackColor = SystemColors.ControlLight;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(15, 17);
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
            tabControl.Appearance = TabAppearance.Buttons;
            tabControl.Controls.Add(loginPage);
            tabControl.Controls.Add(dataPage);
            tabControl.Controls.Add(checkoutPage);
            tabControl.Controls.Add(checkinPage);
            tabControl.Controls.Add(reportPage);
            tabControl.Controls.Add(adminPage);
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.Font = new Font("Verdana", 11.25F, FontStyle.Bold);
            tabControl.HotTrack = true;
            tabControl.ItemSize = new Size(200, 40);
            tabControl.Location = new Point(0, 31);
            tabControl.Margin = new Padding(5, 2, 5, 2);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(30, 5);
            tabControl.SelectedIndex = 0;
            tabControl.ShowToolTips = true;
            tabControl.Size = new Size(1539, 792);
            tabControl.TabIndex = 9;
            tabControl.TabStop = false;
            tabControl.DrawItem += tabControl_DrawItem;
            tabControl.Selecting += tabControl_Selecting;
            // 
            // loginPage
            // 
            loginPage.BackColor = Color.Lavender;
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
            loginPage.Padding = new Padding(10, 2, 10, 2);
            loginPage.Size = new Size(1531, 744);
            loginPage.TabIndex = 0;
            loginPage.Text = "Home";
            loginPage.ToolTipText = "Login Page";
            // 
            // loggedInLabel
            // 
            loggedInLabel.AutoSize = true;
            loggedInLabel.Location = new Point(266, 452);
            loggedInLabel.Name = "loggedInLabel";
            loggedInLabel.Size = new Size(57, 18);
            loggedInLabel.TabIndex = 0;
            loggedInLabel.Text = "label5";
            // 
            // logoutButton
            // 
            logoutButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            logoutButton.Location = new Point(247, 490);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(116, 33);
            logoutButton.TabIndex = 1;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = true;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(448, 301);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(230, 26);
            passwordTextBox.TabIndex = 18;
            // 
            // loginButton
            // 
            loginButton.AutoSize = true;
            loginButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loginButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            loginButton.Location = new Point(498, 371);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(73, 35);
            loginButton.TabIndex = 19;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            // 
            // comboBoxUsers
            // 
            comboBoxUsers.FormattingEnabled = true;
            comboBoxUsers.Location = new Point(448, 242);
            comboBoxUsers.Name = "comboBoxUsers";
            comboBoxUsers.Size = new Size(230, 26);
            comboBoxUsers.TabIndex = 17;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(254, 309);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(88, 18);
            passwordLabel.TabIndex = 23;
            passwordLabel.Text = "Password";
            // 
            // pickUserLabel
            // 
            pickUserLabel.AutoSize = true;
            pickUserLabel.BackColor = Color.Transparent;
            pickUserLabel.Location = new Point(254, 245);
            pickUserLabel.Name = "pickUserLabel";
            pickUserLabel.Size = new Size(84, 18);
            pickUserLabel.TabIndex = 16;
            pickUserLabel.Text = "Pick User";
            // 
            // changePasswordButton
            // 
            changePasswordButton.AutoSize = true;
            changePasswordButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            changePasswordButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            changePasswordButton.Location = new Point(254, 371);
            changePasswordButton.Name = "changePasswordButton";
            changePasswordButton.Size = new Size(179, 35);
            changePasswordButton.TabIndex = 22;
            changePasswordButton.Text = "Change Password";
            changePasswordButton.UseVisualStyleBackColor = true;
            // 
            // dataPage
            // 
            dataPage.BackColor = Color.Lavender;
            dataPage.BorderStyle = BorderStyle.Fixed3D;
            dataPage.Controls.Add(filterBarcodeTextBox);
            dataPage.Controls.Add(scanBarcodeLabel);
            dataPage.Controls.Add(filterRowsLabel);
            dataPage.Controls.Add(addRowButton);
            dataPage.Controls.Add(dataGridView);
            dataPage.Controls.Add(clearFilterButton);
            dataPage.Controls.Add(filterSkuTextBox);
            dataPage.Location = new Point(4, 44);
            dataPage.Name = "dataPage";
            dataPage.Padding = new Padding(1);
            dataPage.Size = new Size(1531, 744);
            dataPage.TabIndex = 1;
            dataPage.Text = "Inventory";
            dataPage.ToolTipText = "Inventory for Patster";
            dataPage.Click += dataPage_Click;
            dataPage.Paint += dataPage_Paint;
            // 
            // filterBarcodeTextBox
            // 
            filterBarcodeTextBox.Location = new Point(730, 13);
            filterBarcodeTextBox.Name = "filterBarcodeTextBox";
            filterBarcodeTextBox.Size = new Size(202, 26);
            filterBarcodeTextBox.TabIndex = 7;
            // 
            // scanBarcodeLabel
            // 
            scanBarcodeLabel.AutoSize = true;
            scanBarcodeLabel.Location = new Point(600, 16);
            scanBarcodeLabel.Margin = new Padding(4, 0, 4, 0);
            scanBarcodeLabel.Name = "scanBarcodeLabel";
            scanBarcodeLabel.Size = new Size(123, 18);
            scanBarcodeLabel.TabIndex = 6;
            scanBarcodeLabel.Text = "Scan  Barcode";
            scanBarcodeLabel.MouseHover += scanBarcodeLabel_MouseHover;
            // 
            // filterRowsLabel
            // 
            filterRowsLabel.AutoSize = true;
            filterRowsLabel.Location = new Point(206, 13);
            filterRowsLabel.Margin = new Padding(4, 0, 4, 0);
            filterRowsLabel.Name = "filterRowsLabel";
            filterRowsLabel.Size = new Size(100, 18);
            filterRowsLabel.TabIndex = 3;
            filterRowsLabel.Text = "Filter Rows";
            filterRowsLabel.MouseHover += filterRowsLabel_MouseHover;
            // 
            // addRowButton
            // 
            addRowButton.Location = new Point(41, 8);
            addRowButton.Name = "addRowButton";
            addRowButton.Size = new Size(118, 35);
            addRowButton.TabIndex = 4;
            addRowButton.Text = "Add Item";
            addRowButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BorderStyle = BorderStyle.Fixed3D;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Verdana", 9.75F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.Location = new Point(6, 53);
            dataGridView.Margin = new Padding(5, 2, 5, 2);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 82;
            dataGridView.RowTemplate.Height = 41;
            dataGridView.ScrollBars = ScrollBars.Vertical;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(1513, 674);
            dataGridView.TabIndex = 1;
            // 
            // clearFilterButton
            // 
            clearFilterButton.AutoSize = true;
            clearFilterButton.Location = new Point(959, 8);
            clearFilterButton.Margin = new Padding(4, 6, 4, 6);
            clearFilterButton.Name = "clearFilterButton";
            clearFilterButton.Size = new Size(147, 32);
            clearFilterButton.TabIndex = 5;
            clearFilterButton.Text = "Clear Filter";
            clearFilterButton.UseVisualStyleBackColor = true;
            // 
            // filterSkuTextBox
            // 
            filterSkuTextBox.Location = new Point(362, 13);
            filterSkuTextBox.Margin = new Padding(4, 3, 4, 3);
            filterSkuTextBox.Name = "filterSkuTextBox";
            filterSkuTextBox.Size = new Size(217, 26);
            filterSkuTextBox.TabIndex = 2;
            // 
            // checkoutPage
            // 
            checkoutPage.BackColor = Color.Lavender;
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
            checkoutPage.Size = new Size(1531, 744);
            checkoutPage.TabIndex = 2;
            checkoutPage.Text = "Check Out";
            checkoutPage.ToolTipText = "Checkout Items";
            // 
            // textBoxBarcode
            // 
            textBoxBarcode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxBarcode.Location = new Point(1259, 144);
            textBoxBarcode.Name = "textBoxBarcode";
            textBoxBarcode.Size = new Size(246, 26);
            textBoxBarcode.TabIndex = 13;
            // 
            // checkOutSearchTextBox
            // 
            checkOutSearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkOutSearchTextBox.Location = new Point(1246, 190);
            checkOutSearchTextBox.Name = "checkOutSearchTextBox";
            checkOutSearchTextBox.Size = new Size(259, 26);
            checkOutSearchTextBox.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1132, 152);
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
            label7.Font = new Font("Verdana", 15.75F, FontStyle.Bold);
            label7.ForeColor = SystemColors.Highlight;
            label7.Location = new Point(1134, 427);
            label7.Name = "label7";
            label7.Size = new Size(397, 77);
            label7.TabIndex = 9;
            label7.Text = "Please go to the Check In screen\r\n to see a list of what you have \r\nchecked out.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1131, 198);
            label8.Name = "label8";
            label8.Size = new Size(104, 18);
            label8.TabIndex = 12;
            label8.Text = "Search SKU";
            // 
            // coResetButton
            // 
            coResetButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            coResetButton.AutoSize = true;
            coResetButton.Location = new Point(1246, 274);
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
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.Font = new Font("Verdana", 11.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(0, 2, 10, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            checkOutDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            checkOutDataGrid.Location = new Point(5, 3);
            checkOutDataGrid.MultiSelect = false;
            checkOutDataGrid.Name = "checkOutDataGrid";
            checkOutDataGrid.ReadOnly = true;
            checkOutDataGrid.RowHeadersWidth = 82;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Padding = new Padding(0, 0, 10, 0);
            checkOutDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            checkOutDataGrid.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            checkOutDataGrid.RowTemplate.DefaultCellStyle.Padding = new Padding(0, 0, 10, 0);
            checkOutDataGrid.RowTemplate.Resizable = DataGridViewTriState.True;
            checkOutDataGrid.Size = new Size(1090, 736);
            checkOutDataGrid.TabIndex = 4;
            checkOutDataGrid.DataError += checkOutDataGrid_DataError;
            // 
            // checkinPage
            // 
            checkinPage.AutoScroll = true;
            checkinPage.BackColor = Color.Lavender;
            checkinPage.Controls.Add(allUsersCheckBox);
            checkinPage.Controls.Add(applyChangesButton);
            checkinPage.Controls.Add(label3);
            checkinPage.Controls.Add(checkInDataGrid);
            checkinPage.Location = new Point(4, 44);
            checkinPage.Name = "checkinPage";
            checkinPage.Size = new Size(1531, 744);
            checkinPage.TabIndex = 4;
            checkinPage.Text = "Check In";
            checkinPage.ToolTipText = "Check In Items";
            // 
            // allUsersCheckBox
            // 
            allUsersCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            allUsersCheckBox.AutoSize = true;
            allUsersCheckBox.Location = new Point(1365, 146);
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
            applyChangesButton.Location = new Point(1308, 202);
            applyChangesButton.Name = "applyChangesButton";
            applyChangesButton.Size = new Size(220, 35);
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Verdana", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            checkInDataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            checkInDataGrid.Location = new Point(-7, 0);
            checkInDataGrid.Name = "checkInDataGrid";
            checkInDataGrid.RowHeadersWidth = 82;
            checkInDataGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            checkInDataGrid.Size = new Size(1292, 739);
            checkInDataGrid.TabIndex = 0;
            // 
            // reportPage
            // 
            reportPage.Controls.Add(showAllButton);
            reportPage.Controls.Add(filterLable);
            reportPage.Controls.Add(reportFilterTextBox);
            reportPage.Controls.Add(refreshButton);
            reportPage.Controls.Add(label2);
            reportPage.Controls.Add(label1);
            reportPage.Controls.Add(endTimePicker);
            reportPage.Controls.Add(startTimePicker);
            reportPage.Controls.Add(reportGridView);
            reportPage.Location = new Point(4, 44);
            reportPage.Name = "reportPage";
            reportPage.Size = new Size(1531, 744);
            reportPage.TabIndex = 5;
            reportPage.Text = "Report Page";
            reportPage.UseVisualStyleBackColor = true;
            // 
            // filterLable
            // 
            filterLable.AutoSize = true;
            filterLable.Font = new Font("Verdana", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            filterLable.Location = new Point(8, 18);
            filterLable.Name = "filterLable";
            filterLable.Size = new Size(132, 23);
            filterLable.TabIndex = 7;
            filterLable.Text = "Filter Rows";
            // 
            // reportFilterTextBox
            // 
            reportFilterTextBox.Font = new Font("Verdana", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            reportFilterTextBox.Location = new Point(157, 15);
            reportFilterTextBox.Name = "reportFilterTextBox";
            reportFilterTextBox.Size = new Size(235, 30);
            reportFilterTextBox.TabIndex = 6;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(1198, 167);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(97, 30);
            refreshButton.TabIndex = 5;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1191, 90);
            label2.Name = "label2";
            label2.Size = new Size(82, 18);
            label2.TabIndex = 4;
            label2.Text = "End Date";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1191, 50);
            label1.Name = "label1";
            label1.Size = new Size(94, 18);
            label1.TabIndex = 3;
            label1.Text = "Start Date";
            // 
            // endTimePicker
            // 
            endTimePicker.Location = new Point(1303, 84);
            endTimePicker.Name = "endTimePicker";
            endTimePicker.Size = new Size(200, 26);
            endTimePicker.TabIndex = 2;
            // 
            // startTimePicker
            // 
            startTimePicker.Location = new Point(1303, 42);
            startTimePicker.Name = "startTimePicker";
            startTimePicker.Size = new Size(200, 26);
            startTimePicker.TabIndex = 1;
            // 
            // reportGridView
            // 
            reportGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            reportGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            reportGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            reportGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reportGridView.Location = new Point(0, 60);
            reportGridView.Name = "reportGridView";
            reportGridView.Size = new Size(1127, 684);
            reportGridView.TabIndex = 0;
            // 
            // adminPage
            // 
            adminPage.AutoScroll = true;
            adminPage.BackColor = Color.Lavender;
            adminPage.BorderStyle = BorderStyle.Fixed3D;
            adminPage.Controls.Add(label5);
            adminPage.Controls.Add(resetComboBox);
            adminPage.Controls.Add(deleteUserButton);
            adminPage.Controls.Add(label9);
            adminPage.Controls.Add(resetPasswordButton);
            adminPage.Controls.Add(addUserButton);
            adminPage.Controls.Add(loggingTextBox);
            adminPage.Controls.Add(restoreDatabaseButton);
            adminPage.Controls.Add(backupButton);
            adminPage.Location = new Point(4, 44);
            adminPage.Name = "adminPage";
            adminPage.Size = new Size(1531, 744);
            adminPage.TabIndex = 3;
            adminPage.Text = "Admin";
            adminPage.ToolTipText = "Admin Settings";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(137, 98);
            label5.Name = "label5";
            label5.Size = new Size(84, 18);
            label5.TabIndex = 0;
            label5.Text = "Pick User";
            // 
            // resetComboBox
            // 
            resetComboBox.BackColor = Color.Lavender;
            resetComboBox.FormattingEnabled = true;
            resetComboBox.Location = new Point(255, 94);
            resetComboBox.Name = "resetComboBox";
            resetComboBox.Size = new Size(194, 26);
            resetComboBox.TabIndex = 1;
            // 
            // deleteUserButton
            // 
            deleteUserButton.FlatStyle = FlatStyle.Popup;
            deleteUserButton.Location = new Point(79, 239);
            deleteUserButton.Name = "deleteUserButton";
            deleteUserButton.Size = new Size(370, 50);
            deleteUserButton.TabIndex = 8;
            deleteUserButton.Text = "Delete User";
            deleteUserButton.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Verdana", 14.25F, FontStyle.Bold);
            label9.Location = new Point(1089, 34);
            label9.Name = "label9";
            label9.Size = new Size(224, 23);
            label9.TabIndex = 9;
            label9.Text = "Application Logging";
            // 
            // resetPasswordButton
            // 
            resetPasswordButton.FlatStyle = FlatStyle.Popup;
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
            addUserButton.BackColor = Color.Lavender;
            addUserButton.FlatStyle = FlatStyle.Popup;
            addUserButton.Location = new Point(79, 318);
            addUserButton.Margin = new Padding(4, 6, 4, 6);
            addUserButton.Name = "addUserButton";
            addUserButton.Size = new Size(370, 57);
            addUserButton.TabIndex = 9;
            addUserButton.Text = "Add User";
            addUserButton.UseVisualStyleBackColor = false;
            // 
            // loggingTextBox
            // 
            loggingTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            loggingTextBox.BackColor = Color.FromArgb(255, 255, 255);
            loggingTextBox.BorderStyle = BorderStyle.FixedSingle;
            loggingTextBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            loggingTextBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            loggingTextBox.Location = new Point(647, 97);
            loggingTextBox.Multiline = true;
            loggingTextBox.Name = "loggingTextBox";
            loggingTextBox.ScrollBars = ScrollBars.Vertical;
            loggingTextBox.Size = new Size(860, 623);
            loggingTextBox.TabIndex = 7;
            // 
            // restoreDatabaseButton
            // 
            restoreDatabaseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            restoreDatabaseButton.FlatStyle = FlatStyle.Popup;
            restoreDatabaseButton.Location = new Point(36, 472);
            restoreDatabaseButton.Margin = new Padding(4, 6, 4, 6);
            restoreDatabaseButton.Name = "restoreDatabaseButton";
            restoreDatabaseButton.Size = new Size(216, 56);
            restoreDatabaseButton.TabIndex = 5;
            restoreDatabaseButton.Text = "Restore Database";
            restoreDatabaseButton.UseVisualStyleBackColor = true;
            // 
            // backupButton
            // 
            backupButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            backupButton.FlatStyle = FlatStyle.Popup;
            backupButton.Location = new Point(36, 411);
            backupButton.Margin = new Padding(4, 6, 4, 6);
            backupButton.Name = "backupButton";
            backupButton.Size = new Size(216, 49);
            backupButton.TabIndex = 4;
            backupButton.Text = "Backup Database";
            backupButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // toolTip
            // 
            toolTip.IsBalloon = true;
            toolTip.ToolTipIcon = ToolTipIcon.Info;
            // 
            // showAllButton
            // 
            showAllButton.Location = new Point(1198, 217);
            showAllButton.Name = "showAllButton";
            showAllButton.Size = new Size(164, 31);
            showAllButton.TabIndex = 8;
            showAllButton.Text = "Show All Dates";
            showAllButton.UseVisualStyleBackColor = true;
            // 
            // Vivian
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(1539, 823);
            Controls.Add(tabControl);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 10.125F);
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
            reportPage.ResumeLayout(false);
            reportPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)reportGridView).EndInit();
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
        public Button deleteUserButton;
        private Label label9;
        private Label filterRowsLabel;
        internal DataGridView dataGridView;
        internal Button addRowButton;
        internal Button clearFilterButton;
        internal TextBox filterSkuTextBox;
        internal Label passwordLabel;
        internal Label pickUserLabel;
        private ToolStripMenuItem viewToolStripMenuItem;
        internal ToolStripMenuItem setInventoryFontSizeToolStripMenuItem;
        private Label scanBarcodeLabel;
        internal TextBox filterBarcodeTextBox;
        private ToolTip toolTip;
        internal Button addUserButton;
        internal ToolStripMenuItem saveInventoryReportToolStripMenuItem;
        private TabPage reportPage;
        public DataGridView reportGridView;
        private Label label2;
        private Label label1;
        public DateTimePicker endTimePicker;
        public DateTimePicker startTimePicker;
        private DateTimePicker dateTimePicker2;
        public Button refreshButton;
        private Label filterLable;
        public TextBox reportFilterTextBox;
        public Button showAllButton;
    }
}

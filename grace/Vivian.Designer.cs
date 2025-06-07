

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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            openFileDialog = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            editToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            importInventoryToolStripMenuItem = new ToolStripMenuItem();
            saveInventoryReportToolStripMenuItem = new ToolStripMenuItem();
            saveReportToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
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
            dataGridView = new DataGridView();
            filterBarcodeTextBox = new TextBox();
            scanBarcodeLabel = new Label();
            filterRowsLabel = new Label();
            addRowButton = new Button();
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
            filterSkuLabel = new Label();
            skuFilterTextBox = new TextBox();
            allUsersCheckBox = new CheckBox();
            applyChangesButton = new Button();
            label3 = new Label();
            checkInDataGrid = new DataGridView();
            reportPage = new TabPage();
            reportInfoLabel = new Label();
            filterLable = new Label();
            reportFilterTextBox = new TextBox();
            refreshButton = new Button();
            reportGridView = new DataGridView();
            collectionPage = new TabPage();
            clearComboButton = new Button();
            colLabel1 = new Label();
            colReportComboBox = new ComboBox();
            collGridView = new DataGridView();
            adminPage = new TabPage();
            adminCheckBox = new CheckBox();
            adminUserLabel = new Label();
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
            reportToolTip = new ToolTip(components);
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
            collectionPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)collGridView).BeginInit();
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
            menuStrip1.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            menuStrip1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
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
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, importInventoryToolStripMenuItem, saveInventoryReportToolStripMenuItem, saveReportToolStripMenuItem, aboutToolStripMenuItem, exitToolStripMenuItem });
            editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            editToolStripMenuItem.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(45, 25);
            editToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(235, 24);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += SettingsToolStripMenuItem_Click;
            // 
            // importInventoryToolStripMenuItem
            // 
            importInventoryToolStripMenuItem.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            importInventoryToolStripMenuItem.Name = "importInventoryToolStripMenuItem";
            importInventoryToolStripMenuItem.Size = new Size(235, 24);
            importInventoryToolStripMenuItem.Text = "Import Inventory";
            importInventoryToolStripMenuItem.Click += ImportInventoryToolStripMenuItem_Click;
            // 
            // saveInventoryReportToolStripMenuItem
            // 
            saveInventoryReportToolStripMenuItem.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            saveInventoryReportToolStripMenuItem.Name = "saveInventoryReportToolStripMenuItem";
            saveInventoryReportToolStripMenuItem.Size = new Size(235, 24);
            saveInventoryReportToolStripMenuItem.Text = "Save Inventory Report";
            // 
            // saveReportToolStripMenuItem
            // 
            saveReportToolStripMenuItem.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            saveReportToolStripMenuItem.Name = "saveReportToolStripMenuItem";
            saveReportToolStripMenuItem.Size = new Size(235, 24);
            saveReportToolStripMenuItem.Text = "Save Collection Report";
            saveReportToolStripMenuItem.Click += SaveReportToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(235, 24);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(235, 24);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setInventoryFontSizeToolStripMenuItem });
            viewToolStripMenuItem.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(60, 25);
            viewToolStripMenuItem.Text = "View";
            // 
            // setInventoryFontSizeToolStripMenuItem
            // 
            setInventoryFontSizeToolStripMenuItem.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
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
            tabControl.Controls.Add(collectionPage);
            tabControl.Controls.Add(adminPage);
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.Font = new System.Drawing.Font("Georgia", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tabControl.HotTrack = true;
            tabControl.ItemSize = new Size(200, 40);
            tabControl.Location = new Point(0, 31);
            tabControl.Margin = new Padding(5, 2, 5, 2);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(30, 5);
            tabControl.SelectedIndex = 0;
            tabControl.ShowToolTips = true;
            tabControl.Size = new Size(1525, 781);
            tabControl.TabIndex = 9;
            tabControl.TabStop = false;
            tabControl.DrawItem += TabControl_DrawItem;
            tabControl.Selecting += TabControl_Selecting;
            // 
            // loginPage
            // 
            loginPage.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
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
            loginPage.Size = new Size(1517, 733);
            loginPage.TabIndex = 0;
            loginPage.Text = "Home";
            loginPage.ToolTipText = "Login Page";
            // 
            // loggedInLabel
            // 
            loggedInLabel.AutoSize = true;
            loggedInLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            loggedInLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            loggedInLabel.Location = new Point(266, 452);
            loggedInLabel.Name = "loggedInLabel";
            loggedInLabel.Size = new Size(57, 18);
            loggedInLabel.TabIndex = 0;
            loggedInLabel.Text = "label5";
            // 
            // logoutButton
            // 
            logoutButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            logoutButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            logoutButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            logoutButton.FlatAppearance.BorderSize = 1;
            logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            logoutButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            logoutButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            logoutButton.Location = new Point(247, 490);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(116, 33);
            logoutButton.TabIndex = 1;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = false;
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            passwordTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            passwordTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
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
            loginButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            loginButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            loginButton.FlatAppearance.BorderSize = 1;
            loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            loginButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            loginButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            loginButton.Location = new Point(498, 371);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(73, 35);
            loginButton.TabIndex = 19;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            // 
            // comboBoxUsers
            // 
            comboBoxUsers.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            comboBoxUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            comboBoxUsers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            comboBoxUsers.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            comboBoxUsers.FormattingEnabled = true;
            comboBoxUsers.Location = new Point(448, 242);
            comboBoxUsers.Name = "comboBoxUsers";
            comboBoxUsers.Size = new Size(230, 26);
            comboBoxUsers.TabIndex = 17;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            passwordLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            passwordLabel.Location = new Point(254, 309);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(88, 18);
            passwordLabel.TabIndex = 23;
            passwordLabel.Text = "Password";
            // 
            // pickUserLabel
            // 
            pickUserLabel.AutoSize = true;
            pickUserLabel.BackColor = System.Drawing.Color.Transparent;
            pickUserLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pickUserLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
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
            changePasswordButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            changePasswordButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            changePasswordButton.FlatAppearance.BorderSize = 1;
            changePasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            changePasswordButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            changePasswordButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            changePasswordButton.Location = new Point(254, 371);
            changePasswordButton.Name = "changePasswordButton";
            changePasswordButton.Size = new Size(179, 35);
            changePasswordButton.TabIndex = 22;
            changePasswordButton.Text = "Change Password";
            changePasswordButton.UseVisualStyleBackColor = false;
            // 
            // dataPage
            // 
            dataPage.AutoScroll = true;
            dataPage.AutoScrollMargin = new Size(5, 5);
            dataPage.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
            dataPage.BorderStyle = BorderStyle.Fixed3D;
            dataPage.Controls.Add(dataGridView);
            dataPage.Controls.Add(filterBarcodeTextBox);
            dataPage.Controls.Add(scanBarcodeLabel);
            dataPage.Controls.Add(filterRowsLabel);
            dataPage.Controls.Add(addRowButton);
            dataPage.Controls.Add(clearFilterButton);
            dataPage.Controls.Add(filterSkuTextBox);
            dataPage.Location = new Point(4, 44);
            dataPage.Name = "dataPage";
            dataPage.Padding = new Padding(1);
            dataPage.Size = new Size(1517, 733);
            dataPage.TabIndex = 1;
            dataPage.Text = "Inventory";
            dataPage.ToolTipText = "Inventory for Patster";
            // dataGridViewCellStyle1
            //
            dataGridViewCellStyle1.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F0E3");
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            //
            // dataGridViewCellStyle2
            //
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewCellStyle2.BorderStyle = DataGridViewHeaderBorderStyle.Single;
            //
            // dataGridViewCellStyle3
            //
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            //
            // dataGridViewCellStyle4
            //
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            //
            // dataGridViewCellStyle5
            //
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle5.Padding = new Padding(0, 2, 10, 0); // Keep existing padding
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            //
            // dataGridViewCellStyle6
            //
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle6.Padding = new Padding(0, 0, 10, 0); // Keep existing padding
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            //
            // dataGridViewCellStyle7
            //
            dataGridViewCellStyle7.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F0E3");
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            //
            // dataGridViewCellStyle8
            //
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dataGridViewCellStyle8.BorderStyle = DataGridViewHeaderBorderStyle.Single;
            //
            // dataGridViewCellStyle9
            //
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            //
            // dataGridViewCellStyle10
            //
            dataGridViewCellStyle10.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F0E3");
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            //
            // dataGridViewCellStyle11
            //
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dataGridViewCellStyle11.BorderStyle = DataGridViewHeaderBorderStyle.Single; // Apply consistent border
            //
            // dataGridViewCellStyle12
            //
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            //
            // dataGridViewCellStyle13
            //
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle13.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            //
            // dataGridViewCellStyle14
            //
            dataGridViewCellStyle14.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F0E3");
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            //
            // dataGridViewCellStyle15
            //
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle15.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            dataGridViewCellStyle15.BorderStyle = DataGridViewHeaderBorderStyle.Single; // Apply consistent border
            //
            // dataGridViewCellStyle16
            //
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.False;
            //
            // dataGridViewCellStyle17
            //
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle17.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            //
            // dataGridViewCellStyle18
            //
            dataGridViewCellStyle18.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F0E3");
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            //
            // dataGridViewCellStyle19
            //
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle19.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
            dataGridViewCellStyle19.BorderStyle = DataGridViewHeaderBorderStyle.Single; // Apply consistent border
            //
            // dataGridViewCellStyle20
            //
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle20.WrapMode = DataGridViewTriState.False;
            //
            // dataGridViewCellStyle21
            //
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle21.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E0C97F");
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            dataGridViewCellStyle21.WrapMode = DataGridViewTriState.True;
            // 
            // dataGridView
            // 
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
            dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = System.Drawing.ColorTranslator.FromHtml("#D3C0B1");
            dataGridView.Location = new Point(4, 61);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(1503, 664);
            dataGridView.TabIndex = 8;
            // 
            // filterBarcodeTextBox
            // 
            filterBarcodeTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            filterBarcodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            filterBarcodeTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            filterBarcodeTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            filterBarcodeTextBox.Location = new Point(730, 13);
            filterBarcodeTextBox.Name = "filterBarcodeTextBox";
            filterBarcodeTextBox.Size = new Size(202, 26);
            filterBarcodeTextBox.TabIndex = 7;
            // 
            // scanBarcodeLabel
            // 
            scanBarcodeLabel.AutoSize = true;
            scanBarcodeLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            scanBarcodeLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            scanBarcodeLabel.Location = new Point(600, 16);
            scanBarcodeLabel.Margin = new Padding(4, 0, 4, 0);
            scanBarcodeLabel.Name = "scanBarcodeLabel";
            scanBarcodeLabel.Size = new Size(123, 18);
            scanBarcodeLabel.TabIndex = 6;
            scanBarcodeLabel.Text = "Scan  Barcode";
            scanBarcodeLabel.MouseHover += ScanBarcodeLabel_MouseHover;
            // 
            // filterRowsLabel
            // 
            filterRowsLabel.AutoSize = true;
            filterRowsLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            filterRowsLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            filterRowsLabel.Location = new Point(206, 13);
            filterRowsLabel.Margin = new Padding(4, 0, 4, 0);
            filterRowsLabel.Name = "filterRowsLabel";
            filterRowsLabel.Size = new Size(100, 18);
            filterRowsLabel.TabIndex = 3;
            filterRowsLabel.Text = "Filter Rows";
            filterRowsLabel.MouseHover += FilterRowsLabel_MouseHover;
            // 
            // addRowButton
            // 
            addRowButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            addRowButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            addRowButton.FlatAppearance.BorderSize = 1;
            addRowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            addRowButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            addRowButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            addRowButton.Location = new Point(41, 8);
            addRowButton.Name = "addRowButton";
            addRowButton.Size = new Size(118, 35);
            addRowButton.TabIndex = 4;
            addRowButton.Text = "Add Item";
            addRowButton.UseVisualStyleBackColor = false;
            // 
            // clearFilterButton
            // 
            clearFilterButton.AutoSize = true;
            clearFilterButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            clearFilterButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            clearFilterButton.FlatAppearance.BorderSize = 1;
            clearFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            clearFilterButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            clearFilterButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            clearFilterButton.Location = new Point(959, 8);
            clearFilterButton.Margin = new Padding(4, 6, 4, 6);
            clearFilterButton.Name = "clearFilterButton";
            clearFilterButton.Size = new Size(147, 32);
            clearFilterButton.TabIndex = 5;
            clearFilterButton.Text = "Clear Filter";
            clearFilterButton.UseVisualStyleBackColor = false;
            // 
            // filterSkuTextBox
            // 
            filterSkuTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            filterSkuTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            filterSkuTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            filterSkuTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            filterSkuTextBox.Location = new Point(362, 13);
            filterSkuTextBox.Margin = new Padding(4, 3, 4, 3);
            filterSkuTextBox.Name = "filterSkuTextBox";
            filterSkuTextBox.Size = new Size(217, 26);
            filterSkuTextBox.TabIndex = 2;
            // 
            // checkoutPage
            // 
            checkoutPage.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
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
            checkoutPage.Size = new Size(1517, 733);
            checkoutPage.TabIndex = 2;
            checkoutPage.Text = "Check Out";
            checkoutPage.ToolTipText = "Checkout Items";
            // 
            // textBoxBarcode
            // 
            textBoxBarcode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxBarcode.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            textBoxBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBoxBarcode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxBarcode.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            textBoxBarcode.Location = new Point(1259, 144);
            textBoxBarcode.Name = "textBoxBarcode";
            textBoxBarcode.Size = new Size(246, 26);
            textBoxBarcode.TabIndex = 13;
            // 
            // checkOutSearchTextBox
            // 
            checkOutSearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkOutSearchTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            checkOutSearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            checkOutSearchTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkOutSearchTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            checkOutSearchTextBox.Location = new Point(1246, 190);
            checkOutSearchTextBox.Name = "checkOutSearchTextBox";
            checkOutSearchTextBox.Size = new Size(259, 26);
            checkOutSearchTextBox.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
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
            label7.BackColor = Color.Transparent; // Potentially keep transparent or match page bg
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new System.Drawing.Font("Georgia", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Heading Font
            label7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F"); // Charcoal Text
            label7.Location = new Point(1108, 429);
            label7.Name = "label7";
            label7.Size = new Size(397, 77);
            label7.TabIndex = 9;
            label7.Text = "Please go to the Check In screen\r\n to see a list of what you have \r\nchecked out.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
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
            coResetButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            coResetButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            coResetButton.FlatAppearance.BorderSize = 1;
            coResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            coResetButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            coResetButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            coResetButton.Location = new Point(1246, 274);
            coResetButton.Name = "coResetButton";
            coResetButton.Size = new Size(259, 46);
            coResetButton.TabIndex = 7;
            coResetButton.Text = "Show All Data";
            coResetButton.UseVisualStyleBackColor = false;
            // 
            // checkOutDataGrid
            // 
            checkOutDataGrid.AllowUserToAddRows = false;
            checkOutDataGrid.AllowUserToDeleteRows = false;
            checkOutDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            checkOutDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkOutDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            checkOutDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            checkOutDataGrid.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
            checkOutDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            checkOutDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            checkOutDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            checkOutDataGrid.DefaultCellStyle = dataGridViewCellStyle5; // Will be updated
            checkOutDataGrid.EnableHeadersVisualStyles = false;
            checkOutDataGrid.GridColor = System.Drawing.ColorTranslator.FromHtml("#D3C0B1");
            checkOutDataGrid.Location = new Point(5, 3);
            checkOutDataGrid.MultiSelect = false;
            checkOutDataGrid.Name = "checkOutDataGrid";
            checkOutDataGrid.ReadOnly = true;
            checkOutDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            checkOutDataGrid.RowHeadersWidth = 82;
            checkOutDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle6; // Will be updated
            checkOutDataGrid.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            checkOutDataGrid.RowTemplate.DefaultCellStyle.Padding = new Padding(0, 0, 10, 0);
            checkOutDataGrid.RowTemplate.Resizable = DataGridViewTriState.True;
            checkOutDataGrid.Size = new Size(1090, 725);
            checkOutDataGrid.TabIndex = 4;
            checkOutDataGrid.DataError += CheckOutDataGrid_DataError;
            // 
            // checkinPage
            // 
            checkinPage.AutoScroll = true;
            checkinPage.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
            checkinPage.Controls.Add(filterSkuLabel);
            checkinPage.Controls.Add(skuFilterTextBox);
            checkinPage.Controls.Add(allUsersCheckBox);
            checkinPage.Controls.Add(applyChangesButton);
            checkinPage.Controls.Add(label3);
            checkinPage.Controls.Add(checkInDataGrid);
            checkinPage.Location = new Point(4, 44);
            checkinPage.Name = "checkinPage";
            checkinPage.Size = new Size(1517, 733);
            checkinPage.TabIndex = 4;
            checkinPage.Text = "Check In";
            checkinPage.ToolTipText = "Check In Items";
            // 
            // filterSkuLabel
            // 
            filterSkuLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            filterSkuLabel.AutoSize = true;
            filterSkuLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            filterSkuLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            filterSkuLabel.Location = new Point(1306, 48);
            filterSkuLabel.Name = "filterSkuLabel";
            filterSkuLabel.Size = new Size(112, 18);
            filterSkuLabel.TabIndex = 5;
            filterSkuLabel.Text = "Filter By Sku";
            filterSkuLabel.Click += label1_Click;
            // 
            // skuFilterTextBox
            // 
            skuFilterTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            skuFilterTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            skuFilterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            skuFilterTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            skuFilterTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            skuFilterTextBox.Location = new Point(1306, 80);
            skuFilterTextBox.Name = "skuFilterTextBox";
            skuFilterTextBox.Size = new Size(194, 26);
            skuFilterTextBox.TabIndex = 4;
            // 
            // allUsersCheckBox
            // 
            allUsersCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            allUsersCheckBox.AutoSize = true;
            allUsersCheckBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            allUsersCheckBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            allUsersCheckBox.Location = new Point(1351, 146);
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
            applyChangesButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            applyChangesButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            applyChangesButton.FlatAppearance.BorderSize = 1;
            applyChangesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            applyChangesButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            applyChangesButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            applyChangesButton.Location = new Point(1294, 202);
            applyChangesButton.Name = "applyChangesButton";
            applyChangesButton.Size = new Size(220, 35);
            applyChangesButton.TabIndex = 3;
            applyChangesButton.Text = "Apply Changes";
            applyChangesButton.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            label3.Location = new Point(1034, 38);
            label3.Name = "label3";
            label3.Size = new Size(0, 18);
            label3.TabIndex = 1;
            // 
            // checkInDataGrid
            // 
            checkInDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            checkInDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkInDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            checkInDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            checkInDataGrid.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
            checkInDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            checkInDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.Sunken; // Keep or change to Single? For now, keep.
            checkInDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken; // Keep or change to Single? For now, keep.
            checkInDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            checkInDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            checkInDataGrid.DefaultCellStyle = dataGridViewCellStyle12; // New style
            checkInDataGrid.EnableHeadersVisualStyles = false;
            checkInDataGrid.GridColor = System.Drawing.ColorTranslator.FromHtml("#D3C0B1");
            checkInDataGrid.Location = new Point(-7, 0);
            checkInDataGrid.Name = "checkInDataGrid";
            checkInDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            checkInDataGrid.RowHeadersWidth = 82;
            checkInDataGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            checkInDataGrid.Size = new Size(1292, 728);
            checkInDataGrid.TabIndex = 0;
            // 
            // reportPage
            // 
            reportPage.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
            reportPage.Controls.Add(reportInfoLabel);
            reportPage.Controls.Add(filterLable);
            reportPage.Controls.Add(reportFilterTextBox);
            reportPage.Controls.Add(refreshButton);
            reportPage.Controls.Add(reportGridView);
            reportPage.Location = new Point(4, 44);
            reportPage.Name = "reportPage";
            reportPage.Size = new Size(1517, 733);
            reportPage.TabIndex = 5;
            reportPage.Text = "Report Page";
            reportPage.UseVisualStyleBackColor = true;
            // 
            // reportInfoLabel
            // 
            reportInfoLabel.AutoSize = true;
            reportInfoLabel.Font = new System.Drawing.Font("Georgia", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Heading Font
            reportInfoLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            reportInfoLabel.Location = new Point(558, 21);
            reportInfoLabel.Name = "reportInfoLabel";
            reportInfoLabel.Size = new Size(582, 23);
            reportInfoLabel.TabIndex = 8;
            reportInfoLabel.Text = "This report is best viewed by selecting a single item.";
            reportInfoLabel.MouseHover += ReportInfoLabel_MouseHover;
            // 
            // filterLable
            // 
            filterLable.AutoSize = true;
            filterLable.Font = new System.Drawing.Font("Georgia", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Heading Font
            filterLable.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            filterLable.Location = new Point(8, 18);
            filterLable.Name = "filterLable";
            filterLable.Size = new Size(132, 23);
            filterLable.TabIndex = 7;
            filterLable.Text = "Filter Rows";
            // 
            // reportFilterTextBox
            // 
            reportFilterTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            reportFilterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            reportFilterTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reportFilterTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            reportFilterTextBox.Location = new Point(157, 15);
            reportFilterTextBox.Name = "reportFilterTextBox";
            reportFilterTextBox.Size = new Size(235, 30);
            reportFilterTextBox.TabIndex = 6;
            // 
            // refreshButton
            // 
            refreshButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            refreshButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            refreshButton.FlatAppearance.BorderSize = 1;
            refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            refreshButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            refreshButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            refreshButton.Location = new Point(431, 18);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(97, 30);
            refreshButton.TabIndex = 5;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = false;
            // 
            // reportGridView
            // 
            reportGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle14;
            reportGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            reportGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            reportGridView.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
            reportGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            reportGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            reportGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reportGridView.DefaultCellStyle = dataGridViewCellStyle16;
            reportGridView.EnableHeadersVisualStyles = false;
            reportGridView.GridColor = System.Drawing.ColorTranslator.FromHtml("#D3C0B1");
            reportGridView.Location = new Point(8, 60);
            reportGridView.Name = "reportGridView";
            reportGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            reportGridView.Size = new Size(1501, 670);
            reportGridView.TabIndex = 0;
            // 
            // collectionPage
            // 
            collectionPage.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
            collectionPage.Controls.Add(clearComboButton);
            collectionPage.Controls.Add(colLabel1);
            collectionPage.Controls.Add(colReportComboBox);
            collectionPage.Controls.Add(collGridView);
            collectionPage.Location = new Point(4, 44);
            collectionPage.Name = "collectionPage";
            collectionPage.Padding = new Padding(3);
            collectionPage.Size = new Size(1517, 733);
            collectionPage.TabIndex = 6;
            collectionPage.Text = "Collection";
            // 
            // clearComboButton
            // 
            clearComboButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            clearComboButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            clearComboButton.FlatAppearance.BorderSize = 1;
            clearComboButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            clearComboButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            clearComboButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            clearComboButton.Location = new Point(436, 32);
            clearComboButton.Name = "clearComboButton";
            clearComboButton.Size = new Size(109, 26);
            clearComboButton.TabIndex = 3;
            clearComboButton.Text = "Clear";
            clearComboButton.UseVisualStyleBackColor = false;
            // 
            // colLabel1
            // 
            colLabel1.AutoSize = true;
            colLabel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            colLabel1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            colLabel1.Location = new Point(34, 35);
            colLabel1.Name = "colLabel1";
            colLabel1.Size = new Size(150, 18);
            colLabel1.TabIndex = 2;
            colLabel1.Text = "Select Collections";
            // 
            // colReportComboBox
            // 
            colReportComboBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            colReportComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            colReportComboBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            colReportComboBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            colReportComboBox.FormattingEnabled = true;
            colReportComboBox.Location = new Point(201, 32);
            colReportComboBox.Name = "colReportComboBox";
            colReportComboBox.Size = new Size(196, 26);
            colReportComboBox.TabIndex = 1;
            // 
            // collGridView
            // 
            collGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle18;
            collGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            collGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            collGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            collGridView.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
            collGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            collGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            collGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            collGridView.DefaultCellStyle = dataGridViewCellStyle20;
            collGridView.EnableHeadersVisualStyles = false;
            collGridView.GridColor = System.Drawing.ColorTranslator.FromHtml("#D3C0B1");
            collGridView.Location = new Point(6, 72);
            collGridView.Name = "collGridView";
            collGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            collGridView.Size = new Size(1505, 655);
            collGridView.TabIndex = 0;
            // 
            // adminPage
            // 
            adminPage.AutoScroll = true;
            adminPage.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
            adminPage.BorderStyle = BorderStyle.Fixed3D;
            adminPage.Controls.Add(adminCheckBox);
            adminPage.Controls.Add(adminUserLabel);
            adminPage.Controls.Add(label5);
            adminPage.Controls.Add(resetComboBox);
            adminPage.Controls.Add(deleteUserButton);
            adminPage.Controls.Add(label9);
            adminPage.Controls.Add(resetPasswordButton);
            adminPage.Controls.Add(addUserButton);
            adminPage.Controls.Add(loggingTextBox);
            adminPage.Controls.Add(restoreDatabaseButton);
            adminPage.Controls.Add(backupButton);
            adminPage.ForeColor = Color.Black;
            adminPage.Location = new Point(4, 44);
            adminPage.Name = "adminPage";
            adminPage.Size = new Size(1517, 733);
            adminPage.TabIndex = 3;
            adminPage.Text = "Admin";
            adminPage.ToolTipText = "Admin Settings";
            // 
            // adminCheckBox
            // 
            adminCheckBox.AutoSize = true;
            adminCheckBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            adminCheckBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            adminCheckBox.Location = new Point(79, 402);
            adminCheckBox.Name = "adminCheckBox";
            adminCheckBox.Size = new Size(158, 22);
            adminCheckBox.TabIndex = 11;
            adminCheckBox.Text = "    Admin Status";
            adminCheckBox.UseVisualStyleBackColor = true;
            // 
            // adminUserLabel
            // 
            adminUserLabel.AutoSize = true;
            adminUserLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            adminUserLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            adminUserLabel.Location = new Point(256, 58);
            adminUserLabel.Name = "adminUserLabel";
            adminUserLabel.Size = new Size(203, 18);
            adminUserLabel.TabIndex = 10;
            adminUserLabel.Text = "Admin Users are in Bold";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            label5.Location = new Point(137, 98);
            label5.Name = "label5";
            label5.Size = new Size(84, 18);
            label5.TabIndex = 0;
            label5.Text = "Pick User";
            // 
            // resetComboBox
            // 
            resetComboBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            resetComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            resetComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            resetComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resetComboBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            resetComboBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            resetComboBox.FormattingEnabled = true;
            resetComboBox.Location = new Point(255, 94);
            resetComboBox.Name = "resetComboBox";
            resetComboBox.Size = new Size(194, 27);
            resetComboBox.TabIndex = 1;
            resetComboBox.DrawItem += ResetComboBox_DrawItem;
            // 
            // deleteUserButton
            // 
            deleteUserButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            deleteUserButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            deleteUserButton.FlatAppearance.BorderSize = 1;
            deleteUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat; // Changed from Popup
            deleteUserButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            deleteUserButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            deleteUserButton.Location = new Point(79, 239);
            deleteUserButton.Name = "deleteUserButton";
            deleteUserButton.Size = new Size(370, 50);
            deleteUserButton.TabIndex = 8;
            deleteUserButton.Text = "Delete User";
            deleteUserButton.UseVisualStyleBackColor = false; // Changed from true
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Georgia", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Heading Font
            label9.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            label9.Location = new Point(1089, 34);
            label9.Name = "label9";
            label9.Size = new Size(224, 23);
            label9.TabIndex = 9;
            label9.Text = "Application Logging";
            // 
            // resetPasswordButton
            // 
            resetPasswordButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            resetPasswordButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            resetPasswordButton.FlatAppearance.BorderSize = 1;
            resetPasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat; // Changed from Popup
            resetPasswordButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            resetPasswordButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            resetPasswordButton.Location = new Point(79, 164);
            resetPasswordButton.Name = "resetPasswordButton";
            resetPasswordButton.Size = new Size(380, 53);
            resetPasswordButton.TabIndex = 2;
            resetPasswordButton.Text = "Reset Password";
            resetPasswordButton.UseVisualStyleBackColor = false; // Changed from true
            // 
            // addUserButton
            // 
            addUserButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addUserButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5"); // Changed from Lavender
            addUserButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            addUserButton.FlatAppearance.BorderSize = 1;
            addUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat; // Changed from Popup
            addUserButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            addUserButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
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
            loggingTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0"); // FloralWhite
            loggingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            loggingTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            loggingTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F"); // Charcoal
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
            restoreDatabaseButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            restoreDatabaseButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            restoreDatabaseButton.FlatAppearance.BorderSize = 1;
            restoreDatabaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat; // Changed from Popup
            restoreDatabaseButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            restoreDatabaseButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            restoreDatabaseButton.Location = new Point(36, 516);
            restoreDatabaseButton.Margin = new Padding(4, 6, 4, 6);
            restoreDatabaseButton.Name = "restoreDatabaseButton";
            restoreDatabaseButton.Size = new Size(216, 56);
            restoreDatabaseButton.TabIndex = 5;
            restoreDatabaseButton.Text = "Restore Database";
            restoreDatabaseButton.UseVisualStyleBackColor = false; // Changed from true
            // 
            // backupButton
            // 
            backupButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            backupButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            backupButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            backupButton.FlatAppearance.BorderSize = 1;
            backupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat; // Changed from Popup
            backupButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            backupButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            backupButton.Location = new Point(36, 455);
            backupButton.Margin = new Padding(4, 6, 4, 6);
            backupButton.Name = "backupButton";
            backupButton.Size = new Size(216, 49);
            backupButton.TabIndex = 4;
            backupButton.Text = "Backup Database";
            backupButton.UseVisualStyleBackColor = false; // Changed from true
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // reportToolTip
            // 
            reportToolTip.IsBalloon = true;
            reportToolTip.ToolTipIcon = ToolTipIcon.Info;
            reportToolTip.ToolTipTitle = "Report Info";
            // 
            // Vivian
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
            ClientSize = new Size(1539, 823);
            Controls.Add(tabControl);
            Controls.Add(menuStrip1);
            Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5, 2, 5, 2);
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "Vivian";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "VivianGrace";
            Load += Vivian_Load;
            Paint += Vivian_Paint;
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
            collectionPage.ResumeLayout(false);
            collectionPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)collGridView).EndInit();
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
        internal Button addRowButton;
        internal Button clearFilterButton;
        internal TextBox filterSkuTextBox;
        internal Label passwordLabel;
        internal Label pickUserLabel;
        private ToolStripMenuItem viewToolStripMenuItem;
        internal ToolStripMenuItem setInventoryFontSizeToolStripMenuItem;
        private Label scanBarcodeLabel;
        internal TextBox filterBarcodeTextBox;
        private ToolTip reportToolTip;
        internal Button addUserButton;
        internal ToolStripMenuItem saveInventoryReportToolStripMenuItem;
        private TabPage reportPage;
        public DataGridView reportGridView;
        private DateTimePicker dateTimePicker2;
        public Button refreshButton;
        private Label filterLable;
        public TextBox reportFilterTextBox;
        public DataGridView dataGridView;
        private TabPage collectionPage;
        public DataGridView collGridView;
        private Label colLabel1;
        public ComboBox colReportComboBox;
        public Button clearComboButton;
        private Label adminUserLabel;
        public CheckBox adminCheckBox;
        private Label reportInfoLabel;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Label filterSkuLabel;
        public TextBox skuFilterTextBox;
    }
}

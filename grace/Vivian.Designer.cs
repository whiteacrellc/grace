

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
            DataGridViewCellStyle dataGridViewCellStyle34 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle35 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle36 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle37 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle38 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle39 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle40 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle41 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle42 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle26 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle27 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle28 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle29 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle30 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle31 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle32 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle33 = new DataGridViewCellStyle();
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
            tabControl = new TabControl();
            // loginPage = new TabPage(); // Removed
            // pictureBox1 = new PictureBox(); // Removed
            // loggedInLabel = new Label(); // Removed
            // logoutButton = new Button(); // Removed
            // passwordTextBox = new TextBox(); // Removed
            // loginButton = new Button(); // Removed
            // comboBoxUsers = new ComboBox(); // Removed
            // passwordLabel = new Label(); // Removed
            // pickUserLabel = new Label(); // Removed
            // changePasswordButton = new Button(); // Removed
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
            tabControl.SuspendLayout();
            // loginPage.SuspendLayout(); // Removed
            // ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit(); // Removed
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
            menuStrip1.BackColor = Color.FromArgb(245, 245, 245);
            menuStrip1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ForeColor = Color.FromArgb(54, 69, 79);
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, viewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1539, 27);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, importInventoryToolStripMenuItem, saveInventoryReportToolStripMenuItem, saveReportToolStripMenuItem, aboutToolStripMenuItem, exitToolStripMenuItem });
            editToolStripMenuItem.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editToolStripMenuItem.ForeColor = Color.FromArgb(54, 69, 79);
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(44, 23);
            editToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.ForeColor = Color.FromArgb(54, 69, 79);
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(231, 24);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += SettingsToolStripMenuItem_Click;
            // 
            // importInventoryToolStripMenuItem
            // 
            importInventoryToolStripMenuItem.ForeColor = Color.FromArgb(54, 69, 79);
            importInventoryToolStripMenuItem.Name = "importInventoryToolStripMenuItem";
            importInventoryToolStripMenuItem.Size = new Size(231, 24);
            importInventoryToolStripMenuItem.Text = "Import Inventory";
            importInventoryToolStripMenuItem.Click += ImportInventoryToolStripMenuItem_Click;
            // 
            // saveInventoryReportToolStripMenuItem
            // 
            saveInventoryReportToolStripMenuItem.ForeColor = Color.FromArgb(54, 69, 79);
            saveInventoryReportToolStripMenuItem.Name = "saveInventoryReportToolStripMenuItem";
            saveInventoryReportToolStripMenuItem.Size = new Size(231, 24);
            saveInventoryReportToolStripMenuItem.Text = "Save Inventory Report";
            // 
            // saveReportToolStripMenuItem
            // 
            saveReportToolStripMenuItem.ForeColor = Color.FromArgb(54, 69, 79);
            saveReportToolStripMenuItem.Name = "saveReportToolStripMenuItem";
            saveReportToolStripMenuItem.Size = new Size(231, 24);
            saveReportToolStripMenuItem.Text = "Save Collection Report";
            saveReportToolStripMenuItem.Click += SaveReportToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.ForeColor = Color.FromArgb(54, 69, 79);
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(231, 24);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.ForeColor = Color.FromArgb(54, 69, 79);
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(231, 24);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setInventoryFontSizeToolStripMenuItem, logoutToolStripMenuItem });
            viewToolStripMenuItem.ForeColor = Color.FromArgb(54, 69, 79);
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(53, 23);
            viewToolStripMenuItem.Text = "View";
            // 
            // setInventoryFontSizeToolStripMenuItem
            // 
            setInventoryFontSizeToolStripMenuItem.ForeColor = Color.FromArgb(54, 69, 79);
            setInventoryFontSizeToolStripMenuItem.Name = "setInventoryFontSizeToolStripMenuItem";
            setInventoryFontSizeToolStripMenuItem.Size = new Size(232, 24);
            setInventoryFontSizeToolStripMenuItem.Text = "Set Inventory Font Size";
            // 
            // logoutToolStripMenuItem
            //
            logoutToolStripMenuItem.ForeColor = Color.FromArgb(54, 69, 79);
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(232, 24);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += new System.EventHandler(this.LogoutToolStripMenuItem_Click);
            //
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Appearance = TabAppearance.Buttons;
            // tabControl.Controls.Add(loginPage); // Removed
            tabControl.Controls.Add(dataPage);
            tabControl.Controls.Add(checkoutPage);
            tabControl.Controls.Add(checkinPage);
            tabControl.Controls.Add(reportPage);
            tabControl.Controls.Add(collectionPage);
            tabControl.Controls.Add(adminPage);
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            // loginPage REMOVED
            //
            // pictureBox1 REMOVED
            //
            // loggedInLabel REMOVED
            //
            // logoutButton REMOVED
            //
            // passwordTextBox REMOVED
            //
            // loginButton REMOVED
            //
            // comboBoxUsers REMOVED
            //
            // passwordLabel REMOVED
            //
            // pickUserLabel REMOVED
            //
            // changePasswordButton REMOVED
            // 
            // dataPage
            // 
            dataPage.AutoScroll = true;
            dataPage.AutoScrollMargin = new Size(5, 5);
            dataPage.BackColor = Color.FromArgb(255, 245, 238);
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
            // 
            // dataGridView
            // 
            dataGridViewCellStyle34.BackColor = Color.FromArgb(248, 240, 227);
            dataGridViewCellStyle34.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle34.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle34.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle34.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle34;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BackgroundColor = Color.FromArgb(255, 245, 238);
            dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle35.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle35.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle35.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle35.SelectionBackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle35.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle35.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle35;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle36.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = Color.FromArgb(255, 250, 240);
            dataGridViewCellStyle36.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle36.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle36.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle36.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle36.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle36;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = Color.FromArgb(211, 192, 177);
            dataGridView.Location = new Point(4, 61);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridViewCellStyle37.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle37.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle37.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle37.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle37.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle37.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle37.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle37;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(1503, 664);
            dataGridView.TabIndex = 8;
            // 
            // filterBarcodeTextBox
            // 
            filterBarcodeTextBox.BackColor = Color.FromArgb(255, 250, 240);
            filterBarcodeTextBox.BorderStyle = BorderStyle.FixedSingle;
            filterBarcodeTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filterBarcodeTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            filterBarcodeTextBox.Location = new Point(730, 13);
            filterBarcodeTextBox.Name = "filterBarcodeTextBox";
            filterBarcodeTextBox.Size = new Size(202, 25);
            filterBarcodeTextBox.TabIndex = 7;
            // 
            // scanBarcodeLabel
            // 
            scanBarcodeLabel.AutoSize = true;
            scanBarcodeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            scanBarcodeLabel.ForeColor = Color.FromArgb(54, 69, 79);
            scanBarcodeLabel.Location = new Point(600, 16);
            scanBarcodeLabel.Margin = new Padding(4, 0, 4, 0);
            scanBarcodeLabel.Name = "scanBarcodeLabel";
            scanBarcodeLabel.Size = new Size(94, 19);
            scanBarcodeLabel.TabIndex = 6;
            scanBarcodeLabel.Text = "Scan  Barcode";
            scanBarcodeLabel.MouseHover += ScanBarcodeLabel_MouseHover;
            // 
            // filterRowsLabel
            // 
            filterRowsLabel.AutoSize = true;
            filterRowsLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filterRowsLabel.ForeColor = Color.FromArgb(54, 69, 79);
            filterRowsLabel.Location = new Point(206, 13);
            filterRowsLabel.Margin = new Padding(4, 0, 4, 0);
            filterRowsLabel.Name = "filterRowsLabel";
            filterRowsLabel.Size = new Size(75, 19);
            filterRowsLabel.TabIndex = 3;
            filterRowsLabel.Text = "Filter Rows";
            filterRowsLabel.MouseHover += FilterRowsLabel_MouseHover;
            // 
            // addRowButton
            // 
            addRowButton.BackColor = Color.FromArgb(245, 245, 245);
            addRowButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            addRowButton.FlatStyle = FlatStyle.Flat;
            addRowButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addRowButton.ForeColor = Color.FromArgb(54, 69, 79);
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
            clearFilterButton.BackColor = Color.FromArgb(245, 245, 245);
            clearFilterButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            clearFilterButton.FlatStyle = FlatStyle.Flat;
            clearFilterButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clearFilterButton.ForeColor = Color.FromArgb(54, 69, 79);
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
            filterSkuTextBox.BackColor = Color.FromArgb(255, 250, 240);
            filterSkuTextBox.BorderStyle = BorderStyle.FixedSingle;
            filterSkuTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filterSkuTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            filterSkuTextBox.Location = new Point(362, 13);
            filterSkuTextBox.Margin = new Padding(4, 3, 4, 3);
            filterSkuTextBox.Name = "filterSkuTextBox";
            filterSkuTextBox.Size = new Size(217, 25);
            filterSkuTextBox.TabIndex = 2;
            // 
            // checkoutPage
            // 
            checkoutPage.BackColor = Color.FromArgb(255, 245, 238);
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
            textBoxBarcode.BackColor = Color.FromArgb(255, 250, 240);
            textBoxBarcode.BorderStyle = BorderStyle.FixedSingle;
            textBoxBarcode.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxBarcode.ForeColor = Color.FromArgb(54, 69, 79);
            textBoxBarcode.Location = new Point(1246, 144);
            textBoxBarcode.Name = "textBoxBarcode";
            textBoxBarcode.Size = new Size(246, 25);
            textBoxBarcode.TabIndex = 13;
            // 
            // checkOutSearchTextBox
            // 
            checkOutSearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkOutSearchTextBox.BackColor = Color.FromArgb(255, 250, 240);
            checkOutSearchTextBox.BorderStyle = BorderStyle.FixedSingle;
            checkOutSearchTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkOutSearchTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            checkOutSearchTextBox.Location = new Point(1246, 190);
            checkOutSearchTextBox.Name = "checkOutSearchTextBox";
            checkOutSearchTextBox.Size = new Size(246, 25);
            checkOutSearchTextBox.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(54, 69, 79);
            label6.Location = new Point(1131, 152);
            label6.Name = "label6";
            label6.Size = new Size(89, 17);
            label6.TabIndex = 11;
            label6.Text = "Scan Barcode";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(54, 69, 79);
            label7.Location = new Point(1131, 353);
            label7.Name = "label7";
            label7.Size = new Size(256, 65);
            label7.TabIndex = 9;
            label7.Text = "Please go to the Check In screen\r\n to see a list of what you have \r\nchecked out.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(54, 69, 79);
            label8.Location = new Point(1144, 192);
            label8.Name = "label8";
            label8.Size = new Size(76, 17);
            label8.TabIndex = 12;
            label8.Text = "Search SKU";
            // 
            // coResetButton
            // 
            coResetButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            coResetButton.AutoSize = true;
            coResetButton.BackColor = Color.FromArgb(245, 245, 245);
            coResetButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            coResetButton.FlatStyle = FlatStyle.Flat;
            coResetButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            coResetButton.ForeColor = Color.FromArgb(54, 69, 79);
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
            dataGridViewCellStyle38.BackColor = Color.FromArgb(248, 240, 227);
            dataGridViewCellStyle38.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle38.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle38.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle38.SelectionForeColor = Color.FromArgb(54, 69, 79);
            checkOutDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle38;
            checkOutDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkOutDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            checkOutDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            checkOutDataGrid.BackgroundColor = Color.FromArgb(255, 245, 238);
            dataGridViewCellStyle39.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle39.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle39.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle39.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle39.SelectionBackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle39.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle39.WrapMode = DataGridViewTriState.True;
            checkOutDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle39;
            checkOutDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle40.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle40.BackColor = Color.FromArgb(255, 250, 240);
            dataGridViewCellStyle40.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle40.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle40.Padding = new Padding(0, 2, 10, 0);
            dataGridViewCellStyle40.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle40.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle40.WrapMode = DataGridViewTriState.False;
            checkOutDataGrid.DefaultCellStyle = dataGridViewCellStyle40;
            checkOutDataGrid.EnableHeadersVisualStyles = false;
            checkOutDataGrid.GridColor = Color.FromArgb(211, 192, 177);
            checkOutDataGrid.Location = new Point(5, 3);
            checkOutDataGrid.MultiSelect = false;
            checkOutDataGrid.Name = "checkOutDataGrid";
            checkOutDataGrid.ReadOnly = true;
            dataGridViewCellStyle41.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle41.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle41.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle41.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle41.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle41.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle41.WrapMode = DataGridViewTriState.True;
            checkOutDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle41;
            checkOutDataGrid.RowHeadersWidth = 82;
            dataGridViewCellStyle42.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle42.BackColor = Color.FromArgb(255, 250, 240);
            dataGridViewCellStyle42.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle42.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle42.Padding = new Padding(0, 0, 10, 0);
            dataGridViewCellStyle42.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle42.SelectionForeColor = Color.FromArgb(54, 69, 79);
            checkOutDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle42;
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
            checkinPage.BackColor = Color.FromArgb(255, 245, 238);
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
            filterSkuLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            filterSkuLabel.ForeColor = Color.FromArgb(54, 69, 79);
            filterSkuLabel.Location = new Point(1306, 50);
            filterSkuLabel.Name = "filterSkuLabel";
            filterSkuLabel.Size = new Size(83, 17);
            filterSkuLabel.TabIndex = 5;
            filterSkuLabel.Text = "Filter By Sku";
            filterSkuLabel.Click += label1_Click;
            // 
            // skuFilterTextBox
            // 
            skuFilterTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            skuFilterTextBox.BackColor = Color.FromArgb(255, 250, 240);
            skuFilterTextBox.BorderStyle = BorderStyle.FixedSingle;
            skuFilterTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            skuFilterTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            skuFilterTextBox.Location = new Point(1306, 80);
            skuFilterTextBox.Name = "skuFilterTextBox";
            skuFilterTextBox.Size = new Size(194, 25);
            skuFilterTextBox.TabIndex = 4;
            // 
            // allUsersCheckBox
            // 
            allUsersCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            allUsersCheckBox.AutoSize = true;
            allUsersCheckBox.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            allUsersCheckBox.ForeColor = Color.FromArgb(54, 69, 79);
            allUsersCheckBox.Location = new Point(1384, 120);
            allUsersCheckBox.Name = "allUsersCheckBox";
            allUsersCheckBox.Size = new Size(116, 21);
            allUsersCheckBox.TabIndex = 2;
            allUsersCheckBox.Text = "Show All Users";
            allUsersCheckBox.UseVisualStyleBackColor = true;
            // 
            // applyChangesButton
            // 
            applyChangesButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            applyChangesButton.AutoSize = true;
            applyChangesButton.BackColor = Color.FromArgb(245, 245, 245);
            applyChangesButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            applyChangesButton.FlatStyle = FlatStyle.Flat;
            applyChangesButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            applyChangesButton.ForeColor = Color.FromArgb(54, 69, 79);
            applyChangesButton.Location = new Point(1306, 165);
            applyChangesButton.Name = "applyChangesButton";
            applyChangesButton.Size = new Size(151, 35);
            applyChangesButton.TabIndex = 3;
            applyChangesButton.Text = "Apply Changes";
            applyChangesButton.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(54, 69, 79);
            label3.Location = new Point(1034, 38);
            label3.Name = "label3";
            label3.Size = new Size(0, 19);
            label3.TabIndex = 1;
            // 
            // checkInDataGrid
            // 
            dataGridViewCellStyle22.BackColor = Color.FromArgb(248, 240, 227);
            dataGridViewCellStyle22.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle22.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle22.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle22.SelectionForeColor = Color.FromArgb(54, 69, 79);
            checkInDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            checkInDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkInDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            checkInDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            checkInDataGrid.BackgroundColor = Color.FromArgb(255, 245, 238);
            checkInDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            checkInDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle23.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle23.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle23.SelectionBackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle23.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle23.WrapMode = DataGridViewTriState.True;
            checkInDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            checkInDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = Color.FromArgb(255, 250, 240);
            dataGridViewCellStyle24.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle24.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle24.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle24.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle24.WrapMode = DataGridViewTriState.False;
            checkInDataGrid.DefaultCellStyle = dataGridViewCellStyle24;
            checkInDataGrid.EnableHeadersVisualStyles = false;
            checkInDataGrid.GridColor = Color.FromArgb(211, 192, 177);
            checkInDataGrid.Location = new Point(-7, 0);
            checkInDataGrid.Name = "checkInDataGrid";
            dataGridViewCellStyle25.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle25.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle25.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle25.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle25.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle25.WrapMode = DataGridViewTriState.True;
            checkInDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle25;
            checkInDataGrid.RowHeadersWidth = 82;
            checkInDataGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            checkInDataGrid.Size = new Size(1292, 728);
            checkInDataGrid.TabIndex = 0;
            // 
            // reportPage
            // 
            reportPage.BackColor = Color.FromArgb(255, 245, 238);
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
            reportInfoLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            reportInfoLabel.ForeColor = Color.FromArgb(54, 69, 79);
            reportInfoLabel.Location = new Point(532, 17);
            reportInfoLabel.Name = "reportInfoLabel";
            reportInfoLabel.Size = new Size(357, 19);
            reportInfoLabel.TabIndex = 8;
            reportInfoLabel.Text = "This report is best viewed by selecting a single item.";
            reportInfoLabel.MouseHover += ReportInfoLabel_MouseHover;
            // 
            // filterLable
            // 
            filterLable.AutoSize = true;
            filterLable.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            filterLable.ForeColor = Color.FromArgb(54, 69, 79);
            filterLable.Location = new Point(49, 18);
            filterLable.Name = "filterLable";
            filterLable.Size = new Size(82, 19);
            filterLable.TabIndex = 7;
            filterLable.Text = "Filter Rows";
            // 
            // reportFilterTextBox
            // 
            reportFilterTextBox.BackColor = Color.FromArgb(255, 250, 240);
            reportFilterTextBox.BorderStyle = BorderStyle.FixedSingle;
            reportFilterTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reportFilterTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            reportFilterTextBox.Location = new Point(157, 15);
            reportFilterTextBox.Name = "reportFilterTextBox";
            reportFilterTextBox.Size = new Size(235, 25);
            reportFilterTextBox.TabIndex = 6;
            // 
            // refreshButton
            // 
            refreshButton.BackColor = Color.FromArgb(245, 245, 245);
            refreshButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            refreshButton.FlatStyle = FlatStyle.Flat;
            refreshButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            refreshButton.ForeColor = Color.FromArgb(54, 69, 79);
            refreshButton.Location = new Point(415, 11);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(97, 30);
            refreshButton.TabIndex = 5;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = false;
            // 
            // reportGridView
            // 
            dataGridViewCellStyle26.BackColor = Color.FromArgb(248, 240, 227);
            dataGridViewCellStyle26.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle26.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle26.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle26.SelectionForeColor = Color.FromArgb(54, 69, 79);
            reportGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle26;
            reportGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            reportGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            reportGridView.BackgroundColor = Color.FromArgb(255, 245, 238);
            dataGridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle27.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle27.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle27.SelectionBackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle27.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle27.WrapMode = DataGridViewTriState.True;
            reportGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            reportGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle28.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = Color.FromArgb(255, 250, 240);
            dataGridViewCellStyle28.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle28.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle28.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle28.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle28.WrapMode = DataGridViewTriState.False;
            reportGridView.DefaultCellStyle = dataGridViewCellStyle28;
            reportGridView.EnableHeadersVisualStyles = false;
            reportGridView.GridColor = Color.FromArgb(211, 192, 177);
            reportGridView.Location = new Point(8, 60);
            reportGridView.Name = "reportGridView";
            dataGridViewCellStyle29.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle29.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle29.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle29.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle29.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle29.WrapMode = DataGridViewTriState.True;
            reportGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle29;
            reportGridView.Size = new Size(1501, 670);
            reportGridView.TabIndex = 0;
            // 
            // collectionPage
            // 
            collectionPage.BackColor = Color.FromArgb(255, 245, 238);
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
            clearComboButton.BackColor = Color.FromArgb(245, 245, 245);
            clearComboButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            clearComboButton.FlatStyle = FlatStyle.Flat;
            clearComboButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clearComboButton.ForeColor = Color.FromArgb(54, 69, 79);
            clearComboButton.Location = new Point(419, 30);
            clearComboButton.Name = "clearComboButton";
            clearComboButton.Size = new Size(109, 26);
            clearComboButton.TabIndex = 3;
            clearComboButton.Text = "Clear";
            clearComboButton.UseVisualStyleBackColor = false;
            // 
            // colLabel1
            // 
            colLabel1.AutoSize = true;
            colLabel1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            colLabel1.ForeColor = Color.FromArgb(54, 69, 79);
            colLabel1.Location = new Point(50, 35);
            colLabel1.Name = "colLabel1";
            colLabel1.Size = new Size(116, 17);
            colLabel1.TabIndex = 2;
            colLabel1.Text = "Select Collections";
            // 
            // colReportComboBox
            // 
            colReportComboBox.BackColor = Color.FromArgb(255, 250, 240);
            colReportComboBox.FlatStyle = FlatStyle.Flat;
            colReportComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            colReportComboBox.ForeColor = Color.FromArgb(54, 69, 79);
            colReportComboBox.FormattingEnabled = true;
            colReportComboBox.Location = new Point(201, 32);
            colReportComboBox.Name = "colReportComboBox";
            colReportComboBox.Size = new Size(196, 25);
            colReportComboBox.TabIndex = 1;
            // 
            // collGridView
            // 
            dataGridViewCellStyle30.BackColor = Color.FromArgb(248, 240, 227);
            dataGridViewCellStyle30.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle30.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle30.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle30.SelectionForeColor = Color.FromArgb(54, 69, 79);
            collGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle30;
            collGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            collGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            collGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            collGridView.BackgroundColor = Color.FromArgb(255, 245, 238);
            dataGridViewCellStyle31.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle31.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle31.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle31.SelectionBackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle31.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle31.WrapMode = DataGridViewTriState.True;
            collGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            collGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle32.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = Color.FromArgb(255, 250, 240);
            dataGridViewCellStyle32.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle32.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle32.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle32.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle32.WrapMode = DataGridViewTriState.False;
            collGridView.DefaultCellStyle = dataGridViewCellStyle32;
            collGridView.EnableHeadersVisualStyles = false;
            collGridView.GridColor = Color.FromArgb(211, 192, 177);
            collGridView.Location = new Point(6, 72);
            collGridView.Name = "collGridView";
            dataGridViewCellStyle33.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle33.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle33.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle33.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle33.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle33.WrapMode = DataGridViewTriState.True;
            collGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle33;
            collGridView.Size = new Size(1505, 655);
            collGridView.TabIndex = 0;
            // 
            // adminPage
            // 
            adminPage.AutoScroll = true;
            adminPage.BackColor = Color.FromArgb(255, 245, 238);
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
            adminCheckBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            adminCheckBox.ForeColor = Color.FromArgb(54, 69, 79);
            adminCheckBox.Location = new Point(79, 402);
            adminCheckBox.Name = "adminCheckBox";
            adminCheckBox.Size = new Size(126, 23);
            adminCheckBox.TabIndex = 11;
            adminCheckBox.Text = "    Admin Status";
            adminCheckBox.UseVisualStyleBackColor = true;
            // 
            // adminUserLabel
            // 
            adminUserLabel.AutoSize = true;
            adminUserLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            adminUserLabel.ForeColor = Color.FromArgb(54, 69, 79);
            adminUserLabel.Location = new Point(256, 58);
            adminUserLabel.Name = "adminUserLabel";
            adminUserLabel.Size = new Size(154, 17);
            adminUserLabel.TabIndex = 10;
            adminUserLabel.Text = "Admin Users are in Bold";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(54, 69, 79);
            label5.Location = new Point(159, 97);
            label5.Name = "label5";
            label5.Size = new Size(64, 17);
            label5.TabIndex = 0;
            label5.Text = "Pick User";
            // 
            // resetComboBox
            // 
            resetComboBox.BackColor = Color.FromArgb(255, 250, 240);
            resetComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            resetComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            resetComboBox.FlatStyle = FlatStyle.Flat;
            resetComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            resetComboBox.ForeColor = Color.FromArgb(54, 69, 79);
            resetComboBox.FormattingEnabled = true;
            resetComboBox.Location = new Point(255, 94);
            resetComboBox.Name = "resetComboBox";
            resetComboBox.Size = new Size(194, 26);
            resetComboBox.TabIndex = 1;
            resetComboBox.DrawItem += ResetComboBox_DrawItem;
            // 
            // deleteUserButton
            // 
            deleteUserButton.BackColor = Color.FromArgb(245, 245, 245);
            deleteUserButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            deleteUserButton.FlatStyle = FlatStyle.Flat;
            deleteUserButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteUserButton.ForeColor = Color.FromArgb(54, 69, 79);
            deleteUserButton.Location = new Point(79, 239);
            deleteUserButton.Name = "deleteUserButton";
            deleteUserButton.Size = new Size(370, 50);
            deleteUserButton.TabIndex = 8;
            deleteUserButton.Text = "Delete User";
            deleteUserButton.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(54, 69, 79);
            label9.Location = new Point(1346, 56);
            label9.Name = "label9";
            label9.Size = new Size(145, 19);
            label9.TabIndex = 9;
            label9.Text = "Application Logging";
            // 
            // resetPasswordButton
            // 
            resetPasswordButton.BackColor = Color.FromArgb(245, 245, 245);
            resetPasswordButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            resetPasswordButton.FlatStyle = FlatStyle.Flat;
            resetPasswordButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            resetPasswordButton.ForeColor = Color.FromArgb(54, 69, 79);
            resetPasswordButton.Location = new Point(79, 164);
            resetPasswordButton.Name = "resetPasswordButton";
            resetPasswordButton.Size = new Size(380, 53);
            resetPasswordButton.TabIndex = 2;
            resetPasswordButton.Text = "Reset Password";
            resetPasswordButton.UseVisualStyleBackColor = false;
            // 
            // addUserButton
            // 
            addUserButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addUserButton.BackColor = Color.FromArgb(245, 245, 245);
            addUserButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            addUserButton.FlatStyle = FlatStyle.Flat;
            addUserButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addUserButton.ForeColor = Color.FromArgb(54, 69, 79);
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
            loggingTextBox.BackColor = Color.FromArgb(255, 250, 240);
            loggingTextBox.BorderStyle = BorderStyle.FixedSingle;
            loggingTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loggingTextBox.ForeColor = Color.FromArgb(54, 69, 79);
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
            restoreDatabaseButton.BackColor = Color.FromArgb(245, 245, 245);
            restoreDatabaseButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            restoreDatabaseButton.FlatStyle = FlatStyle.Flat;
            restoreDatabaseButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            restoreDatabaseButton.ForeColor = Color.FromArgb(54, 69, 79);
            restoreDatabaseButton.Location = new Point(36, 516);
            restoreDatabaseButton.Margin = new Padding(4, 6, 4, 6);
            restoreDatabaseButton.Name = "restoreDatabaseButton";
            restoreDatabaseButton.Size = new Size(216, 56);
            restoreDatabaseButton.TabIndex = 5;
            restoreDatabaseButton.Text = "Restore Database";
            restoreDatabaseButton.UseVisualStyleBackColor = false;
            // 
            // backupButton
            // 
            backupButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            backupButton.BackColor = Color.FromArgb(245, 245, 245);
            backupButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            backupButton.FlatStyle = FlatStyle.Flat;
            backupButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            backupButton.ForeColor = Color.FromArgb(54, 69, 79);
            backupButton.Location = new Point(36, 455);
            backupButton.Margin = new Padding(4, 6, 4, 6);
            backupButton.Name = "backupButton";
            backupButton.Size = new Size(216, 49);
            backupButton.TabIndex = 4;
            backupButton.Text = "Backup Database";
            backupButton.UseVisualStyleBackColor = false;
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
            BackColor = Color.FromArgb(255, 245, 238);
            ClientSize = new Size(1539, 823);
            Controls.Add(tabControl);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            tabControl.ResumeLayout(false);
            // loginPage.ResumeLayout(false); // Removed
            // loginPage.PerformLayout(); // Removed
            // ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit(); // Removed
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
        private TabPage dataPage;
        private TabPage checkoutPage;
        private TabPage adminPage;
        private ErrorProvider errorProvider1;
        private Label label5;
        private TabPage checkinPage;
        // public Label loggedInLabel; // Removed
        public ComboBox resetComboBox;
        public Button resetPasswordButton;
        public TabControl tabControl;
        // public Button loginButton; // Removed
        // public TextBox passwordTextBox; // Removed
        // public ComboBox comboBoxUsers; // Removed
        // internal Button changePasswordButton; // Removed
        // internal Button logoutButton; // Removed
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
        // internal TabPage loginPage; // Removed
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
        // internal Label passwordLabel; // Removed
        // internal Label pickUserLabel; // Removed
        private ToolStripMenuItem viewToolStripMenuItem;
        internal ToolStripMenuItem setInventoryFontSizeToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
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
        // private PictureBox pictureBox1; // Removed
    }
}

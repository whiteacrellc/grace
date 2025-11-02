

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vivian));
            openFileDialog = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            editToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            importInventoryToolStripMenuItem = new ToolStripMenuItem();
            saveInventoryReportToolStripMenuItem = new ToolStripMenuItem();
            saveReportToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            setInventoryFontSizeToolStripMenuItem = new ToolStripMenuItem();
            tabControl = new TabControl();
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
            arrangementPage = new TabPage();
            currentCollectionLabel = new Label();
            deleteArrangementButton = new Button();
            arrangementDataGrid = new DataGridView();
            collectionDropDown = new ComboBox();
            createArrangementButton = new Button();
            errorProvider1 = new ErrorProvider(components);
            checkoutBindingSource = new BindingSource(components);
            checkInBindingSource = new BindingSource(components);
            reportToolTip = new ToolTip(components);
            statusStrip = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            tabControl.SuspendLayout();
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
            arrangementPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)arrangementDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkoutBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkInBindingSource).BeginInit();
            statusStrip.SuspendLayout();
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
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, importInventoryToolStripMenuItem, saveInventoryReportToolStripMenuItem, saveReportToolStripMenuItem, aboutToolStripMenuItem, toolStripMenuItem2, exitToolStripMenuItem });
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
            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(231, 24);
            toolStripMenuItem2.Text = "Logout";
            toolStripMenuItem2.Click += LogoutToolStripMenuItem_Click;
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
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setInventoryFontSizeToolStripMenuItem });
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
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Appearance = TabAppearance.Buttons;
            tabControl.Controls.Add(dataPage);
            tabControl.Controls.Add(checkoutPage);
            tabControl.Controls.Add(checkinPage);
            tabControl.Controls.Add(reportPage);
            tabControl.Controls.Add(collectionPage);
            tabControl.Controls.Add(adminPage);
            tabControl.Controls.Add(arrangementPage);
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
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 240, 227);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BackgroundColor = Color.FromArgb(255, 245, 238);
            dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 250, 240);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = Color.FromArgb(211, 192, 177);
            dataGridView.Location = new Point(4, 61);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.BackColor = Color.FromArgb(248, 240, 227);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(54, 69, 79);
            checkOutDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            checkOutDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkOutDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            checkOutDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            checkOutDataGrid.BackgroundColor = Color.FromArgb(255, 245, 238);
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            checkOutDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            checkOutDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(255, 250, 240);
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle7.Padding = new Padding(0, 2, 10, 0);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            checkOutDataGrid.DefaultCellStyle = dataGridViewCellStyle7;
            checkOutDataGrid.EnableHeadersVisualStyles = false;
            checkOutDataGrid.GridColor = Color.FromArgb(211, 192, 177);
            checkOutDataGrid.Location = new Point(5, 3);
            checkOutDataGrid.MultiSelect = false;
            checkOutDataGrid.Name = "checkOutDataGrid";
            checkOutDataGrid.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            checkOutDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            checkOutDataGrid.RowHeadersWidth = 82;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(255, 250, 240);
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle9.Padding = new Padding(0, 0, 10, 0);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(54, 69, 79);
            checkOutDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle9;
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
            dataGridViewCellStyle10.BackColor = Color.FromArgb(248, 240, 227);
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle10.SelectionForeColor = Color.FromArgb(54, 69, 79);
            checkInDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            checkInDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkInDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            checkInDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            checkInDataGrid.BackgroundColor = Color.FromArgb(255, 245, 238);
            checkInDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            checkInDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle11.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            checkInDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            checkInDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.FromArgb(255, 250, 240);
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle12.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle12.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            checkInDataGrid.DefaultCellStyle = dataGridViewCellStyle12;
            checkInDataGrid.EnableHeadersVisualStyles = false;
            checkInDataGrid.GridColor = Color.FromArgb(211, 192, 177);
            checkInDataGrid.Location = new Point(-7, 0);
            checkInDataGrid.Name = "checkInDataGrid";
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle13.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle13.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle13.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            checkInDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
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
            dataGridViewCellStyle14.BackColor = Color.FromArgb(248, 240, 227);
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle14.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle14.SelectionForeColor = Color.FromArgb(54, 69, 79);
            reportGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle14;
            reportGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            reportGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            reportGridView.BackgroundColor = Color.FromArgb(255, 245, 238);
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle15.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle15.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle15.SelectionBackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle15.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            reportGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            reportGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = Color.FromArgb(255, 250, 240);
            dataGridViewCellStyle16.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle16.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle16.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle16.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.False;
            reportGridView.DefaultCellStyle = dataGridViewCellStyle16;
            reportGridView.EnableHeadersVisualStyles = false;
            reportGridView.GridColor = Color.FromArgb(211, 192, 177);
            reportGridView.Location = new Point(8, 60);
            reportGridView.Name = "reportGridView";
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle17.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle17.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle17.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle17.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            reportGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
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
            dataGridViewCellStyle18.BackColor = Color.FromArgb(248, 240, 227);
            dataGridViewCellStyle18.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle18.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle18.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle18.SelectionForeColor = Color.FromArgb(54, 69, 79);
            collGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle18;
            collGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            collGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            collGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            collGridView.BackgroundColor = Color.FromArgb(255, 245, 238);
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle19.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle19.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle19.SelectionBackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle19.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
            collGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            collGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = Color.FromArgb(255, 250, 240);
            dataGridViewCellStyle20.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle20.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle20.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle20.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle20.WrapMode = DataGridViewTriState.False;
            collGridView.DefaultCellStyle = dataGridViewCellStyle20;
            collGridView.EnableHeadersVisualStyles = false;
            collGridView.GridColor = Color.FromArgb(211, 192, 177);
            collGridView.Location = new Point(6, 72);
            collGridView.Name = "collGridView";
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = Color.FromArgb(234, 221, 202);
            dataGridViewCellStyle21.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle21.ForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle21.SelectionBackColor = Color.FromArgb(224, 201, 127);
            dataGridViewCellStyle21.SelectionForeColor = Color.FromArgb(54, 69, 79);
            dataGridViewCellStyle21.WrapMode = DataGridViewTriState.True;
            collGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
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
            // arrangementPage
            // 
            arrangementPage.Controls.Add(statusStrip);
            arrangementPage.BackColor = Color.FromArgb(255, 245, 238);
            arrangementPage.Controls.Add(currentCollectionLabel);
            arrangementPage.Controls.Add(deleteArrangementButton);
            arrangementPage.Controls.Add(arrangementDataGrid);
            arrangementPage.Controls.Add(collectionDropDown);
            arrangementPage.Controls.Add(createArrangementButton);
            arrangementPage.ForeColor = Color.FromArgb(54, 69, 79);
            arrangementPage.Location = new Point(4, 44);
            arrangementPage.Name = "arrangementPage";
            arrangementPage.Size = new Size(1517, 733);
            arrangementPage.TabIndex = 7;
            arrangementPage.Text = "Arrangement";
            // 
            // currentCollectionLabel
            //
            currentCollectionLabel.AutoSize = true;
            currentCollectionLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            currentCollectionLabel.ForeColor = Color.FromArgb(54, 69, 79);
            currentCollectionLabel.Location = new Point(63, 25);
            currentCollectionLabel.Name = "currentCollectionLabel";
            currentCollectionLabel.Size = new Size(50, 19);
            currentCollectionLabel.TabIndex = 5;
            currentCollectionLabel.Text = "label1";
            // 
            // deleteArrangementButton
            //
            deleteArrangementButton.BackColor = Color.FromArgb(245, 245, 245);
            deleteArrangementButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            deleteArrangementButton.FlatStyle = FlatStyle.Flat;
            deleteArrangementButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteArrangementButton.ForeColor = Color.FromArgb(54, 69, 79);
            deleteArrangementButton.Location = new Point(555, 240);
            deleteArrangementButton.Name = "deleteArrangementButton";
            deleteArrangementButton.Size = new Size(177, 39);
            deleteArrangementButton.TabIndex = 4;
            deleteArrangementButton.Text = "Delete Arrangement";
            deleteArrangementButton.UseVisualStyleBackColor = false;
            // 
            // arrangementDataGrid
            //
            arrangementDataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 240, 227);
            arrangementDataGrid.AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI", 10F);
            arrangementDataGrid.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(54, 69, 79);
            arrangementDataGrid.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 201, 127);
            arrangementDataGrid.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(54, 69, 79);
            arrangementDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            arrangementDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            arrangementDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            arrangementDataGrid.BackgroundColor = Color.FromArgb(255, 245, 238);
            arrangementDataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            arrangementDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(234, 221, 202);
            arrangementDataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            arrangementDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(54, 69, 79);
            arrangementDataGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(234, 221, 202);
            arrangementDataGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(54, 69, 79);
            arrangementDataGrid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            arrangementDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            arrangementDataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            arrangementDataGrid.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 240);
            arrangementDataGrid.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            arrangementDataGrid.DefaultCellStyle.ForeColor = Color.FromArgb(54, 69, 79);
            arrangementDataGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 201, 127);
            arrangementDataGrid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(54, 69, 79);
            arrangementDataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            arrangementDataGrid.EnableHeadersVisualStyles = false;
            arrangementDataGrid.GridColor = Color.FromArgb(211, 192, 177);
            arrangementDataGrid.Location = new Point(21, 64);
            arrangementDataGrid.Name = "arrangementDataGrid";
            arrangementDataGrid.Size = new Size(509, 630);
            arrangementDataGrid.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            arrangementDataGrid.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(234, 221, 202);
            arrangementDataGrid.RowHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            arrangementDataGrid.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(54, 69, 79);
            arrangementDataGrid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 201, 127);
            arrangementDataGrid.RowHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(54, 69, 79);
            arrangementDataGrid.RowHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            arrangementDataGrid.TabIndex = 3;
            // 
            // collectionDropDown
            //
            collectionDropDown.BackColor = Color.FromArgb(255, 250, 240);
            collectionDropDown.FlatStyle = FlatStyle.Flat;
            collectionDropDown.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            collectionDropDown.ForeColor = Color.FromArgb(54, 69, 79);
            collectionDropDown.FormattingEnabled = true;
            collectionDropDown.Location = new Point(555, 64);
            collectionDropDown.Name = "collectionDropDown";
            collectionDropDown.Size = new Size(177, 25);
            collectionDropDown.TabIndex = 2;
            collectionDropDown.SelectedValueChanged += CollectionDropDown_SelectedValueChanged;
            // 
            // createArrangementButton
            //
            createArrangementButton.BackColor = Color.FromArgb(245, 245, 245);
            createArrangementButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            createArrangementButton.FlatStyle = FlatStyle.Flat;
            createArrangementButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createArrangementButton.ForeColor = Color.FromArgb(54, 69, 79);
            createArrangementButton.Location = new Point(555, 185);
            createArrangementButton.Name = "createArrangementButton";
            createArrangementButton.Size = new Size(177, 39);
            createArrangementButton.TabIndex = 1;
            createArrangementButton.Text = "Create Arrangement";
            createArrangementButton.UseVisualStyleBackColor = false;
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
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip.Location = new Point(0, 711);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1517, 22);
            statusStrip.TabIndex = 6;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
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
            FormClosing += Vivian_FormClosing;
            Load += Vivian_Load;
            Paint += Vivian_Paint;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl.ResumeLayout(false);
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
            arrangementPage.ResumeLayout(false);
            arrangementPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)arrangementDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkoutBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkInBindingSource).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
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
        private ToolStripMenuItem toolStripMenuItem2;
        private TabPage arrangementPage;
        internal Button createArrangementButton;
        internal ComboBox collectionDropDown;
        internal DataGridView arrangementDataGrid;
        internal Button deleteArrangementButton;
        internal Label currentCollectionLabel;
        internal StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel1;
        // private PictureBox pictureBox1; // Removed
    }
}

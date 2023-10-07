namespace grace
{
    partial class Vivian
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
            openFileDialog = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            editToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            importInventoryToolStripMenuItem = new ToolStripMenuItem();
            printReportToolStripMenuItem = new ToolStripMenuItem();
            saveReportToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            tabControl1 = new TabControl();
            loginPage = new TabPage();
            chooseUserButton = new Button();
            groupBox1 = new GroupBox();
            radioButtonKaren = new RadioButton();
            radioButtonBetty = new RadioButton();
            radioButtonSue = new RadioButton();
            radioButtonPatti = new RadioButton();
            dataPage = new TabPage();
            dataGridView = new DataGridView();
            Brand = new DataGridViewTextBoxColumn();
            Barcode = new DataGridViewTextBoxColumn();
            sku = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            col1 = new DataGridViewTextBoxColumn();
            col2 = new DataGridViewTextBoxColumn();
            col3 = new DataGridViewTextBoxColumn();
            col4 = new DataGridViewTextBoxColumn();
            col5 = new DataGridViewTextBoxColumn();
            col6 = new DataGridViewTextBoxColumn();
            availabilty = new DataGridViewTextBoxColumn();
            previousTotal = new DataGridViewTextBoxColumn();
            currentTotal = new DataGridViewTextBoxColumn();
            bindingSource1 = new BindingSource(components);
            checkoutPage = new TabPage();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            loginPage.SuspendLayout();
            groupBox1.SuspendLayout();
            dataPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(3, 1, 0, 1);
            menuStrip1.Size = new Size(1300, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, importInventoryToolStripMenuItem, printReportToolStripMenuItem, saveReportToolStripMenuItem, exitToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(37, 22);
            editToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(163, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // importInventoryToolStripMenuItem
            // 
            importInventoryToolStripMenuItem.Name = "importInventoryToolStripMenuItem";
            importInventoryToolStripMenuItem.Size = new Size(163, 22);
            importInventoryToolStripMenuItem.Text = "Import Inventory";
            importInventoryToolStripMenuItem.Click += importInventoryToolStripMenuItem_Click;
            // 
            // printReportToolStripMenuItem
            // 
            printReportToolStripMenuItem.Name = "printReportToolStripMenuItem";
            printReportToolStripMenuItem.Size = new Size(163, 22);
            // 
            // saveReportToolStripMenuItem
            // 
            saveReportToolStripMenuItem.Name = "saveReportToolStripMenuItem";
            saveReportToolStripMenuItem.Size = new Size(163, 22);
            saveReportToolStripMenuItem.Text = "Save Report";
            saveReportToolStripMenuItem.Click += saveReportToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(163, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.AccessibleDescription = "Logo";
            pictureBox1.AccessibleName = "Logo";
            pictureBox1.BackColor = SystemColors.ControlLight;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Margin = new Padding(2, 1, 2, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(348, 123);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(loginPage);
            tabControl1.Controls.Add(dataPage);
            tabControl1.Controls.Add(checkoutPage);
            tabControl1.Location = new Point(0, 20);
            tabControl1.Margin = new Padding(2, 1, 2, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1300, 654);
            tabControl1.TabIndex = 9;
            // 
            // loginPage
            // 
            loginPage.Controls.Add(chooseUserButton);
            loginPage.Controls.Add(groupBox1);
            loginPage.Controls.Add(pictureBox1);
            loginPage.Location = new Point(4, 24);
            loginPage.Margin = new Padding(2, 1, 2, 1);
            loginPage.Name = "loginPage";
            loginPage.Padding = new Padding(2, 1, 2, 1);
            loginPage.Size = new Size(1292, 626);
            loginPage.TabIndex = 0;
            loginPage.Text = "Home";
            loginPage.UseVisualStyleBackColor = true;
            // 
            // chooseUserButton
            // 
            chooseUserButton.Location = new Point(412, 228);
            chooseUserButton.Margin = new Padding(2, 1, 2, 1);
            chooseUserButton.Name = "chooseUserButton";
            chooseUserButton.Size = new Size(134, 41);
            chooseUserButton.TabIndex = 8;
            chooseUserButton.Text = "Choose User";
            chooseUserButton.UseVisualStyleBackColor = true;
            chooseUserButton.Click += chooseUserButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonKaren);
            groupBox1.Controls.Add(radioButtonBetty);
            groupBox1.Controls.Add(radioButtonSue);
            groupBox1.Controls.Add(radioButtonPatti);
            groupBox1.Location = new Point(407, 74);
            groupBox1.Margin = new Padding(2, 1, 2, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 1, 2, 1);
            groupBox1.Size = new Size(149, 147);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // radioButtonKaren
            // 
            radioButtonKaren.AutoSize = true;
            radioButtonKaren.Location = new Point(15, 112);
            radioButtonKaren.Margin = new Padding(2, 1, 2, 1);
            radioButtonKaren.Name = "radioButtonKaren";
            radioButtonKaren.Size = new Size(55, 19);
            radioButtonKaren.TabIndex = 8;
            radioButtonKaren.TabStop = true;
            radioButtonKaren.Text = "Karen";
            radioButtonKaren.UseVisualStyleBackColor = true;
            // 
            // radioButtonBetty
            // 
            radioButtonBetty.AutoSize = true;
            radioButtonBetty.Location = new Point(15, 81);
            radioButtonBetty.Margin = new Padding(2, 1, 2, 1);
            radioButtonBetty.Name = "radioButtonBetty";
            radioButtonBetty.Size = new Size(52, 19);
            radioButtonBetty.TabIndex = 7;
            radioButtonBetty.TabStop = true;
            radioButtonBetty.Text = "Betty";
            radioButtonBetty.UseVisualStyleBackColor = true;
            // 
            // radioButtonSue
            // 
            radioButtonSue.AutoSize = true;
            radioButtonSue.ImageAlign = ContentAlignment.MiddleLeft;
            radioButtonSue.Location = new Point(15, 51);
            radioButtonSue.Margin = new Padding(2, 1, 2, 1);
            radioButtonSue.Name = "radioButtonSue";
            radioButtonSue.Size = new Size(44, 19);
            radioButtonSue.TabIndex = 6;
            radioButtonSue.TabStop = true;
            radioButtonSue.Text = "Sue";
            radioButtonSue.UseVisualStyleBackColor = true;
            // 
            // radioButtonPatti
            // 
            radioButtonPatti.AutoSize = true;
            radioButtonPatti.Location = new Point(15, 24);
            radioButtonPatti.Margin = new Padding(2, 1, 2, 1);
            radioButtonPatti.Name = "radioButtonPatti";
            radioButtonPatti.Size = new Size(49, 19);
            radioButtonPatti.TabIndex = 5;
            radioButtonPatti.TabStop = true;
            radioButtonPatti.Text = "Patti";
            radioButtonPatti.UseVisualStyleBackColor = true;
            // 
            // dataPage
            // 
            dataPage.Controls.Add(dataGridView);
            dataPage.Location = new Point(4, 24);
            dataPage.Name = "dataPage";
            dataPage.Size = new Size(1292, 626);
            dataPage.TabIndex = 1;
            dataPage.Text = "Inventory";
            dataPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { Brand, Barcode, sku, description, col1, col2, col3, col4, col5, col6, availabilty, previousTotal, currentTotal });
            dataGridView.Location = new Point(0, 5);
            dataGridView.Margin = new Padding(2, 1, 2, 1);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 82;
            dataGridView.RowTemplate.Height = 41;
            dataGridView.Size = new Size(1300, 625);
            dataGridView.TabIndex = 1;
            // 
            // Brand
            // 
            Brand.HeaderText = "Brand";
            Brand.MinimumWidth = 10;
            Brand.Name = "Brand";
            // 
            // Barcode
            // 
            Barcode.HeaderText = "Barcode";
            Barcode.MinimumWidth = 10;
            Barcode.Name = "Barcode";
            Barcode.Visible = false;
            Barcode.Width = 200;
            // 
            // sku
            // 
            sku.HeaderText = "Item Number";
            sku.MinimumWidth = 10;
            sku.Name = "sku";
            // 
            // description
            // 
            description.HeaderText = "Description";
            description.MinimumWidth = 10;
            description.Name = "description";
            description.Width = 200;
            // 
            // col1
            // 
            col1.HeaderText = "Collection1";
            col1.MinimumWidth = 10;
            col1.Name = "col1";
            col1.Width = 75;
            // 
            // col2
            // 
            col2.HeaderText = "Collection 2";
            col2.MinimumWidth = 10;
            col2.Name = "col2";
            col2.Width = 75;
            // 
            // col3
            // 
            col3.HeaderText = "Collection 3";
            col3.MinimumWidth = 10;
            col3.Name = "col3";
            col3.Width = 75;
            // 
            // col4
            // 
            col4.HeaderText = "Collection 4";
            col4.MinimumWidth = 10;
            col4.Name = "col4";
            col4.Width = 75;
            // 
            // col5
            // 
            col5.HeaderText = "Collection 5";
            col5.MinimumWidth = 10;
            col5.Name = "col5";
            col5.Width = 75;
            // 
            // col6
            // 
            col6.HeaderText = "Collection 6";
            col6.MinimumWidth = 10;
            col6.Name = "col6";
            col6.Width = 75;
            // 
            // availabilty
            // 
            availabilty.HeaderText = "Availability";
            availabilty.MinimumWidth = 10;
            availabilty.Name = "availabilty";
            availabilty.Width = 75;
            // 
            // previousTotal
            // 
            previousTotal.HeaderText = "Previous Total";
            previousTotal.MinimumWidth = 10;
            previousTotal.Name = "previousTotal";
            // 
            // currentTotal
            // 
            currentTotal.HeaderText = "Current Total";
            currentTotal.MinimumWidth = 10;
            currentTotal.Name = "currentTotal";
            // 
            // bindingSource1
            // 
            bindingSource1.BindingComplete += bindingSource1_BindingComplete;
            // 
            // checkoutPage
            // 
            checkoutPage.Location = new Point(4, 24);
            checkoutPage.Name = "checkoutPage";
            checkoutPage.Size = new Size(1292, 626);
            checkoutPage.TabIndex = 2;
            checkoutPage.Text = "Checkout";
            checkoutPage.UseVisualStyleBackColor = true;
            // 
            // Vivian
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 672);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2, 1, 2, 1);
            Name = "Vivian";
            Text = "VivianGrace";
            Load += Vivian_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            loginPage.ResumeLayout(false);
            loginPage.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            dataPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openFileDialog;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem importInventoryToolStripMenuItem;
        private ToolStripMenuItem saveReportToolStripMenuItem;
        private ToolStripMenuItem printReportToolStripMenuItem;
        private PictureBox pictureBox1;
        private TabControl tabControl1;
        private TabPage loginPage;
        private Button chooseUserButton;
        private GroupBox groupBox1;
        private RadioButton radioButtonKaren;
        private RadioButton radioButtonBetty;
        private RadioButton radioButtonSue;
        private RadioButton radioButtonPatti;
        private BindingSource bindingSource1;
        private TabPage dataPage;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn Brand;
        private DataGridViewTextBoxColumn Barcode;
        private DataGridViewTextBoxColumn sku;
        private DataGridViewTextBoxColumn description;
        private DataGridViewTextBoxColumn col1;
        private DataGridViewTextBoxColumn col2;
        private DataGridViewTextBoxColumn col3;
        private DataGridViewTextBoxColumn col4;
        private DataGridViewTextBoxColumn col5;
        private DataGridViewTextBoxColumn col6;
        private DataGridViewTextBoxColumn availabilty;
        private DataGridViewTextBoxColumn previousTotal;
        private DataGridViewTextBoxColumn currentTotal;
        private TabPage checkoutPage;
    }
}

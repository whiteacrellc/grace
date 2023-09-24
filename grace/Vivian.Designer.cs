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
            dataGridView1 = new DataGridView();
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
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            loginPage.SuspendLayout();
            groupBox1.SuspendLayout();
            dataPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            menuStrip1.Size = new Size(1808, 40);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, importInventoryToolStripMenuItem, printReportToolStripMenuItem, saveReportToolStripMenuItem, exitToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(71, 36);
            editToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(326, 44);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // importInventoryToolStripMenuItem
            // 
            importInventoryToolStripMenuItem.Name = "importInventoryToolStripMenuItem";
            importInventoryToolStripMenuItem.Size = new Size(326, 44);
            importInventoryToolStripMenuItem.Text = "Import Inventory";
            importInventoryToolStripMenuItem.Click += importInventoryToolStripMenuItem_Click;
            // 
            // printReportToolStripMenuItem
            // 
            printReportToolStripMenuItem.Name = "printReportToolStripMenuItem";
            printReportToolStripMenuItem.Size = new Size(326, 44);
            printReportToolStripMenuItem.Text = "Print Report";
            printReportToolStripMenuItem.Click += printReportToolStripMenuItem_Click;
            // 
            // saveReportToolStripMenuItem
            // 
            saveReportToolStripMenuItem.Name = "saveReportToolStripMenuItem";
            saveReportToolStripMenuItem.Size = new Size(326, 44);
            saveReportToolStripMenuItem.Text = "Save Report";
            saveReportToolStripMenuItem.Click += saveReportToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(326, 44);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.AccessibleDescription = "Logo";
            pictureBox1.AccessibleName = "Logo";
            pictureBox1.BackColor = SystemColors.ControlLight;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(6, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(354, 134);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(loginPage);
            tabControl1.Controls.Add(dataPage);
            tabControl1.Location = new Point(0, 43);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1808, 775);
            tabControl1.TabIndex = 9;
            // 
            // loginPage
            // 
            loginPage.Controls.Add(chooseUserButton);
            loginPage.Controls.Add(groupBox1);
            loginPage.Controls.Add(pictureBox1);
            loginPage.Location = new Point(8, 46);
            loginPage.Name = "loginPage";
            loginPage.Padding = new Padding(3);
            loginPage.Size = new Size(1792, 721);
            loginPage.TabIndex = 0;
            loginPage.UseVisualStyleBackColor = true;
            // 
            // chooseUserButton
            // 
            chooseUserButton.Location = new Point(231, 478);
            chooseUserButton.Name = "chooseUserButton";
            chooseUserButton.Size = new Size(249, 87);
            chooseUserButton.TabIndex = 8;
            chooseUserButton.Text = "Choose User";
            chooseUserButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonKaren);
            groupBox1.Controls.Add(radioButtonBetty);
            groupBox1.Controls.Add(radioButtonSue);
            groupBox1.Controls.Add(radioButtonPatti);
            groupBox1.Location = new Point(204, 158);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(276, 314);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // radioButtonKaren
            // 
            radioButtonKaren.AutoSize = true;
            radioButtonKaren.Location = new Point(28, 239);
            radioButtonKaren.Name = "radioButtonKaren";
            radioButtonKaren.Size = new Size(106, 36);
            radioButtonKaren.TabIndex = 8;
            radioButtonKaren.TabStop = true;
            radioButtonKaren.Text = "Karen";
            radioButtonKaren.UseVisualStyleBackColor = true;
            // 
            // radioButtonBetty
            // 
            radioButtonBetty.AutoSize = true;
            radioButtonBetty.Location = new Point(28, 172);
            radioButtonBetty.Name = "radioButtonBetty";
            radioButtonBetty.Size = new Size(100, 36);
            radioButtonBetty.TabIndex = 7;
            radioButtonBetty.TabStop = true;
            radioButtonBetty.Text = "Betty";
            radioButtonBetty.UseVisualStyleBackColor = true;
            // 
            // radioButtonSue
            // 
            radioButtonSue.AutoSize = true;
            radioButtonSue.ImageAlign = ContentAlignment.MiddleLeft;
            radioButtonSue.Location = new Point(28, 108);
            radioButtonSue.Name = "radioButtonSue";
            radioButtonSue.Size = new Size(85, 36);
            radioButtonSue.TabIndex = 6;
            radioButtonSue.TabStop = true;
            radioButtonSue.Text = "Sue";
            radioButtonSue.UseVisualStyleBackColor = true;
            // 
            // radioButtonPatti
            // 
            radioButtonPatti.AutoSize = true;
            radioButtonPatti.Location = new Point(28, 52);
            radioButtonPatti.Name = "radioButtonPatti";
            radioButtonPatti.Size = new Size(91, 36);
            radioButtonPatti.TabIndex = 5;
            radioButtonPatti.TabStop = true;
            radioButtonPatti.Text = "Patti";
            radioButtonPatti.UseVisualStyleBackColor = true;
            // 
            // dataPage
            // 
            dataPage.Controls.Add(dataGridView1);
            dataPage.Location = new Point(8, 46);
            dataPage.Name = "dataPage";
            dataPage.Padding = new Padding(3);
            dataPage.Size = new Size(1792, 721);
            dataPage.TabIndex = 1;
            dataPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Brand, Barcode, sku, description, col1, col2, col3, col4, col5, col6, availabilty, previousTotal, currentTotal });
            dataGridView1.Location = new Point(-8, -17);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.RowTemplate.Height = 41;
            dataGridView1.Size = new Size(1739, 644);
            dataGridView1.TabIndex = 0;
            // 
            // Brand
            // 
            Brand.HeaderText = "Brand";
            Brand.MinimumWidth = 10;
            Brand.Name = "Brand";
            Brand.Width = 200;
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
            sku.Width = 200;
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
            col1.Width = 200;
            // 
            // col2
            // 
            col2.HeaderText = "Collection 2";
            col2.MinimumWidth = 10;
            col2.Name = "col2";
            col2.Width = 200;
            // 
            // col3
            // 
            col3.HeaderText = "Collection 3";
            col3.MinimumWidth = 10;
            col3.Name = "col3";
            col3.Width = 200;
            // 
            // col4
            // 
            col4.HeaderText = "Collection 4";
            col4.MinimumWidth = 10;
            col4.Name = "col4";
            col4.Width = 200;
            // 
            // col5
            // 
            col5.HeaderText = "Collection 5";
            col5.MinimumWidth = 10;
            col5.Name = "col5";
            col5.Width = 200;
            // 
            // col6
            // 
            col6.HeaderText = "Collection 6";
            col6.MinimumWidth = 10;
            col6.Name = "col6";
            col6.Width = 200;
            // 
            // availabilty
            // 
            availabilty.HeaderText = "Availability";
            availabilty.MinimumWidth = 10;
            availabilty.Name = "availabilty";
            availabilty.Width = 200;
            // 
            // previousTotal
            // 
            previousTotal.HeaderText = "Previous Total";
            previousTotal.MinimumWidth = 10;
            previousTotal.Name = "previousTotal";
            previousTotal.Width = 200;
            // 
            // currentTotal
            // 
            currentTotal.HeaderText = "Current Total";
            currentTotal.MinimumWidth = 10;
            currentTotal.Name = "currentTotal";
            currentTotal.Width = 200;
            // 
            // bindingSource1
            // 
            bindingSource1.BindingComplete += bindingSource1_BindingComplete;
            // 
            // Vivian
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1808, 830);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Vivian";
            Text = "VivianGrace";
            Load += Vivian_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            loginPage.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            dataPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private TabPage dataPage;
        private DataGridView dataGridView1;
        private BindingSource bindingSource1;
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
    }
}

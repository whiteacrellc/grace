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
            tabControl = new TabControl();
            loginPage = new TabPage();
            chooseUserButton = new Button();
            groupBox1 = new GroupBox();
            radioButtonKaren = new RadioButton();
            radioButtonBetty = new RadioButton();
            radioButtonSue = new RadioButton();
            radioButtonPatti = new RadioButton();
            dataPage = new TabPage();
            label1 = new Label();
            textBox1 = new TextBox();
            dataGridView = new DataGridView();
            checkoutPage = new TabPage();
            dataGridView1 = new DataGridView();
            barcodeLabel = new Label();
            textBoxBarcode = new TextBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl.SuspendLayout();
            loginPage.SuspendLayout();
            groupBox1.SuspendLayout();
            dataPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            checkoutPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            menuStrip1.Size = new Size(2874, 40);
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
            pictureBox1.Location = new Point(108, 85);
            pictureBox1.Margin = new Padding(4, 2, 4, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(334, 129);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(loginPage);
            tabControl.Controls.Add(dataPage);
            tabControl.Controls.Add(checkoutPage);
            tabControl.Location = new Point(0, 43);
            tabControl.Margin = new Padding(4, 2, 4, 2);
            tabControl.MinimumSize = new Size(2900, 1490);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(2900, 1490);
            tabControl.TabIndex = 9;
            // 
            // loginPage
            // 
            loginPage.Controls.Add(chooseUserButton);
            loginPage.Controls.Add(groupBox1);
            loginPage.Controls.Add(pictureBox1);
            loginPage.Location = new Point(8, 46);
            loginPage.Margin = new Padding(4, 2, 4, 2);
            loginPage.Name = "loginPage";
            loginPage.Padding = new Padding(4, 2, 4, 2);
            loginPage.Size = new Size(2884, 1436);
            loginPage.TabIndex = 0;
            loginPage.Text = "Home";
            loginPage.UseVisualStyleBackColor = true;
            // 
            // chooseUserButton
            // 
            chooseUserButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chooseUserButton.Location = new Point(790, 625);
            chooseUserButton.Margin = new Padding(4, 2, 4, 2);
            chooseUserButton.Name = "chooseUserButton";
            chooseUserButton.Size = new Size(281, 77);
            chooseUserButton.TabIndex = 8;
            chooseUserButton.Text = "Choose User";
            chooseUserButton.UseVisualStyleBackColor = true;
            chooseUserButton.Click += chooseUserButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(radioButtonKaren);
            groupBox1.Controls.Add(radioButtonBetty);
            groupBox1.Controls.Add(radioButtonSue);
            groupBox1.Controls.Add(radioButtonPatti);
            groupBox1.Location = new Point(790, 189);
            groupBox1.Margin = new Padding(4, 2, 4, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 2, 4, 2);
            groupBox1.Size = new Size(277, 402);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // radioButtonKaren
            // 
            radioButtonKaren.AutoSize = true;
            radioButtonKaren.Location = new Point(28, 239);
            radioButtonKaren.Margin = new Padding(4, 2, 4, 2);
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
            radioButtonBetty.Location = new Point(28, 173);
            radioButtonBetty.Margin = new Padding(4, 2, 4, 2);
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
            radioButtonSue.Location = new Point(28, 109);
            radioButtonSue.Margin = new Padding(4, 2, 4, 2);
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
            radioButtonPatti.Location = new Point(28, 51);
            radioButtonPatti.Margin = new Padding(4, 2, 4, 2);
            radioButtonPatti.Name = "radioButtonPatti";
            radioButtonPatti.Size = new Size(91, 36);
            radioButtonPatti.TabIndex = 5;
            radioButtonPatti.TabStop = true;
            radioButtonPatti.Text = "Patti";
            radioButtonPatti.UseVisualStyleBackColor = true;
            // 
            // dataPage
            // 
            dataPage.Controls.Add(label1);
            dataPage.Controls.Add(textBox1);
            dataPage.Controls.Add(dataGridView);
            dataPage.Location = new Point(8, 46);
            dataPage.Margin = new Padding(6);
            dataPage.Name = "dataPage";
            dataPage.Size = new Size(2884, 1436);
            dataPage.TabIndex = 1;
            dataPage.Text = "Inventory";
            dataPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(323, 22);
            label1.Name = "label1";
            label1.Size = new Size(117, 32);
            label1.TabIndex = 3;
            label1.Text = "Filter SKU";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(16, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(273, 39);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(0, 84);
            dataGridView.Margin = new Padding(4, 2, 4, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 82;
            dataGridView.RowTemplate.Height = 41;
            dataGridView.Size = new Size(2795, 1327);
            dataGridView.TabIndex = 1;
            dataGridView.CellBeginEdit += dataGridView_CellBeginEdit;
            dataGridView.CellEndEdit += dataGridView_CellEndEdit;
            dataGridView.CellMouseDoubleClick += dataGridView_CellMouseDoubleClick;
            dataGridView.DataBindingComplete += dataGridView_DataBindingComplete;
            dataGridView.Paint += dataGridView_Paint;
            dataGridView.Resize += dataGridView_Resize;
            // 
            // checkoutPage
            // 
            checkoutPage.Controls.Add(dataGridView1);
            checkoutPage.Controls.Add(barcodeLabel);
            checkoutPage.Controls.Add(textBoxBarcode);
            checkoutPage.Location = new Point(8, 46);
            checkoutPage.Margin = new Padding(6);
            checkoutPage.Name = "checkoutPage";
            checkoutPage.Size = new Size(2884, 1436);
            checkoutPage.TabIndex = 2;
            checkoutPage.Text = "Checkout";
            checkoutPage.UseVisualStyleBackColor = true;
            checkoutPage.Click += checkoutPage_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(446, 320);
            dataGridView1.TabIndex = 2;
            // 
            // barcodeLabel
            // 
            barcodeLabel.AutoSize = true;
            barcodeLabel.Location = new Point(1683, 90);
            barcodeLabel.Margin = new Padding(6, 0, 6, 0);
            barcodeLabel.Name = "barcodeLabel";
            barcodeLabel.Size = new Size(157, 32);
            barcodeLabel.TabIndex = 1;
            barcodeLabel.Text = "Scan Barcode";
            // 
            // textBoxBarcode
            // 
            textBoxBarcode.Location = new Point(1857, 83);
            textBoxBarcode.Margin = new Padding(6);
            textBoxBarcode.Name = "textBoxBarcode";
            textBoxBarcode.Size = new Size(377, 39);
            textBoxBarcode.TabIndex = 0;
            textBoxBarcode.TextChanged += textBoxBarcode_TextChanged;
            textBoxBarcode.KeyDown += textBoxBarcode_KeyDown;
            // 
            // Vivian
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(2874, 1429);
            Controls.Add(tabControl);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 2, 4, 2);
            Name = "Vivian";
            Text = "VivianGrace";
            Load += Vivian_Load;
            Resize += Vivian_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl.ResumeLayout(false);
            loginPage.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            dataPage.ResumeLayout(false);
            dataPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            checkoutPage.ResumeLayout(false);
            checkoutPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private TabControl tabControl;
        private TabPage loginPage;
        private Button chooseUserButton;
        private GroupBox groupBox1;
        private RadioButton radioButtonKaren;
        private RadioButton radioButtonBetty;
        private RadioButton radioButtonSue;
        private RadioButton radioButtonPatti;
        private BindingSource bindingSource;
        private TabPage dataPage;
        private DataGridView dataGridView;
        private TabPage checkoutPage;
        private TextBox textBoxBarcode;
        private Label barcodeLabel;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBox1;
    }
}

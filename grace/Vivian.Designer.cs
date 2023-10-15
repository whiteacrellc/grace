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
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(loginPage);
            tabControl.Controls.Add(dataPage);
            tabControl.Controls.Add(checkoutPage);
            tabControl.Location = new Point(0, 20);
            tabControl.Margin = new Padding(2, 1, 2, 1);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1300, 654);
            tabControl.TabIndex = 9;
            tabControl.Selected += tabControl1_Selected;
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
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(0, 5);
            dataGridView.Margin = new Padding(2, 1, 2, 1);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 82;
            dataGridView.RowTemplate.Height = 41;
            dataGridView.Size = new Size(1300, 625);
            dataGridView.TabIndex = 1;
            dataGridView.CellFormatting += dataGridView_CellFormatting;
            dataGridView.DataBindingComplete += dataGridView_DataBindingComplete;
            // 
            // checkoutPage
            // 
            checkoutPage.Controls.Add(dataGridView1);
            checkoutPage.Controls.Add(barcodeLabel);
            checkoutPage.Controls.Add(textBoxBarcode);
            checkoutPage.Location = new Point(4, 24);
            checkoutPage.Name = "checkoutPage";
            checkoutPage.Size = new Size(1292, 626);
            checkoutPage.TabIndex = 2;
            checkoutPage.Text = "Checkout";
            checkoutPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 2;
            // 
            // barcodeLabel
            // 
            barcodeLabel.AutoSize = true;
            barcodeLabel.Location = new Point(906, 42);
            barcodeLabel.Name = "barcodeLabel";
            barcodeLabel.Size = new Size(78, 15);
            barcodeLabel.TabIndex = 1;
            barcodeLabel.Text = "Scan Barcode";
            // 
            // textBoxBarcode
            // 
            textBoxBarcode.Location = new Point(1000, 39);
            textBoxBarcode.Name = "textBoxBarcode";
            textBoxBarcode.Size = new Size(205, 23);
            textBoxBarcode.TabIndex = 0;
            textBoxBarcode.TextChanged += textBoxBarcode_TextChanged;
            textBoxBarcode.KeyDown += textBoxBarcode_KeyDown;
            // 
            // Vivian
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 672);
            Controls.Add(tabControl);
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
            tabControl.ResumeLayout(false);
            loginPage.ResumeLayout(false);
            loginPage.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            dataPage.ResumeLayout(false);
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
    }
}

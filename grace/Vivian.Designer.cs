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
            saveReportToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            tabControl = new TabControl();
            loginPage = new TabPage();
            loginButton = new Button();
            passwordTextBox = new TextBox();
            comboBoxUsers = new ComboBox();
            label4 = new Label();
            changePasswordButton = new Button();
            forgotPasswordButton = new Button();
            label3 = new Label();
            label2 = new Label();
            chooseUserButton = new Button();
            groupBox1 = new GroupBox();
            dataPage = new TabPage();
            addRowButton = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            dataGridView = new DataGridView();
            checkoutPage = new TabPage();
            barcodeLabel = new Label();
            textBoxBarcode = new TextBox();
            adminPage = new TabPage();
            errorProvider1 = new ErrorProvider(components);
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl.SuspendLayout();
            loginPage.SuspendLayout();
            dataPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            checkoutPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
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
            menuStrip1.Size = new Size(1624, 28);
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
            pictureBox1.Location = new Point(36, 32);
            pictureBox1.Margin = new Padding(5, 2, 5, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(342, 126);
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
            tabControl.Controls.Add(adminPage);
            tabControl.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point);
            tabControl.ItemSize = new Size(150, 48);
            tabControl.Location = new Point(0, 30);
            tabControl.Margin = new Padding(5, 2, 5, 2);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(30, 5);
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1804, 632);
            tabControl.TabIndex = 9;
            tabControl.TabStop = false;
            // 
            // loginPage
            // 
            loginPage.Controls.Add(loginButton);
            loginPage.Controls.Add(passwordTextBox);
            loginPage.Controls.Add(comboBoxUsers);
            loginPage.Controls.Add(label4);
            loginPage.Controls.Add(changePasswordButton);
            loginPage.Controls.Add(forgotPasswordButton);
            loginPage.Controls.Add(label3);
            loginPage.Controls.Add(label2);
            loginPage.Controls.Add(chooseUserButton);
            loginPage.Controls.Add(groupBox1);
            loginPage.Controls.Add(pictureBox1);
            loginPage.Location = new Point(4, 52);
            loginPage.Margin = new Padding(5, 2, 5, 2);
            loginPage.Name = "loginPage";
            loginPage.Padding = new Padding(5, 2, 5, 2);
            loginPage.Size = new Size(1796, 576);
            loginPage.TabIndex = 0;
            loginPage.Text = "Home";
            loginPage.ToolTipText = "Login Page";
            loginPage.UseVisualStyleBackColor = true;
            // 
            // loginButton
            // 
            loginButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            loginButton.Location = new Point(621, 213);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(88, 23);
            loginButton.TabIndex = 11;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(606, 180);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(121, 27);
            passwordTextBox.TabIndex = 10;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // comboBoxUsers
            // 
            comboBoxUsers.FormattingEnabled = true;
            comboBoxUsers.Location = new Point(606, 140);
            comboBoxUsers.Name = "comboBoxUsers";
            comboBoxUsers.Size = new Size(121, 27);
            comboBoxUsers.TabIndex = 9;
            comboBoxUsers.SelectedIndexChanged += comboBoxUsers_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(505, 180);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 15;
            label4.Text = "Password";
            // 
            // changePasswordButton
            // 
            changePasswordButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            changePasswordButton.Location = new Point(632, 254);
            changePasswordButton.Name = "changePasswordButton";
            changePasswordButton.Size = new Size(129, 23);
            changePasswordButton.TabIndex = 13;
            changePasswordButton.Text = "Change Password";
            changePasswordButton.UseVisualStyleBackColor = true;
            // 
            // forgotPasswordButton
            // 
            forgotPasswordButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            forgotPasswordButton.Location = new Point(482, 254);
            forgotPasswordButton.Name = "forgotPasswordButton";
            forgotPasswordButton.Size = new Size(129, 23);
            forgotPasswordButton.TabIndex = 12;
            forgotPasswordButton.Text = "Forgot Password";
            forgotPasswordButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(505, 176);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 12;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(505, 143);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 0;
            label2.Text = "Pick User";
            // 
            // chooseUserButton
            // 
            chooseUserButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chooseUserButton.Location = new Point(778, 335);
            chooseUserButton.Margin = new Padding(5, 2, 5, 2);
            chooseUserButton.Name = "chooseUserButton";
            chooseUserButton.Size = new Size(0, 0);
            chooseUserButton.TabIndex = 8;
            chooseUserButton.Text = "Choose User";
            chooseUserButton.UseVisualStyleBackColor = true;
            chooseUserButton.Click += chooseUserButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Location = new Point(542, 59);
            groupBox1.Margin = new Padding(5, 2, 5, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 2, 5, 2);
            groupBox1.Size = new Size(320, 0);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // dataPage
            // 
            dataPage.Controls.Add(addRowButton);
            dataPage.Controls.Add(label1);
            dataPage.Controls.Add(textBox1);
            dataPage.Controls.Add(dataGridView);
            dataPage.Location = new Point(4, 52);
            dataPage.Name = "dataPage";
            dataPage.Padding = new Padding(11, 12, 11, 12);
            dataPage.Size = new Size(1796, 576);
            dataPage.TabIndex = 1;
            dataPage.Text = "Inventory";
            dataPage.ToolTipText = "Inventory for Patti";
            dataPage.UseVisualStyleBackColor = true;
            // 
            // addRowButton
            // 
            addRowButton.Location = new Point(480, 4);
            addRowButton.Name = "addRowButton";
            addRowButton.Size = new Size(103, 38);
            addRowButton.TabIndex = 4;
            addRowButton.Text = "Add Row";
            addRowButton.UseVisualStyleBackColor = true;
            addRowButton.Click += addRowButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(337, 18);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 3;
            label1.Text = "Filter SKU";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(15, 15);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(314, 27);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(-4, 47);
            dataGridView.Margin = new Padding(5, 2, 5, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 82;
            dataGridView.RowTemplate.Height = 41;
            dataGridView.Size = new Size(1127, 459);
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
            checkoutPage.Controls.Add(barcodeLabel);
            checkoutPage.Controls.Add(textBoxBarcode);
            checkoutPage.Location = new Point(4, 52);
            checkoutPage.Margin = new Padding(7);
            checkoutPage.Name = "checkoutPage";
            checkoutPage.Size = new Size(1796, 576);
            checkoutPage.TabIndex = 2;
            checkoutPage.Text = "Checkout";
            checkoutPage.ToolTipText = "Checkout Items";
            checkoutPage.UseVisualStyleBackColor = true;
            checkoutPage.Click += checkoutPage_Click;
            // 
            // barcodeLabel
            // 
            barcodeLabel.AutoSize = true;
            barcodeLabel.Location = new Point(889, 45);
            barcodeLabel.Margin = new Padding(7, 0, 7, 0);
            barcodeLabel.Name = "barcodeLabel";
            barcodeLabel.Size = new Size(102, 20);
            barcodeLabel.TabIndex = 1;
            barcodeLabel.Text = "Scan Barcode";
            // 
            // textBoxBarcode
            // 
            textBoxBarcode.Location = new Point(1005, 38);
            textBoxBarcode.Margin = new Padding(7);
            textBoxBarcode.Name = "textBoxBarcode";
            textBoxBarcode.Size = new Size(434, 27);
            textBoxBarcode.TabIndex = 0;
            textBoxBarcode.TextChanged += textBoxBarcode_TextChanged;
            textBoxBarcode.KeyDown += textBoxBarcode_KeyDown;
            // 
            // adminPage
            // 
            adminPage.BackColor = SystemColors.Control;
            adminPage.BorderStyle = BorderStyle.Fixed3D;
            adminPage.Location = new Point(4, 52);
            adminPage.Name = "adminPage";
            adminPage.Size = new Size(1796, 576);
            adminPage.TabIndex = 3;
            adminPage.Text = "Admin";
            adminPage.ToolTipText = "Admin Settings";
            adminPage.Layout += adminPage_Layout;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Vivian
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1624, 661);
            Controls.Add(tabControl);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5, 2, 5, 2);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Vivian";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "VivianGrace";
            Load += Vivian_Load;
            Resize += Vivian_Resize;
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
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
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
        private PictureBox pictureBox1;
        private TabControl tabControl;
        private TabPage loginPage;
        private Button chooseUserButton;
        private GroupBox groupBox1;
        private TabPage dataPage;
        private DataGridView dataGridView;
        private TabPage checkoutPage;
        private TextBox textBoxBarcode;
        private Label barcodeLabel;
        private Label label1;
        private TextBox textBox1;
        private TabPage adminPage;
        private Button addRowButton;
        private ComboBox comboBoxUsers;
        private Label label3;
        private Label label2;
        private Button changePasswordButton;
        private Button forgotPasswordButton;
        private Label label4;
        private ErrorProvider errorProvider1;
        private TextBox passwordTextBox;
        private Button loginButton;
    }
}

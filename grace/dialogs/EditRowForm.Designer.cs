

namespace grace
{
    partial class EditRowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRowForm));
            cancelButton = new Button();
            panel1 = new Panel();
            noteTextBox = new TextBox();
            label9 = new Label();
            addCollectionLabel = new Label();
            addCollectionTextBox = new TextBox();
            checkedListBox = new CheckedListBox();
            label8 = new Label();
            collectionLabel = new Label();
            brandComboBox = new ComboBox();
            adjustTextBox = new TextBox();
            adjustInventoryLabel = new Label();
            currentTextBox = new TextBox();
            label6 = new Label();
            barCodeTextBox = new TextBox();
            availabilityTextBox = new TextBox();
            label5 = new Label();
            label4 = new Label();
            descTextBox = new TextBox();
            label3 = new Label();
            skuTextBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            saveButton = new Button();
            deleteButton = new Button();
            toolTip = new ToolTip(components);
            helpProvider = new HelpProvider();
            addBrandTextBox = new TextBox();
            label7 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.BackColor = Color.FromArgb(234, 221, 202);
            cancelButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            cancelButton.ForeColor = Color.FromArgb(54, 69, 79);
            cancelButton.Location = new Point(699, 512);
            cancelButton.Margin = new Padding(2, 1, 2, 1);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(113, 33);
            cancelButton.TabIndex = 11;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(255, 245, 238);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label7);
            panel1.Controls.Add(addBrandTextBox);
            panel1.Controls.Add(noteTextBox);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(addCollectionLabel);
            panel1.Controls.Add(addCollectionTextBox);
            panel1.Controls.Add(checkedListBox);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(collectionLabel);
            panel1.Controls.Add(brandComboBox);
            panel1.Controls.Add(adjustTextBox);
            panel1.Controls.Add(adjustInventoryLabel);
            panel1.Controls.Add(currentTextBox);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(barCodeTextBox);
            panel1.Controls.Add(availabilityTextBox);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(descTextBox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(skuTextBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(22, 38);
            panel1.Name = "panel1";
            panel1.Size = new Size(790, 457);
            panel1.TabIndex = 1;
            // 
            // noteTextBox
            // 
            noteTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            noteTextBox.BackColor = Color.FromArgb(255, 250, 240);
            noteTextBox.BorderStyle = BorderStyle.FixedSingle;
            noteTextBox.Font = new Font("Segoe UI", 10F);
            noteTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            noteTextBox.Location = new Point(146, 294);
            noteTextBox.Multiline = true;
            noteTextBox.Name = "noteTextBox";
            noteTextBox.Size = new Size(269, 67);
            noteTextBox.TabIndex = 31;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.ForeColor = Color.FromArgb(54, 69, 79);
            label9.Location = new Point(26, 295);
            label9.Name = "label9";
            label9.Size = new Size(39, 19);
            label9.TabIndex = 30;
            label9.Text = "Note";
            // 
            // addCollectionLabel
            // 
            addCollectionLabel.AutoSize = true;
            addCollectionLabel.Font = new Font("Segoe UI", 10F);
            addCollectionLabel.ForeColor = Color.FromArgb(54, 69, 79);
            addCollectionLabel.Location = new Point(433, 336);
            addCollectionLabel.Margin = new Padding(2, 0, 2, 0);
            addCollectionLabel.Name = "addCollectionLabel";
            addCollectionLabel.Size = new Size(144, 19);
            addCollectionLabel.TabIndex = 29;
            addCollectionLabel.Text = "Assign New Collection";
            addCollectionLabel.MouseHover += addCollectionLabel_MouseHover;
            // 
            // addCollectionTextBox
            // 
            addCollectionTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addCollectionTextBox.BackColor = Color.FromArgb(255, 250, 240);
            addCollectionTextBox.BorderStyle = BorderStyle.FixedSingle;
            addCollectionTextBox.Font = new Font("Segoe UI", 10F);
            addCollectionTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            addCollectionTextBox.Location = new Point(581, 336);
            addCollectionTextBox.Margin = new Padding(2, 1, 2, 1);
            addCollectionTextBox.Name = "addCollectionTextBox";
            addCollectionTextBox.Size = new Size(173, 25);
            addCollectionTextBox.TabIndex = 12;
            // 
            // checkedListBox
            // 
            checkedListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            checkedListBox.BackColor = Color.FromArgb(255, 250, 240);
            checkedListBox.BorderStyle = BorderStyle.FixedSingle;
            checkedListBox.Font = new Font("Segoe UI", 10F);
            checkedListBox.ForeColor = Color.FromArgb(54, 69, 79);
            checkedListBox.FormattingEnabled = true;
            checkedListBox.Location = new Point(581, 38);
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new Size(173, 262);
            checkedListBox.TabIndex = 28;
            checkedListBox.ItemCheck += checkedListBox_ItemCheck;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(54, 69, 79);
            label8.Location = new Point(17, 389);
            label8.Name = "label8";
            label8.Size = new Size(226, 21);
            label8.TabIndex = 27;
            label8.Text = "All bolded fields are mandatory";
            // 
            // collectionLabel
            // 
            collectionLabel.AutoSize = true;
            collectionLabel.Font = new Font("Georgia", 11F, FontStyle.Bold);
            collectionLabel.ForeColor = Color.FromArgb(54, 69, 79);
            collectionLabel.Location = new Point(581, 10);
            collectionLabel.Name = "collectionLabel";
            collectionLabel.Size = new Size(91, 18);
            collectionLabel.TabIndex = 26;
            collectionLabel.Text = "Collections";
            // 
            // brandComboBox
            // 
            brandComboBox.BackColor = Color.FromArgb(255, 250, 240);
            brandComboBox.FlatStyle = FlatStyle.Flat;
            brandComboBox.Font = new Font("Segoe UI", 10F);
            brandComboBox.ForeColor = Color.FromArgb(54, 69, 79);
            brandComboBox.FormattingEnabled = true;
            brandComboBox.Location = new Point(267, 52);
            brandComboBox.Name = "brandComboBox";
            brandComboBox.Size = new Size(148, 25);
            brandComboBox.TabIndex = 2;
            // 
            // adjustTextBox
            // 
            adjustTextBox.BackColor = Color.FromArgb(255, 250, 240);
            adjustTextBox.BorderStyle = BorderStyle.FixedSingle;
            adjustTextBox.Font = new Font("Segoe UI", 10F);
            adjustTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            adjustTextBox.Location = new Point(265, 241);
            adjustTextBox.Name = "adjustTextBox";
            adjustTextBox.Size = new Size(150, 25);
            adjustTextBox.TabIndex = 7;
            // 
            // adjustInventoryLabel
            // 
            adjustInventoryLabel.AutoSize = true;
            adjustInventoryLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            adjustInventoryLabel.ForeColor = Color.FromArgb(54, 69, 79);
            adjustInventoryLabel.Location = new Point(17, 247);
            adjustInventoryLabel.Name = "adjustInventoryLabel";
            adjustInventoryLabel.Size = new Size(228, 19);
            adjustInventoryLabel.TabIndex = 25;
            adjustInventoryLabel.Text = "Adjust Inventory By This Amount";
            // 
            // currentTextBox
            // 
            currentTextBox.BackColor = Color.FromArgb(255, 250, 240);
            currentTextBox.BorderStyle = BorderStyle.FixedSingle;
            currentTextBox.Font = new Font("Segoe UI", 10F);
            currentTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            currentTextBox.Location = new Point(265, 193);
            currentTextBox.Name = "currentTextBox";
            currentTextBox.ReadOnly = true;
            currentTextBox.Size = new Size(150, 25);
            currentTextBox.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.ForeColor = Color.FromArgb(54, 69, 79);
            label6.Location = new Point(17, 201);
            label6.Name = "label6";
            label6.Size = new Size(119, 19);
            label6.TabIndex = 25;
            label6.Text = "Current Inventory";
            // 
            // barCodeTextBox
            // 
            barCodeTextBox.BackColor = Color.FromArgb(255, 250, 240);
            barCodeTextBox.BorderStyle = BorderStyle.FixedSingle;
            barCodeTextBox.Font = new Font("Segoe UI", 10F);
            barCodeTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            barCodeTextBox.Location = new Point(265, 159);
            barCodeTextBox.Name = "barCodeTextBox";
            barCodeTextBox.Size = new Size(150, 25);
            barCodeTextBox.TabIndex = 5;
            barCodeTextBox.KeyDown += BarCodeTextBox_KeyDown;
            // 
            // availabilityTextBox
            // 
            availabilityTextBox.BackColor = Color.FromArgb(255, 250, 240);
            availabilityTextBox.BorderStyle = BorderStyle.FixedSingle;
            availabilityTextBox.Font = new Font("Segoe UI", 10F);
            availabilityTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            availabilityTextBox.Location = new Point(265, 121);
            availabilityTextBox.Name = "availabilityTextBox";
            availabilityTextBox.Size = new Size(150, 25);
            availabilityTextBox.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = Color.FromArgb(54, 69, 79);
            label5.Location = new Point(17, 162);
            label5.Name = "label5";
            label5.Size = new Size(65, 19);
            label5.TabIndex = 24;
            label5.Text = "Bar Code";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.FromArgb(54, 69, 79);
            label4.Location = new Point(17, 124);
            label4.Name = "label4";
            label4.Size = new Size(99, 19);
            label4.TabIndex = 23;
            label4.Text = "Reorder Status";
            // 
            // descTextBox
            // 
            descTextBox.BackColor = Color.FromArgb(255, 250, 240);
            descTextBox.BorderStyle = BorderStyle.FixedSingle;
            descTextBox.Font = new Font("Segoe UI", 10F);
            descTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            descTextBox.Location = new Point(146, 87);
            descTextBox.Name = "descTextBox";
            descTextBox.Size = new Size(269, 25);
            descTextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(54, 69, 79);
            label3.Location = new Point(17, 90);
            label3.Name = "label3";
            label3.Size = new Size(85, 19);
            label3.TabIndex = 22;
            label3.Text = "Description";
            // 
            // skuTextBox
            // 
            skuTextBox.BackColor = Color.FromArgb(255, 250, 240);
            skuTextBox.BorderStyle = BorderStyle.FixedSingle;
            skuTextBox.Font = new Font("Segoe UI", 10F);
            skuTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            skuTextBox.Location = new Point(265, 15);
            skuTextBox.Name = "skuTextBox";
            skuTextBox.Size = new Size(150, 25);
            skuTextBox.TabIndex = 1;
            skuTextBox.TextChanged += skuTextBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(54, 69, 79);
            label2.Location = new Point(17, 55);
            label2.Name = "label2";
            label2.Size = new Size(49, 19);
            label2.TabIndex = 21;
            label2.Text = "Brand";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(54, 69, 79);
            label1.Location = new Point(17, 18);
            label1.Name = "label1";
            label1.Size = new Size(36, 19);
            label1.TabIndex = 20;
            label1.Text = "SKU";
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.BackColor = Color.FromArgb(234, 221, 202);
            saveButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            saveButton.ForeColor = Color.FromArgb(54, 69, 79);
            saveButton.Location = new Point(40, 512);
            saveButton.Margin = new Padding(2, 1, 2, 1);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(113, 33);
            saveButton.TabIndex = 9;
            saveButton.Text = "Update";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += SaveButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            deleteButton.BackColor = Color.FromArgb(234, 221, 202);
            deleteButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            deleteButton.ForeColor = Color.FromArgb(54, 69, 79);
            deleteButton.Location = new Point(241, 512);
            deleteButton.Margin = new Padding(2, 1, 2, 1);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(113, 33);
            deleteButton.TabIndex = 10;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += DeleteButton_Click;
            // 
            // toolTip
            // 
            toolTip.ToolTipTitle = "Inventory Help";
            // 
            // addBrandTextBox
            // 
            addBrandTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addBrandTextBox.BackColor = Color.FromArgb(255, 250, 240);
            addBrandTextBox.BorderStyle = BorderStyle.FixedSingle;
            addBrandTextBox.Font = new Font("Segoe UI", 10F);
            addBrandTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            addBrandTextBox.Location = new Point(581, 385);
            addBrandTextBox.Margin = new Padding(2, 1, 2, 1);
            addBrandTextBox.Name = "addBrandTextBox";
            addBrandTextBox.Size = new Size(173, 25);
            addBrandTextBox.TabIndex = 32;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.ForeColor = Color.FromArgb(54, 69, 79);
            label7.Location = new Point(433, 387);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(120, 19);
            label7.TabIndex = 33;
            label7.Text = "Assign New Brand";
            // 
            // EditRowForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(255, 245, 238);
            CancelButton = cancelButton;
            ClientSize = new Size(858, 571);
            Controls.Add(deleteButton);
            Controls.Add(saveButton);
            Controls.Add(panel1);
            Controls.Add(cancelButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 1, 2, 1);
            Name = "EditRowForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Row Editor";
            Load += EditRowForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button cancelButton;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox skuTextBox;
        private Button saveButton;
        private Label label3;
        private TextBox availabilityTextBox;
        private Label label4;
        private TextBox descTextBox;
        private TextBox barCodeTextBox;
        private Label label5;
        private TextBox adjustTextBox;
        private Label adjustInventoryLabel;
        private TextBox currentTextBox;
        private Label label6;
        private Button deleteButton;
        private ToolTip toolTip;
        private ComboBox brandComboBox;
        private Label collectionLabel;
        private Label label8;
        private CheckedListBox checkedListBox;
        private Label addCollectionLabel;
        private TextBox addCollectionTextBox;
        private HelpProvider helpProvider;
        private TextBox noteTextBox;
        private Label label9;
        private Label label7;
        private TextBox addBrandTextBox;
    }
}

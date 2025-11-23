

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
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            cancelButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            cancelButton.FlatAppearance.BorderSize = 1;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            cancelButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            cancelButton.Location = new Point(699, 512); // Adjusted X for Right anchor (858 - 113 - approx 40 for padding)
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
            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE"); // Blend with form
            panel1.BorderStyle = BorderStyle.FixedSingle;
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
            noteTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            noteTextBox.BorderStyle = BorderStyle.FixedSingle;
            noteTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            noteTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            noteTextBox.Location = new Point(146, 294);
            noteTextBox.Multiline = true;
            noteTextBox.Name = "noteTextBox";
            noteTextBox.Size = new Size(269, 67); // Width will be adjusted by anchor
            noteTextBox.TabIndex = 31;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            label9.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            label9.Location = new Point(26, 295);
            label9.Name = "label9";
            label9.Size = new Size(37, 17);
            label9.TabIndex = 30;
            label9.Text = "Note";
            // 
            // addCollectionLabel
            // 
            addCollectionLabel.AutoSize = true;
            addCollectionLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            addCollectionLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
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
            addCollectionTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            addCollectionTextBox.BorderStyle = BorderStyle.FixedSingle;
            addCollectionTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            addCollectionTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            addCollectionTextBox.Location = new Point(581, 336);
            addCollectionTextBox.Margin = new Padding(2, 1, 2, 1);
            addCollectionTextBox.Name = "addCollectionTextBox";
            addCollectionTextBox.Size = new Size(173, 25);
            addCollectionTextBox.TabIndex = 12;
            // 
            // checkedListBox
            // 
            checkedListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            checkedListBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            checkedListBox.BorderStyle = BorderStyle.FixedSingle;
            checkedListBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            checkedListBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            checkedListBox.FormattingEnabled = true;
            checkedListBox.Location = new Point(581, 38);
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new Size(173, 274);
            checkedListBox.TabIndex = 28;
            checkedListBox.ItemCheck += checkedListBox_ItemCheck;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            label8.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            label8.Location = new Point(17, 389);
            label8.Name = "label8";
            label8.Size = new Size(254, 23);
            label8.TabIndex = 27;
            label8.Text = "All bolded fields are mandatory";
            // 
            // collectionLabel
            // 
            collectionLabel.AutoSize = true;
            collectionLabel.Font = new System.Drawing.Font("Georgia", 11F, FontStyle.Bold);
            collectionLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            collectionLabel.Location = new Point(581, 10);
            collectionLabel.Name = "collectionLabel";
            collectionLabel.Size = new Size(109, 25);
            collectionLabel.TabIndex = 26;
            collectionLabel.Text = "Collections";
            // 
            // brandComboBox
            // 
            brandComboBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            brandComboBox.FlatStyle = FlatStyle.Flat;
            brandComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            brandComboBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            brandComboBox.FormattingEnabled = true;
            brandComboBox.Location = new Point(267, 52);
            brandComboBox.Name = "brandComboBox";
            brandComboBox.Size = new Size(148, 25);
            brandComboBox.TabIndex = 2;
            // 
            // adjustTextBox
            // 
            adjustTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            adjustTextBox.BorderStyle = BorderStyle.FixedSingle;
            adjustTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            adjustTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            adjustTextBox.Location = new Point(265, 241);
            adjustTextBox.Name = "adjustTextBox";
            adjustTextBox.Size = new Size(150, 25);
            adjustTextBox.TabIndex = 7;
            // 
            // adjustInventoryLabel
            // 
            adjustInventoryLabel.AutoSize = true;
            adjustInventoryLabel.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            adjustInventoryLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            adjustInventoryLabel.Location = new Point(17, 247);
            adjustInventoryLabel.Name = "adjustInventoryLabel";
            adjustInventoryLabel.Size = new Size(228, 19);
            adjustInventoryLabel.TabIndex = 25;
            adjustInventoryLabel.Text = "Adjust Inventory By This Amount";
            // 
            // currentTextBox
            // 
            currentTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            currentTextBox.BorderStyle = BorderStyle.FixedSingle;
            currentTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            currentTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            currentTextBox.Location = new Point(265, 193);
            currentTextBox.Name = "currentTextBox";
            currentTextBox.ReadOnly = true;
            currentTextBox.Size = new Size(150, 25);
            currentTextBox.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            label6.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            label6.Location = new Point(17, 201);
            label6.Name = "label6";
            label6.Size = new Size(108, 17);
            label6.TabIndex = 25;
            label6.Text = "Current Inventory";
            // 
            // barCodeTextBox
            // 
            barCodeTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            barCodeTextBox.BorderStyle = BorderStyle.FixedSingle;
            barCodeTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            barCodeTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            barCodeTextBox.Location = new Point(265, 159);
            barCodeTextBox.Name = "barCodeTextBox";
            barCodeTextBox.Size = new Size(150, 25);
            barCodeTextBox.TabIndex = 5;
            barCodeTextBox.KeyDown += BarCodeTextBox_KeyDown;
            // 
            // availabilityTextBox
            // 
            availabilityTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            availabilityTextBox.BorderStyle = BorderStyle.FixedSingle;
            availabilityTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            availabilityTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            availabilityTextBox.Location = new Point(265, 121);
            availabilityTextBox.Name = "availabilityTextBox";
            availabilityTextBox.Size = new Size(150, 25);
            availabilityTextBox.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            label5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            label5.Location = new Point(17, 162);
            label5.Name = "label5";
            label5.Size = new Size(62, 17);
            label5.TabIndex = 24;
            label5.Text = "Bar Code";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            label4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            label4.Location = new Point(17, 124);
            label4.Name = "label4";
            label4.Size = new Size(95, 17);
            label4.TabIndex = 23;
            label4.Text = "Reorder Status";
            // 
            // descTextBox
            // 
            descTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            descTextBox.BorderStyle = BorderStyle.FixedSingle;
            descTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            descTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            descTextBox.Location = new Point(146, 87);
            descTextBox.Name = "descTextBox";
            descTextBox.Size = new Size(269, 25);
            descTextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            label3.Location = new Point(17, 90);
            label3.Name = "label3";
            label3.Size = new Size(79, 17);
            label3.TabIndex = 22;
            label3.Text = "Description";
            // 
            // skuTextBox
            // 
            skuTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFAF0");
            skuTextBox.BorderStyle = BorderStyle.FixedSingle;
            skuTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            skuTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            skuTextBox.Location = new Point(265, 15);
            skuTextBox.Name = "skuTextBox";
            skuTextBox.Size = new Size(150, 25);
            skuTextBox.TabIndex = 1;
            skuTextBox.TextChanged += skuTextBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            label2.Location = new Point(17, 55);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 21;
            label2.Text = "Brand";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            label1.Location = new Point(17, 18);
            label1.Name = "label1";
            label1.Size = new Size(32, 17);
            label1.TabIndex = 20;
            label1.Text = "SKU";
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            saveButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            saveButton.FlatAppearance.BorderSize = 1;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            saveButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
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
            deleteButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#EADDCA");
            deleteButton.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            deleteButton.FlatAppearance.BorderSize = 1;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            deleteButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
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
            // EditRowForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
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
    }
}

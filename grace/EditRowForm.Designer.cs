

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
            addCollectionLabel = new Label();
            addCollectionTextBox = new TextBox();
            checkedListBox = new CheckedListBox();
            label8 = new Label();
            label7 = new Label();
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
            cancelButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cancelButton.Location = new Point(452, 451);
            cancelButton.Margin = new Padding(2, 1, 2, 1);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(113, 33);
            cancelButton.TabIndex = 11;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(addCollectionLabel);
            panel1.Controls.Add(addCollectionTextBox);
            panel1.Controls.Add(checkedListBox);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
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
            panel1.Size = new Size(790, 387);
            panel1.TabIndex = 1;
            // 
            // addCollectionLabel
            // 
            addCollectionLabel.AutoSize = true;
            addCollectionLabel.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            addCollectionLabel.Location = new Point(429, 342);
            addCollectionLabel.Margin = new Padding(2, 0, 2, 0);
            addCollectionLabel.Name = "addCollectionLabel";
            addCollectionLabel.Size = new Size(144, 19);
            addCollectionLabel.TabIndex = 29;
            addCollectionLabel.Text = "Assign New Collection";
            addCollectionLabel.HelpRequested += label9_HelpRequested;
            addCollectionLabel.MouseHover += addCollectionLabel_MouseHover;
            // 
            // addCollectionTextBox
            // 
            addCollectionTextBox.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            addCollectionTextBox.Location = new Point(581, 338);
            addCollectionTextBox.Margin = new Padding(2, 1, 2, 1);
            addCollectionTextBox.Name = "addCollectionTextBox";
            addCollectionTextBox.Size = new Size(173, 25);
            addCollectionTextBox.TabIndex = 12;
            addCollectionTextBox.HelpRequested += textBox1_HelpRequested;
            addCollectionTextBox.MouseHover += addCollectionTextBox_MouseHover;
            // 
            // checkedListBox
            // 
            checkedListBox.FormattingEnabled = true;
            checkedListBox.Location = new Point(581, 38);
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new Size(173, 274);
            checkedListBox.TabIndex = 28;
            checkedListBox.ItemCheck += checkedListBox_ItemCheck;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(102, 299);
            label8.Name = "label8";
            label8.Size = new Size(254, 23);
            label8.TabIndex = 27;
            label8.Text = "All bolded fields are mandatory";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(581, 10);
            label7.Name = "label7";
            label7.Size = new Size(109, 25);
            label7.TabIndex = 26;
            label7.Text = "Collections";
            // 
            // brandComboBox
            // 
            brandComboBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            brandComboBox.FormattingEnabled = true;
            brandComboBox.Location = new Point(267, 52);
            brandComboBox.Name = "brandComboBox";
            brandComboBox.Size = new Size(148, 25);
            brandComboBox.TabIndex = 2;
            // 
            // adjustTextBox
            // 
            adjustTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            adjustTextBox.Location = new Point(265, 241);
            adjustTextBox.Name = "adjustTextBox";
            adjustTextBox.Size = new Size(150, 25);
            adjustTextBox.TabIndex = 7;
            // 
            // adjustInventoryLabel
            // 
            adjustInventoryLabel.AutoSize = true;
            adjustInventoryLabel.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            adjustInventoryLabel.Location = new Point(17, 247);
            adjustInventoryLabel.Name = "adjustInventoryLabel";
            adjustInventoryLabel.Size = new Size(228, 19);
            adjustInventoryLabel.TabIndex = 25;
            adjustInventoryLabel.Text = "Adjust Inventory By This Amount";
            adjustInventoryLabel.Click += adjustInventoryLabel_Click;
            // 
            // currentTextBox
            // 
            currentTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            currentTextBox.Location = new Point(265, 193);
            currentTextBox.Name = "currentTextBox";
            currentTextBox.ReadOnly = true;
            currentTextBox.Size = new Size(150, 25);
            currentTextBox.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(17, 201);
            label6.Name = "label6";
            label6.Size = new Size(108, 17);
            label6.TabIndex = 25;
            label6.Text = "Current Inventory";
            // 
            // barCodeTextBox
            // 
            barCodeTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            barCodeTextBox.Location = new Point(265, 159);
            barCodeTextBox.Name = "barCodeTextBox";
            barCodeTextBox.Size = new Size(150, 25);
            barCodeTextBox.TabIndex = 5;
            barCodeTextBox.KeyDown += barCodeTextBox_KeyDown;
            // 
            // availabilityTextBox
            // 
            availabilityTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            availabilityTextBox.Location = new Point(265, 121);
            availabilityTextBox.Name = "availabilityTextBox";
            availabilityTextBox.Size = new Size(150, 25);
            availabilityTextBox.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(17, 162);
            label5.Name = "label5";
            label5.Size = new Size(62, 17);
            label5.TabIndex = 24;
            label5.Text = "Bar Code";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(17, 124);
            label4.Name = "label4";
            label4.Size = new Size(95, 17);
            label4.TabIndex = 23;
            label4.Text = "Reorder Status";
            // 
            // descTextBox
            // 
            descTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            descTextBox.Location = new Point(146, 87);
            descTextBox.Name = "descTextBox";
            descTextBox.Size = new Size(269, 25);
            descTextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(17, 90);
            label3.Name = "label3";
            label3.Size = new Size(79, 17);
            label3.TabIndex = 22;
            label3.Text = "Description";
            // 
            // skuTextBox
            // 
            skuTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            skuTextBox.Location = new Point(265, 15);
            skuTextBox.Name = "skuTextBox";
            skuTextBox.Size = new Size(150, 25);
            skuTextBox.TabIndex = 1;
            skuTextBox.TextChanged += skuTextBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(17, 55);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 21;
            label2.Text = "Brand";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(17, 18);
            label1.Name = "label1";
            label1.Size = new Size(32, 17);
            label1.TabIndex = 20;
            label1.Text = "SKU";
            // 
            // saveButton
            // 
            saveButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            saveButton.Location = new Point(40, 451);
            saveButton.Margin = new Padding(2, 1, 2, 1);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(113, 33);
            saveButton.TabIndex = 9;
            saveButton.Text = "Update";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            deleteButton.Location = new Point(241, 451);
            deleteButton.Margin = new Padding(2, 1, 2, 1);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(113, 33);
            deleteButton.TabIndex = 10;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // toolTip
            // 
            toolTip.ToolTipTitle = "Inventory Help";
            // 
            // EditRowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(858, 497);
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
        private Label label7;
        private Label label8;
        private CheckedListBox checkedListBox;
        private Label addCollectionLabel;
        private TextBox addCollectionTextBox;
        private HelpProvider helpProvider;
    }
}

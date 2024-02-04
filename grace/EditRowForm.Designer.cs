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
            checkedListBox = new CheckedListBox();
            skuTextBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            saveButton = new Button();
            deleteButton = new Button();
            toolTip = new ToolTip(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cancelButton
            // 
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
            panel1.Controls.Add(checkedListBox);
            panel1.Controls.Add(skuTextBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(22, 89);
            panel1.Name = "panel1";
            panel1.Size = new Size(562, 336);
            panel1.TabIndex = 1;
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
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(455, 15);
            label7.Name = "label7";
            label7.Size = new Size(66, 15);
            label7.TabIndex = 26;
            label7.Text = "Categories";
            // 
            // brandComboBox
            // 
            brandComboBox.FormattingEnabled = true;
            brandComboBox.Location = new Point(135, 49);
            brandComboBox.Name = "brandComboBox";
            brandComboBox.Size = new Size(148, 23);
            brandComboBox.TabIndex = 2;
            // 
            // adjustTextBox
            // 
            adjustTextBox.Location = new Point(228, 239);
            adjustTextBox.Name = "adjustTextBox";
            adjustTextBox.Size = new Size(150, 23);
            adjustTextBox.TabIndex = 7;
            // 
            // adjustInventoryLabel
            // 
            adjustInventoryLabel.AutoSize = true;
            adjustInventoryLabel.Location = new Point(27, 241);
            adjustInventoryLabel.Name = "adjustInventoryLabel";
            adjustInventoryLabel.Size = new Size(181, 15);
            adjustInventoryLabel.TabIndex = 25;
            adjustInventoryLabel.Text = "Adjust Inventory By This Amount";
            // 
            // currentTextBox
            // 
            currentTextBox.Location = new Point(133, 198);
            currentTextBox.Name = "currentTextBox";
            currentTextBox.ReadOnly = true;
            currentTextBox.Size = new Size(150, 23);
            currentTextBox.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 201);
            label6.Name = "label6";
            label6.Size = new Size(100, 15);
            label6.TabIndex = 25;
            label6.Text = "Current Inventory";
            // 
            // barCodeTextBox
            // 
            barCodeTextBox.Location = new Point(133, 159);
            barCodeTextBox.Name = "barCodeTextBox";
            barCodeTextBox.Size = new Size(150, 23);
            barCodeTextBox.TabIndex = 5;
            barCodeTextBox.KeyDown += barCodeTextBox_KeyDown;
            // 
            // availabilityTextBox
            // 
            availabilityTextBox.Location = new Point(133, 121);
            availabilityTextBox.Name = "availabilityTextBox";
            availabilityTextBox.Size = new Size(150, 23);
            availabilityTextBox.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 162);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 24;
            label5.Text = "Bar Code";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 124);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 23;
            label4.Text = "Reorder Status";
            // 
            // descTextBox
            // 
            descTextBox.Location = new Point(135, 85);
            descTextBox.Name = "descTextBox";
            descTextBox.Size = new Size(269, 23);
            descTextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(27, 90);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 22;
            label3.Text = "Description";
            // 
            // checkedListBox
            // 
            checkedListBox.FormattingEnabled = true;
            checkedListBox.Location = new Point(428, 40);
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new Size(120, 274);
            checkedListBox.TabIndex = 8;
            checkedListBox.ItemCheck += checkedListBox_ItemCheck;
            // 
            // skuTextBox
            // 
            skuTextBox.Location = new Point(133, 15);
            skuTextBox.Name = "skuTextBox";
            skuTextBox.Size = new Size(150, 23);
            skuTextBox.TabIndex = 1;
            skuTextBox.TextChanged += skuTextBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(27, 52);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 21;
            label2.Text = "Brand";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(27, 18);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 20;
            label1.Text = "SKU";
            // 
            // saveButton
            // 
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
            ClientSize = new Size(640, 514);
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
        private CheckedListBox checkedListBox;
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
    }
}

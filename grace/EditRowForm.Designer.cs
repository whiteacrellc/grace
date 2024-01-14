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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRowForm));
            cancelButton = new Button();
            panel1 = new Panel();
            deleteTextBox = new TextBox();
            deleteInventoryLabel = new Label();
            addTextBox = new TextBox();
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
            brandTextBox = new TextBox();
            skuTextBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            saveButton = new Button();
            deleteButton = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(451, 324);
            cancelButton.Margin = new Padding(2, 1, 2, 1);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(113, 33);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(deleteTextBox);
            panel1.Controls.Add(deleteInventoryLabel);
            panel1.Controls.Add(addTextBox);
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
            panel1.Controls.Add(brandTextBox);
            panel1.Controls.Add(skuTextBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(562, 308);
            panel1.TabIndex = 1;
            // 
            // deleteTextBox
            // 
            deleteTextBox.Location = new Point(135, 255);
            deleteTextBox.Name = "deleteTextBox";
            deleteTextBox.Size = new Size(154, 23);
            deleteTextBox.TabIndex = 19;
            deleteTextBox.TextChanged += deltaTextBox_TextChanged;
            // 
            // deleteInventoryLabel
            // 
            deleteInventoryLabel.AutoSize = true;
            deleteInventoryLabel.Location = new Point(27, 263);
            deleteInventoryLabel.Name = "deleteInventoryLabel";
            deleteInventoryLabel.Size = new Size(93, 15);
            deleteInventoryLabel.TabIndex = 18;
            deleteInventoryLabel.Text = "Delete Inventory";
            // 
            // addTextBox
            // 
            addTextBox.Location = new Point(133, 224);
            addTextBox.Name = "addTextBox";
            addTextBox.Size = new Size(156, 23);
            addTextBox.TabIndex = 17;
            addTextBox.TextChanged += deltaTextBox_TextChanged;
            // 
            // adjustInventoryLabel
            // 
            adjustInventoryLabel.AutoSize = true;
            adjustInventoryLabel.Location = new Point(27, 229);
            adjustInventoryLabel.Name = "adjustInventoryLabel";
            adjustInventoryLabel.Size = new Size(82, 15);
            adjustInventoryLabel.TabIndex = 16;
            adjustInventoryLabel.Text = "Add Inventory";
            // 
            // currentTextBox
            // 
            currentTextBox.Location = new Point(133, 186);
            currentTextBox.Name = "currentTextBox";
            currentTextBox.ReadOnly = true;
            currentTextBox.Size = new Size(150, 23);
            currentTextBox.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 189);
            label6.Name = "label6";
            label6.Size = new Size(100, 15);
            label6.TabIndex = 14;
            label6.Text = "Current Inventory";
            // 
            // barCodeTextBox
            // 
            barCodeTextBox.Location = new Point(133, 146);
            barCodeTextBox.Name = "barCodeTextBox";
            barCodeTextBox.Size = new Size(150, 23);
            barCodeTextBox.TabIndex = 13;
            barCodeTextBox.KeyDown += barCodeTextBox_KeyDown;
            // 
            // availabilityTextBox
            // 
            availabilityTextBox.Location = new Point(133, 108);
            availabilityTextBox.Name = "availabilityTextBox";
            availabilityTextBox.Size = new Size(150, 23);
            availabilityTextBox.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 149);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 12;
            label5.Text = "Bar Code";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 111);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 8;
            label4.Text = "Availability";
            // 
            // descTextBox
            // 
            descTextBox.Location = new Point(135, 75);
            descTextBox.Name = "descTextBox";
            descTextBox.Size = new Size(269, 23);
            descTextBox.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 80);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 6;
            label3.Text = "Description";
            // 
            // checkedListBox
            // 
            checkedListBox.FormattingEnabled = true;
            checkedListBox.Location = new Point(428, 15);
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new Size(120, 274);
            checkedListBox.TabIndex = 5;
            checkedListBox.ItemCheck += checkedListBox_ItemCheck;
            // 
            // brandTextBox
            // 
            brandTextBox.Location = new Point(133, 44);
            brandTextBox.Name = "brandTextBox";
            brandTextBox.Size = new Size(150, 23);
            brandTextBox.TabIndex = 4;
            // 
            // skuTextBox
            // 
            skuTextBox.Location = new Point(133, 15);
            skuTextBox.Name = "skuTextBox";
            skuTextBox.Size = new Size(100, 23);
            skuTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 47);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "Brand";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 18);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 1;
            label1.Text = "SKU";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(39, 324);
            saveButton.Margin = new Padding(2, 1, 2, 1);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(113, 33);
            saveButton.TabIndex = 2;
            saveButton.Text = "Update";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(240, 324);
            deleteButton.Margin = new Padding(2, 1, 2, 1);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(113, 33);
            deleteButton.TabIndex = 3;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // EditRowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(594, 367);
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
            Text = "Previous Total";
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
        private TextBox brandTextBox;
        private TextBox skuTextBox;
        private CheckedListBox checkedListBox;
        private Button saveButton;
        private Label label3;
        private TextBox availabilityTextBox;
        private Label label4;
        private TextBox descTextBox;
        private TextBox barCodeTextBox;
        private Label label5;
        private TextBox addTextBox;
        private Label adjustInventoryLabel;
        private TextBox currentTextBox;
        private Label label6;
        private Button deleteButton;
        private TextBox deleteTextBox;
        private Label deleteInventoryLabel;
    }
}

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
            totalTextBox = new TextBox();
            label7 = new Label();
            prevTotTextBox = new TextBox();
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
            cancelButton.Location = new Point(838, 691);
            cancelButton.Margin = new Padding(4, 2, 4, 2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(210, 70);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(totalTextBox);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(prevTotTextBox);
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
            panel1.Location = new Point(22, 26);
            panel1.Margin = new Padding(6, 6, 6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(1044, 657);
            panel1.TabIndex = 1;
            // 
            // totalTextBox
            // 
            totalTextBox.Location = new Point(214, 482);
            totalTextBox.Margin = new Padding(6, 6, 6, 6);
            totalTextBox.Name = "totalTextBox";
            totalTextBox.Size = new Size(275, 39);
            totalTextBox.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(50, 489);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(65, 32);
            label7.TabIndex = 16;
            label7.Text = "Total";
            // 
            // prevTotTextBox
            // 
            prevTotTextBox.Location = new Point(214, 397);
            prevTotTextBox.Margin = new Padding(6, 6, 6, 6);
            prevTotTextBox.Name = "prevTotTextBox";
            prevTotTextBox.Size = new Size(275, 39);
            prevTotTextBox.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(50, 403);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(162, 32);
            label6.TabIndex = 14;
            label6.Text = "Previous Total";
            // 
            // barCodeTextBox
            // 
            barCodeTextBox.Location = new Point(214, 311);
            barCodeTextBox.Margin = new Padding(6, 6, 6, 6);
            barCodeTextBox.Name = "barCodeTextBox";
            barCodeTextBox.Size = new Size(275, 39);
            barCodeTextBox.TabIndex = 13;
            barCodeTextBox.KeyDown += barCodeTextBox_KeyDown;
            // 
            // availabilityTextBox
            // 
            availabilityTextBox.Location = new Point(214, 230);
            availabilityTextBox.Margin = new Padding(6, 6, 6, 6);
            availabilityTextBox.Name = "availabilityTextBox";
            availabilityTextBox.Size = new Size(275, 39);
            availabilityTextBox.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(50, 318);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(111, 32);
            label5.TabIndex = 12;
            label5.Text = "Bar Code";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 237);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(129, 32);
            label4.TabIndex = 8;
            label4.Text = "Availability";
            // 
            // descTextBox
            // 
            descTextBox.Location = new Point(217, 160);
            descTextBox.Margin = new Padding(6, 6, 6, 6);
            descTextBox.Name = "descTextBox";
            descTextBox.Size = new Size(557, 39);
            descTextBox.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 171);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(135, 32);
            label3.TabIndex = 6;
            label3.Text = "Description";
            // 
            // checkedListBox
            // 
            checkedListBox.FormattingEnabled = true;
            checkedListBox.Location = new Point(795, 32);
            checkedListBox.Margin = new Padding(6, 6, 6, 6);
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new Size(219, 580);
            checkedListBox.TabIndex = 5;
            // 
            // brandTextBox
            // 
            brandTextBox.Location = new Point(214, 94);
            brandTextBox.Margin = new Padding(6, 6, 6, 6);
            brandTextBox.Name = "brandTextBox";
            brandTextBox.Size = new Size(275, 39);
            brandTextBox.TabIndex = 4;
            // 
            // skuTextBox
            // 
            skuTextBox.Location = new Point(214, 32);
            skuTextBox.Margin = new Padding(6, 6, 6, 6);
            skuTextBox.Name = "skuTextBox";
            skuTextBox.Size = new Size(182, 39);
            skuTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 100);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(76, 32);
            label2.TabIndex = 2;
            label2.Text = "Brand";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 38);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(57, 32);
            label1.TabIndex = 1;
            label1.Text = "SKU";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(72, 691);
            saveButton.Margin = new Padding(4, 2, 4, 2);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(210, 70);
            saveButton.TabIndex = 2;
            saveButton.Text = "Update";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(446, 691);
            deleteButton.Margin = new Padding(4, 2, 4, 2);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(210, 70);
            deleteButton.TabIndex = 3;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // EditRowForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(1103, 783);
            Controls.Add(deleteButton);
            Controls.Add(saveButton);
            Controls.Add(panel1);
            Controls.Add(cancelButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 2, 4, 2);
            Name = "EditRowForm";
            ShowInTaskbar = false;
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
        private TextBox totalTextBox;
        private Label label7;
        private TextBox prevTotTextBox;
        private Label label6;
        private Button deleteButton;
    }
}

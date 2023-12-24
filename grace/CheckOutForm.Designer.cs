namespace grace
{
    partial class CheckOutForm
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
            label1 = new Label();
            brandLabel = new Label();
            label2 = new Label();
            skuLabel = new Label();
            descriptionLabel = new Label();
            label4 = new Label();
            totalLabel = new Label();
            label5 = new Label();
            label3 = new Label();
            label6 = new Label();
            numCheckOutTextBox = new TextBox();
            collectionComboBox = new ComboBox();
            saveButton = new Button();
            cancelButton = new Button();
            commentBox = new TextBox();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 17);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Brand";
            // 
            // brandLabel
            // 
            brandLabel.AutoSize = true;
            brandLabel.Location = new Point(133, 17);
            brandLabel.Name = "brandLabel";
            brandLabel.Size = new Size(0, 15);
            brandLabel.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 63);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 2;
            label2.Text = "Item Number";
            // 
            // skuLabel
            // 
            skuLabel.AutoSize = true;
            skuLabel.Location = new Point(133, 63);
            skuLabel.Name = "skuLabel";
            skuLabel.Size = new Size(0, 15);
            skuLabel.TabIndex = 3;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(133, 115);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(0, 15);
            descriptionLabel.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 115);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 4;
            label4.Text = "Description";
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Location = new Point(133, 163);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(0, 15);
            totalLabel.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 163);
            label5.Name = "label5";
            label5.Size = new Size(107, 15);
            label5.TabIndex = 6;
            label5.Text = "Currently Available";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(319, 21);
            label3.Name = "label3";
            label3.Size = new Size(120, 15);
            label3.TabIndex = 8;
            label3.Text = "Number To Checkout";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(319, 67);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 9;
            label6.Text = "CollectionName";
            // 
            // numCheckOutTextBox
            // 
            numCheckOutTextBox.Location = new Point(489, 13);
            numCheckOutTextBox.Name = "numCheckOutTextBox";
            numCheckOutTextBox.Size = new Size(121, 23);
            numCheckOutTextBox.TabIndex = 10;
            numCheckOutTextBox.KeyPress += numCheckOutTextBox_KeyPress;
            // 
            // collectionComboBox
            // 
            collectionComboBox.FormattingEnabled = true;
            collectionComboBox.Location = new Point(489, 59);
            collectionComboBox.Name = "collectionComboBox";
            collectionComboBox.Size = new Size(121, 23);
            collectionComboBox.TabIndex = 11;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(133, 210);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 12;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(269, 210);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 13;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // commentBox
            // 
            commentBox.AcceptsReturn = true;
            commentBox.Location = new Point(489, 112);
            commentBox.Multiline = true;
            commentBox.Name = "commentBox";
            commentBox.Size = new Size(127, 66);
            commentBox.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(319, 115);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 15;
            label7.Text = "Comment";
            // 
            // CheckOutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(628, 258);
            Controls.Add(label7);
            Controls.Add(commentBox);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(collectionComboBox);
            Controls.Add(numCheckOutTextBox);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(totalLabel);
            Controls.Add(label5);
            Controls.Add(descriptionLabel);
            Controls.Add(label4);
            Controls.Add(skuLabel);
            Controls.Add(label2);
            Controls.Add(brandLabel);
            Controls.Add(label1);
            Name = "CheckOutForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Check Out Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label brandLabel;
        private Label label2;
        private Label skuLabel;
        private Label descriptionLabel;
        private Label label4;
        private Label totalLabel;
        private Label label5;
        private Label label3;
        private Label label6;
        private TextBox numCheckOutTextBox;
        private ComboBox collectionComboBox;
        private Button saveButton;
        private Button cancelButton;
        private TextBox commentBox;
        private Label label7;
    }
}

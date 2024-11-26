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
            components = new System.ComponentModel.Container();
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
            helpProvider1 = new HelpProvider();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(94, 95);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 0;
            label1.Text = "Brand";
            // 
            // brandLabel
            // 
            brandLabel.AutoSize = true;
            brandLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            brandLabel.Location = new Point(148, 95);
            brandLabel.Name = "brandLabel";
            brandLabel.Size = new Size(29, 17);
            brandLabel.TabIndex = 1;
            brandLabel.Text = "asd";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(48, 141);
            label2.Name = "label2";
            label2.Size = new Size(90, 17);
            label2.TabIndex = 2;
            label2.Text = "Item Number";
            // 
            // skuLabel
            // 
            skuLabel.AutoSize = true;
            skuLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            skuLabel.Location = new Point(148, 141);
            skuLabel.Name = "skuLabel";
            skuLabel.Size = new Size(29, 17);
            skuLabel.TabIndex = 3;
            skuLabel.Text = "asd";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            descriptionLabel.Location = new Point(148, 193);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(29, 17);
            descriptionLabel.TabIndex = 5;
            descriptionLabel.Text = "asd";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(59, 193);
            label4.Name = "label4";
            label4.Size = new Size(79, 17);
            label4.TabIndex = 4;
            label4.Text = "Description";
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            totalLabel.Location = new Point(148, 241);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(29, 17);
            totalLabel.TabIndex = 7;
            totalLabel.Text = "asb";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(12, 241);
            label5.Name = "label5";
            label5.Size = new Size(126, 17);
            label5.TabIndex = 6;
            label5.Text = "Currently Available";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(310, 97);
            label3.Name = "label3";
            label3.Size = new Size(138, 17);
            label3.TabIndex = 8;
            label3.Text = "Number To Checkout";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(342, 149);
            label6.Name = "label6";
            label6.Size = new Size(106, 17);
            label6.TabIndex = 9;
            label6.Text = "CollectionName";
            label6.HelpRequested += label6_HelpRequested;
            // 
            // numCheckOutTextBox
            // 
            numCheckOutTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            numCheckOutTextBox.Location = new Point(489, 87);
            numCheckOutTextBox.Name = "numCheckOutTextBox";
            numCheckOutTextBox.Size = new Size(121, 25);
            numCheckOutTextBox.TabIndex = 10;
            numCheckOutTextBox.KeyPress += numCheckOutTextBox_KeyPress;
            // 
            // collectionComboBox
            // 
            collectionComboBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            collectionComboBox.FormattingEnabled = true;
            collectionComboBox.Location = new Point(489, 141);
            collectionComboBox.Name = "collectionComboBox";
            collectionComboBox.Size = new Size(121, 25);
            collectionComboBox.TabIndex = 11;
            collectionComboBox.ValueMemberChanged += CollectionComboBox_ValueMemberChanged;
            // 
            // saveButton
            // 
            saveButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            saveButton.Location = new Point(133, 308);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(90, 43);
            saveButton.TabIndex = 12;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.Location = new Point(269, 308);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(90, 43);
            cancelButton.TabIndex = 13;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // commentBox
            // 
            commentBox.AcceptsReturn = true;
            commentBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            commentBox.Location = new Point(489, 210);
            commentBox.Multiline = true;
            commentBox.Name = "commentBox";
            commentBox.Size = new Size(127, 66);
            commentBox.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(389, 210);
            label7.Name = "label7";
            label7.Size = new Size(68, 17);
            label7.TabIndex = 15;
            label7.Text = "Comment";
            // 
            // CheckOutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(658, 377);
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
            Load += CheckoutForm_Load;
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
        private HelpProvider helpProvider1;
        private ToolTip toolTip1;
    }
}

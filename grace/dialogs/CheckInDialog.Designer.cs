namespace grace
{
    partial class CheckInDialog
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
            updateButton = new Button();
            deleteButton = new Button();
            userTotalTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            collectionComboBox = new ComboBox();
            label3 = new Label();
            skuLabel = new Label();
            descriptionLabel = new Label();
            label5 = new Label();
            brandLabel = new Label();
            label7 = new Label();
            cancelButton = new Button();
            SuspendLayout();
            //
            // updateButton
            //
            updateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            updateButton.BackColor = Color.FromArgb(234, 221, 202);
            updateButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            updateButton.FlatAppearance.BorderSize = 1;
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            updateButton.ForeColor = Color.FromArgb(54, 69, 79);
            updateButton.Location = new Point(19, 246);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(95, 34);
            updateButton.TabIndex = 3;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = false;
            updateButton.Click += UpdateButton_Click;
            //
            // deleteButton
            //
            deleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            deleteButton.BackColor = Color.FromArgb(234, 221, 202);
            deleteButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            deleteButton.FlatAppearance.BorderSize = 1;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            deleteButton.ForeColor = Color.FromArgb(54, 69, 79);
            deleteButton.Location = new Point(135, 246);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(95, 34);
            deleteButton.TabIndex = 4;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            //
            // userTotalTextBox
            //
            userTotalTextBox.BackColor = Color.FromArgb(255, 250, 240);
            userTotalTextBox.BorderStyle = BorderStyle.FixedSingle;
            userTotalTextBox.Font = new Font("Segoe UI", 10F);
            userTotalTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            userTotalTextBox.Location = new Point(135, 172);
            userTotalTextBox.Name = "userTotalTextBox";
            userTotalTextBox.Size = new Size(198, 23);
            userTotalTextBox.TabIndex = 2;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.FromArgb(54, 69, 79);
            label1.Location = new Point(28, 175);
            label1.Name = "label1";
            label1.Size = new Size(86, 17);
            label1.TabIndex = 14;
            label1.Text = "Checked Out";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = Color.FromArgb(54, 69, 79);
            label2.Location = new Point(44, 136);
            label2.Name = "label2";
            label2.Size = new Size(70, 17);
            label2.TabIndex = 13;
            label2.Text = "Collection";
            //
            // collectionComboBox
            //
            collectionComboBox.BackColor = Color.FromArgb(255, 250, 240);
            collectionComboBox.FlatStyle = FlatStyle.Flat;
            collectionComboBox.Font = new Font("Segoe UI", 10F);
            collectionComboBox.ForeColor = Color.FromArgb(54, 69, 79);
            collectionComboBox.FormattingEnabled = true;
            collectionComboBox.Location = new Point(135, 135);
            collectionComboBox.Name = "collectionComboBox";
            collectionComboBox.Size = new Size(198, 23);
            collectionComboBox.TabIndex = 1;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.FromArgb(54, 69, 79);
            label3.Location = new Point(82, 29);
            label3.Name = "label3";
            label3.Size = new Size(32, 17);
            label3.TabIndex = 7;
            label3.Text = "SKU";
            //
            // skuLabel
            //
            skuLabel.AutoSize = true;
            skuLabel.Font = new Font("Segoe UI", 10F);
            skuLabel.ForeColor = Color.FromArgb(54, 69, 79);
            skuLabel.Location = new Point(135, 29);
            skuLabel.Name = "skuLabel";
            skuLabel.Size = new Size(32, 17);
            skuLabel.TabIndex = 8;
            skuLabel.Text = "SKU";
            //
            // descriptionLabel
            //
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Segoe UI", 10F);
            descriptionLabel.ForeColor = Color.FromArgb(54, 69, 79);
            descriptionLabel.Location = new Point(135, 85);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(32, 17);
            descriptionLabel.TabIndex = 9;
            descriptionLabel.Text = "SKU";
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = Color.FromArgb(54, 69, 79);
            label5.Location = new Point(35, 85);
            label5.Name = "label5";
            label5.Size = new Size(79, 17);
            label5.TabIndex = 10;
            label5.Text = "Description";
            //
            // brandLabel
            //
            brandLabel.AutoSize = true;
            brandLabel.Font = new Font("Segoe UI", 10F);
            brandLabel.ForeColor = Color.FromArgb(54, 69, 79);
            brandLabel.Location = new Point(135, 58);
            brandLabel.Name = "brandLabel";
            brandLabel.Size = new Size(32, 17);
            brandLabel.TabIndex = 11;
            brandLabel.Text = "SKU";
            //
            // label7
            //
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.ForeColor = Color.FromArgb(54, 69, 79);
            label7.Location = new Point(70, 58);
            label7.Name = "label7";
            label7.Size = new Size(44, 17);
            label7.TabIndex = 12;
            label7.Text = "Brand";
            //
            // cancelButton
            //
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.BackColor = Color.FromArgb(234, 221, 202);
            cancelButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            cancelButton.FlatAppearance.BorderSize = 1;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            cancelButton.ForeColor = Color.FromArgb(54, 69, 79);
            cancelButton.Location = new Point(297, 246); // Adjusted X for Right anchor
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(95, 34);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            //
            // CheckInDialog
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(255, 245, 238);
            CancelButton = cancelButton;
            ClientSize = new Size(404, 323);
            Controls.Add(cancelButton);
            Controls.Add(label7);
            Controls.Add(brandLabel);
            Controls.Add(label5);
            Controls.Add(descriptionLabel);
            Controls.Add(skuLabel);
            Controls.Add(label3);
            Controls.Add(collectionComboBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(userTotalTextBox);
            Controls.Add(deleteButton);
            Controls.Add(updateButton);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(54, 69, 79);
            Name = "CheckInDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "CheckInDialog";
            Load += CheckInDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button updateButton;
        private Button deleteButton;
        private TextBox userTotalTextBox;
        private Label label1;
        private Label label2;
        private ComboBox collectionComboBox;
        private Label label3;
        private Label skuLabel;
        private Label descriptionLabel;
        private Label label5;
        private Label brandLabel;
        private Label label7;
        private Button cancelButton;
    }
}

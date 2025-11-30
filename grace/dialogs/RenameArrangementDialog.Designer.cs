namespace grace.dialogs
{
    partial class RenameArrangementDialog
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
            newNameTextBox = new TextBox();
            titleLabel = new Label();
            newNameLabel = new Label();
            saveButton = new Button();
            cancelButton = new Button();
            currentNameLabel = new Label();
            SuspendLayout();
            // 
            // newNameTextBox
            // 
            newNameTextBox.BackColor = Color.FromArgb(255, 250, 240);
            newNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            newNameTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newNameTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            newNameTextBox.Location = new Point(127, 110);
            newNameTextBox.Name = "newNameTextBox";
            newNameTextBox.Size = new Size(220, 25);
            newNameTextBox.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.FromArgb(54, 69, 79);
            titleLabel.Location = new Point(39, 28);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(164, 20);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Rename Arrangement";
            // 
            // newNameLabel
            // 
            newNameLabel.AutoSize = true;
            newNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newNameLabel.ForeColor = Color.FromArgb(54, 69, 79);
            newNameLabel.Location = new Point(35, 112);
            newNameLabel.Name = "newNameLabel";
            newNameLabel.Size = new Size(76, 19);
            newNameLabel.TabIndex = 3;
            newNameLabel.Text = "New Name";
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(234, 221, 202);
            saveButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveButton.ForeColor = Color.FromArgb(54, 69, 79);
            saveButton.Location = new Point(80, 170);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(90, 35);
            saveButton.TabIndex = 7;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(234, 221, 202);
            cancelButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelButton.ForeColor = Color.FromArgb(54, 69, 79);
            cancelButton.Location = new Point(190, 170);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(90, 35);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += CancelButton_Click;
            // 
            // currentNameLabel
            // 
            currentNameLabel.AutoSize = true;
            currentNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentNameLabel.ForeColor = Color.FromArgb(54, 69, 79);
            currentNameLabel.Location = new Point(12, 69);
            currentNameLabel.Name = "currentNameLabel";
            currentNameLabel.Size = new Size(99, 19);
            currentNameLabel.TabIndex = 2;
            currentNameLabel.Text = "Current Name:";
            // 
            // RenameArrangementDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 245, 238);
            ClientSize = new Size(380, 240);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(newNameLabel);
            Controls.Add(currentNameLabel);
            Controls.Add(titleLabel);
            Controls.Add(newNameTextBox);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(54, 69, 79);
            Name = "RenameArrangementDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Rename Arrangement Dialog";
            Load += RenameArrangementDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label titleLabel;
        private Label currentNameLabel;
        private Button saveButton;
        private Button cancelButton;
        internal Label newNameLabel;
        internal TextBox newNameTextBox;
    }
}

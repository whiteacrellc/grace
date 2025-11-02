namespace grace.dialogs
{
    partial class AddArrangementDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddArrangementDialog));
            nameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            saveButton = new Button();
            cancelButton = new Button();
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // nameText
            // 
            nameTextBox.Location = new Point(90, 68);
            nameTextBox.Size = new Size(189, 23);
            nameTextBox.BackColor = Color.FromArgb(255, 250, 240);
            nameTextBox.BorderStyle = BorderStyle.FixedSingle;
            nameTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.TabIndex = 0;
            // 
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(54, 69, 79);
            label1.Location = new Point(39, 28);
            label1.Name = "label1";
            label1.Size = new Size(136, 20);
            label1.TabIndex = 1;
            label1.Text = "Add Arrangement";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(54, 69, 79);
             label2.Location = new Point(42, 76);
            label2.Name = "label2";
            label2.Size = new Size(44, 19);
            label2.TabIndex = 2;
            label2.Text = "Name";
            //

            // saveButton
            //
            saveButton.BackColor = Color.FromArgb(245, 245, 245);
            saveButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveButton.ForeColor = Color.FromArgb(54, 69, 79);
            saveButton.Location = new Point(35, 127);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(90, 35);
            saveButton.TabIndex = 7;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += SaveButton_Click;
            //
            // cancelButton
            //
            cancelButton.BackColor = Color.FromArgb(245, 245, 245);
            cancelButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelButton.ForeColor = Color.FromArgb(54, 69, 79);
            cancelButton.Location = new Point(140, 128);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(90, 35);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += CancelButton_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(59, 182);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(235, 23);
            progressBar.TabIndex = 9;
            // 
            // AddArrangementDialog
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 242);
            Controls.Add(progressBar);
            BackColor = Color.FromArgb(255, 245, 238);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nameTextBox);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(54, 69, 79);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddArrangementDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Arrangement Dialog";
            Load += AddArrangementDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private Label label1;
        private Label label2;
        private Button saveButton;
        private Button cancelButton;
        private ProgressBar progressBar;
    }
}

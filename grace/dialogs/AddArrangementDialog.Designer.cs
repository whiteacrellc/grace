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
            initialAmountTextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            collectionDropDown = new ComboBox();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // nameTextBox
            //
            nameTextBox.BackColor = Color.FromArgb(255, 250, 240);
            nameTextBox.BorderStyle = BorderStyle.FixedSingle;
            nameTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            nameTextBox.Location = new Point(128, 76);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(137, 25);
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
            label2.Location = new Point(80, 84);
            label2.Name = "label2";
            label2.Size = new Size(44, 19);
            label2.TabIndex = 2;
            label2.Text = "Name";
            // 
            // initialAmountTextBox
            //
            initialAmountTextBox.BackColor = Color.FromArgb(255, 250, 240);
            initialAmountTextBox.BorderStyle = BorderStyle.FixedSingle;
            initialAmountTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            initialAmountTextBox.ForeColor = Color.FromArgb(54, 69, 79);
            initialAmountTextBox.Location = new Point(128, 115);
            initialAmountTextBox.Name = "initialAmountTextBox";
            initialAmountTextBox.Size = new Size(137, 25);
            initialAmountTextBox.TabIndex = 3;
            initialAmountTextBox.Text = "0";
            initialAmountTextBox.TextAlign = HorizontalAlignment.Right;
            initialAmountTextBox.KeyPress += InitialAmountTextBox_KeyPressHandler;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(54, 69, 79);
            label3.Location = new Point(36, 118);
            label3.Name = "label3";
            label3.Size = new Size(95, 19);
            label3.TabIndex = 4;
            label3.Text = "Initial Amount";
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(54, 69, 79);
            label4.Location = new Point(56, 162);
            label4.Name = "label4";
            label4.Size = new Size(70, 19);
            label4.TabIndex = 5;
            label4.Text = "Collection";
            // 
            // collectionDropDown
            //
            collectionDropDown.BackColor = Color.FromArgb(255, 250, 240);
            collectionDropDown.FlatStyle = FlatStyle.Flat;
            collectionDropDown.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            collectionDropDown.ForeColor = Color.FromArgb(54, 69, 79);
            collectionDropDown.FormattingEnabled = true;
            collectionDropDown.Location = new Point(128, 159);
            collectionDropDown.Name = "collectionDropDown";
            collectionDropDown.Size = new Size(137, 25);
            collectionDropDown.TabIndex = 6;
            // 
            // saveButton
            //
            saveButton.BackColor = Color.FromArgb(245, 245, 245);
            saveButton.FlatAppearance.BorderColor = Color.FromArgb(207, 181, 59);
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveButton.ForeColor = Color.FromArgb(54, 69, 79);
            saveButton.Location = new Point(56, 225);
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
            cancelButton.Location = new Point(161, 225);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(90, 35);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += CancelButton_Click;
            // 
            // AddArrangementDialog
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 245, 238);
            ClientSize = new Size(635, 386);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(collectionDropDown);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(initialAmountTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nameTextBox);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(54, 69, 79);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddArrangementDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddArrangementDialog";
            Load += AddArrangementDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private Label label1;
        private Label label2;
        private TextBox initialAmountTextBox;
        private Label label3;
        private Label label4;
        private ComboBox collectionDropDown;
        private Button saveButton;
        private Button cancelButton;
    }
}

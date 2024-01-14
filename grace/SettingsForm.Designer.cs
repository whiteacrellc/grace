namespace grace
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            textBoxRowsPerPage = new TextBox();
            SettingsCancelButton = new Button();
            SaveButton = new Button();
            label1 = new Label();
            label2 = new Label();
            rowHeighrTextBox = new TextBox();
            SuspendLayout();
            // 
            // textBoxRowsPerPage
            // 
            textBoxRowsPerPage.Location = new Point(121, 20);
            textBoxRowsPerPage.Margin = new Padding(2, 1, 2, 1);
            textBoxRowsPerPage.Name = "textBoxRowsPerPage";
            textBoxRowsPerPage.Size = new Size(63, 23);
            textBoxRowsPerPage.TabIndex = 0;
            textBoxRowsPerPage.KeyPress += ValidateNumber_Callback;
            // 
            // SettingsCancelButton
            // 
            SettingsCancelButton.Location = new Point(110, 170);
            SettingsCancelButton.Margin = new Padding(2, 1, 2, 1);
            SettingsCancelButton.Name = "SettingsCancelButton";
            SettingsCancelButton.Size = new Size(83, 29);
            SettingsCancelButton.TabIndex = 1;
            SettingsCancelButton.Text = "Cancel";
            SettingsCancelButton.UseVisualStyleBackColor = true;
            SettingsCancelButton.Click += CancelButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(13, 170);
            SaveButton.Margin = new Padding(2, 1, 2, 1);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(82, 28);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 20);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 3;
            label1.Text = "Rows Per Page";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 52);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 4;
            label2.Text = "Row Height";
            // 
            // rowHeighrTextBox
            // 
            rowHeighrTextBox.Location = new Point(121, 52);
            rowHeighrTextBox.Margin = new Padding(2, 1, 2, 1);
            rowHeighrTextBox.Name = "rowHeighrTextBox";
            rowHeighrTextBox.Size = new Size(63, 23);
            rowHeighrTextBox.TabIndex = 5;
            rowHeighrTextBox.KeyPress += ValidateNumber_Callback;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 211);
            Controls.Add(rowHeighrTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SaveButton);
            Controls.Add(SettingsCancelButton);
            Controls.Add(textBoxRowsPerPage);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 1, 2, 1);
            Name = "SettingsForm";
            ShowIcon = false;
            Text = "Settings Form";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxRowsPerPage;
        private Button SettingsCancelButton;
        private Button SaveButton;
        private Label label1;
        private Label label2;
        private TextBox rowHeighrTextBox;
    }
}

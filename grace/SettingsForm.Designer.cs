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
            CancelButton = new Button();
            SaveButton = new Button();
            label1 = new Label();
            label2 = new Label();
            rowHeighrTextBox = new TextBox();
            SuspendLayout();
            // 
            // textBoxRowsPerPage
            // 
            textBoxRowsPerPage.Location = new Point(224, 42);
            textBoxRowsPerPage.Name = "textBoxRowsPerPage";
            textBoxRowsPerPage.Size = new Size(113, 39);
            textBoxRowsPerPage.TabIndex = 0;
            textBoxRowsPerPage.Validating += textBoxRowsPerPage_Validating;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(205, 362);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(155, 61);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(25, 362);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(153, 60);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 42);
            label1.Name = "label1";
            label1.Size = new Size(166, 32);
            label1.TabIndex = 3;
            label1.Text = "Rows Per Page";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 111);
            label2.Name = "label2";
            label2.Size = new Size(147, 32);
            label2.TabIndex = 4;
            label2.Text = "Rows Height";
            // 
            // rowHeighrTextBox
            // 
            rowHeighrTextBox.Location = new Point(224, 111);
            rowHeighrTextBox.Name = "rowHeighrTextBox";
            rowHeighrTextBox.Size = new Size(113, 39);
            rowHeighrTextBox.TabIndex = 5;
            rowHeighrTextBox.TextChanged += rowHeighrTextBox_TextChanged;
            rowHeighrTextBox.Validating += rowHeighrTextBox_Validating;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rowHeighrTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SaveButton);
            Controls.Add(CancelButton);
            Controls.Add(textBoxRowsPerPage);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            ShowIcon = false;
            Text = "Settings Form";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxRowsPerPage;
        private Button CancelButton;
        private Button SaveButton;
        private Label label1;
        private Label label2;
        private TextBox rowHeighrTextBox;
    }
}
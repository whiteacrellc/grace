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
            textBoxRowsPerPage = new TextBox();
            CancelButton = new Button();
            SaveButton = new Button();
            SuspendLayout();
            // 
            // textBoxRowsPerPage
            // 
            textBoxRowsPerPage.Location = new Point(558, 49);
            textBoxRowsPerPage.Name = "textBoxRowsPerPage";
            textBoxRowsPerPage.Size = new Size(185, 39);
            textBoxRowsPerPage.TabIndex = 0;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(591, 264);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(155, 61);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(589, 357);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(153, 60);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SaveButton);
            Controls.Add(CancelButton);
            Controls.Add(textBoxRowsPerPage);
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
    }
}
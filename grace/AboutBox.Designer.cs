namespace grace
{
    partial class AboutBox
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
            programLabel = new Label();
            authorLabel = new Label();
            buildLabel = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // programLabel
            // 
            programLabel.AutoSize = true;
            programLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            programLabel.Location = new Point(69, 31);
            programLabel.Name = "programLabel";
            programLabel.Size = new Size(231, 25);
            programLabel.TabIndex = 0;
            programLabel.Text = "Vivian Grace Accounting";
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            authorLabel.Location = new Point(69, 80);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(337, 25);
            authorLabel.TabIndex = 1;
            authorLabel.Text = "Copyright 2025 White Acre Software";
            // 
            // buildLabel
            // 
            buildLabel.AutoSize = true;
            buildLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buildLabel.Location = new Point(238, 146);
            buildLabel.Name = "buildLabel";
            buildLabel.Size = new Size(265, 21);
            buildLabel.TabIndex = 2;
            buildLabel.Text = "Copyright 2025 White Acre Software";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(69, 146);
            button1.Name = "button1";
            button1.Size = new Size(86, 42);
            button1.TabIndex = 3;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // AboutBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 200);
            Controls.Add(button1);
            Controls.Add(buildLabel);
            Controls.Add(authorLabel);
            Controls.Add(programLabel);
            Name = "AboutBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "AboutBox";
            Load += AboutBox_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label programLabel;
        private Label authorLabel;
        private Label buildLabel;
        private Button button1;
    }
}
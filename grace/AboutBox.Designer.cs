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
            programLabel.Font = new System.Drawing.Font("Georgia", 11F, FontStyle.Bold);
            programLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            programLabel.Location = new Point(69, 31);
            programLabel.Name = "programLabel";
            programLabel.Size = new Size(231, 25);
            programLabel.TabIndex = 0;
            programLabel.Text = "Vivian Grace Accounting";
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Font = new System.Drawing.Font("Georgia", 11F, FontStyle.Bold);
            authorLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            authorLabel.Location = new Point(69, 80);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(337, 25);
            authorLabel.TabIndex = 1;
            authorLabel.Text = "Copyright 2025 White Acre Software";
            // 
            // buildLabel
            // 
            buildLabel.AutoSize = true;
            buildLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            buildLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            buildLabel.Location = new Point(238, 146);
            buildLabel.Name = "buildLabel";
            buildLabel.Size = new Size(265, 21);
            buildLabel.TabIndex = 2;
            buildLabel.Text = "Copyright 2025 White Acre Software";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            button1.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CFB53B");
            button1.FlatAppearance.BorderSize = 1;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
            button1.Location = new Point(69, 146);
            button1.Name = "button1";
            button1.Size = new Size(86, 42);
            button1.TabIndex = 3;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // linkLabelReleases
            //
            this.linkLabelReleases = new System.Windows.Forms.LinkLabel();
            this.linkLabelReleases.AutoSize = true;
            this.linkLabelReleases.Font = new System.Drawing.Font("Segoe UI", 10F); // Match buildLabel font
            this.linkLabelReleases.ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F"); // Match buildLabel color
            this.linkLabelReleases.Location = new System.Drawing.Point(238, 171); // Position below buildLabel
            this.linkLabelReleases.Name = "linkLabelReleases";
            this.linkLabelReleases.Size = new System.Drawing.Size(150, 21); // Approximate size, AutoSize will adjust
            this.linkLabelReleases.TabIndex = 4; // Next available tab index
            this.linkLabelReleases.Text = "View Release Notes";
            this.linkLabelReleases.TabStop = true; // Ensure it's a tab stop
            //
            // AboutBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF5EE");
            ClientSize = new Size(520, 240);
            Controls.Add(this.linkLabelReleases);
            Controls.Add(button1);
            Controls.Add(buildLabel);
            Controls.Add(authorLabel);
            Controls.Add(programLabel);
            Font = new System.Drawing.Font("Segoe UI", 10F);
            ForeColor = System.Drawing.ColorTranslator.FromHtml("#36454F");
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
        private System.Windows.Forms.LinkLabel linkLabelReleases;
    }
}

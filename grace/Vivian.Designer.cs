﻿namespace grace
{
    partial class Vivian
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vivian));
            openFileButton = new Button();
            openFileDialog = new OpenFileDialog();
            pictureBox1 = new PictureBox();
            saveButton = new Button();
            debugTextBox = new TextBox();
            menuStrip1 = new MenuStrip();
            editToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            printReportButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // openFileButton
            // 
            openFileButton.Location = new Point(42, 224);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new Size(246, 69);
            openFileButton.TabIndex = 0;
            openFileButton.Text = "Open File";
            openFileButton.UseVisualStyleBackColor = true;
            openFileButton.Click += openFileButtonClick;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // pictureBox1
            // 
            pictureBox1.AccessibleDescription = "Logo";
            pictureBox1.AccessibleName = "Logo";
            pictureBox1.BackColor = SystemColors.ControlLight;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(42, 84);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(354, 134);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(42, 308);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(246, 69);
            saveButton.TabIndex = 2;
            saveButton.Text = "Save Report";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += generateAndSaveReport;
            // 
            // debugTextBox
            // 
            debugTextBox.Location = new Point(430, 12);
            debugTextBox.Multiline = true;
            debugTextBox.Name = "debugTextBox";
            debugTextBox.Size = new Size(926, 732);
            debugTextBox.TabIndex = 3;
            debugTextBox.TextChanged += debugTextBox_TextChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1444, 40);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, exitToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(74, 38);
            editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(233, 44);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(233, 44);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // printReportButton
            // 
            printReportButton.Location = new Point(42, 392);
            printReportButton.Name = "printReportButton";
            printReportButton.Size = new Size(246, 69);
            printReportButton.TabIndex = 5;
            printReportButton.Text = "Print Report";
            printReportButton.UseVisualStyleBackColor = true;
            printReportButton.Click += printReportButton_Click;
            // 
            // Vivian
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1444, 830);
            Controls.Add(debugTextBox);
            Controls.Add(printReportButton);
            Controls.Add(saveButton);
            Controls.Add(pictureBox1);
            Controls.Add(openFileButton);
            Controls.Add(menuStrip1);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Vivian";
            Text = "VivianGrace";
            Load += Vivian_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button openFileButton;
        private OpenFileDialog openFileDialog;
        private PictureBox pictureBox1;
        private Button saveButton;
        private TextBox debugTextBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Button printReportButton;
    }
}
namespace grace
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // openFileButton
            // 
            openFileButton.Location = new Point(42, 190);
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
            pictureBox1.Location = new Point(42, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(354, 134);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(42, 286);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(246, 69);
            saveButton.TabIndex = 2;
            saveButton.Text = "Save Report";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += generateAndSaveReport;
            // 
            // debugTextBox
            // 
            debugTextBox.Location = new Point(447, 48);
            debugTextBox.Multiline = true;
            debugTextBox.Name = "debugTextBox";
            debugTextBox.Size = new Size(926, 732);
            debugTextBox.TabIndex = 3;
            // 
            // Vivian
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1444, 830);
            Controls.Add(debugTextBox);
            Controls.Add(saveButton);
            Controls.Add(pictureBox1);
            Controls.Add(openFileButton);
            Name = "Vivian";
            Text = "VivianGrace";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button openFileButton;
        private OpenFileDialog openFileDialog;
        private PictureBox pictureBox1;
        private Button saveButton;
        private TextBox debugTextBox;
    }
}
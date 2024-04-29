namespace StudyDesk.View
{
    partial class AddSourceForm
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
            titleTextBox = new TextBox();
            uploadButton = new Button();
            filePathTextBox = new TextBox();
            fileLabel = new Label();
            titleLabel = new Label();
            addSourceButton = new Button();
            sourceTypeComboBox = new ComboBox();
            sourceTypeLabel = new Label();
            SuspendLayout();
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(125, 27);
            titleTextBox.Margin = new Padding(3, 2, 3, 2);
            titleTextBox.MaxLength = 50;
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(110, 23);
            titleTextBox.TabIndex = 1;
            // 
            // uploadButton
            // 
            uploadButton.Location = new Point(46, 100);
            uploadButton.Margin = new Padding(3, 2, 3, 2);
            uploadButton.Name = "uploadButton";
            uploadButton.Size = new Size(82, 22);
            uploadButton.TabIndex = 3;
            uploadButton.Text = "Upload";
            uploadButton.UseVisualStyleBackColor = true;
            uploadButton.Click += uploadButton_Click;
            // 
            // filePathTextBox
            // 
            filePathTextBox.Enabled = false;
            filePathTextBox.Location = new Point(226, 102);
            filePathTextBox.Margin = new Padding(3, 2, 3, 2);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.Size = new Size(110, 23);
            filePathTextBox.TabIndex = 5;
            // 
            // fileLabel
            // 
            fileLabel.AutoSize = true;
            fileLabel.Location = new Point(160, 104);
            fileLabel.Name = "fileLabel";
            fileLabel.Size = new Size(55, 15);
            fileLabel.TabIndex = 6;
            fileLabel.Text = "File Path:";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(84, 32);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(32, 15);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Title:";
            // 
            // addSourceButton
            // 
            addSourceButton.Location = new Point(125, 153);
            addSourceButton.Margin = new Padding(3, 2, 3, 2);
            addSourceButton.Name = "addSourceButton";
            addSourceButton.Size = new Size(82, 22);
            addSourceButton.TabIndex = 7;
            addSourceButton.Text = "Add Source";
            addSourceButton.UseVisualStyleBackColor = true;
            addSourceButton.Click += addSourceButton_Click;
            // 
            // sourceTypeComboBox
            // 
            sourceTypeComboBox.FormattingEnabled = true;
            sourceTypeComboBox.Location = new Point(160, 67);
            sourceTypeComboBox.Margin = new Padding(3, 2, 3, 2);
            sourceTypeComboBox.Name = "sourceTypeComboBox";
            sourceTypeComboBox.Size = new Size(133, 23);
            sourceTypeComboBox.TabIndex = 8;
            // 
            // sourceTypeLabel
            // 
            sourceTypeLabel.AutoSize = true;
            sourceTypeLabel.Location = new Point(48, 73);
            sourceTypeLabel.Name = "sourceTypeLabel";
            sourceTypeLabel.Size = new Size(73, 15);
            sourceTypeLabel.TabIndex = 9;
            sourceTypeLabel.Text = "Source Type:";
            // 
            // AddSourceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 193);
            Controls.Add(sourceTypeLabel);
            Controls.Add(sourceTypeComboBox);
            Controls.Add(addSourceButton);
            Controls.Add(fileLabel);
            Controls.Add(filePathTextBox);
            Controls.Add(uploadButton);
            Controls.Add(titleTextBox);
            Controls.Add(titleLabel);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "AddSourceForm";
            Text = "AddSourceForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox titleTextBox;
        private Button uploadButton;
        private Button button2;
        private TextBox filePathTextBox;
        private Label fileLabel;
        private Label titleLabel;
        private Button addSourceButton;
        private ComboBox sourceTypeComboBox;
        private Label sourceTypeLabel;
    }
}
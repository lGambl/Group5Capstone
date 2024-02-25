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
            titleTextBox.Location = new Point(143, 36);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(125, 27);
            titleTextBox.TabIndex = 1;
            // 
            // uploadButton
            // 
            uploadButton.Location = new Point(53, 134);
            uploadButton.Name = "uploadButton";
            uploadButton.Size = new Size(94, 29);
            uploadButton.TabIndex = 3;
            uploadButton.Text = "Upload";
            uploadButton.UseVisualStyleBackColor = true;
            uploadButton.Click += uploadButton_Click;
            // 
            // filePathTextBox
            // 
            filePathTextBox.Enabled = false;
            filePathTextBox.Location = new Point(258, 136);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.Size = new Size(125, 27);
            filePathTextBox.TabIndex = 5;
            // 
            // fileLabel
            // 
            fileLabel.AutoSize = true;
            fileLabel.Location = new Point(183, 139);
            fileLabel.Name = "fileLabel";
            fileLabel.Size = new Size(67, 20);
            fileLabel.TabIndex = 6;
            fileLabel.Text = "File Path:";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(96, 43);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(41, 20);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Title:";
            // 
            // addSourceButton
            // 
            addSourceButton.Location = new Point(143, 204);
            addSourceButton.Name = "addSourceButton";
            addSourceButton.Size = new Size(94, 29);
            addSourceButton.TabIndex = 7;
            addSourceButton.Text = "Add Source";
            addSourceButton.UseVisualStyleBackColor = true;
            addSourceButton.Click += addSourceButton_Click;
            // 
            // sourceTypeComboBox
            // 
            sourceTypeComboBox.FormattingEnabled = true;
            sourceTypeComboBox.Location = new Point(183, 89);
            sourceTypeComboBox.Name = "sourceTypeComboBox";
            sourceTypeComboBox.Size = new Size(151, 28);
            sourceTypeComboBox.TabIndex = 8;
            // 
            // sourceTypeLabel
            // 
            sourceTypeLabel.AutoSize = true;
            sourceTypeLabel.Location = new Point(55, 97);
            sourceTypeLabel.Name = "sourceTypeLabel";
            sourceTypeLabel.Size = new Size(92, 20);
            sourceTypeLabel.TabIndex = 9;
            sourceTypeLabel.Text = "Source Type:";
            // 
            // AddSourceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 257);
            Controls.Add(sourceTypeLabel);
            Controls.Add(sourceTypeComboBox);
            Controls.Add(addSourceButton);
            Controls.Add(fileLabel);
            Controls.Add(filePathTextBox);
            Controls.Add(uploadButton);
            Controls.Add(titleTextBox);
            Controls.Add(titleLabel);
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
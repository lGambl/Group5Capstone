namespace StudyDesk.View
{
    partial class AddTagForm
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
            addTagButton = new Button();
            tagTextBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // addTagButton
            // 
            addTagButton.Location = new Point(60, 81);
            addTagButton.Name = "addTagButton";
            addTagButton.Size = new Size(75, 23);
            addTagButton.TabIndex = 0;
            addTagButton.Text = "Add Tag";
            addTagButton.UseVisualStyleBackColor = true;
            addTagButton.Click += addTagButton_Click;
            // 
            // tagTextBox
            // 
            tagTextBox.Location = new Point(76, 30);
            tagTextBox.Name = "tagTextBox";
            tagTextBox.Size = new Size(100, 23);
            tagTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 2;
            label1.Text = "Enter Tag:";
            // 
            // AddTagForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(193, 113);
            Controls.Add(label1);
            Controls.Add(tagTextBox);
            Controls.Add(addTagButton);
            Name = "AddTagForm";
            Text = "AddTagForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addTagButton;
        private TextBox tagTextBox;
        private Label label1;
    }
}
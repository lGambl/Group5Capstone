namespace StudyDesk.View
{
    partial class AddNoteForm
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
            noteTextBox = new TextBox();
            addNoteButton = new Button();
            tagTextBox = new TextBox();
            addTagButton = new Button();
            tagsListView = new ListView();
            SuspendLayout();
            // 
            // noteTextBox
            // 
            noteTextBox.Location = new Point(27, 25);
            noteTextBox.Multiline = true;
            noteTextBox.Name = "noteTextBox";
            noteTextBox.Size = new Size(209, 135);
            noteTextBox.TabIndex = 0;
            // 
            // addNoteButton
            // 
            addNoteButton.Location = new Point(173, 241);
            addNoteButton.Name = "addNoteButton";
            addNoteButton.Size = new Size(75, 23);
            addNoteButton.TabIndex = 1;
            addNoteButton.Text = "Add Note";
            addNoteButton.UseVisualStyleBackColor = true;
            addNoteButton.Click += addNoteButton_Click;
            // 
            // tagTextBox
            // 
            tagTextBox.Location = new Point(272, 163);
            tagTextBox.Name = "tagTextBox";
            tagTextBox.Size = new Size(121, 23);
            tagTextBox.TabIndex = 2;
            // 
            // addTagButton
            // 
            addTagButton.Location = new Point(296, 192);
            addTagButton.Name = "addTagButton";
            addTagButton.Size = new Size(75, 23);
            addTagButton.TabIndex = 3;
            addTagButton.Text = "Add Tag";
            addTagButton.UseVisualStyleBackColor = true;
            addTagButton.Click += addTagButton_Click;
            // 
            // tagsListView
            // 
            tagsListView.Location = new Point(272, 44);
            tagsListView.Name = "tagsListView";
            tagsListView.Size = new Size(121, 97);
            tagsListView.TabIndex = 4;
            tagsListView.UseCompatibleStateImageBehavior = false;
            // 
            // AddNoteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 276);
            Controls.Add(tagsListView);
            Controls.Add(addTagButton);
            Controls.Add(tagTextBox);
            Controls.Add(addNoteButton);
            Controls.Add(noteTextBox);
            Name = "AddNoteForm";
            Text = "AddNoteForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox noteTextBox;
        private Button addNoteButton;
        private TextBox tagTextBox;
        private Button addTagButton;
        private ListView tagsListView;
    }
}
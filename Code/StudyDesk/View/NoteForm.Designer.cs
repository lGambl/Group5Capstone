namespace StudyDesk.View
{
    partial class NoteForm
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
            saveChangesButton = new Button();
            deleteNoteButton = new Button();
            addTagButton = new Button();
            deleteTagButton = new Button();
            tagsListView = new ListView();
            SuspendLayout();
            // 
            // noteTextBox
            // 
            noteTextBox.Location = new Point(12, 12);
            noteTextBox.Multiline = true;
            noteTextBox.Name = "noteTextBox";
            noteTextBox.Size = new Size(433, 104);
            noteTextBox.TabIndex = 0;
            // 
            // saveChangesButton
            // 
            saveChangesButton.Location = new Point(12, 122);
            saveChangesButton.Name = "saveChangesButton";
            saveChangesButton.Size = new Size(101, 23);
            saveChangesButton.TabIndex = 1;
            saveChangesButton.Text = "Save Changes";
            saveChangesButton.UseVisualStyleBackColor = true;
            saveChangesButton.Click += saveChangesButton_Click;
            // 
            // deleteNoteButton
            // 
            deleteNoteButton.Location = new Point(360, 122);
            deleteNoteButton.Name = "deleteNoteButton";
            deleteNoteButton.Size = new Size(85, 23);
            deleteNoteButton.TabIndex = 2;
            deleteNoteButton.Text = "Delete Note";
            deleteNoteButton.UseVisualStyleBackColor = true;
            deleteNoteButton.Click += deleteNoteButton_Click;
            // 
            // addTagButton
            // 
            addTagButton.Location = new Point(12, 244);
            addTagButton.Name = "addTagButton";
            addTagButton.Size = new Size(101, 23);
            addTagButton.TabIndex = 3;
            addTagButton.Text = "Add Tag";
            addTagButton.UseVisualStyleBackColor = true;
            addTagButton.Click += addTagButton_Click;
            // 
            // deleteTagButton
            // 
            deleteTagButton.Enabled = false;
            deleteTagButton.Location = new Point(360, 244);
            deleteTagButton.Name = "deleteTagButton";
            deleteTagButton.Size = new Size(85, 23);
            deleteTagButton.TabIndex = 4;
            deleteTagButton.Text = "Delete Tag";
            deleteTagButton.UseVisualStyleBackColor = true;
            deleteTagButton.Click += deleteTagButton_Click;
            // 
            // tagsListView
            // 
            tagsListView.Location = new Point(119, 144);
            tagsListView.MultiSelect = false;
            tagsListView.Name = "tagsListView";
            tagsListView.Size = new Size(235, 102);
            tagsListView.TabIndex = 5;
            tagsListView.UseCompatibleStateImageBehavior = false;
            tagsListView.View = System.Windows.Forms.View.List;
            tagsListView.SelectedIndexChanged += tagsListView_SelectedIndexChanged;
            // 
            // NoteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 279);
            Controls.Add(tagsListView);
            Controls.Add(deleteTagButton);
            Controls.Add(addTagButton);
            Controls.Add(deleteNoteButton);
            Controls.Add(saveChangesButton);
            Controls.Add(noteTextBox);
            Name = "NoteForm";
            Text = "NoteForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox noteTextBox;
        private Button saveChangesButton;
        private Button deleteNoteButton;
        private Button addTagButton;
        private Button deleteTagButton;
        private ListView tagsListView;
    }
}
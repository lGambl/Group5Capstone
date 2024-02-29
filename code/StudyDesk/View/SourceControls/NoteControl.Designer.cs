namespace StudyDesk.View.SourceControls
{
    partial class NoteControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            noteTextBox = new TextBox();
            addTagButton = new Button();
            deleteTagButton = new Button();
            tagsLlistView = new ListView();
            deleteNoteButton = new Button();
            saveChangesButton = new Button();
            SuspendLayout();
            // 
            // noteTextBox
            // 
            noteTextBox.Location = new Point(11, 15);
            noteTextBox.Margin = new Padding(3, 2, 3, 2);
            noteTextBox.Multiline = true;
            noteTextBox.Name = "noteTextBox";
            noteTextBox.Size = new Size(221, 118);
            noteTextBox.TabIndex = 0;
            // 
            // addTagButton
            // 
            addTagButton.Location = new Point(11, 251);
            addTagButton.Margin = new Padding(3, 2, 3, 2);
            addTagButton.Name = "addTagButton";
            addTagButton.Size = new Size(82, 32);
            addTagButton.TabIndex = 2;
            addTagButton.Text = "Add Tag";
            addTagButton.UseVisualStyleBackColor = true;
            // 
            // deleteTagButton
            // 
            deleteTagButton.Location = new Point(150, 251);
            deleteTagButton.Margin = new Padding(3, 2, 3, 2);
            deleteTagButton.Name = "deleteTagButton";
            deleteTagButton.Size = new Size(82, 32);
            deleteTagButton.TabIndex = 3;
            deleteTagButton.Text = "Delete Tag";
            deleteTagButton.UseVisualStyleBackColor = true;
            // 
            // tagsLlistView
            // 
            tagsLlistView.Location = new Point(11, 175);
            tagsLlistView.Margin = new Padding(3, 2, 3, 2);
            tagsLlistView.Name = "tagsLlistView";
            tagsLlistView.Size = new Size(221, 72);
            tagsLlistView.TabIndex = 4;
            tagsLlistView.UseCompatibleStateImageBehavior = false;
            // 
            // deleteNoteButton
            // 
            deleteNoteButton.Location = new Point(139, 137);
            deleteNoteButton.Margin = new Padding(3, 2, 3, 2);
            deleteNoteButton.Name = "deleteNoteButton";
            deleteNoteButton.Size = new Size(93, 24);
            deleteNoteButton.TabIndex = 5;
            deleteNoteButton.Text = "Delete Note";
            deleteNoteButton.UseVisualStyleBackColor = true;
            // 
            // saveChangesButton
            // 
            saveChangesButton.Location = new Point(11, 138);
            saveChangesButton.Name = "saveChangesButton";
            saveChangesButton.Size = new Size(90, 23);
            saveChangesButton.TabIndex = 6;
            saveChangesButton.Text = "Save Changes";
            saveChangesButton.UseVisualStyleBackColor = true;
            // 
            // NoteControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(saveChangesButton);
            Controls.Add(deleteNoteButton);
            Controls.Add(tagsLlistView);
            Controls.Add(deleteTagButton);
            Controls.Add(addTagButton);
            Controls.Add(noteTextBox);
            Margin = new Padding(3, 2, 3, 2);
            Name = "NoteControl";
            Size = new Size(242, 289);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox noteTextBox;
        private Button addTagButton;
        private Button deleteTagButton;
        private ListView tagsLlistView;
        private Button deleteNoteButton;
        private Button saveChangesButton;
    }
}

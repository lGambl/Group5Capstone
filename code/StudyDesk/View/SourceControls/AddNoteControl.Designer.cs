namespace StudyDesk.View.SourceControls
{
    partial class AddNoteControl
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
            tagsListView = new ListView();
            addNoteButton = new Button();
            tagTextBox = new TextBox();
            addTagButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // noteTextBox
            // 
            noteTextBox.Location = new Point(3, 4);
            noteTextBox.Margin = new Padding(3, 4, 3, 4);
            noteTextBox.Multiline = true;
            noteTextBox.Name = "noteTextBox";
            noteTextBox.Size = new Size(270, 115);
            noteTextBox.TabIndex = 0;
            // 
            // tagsListView
            // 
            tagsListView.Location = new Point(3, 180);
            tagsListView.Margin = new Padding(3, 4, 3, 4);
            tagsListView.Name = "tagsListView";
            tagsListView.Size = new Size(270, 84);
            tagsListView.TabIndex = 1;
            tagsListView.UseCompatibleStateImageBehavior = false;
            // 
            // addNoteButton
            // 
            addNoteButton.Location = new Point(94, 127);
            addNoteButton.Margin = new Padding(3, 4, 3, 4);
            addNoteButton.Name = "addNoteButton";
            addNoteButton.Size = new Size(86, 31);
            addNoteButton.TabIndex = 2;
            addNoteButton.Text = "Add Note";
            addNoteButton.UseVisualStyleBackColor = true;
            // 
            // tagTextBox
            // 
            tagTextBox.Location = new Point(3, 305);
            tagTextBox.Margin = new Padding(3, 4, 3, 4);
            tagTextBox.Name = "tagTextBox";
            tagTextBox.Size = new Size(270, 27);
            tagTextBox.TabIndex = 3;
            // 
            // addTagButton
            // 
            addTagButton.Location = new Point(94, 340);
            addTagButton.Margin = new Padding(3, 4, 3, 4);
            addTagButton.Name = "addTagButton";
            addTagButton.Size = new Size(86, 31);
            addTagButton.TabIndex = 4;
            addTagButton.Text = "Add Tag";
            addTagButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 281);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 5;
            label1.Text = "Add Tags";
            // 
            // AddNoteControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(addTagButton);
            Controls.Add(tagTextBox);
            Controls.Add(addNoteButton);
            Controls.Add(tagsListView);
            Controls.Add(noteTextBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddNoteControl";
            Size = new Size(276, 375);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox noteTextBox;
        private ListView tagsListView;
        private Button addNoteButton;
        private TextBox tagTextBox;
        private Button addTagButton;
        private Label label1;
    }
}

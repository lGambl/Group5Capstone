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
            noteTextBox.ForeColor = SystemColors.WindowFrame;
            noteTextBox.Location = new Point(3, 3);
            noteTextBox.Multiline = true;
            noteTextBox.Name = "noteTextBox";
            noteTextBox.Size = new Size(237, 87);
            noteTextBox.TabIndex = 0;
            noteTextBox.Text = "Enter your note here...";
            noteTextBox.Enter += noteTextBox_Enter;
            noteTextBox.Leave += noteTextBox_Leave;
            // 
            // tagsListView
            // 
            tagsListView.Location = new Point(3, 135);
            tagsListView.Name = "tagsListView";
            tagsListView.Size = new Size(237, 64);
            tagsListView.TabIndex = 1;
            tagsListView.UseCompatibleStateImageBehavior = false;
            tagsListView.View = System.Windows.Forms.View.List;
            // 
            // addNoteButton
            // 
            addNoteButton.Location = new Point(82, 95);
            addNoteButton.Name = "addNoteButton";
            addNoteButton.Size = new Size(75, 23);
            addNoteButton.TabIndex = 2;
            addNoteButton.Text = "Add Note";
            addNoteButton.UseVisualStyleBackColor = true;
            // 
            // tagTextBox
            // 
            tagTextBox.ForeColor = SystemColors.WindowFrame;
            tagTextBox.Location = new Point(3, 229);
            tagTextBox.Name = "tagTextBox";
            tagTextBox.Size = new Size(237, 23);
            tagTextBox.TabIndex = 3;
            tagTextBox.Text = "Enter your tag here...";
            tagTextBox.Enter += tagTextBox_Enter;
            tagTextBox.Leave += tagTextBox_Leave;
            // 
            // addTagButton
            // 
            addTagButton.Location = new Point(82, 255);
            addTagButton.Name = "addTagButton";
            addTagButton.Size = new Size(75, 23);
            addTagButton.TabIndex = 4;
            addTagButton.Text = "Add Tag";
            addTagButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 211);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 5;
            label1.Text = "Add Tags";
            // 
            // AddNoteControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(addTagButton);
            Controls.Add(tagTextBox);
            Controls.Add(addNoteButton);
            Controls.Add(tagsListView);
            Controls.Add(noteTextBox);
            Name = "AddNoteControl";
            Size = new Size(242, 281);
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

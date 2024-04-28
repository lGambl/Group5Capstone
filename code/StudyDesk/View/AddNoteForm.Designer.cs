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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // noteTextBox
            // 
            noteTextBox.ForeColor = SystemColors.WindowFrame;
            noteTextBox.Location = new Point(27, 25);
            noteTextBox.Multiline = true;
            noteTextBox.Name = "noteTextBox";
            noteTextBox.Size = new Size(360, 80);
            noteTextBox.TabIndex = 0;
            noteTextBox.Text = "Enter your note here...";
            noteTextBox.Enter += noteTextBox_Enter;
            noteTextBox.Leave += noteTextBox_Leave;
            // 
            // addNoteButton
            // 
            addNoteButton.Location = new Point(130, 241);
            addNoteButton.Name = "addNoteButton";
            addNoteButton.Size = new Size(152, 23);
            addNoteButton.TabIndex = 1;
            addNoteButton.Text = "Add Note";
            addNoteButton.UseVisualStyleBackColor = true;
            addNoteButton.Click += addNoteButton_Click;
            // 
            // tagTextBox
            // 
            tagTextBox.ForeColor = SystemColors.WindowFrame;
            tagTextBox.Location = new Point(27, 137);
            tagTextBox.Name = "tagTextBox";
            tagTextBox.Size = new Size(152, 23);
            tagTextBox.TabIndex = 2;
            tagTextBox.Text = "Enter your tag here...";
            tagTextBox.Enter += tagTextBox_Enter;
            tagTextBox.Leave += tagTextBox_Leave;
            // 
            // addTagButton
            // 
            addTagButton.Location = new Point(27, 166);
            addTagButton.Name = "addTagButton";
            addTagButton.Size = new Size(75, 23);
            addTagButton.TabIndex = 3;
            addTagButton.Text = "Add Tag";
            addTagButton.UseVisualStyleBackColor = true;
            addTagButton.Click += addTagButton_Click;
            // 
            // tagsListView
            // 
            tagsListView.Enabled = false;
            tagsListView.Location = new Point(208, 137);
            tagsListView.MultiSelect = false;
            tagsListView.Name = "tagsListView";
            tagsListView.Size = new Size(179, 81);
            tagsListView.TabIndex = 4;
            tagsListView.UseCompatibleStateImageBehavior = false;
            tagsListView.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(208, 119);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 5;
            label1.Text = "Tags:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 7);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 6;
            label2.Text = "Note";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 119);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 7;
            label3.Text = "Add Tags";
            // 
            // AddNoteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 276);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tagsListView);
            Controls.Add(addTagButton);
            Controls.Add(tagTextBox);
            Controls.Add(addNoteButton);
            Controls.Add(noteTextBox);
            MaximizeBox = false;
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
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
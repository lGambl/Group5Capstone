namespace StudyDesk.View
{
    partial class MainPageForm
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
            indexListView = new ListView();
            titleHeader = new ColumnHeader();
            addButton = new Button();
            deleteButton = new Button();
            logoutButton = new Button();
            label1 = new Label();
            searchNoteTagButton = new Button();
            searchNoteTagTextBox = new TextBox();
            label2 = new Label();
            resetSourcesButton = new Button();
            searchNoteTagPanel = new Panel();
            searchTagsListView = new ListView();
            addTagToSearchListButton = new Button();
            searchNoteTagPanel.SuspendLayout();
            SuspendLayout();
            // 
            // indexListView
            // 
            indexListView.Columns.AddRange(new ColumnHeader[] { titleHeader });
            indexListView.HeaderStyle = ColumnHeaderStyle.None;
            indexListView.Location = new Point(8, 222);
            indexListView.Margin = new Padding(3, 2, 3, 2);
            indexListView.Name = "indexListView";
            indexListView.Size = new Size(292, 226);
            indexListView.TabIndex = 0;
            indexListView.UseCompatibleStateImageBehavior = false;
            indexListView.View = System.Windows.Forms.View.Details;
            indexListView.SelectedIndexChanged += indexListView_SelectedIndexChanged;
            indexListView.MouseDoubleClick += indexListView_MouseDoubleClick;
            // 
            // titleHeader
            // 
            titleHeader.Text = "Title";
            titleHeader.Width = 325;
            // 
            // addButton
            // 
            addButton.Location = new Point(8, 453);
            addButton.Margin = new Padding(3, 2, 3, 2);
            addButton.Name = "addButton";
            addButton.Size = new Size(82, 22);
            addButton.TabIndex = 1;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Enabled = false;
            deleteButton.Location = new Point(218, 453);
            deleteButton.Margin = new Padding(3, 2, 3, 2);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(82, 22);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(218, 11);
            logoutButton.Margin = new Padding(3, 2, 3, 2);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(82, 26);
            logoutButton.TabIndex = 3;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 6);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 4;
            label1.Text = "Search Note Tags:";
            // 
            // searchNoteTagButton
            // 
            searchNoteTagButton.Location = new Point(92, 156);
            searchNoteTagButton.Name = "searchNoteTagButton";
            searchNoteTagButton.Size = new Size(87, 30);
            searchNoteTagButton.TabIndex = 5;
            searchNoteTagButton.Text = "Search Tags";
            searchNoteTagButton.UseVisualStyleBackColor = true;
            searchNoteTagButton.Click += searchNoteTagButton_Click;
            // 
            // searchNoteTagTextBox
            // 
            searchNoteTagTextBox.ForeColor = SystemColors.InactiveCaption;
            searchNoteTagTextBox.Location = new Point(3, 29);
            searchNoteTagTextBox.Name = "searchNoteTagTextBox";
            searchNoteTagTextBox.Size = new Size(176, 23);
            searchNoteTagTextBox.TabIndex = 6;
            searchNoteTagTextBox.Text = "Enter tag to search...";
            searchNoteTagTextBox.Enter += searchNoteTagTextBox_Enter;
            searchNoteTagTextBox.Leave += searchNoteTagTextBox_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 205);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 7;
            label2.Text = "Sources:";
            // 
            // resetSourcesButton
            // 
            resetSourcesButton.Location = new Point(115, 453);
            resetSourcesButton.Name = "resetSourcesButton";
            resetSourcesButton.Size = new Size(73, 22);
            resetSourcesButton.TabIndex = 8;
            resetSourcesButton.Text = "Reset";
            resetSourcesButton.UseVisualStyleBackColor = true;
            resetSourcesButton.Click += resetSourcesButton_Click;
            // 
            // searchNoteTagPanel
            // 
            searchNoteTagPanel.BorderStyle = BorderStyle.FixedSingle;
            searchNoteTagPanel.Controls.Add(addTagToSearchListButton);
            searchNoteTagPanel.Controls.Add(searchTagsListView);
            searchNoteTagPanel.Controls.Add(searchNoteTagButton);
            searchNoteTagPanel.Controls.Add(searchNoteTagTextBox);
            searchNoteTagPanel.Controls.Add(label1);
            searchNoteTagPanel.Location = new Point(8, 11);
            searchNoteTagPanel.Name = "searchNoteTagPanel";
            searchNoteTagPanel.Size = new Size(188, 191);
            searchNoteTagPanel.TabIndex = 9;
            // 
            // searchTagsListView
            // 
            searchTagsListView.Location = new Point(4, 96);
            searchTagsListView.Name = "searchTagsListView";
            searchTagsListView.Size = new Size(175, 54);
            searchTagsListView.TabIndex = 7;
            searchTagsListView.UseCompatibleStateImageBehavior = false;
            // 
            // addTagToSearchListButton
            // 
            addTagToSearchListButton.Location = new Point(50, 58);
            addTagToSearchListButton.Name = "addTagToSearchListButton";
            addTagToSearchListButton.Size = new Size(129, 23);
            addTagToSearchListButton.TabIndex = 8;
            addTagToSearchListButton.Text = "Add tag to search list";
            addTagToSearchListButton.UseVisualStyleBackColor = true;
            addTagToSearchListButton.Click += addTagToSearchListButton_Click;
            // 
            // MainPageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 486);
            Controls.Add(searchNoteTagPanel);
            Controls.Add(resetSourcesButton);
            Controls.Add(label2);
            Controls.Add(logoutButton);
            Controls.Add(deleteButton);
            Controls.Add(addButton);
            Controls.Add(indexListView);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainPageForm";
            Text = "MainPageForm";
            searchNoteTagPanel.ResumeLayout(false);
            searchNoteTagPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView indexListView;
        private ColumnHeader titleHeader;
        private Button addButton;
        private Button deleteButton;
        private Button logoutButton;
        private Label label1;
        private Button searchNoteTagButton;
        private TextBox searchNoteTagTextBox;
        private Label label2;
        private Button resetSourcesButton;
        private Panel searchNoteTagPanel;
        private ListView searchTagsListView;
        private Button addTagToSearchListButton;
    }
}
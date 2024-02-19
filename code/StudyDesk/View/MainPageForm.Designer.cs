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
            SuspendLayout();
            // 
            // indexListView
            // 
            indexListView.Columns.AddRange(new ColumnHeader[] { titleHeader });
            indexListView.Location = new Point(10, 36);
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
            addButton.Location = new Point(10, 9);
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
            deleteButton.Location = new Point(220, 9);
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
            logoutButton.Location = new Point(116, 9);
            logoutButton.Margin = new Padding(3, 2, 3, 2);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(82, 22);
            logoutButton.TabIndex = 3;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // MainPageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 270);
            Controls.Add(logoutButton);
            Controls.Add(deleteButton);
            Controls.Add(addButton);
            Controls.Add(indexListView);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainPageForm";
            Text = "MainPageForm";
            ResumeLayout(false);
        }

        #endregion

        private ListView indexListView;
        private ColumnHeader titleHeader;
        private Button addButton;
        private Button deleteButton;
        private Button logoutButton;
    }
}
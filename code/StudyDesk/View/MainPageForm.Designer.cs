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
            SuspendLayout();
            // 
            // indexListView
            // 
            indexListView.Columns.AddRange(new ColumnHeader[] { titleHeader });
            indexListView.Location = new Point(12, 48);
            indexListView.Name = "indexListView";
            indexListView.Size = new Size(333, 300);
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
            addButton.Location = new Point(12, 12);
            addButton.Name = "addButton";
            addButton.Size = new Size(94, 29);
            addButton.TabIndex = 1;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Enabled = false;
            deleteButton.Location = new Point(251, 12);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(94, 29);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // MainPageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 360);
            Controls.Add(deleteButton);
            Controls.Add(addButton);
            Controls.Add(indexListView);
            Name = "MainPageForm";
            Text = "MainPageForm";
            ResumeLayout(false);
        }

        #endregion

        private ListView indexListView;
        private ColumnHeader titleHeader;
        private Button addButton;
        private Button deleteButton;
    }
}
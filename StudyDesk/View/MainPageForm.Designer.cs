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
            typeHeader = new ColumnHeader();
            actionLabel = new Label();
            viewButton = new Button();
            SuspendLayout();
            // 
            // indexListView
            // 
            indexListView.Columns.AddRange(new ColumnHeader[] { titleHeader, typeHeader });
            indexListView.Location = new Point(12, 12);
            indexListView.Name = "indexListView";
            indexListView.Size = new Size(339, 166);
            indexListView.TabIndex = 0;
            indexListView.UseCompatibleStateImageBehavior = false;
            // 
            // titleHeader
            // 
            titleHeader.Text = "Title";
            // 
            // typeHeader
            // 
            typeHeader.Text = "Type";
            // 
            // actionLabel
            // 
            actionLabel.AutoSize = true;
            actionLabel.Location = new Point(550, 58);
            actionLabel.Name = "actionLabel";
            actionLabel.Size = new Size(58, 20);
            actionLabel.TabIndex = 1;
            actionLabel.Text = "Actions";
            // 
            // viewButton
            // 
            viewButton.Location = new Point(532, 81);
            viewButton.Name = "viewButton";
            viewButton.Size = new Size(94, 29);
            viewButton.TabIndex = 2;
            viewButton.Text = "View";
            viewButton.UseVisualStyleBackColor = true;
            viewButton.Click += viewButton_Click;
            // 
            // MainPageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(viewButton);
            Controls.Add(actionLabel);
            Controls.Add(indexListView);
            Name = "MainPageForm";
            Text = "MainPageForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView indexListView;
        private ColumnHeader titleHeader;
        private ColumnHeader typeHeader;
        private Label actionLabel;
        private Button viewButton;
    }
}
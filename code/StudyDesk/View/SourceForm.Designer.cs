namespace StudyDesk.View
{
    partial class SourceForm
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
            splitContainer1 = new SplitContainer();
            videoControl1 = new SourceControls.VideoControl();
            documentControl1 = new SourceControls.DocumentControl();
            tableLayoutPanel1 = new TableLayoutPanel();
            addNoteButton = new Button();
            notesListView = new ListView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(videoControl1);
            splitContainer1.Panel1.Controls.Add(documentControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Size = new Size(892, 410);
            splitContainer1.SplitterDistance = 611;
            splitContainer1.TabIndex = 1;
            // 
            // videoControl1
            // 
            videoControl1.Dock = DockStyle.Fill;
            videoControl1.Location = new Point(0, 0);
            videoControl1.Margin = new Padding(3, 2, 3, 2);
            videoControl1.Name = "videoControl1";
            videoControl1.Size = new Size(611, 410);
            videoControl1.TabIndex = 1;
            // 
            // documentControl1
            // 
            documentControl1.Location = new Point(3, 0);
            documentControl1.Margin = new Padding(3, 2, 3, 2);
            documentControl1.Name = "documentControl1";
            documentControl1.Size = new Size(607, 406);
            documentControl1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(addNoteButton, 0, 0);
            tableLayoutPanel1.Controls.Add(notesListView, 0, 1);
            tableLayoutPanel1.Location = new Point(2, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.68316841F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 93.31683F));
            tableLayoutPanel1.Size = new Size(275, 404);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // addNoteButton
            // 
            addNoteButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            addNoteButton.Location = new Point(3, 3);
            addNoteButton.Name = "addNoteButton";
            addNoteButton.Size = new Size(269, 21);
            addNoteButton.TabIndex = 0;
            addNoteButton.Text = "Add Note";
            addNoteButton.UseVisualStyleBackColor = true;
            addNoteButton.Click += addNoteButton_Click;
            // 
            // notesListView
            // 
            notesListView.Location = new Point(3, 30);
            notesListView.Name = "notesListView";
            notesListView.Size = new Size(269, 371);
            notesListView.TabIndex = 1;
            notesListView.UseCompatibleStateImageBehavior = false;
            notesListView.View = System.Windows.Forms.View.List;
            // 
            // SourceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 410);
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SourceForm";
            Text = "SourceForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SourceControls.DocumentControl documentControl1;
        private SourceControls.VideoControl videoControl1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button addNoteButton;
        private ListView notesListView;
    }
}
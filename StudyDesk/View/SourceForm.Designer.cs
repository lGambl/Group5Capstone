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
            noteGridView = new DataGridView();
            noteColumn = new DataGridViewTextBoxColumn();
            documentControl1 = new SourceControls.DocumentControl();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)noteGridView).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(noteGridView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(documentControl1);
            splitContainer1.Size = new Size(1205, 547);
            splitContainer1.SplitterDistance = 372;
            splitContainer1.TabIndex = 1;
            // 
            // noteGridView
            // 
            noteGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            noteGridView.Columns.AddRange(new DataGridViewColumn[] { noteColumn });
            noteGridView.Location = new Point(3, 12);
            noteGridView.Name = "noteGridView";
            noteGridView.RowHeadersVisible = false;
            noteGridView.RowHeadersWidth = 51;
            noteGridView.Size = new Size(366, 245);
            noteGridView.TabIndex = 0;
            noteGridView.CellValueChanged += noteGridView_CellValueChanged;
            // 
            // noteColumn
            // 
            noteColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            noteColumn.HeaderText = "Note";
            noteColumn.MinimumWidth = 6;
            noteColumn.Name = "noteColumn";
            // 
            // documentControl1
            // 
            documentControl1.Location = new Point(3, 3);
            documentControl1.Name = "documentControl1";
            documentControl1.Size = new Size(823, 541);
            documentControl1.TabIndex = 0;
            // 
            // SourceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1205, 547);
            Controls.Add(splitContainer1);
            Name = "SourceForm";
            Text = "SourceForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)noteGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView noteGridView;
        private DataGridViewTextBoxColumn noteColumn;
        private SourceControls.DocumentControl documentControl1;
    }
}
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
            notesFlowLayoutPanel = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(videoControl1);
            splitContainer1.Panel1.Controls.Add(documentControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(notesFlowLayoutPanel);
            splitContainer1.Size = new Size(1019, 547);
            splitContainer1.SplitterDistance = 700;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 1;
            // 
            // videoControl1
            // 
            videoControl1.Dock = DockStyle.Fill;
            videoControl1.Location = new Point(0, 0);
            videoControl1.Name = "videoControl1";
            videoControl1.Size = new Size(700, 547);
            videoControl1.TabIndex = 1;
            // 
            // documentControl1
            // 
            documentControl1.Location = new Point(3, 0);
            documentControl1.Name = "documentControl1";
            documentControl1.Size = new Size(694, 541);
            documentControl1.TabIndex = 0;
            // 
            // notesFlowLayoutPanel
            // 
            notesFlowLayoutPanel.AutoScroll = true;
            notesFlowLayoutPanel.Dock = DockStyle.Fill;
            notesFlowLayoutPanel.Location = new Point(0, 0);
            notesFlowLayoutPanel.Name = "notesFlowLayoutPanel";
            notesFlowLayoutPanel.Size = new Size(314, 547);
            notesFlowLayoutPanel.TabIndex = 0;
            // 
            // SourceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 547);
            Controls.Add(splitContainer1);
            Name = "SourceForm";
            Text = "SourceForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SourceControls.DocumentControl documentControl1;
        private SourceControls.VideoControl videoControl1;
        private FlowLayoutPanel notesFlowLayoutPanel;
    }
}
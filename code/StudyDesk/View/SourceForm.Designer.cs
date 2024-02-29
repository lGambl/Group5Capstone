﻿namespace StudyDesk.View
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
            documentControl1 = new SourceControls.DocumentControl();
            notesFlowLayoutPanel = new FlowLayoutPanel();
            addNoteButton = new Button();
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
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(documentControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(addNoteButton);
            splitContainer1.Panel2.Controls.Add(notesFlowLayoutPanel);
            splitContainer1.Size = new Size(892, 410);
            splitContainer1.SplitterDistance = 613;
            splitContainer1.TabIndex = 1;
            // 
            // documentControl1
            // 
            documentControl1.Location = new Point(3, 0);
            documentControl1.Margin = new Padding(3, 2, 3, 2);
            documentControl1.Name = "documentControl1";
            documentControl1.Size = new Size(607, 406);
            documentControl1.TabIndex = 0;
            // 
            // notesFlowLayoutPanel
            // 
            notesFlowLayoutPanel.AutoScroll = true;
            notesFlowLayoutPanel.Location = new Point(3, 32);
            notesFlowLayoutPanel.Name = "notesFlowLayoutPanel";
            notesFlowLayoutPanel.Size = new Size(269, 374);
            notesFlowLayoutPanel.TabIndex = 0;
            // 
            // addNoteButton
            // 
            addNoteButton.Location = new Point(100, 3);
            addNoteButton.Name = "addNoteButton";
            addNoteButton.Size = new Size(75, 23);
            addNoteButton.TabIndex = 1;
            addNoteButton.Text = "Add Note";
            addNoteButton.UseVisualStyleBackColor = true;
            addNoteButton.Click += addNoteButton_Click;
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
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SourceControls.DocumentControl documentControl1;
        private FlowLayoutPanel notesFlowLayoutPanel;
        private Button addNoteButton;
    }
}
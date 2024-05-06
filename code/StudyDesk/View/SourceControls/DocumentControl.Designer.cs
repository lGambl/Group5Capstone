namespace StudyDesk.View.SourceControls
{
    partial class DocumentControl
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            zoomInButton = new Button();
            zoomOutButton = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(0, 35);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(584, 299);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // zoomInButton
            // 
            zoomInButton.Location = new Point(3, 0);
            zoomInButton.Margin = new Padding(3, 4, 3, 4);
            zoomInButton.Name = "zoomInButton";
            zoomInButton.Size = new Size(86, 31);
            zoomInButton.TabIndex = 2;
            zoomInButton.Text = "Zoom In";
            zoomInButton.UseVisualStyleBackColor = true;
            zoomInButton.Click += zoomInButton_Click;
            // 
            // zoomOutButton
            // 
            zoomOutButton.Location = new Point(498, 0);
            zoomOutButton.Margin = new Padding(3, 4, 3, 4);
            zoomOutButton.Name = "zoomOutButton";
            zoomOutButton.Size = new Size(86, 31);
            zoomOutButton.TabIndex = 3;
            zoomOutButton.Text = "Zoom Out";
            zoomOutButton.UseVisualStyleBackColor = true;
            zoomOutButton.Click += zoomOutButton_Click;
            // 
            // DocumentControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(zoomOutButton);
            Controls.Add(zoomInButton);
            Controls.Add(flowLayoutPanel1);
            Name = "DocumentControl";
            Size = new Size(584, 333);
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private Button zoomInButton;
        private Button zoomOutButton;
    }
}

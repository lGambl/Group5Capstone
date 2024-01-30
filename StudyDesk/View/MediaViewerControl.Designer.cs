namespace StudyDesk.View
{
    partial class MediaViewerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaViewerControl));
            tabControl1 = new TabControl();
            documentTabPage = new TabPage();
            multiMediaTabPage = new TabPage();
            imageTabPage = new TabPage();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            tabControl1.SuspendLayout();
            multiMediaTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(documentTabPage);
            tabControl1.Controls.Add(multiMediaTabPage);
            tabControl1.Controls.Add(imageTabPage);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(464, 394);
            tabControl1.TabIndex = 0;
            // 
            // documentTabPage
            // 
            documentTabPage.Location = new Point(4, 29);
            documentTabPage.Name = "documentTabPage";
            documentTabPage.Padding = new Padding(3);
            documentTabPage.Size = new Size(456, 361);
            documentTabPage.TabIndex = 0;
            documentTabPage.Text = "Documents";
            documentTabPage.UseVisualStyleBackColor = true;
            // 
            // multiMediaTabPage
            // 
            multiMediaTabPage.Controls.Add(axWindowsMediaPlayer1);
            multiMediaTabPage.Location = new Point(4, 29);
            multiMediaTabPage.Name = "multiMediaTabPage";
            multiMediaTabPage.Padding = new Padding(3);
            multiMediaTabPage.Size = new Size(456, 361);
            multiMediaTabPage.TabIndex = 1;
            multiMediaTabPage.Text = "Audio/Video";
            multiMediaTabPage.UseVisualStyleBackColor = true;
            // 
            // imageTabPage
            // 
            imageTabPage.Location = new Point(4, 29);
            imageTabPage.Name = "imageTabPage";
            imageTabPage.Padding = new Padding(3);
            imageTabPage.Size = new Size(456, 361);
            imageTabPage.TabIndex = 2;
            imageTabPage.Text = "Images";
            imageTabPage.UseVisualStyleBackColor = true;
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(6, 6);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(444, 349);
            axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // MediaViewerControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Name = "MediaViewerControl";
            Size = new Size(464, 394);
            tabControl1.ResumeLayout(false);
            multiMediaTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage documentTabPage;
        private TabPage multiMediaTabPage;
        private TabPage imageTabPage;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

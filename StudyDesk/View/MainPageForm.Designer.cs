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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPageForm));
            splitContainer1 = new SplitContainer();
            sourceViewerTabs = new TabControl();
            documentTabPage = new TabPage();
            pdfViewer1 = new Patagames.Pdf.Net.Controls.WinForms.PdfViewer();
            imageTabPage = new TabPage();
            pictureBox = new PictureBox();
            multiMediaTabPage = new TabPage();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            sourceViewerTabs.SuspendLayout();
            documentTabPage.SuspendLayout();
            imageTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            multiMediaTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(sourceViewerTabs);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 372;
            splitContainer1.TabIndex = 0;
            // 
            // sourceViewerTabs
            // 
            sourceViewerTabs.Controls.Add(documentTabPage);
            sourceViewerTabs.Controls.Add(imageTabPage);
            sourceViewerTabs.Controls.Add(multiMediaTabPage);
            sourceViewerTabs.Dock = DockStyle.Fill;
            sourceViewerTabs.Location = new Point(0, 0);
            sourceViewerTabs.Name = "sourceViewerTabs";
            sourceViewerTabs.SelectedIndex = 0;
            sourceViewerTabs.Size = new Size(424, 450);
            sourceViewerTabs.TabIndex = 1;
            // 
            // documentTabPage
            // 
            documentTabPage.Controls.Add(pdfViewer1);
            documentTabPage.Location = new Point(4, 29);
            documentTabPage.Name = "documentTabPage";
            documentTabPage.Padding = new Padding(3);
            documentTabPage.Size = new Size(416, 417);
            documentTabPage.TabIndex = 0;
            documentTabPage.Text = "Documents";
            documentTabPage.UseVisualStyleBackColor = true;
            // 
            // pdfViewer1
            // 
            pdfViewer1.BackColor = SystemColors.ControlDark;
            pdfViewer1.CurrentIndex = -1;
            pdfViewer1.CurrentPageHighlightColor = Color.FromArgb(170, 70, 130, 180);
            pdfViewer1.Document = null;
            pdfViewer1.FormHighlightColor = Color.Transparent;
            pdfViewer1.FormsBlendMode = Patagames.Pdf.Enums.BlendTypes.FXDIB_BLEND_MULTIPLY;
            pdfViewer1.LoadingIconText = "Loading...";
            pdfViewer1.Location = new Point(7, 8);
            pdfViewer1.Margin = new Padding(4, 5, 4, 5);
            pdfViewer1.MouseMode = Patagames.Pdf.Net.Controls.WinForms.MouseModes.Default;
            pdfViewer1.Name = "pdfViewer1";
            pdfViewer1.OptimizedLoadThreshold = 1000;
            pdfViewer1.Padding = new Padding(13, 15, 13, 15);
            pdfViewer1.PageAlign = ContentAlignment.MiddleCenter;
            pdfViewer1.PageAutoDispose = true;
            pdfViewer1.PageBackColor = Color.White;
            pdfViewer1.PageBorderColor = Color.Black;
            pdfViewer1.PageMargin = new Padding(10);
            pdfViewer1.PageSeparatorColor = Color.Gray;
            pdfViewer1.RenderFlags = Patagames.Pdf.Enums.RenderFlags.FPDF_LCD_TEXT | Patagames.Pdf.Enums.RenderFlags.FPDF_NO_CATCH;
            pdfViewer1.ShowCurrentPageHighlight = true;
            pdfViewer1.ShowLoadingIcon = true;
            pdfViewer1.ShowPageSeparator = true;
            pdfViewer1.Size = new Size(405, 404);
            pdfViewer1.SizeMode = Patagames.Pdf.Net.Controls.WinForms.SizeModes.FitToWidth;
            pdfViewer1.TabIndex = 0;
            pdfViewer1.TextSelectColor = Color.FromArgb(70, 70, 130, 180);
            pdfViewer1.TilesCount = 2;
            pdfViewer1.UseProgressiveRender = true;
            pdfViewer1.ViewMode = Patagames.Pdf.Net.Controls.WinForms.ViewModes.Vertical;
            pdfViewer1.Zoom = 1F;
            // 
            // imageTabPage
            // 
            imageTabPage.Controls.Add(pictureBox);
            imageTabPage.Location = new Point(4, 29);
            imageTabPage.Name = "imageTabPage";
            imageTabPage.Padding = new Padding(3);
            imageTabPage.Size = new Size(416, 417);
            imageTabPage.TabIndex = 2;
            imageTabPage.Text = "Images";
            imageTabPage.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(6, 6);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(404, 403);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // multiMediaTabPage
            // 
            multiMediaTabPage.Controls.Add(axWindowsMediaPlayer1);
            multiMediaTabPage.Location = new Point(4, 29);
            multiMediaTabPage.Name = "multiMediaTabPage";
            multiMediaTabPage.Padding = new Padding(3);
            multiMediaTabPage.Size = new Size(416, 417);
            multiMediaTabPage.TabIndex = 1;
            multiMediaTabPage.Text = "Audio/Video";
            multiMediaTabPage.UseVisualStyleBackColor = true;
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(6, 6);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(402, 403);
            axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // MainPageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "MainPageForm";
            Text = "MainPageForm";
            Load += MainPageForm_Load;
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            sourceViewerTabs.ResumeLayout(false);
            documentTabPage.ResumeLayout(false);
            imageTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            multiMediaTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private MediaViewerControl mediaViewerControl1;
        private TabControl sourceViewerTabs;
        private TabPage documentTabPage;
        private Patagames.Pdf.Net.Controls.WinForms.PdfViewer pdfViewer1;
        private TabPage imageTabPage;
        private PictureBox pictureBox;
        private TabPage multiMediaTabPage;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}
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
            sourceViewerTabs = new TabControl();
            documentTabPage = new TabPage();
            pdfViewer1 = new Patagames.Pdf.Net.Controls.WinForms.PdfViewer();
            imageTabPage = new TabPage();
            pictureBox = new PictureBox();
            multiMediaTabPage = new TabPage();
            vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            playButton = new Button();
            pauseButton = new Button();
            sourceViewerTabs.SuspendLayout();
            documentTabPage.SuspendLayout();
            imageTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            multiMediaTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)vlcControl1).BeginInit();
            SuspendLayout();
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
            sourceViewerTabs.Size = new Size(464, 394);
            sourceViewerTabs.TabIndex = 0;
            // 
            // documentTabPage
            // 
            documentTabPage.Controls.Add(pdfViewer1);
            documentTabPage.Location = new Point(4, 29);
            documentTabPage.Name = "documentTabPage";
            documentTabPage.Padding = new Padding(3);
            documentTabPage.Size = new Size(456, 361);
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
            pdfViewer1.Location = new Point(0, 0);
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
            pdfViewer1.Size = new Size(456, 360);
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
            imageTabPage.Size = new Size(456, 361);
            imageTabPage.TabIndex = 2;
            imageTabPage.Text = "Images";
            imageTabPage.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(6, 6);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(447, 349);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // multiMediaTabPage
            // 
            multiMediaTabPage.Controls.Add(pauseButton);
            multiMediaTabPage.Controls.Add(playButton);
            multiMediaTabPage.Controls.Add(vlcControl1);
            multiMediaTabPage.Location = new Point(4, 29);
            multiMediaTabPage.Name = "multiMediaTabPage";
            multiMediaTabPage.Padding = new Padding(3);
            multiMediaTabPage.Size = new Size(456, 361);
            multiMediaTabPage.TabIndex = 1;
            multiMediaTabPage.Text = "Audio/Video";
            multiMediaTabPage.UseVisualStyleBackColor = true;
            // 
            // vlcControl1
            // 
            vlcControl1.BackColor = Color.Black;
            vlcControl1.Location = new Point(6, 6);
            vlcControl1.Name = "vlcControl1";
            vlcControl1.Size = new Size(444, 309);
            vlcControl1.Spu = -1;
            vlcControl1.TabIndex = 0;
            vlcControl1.Text = "vlcControl1";
            vlcControl1.VlcLibDirectory = null;
            vlcControl1.VlcMediaplayerOptions = null;
            // 
            // playButton
            // 
            playButton.Location = new Point(6, 321);
            playButton.Name = "playButton";
            playButton.Size = new Size(94, 29);
            playButton.TabIndex = 1;
            playButton.Text = "Play";
            playButton.UseVisualStyleBackColor = true;
            // 
            // pauseButton
            // 
            pauseButton.Location = new Point(356, 321);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(94, 29);
            pauseButton.TabIndex = 2;
            pauseButton.Text = "Pause";
            pauseButton.UseVisualStyleBackColor = true;
            // 
            // MediaViewerControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(sourceViewerTabs);
            Name = "MediaViewerControl";
            Size = new Size(464, 394);
            sourceViewerTabs.ResumeLayout(false);
            documentTabPage.ResumeLayout(false);
            imageTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            multiMediaTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)vlcControl1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl sourceViewerTabs;
        private TabPage documentTabPage;
        private TabPage multiMediaTabPage;
        private TabPage imageTabPage;
        private PictureBox pictureBox;
        private Patagames.Pdf.Net.Controls.WinForms.PdfViewer pdfViewer1;
        private Button pauseButton;
        private Button playButton;
        private Vlc.DotNet.Forms.VlcControl vlcControl1;
    }
}

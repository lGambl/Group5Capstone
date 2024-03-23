namespace StudyDesk.View.SourceControls
{
    partial class VideoControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoControl));
            videoPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)videoPlayer).BeginInit();
            SuspendLayout();
            // 
            // videoPlayer
            // 
            videoPlayer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            videoPlayer.Enabled = true;
            videoPlayer.Location = new Point(0, 0);
            videoPlayer.Name = "videoPlayer";
            videoPlayer.OcxState = (AxHost.State)resources.GetObject("videoPlayer.OcxState");
            videoPlayer.Size = new Size(545, 395);
            videoPlayer.TabIndex = 0;
            // 
            // VideoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(videoPlayer);
            Name = "VideoControl";
            Size = new Size(545, 395);
            ((System.ComponentModel.ISupportInitialize)videoPlayer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer videoPlayer;
    }
}

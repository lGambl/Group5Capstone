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
            videoView1 = new LibVLCSharp.WinForms.VideoView();
            playButton = new Button();
            pauseButton = new Button();
            fwrd10SecButton = new Button();
            back10SecondsButton = new Button();
            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            SuspendLayout();
            // 
            // videoView1
            // 
            videoView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            videoView1.BackColor = Color.Black;
            videoView1.Location = new Point(0, 0);
            videoView1.MediaPlayer = null;
            videoView1.Name = "videoView1";
            videoView1.Size = new Size(542, 309);
            videoView1.TabIndex = 0;
            videoView1.Text = "videoView1";
            // 
            // playButton
            // 
            playButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            playButton.Location = new Point(3, 337);
            playButton.Name = "playButton";
            playButton.Size = new Size(94, 29);
            playButton.TabIndex = 1;
            playButton.Text = "Play";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pauseButton.Location = new Point(448, 337);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(94, 29);
            pauseButton.TabIndex = 2;
            pauseButton.Text = "Pause";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // fwrd10SecButton
            // 
            fwrd10SecButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fwrd10SecButton.Location = new Point(296, 337);
            fwrd10SecButton.Name = "fwrd10SecButton";
            fwrd10SecButton.Size = new Size(96, 29);
            fwrd10SecButton.TabIndex = 3;
            fwrd10SecButton.Text = "Fwrd 10 Sec";
            fwrd10SecButton.UseVisualStyleBackColor = true;
            // 
            // back10SecondsButton
            // 
            back10SecondsButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            back10SecondsButton.Location = new Point(136, 337);
            back10SecondsButton.Name = "back10SecondsButton";
            back10SecondsButton.Size = new Size(107, 29);
            back10SecondsButton.TabIndex = 4;
            back10SecondsButton.Text = "Back 10 Sec";
            back10SecondsButton.UseVisualStyleBackColor = true;
            back10SecondsButton.Click += back10SecondsButton_Click;
            // 
            // VideoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(back10SecondsButton);
            Controls.Add(fwrd10SecButton);
            Controls.Add(pauseButton);
            Controls.Add(playButton);
            Controls.Add(videoView1);
            Name = "VideoControl";
            Size = new Size(545, 395);
            ((System.ComponentModel.ISupportInitialize)videoView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private LibVLCSharp.WinForms.VideoView videoView1;
        private Button playButton;
        private Button pauseButton;
        private Button fwrd10SecButton;
        private Button back10SecondsButton;
    }
}

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
            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            SuspendLayout();
            // 
            // videoView1
            // 
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
            playButton.Location = new Point(3, 337);
            playButton.Name = "playButton";
            playButton.Size = new Size(94, 29);
            playButton.TabIndex = 1;
            playButton.Text = "Play";
            playButton.UseVisualStyleBackColor = true;
            // 
            // pauseButton
            // 
            pauseButton.Location = new Point(448, 337);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(94, 29);
            pauseButton.TabIndex = 2;
            pauseButton.Text = "Pause";
            pauseButton.UseVisualStyleBackColor = true;
            // 
            // VideoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
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
    }
}

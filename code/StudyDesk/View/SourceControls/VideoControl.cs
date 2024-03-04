using LibVLCSharp.Shared;
using Microsoft.Identity.Client;

namespace StudyDesk.View.SourceControls
{
    /// <summary>
    /// A user control for displaying a video.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class VideoControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoControl"/> class.
        /// </summary>
        public VideoControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Sets the video link. 
        /// </summary>
        /// <param name="link">The link.</param>
        public void SetVideo(string link)
        {
            Core.Initialize();
            this.videoView1.MediaPlayer = new MediaPlayer(new Media(new LibVLC(), link, FromType.FromLocation));
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            this.videoView1.MediaPlayer!.Play();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            this.videoView1.MediaPlayer!.Pause();
        }


        private void fwrd10SecButton_Click(object sender, EventArgs e)
        {
            this.videoView1.MediaPlayer!.Time += 10000;
        }

        private void back10SecondsButton_Click(object sender, EventArgs e)
        {
            this.videoView1.MediaPlayer!.Time -= 10000;
        }
    }
}

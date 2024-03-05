﻿using LibVLCSharp.Shared;
using Microsoft.Identity.Client;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

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
            Core.Initialize();
        }

        /// <summary>
        /// Sets the video link. 
        /// </summary>
        /// <param name="link">The link.</param>
        public async Task SetVideo(string link)
        {
            var stream = await this.getVideoStream(link);

            var mediaInput = new StreamMediaInput(stream);
            var media = new Media(new LibVLC(), mediaInput);

            this.videoView1.MediaPlayer = new MediaPlayer(media);
        }

        private async Task<Stream> getVideoStream(string link)
        {
            var youtubeClient = new YoutubeClient();
            var video = await youtubeClient.Videos.Streams.GetManifestAsync(link);
            var streamInfo = video.GetMuxedStreams().GetWithHighestVideoQuality();
            return await youtubeClient.Videos.Streams.GetAsync(streamInfo);
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            this.videoView1.MediaPlayer!.Play();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (this.videoView1.MediaPlayer!.IsPlaying)
            {
                this.videoView1.MediaPlayer!.Pause(); 
            }
            else
            {
                this.videoView1.MediaPlayer!.Play();
            }
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

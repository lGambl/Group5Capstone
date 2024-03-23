using YoutubeExplode;

namespace StudyDesk.View.SourceControls;

/// <summary>
///     A user control for displaying a video.
/// </summary>
/// <seealso cref="System.Windows.Forms.UserControl" />
public partial class VideoControl : UserControl
{
    #region Properties

    /// <summary>
    ///     Tracks where the video player is ready to play.
    /// </summary>
    public bool PlayerReady { get; private set; }

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="VideoControl" /> class.
    /// </summary>
    public VideoControl()
    {
        this.InitializeComponent();
        this.PlayerReady = false;
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Sets the video link.
    /// </summary>
    /// <param name="link">The link.</param>
    public async Task SetVideo(string link)
    {
        var filePath = await this.getVideoStream(link);
        this.videoPlayer.URL = filePath;
        this.PlayerReady = true;
    }

    private async Task<string> getVideoStream(string link)
    {
        var youtubeClient = new YoutubeClient();
        var video = await youtubeClient.Videos.Streams.GetManifestAsync(link);
        var streams = video.GetMuxedStreams();
        var streamInfo = streams.OrderByDescending(stream => stream.VideoQuality).First();
        var filePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.mp4");
        await youtubeClient.Videos.Streams.DownloadAsync(streamInfo, filePath);
        return filePath;
    }

    #endregion
}
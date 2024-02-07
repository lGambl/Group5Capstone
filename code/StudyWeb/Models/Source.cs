using System.Collections.ObjectModel;

namespace StudyWeb.Models;

/// <summary>
///     Source types of sources
/// </summary>
public enum SourceTypes
{
    /// <summary>
    ///     A video
    /// </summary>
    Video = 1,

    /// <summary>
    ///     A link to a video
    /// </summary>
    VideoLink = 2,

    /// <summary>
    ///     A pdf
    /// </summary>
    Pdf = 3,

    /// <summary>
    ///     A link to a pdf
    /// </summary>
    PdfLink = 4,

    /// <summary>
    ///     An image
    /// </summary>
    Image = 5,

    /// <summary>
    ///     A link to an image
    /// </summary>
    ImageLink = 6
}

/// <summary>
///     A source of information
/// </summary>
public class Source
{
    #region Properties

    /// <summary>
    ///     Id of Source
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Link to the source
    /// </summary>
    public string Link { get; set; } = "";

    /// <summary>
    ///     Title of the source
    /// </summary>
    public string Title { get; init; } = "";

    /// <summary>
    ///     Type of source
    /// </summary>
    public SourceTypes Type { get; init; }

    /// <summary>
    ///     Type of source as a string
    /// </summary>
    public string TypeString => this.SourceTypeToString();

    /// <summary>
    ///     Owner of the source
    /// </summary>
    public string Owner { get; init; } = "";

    /// <summary>
    ///     Notes on the source
    /// </summary>
    public ICollection<Note> Notes { get; set; } = new Collection<Note>();

    #endregion

    #region Methods

    /// <summary>
    ///     Convert source type to string
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public string SourceTypeToString()
    {
        return this.Type switch
        {
            SourceTypes.Video => "video",
            SourceTypes.VideoLink => "videoLink",
            SourceTypes.Pdf => "pdf",
            SourceTypes.PdfLink => "pdfLink",
            SourceTypes.Image => "image",
            SourceTypes.ImageLink => "imageLink",
            _ => throw new ArgumentException("No video type")
        };
    }

    #endregion
}
using System.Collections;
using System.Collections.ObjectModel;

namespace StudyWeb.Models
{
    /// <summary>
    /// Source types of sources
    /// </summary>
    public enum SourceTypes{

        /// <summary>
        /// A video
        /// </summary>
        Video = 1,

        /// <summary>
        /// A link to a video
        /// </summary>
        VideoLink = 2,

        /// <summary>
        /// A pdf
        /// </summary>
        Pdf = 3,

        /// <summary>
        /// A link to a pdf
        /// </summary>
        PdfLink = 4,

        /// <summary>
        /// An image
        /// </summary>
        Image = 5,

        /// <summary>
        /// A link to an image
        /// </summary>
        ImageLink = 6
    }

    /// <summary>
    /// A source of information
    /// </summary>
    public class Source : IEnumerable
    {
        /// <summary>
        /// Id of Source
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Link to the source
        /// </summary>
        public string Link { get; set; } = "";

        /// <summary>
        /// Title of the source
        /// </summary>
        public string Title { get; set; } = "";

        /// <summary>
        /// Type of source
        /// </summary>
        public SourceTypes Type { get; set; }

        /// <summary>
        /// Type of source as a string
        /// </summary>
        public string TypeString => SourceTypeToString();

        /// <summary>
        /// Owner of the source
        /// </summary>
        public string Owner { get; set; } = "";

        /// <summary>
        /// Notes on the source
        /// </summary>
        public ICollection<Note> Notes { get; set; } = new Collection<Note>();

        /// <summary>
        /// Convert source type to string
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string SourceTypeToString()
        {
            switch (this.Type)
            {
                case SourceTypes.Video:
                    return "video";
                case SourceTypes.VideoLink:
                    return "videoLink";
                case SourceTypes.Pdf:
                    return "pdf";
                case SourceTypes.PdfLink:
                    return "pdfLink";
                case SourceTypes.Image:
                    return "image";
                case SourceTypes.ImageLink:
                    return "imageLink";
                default:
                    throw new ArgumentException("No video type");
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

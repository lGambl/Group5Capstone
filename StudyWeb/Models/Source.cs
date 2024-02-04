using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

namespace StudyWeb.Models
{
    public enum SourceTypes{
        Video = 1,
        VideoLink = 2,
        Pdf = 3,
        PdfLink = 4
    }


    public class Source
    {
        public int Id { get; set; }

        public string Link { get; set; } = "";

        public string Title { get; set; } = "";

        public SourceTypes Type { get; set; }

        public string TypeString => SourceTypeToString();

        public string Owner { get; set; } = "";

        public ICollection<Note> Notes { get; set; } = new Collection<Note>();

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
                default:
                    throw new ArgumentException("No video type");
            }
        }
    }
}

namespace StudyDesk.Model
{
    /// <summary>
    ///   The Source class in the desktop app.
    /// </summary>
    public class Source
    {
        /// <summary>
        ///   Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; init; }

        /// <summary>
        ///   Gets or sets the link.
        /// </summary>
        /// <value>The link.</value>
        public string Link { get; init; }

        /// <summary>
        ///   Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; init; }

        /// <summary>
        ///   Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public SourceType Type { get; init; }

        /// <summary>
        ///   Gets or sets the type string.
        /// </summary>
        /// <value>The type string.</value>
        public string TypeString => this.sourceTypeToString();

        /// <summary>
        ///   Gets or sets the owner.
        /// </summary>
        /// <value>The owner.</value>
        public string Owner { get; init; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="Source" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="link">The link.</param>
        /// <param name="title">The title.</param>
        /// <param name="type">The type.</param>
        /// <param name="owner">The owner.</param>
        public Source(int id, string link, string title, SourceType type, string owner)
        {
            this.Id = id;
            this.Link = link;
            this.Title = title;
            this.Type = type;
            this.Owner = owner;
        }

        private string sourceTypeToString()
        {
            return this.Type switch
            {
                SourceType.Video => "video",
                SourceType.VideoLink => "videoLink",
                SourceType.Pdf => "pdf",
                SourceType.PdfLink => "pdfLink",
                SourceType.Image => "image",
                _ => throw new ArgumentException("No source type")
            };
        }

    }
}

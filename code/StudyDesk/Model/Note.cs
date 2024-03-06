namespace StudyDesk.Model
{
    /// <summary>
    ///   The note class in the Desktop App.
    /// </summary>
    public class Note
    {
        /// <summary>
        ///   Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///   Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        ///   Gets or sets the source identifier.
        /// </summary>
        /// <value>The source identifier.</value>
        public int SourceId { get; set; }

        /// <summary>
        ///   Gets or sets the owner.
        /// </summary>
        /// <value>The owner.</value>
        public string Owner { get; set; }

        /// <summary>
        ///   Gets or sets the note tags.
        /// </summary>
        /// <value>The note tags.</value>
        public List<string> NoteTags { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="Note" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="text">The text.</param>
        /// <param name="sourceId">The source identifier.</param>
        /// <param name="owner">The owner.</param>
        public Note(int id, string text, int sourceId, string owner)
        {
            this.Id = id;
            this.Text = text;
            this.SourceId = sourceId;
            this.Owner = owner;
            this.NoteTags = new List<string>();
        }

    }
}

namespace StudyDesk.Model
{
    /// <summary>
    ///   The Note Tag class.
    /// </summary>
    public class NoteTag
    {
        /// <summary>
        ///   Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///   Gets or sets the note identifier.
        /// </summary>
        /// <value>The note identifier.</value>
        public int NoteId { get; set; }

        /// <summary>
        ///   Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string? Name { get; set; }

    }
}

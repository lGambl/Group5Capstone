namespace StudyWeb.Models
{
    /// <summary>
    /// A note
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Id of note
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Text of note
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// The source the note goes with
        /// </summary>
        public int SourceId { get; set; }

        /// <summary>
        /// The owner of the note
        /// </summary>
        public string Owner { get; set; } = "";
    }
}

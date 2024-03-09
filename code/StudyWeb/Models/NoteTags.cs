namespace StudyWeb.Models;

/// <summary>
///     Model for a note tag
/// </summary>
public class NoteTags
{
    #region Properties

    /// <summary>
    ///     Gets or sets the note identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Gets or sets the tag identifier.
    /// </summary>
    public int TagId { get; set; }

    /// <summary>
    ///     Gets or sets the note tag identifier.
    /// </summary>
    public int NoteId { get; set; }

    #endregion
}
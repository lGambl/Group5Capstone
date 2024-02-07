namespace StudyWeb.Models;

/// <summary>
///     A note
/// </summary>
public class Note
{
    #region Properties

    /// <summary>
    ///     Id of note
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Text of note
    /// </summary>
    public string Text { get; init; } = "";

    /// <summary>
    ///     The source the note goes with
    /// </summary>
    public int SourceId { get; init; }

    /// <summary>
    ///     The owner of the note
    /// </summary>
    public string Owner { get; init; } = "";

    #endregion
}
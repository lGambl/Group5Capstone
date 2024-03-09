namespace StudyWeb.Models;

/// <summary>
///     Model for a tag
/// </summary>
public class Tags
{
    #region Properties

    /// <summary>
    ///     Gets the id of the tag.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Gets or sets the name of the tag.
    /// </summary>
    public string Name { get; set; } = "";

    #endregion
}
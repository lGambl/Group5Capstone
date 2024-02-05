using StudyDesk.Model;

namespace StudyDesk.Controller;

/// <summary>
///     Controller for the main page.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="MainPageController" /> class.
/// </remarks>
/// <param name="id">The identifier.</param>
/// <precondition>id != null</precondition>
public class MainPageController()
{
    #region Properties

    /// <summary>
    ///     Gets or sets the sources of the logged-in user.
    /// </summary>
    /// <value>
    ///     The sources as a collection of Source objects.
    /// </value>
    public IList<Source> Sources { get; private set; } = new List<Source>();

    #endregion

    #region Methods

    private IList<Source> getSources()
    {
        var sources = new List<Source>();
        return sources;
    }

    /// <summary>
    ///     Adds as source under the logged-in user.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="type">The type.</param>
    /// <param name="link">The link.</param>
    /// <precondition>
    ///     name != null AND !name.isEmptyOrBlank
    ///     sourceType.isOfTypeEnum<see cref="SourceType" />() AND
    ///     link != null AND !link.isEmptyOrBlank
    /// </precondition>
    /// <returns>True if addition is successful, false otherwise.</returns>
    public bool AddSource(string name, SourceType type, string link)
    {
        return true;
    }

    #endregion
}
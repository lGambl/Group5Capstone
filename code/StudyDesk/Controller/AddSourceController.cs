using StudyDesk.Model;

namespace StudyDesk.Controller;

/// <summary>
///     A controller for the Add Source form.
/// </summary>
public class AddSourceController
{
    #region Data members

    private readonly AuthService authService;

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="AddSourceController" /> class.
    /// </summary>
    /// <param name="authService">The authentication service.</param>
    public AddSourceController(AuthService authService)
    {
        this.authService = authService;
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Adds the source.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="filePath">The file path or link in the case of links.</param>
    /// <param name="type">The type.</param>
    /// <returns>True if successful, false otherwise.</returns>
    public bool AddSource(string title, string filePath, SourceType type)
    {
        try
        {
            this.authService.AddSource(title, filePath, type);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    #endregion
}
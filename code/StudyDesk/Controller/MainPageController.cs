using System.Text.RegularExpressions;
using StudyDesk.Model;

namespace StudyDesk.Controller;

/// <summary>
///     Controller for the main page.
/// </summary>
public class MainPageController
{
    #region Data members

    private const string ConnectionString =
        "Server=(localdb)\\mssqllocaldb;Database=aspnet-BestPhonebookApp-0fc62a5a-c4b5-4292-9de7-2d743b650400;Trusted_Connection=True;MultipleActiveResultSets=true";

    private readonly IList<Source> userSources;

    #endregion

    #region Properties

    /// <summary>
    ///     Gets or sets the sources of the logged-in user.
    /// </summary>
    /// <value>
    ///     The sources as a collection of Source objects.
    /// </value>
    public IList<Source> Sources { get; set; }

    /// <summary>
    ///     Gets the authentication service.
    /// </summary>
    /// <value>
    ///     The authentication service.
    /// </value>
    public AuthService AuthService { get; }

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="MainPageController" /> class.
    /// </summary>
    public MainPageController(AuthService auth)
    {
        this.AuthService = auth;
        this.Sources = this.AuthService.GetSources().Result.ToList();
        this.userSources = this.Sources;
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Logouts this instance.
    /// </summary>
    /// <returns>True if successful, false otherwise.</returns>
    public bool Logout()
    {
        return this.AuthService.Logout();
    }


    /// <summary>
    ///     Deletes the source.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <returns>
    ///     True if the source was deleted, False if not deleted.
    /// </returns>
    public async Task<bool> DeleteSource(string title)
    {
        const string pattern = @"\{(.*?)\}";
        var match = Regex.Match(title, pattern);
        var result = match.Groups[1].Value;

        var sourceId = -1;
        foreach (var currSource in this.Sources)
        {
            if (currSource.Title == result)
            {
                sourceId = currSource.Id;
                break;
            }
        }

        var response = this.AuthService.DeleteSource(sourceId);

        if (response)
        {
            this.deleteSourceFromSources(result);
            return true;
        }

        return false;
    }

    /// <summary>
    ///   Gets the sources with matching note tags.
    /// </summary>
    /// <param name="tag">The tag.</param>
    /// <returns>
    ///   A list of the sources that have notes with matching tags.
    /// </returns>
    public List<Source> getSourcesWithMatchingNoteTags(string tag)
    {
        List<Source> sources = new List<Source>();
        foreach (var currSource in this.AuthService.GetSourcesWithMatchingTag(tag).Result)
        {
            var newLink = "https://localhost:7240/" + currSource.Link;
            currSource.Link = newLink;
            sources.Add(currSource);
        }

        if (sources.Count == 0)
        {
            sources = null;
        }
        else
        {
            this.Sources = sources;
        }

        return sources;
    }

    /// <summary>
    ///   Resets the user's sources.
    /// </summary>
    public void ResetUserSources()
    {
        this.Sources = this.userSources;
    }

    private void deleteSourceFromSources(string result)
    {
        Source? sourceToRemove = null;
        foreach (var currSource in this.Sources)
        {
            if (currSource.Title == result)
            {
                sourceToRemove = currSource;
                break;
            }
        }

        this.Sources.Remove(sourceToRemove!);
    }

    #endregion

    // /// <summary>
    // ///     Initializes a new instance of the <see cref="MainPageController" /> class.
    // ///     Here for testing purposes.
    // /// </summary>
    // /// <param name="auth">The authentication.</param>
    // /// <param name="client">The client.</param>
    // public MainPageController(AuthService auth, HttpClient client)
    // {
    //     this.AuthService = auth;
    //     this.Sources = this.AuthService.GetSources().Result.ToList();
    //     this.Client = client;
    // }
}
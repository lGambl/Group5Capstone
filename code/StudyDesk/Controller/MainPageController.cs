using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using StudyDesk.Model;


namespace StudyDesk.Controller;

/// <summary>
///     Controller for the main page.
/// </summary>
public class MainPageController
{
    #region Data Members

    private const string ConnectionString =
        "Server=(localdb)\\mssqllocaldb;Database=aspnet-BestPhonebookApp-0fc62a5a-c4b5-4292-9de7-2d743b650400;Trusted_Connection=True;MultipleActiveResultSets=true";

    private const string? ErrorCaption = "Error";
    private const string? FailedToDeleteNotesFromDatabase = "Failed to delete notes from database";
    private const string? FailedToDeleteSourceFromDatabase = "Failed to delete source from database";

    #endregion

    #region Properties

    /// <summary>
    ///     Gets or sets the sources of the logged-in user.
    /// </summary>
    /// <value>
    ///     The sources as a collection of Source objects.
    /// </value>
    public IList<Source> Sources { get; private set; }

    private AuthService AuthService { get; }

    private HttpClient Client { get; }

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="MainPageController" /> class.
    /// </summary>
    public MainPageController(AuthService auth)
    {
        this.AuthService = auth;
        this.Sources = this.AuthService.GetSources().Result.ToList();
        this.Client = this.AuthService.HttpClient;
    }

    public MainPageController(AuthService auth, HttpClient client)
    {
        this.AuthService = auth;
        this.Sources = this.AuthService.GetSources().Result.ToList();
        this.Client = client;
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
    ///   Deletes the source.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <returns>
    ///   True if the source was deleted, False if not deleted.
    /// </returns>
    public async Task<bool> DeleteSource(string title)
    {
        var pattern = @"\{(.*?)\}";
        Match match = Regex.Match(title, pattern);
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

        var response = await this.Client.DeleteAsync($"https://localhost:7240/SourceExplorer/Delete/{sourceId}").ConfigureAwait(false);
        return response.IsSuccessStatusCode;

        // this.deleteSourceNotes(this.getSourceNotes(sourceId));
        // try
        // {
        //     var connection = new SqlConnection(ConnectionString);
        //     connection.Open();
        //     var command = new SqlCommand("DELETE FROM source WHERE Id = @Id", connection);
        //     command.Parameters.AddWithValue("@Id", sourceId);
        //     command.ExecuteNonQuery();
        //     connection.Close();
        //     return true;
        // }
        // catch (Exception ex)
        // {
        //     MessageBox.Show(FailedToDeleteSourceFromDatabase, ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //     return false;
        // }

    }

    private bool deleteSourceNotes(List<int> noteIds)
    {
        try
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            foreach (var currId in noteIds)
            {

                var command = new SqlCommand("DELETE FROM dbo.Note WHERE Id = @id", connection);
                command.Parameters.AddWithValue("@id", currId);
                command.ExecuteNonQuery();

            }
            connection.Close();
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(FailedToDeleteNotesFromDatabase, ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    private List<int> getSourceNotes(int sourceId)
    {
        var notes = new List<int>();
        var connection = new SqlConnection(ConnectionString);
        connection.Open();
        var command = new SqlCommand("SELECT * FROM dbo.Note where SourceId = @sourceId", connection);
        command.Parameters.AddWithValue("@sourceId", sourceId);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            notes.Add(reader.GetInt32(0));
        }
        connection.Close();
        return notes;
    }

    #endregion

    // /// <summary>
    // ///     Adds as source under the logged-in user.
    // /// </summary>
    // /// <param name="name">The name.</param>
    // /// <param name="type">The type.</param>
    // /// <param name="link">The link.</param>
    // /// <precondition>
    // ///     name != null AND !name.isEmptyOrBlank
    // ///     sourceType.isOfTypeEnum<see cref="SourceType" />() AND
    // ///     link != null AND !link.isEmptyOrBlank
    // /// </precondition>
    // /// <returns>True if addition is successful, false otherwise.</returns>
    // public bool AddSource(string name, SourceType type, string link)
    // {
    //     return true;
    // }
}
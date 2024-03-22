using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace StudyDesk.Model;

/// <summary>
///     The Authorization Service class.
/// </summary>
public class AuthService
{
    #region Properties

    /// <summary>
    ///   Gets the HTTP client.
    /// </summary>
    /// <value>The HTTP client.</value>
    public HttpClient HttpClient { get; }

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="AuthService" /> class.
    /// </summary>
    public AuthService()
    {
        var handler = new HttpClientHandler
        {
            CookieContainer = new CookieContainer(),
            UseCookies = true,
            UseDefaultCredentials = false
        };
        this.HttpClient = new HttpClient(handler);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AuthService" /> class.
    ///     Designed for testing purposes.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public AuthService(HttpClient httpClient)
    {
        this.HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Logs in the user, and returns the AuthService object if successful.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    /// <returns>
    ///     An AuthService object if successful, null if unsuccessful.
    /// </returns>
    /// <exception cref="Exception">Login failed with status code: response.StatusCode</exception>
    public virtual async Task<AuthService?> LoginAsync(string username, string password)
    {
        var loginDto = new LoginDto { Username = username, Password = password };
        var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");

        var response = await this.HttpClient.PostAsync("https://localhost:7240/auth/login", content)
            .ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            return this;
        }

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            return null;
        }

        throw new Exception("Login failed with status code: " + response.StatusCode);
    }

    /// <summary>
    ///     Gets the sources.
    /// </summary>
    /// <returns>A list of sources from the DB.</returns>
    /// <exception cref="System.Exception">
    ///     Request failed with status code: " + response.StatusCode
    ///     or
    ///     An error occurred while fetching sources: " + ex.Message
    /// </exception>
    public virtual async Task<IEnumerable<Source>> GetSources()
    {
        try
        {
            this.HttpClient.DefaultRequestHeaders.Accept.Clear();
            this.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await this.HttpClient.GetAsync("https://localhost:7240/SourceExplorer")
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var sources = JsonConvert.DeserializeObject<IEnumerable<Source>>(contentString);
                return sources ?? new List<Source>();
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return new List<Source>();
            }

            throw new Exception("Request failed with status code: " + response.StatusCode);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while fetching sources: " + ex.Message);
        }
    }

    /// <summary>
    ///   Gets the sources with matching tags.
    /// </summary>
    /// <param name="tags">The tags.</param>
    /// <returns>
    ///   Success, with a list of sources if true,
    ///   Bad request if false.
    /// </returns>
    /// <exception cref="System.Exception">Request failed with status code: " + response.StatusCode
    /// or
    /// An error occurred while searching sources: " + ex.Message</exception>
    public virtual async Task<IEnumerable<Source>> GetSourcesWithMatchingTags(IEnumerable<string> tags)
    {
        try
        {
            this.HttpClient.DefaultRequestHeaders.Accept.Clear();
            this.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Serialize the list of tags into a JSON string
            var jsonContent = JsonConvert.SerializeObject(tags);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Use PostAsync and adjust the URL to match the SearchTags endpoint
            var response = await this.HttpClient.PostAsync("https://localhost:7240/SourceExplorer/SearchTags", httpContent)
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var sources = JsonConvert.DeserializeObject<IEnumerable<Source>>(contentString);
                return sources ?? new List<Source>();
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return new List<Source>();
            }

            return new List<Source>();
            //throw new Exception("Request failed with status code: " + response.StatusCode);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while searching sources: " + ex.Message);
        }
    }

    /// <summary>
    ///     Attempts to log out the user.
    /// </summary>
    /// <returns>True if successful, false otherwise.</returns>
    public virtual bool Logout()
    {
        var response = this.HttpClient.GetAsync("https://localhost:7240/Identity/Account/Logout?returnUrl=%2F").Result;
        return response.IsSuccessStatusCode;
    }

    /// <summary>
    ///     Adds the source.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="filePath">The file path or Link in the case of links.</param>
    /// <param name="type">The file type.</param>
    /// <exception cref="System.Exception">Failed to add source. Status code: " + response.StatusCode</exception>
    public virtual Task<bool> AddSource(string title, string filePath, SourceType type)
    {
        return type switch
        {
            SourceType.Pdf => this.addPdfSource(title, filePath),
            SourceType.VideoLink => this.addVideoLinkSource(title, filePath),
            _ => throw new NotImplementedException()
        };
    }

    /// <summary>
    ///   Deletes the source.
    /// </summary>
    /// <param name="sourceId">The source identifier.</param>
    /// <returns>
    ///   true, if successful,
    ///   false otherwise.
    /// </returns>
    public virtual bool DeleteSource(int sourceId)
    {
        var response = this.HttpClient.DeleteAsync("https://localhost:7240/SourceExplorer/Delete/" + sourceId).Result;

        return response.IsSuccessStatusCode;
    }

    private Task<bool> addPdfSource(string title, string filePath)
    {
        var fileContent = this.loadFile(filePath);
        var content = new MultipartFormDataContent
        {
            { new StringContent(title), "Title" },
            { new StringContent(SourceType.Pdf.ToString()), "Type" },
            { fileContent, "pdfUpload", Path.GetFileName(filePath) }
        };
        return this.sendRequest(content);
    }

    private Task<bool> addVideoLinkSource(string title, string filePath)
    {
        var content = new MultipartFormDataContent
        {
            { new StringContent(title), "Title" },
            { new StringContent(SourceType.VideoLink.ToString()), "Type" },
            { new StringContent(filePath), "Link" }
        };
        return this.sendRequest(content);
    }

    private Task<bool> sendRequest(HttpContent content)
    {
        var response = this.HttpClient.PostAsync("https://localhost:7240/SourceExplorer/Create", content).Result;

        return Task.FromResult(response.IsSuccessStatusCode);
    }

    private ByteArrayContent loadFile(string filePath)
    {
        var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
        return fileContent;
    }

    #endregion
}
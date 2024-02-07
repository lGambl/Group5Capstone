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
    #region Data members

    private readonly HttpClient httpClient;

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
        this.httpClient = new HttpClient(handler);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthService"/> class.
    /// Designed for testing purposes.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public AuthService(HttpClient httpClient)
    {
        this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
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

        var response = await this.httpClient.PostAsync("https://localhost:7240/auth/login", content)
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
            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await this.httpClient.GetAsync("https://localhost:7240/SourceExplorer")
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

    #endregion
}
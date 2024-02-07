using System.Text;
using Newtonsoft.Json;

namespace StudyDesk.Controller;

/// <summary>
///     The User Registration Controller
/// </summary>
public class UserRegistrationController
{
    #region Properties

    private HttpClient Client { get; }

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="UserRegistrationController" /> class.
    /// </summary>
    public UserRegistrationController()
    {
        this.Client = new HttpClient();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UserRegistrationController" /> class.
    ///     Designed for testing purposes.
    /// </summary>
    /// <param name="client">The client.</param>
    public UserRegistrationController(HttpClient client)
    {
        this.Client = client;
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Creates the new user.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="email">The email.</param>
    /// <param name="password">The password.</param>
    /// <returns>
    ///     True if the registration is successful, false if unsuccessful
    /// </returns>
    public async Task<bool> CreateNewUser(string username, string email, string password)
    {
        var registerDto = new
        {
            Username = username,
            Email = email,
            Password = password
        };
        var content = new StringContent(JsonConvert.SerializeObject(registerDto), Encoding.UTF8,
            "application/json");

        var response = await this.Client.PostAsync("https://localhost:7240/account/register", content)
            .ConfigureAwait(false);

        return response.IsSuccessStatusCode;
    }

    #endregion
}
using StudyDesk.Model;

namespace StudyDesk.Controller;

/// <summary>
///     The Login Controller.
/// </summary>
public class LoginController
{

    private readonly AuthService authService;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoginController"/> class.
    /// </summary>
    /// <param name="authService">The authentication service.</param>
    public LoginController(AuthService authService)
    {
        this.authService = authService;
    }
    #region Methods

    /// <summary>
    ///     Verifies the login credentials.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    /// <returns>
    ///     True if login is successful, False if unsuccessful
    /// </returns>
    public AuthService? VerifyLoginCredentials(string username, string password)
    {
        return this.authService.LoginAsync(username, password).Result;
    }

    #endregion
}
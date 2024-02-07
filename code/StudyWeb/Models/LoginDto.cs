namespace StudyWeb.Models;

/// <summary>
///     The Login Data Transfer Object on the Web Application side.
/// </summary>
public class LoginDto
{
    #region Properties

    /// <summary>
    ///     Gets or sets the username.
    /// </summary>
    /// <value>
    ///     The username.
    /// </value>
    public string? Username { get; init; }

    /// <summary>
    ///     Gets or sets the password.
    /// </summary>
    /// <value>
    ///     The password.
    /// </value>
    public string? Password { get; init; }

    #endregion
}
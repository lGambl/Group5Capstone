namespace StudyWeb.Models
{
    /// <summary>
    ///   The RegisterDto class in the Web app.
    /// </summary>
    public class RegisterDto
    {
        /// <summary>
        ///   Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string? Username { get; init; }

        /// <summary>
        ///   Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string? Email { get; init; }

        /// <summary>
        ///   Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string? Password { get; init; }
    }

}

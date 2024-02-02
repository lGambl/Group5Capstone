namespace StudyDesk.Model
{

    /// <summary>
    ///   The Login Data Transfer Object on the Desktop Application side.
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        ///   Gets or sets the username.
        /// </summary>
        /// <value>
        ///   The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        ///   Gets or sets the password.
        /// </summary>
        /// <value>
        ///   The password.
        /// </value>
        public string Password { get; set; }

    }
}

using StudyDesk.Model;

namespace StudyDesk.Controller
{
    /// <summary>
    ///   The Login Controller.
    /// </summary>
    public class LoginController
    {

        /// <summary>
        ///   Verifies the login credentials.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   True if login is successful, False if unsuccessful
        /// </returns>
        public bool VerifyLoginCredentials(string username, string password)
        {
            if (new AuthService().LoginAsync(username, password).Result == true)
            {
                return true;
            }
            return false;
        }

    }
}

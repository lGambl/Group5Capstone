using Newtonsoft.Json;
using System.Text;

namespace StudyDesk.Controller
{
    /// <summary>
    ///   The User Registration Controller
    /// </summary>
    public class UserRegistrationController
    {

        /// <summary>
        ///   Creates the new user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   True if the registration is successful, false if unsuccessful
        /// </returns>
        public async Task<bool> CreateNewUser(string username, string email, string password)
        {
            var client = new HttpClient();
            var registerDto = new
            {
                Username = username,
                Email = email,
                Password = password
            };
            var content = new StringContent(JsonConvert.SerializeObject(registerDto), Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync("https://localhost:7240/account/register", content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    }
}

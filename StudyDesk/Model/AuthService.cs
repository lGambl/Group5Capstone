using System.Text;
using Newtonsoft.Json;

namespace StudyDesk.Model
{
    /// <summary>
    ///   The Authorization Service class.
    /// </summary>
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        ///   Initializes a new instance of the <see cref="AuthService" /> class.
        /// </summary>
        public AuthService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        ///   Sends credentials to check login validity.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   True if successful, false if unsuccessful, or throws an exception.
        /// </returns>
        /// <exception cref="System.Exception">
        ///   Login failed with status code: StatusCode
        /// </exception>
        public async Task<bool> LoginAsync(string username, string password)
        {
            var loginDto = new LoginDto { Username = username, Password = password };
            var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7240/auth/login", content)
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                //Process the response content here
                return true;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                // Handle unauthorized
                return false;
            }
            else
            {
                // Handle other types of failures
                throw new Exception("Login failed with status code: " + response.StatusCode);
            }
        }
    }
}
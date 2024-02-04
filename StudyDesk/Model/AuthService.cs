using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using StudyWeb.Models;

namespace StudyDesk.Model
{
    /// <summary>
    ///   The Authorization Service class.
    /// </summary>
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        ///   Gets or sets the token.
        /// </summary>
        /// <value>
        ///   The token.
        /// </value>
        public string Token { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AuthService" /> class.
        /// </summary>
        public AuthService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        ///   Logins the asynchronous.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   True if the login was successful, false if unsuccessful
        /// </returns>
        /// <exception cref="System.Exception">Login failed with status code: response.StatusCode</exception>
        public async Task<bool> LoginAsync(string username, string password)
        {
            var loginDto = new LoginDto { Username = username, Password = password };
            var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7240/auth/login", content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseContent);
                Token = tokenResponse?.Token;

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                Properties.Settings.Default.UserToken = Token;
                Properties.Settings.Default.Save();

                return true;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return false;
            }
            throw new Exception("Login failed with status code: " + response.StatusCode);
        }

    }
}

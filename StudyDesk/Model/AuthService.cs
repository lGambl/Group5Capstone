using System.Net;
using System.Net.Http.Headers;
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
            var handler = new HttpClientHandler
            {
                CookieContainer = new CookieContainer(),
                UseCookies = true,
                UseDefaultCredentials = false
            };
            _httpClient = new HttpClient(handler);
        }

        /// <summary>
        ///   Logins the asynchronous.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   True if the login was successful, false if unsuccessful
        /// </returns>
        /// <exception cref="Exception">Login failed with status code: response.StatusCode</exception>
        public async Task<AuthService?> LoginAsync(string username, string password)
        {
            var loginDto = new LoginDto { Username = username, Password = password };
            var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7240/auth/login", content).ConfigureAwait(false);

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

        public async Task<IEnumerable<Source>> GetSources()
        {
            try
            {

                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.GetAsync("https://localhost:7240/SourceExplorer").ConfigureAwait(false);

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

    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudyWeb.Models;

namespace StudyWeb.Controllers
{
    /// <summary>
    ///   The Authorization Controller class.
    /// </summary>
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        /// <summary>
        ///   Initializes a new instance of the <see cref="AuthController" /> class.
        /// </summary>
        /// <param name="signInManager">
        ///   The sign in manager.
        /// </param>
        public AuthController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        /// <summary>
        ///   Logins the specified model.
        /// </summary>
        /// <param name="model">
        ///   The model.
        /// </param>
        /// <returns>
        ///   Ok if the credentials are legitimate, Unauthorized if illegitimate. 
        /// </returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Generate a JWT token or similar here
                return Ok();
            }
            return Unauthorized();
        }
    }

}

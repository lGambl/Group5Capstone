using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudyWeb.Models;

namespace StudyWeb.Controllers
{
    /// <summary>
    ///   The Account Controller class.
    /// </summary>
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        ///   Initializes a new instance of the <see cref="AccountController" /> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        ///   Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   Succeeded if the registration was successful, bad request if unsuccessful
        /// </returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var user = new IdentityUser { UserName = model.Username, Email = model.Email, EmailConfirmed = true};
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(new { message = "user created successfully" });
            }

            return BadRequest(result.Errors);
        }
    }
}

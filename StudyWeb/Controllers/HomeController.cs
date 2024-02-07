using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudyWeb.Models;

namespace StudyWeb.Controllers
{

    /// <summary>
    ///   The Home Controller class.
    /// </summary>
    public class HomeController : Controller
    {

        /// <summary>
        ///   Indexes this instance.
        /// </summary>
        /// <returns>
        ///   The Index page.
        /// </returns>
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        ///   Privacies this instance.
        /// </summary>
        /// <returns>
        ///   The Privacy page.
        /// </returns>
        public IActionResult Privacy()
        {
            return View();
        }


        /// <summary>
        ///   Errors this instance.
        /// </summary>
        /// <returns>
        ///   The error page.
        /// </returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

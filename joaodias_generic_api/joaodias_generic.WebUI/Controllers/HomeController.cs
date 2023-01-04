using Microsoft.AspNetCore.Mvc;

namespace joaodias_generic.WebUI.Controllers
{
    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Indices the.
        /// </summary>
        /// <returns>An IActionResult.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Privacies the.
        /// </summary>
        /// <returns>An IActionResult.</returns>
        public IActionResult Privacy()
        {
            return View();
        }
    }
}

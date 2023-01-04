using joaodias_generic.Domain.Account;
using joaodias_generic.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace joaodias_generic.WebUI.Controllers
{
    /// <summary>
    /// The account controller.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authentication;
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="authentication">The authentication.</param>
        public AccountController(IAuthenticate authentication)
        {
            _authentication = authentication;
        }

        /// <summary>
        /// Logins the.
        /// </summary>
        /// <param name="returnUrl">The return url.</param>
        /// <returns>An IActionResult.</returns>
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        /// <summary>
        /// Logins the.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A Task.</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authentication.Authenticate(model.Email, model.Password);

            if (result)
            {
                if (string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(model.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.(password must be strong).");
                return View(model);
            }
        }

        /// <summary>
        /// Registers the.
        /// </summary>
        /// <returns>An IActionResult.</returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Registers the.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A Task.</returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var result = await _authentication.RegisterUser(model.Email, model.Password);

            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt (password must be strong.");
                return View(model);
            }
        }

        /// <summary>
        /// Logouts the.
        /// </summary>
        /// <returns>A Task.</returns>
        public async Task<IActionResult> Logout()
        {
            await _authentication.Logout();
            return Redirect("/Account/Login");
        }
    }
}

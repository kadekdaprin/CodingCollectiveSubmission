using CodingCollectiveSubmission.Models;
using CodingCollectiveSubmission.Models.Validators;
using CodingCollectiveSubmission.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodingCollectiveSubmission.Controllers
{
    public class AccountController : Controller
    {
        private readonly RepositoryWrapper _repository;

        public AccountController(RepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            var validator = new LoginValidator().Validate(model);

            if (!validator.IsValid)
            {
                var errors = validator.Errors.Select(x => x.ErrorMessage);
                ViewData["Error"] = String.Join("\n", errors);
                return View("Index");
            }

            var user = _repository.User.GetUser(model);

            if(user != null)
            {
                var claims = new List<Claim>() {
                        new Claim(ClaimTypes.Name, user.Username)
                };
                
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = false
                });

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Error"] = "Invalid Login attemp";
                return View("Index");
            }
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View("Index");
        }
    }
}

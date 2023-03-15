using AdminPanel.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using AdminPanel.Repository.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using AdminPanel.Web.Controllers.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace AdminPanel.Web.Controllers
{
    public class AccountController : BaseAuthController
    {
        private readonly IAccountRepository accountRepository;
        private readonly IUserRepository userRepository;
        public AccountController(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            this.accountRepository = accountRepository;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Register(Register model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var user = accountRepository.Register(model);
                await userRepository.UpdateAsync(user, cancellationToken);

                Authorize(user);

                return Redirect("/");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(Login model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(Login model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var user = accountRepository.Login(model);
                if (user != null)
                {
                     Authorize(user);

                    return Redirect("/");
                }
                ViewBag.LoginError = "Не удалось войти";
            }
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}

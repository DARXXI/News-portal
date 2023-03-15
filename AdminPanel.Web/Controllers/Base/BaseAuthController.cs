using System.Security.Claims;
using AdminPanel.Domain.Entities;
using AdminPanel.Domain.helpers;
using AdminPanel.Repository.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdminPanel.Web.Controllers.Base
{
    public class BaseAuthController : BaseController
    {
        public int UserId
        {
            get
            {
                var userId =  User.Claims.FirstOrDefault(t => t.Type ==
                    "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")!.Value;

                if (userId == null)
                {
                    return 0;
                }

                return Int32.Parse(userId); 
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var imageRepository = context.HttpContext.RequestServices.GetService<IImageRepository>();
                var userRepository = context.HttpContext.RequestServices.GetService<IUserRepository>();

                var user = userRepository.FindOrCreate(UserId);

                if (user != null)
                {
                    var image = imageRepository.Find(user.ImageId);

                    if (image != null)
                    { 
                        ViewBag.ImageHash = image.Hash;
                        return;
                    }
                }
                ViewBag.ImageHash = HashHelper.Hash("default_avatar");
            }
        }

        public async void Authorize(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name),

            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = true
            };
        }
    }
}

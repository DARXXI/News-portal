using AdminPanel.Domain.Entities;
using AdminPanel.Repository.Repositories;
using AdminPanel.Repository.Repositories.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using AdminPanel.Domain.Enums;
using AdminPanel.Web.Controllers.Base;
using System.IO;
using System.Security.Claims;
using AdminPanel.Domain.helpers;
using Azure.Core;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.StaticFiles;
using Dadata.Model;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using AdminPanel.Web.Services;

namespace AdminPanel.Web.Controllers
{
    [Authorize]
    public class ProfileController : BaseAuthController
    {
        private IWebHostEnvironment _hostEnv;
        private IImageRepository _imageRepository;
        private IImageService _imageService;
        public ProfileController(IWebHostEnvironment hostEnv, IImageRepository imageRepository, IImageService imageService)
        {
            _hostEnv = hostEnv;
            _imageRepository = imageRepository;
            _imageService = imageService;
        }

        [AllowAnonymous]
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var userRepository = context.HttpContext.RequestServices.GetService<IUserRepository>();

                var user = userRepository.FindOrCreate(UserId);

                ViewBag.User = user;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken)
        {
            if (file != null)
            {
                var path = _imageService.GeneratePath(UserId.ToString(), file.FileName);

                await using (var fileStream = new FileStream(Path.GetFullPath(path), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                var image = new Image { Name = file.FileName, Path = path, 
                    Hash = HashHelper.Hash(file.FileName), ContentType = file.ContentType};
                await _imageRepository.UpdateAvatar(image, UserId, cancellationToken);
            }
            return RedirectToAction("Index");   
        }

        public IActionResult Index()
        {
            return View("Index");
        }
    }
}

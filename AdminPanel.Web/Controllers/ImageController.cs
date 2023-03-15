using AdminPanel.Repository.Repositories;
using Dadata.Model;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Microsoft.AspNetCore.OutputCaching;
using AdminPanel.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis;

namespace AdminPanel.Web.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        private IWebHostEnvironment _hostEnv;
        private readonly IImageRepository _imageRepository;
        private IImageService _imageService;
        public ImageController(IImageRepository imageRepository, IWebHostEnvironment hostEnv, IImageService imageService)
        {
            _imageRepository = imageRepository;
            _hostEnv = hostEnv;
            _imageService = imageService;
        }


        [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new [] {"*"})]
        public IActionResult Index(string hash)
        {
            if (hash != null)
            {
                var image = _imageRepository.Find(hash);

                //TODO default image
                if (image == null)
                {
                    return BadRequest();
                } 

                var path = Path.Combine(_hostEnv.ContentRootPath, image.Path);

                return File(_imageService.ImageToByte(_imageService.GetImageBitmap(path)), image.ContentType);
            }

            return BadRequest();
        }
    }
}

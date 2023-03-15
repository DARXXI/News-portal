using AdminPanel.Repository.Repositories;
using AdminPanel.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Web.Controllers    
{
    public class HomeController : BaseAuthController
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, IImageRepository imageRepository)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
using AdminPanel.Domain.Entities;
using AdminPanel.Repository.Repositories;
using AdminPanel.Repository.Repositories.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using AdminPanel.Domain.Enums;
using AdminPanel.Web.Controllers.Base;

namespace AdminPanel.Web.Controllers
{
    [Authorize]
    public class NewsController : BaseAuthController
    {
        private readonly INewsRepository newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetData(NewsFilter newsFilter)
        {
            var news = newsRepository.All(newsFilter);

            return Json(news);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.News = newsRepository.GetAllNews();
            return View();
        }

        [HttpGet]
        public IActionResult IndexGrid()    
        {
            return View();
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return View(newsRepository.FindOrCreate(id));
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost]
        public async Task<IActionResult> Edit(News news, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await newsRepository.UpdateAsync(news, cancellationToken);
                return RedirectToAction("Index");
            }
            return View(news);
        }

    }
}

using System.Security.Claims;
using AdminPanel.Domain.Entities;
using AdminPanel.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using AdminPanel.Repository.Repositories.Filters;
using AdminPanel.Web.Controllers.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;


namespace AdminPanel.Web.Controllers
{
    [Authorize]
    public class UsersController : BaseAuthController
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IProjectRepository projectRepository;
        private readonly IUserProjectRepository userProjectRepository;
        public UsersController(IRoleRepository roleRepository, IUserRepository userRepository, IProjectRepository projectRepository, IUserProjectRepository userProjectRepository)
        {
            this.roleRepository = roleRepository;
            this.userRepository = userRepository;
            this.projectRepository = projectRepository;
            this.userProjectRepository = userProjectRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetData(UserFilter userFilter)
        {
            var users = userRepository.All(userFilter);

            return Json(users);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            InitUserSelects();
            return View(userRepository.FindOrCreate(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user, CancellationToken cancellationToken)
        {
            InitUserSelects();
            if (ModelState.IsValid)
            {    
                await userRepository.UpdateAsync(user, cancellationToken);

                Authorize(user);

                return RedirectToAction("Index");

            }
            return View(user);
        }

        [HttpDelete]
        public async Task Delete(int id, CancellationToken cancellationToken)
        { 
            await userRepository.DeleteAsync(id,cancellationToken);
        }

        [AllowAnonymous]
        [HttpPost]
        [HttpGet]
        public  IActionResult CheckExistingEmail(int id, string email)
        {
            if (userRepository.Find(id, email))
            {
                return Json($"Почтовый адрес {email} уже используется");
            }
            return Json(true);
        }

        [NonAction]
        public void InitUserSelects()
        {
            ViewBag.Roles = roleRepository.GetAllRoles();
            ViewBag.Projects = projectRepository.GetAllProjects();
        }
    }
}

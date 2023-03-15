using AdminPanel.Domain.Entities;
using AdminPanel.Repository.Repositories;
using AdminPanel.Repository.Repositories.Filters;
using AdminPanel.Repository.Repositories.Interfaces;
using AdminPanel.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;

namespace AdminPanel.Web.Controllers
{
    [Authorize]
    public class ChatController : BaseAuthController
    {
        private readonly IChatRepository<Message> _chatRepository;
        private readonly IUserRepository _userRepository;
        ITelegramBotClient botClient;



        public ChatController(IChatRepository<Message> chatRepository, IUserRepository userRepository)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
            //ITelegramBotClient botClient;


        }

        [HttpGet]
        public IActionResult Message()
        {
            ViewBag.AllMessages = _chatRepository.GetAllMessages();
            return View(_chatRepository.Create());
        }

        [HttpPost]
        public async Task<IActionResult> Message(string message, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _chatRepository.UpdateAsync(message, UserId, cancellationToken);
            }
            var mes = _chatRepository.GetAllMessages().Last();
            await TelegramBot.SendMessageAsync(cancellationToken, mes);

            return Ok();
        }
    }
}

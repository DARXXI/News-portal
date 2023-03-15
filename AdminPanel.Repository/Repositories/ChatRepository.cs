using AdminPanel.Domain.Entities;
using AdminPanel.Domain.Enums;
using AdminPanel.Domain.Models;
using AdminPanel.Repository.Repositories.Filters;
using AdminPanel.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;


namespace AdminPanel.Repository.Repositories
{
    public class ChatRepository: BaseRepository, IChatRepository<Message>
    {
        public ChatRepository(DataBaseContext context) : base(context)
        {

        }

        public Message Create()
        {
            var message =  new Message { };
            return message;
        }

        public Message[] GetAllMessages()
        {
            return Context.Messages.Include(t=>t.User).ToArray();
        }

        public async Task<Message> UpdateAsync(string message,int userId, CancellationToken cancellationToken)
        {
            Message? mes = JsonConvert.DeserializeObject<Message>(message);
            Console.WriteLine(mes);
            Context.Messages.Update(mes);

            mes.DateCreated = CurrentDate;
            mes.DateUpdated = CurrentDate;
            mes.UserId = userId;

            await Context.SaveChangesAsync(cancellationToken);
            return mes;
        }
    }
}

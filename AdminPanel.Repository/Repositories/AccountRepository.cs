using AdminPanel.Domain.Entities;
using AdminPanel.Domain.Enums;
using AdminPanel.Domain.helpers;
using AdminPanel.Domain.Models;
using AdminPanel.Repository.Repositories.Filters;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;


namespace AdminPanel.Repository.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(DataBaseContext context) : base(context)
        {
        }

        public User Register(Register model)
        {
            var user = Context.Users.FirstOrDefault(t => t.Email == model.Email && t.Password == HashHelper.Hash(model.Password)) ?? new User();
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;
            user.Role = Context.Roles.First();
            return user;
        }

        public User Login(Login model)
        {
            var user = Context.Users.FirstOrDefault(t => t.Email == model.Email && t.Password == HashHelper.Hash(model.Password));
            if (user != null)
            {
                user.Role = Context.Roles.First();
            }
            return user;
        }

        public Register[] GetAllRegistredUsers()
        {
            return Context.Register.ToArray();
        }
    }
}
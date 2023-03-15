using AdminPanel.Domain.Entities;
using AdminPanel.Repository.Configurations;
using AdminPanel.Repository.Repositories.Filters;

namespace AdminPanel.Repository.Repositories
{
    public interface IAccountRepository
    {
        public Register[] GetAllRegistredUsers();
        public User Register(Register model);
        public User Login(Login model);
    }
}
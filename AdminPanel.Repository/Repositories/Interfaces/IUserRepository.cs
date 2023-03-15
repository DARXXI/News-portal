using AdminPanel.Domain.Entities;
using AdminPanel.Domain.Models;
using AdminPanel.Repository.Repositories.Filters;

namespace AdminPanel.Repository.Repositories
{
    public interface IUserRepository: IBaseRepository<User,UserFilter>
    {
        bool Find(int id, string email);
        User FindOrCreate(int? id);
    }
}

using AdminPanel.Domain.Entities;
using AdminPanel.Repository.Repositories.Filters;

namespace AdminPanel.Repository.Repositories
{
    public interface IUserProjectRepository
    {
        public UserProject[] GetAllUserProject();
    }
}
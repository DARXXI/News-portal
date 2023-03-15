using AdminPanel.Domain.Entities;
using AdminPanel.Repository.Repositories.Filters;

namespace AdminPanel.Repository.Repositories
{
    public interface IProjectRepository/*: IBaseRepository<Project,ProjectFilter>*/
    {
        public Project[] GetAllProjects();
    }
}

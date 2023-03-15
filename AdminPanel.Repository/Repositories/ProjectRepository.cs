using AdminPanel.Domain.Entities;

namespace AdminPanel.Repository.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(DataBaseContext context) : base(context)
        {
        }

        public Project[] GetAllProjects()
        {
            return Context.Projects.ToArray();
        }
    }
}   

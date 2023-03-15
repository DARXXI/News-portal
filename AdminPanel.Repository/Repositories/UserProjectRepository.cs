using AdminPanel.Domain.Entities;

namespace AdminPanel.Repository.Repositories
{
    public class UserProjectRepository : BaseRepository, IUserProjectRepository
    {
        public UserProjectRepository(DataBaseContext context) : base(context)
        {
        }

        public UserProject[] GetAllUserProject()
        {
            return Context.UsersProjects.ToArray();
        }
    }
}

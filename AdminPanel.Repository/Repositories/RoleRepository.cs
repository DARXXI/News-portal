using AdminPanel.Domain.Entities;

namespace AdminPanel.Repository.Repositories
{
    public class RoleRepository: BaseRepository, IRoleRepository
    {
        public RoleRepository(DataBaseContext context) : base(context)
        {
        }

        public Role[] GetAllRoles()
        {
            return Context.Roles.ToArray();
        }
    }
}

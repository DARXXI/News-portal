using AdminPanel.Domain.Entities;
using AdminPanel.Repository.Repositories.Filters;

namespace AdminPanel.Repository.Repositories
{
    public interface IRoleRepository/*: IBaseRepository<Role, RoleFilter>*/
    {
        public Role[] GetAllRoles();
    }
}

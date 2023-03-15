using AdminPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AdminPanel.Domain.Enums;
using AdminPanel.Repository.Repositories.Filters;
using AdminPanel.Domain.Models;
using System.Reflection;
using System.Security.Claims;
using AdminPanel.Domain.helpers;
using System.Net.Http;
using System.Security.Policy;

namespace AdminPanel.Repository.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(DataBaseContext context) : base(context)
        {

        }
        public BaseModel<User> All(UserFilter userFilter)
        {
            var propertyGetter = DynamicExpressions.DynamicExpressions.GetPropertyGetter<User>(userFilter.SortColumn);
            var query = Context.Users.Skip(userFilter.StartRow).Take(userFilter.Take)
                .Include(t => t.Role)
                .Include(t => t.UserProjects)!
                .ThenInclude(t => t.Project).AsQueryable();

            query = userFilter.SortOrder == SortOrder.Asc
                ? query.OrderBy(propertyGetter)
                : query.OrderByDescending(propertyGetter);
            var queryUsers = query.ToArray();

            var usersModel = new BaseModel<User>() { Data = queryUsers, LastRowIndex = Context.Users.Count() };
            return usersModel;
        }

        public async Task<User> FindAsync(int id, CancellationToken cancellationToken)
        {
            return await Context.Users.Include(t => t.UserProjects).SingleOrDefaultAsync(t=>t.Id == id , cancellationToken);
        }

        public User FindOrCreate(int? id)
        {
            var user = id != null ?  Context.Users.Find(new object?[] { id }) : new User();
            return user;
        }

        public bool Find(int id, string email)
        {
            var userWithSameEmail = Context.Users.SingleOrDefault(t => t.Email == email);
            return userWithSameEmail != null && userWithSameEmail.Id != id;
        }

        public User Create()
        {
            var user = new User();
            return user;
        }
        
        public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            if (user.IsNew())
            {
                user.DateCreated = CurrentDate;
                user.Password = HashHelper.Hash(user.Password);
                user.ImageId = Context.Images.OrderBy(t => t.Id).First().Id;
            }
            
            user.DateUpdated = CurrentDate;

            Context.Users.Update(user);
            await Context.SaveChangesAsync(cancellationToken);
            var userProjectsToDelete = Context.UsersProjects.Where(t => t.UserId == user.Id);
            Context.UsersProjects.RemoveRange(userProjectsToDelete);
            var userProjects = user.ProjectsId.Select(t => new UserProject() { ProjectId = t, UserId = user.Id }).ToList();
            Context.UsersProjects.AddRange(userProjects);
            var projectsIds = new List<int>();
            foreach (var project in userProjects)
            {
                projectsIds.Add(project.ProjectId);
            }
            user.ProjectsId = projectsIds;
            await Context.SaveChangesAsync(cancellationToken);
            return user;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var exactUser = await FindAsync(id, cancellationToken);
            Context.Users.Remove(exactUser);
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}

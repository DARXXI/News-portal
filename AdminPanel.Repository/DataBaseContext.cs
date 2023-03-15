using System.Reflection;
using AdminPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Repository
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options) {}
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UserProject> UsersProjects { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Register> Register { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.LoadFrom(Path.Combine(path, "AdminPanel.Repository.dll")));
        }
    }
}

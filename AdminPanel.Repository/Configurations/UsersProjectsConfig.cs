using AdminPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Repository.Configurations
{
    public class UsersProjectsConfig : IEntityTypeConfiguration<UserProject>
    {
        public void Configure(EntityTypeBuilder<UserProject> builder)
        {
            builder.ToTable("UsersProjects");

            builder.HasKey("UserId", "ProjectId");

            builder
                .HasOne(t => t.User)
                .WithMany(t => t.UserProjects)
                .HasForeignKey(t => t.UserId);
            builder
                .HasOne(t => t.Project)
                .WithMany(t => t.ProjectUsers)
                .HasForeignKey(t => t.ProjectId);
        }
    }
}
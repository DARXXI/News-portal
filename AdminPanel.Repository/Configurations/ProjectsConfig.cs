using AdminPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Repository.Configurations
{
    public class ProjectsConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Name")
                .HasColumnType("varchar");
        }
    }
}

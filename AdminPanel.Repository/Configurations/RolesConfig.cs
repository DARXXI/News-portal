using AdminPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Repository.Configurations
{
    public class RolesConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
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

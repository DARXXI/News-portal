using AdminPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Repository.Configurations
{
    public class LoginConfig : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder
                .Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Email")
                .HasColumnType("varchar");
            builder
                .Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Password")
                .HasColumnType("varchar");
        }
    }
}
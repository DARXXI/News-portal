using AdminPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Repository.Configurations
{
    public class RegisterConfig : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Name")
                .HasColumnType("varchar");
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
            builder
                .Property(t => t.ConfirmedPassword)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("ConfirmedPassword")
                .HasColumnType("varchar");
        }
    }
}
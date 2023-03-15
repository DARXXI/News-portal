using AdminPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Repository.Configurations
{
    public class UsersConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(t => t.Age)
                .HasColumnName("Age")
                .HasColumnType("int");
            builder
                .Property(t => t.City)
                .HasMaxLength(100)
                .HasColumnName("City")
                .HasColumnType("varchar");
            builder
                .Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Email")
                .HasColumnType("varchar");
            builder
                .Property(t => t.Name)
                .HasMaxLength(100)
                .HasColumnName("Name")
                .HasColumnType("varchar");
            builder
                .Property(t => t.Note)
                .HasMaxLength(100)
                .HasColumnName("Note")
                .HasColumnType("varchar");
            builder
                .Property(b => b.Password)
                .HasMaxLength(100)
                .HasColumnName("Password")
                .HasColumnType("varchar");
            builder
                .Property(b => b.Phone)
                .HasMaxLength(100)
                .HasColumnName("Phone")
                .HasColumnType("varchar");
        }
    }   
}

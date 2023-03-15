using AdminPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Repository.Configurations
{
    public class SettingsConfig : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder
                .Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Code")
                .HasColumnType("varchar");
            builder
                .Property(t => t.Value)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Value")
                .HasColumnType("varchar");
        }
    }
}

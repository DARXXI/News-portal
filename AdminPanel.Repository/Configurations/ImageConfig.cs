using AdminPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Repository.Configurations
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Name")
                .HasColumnType("varchar");
            builder
                .Property(t => t.Path)
                .HasMaxLength(100)
                .HasColumnName("Path")
                .HasColumnType("varchar");
            builder
                .Property(t => t.Hash)
                .HasMaxLength(100)
                .HasColumnName("Hash")
                .HasColumnType("varchar");
            builder
                .Property(t => t.UsagePlace)
                .HasMaxLength(100)
                .HasColumnName("UsagePlace")
                .HasColumnType("varchar");
        }
    }
}

using AdminPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Repository.Configurations
{
    public class NewsConfig : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Title")
                .HasColumnType("varchar");
            builder
                .Property(t => t.Content)
                .IsRequired()
                .HasColumnName("Content")
                .HasColumnType("text");
            builder
                .Property(t => t.Views)
                .HasColumnName("Views")
                .HasColumnType("int");
            builder
                .Property(t => t.IsPublished)
                .IsRequired()
                .HasColumnName("IsPublished")
                .HasColumnType("boolean");
        }
    }
}
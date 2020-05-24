using Articles.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Heading).IsRequired();
            builder.Property(e => e.Text).IsRequired();
            builder.Property(e => e.Year).IsRequired();
            builder.HasOne(e => e.Author).WithMany(e=> e.Articles);
        }
    }
}

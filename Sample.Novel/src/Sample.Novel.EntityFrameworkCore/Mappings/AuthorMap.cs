using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Novel.Domain.Author.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sample.Novel.EntityFrameworkCore.Mappings
{
    public class AuthorMap: IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable(nameof(Author));
            
            // 对实体配置基本属性和约定，包括外键
            builder.ConfigureByConvention();

            builder.Property(author => author.Name).IsRequired()
                .HasMaxLength(20);
        }
    }
}
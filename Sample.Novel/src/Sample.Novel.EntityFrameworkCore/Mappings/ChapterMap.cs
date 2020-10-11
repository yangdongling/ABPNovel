using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Novel.Domain.Book.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sample.Novel.EntityFrameworkCore.Mappings
{
    public class ChapterMap: IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.ToTable(nameof(Chapter));
            
            builder.ConfigureByConvention();

            // chapter和chapterText之间一对一，但没有按约定去做，需要自己手动书写一下
            builder.HasOne(chapter => chapter.ChapterText)
                .WithOne(text => text.Chapter)
                .HasForeignKey<ChapterText>(text => text.Id);
        }
    }
}
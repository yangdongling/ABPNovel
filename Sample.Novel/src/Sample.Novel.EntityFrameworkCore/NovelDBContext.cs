using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.Domain.Book.Entities;
using Sample.Novel.Domain.Category.Entities;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore
{
    // 可以指定到具体appsetting.json的连接字符串里，在具体的Wweb项目里配置
    [ConnectionStringName("Novel")]
    public class NovelDBContext: AbpDbContext<NovelDBContext>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<ChapterText> ChapterTexts { get; set; }
        
        public NovelDBContext(DbContextOptions<NovelDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 使用当前的assembly加载mapping配置文件，全部都应用起来
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
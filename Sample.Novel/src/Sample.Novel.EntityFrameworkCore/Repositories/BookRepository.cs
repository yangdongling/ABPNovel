using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Book.Entities;
using Sample.Novel.Domain.Book.Repository;
using Sample.Novel.EntityFrameworkCore.Extensions;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore.Repositories
{
    public class BookRepository : EfCoreRepository<NovelDBContext, Book, Guid>, IBookRepository
    {
        public BookRepository(IDbContextProvider<NovelDBContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Chapter> FindChapterByIdAsync(Guid id, bool include = true,
            CancellationToken cancellationToken = default)
        {
            var result = await DbContext.Chapters
                .IncludeIf(include, chapter => chapter.ChapterText)
                .FirstOrDefaultAsync(chapter => chapter.Id == id, GetCancellationToken(cancellationToken));

            return result;
        }

        // 实现Abp指定导航属性，需要自己override扩展实现, 公共方法放在扩展类里
        public override IQueryable<Book> WithDetails()
        {
            return GetQueryable().IncludeDetails();
        }
    }
}
using System;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Book.Entities;
using Sample.Novel.Domain.Book.Repository;
using Volo.Abp.Threading;

namespace Sample.Novel.EntityFrameworkCore.Extensions
{
    /// <summary>
    /// BookRepository的同步自定义方法
    /// </summary>
    public static class BookRepositoryExtensions
    {
        public static Chapter FindChapterById(this IBookRepository repository, Guid id, bool include,
            CancellationToken cancellationToken)
        {
            return AsyncHelper.RunSync(() => repository.FindChapterByIdAsync(id, include));
        }
        
        // override 和repository实现类配合使用
        public static IQueryable<Book> IncludeDetails(
            this IQueryable<Book> queryable,
            bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(book => book.Volumes)
                .ThenInclude(volume => volume.Chapters);
        }
    }
}
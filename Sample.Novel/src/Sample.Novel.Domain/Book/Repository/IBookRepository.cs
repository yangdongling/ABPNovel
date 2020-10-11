using System;
using System.Threading;
using System.Threading.Tasks;
using Sample.Novel.Domain.Book.Entities;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Domain.Book.Repository
{
    public interface IBookRepository : IRepository<Entities.Book, Guid>
    {
        /// <summary>
        /// 查询章节
        /// </summary>
        /// <param name="id"></param>
        /// <param name="include">是否包括ChapterText</param>
        /// <returns></returns>
        Task<Chapter> FindChapterByIdAsync(Guid id,
            bool include = true,
            CancellationToken cancellationToken = default);
    }
}
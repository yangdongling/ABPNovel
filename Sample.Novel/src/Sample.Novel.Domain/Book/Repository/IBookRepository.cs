using System;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Domain.Book.Repository
{
    public interface IBookRepository: IRepository<Entities.Book, Guid>
    {
        
    }
}
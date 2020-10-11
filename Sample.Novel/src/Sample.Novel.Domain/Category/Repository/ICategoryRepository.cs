using System;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Domain.Category.Repository
{
    public interface ICategoryRepository: IRepository<Entities.Category, Guid>
    {
        
    }
}
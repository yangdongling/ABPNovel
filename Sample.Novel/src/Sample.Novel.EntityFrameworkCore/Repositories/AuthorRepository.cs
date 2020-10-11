using System;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.Domain.Author.Repository;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore.Repositories
{
    public class AuthorRepository: EfCoreRepository<NovelDBContext, Author, Guid>, IAuthorRepository
    {
        public AuthorRepository(IDbContextProvider<NovelDBContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
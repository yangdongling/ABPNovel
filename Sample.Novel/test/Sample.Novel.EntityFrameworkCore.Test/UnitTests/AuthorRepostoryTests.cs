using System;
using System.Threading.Tasks;
using Sample.Novel.Domain.Author.Entities;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Xunit;

namespace Sample.Novel.EntityFrameworkCore.Test.UnitTests
{
    public class AuthorRepostoryTests : NovelEntityFrameworkCoreTestBase
    {
        // 使用通用反向仓储接口
        private readonly IRepository<Author, Guid> _authorRepository;

        // ABP中GUID生成器
        private readonly IGuidGenerator _guidGenerator;

        public AuthorRepostoryTests()
        {
            // 直接从DI中获取对应的实例
            _authorRepository = GetRequiredService<IRepository<Author, Guid>>();
            _guidGenerator = GetRequiredService<IGuidGenerator>();
        }

        [Fact]
        public async Task Should_Insert_A_Valid_Author()
        {
            await WaitUnitOfWorkAsync(async () =>
            {
                var result = await _authorRepository.InsertAsync(new Author(_guidGenerator.Create(),
                    "天下霸唱", "盗墓系列开山鼻祖"));

                result.Id.ShouldNotBeNull();
            });
        }
    }
}
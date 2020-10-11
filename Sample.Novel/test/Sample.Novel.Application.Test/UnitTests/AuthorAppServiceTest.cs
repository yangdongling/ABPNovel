using System.Threading.Tasks;
using Sample.Novel.Application.Contracts.Dtos.Author;
using Sample.Novel.Application.Contracts.Interfaces;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Xunit;

namespace Sample.Novel.Application.Test.UnitTests
{
    public class AuthorAppServiceTest : NovelApplicationTestBase
    {
        private readonly IAuthorAppService _authorAppService;

        public AuthorAppServiceTest(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        [Fact]
        public async Task Should_Create_A_Valid_Author()
        {
            await WaitUnitOfWorkAsync(async () =>
            {
                // 没有返回值的，用是否抛出异常判定
                Should.NotThrow(async () =>
                {
                    var input = new CreateAuthorInput
                    {
                        Name = "天下霸唱",
                        Description = "盗墓小说祖师"
                    };

                    await _authorAppService.CreateAsync(input);
                });
            });
        }

        [Fact]
        public async Task Should_Get_PagedAndSorted_Of_Authors()
        {
            var result = await WaitUnitOfWorkAsync(async () =>
            {
                var input = new PagedAndSortedResultRequestDto
                {
                    SkipCount = 0,
                    MaxResultCount = 10,
                    Sorting = "Name"
                };

                return await _authorAppService.GetListAsync(input);
            });

            result.TotalCount.ShouldBe(1);
            result.Items.Count.ShouldBe(1);
        }
    }
}
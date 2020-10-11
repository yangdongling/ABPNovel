using System;
using System.Threading.Tasks;
using Sample.Novel.Application.Contracts.Dtos.Author;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sample.Novel.Application.Contracts.Interfaces
{
    public interface IAuthorAppService: IApplicationService
    {
        Task CreateAsync(CreateAuthorInput input);

        Task<AuthorDto> GetAsync(Guid id);

        /// <summary>
        /// 查询分页结果
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}
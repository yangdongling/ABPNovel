using System;
using Volo.Abp.Application.Dtos;

namespace Sample.Novel.Application.Contracts.Dtos.Author
{
    /// <summary>
    /// 查询实体完整信息的输出Dto，不同的实体可以做多个Dto来隐藏一些属性
    /// </summary>
    public class AuthorDto: EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
using Volo.Abp.Application.Dtos;

namespace Sample.Novel.Application.Contracts.Dtos.Author
{
    /// <summary>
    /// 输入Dto，创建auther时候使用，不推荐重用，不同的属性和操作要求使用不同的Dto
    /// </summary>
    public class CreateAuthorInput: EntityDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
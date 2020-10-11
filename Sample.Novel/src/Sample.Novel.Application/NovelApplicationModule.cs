using System;
using Sample.Novel.Application.Contracts;
using Sample.Novel.Application.Profiles;
using Sample.Novel.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Sample.Novel.Application
{
    [DependsOn(typeof(AbpAutoMapperModule),
        typeof(NovelDomainModule),
        typeof(NovelApplicationContractsModule))]
    public class NovelApplicationModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // 添加automapper的配置类
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AuthorProfile>(true);
            });
        }
    }
}
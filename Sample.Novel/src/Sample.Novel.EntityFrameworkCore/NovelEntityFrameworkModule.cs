using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace Sample.Novel.EntityFrameworkCore
{
    [DependsOn(typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreSqliteModule))]
    public class NovelEntityFrameworkModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<NovelDBContext>(option =>
            {
                // 默认只对聚合根创建仓储服务，给参数true是对实体也建立仓储
                option.AddDefaultRepositories(true);
            });
        }
    }
}
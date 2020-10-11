using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Sample.Novel.EntityFrameworkCore.DBMigrations
{
    [DependsOn(typeof(NovelEntityFrameworkModule))]
    public class NovelDBMigrationsModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<NovelDBContext>();
        }
    }
}
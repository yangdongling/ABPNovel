using Autofac.Extensions.DependencyInjection;
using Sample.Novel.Domain;
using Sample.Novel.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Sample.Novel.TestBase
{
    [DependsOn(typeof(AbpTestBaseModule),
        typeof(AbpAutofacModule),
        typeof(NovelDomainModule),
        typeof(NovelEntityFrameworkModule))]
    public class NovelTestBaseModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        { 
            context.Services.AddAutofac();
        }
    }
}
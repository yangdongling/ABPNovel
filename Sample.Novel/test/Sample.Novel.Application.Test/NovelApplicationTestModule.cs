using System;
using Sample.Novel.EntityFrameworkCore.Test;
using Volo.Abp.Modularity;
using Xunit;

namespace Sample.Novel.Application.Test
{
    [DependsOn(typeof(NovelApplicationModule),
        typeof(NovelEntityFrameworkCoreTestModule))]
    public class NovelApplicationTestModule: AbpModule
    {
    }
}
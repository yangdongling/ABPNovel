using System;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.Testing;
using Volo.Abp.Uow;
using Xunit;

namespace Sample.Novel.TestBase
{
    public abstract class NovelTestBase<TStartupModule> : AbpIntegratedTest<TStartupModule>
        where TStartupModule : IAbpModule
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.Services.AddAutofac();
        }

        protected virtual async Task WaitUnitOfWorkAsync(AbpUnitOfWorkOptions options, Func<Task> action)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var uowManager = scope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();

                using (var uow = uowManager.Begin(options))
                {
                    await action();

                    await uow.CompleteAsync();
                }
            }
        }

        protected virtual async Task<TResult> WaitUnitOfWorkAsync<TResult>(AbpUnitOfWorkOptions options,
            Func<Task<TResult>> func)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var uowManager = scope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();

                using (var uow = uowManager.Begin(options))
                {
                    var result = await func();
                    await uow.CompleteAsync();
                    return result;
                }
            }
        }

        protected virtual Task WaitUnitOfWorkAsync(Func<Task> action)
        {
            return WaitUnitOfWorkAsync(new AbpUnitOfWorkOptions(), action);
        }

        protected virtual Task<TResult> WaitUnitOfWorkAsync<TResult>(Func<Task<TResult>> func)
        {
            return WaitUnitOfWorkAsync<TResult>(new AbpUnitOfWorkOptions(), func);
        }
    }
}
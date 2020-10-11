using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Sample.Novel.TestBase;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace Sample.Novel.EntityFrameworkCore.Test
{
    [DependsOn(typeof(NovelEntityFrameworkModule),
        typeof(NovelTestBaseModule),
        typeof(AbpEntityFrameworkCoreSqliteModule))]
    public class NovelEntityFrameworkCoreTestModule : AbpModule
    {
        private SqliteConnection _sqliteConnection;

        private static SqliteConnection CreateDataBaseAndGetConnection()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            // 通过上下文的选项构建对象，创建上下文
            var options = new DbContextOptionsBuilder<NovelDBContext>()
                .UseSqlite(connection)
                .Options;

            // 上下文获取数据库创建器，创建表，返回连接
            using var context = new NovelDBContext(options);
            context.GetService<IRelationalDatabaseCreator>().CreateTables();

            return connection;
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            _sqliteConnection = CreateDataBaseAndGetConnection();

            context.Services.Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(configurationContext =>
                    configurationContext.DbContextOptions.UseSqlite(_sqliteConnection));
            });
        }

        public override void OnApplicationShutdown(ApplicationShutdownContext context)
        {
            _sqliteConnection.Close();
            _sqliteConnection.Dispose();
        }
    }
}
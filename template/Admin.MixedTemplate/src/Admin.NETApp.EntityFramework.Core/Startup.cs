using Furion;
using Furion.DatabaseAccessor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.NETApp.EntityFramework.Core
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseAccessor(options =>
            {
                options.CustomizeMultiTenants(); // 自定义租户

                options.AddDb<DefaultDbContext>(providerName: default, optionBuilder: opt =>
                {
#if (SqlServer)
                    opt.UseBatchEF_MSSQL(); // EF批量组件
#elif (MySql)
                    opt.UseBatchEF_MySQLPomelo(); // EF批量组件
#elif (Oracle)
                    opt.UseBatchEF_Oracle(); // EF批量组件
#elif (Npgsql)
                    opt.UseBatchEF_Npgsql(); // EF批量组件
#elif (Sqlite)
                    opt.UseBatchEF_Sqlite(); // EF批量组件
#endif
                });
#if (EnableTenant)
                options.AddDb<MultiTenantDbContext, MultiTenantDbContextLocator>();
#endif
            }, "Admin.NETApp.Database.Migrations");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //// 自动迁移数据库（update-database命令）
            //if (env.IsDevelopment())
            //{
            //    Scoped.Create((_, scope) =>
            //    {
            //        var context = scope.ServiceProvider.GetRequiredService<DefaultDbContext>();
            //        context.Database.Migrate();
            //    });
            //}
        }
    }
}
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;

namespace WeishanCloud.Library.Extensions
{
    public static class MigrateDatabase
    {
        // 自动迁移数据库
        public static IHost AutoMigrateDbContext<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder = null) where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();
                var configuration = services.GetService<IConfiguration>();
                var env = services.GetService<IWebHostEnvironment>();

                var connectionString = configuration.GetConnectionString("DatabaseConnection");
                try
                {
                    logger.LogInformation($"为 DbContext {typeof(TContext).Name} 迁移数据库.");
                    logger.LogInformation($"数据库连接字符串是: {connectionString}");
                    var retry = Policy.Handle<Exception>().WaitAndRetry(new[]
                    {
                        TimeSpan.FromSeconds(5),
                        TimeSpan.FromSeconds(10),
                        TimeSpan.FromSeconds(15),
                        TimeSpan.FromSeconds(20),
                        TimeSpan.FromSeconds(25), 
                    });

                    retry.Execute(() =>
                    {
                        context.Database.Migrate();
                        try
                        {
                            seeder?.Invoke(context, services);
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, $"出现未知错误导致无法迁移数据库给 {typeof(TContext).Name}");
                        }
                    });
                    logger.LogInformation($"给此上下文迁移数据库: {typeof(TContext).Name}");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"出现了未知错误导致无法迁移数据库给 {typeof(TContext).Name}");
                }
            }

            return host;
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WeishanCloud.Library.Extensions
{
    public static class DefaultMvc
    {
        // 添加默认的Mvc框架
        public static IServiceCollection AddDefaultMvc(this IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson().SetCompatibilityVersion(CompatibilityVersion.Latest);

            return services;
        }
    }
}
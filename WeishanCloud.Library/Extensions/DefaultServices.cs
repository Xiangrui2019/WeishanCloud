using System;
using Microsoft.Extensions.DependencyInjection;

namespace WeishanCloud.Library.Extensions
{
    public static class DefaultServices
    {
        public static IServiceCollection AddDefaultServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
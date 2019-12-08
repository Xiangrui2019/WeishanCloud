using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeishanCloud.Library.Interfaces;

namespace WeishanCloud.Library.Extensions
{
    public static class AutoRegister
    {
        public static IEnumerable<T> AddWith<T>(this IEnumerable<T> input, T toadd)
        {
            var list = input.ToList();
            list.Add(toadd);
            return list;
        }

        public static List<Type> AllAccessiableClass()
        {
            var entry = Assembly.GetEntryAssembly();
            return entry
                .GetReferencedAssemblies()
                .ToList()
                .Select(t => Assembly.Load(t))
                .AddWith(entry)
                .SelectMany(t => t.GetTypes())
                .Where(t => !t.IsNestedPrivate)
                .Where(t => !t.IsGenericType)
                .Where(t => !t.IsInterface)
                .Where(t => !(t.Namespace?.StartsWith("System") ?? true))
                .ToList();
        }
        
        // 注册所有实现了对应接口的类
        public static IServiceCollection AutoRegisterDependencies(this IServiceCollection services, string applicationName)
        {
            var executingTypes = AllAccessiableClass();
            
            foreach (var item in executingTypes)
            {
                if (item.GetInterfaces().Contains(typeof(ISingletonDependency)))
                {
                    if (item.GetInterfaces().Contains(typeof(IHostedService)))
                    {
                        services.AddSingleton(typeof(IHostedService), item);
                    }
                    else
                    {
                        services.AddSingleton(item);
                    }
                    Console.WriteLine($"[Auto Register Dependencies] 服务: {item.Name} - 成功注册为了一个Singleton服务.");
                }
                else if (item.GetInterfaces().Contains(typeof(IScopedDependency)))
                {
                    services.AddScoped(item);
                    Console.WriteLine($"[Auto Register Dependencies] 服务: {item.Name} - 成功注册为了一个Scoped服务.");
                }
                else if (item.GetInterfaces().Contains(typeof(ITransientDependency)))
                {
                    services.AddTransient(item);
                    Console.WriteLine($"[Auto Register Dependencies] 服务: {item.Name} - 成功注册为了一个Transient服务.");
                }
            }

            return services;
        }
    }
}
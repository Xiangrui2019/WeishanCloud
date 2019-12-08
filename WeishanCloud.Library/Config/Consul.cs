using System;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Winton.Extensions.Configuration.Consul;

namespace WeishanCloud.Library.Config
{
    public static class Consul
    {
        public static void ConsulApplicationConfiguration(HostBuilderContext builderContext,
            IConfigurationBuilder configurationBuilder)
        {
            var env = builderContext.HostingEnvironment;
            

            configurationBuilder.AddConsul(
                $"{env.ApplicationName}/appsettings.{env.EnvironmentName}.json",
                options =>
                {
                    options.Optional = true;
                    options.ReloadOnChange = true;
                    options.OnLoadException = exceptionContext => { exceptionContext.Ignore = true; };
                    options.ConsulConfigurationOptions = consulConfig =>
                    {
                        var consulUrl = Environment.GetEnvironmentVariable("CONSUL_CONFIG_CENTER_URL");
                        var consulDc = Environment.GetEnvironmentVariable("CONSUL_CONFIG_CENTER_DC");

                        consulConfig.Address = new Uri(consulUrl == "" ? "" : consulUrl);
                        consulConfig.Datacenter = consulDc == "" ? "dc1" : consulDc;
                    };
                });

            builderContext.Configuration = configurationBuilder.Build();
        }
    }
}
using Microsoft.Extensions.Configuration;
using WeishanCloud.Library.Interfaces;

namespace WeishanCloud.Library.Services
{
    public class ServiceLocation : ISingletonDependency
    {
        public ServiceLocation(IConfiguration configuration)
        {
        }
    }
}
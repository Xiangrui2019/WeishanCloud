using Microsoft.Extensions.Configuration;
using WeishanCloud.Library.Interfaces;

namespace WeishanCloud.Library.Services
{
    public class ServiceLocation : ISingletonDependency
    {
        public string Home { get; private set; }
        public string UI { get; private set; }
        
        public ServiceLocation(IConfiguration configuration)
        {
            Home = "http://localhost:5000/";
            UI = "https://ui.chenbaibai.xyz:33444/";
        }
    }
}
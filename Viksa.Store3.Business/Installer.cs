using Microsoft.Extensions.DependencyInjection;
using Viksa.Store3.Business.Implementations;

namespace Viksa.Store3.Business
{
    public static class Installer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            DataAccess.Installer.ConfigureServices(services);

            services.AddTransient<IAgreementsBusiness, AgreementsBusiness>();
            services.AddTransient<IProductsBusiness, ProductsBusiness>();
            services.AddTransient<ICustomersBusiness, CustomersBusiness>();
            services.AddTransient<IOrdersBusiness, OrdersBusiness>();
        }
    }
}

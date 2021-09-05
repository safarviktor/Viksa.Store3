using Microsoft.Extensions.DependencyInjection;
using System;
using Viksa.Store3.DataAccess.Implementations;

namespace Viksa.Store3.DataAccess
{
    public static class Installer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomersRepository, CustomersRepository>();
            services.AddSingleton<IProductPricesRepository, ProductPricesRepository>();
            services.AddSingleton<IProductsRepository, ProductsRepository>();
            services.AddSingleton<IAgreementsRepository, AgreementsRepository>();
            services.AddSingleton<IOrdersRepository, OrdersRepository>();
        }
    }
}

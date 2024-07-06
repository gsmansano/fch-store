using Lw.FchStore.Application.Services;
using Lw.FchStore.Domain.Interfaces.Services;
using Lw.FchStore.Infra.Data.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lw.FchStore.Application.Builder
{
    public static class LwApplicationBuilder
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfraData(configuration);

            services.AddTransient<IManufacturerAppServices, ManufacturerAppServices>();
            services.AddTransient<IUnitAppServices, UnitAppServices>();
            services.AddTransient<ICategoryAppServices, CategoryAppServices>();
            services.AddTransient<ISupplierAppServices, SupplierAppServices>();
            services.AddTransient<IClientAppServices, ClientAppServices>();
            services.AddTransient<IClientAddressAppServices, ClientAddressAppServices>();
            services.AddTransient<IOrderAppServices, OrderAppServices>();
            services.AddTransient<IOrderItemAppServices, OrderItemAppServices>();
            services.AddTransient<IOrderUpdateAppServices, OrderUpdateAppServices>();
            services.AddTransient<IProductAppServices, ProductAppServices>();

        }
    }
}

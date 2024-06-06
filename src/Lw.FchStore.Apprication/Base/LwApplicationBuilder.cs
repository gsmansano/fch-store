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
        }
    }
}

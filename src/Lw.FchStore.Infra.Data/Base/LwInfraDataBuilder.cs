using Lw.FchStore.Domain.Interfaces.Repositories;
using Lw.FchStore.Infra.Data.Context;
using Lw.FchStore.Infra.Data.Repositoy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lw.FchStore.Infra.Data.Base
{
    public static class LwInfraDataBuilder
    {
        public static void AddInfraData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LwContext>(p => p.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IUnitRepository, UnitRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
        }
    }
}

using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lw.FchStore.Infra.Data.Context
{
    public class LwContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturer { get; set; }

        public LwContext(DbContextOptions<LwContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MapManufacturer());

            base.OnModelCreating(builder);
        }
    }
}

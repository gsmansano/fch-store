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
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ClientAddress> ClientAddress { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderUpdate> OrderUpdate { get; set; }

        public LwContext(DbContextOptions<LwContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MapManufacturer());
            builder.ApplyConfiguration(new MapSupplier());
            builder.ApplyConfiguration(new MapUnit());
            builder.ApplyConfiguration(new MapCategory());
            builder.ApplyConfiguration(new MapClient());
            builder.ApplyConfiguration(new MapClientAddress());
            builder.ApplyConfiguration(new MapOrder());
            builder.ApplyConfiguration(new MapOrderItem());
            builder.ApplyConfiguration(new MapProduct());
            builder.ApplyConfiguration(new MapOrderUpdate());

            base.OnModelCreating(builder);
        }
    }
}

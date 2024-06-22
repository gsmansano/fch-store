using Lw.FchStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lw.FchStore.Infra.Data.Mappings
{
    internal class MapOrder : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.Property(c => c.OrderId).HasColumnType("int").HasColumnName("OrderId").IsRequired();
            builder.Property(c => c.Status).HasColumnType("int").HasColumnName("Status").IsRequired();
            builder.Property(c => c.ClientId).HasColumnType("int").HasColumnName("ClientId").IsRequired();
            builder.Property(c => c.ClientAddressId).HasColumnType("int").HasColumnName("ClientAddressId").IsRequired();
            builder.Property(c => c.PaymentId).HasColumnType("int").HasColumnName("PaymentId").IsRequired();
            builder.Property(c => c.TotalValue).HasColumnType("decimal").HasColumnName("TotalValue");
            builder.Property(c => c.IsActive).HasColumnType("bit").HasColumnName("IsActive");
            builder.Property(c => c.CreatedAt).HasColumnType("datetime").HasColumnName("CreatedAt");
        }
    }
}

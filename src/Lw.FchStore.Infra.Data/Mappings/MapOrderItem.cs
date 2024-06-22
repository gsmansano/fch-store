using Lw.FchStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lw.FchStore.Infra.Data.Mappings
{
    internal class MapOrderItem : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.Property(c => c.OrderItemId).HasColumnType("int").HasColumnName("OrderItemId").IsRequired();
            builder.Property(c => c.ProductId).HasColumnType("int").HasColumnName("ProductId").IsRequired();
            builder.Property(c => c.UnitPrice).HasColumnType("decimal").HasColumnName("UnitPrice");
            builder.Property(c => c.Amount).HasColumnType("decimal").HasColumnName("Amount");

    }
    }

}

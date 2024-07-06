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

            builder.HasKey(oi => oi.OrderItemId);

            builder.Property(oi => oi.OrderItemId)
                .HasColumnType("int")
                .HasColumnName("OrderItemId")
                .IsRequired();

            builder.Property(oi => oi.OrderId)
                .HasColumnType("int")
                .HasColumnName("OrderId")
                .IsRequired();

            builder.Property(oi => oi.ProductId)
                .HasColumnType("int")
                .HasColumnName("ProductId")
                .IsRequired();

            builder.Property(oi => oi.UnitPrice)
                .HasColumnType("decimal(18,2)")
                .HasColumnName("UnitPrice")
                .IsRequired();

            builder.Property(oi => oi.Amount)
                .HasColumnType("decimal(18,3)")
                .HasColumnName("Amount")
                .IsRequired();

            builder.HasOne<Order>(p => p.Order).WithMany(p => p.Items).HasForeignKey(p => p.OrderId);

        }
    }

}

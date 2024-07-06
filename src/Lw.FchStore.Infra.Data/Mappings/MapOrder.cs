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

            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.OrderId)
                .HasColumnType("int")
                .HasColumnName("OrderId")
                .IsRequired();

            builder.Property(o => o.Status)
                .HasColumnType("int")
                .HasColumnName("Status")
                .IsRequired();

            builder.Property(o => o.ClientId)
                .HasColumnType("int")
                .HasColumnName("ClientId")
                .IsRequired();

            builder.Property(o => o.TotalValue)
                .HasColumnType("decimal(18,2)")
                .HasColumnName("TotalValue")
                .IsRequired();

            builder.Property(o => o.ClientAddressId)
                .HasColumnType("int")
                .HasColumnName("ClientAddressId")
                .IsRequired(false);

            builder.Property(o => o.PaymentId)
                .HasColumnType("int")
                .HasColumnName("PaymentId")
                .IsRequired(false);

            builder.Property(o => o.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("CreatedAt")
                .IsRequired();


            builder.HasOne<Client>(p => p.Client).WithMany(p => p.Orders).HasForeignKey(p => p.ClientId);
            builder.HasOne<ClientAddress>(p => p.Address).WithMany(p => p.Orders).HasForeignKey(p => p.ClientAddressId);
            builder.HasMany<OrderItem>(p => p.Items).WithOne(p => p.Order);

        }
    }
}

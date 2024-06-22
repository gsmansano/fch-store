using Lw.FchStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lw.FchStore.Infra.Data.Mappings
{
    internal class MapClientAddress : IEntityTypeConfiguration<ClientAddress>
    {
        public void Configure(EntityTypeBuilder<ClientAddress> builder)
        {
            builder.ToTable("ClientAddress");

            builder.Property(c => c.ClientAddressId).HasColumnType("int").HasColumnName("ClientAddressId").IsRequired();
            builder.Property(c => c.ClientId).HasColumnType("int").HasColumnName("ClientId").IsRequired();
            builder.Property(c => c.FullAddress).HasColumnType("varchar(500)").HasColumnName("FullAddress");
            builder.Property(c => c.City).HasColumnType("varchar(500)").HasColumnName("City");
            builder.Property(c => c.Country).HasColumnType("varchar(500)").HasColumnName("Country");
            builder.Property(c => c.ZipCode).HasColumnType("varchar(500)").HasColumnName("ZipCode");
            builder.Property(c => c.IsActive).HasColumnType("bit").HasColumnName("IsActive");
            builder.Property(c => c.CreatedAt).HasColumnType("datetime").HasColumnName("CreatedAt");

        }
    }
}

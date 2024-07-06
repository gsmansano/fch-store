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

            builder.HasKey(ca => ca.ClientAddressId);

            builder.Property(ca => ca.ClientAddressId)
                .HasColumnType("int")
                .HasColumnName("ClientAddressId")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(ca => ca.ClientId)
                .HasColumnType("int")
                .HasColumnName("ClientId")
                .IsRequired();

            builder.Property(ca => ca.AddressLine1)
                .HasColumnType("varchar(255)")
                .HasColumnName("AddressLine1")
                .IsRequired();

            builder.Property(ca => ca.AddressLine2)
                .HasColumnType("varchar(255)")
                .HasColumnName("AddressLine2")
                .IsRequired(false);

            builder.Property(ca => ca.AddressLine3)
                .HasColumnType("varchar(255)")
                .HasColumnName("AddressLine3")
                .IsRequired(false);

            builder.Property(ca => ca.City)
                .HasColumnType("varchar(100)")
                .HasColumnName("City")
                .IsRequired();

            builder.Property(ca => ca.Country)
                .HasColumnType("varchar(100)")
                .HasColumnName("Country")
                .IsRequired();

            builder.Property(ca => ca.ZipCode)
                .HasColumnType("varchar(20)")
                .HasColumnName("ZipCode")
                .IsRequired();

            builder.Property(ca => ca.IsActive)
                .HasColumnType("bit")
                .HasColumnName("IsActive")
                .IsRequired();

            builder.Property(ca => ca.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("CreatedAt")
                .IsRequired();


            builder.HasOne<Client>(p => p.Client).WithMany(p => p.Addresses).HasForeignKey(p => p.ClientId);

        }
    }
}

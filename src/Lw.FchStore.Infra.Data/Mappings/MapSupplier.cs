using Lw.FchStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.FchStore.Infra.Data.Mappings
{
    internal class MapSupplier : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Supplier");

            builder.HasKey(s => s.SupplierId);

            builder.Property(s => s.SupplierId)
                   .HasColumnType("int")
                   .HasColumnName("SupplierId")
                   .IsRequired();

            builder.Property(s => s.Name)
                   .HasColumnType("varchar(500)")
                   .HasColumnName("Name")
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(s => s.FullAddress)
                   .HasColumnType("varchar(500)")
                   .HasColumnName("FullAddress")
                   .HasMaxLength(500);

            builder.Property(s => s.ZipCode)
                   .HasColumnType("varchar(500)")
                   .HasColumnName("ZipCode")
                   .HasMaxLength(500);

            builder.Property(s => s.ContactName)
                   .HasColumnType("varchar(500)")
                   .HasColumnName("ContactName")
                   .HasMaxLength(500);

            builder.Property(s => s.EmailAddress)
                   .HasColumnType("varchar(500)")
                   .HasColumnName("EmailAddress")
                   .HasMaxLength(500);

            builder.Property(s => s.PhoneNumber)
                   .HasColumnType("varchar(20)")
                   .HasColumnName("PhoneNumber")
                   .HasMaxLength(20);

            builder.Property(s => s.VatNumber)
                   .HasColumnType("varchar(50)")
                   .HasColumnName("VatNumber")
                   .HasMaxLength(50);

            builder.Property(s => s.IsActive)
                   .HasColumnType("bit")
                   .HasColumnName("IsActive")
                   .HasDefaultValue(true);

            builder.Property(s => s.CreatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("CreatedAt")
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}

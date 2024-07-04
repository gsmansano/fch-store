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

            builder.Property(c => c.SupplierId).HasColumnType("int").HasColumnName("SupplierId").IsRequired();
            builder.Property(c => c.Name).HasColumnType("varchar(500)").HasColumnName("Name");
            builder.Property(c => c.FullAddress).HasColumnType("varchar(500)").HasColumnName("FullAddress");
            builder.Property(c => c.ZipCode).HasColumnType("varchar(500)").HasColumnName("ZipCode");
            builder.Property(c => c.ContactName).HasColumnType("varchar(500)").HasColumnName("ContactName");
            builder.Property(c => c.EmailAddress).HasColumnType("varchar(500)").HasColumnName("EmailAddress");
            builder.Property(c => c.PhoneNumber).HasColumnType("int").HasColumnName("PhoneNumber");
            builder.Property(c => c.VatNumber).HasColumnType("varchar(50)").HasColumnName("VatNumber");
            builder.Property(c => c.IsActive).HasColumnType("bit").HasColumnName("IsActive");
            builder.Property(c => c.CreatedAt).HasColumnType("datetime").HasColumnName("CreatedAt");
        }
    }
}

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
    internal class MapManufacturer : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("Manufacturer");

            builder.Property(m => m.ManufacturerId)
                   .HasColumnType("int")
                   .HasColumnName("ManufacturerId")
                   .IsRequired();

            builder.Property(m => m.Name)
                   .HasColumnType("varchar(500)")
                   .HasColumnName("Name")
                   .IsRequired() 
                   .HasMaxLength(500);

            builder.Property(m => m.IsActive)
                   .HasColumnType("bit")
                   .HasColumnName("IsActive")
                   .HasDefaultValue(1)
                   .IsRequired();

            builder.Property(m => m.CreatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("CreatedAt")
        ;
        }
    }
}

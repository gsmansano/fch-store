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
    internal class MapUnit : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Unit");

            builder.HasKey(u => u.UnitId);

            builder.Property(u => u.UnitId)
                .HasColumnType("int")
                .HasColumnName("UnitId")
                .IsRequired();

            builder.Property(u => u.Name)
                .HasColumnType("varchar(255)")
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(u => u.Short)
                .HasColumnType("varchar(50)")
                .HasColumnName("Short")
                .IsRequired();

            builder.Property(u => u.IsActive)
                .HasColumnType("bit")
                .HasColumnName("IsActive")
                .IsRequired();

            builder.Property(u => u.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("CreatedAt")
                .IsRequired();
        }
    }
}

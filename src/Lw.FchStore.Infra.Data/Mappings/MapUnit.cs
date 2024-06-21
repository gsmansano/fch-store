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

            builder.Property(c => c.UnitId).HasColumnType("int").HasColumnName("UnitId").IsRequired();
            builder.Property(c => c.Name).HasColumnType("varchar(500)").HasColumnName("Name");
            builder.Property(c => c.IsActive).HasColumnType("int").HasColumnName("IsActive");
        }
    }
}

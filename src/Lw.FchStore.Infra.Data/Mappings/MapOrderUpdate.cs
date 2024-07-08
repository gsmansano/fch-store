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
    internal class MapOrderUpdate : IEntityTypeConfiguration<OrderUpdate>
    {

        public void Configure(EntityTypeBuilder<OrderUpdate> builder)
        {
            builder.ToTable("OrderUpdate");

            builder.HasKey(ou => ou.OrderUpdateId);

            builder.Property(ou => ou.OrderUpdateId)
                .HasColumnType("int")
                .HasColumnName("OrderUpdateId")
                .IsRequired();

            builder.Property(ou => ou.OrderId)
                .HasColumnType("int")
                .HasColumnName("OrderId")
                .IsRequired();

            builder.Property(ou => ou.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("UpdateTime")
                .IsRequired();

            builder.Property(ou => ou.Description)
                .HasColumnType("varchar(1000)")
                .HasColumnName("Description")
                .IsRequired(false);

            builder.Property(ou => ou.Status)
                .HasColumnType("int")
                .HasColumnName("Status")
                .IsRequired();

        }
    }
}

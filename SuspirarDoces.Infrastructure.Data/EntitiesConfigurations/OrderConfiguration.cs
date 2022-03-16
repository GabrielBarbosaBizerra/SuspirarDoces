using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuspirarDoces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Infrastructure.Data.EntitiesConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.Property(x => x.LocalDeEntrega).HasMaxLength(22);
            builder.Property(x => x.ValorAPagar).HasPrecision(10, 2).IsRequired();
            builder.Property(x => x.ValorDeEntrada).HasPrecision(10, 2).IsRequired();
            builder.Property(x => x.ValorTotal).HasPrecision(10, 2).IsRequired();
        }
    }
}

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
    public class InventoryConfiguration : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.Property(x => x.Nome).HasMaxLength(12);
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.QuantidadeMinima).IsRequired();

        }
    }
}

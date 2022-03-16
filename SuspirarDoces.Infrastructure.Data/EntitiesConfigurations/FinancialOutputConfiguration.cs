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
    public class FinancialOutputConfiguration: IEntityTypeConfiguration<Saida>
    {
        public void Configure(EntityTypeBuilder<Saida> builder)
        {
            builder.Property(x => x.Nome).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Valor).HasPrecision(10, 2);
            builder.Property(x => x.Descricao).HasMaxLength(25);
            builder.Property(x => x.Data).IsRequired();
        }
    }
}

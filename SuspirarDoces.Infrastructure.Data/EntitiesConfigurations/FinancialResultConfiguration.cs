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
    class FinancialResultConfiguration: IEntityTypeConfiguration<Resultado>
    {
        public void Configure(EntityTypeBuilder<Resultado> builder)
        {
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.Entrada).HasPrecision(10, 2);
            builder.Property(x => x.Saida).HasPrecision(10, 2);
            builder.Property(x => x.ResultadoFinanceiro).HasPrecision(10, 2);
        }
    }
}

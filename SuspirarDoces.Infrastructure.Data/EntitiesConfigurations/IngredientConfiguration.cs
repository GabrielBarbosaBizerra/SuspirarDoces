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
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingrediente>
    {
        public void Configure(EntityTypeBuilder<Ingrediente> builder)
        {
            builder.Property(x => x.QuantidadeOvos);
            builder.Property(x => x.QuantidadeAcucar);
            builder.Property(x => x.QuantidadeGlacucar);

            builder.HasData(
                new Ingrediente
                {
                    Id = 1,
                    QuantidadeOvos = 4,
                    QuantidadeAcucar = 350,
                    QuantidadeGlacucar = 150
                });
        }
    }
}

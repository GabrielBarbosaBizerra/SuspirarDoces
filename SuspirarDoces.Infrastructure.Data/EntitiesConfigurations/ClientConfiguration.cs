using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuspirarDoces.Domain.Entities;


namespace SuspirarDoces.Infrastructure.Data.EntitiesConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(x => x.CPF).HasMaxLength(11);
            builder.Property(x => x.Nome).HasMaxLength(23).IsRequired();
            builder.Property(x => x.Telefone).HasMaxLength(11);
            builder.Property(x => x.Cidade).HasMaxLength(17);
        }
    }
}

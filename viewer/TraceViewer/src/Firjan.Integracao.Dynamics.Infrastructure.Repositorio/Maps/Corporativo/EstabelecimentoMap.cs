using Microsoft.EntityFrameworkCore;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo
{
    public class EstabelecimentoMap : IEntityTypeConfiguration<Estabelecimento>
    {
        public void Configure(EntityTypeBuilder<Estabelecimento> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("ch_cd_IdEstabelecimento")
               .IsRequired();

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_ds_Nome");

            builder
                .ToTable("Estabelecimento");
        }
    }
}
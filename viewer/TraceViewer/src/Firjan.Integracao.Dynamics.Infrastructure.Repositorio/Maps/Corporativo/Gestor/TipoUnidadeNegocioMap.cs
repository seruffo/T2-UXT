using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class TipoUnidadeNegocioMap : IEntityTypeConfiguration<TipoUnidadeNegocio>
    {
        public void Configure(EntityTypeBuilder<TipoUnidadeNegocio> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("si_sq_tipounidade")
               .IsRequired();

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_ds_tipounidade");

            builder
               .Property(e => e.Sigla)
               .HasColumnName("vc_sg_tipounidade");

            builder
              .Property(e => e.UnidadeVinculada)
              .HasColumnName("ch_fg_unidadevinculada")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (UnidadeVinculada)Enums<char?>.Parse<UnidadeVinculada>(v))
              .IsUnicode(false);

            builder
                .ToTable("TipoUnidadeNegocio");
        }
    }
}

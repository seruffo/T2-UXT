using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class TipoServicoMap : IEntityTypeConfiguration<Domain.Models.Corporativo.Gestor.TipoServico>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Corporativo.Gestor.TipoServico> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("ch_ql_servoficial")
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsRequired(true);

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_ds_tiposervicooficial")
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .IsRequired(true);

            builder
              .Property(e => e.Sigla)
              .HasColumnName("ch_sg_tiposervicooficial")
              .HasColumnType("char")
              .HasMaxLength(3)
              .IsRequired(true);

            builder
              .Property(e => e.ObrigaArea)
              .HasColumnName("ch_fg_obriga_area_tiposervicooficial")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (ObrigaArea)Enums<char?>.Parse<ObrigaArea>(v))
              .IsUnicode(false);


            builder
              .Property(e => e.ObrigaCusto)
              .HasColumnName("ch_fg_obriga_custo_tiposervicooficial")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (ObrigaCusto)Enums<char?>.Parse<ObrigaCusto>(v))
              .IsUnicode(false);


            builder
                .ToTable("TipoServicoOficial");
        }
    }
}
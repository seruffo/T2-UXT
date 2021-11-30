using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class TipoUnidadeNegocioTipoEntidadeVinculoMap : IEntityTypeConfiguration<TipoUnidadeNegocioTipoEntidadeVinculo>
    {
        public void Configure(EntityTypeBuilder<TipoUnidadeNegocioTipoEntidadeVinculo> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("si_sq_tpunnegtpentvinc")
               .HasColumnType("smallint")
               .HasMaxLength(2)
               .IsRequired(true);

            builder
                .Ignore(r => r.Descricao);

            builder
                 .Property(e => e.TipoEntidadeVinculoId)
                 .HasColumnName("ch_tp_entidade_vinculo")
                 .HasMaxLength(2)
                 .IsRequired(true);

            builder.HasOne(a => a.TipoEntidadeVinculo)
                  .WithMany()
                  .HasForeignKey(s => s.TipoEntidadeVinculoId)
                  .IsRequired();

            builder
                 .Property(e => e.TipoUnidadeNegocioId)
                 .HasColumnName("si_sq_tipounidade")
                 .HasColumnType("smallint")
                 .HasMaxLength(2)
                 .IsRequired(true);

            builder.HasOne(a => a.TipoUnidadeNegocio)
                  .WithMany()
                  .HasForeignKey(s => s.TipoUnidadeNegocioId)
                  .IsRequired();

            builder
                .ToTable("TpUnNegTpEntVinc");
        }
    }
}
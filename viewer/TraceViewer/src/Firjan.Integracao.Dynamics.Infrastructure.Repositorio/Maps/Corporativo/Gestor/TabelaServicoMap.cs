using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class TabelaServicoMap : IEntityTypeConfiguration<TabelaServico>
    {
        public void Configure(EntityTypeBuilder<TabelaServico> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("si_sq_tabservico")
               .HasColumnType("smallint")
               .HasMaxLength(2)
               .IsRequired(true);

            builder
                .HasKey(e => e.Id);

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_ds_tabservico")
              .HasColumnType("varchar")
              .HasMaxLength(60)
              .IsRequired(true);


            builder
              .Property(e => e.CodigoTipoEntidadeVinculo)
              .HasColumnName("ch_tp_entidade_vinculo")
              .IsRequired(true);

            builder
              .HasOne(a => a.TipoEntidadeVinculo)
              .WithMany()
              .HasForeignKey(s => s.CodigoTipoEntidadeVinculo);

            builder
              .Property(e => e.IsAtendimento)
              .HasColumnName("ch_fg_atendimento_tabservico")
              .HasColumnType("char(1)")
              .HasMaxLength(1);

            builder
              .Property(e => e.TipoPreco)
              .HasColumnName("ch_ql_tppreco_tabservico")
              .HasColumnType("char(1)")
              .HasMaxLength(1);

            builder
                .ToTable("TabelaServico");
        }
    }
}
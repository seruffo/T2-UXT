using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class TabelaServicoTipoEntidadeVinculoMap : IEntityTypeConfiguration<TabelaServicoTipoEntidadeVinculo>
    {
        public void Configure(EntityTypeBuilder<TabelaServicoTipoEntidadeVinculo> builder)
        {
            builder
               .Property(e => e.CodigoTipoServico)
               .HasColumnName("ch_ql_servoficial")
               .HasColumnType("char")
               .HasMaxLength(1);

            builder
              .HasOne(a => a.TipoServico)
              .WithMany()
              .HasForeignKey(s => s.CodigoTipoServico)
              .IsRequired();


            builder
               .Property(e => e.ProdutoId)
               .HasColumnName("in_sq_classifservofic")
               .HasColumnType("int")
               .HasMaxLength(4);

            builder
                .HasKey(e => new { e.ProdutoId , e.GrupoClassificacaoId, e.CodigoTipoServico});

            builder
              .HasOne(a => a.Produto)
              .WithMany()
              .HasForeignKey(s => s.ProdutoId)
              .IsRequired();

            builder
               .Property(e => e.GrupoClassificacaoId)
               .HasColumnName("in_sq_grupoclassif")
               .HasColumnType("int")
               .HasMaxLength(4);

            builder
              .HasOne(a => a.GrupoClassificacao)
              .WithMany()
              .HasForeignKey(s => s.GrupoClassificacaoId)
              .IsRequired();

            builder
              .Property(e => e.GrupoClassificacaoPaiId)
              .HasColumnName("in_sq_pai_grupoclassif")
              .HasColumnType("int")
              .HasMaxLength(4);

            builder
              .HasOne(a => a.GrupoClassificacaoPai)
              .WithMany()
              .HasForeignKey(s => s.GrupoClassificacaoPaiId)
              .IsRequired();

            builder
               .Ignore(b => b.Id);

            builder
                .Ignore(b => b.Descricao);

            builder
                .ToTable("SPTabelaServicoTpEntCons");
        }
    }
}
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class GrupoClassificacaoMap : IEntityTypeConfiguration<GrupoClassificacao>
    {
        public void Configure(EntityTypeBuilder<GrupoClassificacao> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("in_sq_grupoclassif")
               .HasColumnType("int")
               .HasMaxLength(4)
               .IsRequired(true);

            builder
              .HasKey(b => b.Id);

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_ds_apelido_grupoclassif")
              .HasColumnType("varchar(100)")
              .HasMaxLength(100);

            builder
              .Property(e => e.Nome)
              .HasColumnName("vc_nm_grupoclassif")
              .HasColumnType("varchar(100)")
              .HasMaxLength(100);

            builder
              .Property(e => e.NovaInterface)
              .HasColumnName("bi_fg_novainterface_grupoclassif")
              .HasColumnType("bit")
              .HasMaxLength(1);

            builder
              .Property(e => e.TipoServicoId)
              .HasColumnName("ch_ql_servoficial_grupoclassif")
              .HasColumnType("char(1)");

            builder
              .HasOne(a => a.TipoServico)
              .WithMany()
              .HasForeignKey(s => s.TipoServicoId);

            builder
              .Property(e => e.NumeroOrdem)
              .HasColumnName("vc_nr_ordem_grupoclassif")
              .HasColumnType("varchar")
              .HasMaxLength(30);

            builder
            .Property(e => e.Fim)
            .HasColumnName("sd_dt_fim_grupoclassif")
            .HasColumnType("datetime");

            builder
              .Property(e => e.NivelServico)
              .HasColumnName("ti_nr_nivelgrupo")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (NivelGrupo)Enums<byte?>.Parse<NivelGrupo>(v))
              .IsUnicode(false);

            builder
               .Property(e => e.PrimeiroNivelServico)
               .HasColumnName("bi_fg_primeironivel_grupoclassif");

            builder
              .Property(e => e.IndicadorProduto)
              .HasColumnName("ch_fg_indicadorproduto_grupoclassif")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (IndicadorProduto)Enums<char?>.Parse<IndicadorProduto>(v))
              .IsUnicode(false);

            builder
               .Property(e => e.CodigoTipoEntidadeVinculo)
               .HasColumnName("ch_tp_entidade_vinculo");

            builder
              .HasOne(a => a.TipoEntidadeVinculo)
              .WithMany()
              .HasForeignKey(s => s.CodigoTipoEntidadeVinculo);

            builder
               .Property(e => e.GrupoClassificacaoPaiId)
               .HasColumnName("in_sq_pai_grupoclassif");

            builder
              .HasOne(a => a.GrupoClassificacaoPai)
              .WithMany()
              .HasForeignKey(s => s.GrupoClassificacaoPaiId);

            builder
               .Property(e => e.CodigoTipoEntidadeVinculo)
               .HasColumnName("ch_tp_entidade_vinculo");

            builder
                .Ignore(t => t.GruposClassificacoes);

            builder
                .Ignore(t => t.Logon);

            builder
                .ToTable("GrupoClassif");
        }
    }
}
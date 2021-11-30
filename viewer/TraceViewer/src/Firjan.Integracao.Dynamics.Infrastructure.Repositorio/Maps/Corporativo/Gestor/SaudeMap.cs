using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class SaudeMap : IEntityTypeConfiguration<Domain.Models.Corporativo.Gestor.Saude>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Corporativo.Gestor.Saude> builder)
        {
            builder
                .Property(e => e.ProdutoId)
                .HasColumnName("in_sq_classifservofic_saude")
                .HasColumnType("int");

            builder
                .HasKey(t => t.ProdutoId );

            builder
              .HasOne(a => a.Produto)
              .WithMany()
              .HasForeignKey(s => s.ProdutoId);

            builder
              .Property(e => e.TipoProcedimento)
              .HasColumnName("ch_fg_tpproc_saude")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoProcedimento)Enums<char?>.Parse<TipoProcedimento>(v))
              .IsUnicode(false);

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_ds_servoficial_saude")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Ignore(r => r.TipoFicha);

            builder
              .Property(e => e.TipoServicoSaude)
              .HasColumnName("ch_fg_tpserv_saude")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoServicoSaude)Enums<char?>.Parse<TipoServicoSaude>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.Exame)
              .HasColumnName("ch_fg_exame_saude")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Exame)Enums<char?>.Parse<Exame>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.TipoResultado)
              .HasColumnName("ch_fg_tiporesultado_saude")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoResultado)Enums<decimal>.Parse<TipoResultado>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.OrigemSaude)
              .HasColumnName("ch_cd_origem_saude")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (OrigemSaude)Enums<char?>.Parse<OrigemSaude>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.TipoOrigemServico)
              .HasColumnName("ch_tp_origemocup_saude")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoOrigemServico)Enums<char?>.Parse<TipoOrigemServico>(v))
              .IsUnicode(false);

            builder
             .Property(e => e.ClassificacaoExameId)
             .HasColumnName("si_sq_classifexame")
             .HasDefaultValue(null)
             .HasColumnType("smallint");

            builder
              .HasOne(a => a.ClassificacaoExame)
              .WithMany()
              .HasForeignKey(s => s.ClassificacaoExameId);

            builder
              .Property(e => e.TipoClassificacao)
              .HasColumnName("ch_fg_tpClassif_saude")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoClassificacao)Enums<char?>.Parse<TipoClassificacao>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.TipoServicoOdontologico)
              .HasColumnName("ch_tp_ServOdonto_Saude")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoServicoOdontologico)Enums<char?>.Parse<TipoServicoOdontologico>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.QtdDentesEnvolvidos)
              .HasColumnName("ti_qt_DentesEnvolvidos_saude")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (QtdDentesEnvolvidos)Enums<byte>.Parse<QtdDentesEnvolvidos>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.GuiaCobrancaSemPFO)
              .HasColumnName("ch_fg_proptratpto_valido_saude")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (GuiaCobrancaSemPFO)Enums<char?>.Parse<GuiaCobrancaSemPFO>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.GrupoClassificacaoId)
              .HasColumnName("in_sq_grupoclassif")
              .HasColumnType("int");

            builder
              .HasOne(a => a.GrupoClassificacao)
              .WithMany()
              .HasForeignKey(s => s.GrupoClassificacaoId);

            builder
                .Property(e => e.CodigoServico)
                .HasColumnName("vc_cd_classifservofic_saude")
                .HasDefaultValue(null)
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder
                .Property(e => e.Estado)
                .HasColumnName("ch_fg_estado_classifservofic_saude")
                .HasMaxLength(1)
                .HasConversion(
                    v => v.Id,
                    v => (Estado)Enums<char?>.Parse<Estado>(v))
                .IsUnicode(false);

            builder
                .Property(e => e.Fim)
                .HasColumnName("sd_dt_fim_classifservofic_saude")
                .HasDefaultValue(null)
                .HasColumnType("smalldatetime")
                .HasMaxLength(4);

            builder
                .Property(e => e.Aprovacao)
                .HasColumnName("sd_dt_aprovacao_classifservofic_saude")
                .HasDefaultValue(null)
                .HasColumnType("smalldatetime")
                .HasMaxLength(4);

            builder
                .Property(e => e.CodigoFirjan)
                .HasColumnName("ch_cd_firjansaude_saude")
                .HasDefaultValue(null)
                .HasColumnType("varchar")
                .HasMaxLength(9);

            builder
                .Property(e => e.ProcedimentoPrepartorio)
                .HasColumnName("vc_ds_procprep_servoficial_saude")
                .HasDefaultValue(null)
                .HasColumnType("varchar")
                .HasMaxLength(8000);

            builder
                .Property(e => e.MarcarHora)
                .HasColumnName("ch_fg_marcahr_saude")
                .HasMaxLength(1)
                .HasConversion(
                    v => v.Id,
                    v => (MarcarHora)Enums<char?>.Parse<MarcarHora>(v))
                .IsUnicode(false);

            builder
                .Property(e => e.TempoAtendimento)
                .HasColumnName("sd_hr_tempoatend_saude")
                .HasDefaultValue(null)
                .HasColumnType("smalldatetime")
                .HasMaxLength(4);

            builder
                .Property(e => e.Quantificavel)
                .HasColumnName("ch_fg_quantificavel_saude")
                .HasMaxLength(1)
                .HasConversion(
                    v => v.Id,
                    v => (Quantificavel)Enums<char?>.Parse<Quantificavel>(v))
                .IsUnicode(false);

            builder
              .Property(e => e.Autorizacao)
              .HasColumnName("bi_fg_autorizacaoFS_saude")
              .HasColumnType("bit")
              .HasMaxLength(1);

            builder
              .Property(e => e.AgendaTeleatendimento)
              .HasColumnName("bi_fg_agendaTeleAtend_saude")
              .HasColumnType("bit")
              .HasMaxLength(1);

            builder
                .Property(e => e.DisponivelAgendamento)
                .HasColumnName("ch_fg_marcahr_saude")
                .HasMaxLength(1)
                .HasConversion(
                    v => v.Id,
                    v => (Flag)Enums<char?>.Parse<Flag>(v))
                .IsUnicode(false);

            builder
                .ToTable("Saude");
        }
    }
}

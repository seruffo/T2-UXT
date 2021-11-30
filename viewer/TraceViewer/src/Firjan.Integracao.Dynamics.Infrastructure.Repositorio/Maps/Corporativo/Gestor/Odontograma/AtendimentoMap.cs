using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class AtendimentoMap : IEntityTypeConfiguration<Domain.Models.Corporativo.Gestor.Odontograma.Atendimento>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Corporativo.Gestor.Odontograma.Atendimento> builder)
        {

            builder
               .Property(e => e.Id)
               .HasColumnName("ch_nr_atendimento")
               .IsRequired(true);
            
            builder
                .HasKey(s => new { s.Id });

            builder
                .Ignore(e => e.Descricao);

            builder
               .Property(e => e.Data)
               .HasColumnName("sd_dt_atendimento")
               .HasColumnType("smalldatetime")
               .HasMaxLength(4)
               .IsRequired(true);

            builder
               .Property(e => e.Numero)
               .HasColumnName("si_nr_atendimento")
               .HasColumnType("smallint")
               .HasMaxLength(4)
               .IsRequired(true);

            builder
               .Property(e => e.ColaboradorAtendeId)
               .HasColumnName("in_sq_colab_atende")
               .HasColumnType("int")
               .HasMaxLength(4);

            builder
              .HasOne(a => a.ColaboradorAtende)
              .WithMany()
              .HasForeignKey(s => s.ColaboradorAtendeId);

            builder
               .Property(e => e.InicioColaborador)
               .HasColumnName("sd_dt_inicio_colaborador")
               .HasColumnType("smalldatetime")
               .HasMaxLength(4);

            builder
                .Property(e => e.TipoFichaId)
                .HasColumnName("in_sq_tpregatend")
                .HasColumnType("int")
                .IsRequired(true);

            builder
              .HasOne(a => a.TipoFicha)
              .WithMany()
              .HasForeignKey(s => s.TipoFichaId);

            builder
                .Property(e => e.UnidadeNegocioRegistraId)
                .HasColumnName("si_sq_unidnegocio_registra")
                .HasColumnType("smallint");

            builder
              .HasOne(a => a.UnidadeNegocioRegistra)
              .WithMany()
              .HasForeignKey(s => s.UnidadeNegocioRegistraId);

            builder
              .Property(e => e.Situacao)
              .HasColumnName("ch_cd_situacao_atendimento")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (SituacaoAtendimento)Enums<char?>.Parse<SituacaoAtendimento>(v))
              .IsUnicode(false)
              .IsRequired(true);
            
            builder
                .Property(e => e.Geracao)
                .HasColumnName("sd_dt_geracao_atendimento")
                .HasColumnType("smalldatetime")
                .IsRequired(true);

            builder
              .Property(e => e.TipoAtendimento)
              .HasColumnName("ch_ql_atendimento")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Domain.Models.Corporativo.Gestor.Tipos.TipoAtendimento)Enums<char?>.Parse<Domain.Models.Corporativo.Gestor.Tipos.TipoAtendimento>(v))
              .IsUnicode(false)
              .IsRequired(true);

            builder
              .Property(e => e.TipoSerieAtendimento)
              .HasColumnName("ch_tp_indicserie_atendimento")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoSerieAtendimento)Enums<char?>.Parse<TipoSerieAtendimento>(v))
              .IsUnicode(false)
              .IsRequired(true);

            builder
                .Property(e => e.UnidadeNegocioRecebeId)
                .HasColumnName("si_sq_unidnegocio_recebe")
                .HasColumnType("smallint");

            builder
              .HasOne(a => a.UnidadeNegocioRecebe)
              .WithMany()
              .HasForeignKey(s => s.UnidadeNegocioRecebeId);

            builder
                .Property(e => e.EntidadePrestadoraId)
                .HasColumnName("in_sq_entidade_prestadora")
                .HasColumnType("int");

            builder
                .Property(e => e.EntidadeAtendidaId)
                .HasColumnName("in_sq_entidade_atendida")
                .HasColumnType("int");

            builder
                .Property(e => e.Digitacao)
                .HasColumnName("sd_dt_digitacao_atendimento")
                .HasColumnType("smalldatetime");

            builder
                .Property(e => e.Pagamento)
                .HasColumnName("sd_dt_pgto_atendimento")
                .HasColumnType("smalldatetime");

            builder
              .Property(e => e.Assistencial)
              .HasColumnName("ch_fg_assistencial_atendimento")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Assistencial)Enums<char?>.Parse<Assistencial>(v))
              .IsUnicode(false);

            builder
               .Property(e => e.PessoaId)
               .HasColumnName("in_sq_pessoa")
               .HasColumnType("int")
               .HasMaxLength(4)
               .IsRequired(true);

            builder
              .HasOne(a => a.Pessoa)
              .WithMany()
              .HasForeignKey(s => s.PessoaId);

            builder
              .Property(e => e.QualificadorBeneficiario)
              .HasColumnName("ch_ql_beneficiario")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoRegimento)Enums<char?>.Parse<TipoRegimento>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.TipoBeneficiario)
              .HasColumnName("ch_tp_beneficiario")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoBeneficiario)Enums<char?>.Parse<TipoBeneficiario>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.TipoConvenio)
              .HasColumnName("ch_tp_conv_atendimento")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoConvenio)Enums<char?>.Parse<TipoConvenio>(v))
              .IsUnicode(false);

            builder
                .Property(e => e.ColaboradorResponsavelId)
                .HasColumnName("in_sq_colab_resp")
                .HasColumnType("int");

            builder
              .HasOne(a => a.ColaboradorResponsavel)
              .WithMany()
              .HasForeignKey(s => s.ColaboradorResponsavelId);

            builder
                .Property(e => e.InicioColaboradorResponsavel)
                .HasColumnName("sd_dt_inicio_colab_resp")
                .HasColumnType("smalldatetime");

            builder
              .Property(e => e.SubTipoAtendimento)
              .HasColumnName("ch_ql_subtipo_atendimento")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (SubTipoAtendimento)Enums<char?>.Parse<SubTipoAtendimento>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.StatusSede)
              .HasColumnName("ch_cd_statussede_atendimento")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (StatusSede)Enums<char?>.Parse<StatusSede>(v))
              .IsUnicode(false);

            builder
                .Property(e => e.MudancaSede)
                .HasColumnName("sd_dt_mudancasede_atendimento")
                .HasColumnType("smalldatetime");

            builder
              .Property(e => e.MarcadoAtendimento)
              .HasColumnName("ch_fg_marcado_atendimento")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (MarcadoAtendimento)Enums<char?>.Parse<MarcadoAtendimento>(v))
              .IsUnicode(false);

            builder
                .Property(e => e.NumeroBoleto)
                .HasColumnName("ch_nr_boleto_atendimento")
                .HasColumnType("char")
                .HasMaxLength(10);

            builder
                .Property(e => e.JustificativaFaltaProfissionalAtendimento)
                .HasColumnName("vc_ds_motivofaltaprof_atendimento")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder
              .Property(e => e.TipoUtilizacao)
              .HasColumnName("ch_tp_utiliz_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoUtilizacao)Enums<char?>.Parse<TipoUtilizacao>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.Deficiencia)
              .HasColumnName("ch_fg_deficiencia_atendimento")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Deficiencia)Enums<char?>.Parse<Deficiencia>(v))
              .IsUnicode(false);

            builder
                .Property(e => e.UnidadeNegocioEmitenteId)
                .HasColumnName("si_sq_unidnegocio_emitente")
                .HasColumnType("smallint");

            builder
              .HasOne(a => a.UnidadeNegocioEmitente)
              .WithMany()
              .HasForeignKey(s => s.UnidadeNegocioEmitenteId);

            builder
              .Property(e => e.TipoLocal)
              .HasColumnName("ch_tp_local_atendimento")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoLocal)Enums<char?>.Parse<TipoLocal>(v))
              .IsUnicode(false);

            builder
                .Property(e => e.AtendimentorelacionadoId)
                .HasColumnName("ch_nr_atendimento_relacionado")
                .HasColumnType("char")
                .HasMaxLength(15);

            builder
              .HasOne(a => a.Atendimentorelacionado)
              .WithOne()
              .HasForeignKey<Domain.Models.Corporativo.Gestor.Odontograma.Atendimento>(s => s.AtendimentorelacionadoId);

            builder
              .Property(e => e.AptoAltura)
              .HasColumnName("bi_fg_aptoaltura_atendimento")
              .HasColumnType("bit")
              .HasMaxLength(1);

            builder
              .Property(e => e.AptoConfinamento)
              .HasColumnName("bi_fg_aptoconfinamento_atendimento")
              .HasColumnType("bit")
              .HasMaxLength(1);

            builder
                .Property(e => e.UnidadeNegocioContratoId)
                .HasColumnName("si_sq_unidnegocio_contrato")
                .HasColumnType("smallint");

            builder
              .HasOne(a => a.UnidadeNegocioContrato)
              .WithMany()
              .HasForeignKey(s => s.UnidadeNegocioContratoId);

            builder
                .Property(e => e.ContratoId)
                .HasColumnName("in_sq_contrato")
                .HasColumnType("int");

            builder
              .HasOne(a => a.Contrato)
              .WithMany()
              .HasForeignKey(s => new { s.ContratoId, s.UnidadeNegocioContratoId });

            builder
               .Property(e => e.MudancaSede)
               .HasColumnName("sd_dt_mudancasede_atendimento")
               .HasColumnType("smalldatetime")
               .HasMaxLength(4);

            builder
                .ToTable("Atendimento");
        }
    }
}
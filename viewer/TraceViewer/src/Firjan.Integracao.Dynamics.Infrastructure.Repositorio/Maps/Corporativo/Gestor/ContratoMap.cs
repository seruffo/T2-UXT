using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class ContratoMap : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("in_sq_contrato")
               .HasColumnType("int")
               .HasMaxLength(4)
               .IsRequired(true);

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_ds_objeto_contrato")
              .HasColumnType("varchar")
              .HasMaxLength(255)
              .IsRequired(true);


            builder
                .HasKey(e => new { e.Id, e.UnidadeNegocioId });

            builder
              .Property(e => e.UnidadeNegocioId)
              .HasColumnName("si_sq_unidnegocio_contrato")
              .IsRequired(true);

            builder
              .HasOne(a => a.UnidadeNegocio)
              .WithMany()
              .HasForeignKey(s => s.UnidadeNegocioId)
              .IsRequired();

            builder
              .Property(e => e.TipoContratoId)
              .HasColumnName("si_sq_tipocontrato")
              .IsRequired(true);

            builder
              .HasOne(a => a.TipoContrato)
              .WithMany()
              .HasForeignKey(s => s.TipoContratoId)
              .IsRequired();

            builder
              .Property(e => e.Numero)
              .HasColumnName("vc_nr_contrato")
              .HasColumnType("varchar")
              .HasMaxLength(15);

            builder
              .Property(e => e.Assinatura)
              .HasColumnName("sd_dt_assinatura_contrato")
              .HasColumnType("smalldatetime")
              .HasMaxLength(4);

            builder
              .Property(e => e.Vigencia)
              .HasColumnName("sd_dt_vigencia_contrato")
              .HasColumnType("smalldatetime")
              .HasMaxLength(4);

            builder
              .Property(e => e.Cancelamento)
              .HasColumnName("sd_dt_canc_contrato")
              .HasColumnType("smalldatetime")
              .HasMaxLength(4);
            

            builder
              .Property(e => e.Final)
              .HasColumnName("sd_dt_final_contrato")
              .HasColumnType("smalldatetime")
              .HasMaxLength(4);

            builder
              .Property(e => e.TipoPessoa)
              .HasColumnName("ch_ql_contrato")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoPessoa)Enums<char?>.Parse<TipoPessoa>(v))
              .IsUnicode(false)
              .IsRequired(true);

            builder
              .Property(e => e.TodasUnidadesNegocios)
              .HasColumnName("ch_fg_todosunidneg_contrato")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TodasUnidadesNegocios)Enums<char?>.Parse<TodasUnidadesNegocios>(v))
              .IsUnicode(false)
              .IsRequired(true);

            builder
              .Property(e => e.TodasPessoas)
              .HasColumnName("ch_fg_todospess_contrato")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TodasPessoas)Enums<char?>.Parse<TodasPessoas>(v))
              .IsUnicode(false)
              .IsRequired(true);

            builder
              .Property(e => e.TodosServicos)
              .HasColumnName("ch_fg_todosservico_contrato")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TodosServicos)Enums<char?>.Parse<TodosServicos>(v))
              .IsUnicode(false)
              .IsRequired(true);

            builder
              .Property(e => e.TipoCNI)
              .HasColumnName("ch_fg_tipo_cni_contrato")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoCNI)Enums<char?>.Parse<TipoCNI>(v))
              .IsUnicode(false)
              .IsRequired(true);

            builder
              .Property(e => e.NumeroTermo)
              .HasColumnName("vc_nr_termo_contrato")
              .HasColumnType("varchar")
              .HasMaxLength(11);

            builder
              .Property(e => e.Inicio)
              .HasColumnName("sd_dt_inc_contrato")
              .HasColumnType("smalldatetime")
              .HasMaxLength(4);

            builder
              .Property(e => e.Alteracao)
              .HasColumnName("sd_dt_alt_contrato")
              .HasColumnType("smalldatetime")
              .HasMaxLength(4);

            builder
              .Property(e => e.NumeroUltimaNegociacao)
              .HasColumnName("in_nr_ult_negociacao")
              .HasColumnType("int");

            builder
              .Property(e => e.UnidadeNegocioExecutoraUltimaNegociacaoId)
              .HasColumnName("si_sq_unidneg_exec_ult_renegociacao")
              .HasColumnType("int");

            builder
              .HasOne(a => a.UnidadeNegocioExecutoraUltimaNegociacao)
              .WithMany()
              .HasForeignKey(s => s.UnidadeNegocioExecutoraUltimaNegociacaoId)
              .IsRequired();

            builder
              .Property(e => e.NumeroUltimaSituacaoCobranca)
              .HasColumnName("in_nr_ult_sitcobr")
              .HasColumnType("int");

            builder
              .Property(e => e.UnidadeNegocioUltimaSituacaoCobrancaId)
              .HasColumnName("si_sq_unidnegocio_orig_ult_sitcobr")
              .HasColumnType("int");

            builder
              .HasOne(a => a.UnidadeNegocioUltimaSituacaoCobranca)
              .WithMany()
              .HasForeignKey(s => s.UnidadeNegocioUltimaSituacaoCobrancaId)
              .IsRequired();

            builder
              .Property(e => e.NumeroUltimoAditivoContrato)
              .HasColumnName("vc_nr_ult_aditivo")
              .HasColumnType("varchar")
              .HasMaxLength(15);

            builder
                .ToTable("Contrato");
        }
    }
}
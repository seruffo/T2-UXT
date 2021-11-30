using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class ModuloVersaoMap : IEntityTypeConfiguration<ModuloVersao>
    {
        public void Configure(EntityTypeBuilder<ModuloVersao> builder)
        {
            builder
               .Property(e => e.Codigo)
               .HasColumnName("ch_cd_modulo")
               .HasColumnType("char")
               .HasMaxLength(5)
               .IsRequired(true);

            builder
                 .HasKey(s => new { s.Codigo, s.NumeroVersao });
  
            builder
              .Property(e => e.NumeroVersao)
              .HasColumnType("char")
              .HasColumnName("ch_nr_moduloversao")
              .IsRequired(true)
              .HasMaxLength(2);

            builder
               .Property(e => e.QtdHoras)
               .HasColumnType("smallint")
               .HasColumnName("si_qt_horas_moduloversao")
               .HasMaxLength(2);

            builder
               .Property(e => e.QtddDias)
               .HasColumnType("smallint")
               .HasColumnName("si_qt_dias_moduloversao")
               .HasMaxLength(2);

            builder
               .Property(e => e.Fim)
               .HasColumnType("datetime")
               .HasColumnName("sd_dt_fim_moduloversao");

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_ds_conteudo_moduloversao")
              .HasColumnType("varchar")
              .HasMaxLength(100);

            builder
              .Property(e => e.ProdutoId)
              .HasColumnName("in_sq_classifservofic_moduloversao")
              .HasColumnType("int")
              .HasMaxLength(4);

            builder
              .HasOne(a => a.Produto)
              .WithMany()
              .HasForeignKey(s => s.ProdutoId)
              .IsRequired();

            builder
              .Property(e => e.TipoModalidadeId)
              .HasColumnName("si_sq_tipomodal")
              .HasColumnType("smallint")
              .HasMaxLength(2);

            builder
              .HasOne(a => a.TipoModalidade)
              .WithMany()
              .HasForeignKey(s => s.TipoModalidadeId)
              .IsRequired();

            builder
              .Property(e => e.CodigoInstrucao)
              .HasColumnName("ch_cd_instrucao")
              .HasColumnType("char")
              .HasMaxLength(2);

            builder
              .HasOne(a => a.Instrucao)
              .WithMany()
              .HasForeignKey(s => s.CodigoInstrucao)
              .IsRequired();

            builder
              .Property(e => e.QtdHorasEstagio)
              .HasColumnName("si_qt_horasEstag_modversao")
              .HasColumnType("smallint")
              .HasMaxLength(2);

            builder
              .Property(e => e.TipoModulo)
              .HasColumnName("ch_fg_tipo_modulo")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoModulo)Enums<char?>.Parse<TipoModulo>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.GeraNumeroCertificado)
              .HasColumnName("ch_fg_geranum_certificado")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (GeraNumeroCertificado)Enums<char?>.Parse<GeraNumeroCertificado>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.ContemDisciplina)
              .HasColumnName("ch_fg_contem_disciplina")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (ContemDisciplina)Enums<char?>.Parse<ContemDisciplina>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.RefazCurso)
              .HasColumnName("ch_fg_contem_disciplina")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (RefazCurso)Enums<char?>.Parse<RefazCurso>(v))
              .IsUnicode(false);
              
            builder
              .Property(e => e.PortifolioEducacaoId)
              .HasColumnName("in_sq_portifolioeducacao")
              .HasColumnType("int")
              .HasMaxLength(4);

            builder.HasOne(a => a.PortifolioEducacao)
              .WithMany()
              .HasForeignKey(s => s.PortifolioEducacaoId);

            builder
              .Property(e => e.FlagProcessoSeletivo)
              .HasColumnName("bi_fg_processoseletivo_moduloversao")
              .HasColumnType("bit")
              .HasMaxLength(1);

            builder
              .Property(e => e.CustoSistema)
              .HasColumnName("ch_fg_custosistema_moduloversao")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (CustoSistema)Enums<char?>.Parse<CustoSistema>(v))
              .IsUnicode(false);

            builder
              .Ignore(a => a.IdadeMinimaEducacao);

            builder
              .Ignore(a => a.IdadeMaximaEducacao);

            builder
              .Property(e => e.Nome)
              .HasColumnName("vc_nm_moduloversao")
              .HasColumnType("varchar")
              .HasMaxLength(100);

            builder
              .Property(e => e.NomeResumido)
              .HasColumnName("vc_nm_resumido_moduloversao")
              .HasColumnType("varchar")
              .HasMaxLength(100);

            builder
               .Property(e => e.Inicio)
               .HasColumnType("datetime")
               .HasColumnName("sd_dt_ini_moduloversao");

            builder
              .Property(e => e.Missao)
              .HasColumnName("vc_ds_missao_moduloversao")
              .HasColumnType("varchar")
              .HasMaxLength(100);

            builder
                .ToTable("ModuloVersao");
        }
    }
}
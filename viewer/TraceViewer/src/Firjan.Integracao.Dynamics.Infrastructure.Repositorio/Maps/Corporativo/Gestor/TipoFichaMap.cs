using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class TipoFichaMap : IEntityTypeConfiguration<TipoFicha>
    {
        public void Configure(EntityTypeBuilder<TipoFicha> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("in_sq_tpregatend")
                .IsRequired(true);

            builder
                .HasKey(e => e.Id);
            
            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_ds_tpregatend")
                .IsRequired(true);

            builder
              .Property(e => e.HistFisioVac)
              .HasColumnName("ch_fg_Histfisiovac_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.HistFam)
              .HasColumnName("ch_fg_histfam_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.HppInter)
              .HasColumnName("ch_fg_hppinter_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.HppDoencas)
              .HasColumnName("ch_fg_hppdoencas_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Habitos)
              .HasColumnName("ch_fg_habitos_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.CondHab)
              .HasColumnName("ch_fg_condhab_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Torax)
              .HasColumnName("ch_fg_torax_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Membros)
              .HasColumnName("ch_fg_membros_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Coluna)
              .HasColumnName("ch_fg_coluna_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.ExameGer)
              .HasColumnName("ch_fg_exameger_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Abdome)
              .HasColumnName("ch_fg_abdome_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Imunizacao)
              .HasColumnName("ch_fg_imunizacao_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.BioComport)
              .HasColumnName("ch_fg_biocomport_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.CabecaPescoco)
              .HasColumnName("ch_fg_cabecapescoco_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.CondTrab)
              .HasColumnName("ch_fg_condtrab_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.AcidTrab)
              .HasColumnName("ch_fg_acidtrab_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Faixa)
              .HasColumnName("ch_fg_faixa_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.ColabResp)
              .HasColumnName("ch_fg_colabresp_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.ColabAtend)
              .HasColumnName("ch_fg_colabatend_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.QtdEspectad)
              .HasColumnName("ch_fg_qtdespectad_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.IndiSerie)
              .HasColumnName("ch_fg_indiserie_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Assistencial)
              .HasColumnName("ch_fg_assistencial_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.TotAtend)
              .HasColumnName("ch_fg_totatend_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Evento)
              .HasColumnName("ch_fg_evento_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Tema)
              .HasColumnName("ch_fg_tema_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.QtdAtend)
              .HasColumnName("ch_fg_qtdatend_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Entidade)
              .HasColumnName("ch_fg_entidade_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Pessoa)
              .HasColumnName("ch_fg_pessoa_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.TipoUtilizacao)
              .HasColumnName("ch_tp_utilizacao_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoUtilizacao)Enums<char?>.Parse<TipoUtilizacao>(v));

            builder
              .Property(e => e.Umo)
              .HasColumnName("ch_fg_umo_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.PrimVez)
              .HasColumnName("ch_fg_primvez_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.PrimeSpec)
              .HasColumnName("ch_fg_primespec_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Dente)
              .HasColumnName("ch_fg_dente_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Valor)
              .HasColumnName("ch_fg_valor_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.QtPesAtend)
              .HasColumnName("ch_fg_qtpesatend_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Turma)
              .HasColumnName("ch_fg_turma_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.EntPrestadora)
              .HasColumnName("ch_fg_entprestadora_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.TipoPreenchimento)
              .HasColumnName("ch_fg_tpconv_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoPreenchimento)Enums<char?>.Parse<TipoPreenchimento>(v));

            builder
              .Property(e => e.PublAlvo)
              .HasColumnName("ch_fg_publalvo_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Despesa)
              .HasColumnName("ch_fg_despesa_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.Receita)
              .HasColumnName("ch_fg_receita_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.CidDeficiencia)
              .HasColumnName("ch_fg_ciddeficiencia_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.GeraAtendimento)
              .HasColumnName("ch_fg_geraatendimento_tpregatend")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
                .ToTable("TipoRegAtend");
        }
    }
}
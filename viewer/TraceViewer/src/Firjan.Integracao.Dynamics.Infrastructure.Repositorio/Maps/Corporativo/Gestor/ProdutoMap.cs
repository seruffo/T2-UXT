using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("in_sq_classifservofic")
                .HasColumnType("int");

            builder
                .HasKey(w => w.Id);

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_ds_servoficial_classif")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder
                .Property(e => e.Inicio)
                .HasColumnName("sd_dt_criacao_classifservofic")
                .HasDefaultValueSql("getdate()")
                .HasColumnType("smalldatetime")
                .IsRequired(true);

            builder
                .Property(e => e.Fim)
                .HasColumnName("sd_dt_fim_classifservofic")
                .HasDefaultValue(null)
                .HasColumnType("smalldatetime");


            builder
                .Property(e => e.Validade)
                .HasColumnName("sd_dt_validade_classifservofic")
                .HasDefaultValue(null)
                .HasColumnType("smalldatetime");

            builder
              .Property(e => e.Categoria)
              .HasColumnName("ch_ql_categoria_classifservofic")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Categoria)Enums<char?>.Parse<Categoria>(v))
              .IsUnicode(false);

            builder
                .Property(e => e.ClassificacaoServicoId)
                .HasColumnName("in_sq_classificacaoservicost")
                .HasDefaultValue(null)
                .HasColumnType("int");

            builder
              .HasOne(a => a.ClassificacaoServico)
              .WithMany()
              .HasForeignKey(s => s.ClassificacaoServicoId);

            builder
              .Property(e => e.FuncaoServicoTecnologicoCodigo)
              .HasColumnName("ch_cd_funcaoservtec")
              .HasDefaultValue(null)
              .HasColumnType("char(5)");

            builder
              .HasOne(a => a.FuncaoServicoTecnologico)
              .WithMany()
              .HasForeignKey(s => s.FuncaoServicoTecnologicoCodigo);

            builder
              .Property(e => e.CodigoServico)
              .HasColumnName("vc_cd_classifservofic")
              .HasDefaultValue(null)
              .HasColumnType("varcha(20)");

            builder
              .Ignore(p => p.CodigoServicoEspecialidade);

            builder
              .Property(e => e.Divulgado)
              .HasColumnName("ch_fg_divulgado_classifservofic")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Divulgado)Enums<char?>.Parse<Divulgado>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.DivulgadoSite)
              .HasColumnName("ch_fg_divulgado_site_classifservofic")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Divulgado)Enums<char?>.Parse<Divulgado>(v))
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
              .Property(e => e.GrupoClassificacaoPrimeiroNivelId)
              .HasColumnName("in_sq_grupoclassif_primeironivel")
              .HasColumnType("int");

            builder
              .HasOne(a => a.GrupoClassificacaoPrimeiroNivel)
              .WithMany()
              .HasForeignKey(s => s.GrupoClassificacaoPrimeiroNivelId);

            builder
              .Ignore(e => e.Especialidade);

            builder
              .Property(e => e.LinhaServicoId)
              .HasColumnName("in_sq_linhaservicost")
              .HasColumnType("int");

            builder
              .HasOne(a => a.LinhaServico)
              .WithMany()
              .HasForeignKey(s => s.LinhaServicoId);

            builder
              .Property(e => e.NivelServicoId)
              .HasColumnName("ti_nr_nivelservico")
              .HasColumnType("tinyint");

            builder
              .HasOne(a => a.NivelServico)
              .WithMany()
              .HasForeignKey(s => new { s.NivelServicoId, s.TabelaServicoId });

            builder
              .Property(e => e.NomeResumido)
              .HasColumnName("vc_nm_resumido_classifservofic")
              .HasColumnType("varchar(100)");

            builder
              .Property(e => e.PlataformaId)
              .HasColumnName("in_sq_plataformast")
              .HasColumnType("int");

            builder
              .HasOne(a => a.Plataforma)
              .WithMany()
              .HasForeignKey(s => s.PlataformaId);

            builder
              .Property(e => e.ProdutoEspecialidadeId)
              .HasColumnName("in_sq_classifservofic_especialidade")
              .HasDefaultValue(null)
              .HasColumnType("int");

            builder
              .HasOne(a => a.ProdutoEspecialidade)
              .WithMany()
              .HasForeignKey(s => s.ProdutoEspecialidadeId);

            builder
              .Property(e => e.TabelaServicoId)
              .HasColumnName("si_sq_tabservico")
              .HasDefaultValue(null)
              .HasColumnType("smallint");

            builder
              .HasOne(a => a.TabelaServico)
              .WithMany()
              .HasForeignKey(s => s.TabelaServicoId);

            builder
              .Property(e => e.TUSSId)
              .HasColumnName("in_sq_TUSS")
              .HasDefaultValue(null)
              .HasColumnType("int");

            builder
              .HasOne(a => a.TUSS)
              .WithMany()
              .HasForeignKey(s => s.TUSSId);

            builder
              .Property(e => e.TipoEntidadeVinculoId)
              .HasColumnName("ch_tp_entidade_vinculo");

            builder
              .HasOne(a => a.TipoEntidadeVinculo)
              .WithMany()
              .HasForeignKey(s => s.TipoEntidadeVinculoId);

            builder
              .Property(e => e.TipoServicoId)
              .HasColumnName("ch_ql_servoficial_classif")
              .HasColumnType("char(1)");

            builder
              .HasOne(a => a.TipoServico)
              .WithMany()
              .HasForeignKey(s => s.TipoServicoId);

            builder
              .Property(e => e.ValeCultura)
              .HasColumnName("ch_fg_valecultura_classifservofic")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (ValeCultura)Enums<char?>.Parse<ValeCultura>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.Dedutivel)
              .HasColumnName("ch_fg_dedutivel_classifservofic")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Dedutivel)Enums<char?>.Parse<Dedutivel>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.AreaId)
              .HasColumnName("ch_cd_area");

            builder
              .HasOne(a => a.Area)
              .WithOne()
              .HasForeignKey<Produto>(s => s.AreaId);

            builder
              .Property(e => e.CodigoAreaDN)
              .HasColumnName("ch_cd_areadn_classifservofic");

            builder
              .Property(e => e.Versao)
              .HasColumnName("sd_dt_versao_classifservofic");

            builder
                .Ignore(t => t.AreaDN);

            builder
              .Property(e => e.ExigeCPF)
              .HasColumnName("bi_fg_exigeCPF_classifservofic")
              .HasColumnType("bit")
              .HasMaxLength(1);

            builder
              .Property(e => e.NumeroAgente)
              .HasColumnName("ch_nr_agente")
              .HasColumnType("char")
              .HasMaxLength(4);

            builder
              .Property(e => e.ServicoOficialId)
              .HasColumnName("in_sq_servoficial")
              .HasColumnType("int");

            builder
              .HasOne(a => a.ServicoOficial)
              .WithMany()
              .HasForeignKey(s => s.ServicoOficialId);

            builder
              .Ignore(a => a.Lazer);

            builder
             .Ignore(a => a.Saude);

            builder
              .Property(e => e.CursoPadrao)
              .HasColumnName("ch_fg_padrao_moduloversao_classifservofic")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.ModalidadeId)
              .HasColumnName("si_cd_modalidade_classifservofic");

            builder
              .Ignore(a => a.Modalidade);

            builder
              .Property(e => e.TipoCliente)
              .HasColumnName("ch_tp_cliente_classifservofic")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Domain.Models.Corporativo.Gestor.Tipos.TipoCliente)Enums<char?>.Parse<Domain.Models.Corporativo.Gestor.Tipos.TipoCliente>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.Atendimento)
              .HasColumnName("ch_fg_atendimento_classifservofic")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v));

            builder
              .Property(e => e.ExigeConfeccaoContrato)
              .HasColumnName("ch_fg_exigecontrato_classifservofic")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (ExigeContrato)Enums<char?>.Parse<ExigeContrato>(v))
              .IsUnicode(false);

            builder
              .HasOne(a => a.Plataforma)
              .WithMany()
              .HasForeignKey(s => s.PlataformaId);

            builder
              .HasOne(a => a.Area)
              .WithOne()
              .HasForeignKey<Produto>(s => s.AreaId);

            builder
                .ToTable("ClassifServicoOficial");
        }
    }
}
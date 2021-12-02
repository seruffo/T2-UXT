using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.SRC
{
    public class UnidadeNegocioMap : IEntityTypeConfiguration<UnidadeNegocio>
    {
        public void Configure(EntityTypeBuilder<UnidadeNegocio> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("si_sq_unidnegocio")
               .HasColumnType("smallint")
               .IsRequired(true);

            builder
                .HasKey(e => e.Id);

            builder
              .Property(e => e.Inicio)
              .HasColumnName("sd_dt_inicio_unidnegocio")
              .HasDefaultValueSql("getdate()");

            builder
                 .Property(e => e.TipoUnidadeId)
                 .HasColumnName("si_sq_tipounidade")
                 .HasColumnType("smallint")
                 .HasMaxLength(2)
                 .IsRequired(true);

            builder
              .Property(e => e.Fim)
              .HasColumnName("sd_dt_fim_unidnegocio");

            builder
                .Property(e => e.EnderecoProprio)
                .HasColumnName("ch_fg_enderecoproprio");

            builder
                .Property(e => e.EnderecadoProprio)
                .HasColumnName("ch_fg_enderecadoproprio");

            builder
                .Property(e => e.DiscadoProprio)
                .HasColumnName("ch_fg_discadoproprio");

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_ds_unidnegocio")
                .IsRequired(true);

            builder
                .Property(e => e.DescricaoAbreviado)
                .HasColumnName("vc_ds_abreviada_unidnegocio");

            builder
                .Property(e => e.Sigla)
                .HasMaxLength(10)
                .HasColumnName("ch_sg_unidnegocio");

            builder
                .Property(e => e.Prestador)
                .HasColumnName("ch_fg_prestad_unidnegocio")
                .HasColumnType("char")
                .HasMaxLength(1)
                .HasDefaultValue("N");

            builder
                .Property(e => e.Corporativo)
                .HasColumnName("ch_fg_corporat_unidnegocio")
                .HasColumnType("char")
                .HasMaxLength(1)
                .HasDefaultValue("N");

            builder
                .Property(e => e.SiglaSerie)
                .HasMaxLength(4)
                .HasColumnName("ch_sg_serie_unidnegocio")
                .HasColumnType("varchar");

            builder
                .Property(e => e.SiglaTitulo)
                .HasMaxLength(2)
                .HasColumnName("ch_sg_titulo_unidnegocio");

            builder
                .Property(e => e.FazFaturamento)
                .HasColumnName("bi_fg_FazFaturamento_UnidNegocio")
                .HasDefaultValue(false);

            builder
                .Property(e => e.AceitaPreco)
                .HasColumnName("bi_fg_aceitapreco_unidnegocio")
                .HasDefaultValue(false);

            builder
                .Property(e => e.AutorizaDivulgacao)
                .HasColumnName("bi_fg_autorizadivulgacao_unidnegocio")
                .HasDefaultValue(false);

            builder
                .Property(e => e.AtendimentoCentralizado)
                .HasColumnName("bi_fg_atendcentralizado_unidnegocio")
                .HasDefaultValue(false);

            builder
                .Property(e => e.AtivoAssistMarca)
                .HasColumnName("bi_fg_ativoassistmarca_unidnegocio")
                .HasDefaultValue(false);

            builder
                .Property(e => e.AtivoOcupMarca)
                .HasColumnName("bi_fg_ativoocupmarca_unidnegocio")
                .HasDefaultValue(false);

            builder
                .Property(e => e.AtivoOcupDesMarca)
                .HasColumnName("bi_fg_ativoocupdesmarca_unidnegocio")
                .HasDefaultValue(false);

            builder
                .Property(e => e.NomeCogecor)
                .HasMaxLength(100)
                .HasColumnName("vc_nm_cogecor_unidnegocio");

            builder
                .Property(e => e.EmpresaSistemaCNICoordenadoraId)
                .HasColumnName("in_sq_empCNI_coordenadora");

            builder
                .ToTable("UnidadeNegocio");
        }
    }
}
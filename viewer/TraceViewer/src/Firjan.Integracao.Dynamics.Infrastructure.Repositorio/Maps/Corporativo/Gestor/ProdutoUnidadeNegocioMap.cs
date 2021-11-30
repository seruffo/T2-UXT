using Firjan.Integracao.Dynamics.Domain.Models.Corporativo;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class ProdutoUnidadeNegocioMap : IEntityTypeConfiguration<ProdutoUnidadeNegocio>
    {
        public void Configure(EntityTypeBuilder<ProdutoUnidadeNegocio> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("in_sq_clservunidneg")
                .HasColumnType("int")
                .IsRequired(true);

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Inicio)
                .HasColumnName("sd_dt_ini_clservunidneg")
                .HasDefaultValueSql("getdate()")
                .HasColumnType("smalldatetime")
                .IsRequired(true);

            builder
                .Property(e => e.ProdutoId)
                .HasColumnName("in_sq_classifservofic")
                .IsRequired(true);

            builder
                .Property(e => e.Fim)
                .HasColumnName("sd_dt_fim_clservunidneg")
                .HasColumnType("smalldatetime");

            builder
                .Property(e => e.UnidadeNegocioId)
                .HasColumnName("si_sq_unidnegocio")
                .IsRequired(true);

            builder.HasOne(a => a.UnidadeNegocio)
               .WithMany()
               .HasForeignKey(s => s.UnidadeNegocioId);

            builder
                .Property(e => e.ExecutaServicoOferecido)
                .HasColumnName("ch_fg_executa_clservunidneg")
                .HasMaxLength(1)
                .HasColumnType("char");

            builder
                .Property(e => e.EmEstudoAtendimentoProduto)
                .HasColumnName("ch_fg_estudo_clservunidneg")
                .HasMaxLength(1)
                .HasColumnType("char");

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_ds_naoaprova_clservunidneg")
                .HasMaxLength(80)
                .HasColumnType("varchar");

            builder
                .Property(e => e.PercentualMaximoDesconto)
                .HasColumnName("nc_vl_negocia_clservunidneg")
                .HasColumnType("numeric(4,2)");

            builder
                .ToTable("ClServUnidNeg");
        }
    }
}
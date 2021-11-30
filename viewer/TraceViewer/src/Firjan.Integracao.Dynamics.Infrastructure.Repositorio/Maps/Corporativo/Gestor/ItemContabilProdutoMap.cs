using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class ItemContabilProdutoMap : IEntityTypeConfiguration<ItemContabilProduto>
    {
        public void Configure(EntityTypeBuilder<ItemContabilProduto> builder)
        {
            builder
               .Property(e => e.CodigoEmpresa)
               .HasColumnName("EMPRESA")
               .HasColumnType("char")
               .HasMaxLength(8)
               .IsRequired(true);

            builder
               .Property(e => e.CodigoCentroResponsabilidade)
               .HasColumnName("CODSUB1")
               .HasColumnType("char")
               .HasMaxLength(20)
               .IsRequired(true);

            builder
               .Property(e => e.ProdutoId)
               .HasColumnName("in_sq_classifservofic")
               .HasColumnType("int")
               .HasMaxLength(4)
               .IsRequired(true);

            builder
               .Property(e => e.Inicio)
               .HasColumnName("sd_dt_ini_clservsubconta1")
               .HasColumnType("smalldatetime")
               .IsRequired(true);

            builder
                .HasKey(s => new { s.CodigoEmpresa, s.CodigoCentroResponsabilidade, s.ProdutoId, s.Inicio });

            builder
               .Property(e => e.Fim)
               .HasColumnName("sd_dt_fim_clservsubconta1")
               .HasColumnType("smalldatetime");

            builder
               .Property(e => e.IsAssistencial)
               .HasColumnName("ch_fg_assistencial_ClSrvSubCta1")
               .HasColumnType("char")
               .HasDefaultValue(null)
               .HasMaxLength(1);

            builder
                .Ignore(s => s.GrupoClassifId);

            builder
                .ToTable("ClServSubConta1");
        }
    }
}

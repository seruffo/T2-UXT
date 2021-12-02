using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class ContaContabilProdutoMap : IEntityTypeConfiguration<ContaContabilProduto>
    {
        public void Configure(EntityTypeBuilder<ContaContabilProduto> builder)
        {
            builder
               .Property(e => e.CodigoEmpresa)
               .HasColumnName("EMPRESA")
               .HasColumnType("char")
               .HasMaxLength(8)
               .IsRequired(true);

            builder
               .Property(e => e.CodigoConta)
               .HasColumnName("CONTA")
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
               .HasColumnName("sd_dt_ini_clservplanocta")
               .HasColumnType("smalldatetime")
               .IsRequired(true);

            builder
                .HasKey(s => new { s.CodigoEmpresa, s.CodigoConta, s.ProdutoId, s.Inicio });

            builder
               .Property(e => e.Fim)
               .HasColumnName("sd_dt_fim_clservplanocta")
               .HasColumnType("smalldatetime");

            builder
               .Property(e => e.IsAssistencial)
               .HasColumnName("ch_fg_assistencial_planocta")
               .HasColumnType("char")
               .HasMaxLength(1);

            builder
                .Ignore(s => s.GrupoClassifId);

            builder
                .ToTable("ClServPlanoCta");
        }
    }
}

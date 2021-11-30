using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo
{
    public class CentroCustoMap : IEntityTypeConfiguration<CentroCusto>
    {
        public void Configure(EntityTypeBuilder<CentroCusto> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("CENTRO")
               .HasColumnType("varchar(20)")
               .HasMaxLength(20)
               .HasConversion(
                 v => v,
                 v => v.Trim());

            builder.HasKey(e => new { e.Id, e.Empresa, e.Descricao });

            builder
                .Property(e => e.Descricao)
                .HasColumnName("NOMECENTRO")
                .HasColumnType("varchar(40)")
                .HasMaxLength(40)
                .HasConversion(
                  v => v,
                  v => v.Trim());

            builder
                .Property(e => e.Inicio)
                .HasColumnName("CE_VALINI")
                .HasColumnType("datetime");

            builder
                .Property(e => e.Fim)
                .HasColumnName("CE_VALFIM")
                .HasColumnType("datetime");

            builder
                .Property(e => e.Empresa)
                .HasColumnName("EMPRESA")
                .HasColumnType("varchar(20)")
                .HasConversion(
                  v => v,
                  v => v.Trim());

            builder
                .ToTable("Centros");
        }
    }
}
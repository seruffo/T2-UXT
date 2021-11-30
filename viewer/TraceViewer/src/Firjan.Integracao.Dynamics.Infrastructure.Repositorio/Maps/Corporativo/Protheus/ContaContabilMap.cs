using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Protheus
{
    public class ContaContabilMap : IEntityTypeConfiguration<ContaContabil>
    {
        public void Configure(EntityTypeBuilder<ContaContabil> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("CONTA")
                .HasColumnType("varchar(20)")
                .IsRequired()
                .HasConversion(
                 v => v,
                 v => v.Trim());

            builder
                .Property(e => e.Descricao)
                .HasColumnName("NOMECONTA")
                .HasColumnType("varchar(45)")
                .HasConversion(
                 v => v,
                 v => v.Trim());

            builder
                .HasKey(e => new { e.Id, e.Empresa });

            builder
                .Property(e => e.Empresa)
                .HasColumnName("EMPRESA")
                .HasColumnType("varchar(8)")
                .HasMaxLength(8)
                .IsRequired(true)
                .HasConversion(
                 v => v,
                 v => v.Trim());

            builder
                .Property(e => e.Inicio)
                .HasColumnName("DAT_VALID_INI")

                .HasColumnType("datetime");

            builder
                .Property(e => e.Fim)
                .HasColumnName("DAT_VALID_FIM")
                .HasColumnType("datetime");

            builder
                .ToTable("PLANOCTA");
        }
    }
}
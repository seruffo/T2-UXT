using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Protheus
{
    public class ClasseValorMap : IEntityTypeConfiguration<ClasseValor>
    {
        public void Configure(EntityTypeBuilder<ClasseValor> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("CODSUB2")
                .HasColumnType("varchar(20)")
                .HasConversion(
                     v => v,
                     v => v.Trim())
                .HasMaxLength(20)
                .IsRequired(true);

            builder
                .HasKey(e => new { e.Id, e.Empresa });

            builder
                .Property(e => e.Descricao)
                .HasColumnName("DESCSUB2")
                .HasColumnType("varchar(40)")
                .HasConversion(
                     v => v,
                     v => v.Trim())
                .HasMaxLength(40);

            builder
                .Property(e => e.Empresa)
                .HasColumnName("EMPRESA")
                .HasColumnType("varchar(8)")
                .HasConversion(
                     v => v,
                     v => v.Trim())
                .HasMaxLength(8)
                .IsRequired(true);

            builder
                .Property(e => e.Inicio)
                .HasColumnName("S2_VALINI")
                .HasColumnType("datetime");

            builder
                .Property(e => e.Fim)
                .HasColumnName("S2_VALFIM")
                .HasColumnType("datetime");

            builder
                .ToTable("SUBCONTA2");
        }
    }
}
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Protheus
{
    public class ItemContabilMap : IEntityTypeConfiguration<ItemContabil>
    {
        public void Configure(EntityTypeBuilder<ItemContabil> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("CODSUB1")
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder
                .Property(e => e.Descricao)
                .HasColumnName("DESCSUB1")
                .HasColumnType("varchar(40)");

            builder
                .HasKey(e => new { e.Id, e.Empresa });

            builder
                .Property(e => e.Empresa)
                .HasColumnName("EMPRESA")
                .HasColumnType("varchar(8)")
                .HasMaxLength(8)
                .IsRequired(true);

            builder
                .Property(e => e.Inicio)
                .HasColumnName("S1_VALINI")
                .HasColumnType("datetime");

            builder
                .Property(e => e.Fim)
                .HasColumnName("S1_VALFIM")
                .HasColumnType("datetime");

            builder
                .ToTable("SUBCONTA1");
        }
    }
}
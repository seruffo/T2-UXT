using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class UFMap : IEntityTypeConfiguration<UF>
    {
        public void Configure(EntityTypeBuilder<UF> builder)
        {
            builder
               .Property(e => e.Sigla)
               .HasColumnName("ch_sg_uf")
               .HasColumnType("char")
               .HasMaxLength(2)
               .IsRequired(true);

            builder
                .HasKey(e => e.Sigla);

            builder
               .Property(e => e.Nome)
               .HasColumnName("vc_nm_uf")
               .HasColumnType("varchar")
               .HasMaxLength(25)
               .IsRequired(true);

            builder
                .ToTable("UF");
        }
    }
}
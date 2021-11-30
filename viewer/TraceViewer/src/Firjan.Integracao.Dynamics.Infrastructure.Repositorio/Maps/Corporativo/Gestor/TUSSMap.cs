
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class TUSSMap : IEntityTypeConfiguration<TUSS>
    {
        public void Configure(EntityTypeBuilder<TUSS> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("in_sq_TUSS")
               .HasColumnType("int")
               .HasMaxLength(4)
               .IsRequired(true);

            builder
                .HasKey(e => e.Id);

            builder
               .Property(e => e.Codigo)
               .HasColumnName("vc_cd_TUSS")
               .HasColumnType("varchar")
               .HasMaxLength(10)
               .IsRequired(true);

            builder
               .Property(e => e.Descricao)
               .HasColumnName("vc_ds_procedimento_TUSS")
               .HasColumnType("varchar")
               .HasMaxLength(200);

            builder
                .ToTable("TUSS");
        }
    }
}

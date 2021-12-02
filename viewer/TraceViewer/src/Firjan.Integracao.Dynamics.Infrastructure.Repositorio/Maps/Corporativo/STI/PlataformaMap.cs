using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.STI
{
    public class PlataformaMap : IEntityTypeConfiguration<Plataforma>
    {
        public void Configure(EntityTypeBuilder<Plataforma> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("in_sq_plataformast")
                .HasColumnType("int")                
                .IsRequired(true);

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_ds_plataformast")
                .HasColumnType("varchar")
                .HasMaxLength(80)
                .IsRequired(true);

            builder
                .Property(x => x.CodigoArea)
                .HasColumnName("ch_cd_area")
                .HasColumnType("char")
                .HasMaxLength(5)
                .IsRequired(true);

            builder
                .HasOne(a => a.Area)
                .WithMany()
                .HasForeignKey(s => s.CodigoArea)
                .IsRequired();

            builder
              .ToTable("PlataformaST");
        }
    }
}
using Firjan.Integracao.Dynamics.Domain.Models.SGE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.SGE
{
    public class AreaSGEMap : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("codarea")
                .HasColumnType("smallint")
                .IsRequired(true);

            builder
                .HasKey(r => new { r.Id, r.ColigadaId });

            builder
                .Property(e => e.ColigadaId)
                .HasColumnName("codcoligada")
                .HasColumnType("smallint")
                .IsRequired(true);

            builder
               .HasOne(a => a.Coligada)
               .WithMany()
               .HasForeignKey(s => s.ColigadaId)
               .IsRequired();

            builder
                .Property(e => e.Descricao)
                .HasColumnName("nome");

            builder
                .ToTable("SAREA");
        }
    }
}
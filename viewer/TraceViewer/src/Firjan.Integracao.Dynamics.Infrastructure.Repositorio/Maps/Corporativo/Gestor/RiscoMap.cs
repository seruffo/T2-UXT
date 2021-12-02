using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class RiscoMap : IEntityTypeConfiguration<Risco>
    {
        public void Configure(EntityTypeBuilder<Risco> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("ch_nr_risco")
               .IsRequired(true);

            builder
                .HasKey(e => e.Id);

            builder
               .Property(e => e.Descricao)
               .HasColumnName("vc_nm_risco")
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsRequired(true);

            builder
                 .Property(e => e.TipoRiscoId)
                 .HasColumnName("ch_nr_tiporisco");

            builder
                .HasOne(a => a.TipoRisco)
                .WithMany()
                .HasForeignKey(s => s.TipoRiscoId);
        }
    }
}

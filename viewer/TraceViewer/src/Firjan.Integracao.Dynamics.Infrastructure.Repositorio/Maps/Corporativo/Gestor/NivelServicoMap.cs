using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class NivelServicoMap : IEntityTypeConfiguration<NivelServico>
    {
        public void Configure(EntityTypeBuilder<NivelServico> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("ti_nr_nivelservico")
               .HasColumnType("tinyint")
               .HasMaxLength(1)
               .IsRequired(true);

            builder
                .HasKey(e => new { e.Id, e.TabelaServicoId });

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_ds_nivelservico")
              .HasColumnType("varchar")
              .HasMaxLength(30)
              .IsRequired(true);

            builder
              .Property(e => e.TabelaServicoId)
              .HasColumnName("si_sq_tabservico")
              .IsRequired(true);

            builder
              .HasOne(a => a.TabelaServico)
              .WithMany()
              .HasForeignKey(s => s.TabelaServicoId);

            builder
                .ToTable("NivelServico");
        }
    }
}
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class SaudeFiguraOdontogramaMap : IEntityTypeConfiguration<SaudeFiguraOdontograma>
    {
        public void Configure(EntityTypeBuilder<SaudeFiguraOdontograma> builder)
        {

            builder
                .HasKey(s => new { s.SaudeId, s.FiguraOdontogramaId });

            builder
               .Property(e => e.SaudeId)
               .HasColumnName("in_sq_classifservofic_saude")
               .HasColumnType("int")
               .HasMaxLength(4)
               .IsRequired(true);

            builder
              .HasOne(a => a.Saude)
              .WithMany()
              .HasForeignKey(s => s.SaudeId);

            builder
               .Property(e => e.FiguraOdontogramaId)
               .HasColumnName("in_sq_figuraodontograma")
               .HasColumnType("int")
               .HasMaxLength(4)
               .IsRequired(true);

            builder
              .HasOne(a => a.FiguraOdontograma)
              .WithMany()
              .HasForeignKey(s => s.FiguraOdontogramaId);

            builder
              .Property(e => e.Obrigatorio)
              .HasColumnName("ch_fg_obrigatorio_saudefiguraodontograma")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Obrigatorio)Enums<char?>.Parse<Obrigatorio>(v))
              .IsUnicode(false)
              .IsRequired(true);

            builder
                .ToTable("SaudeFiguraOdontograma");
        }
    }
}
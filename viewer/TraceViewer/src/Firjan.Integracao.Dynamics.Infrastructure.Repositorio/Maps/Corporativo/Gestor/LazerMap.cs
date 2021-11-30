using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class LazerMap : IEntityTypeConfiguration<Lazer>
    {
        public void Configure(EntityTypeBuilder<Lazer> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("in_sq_classifservofic")
                .IsRequired(true);

            builder
              .HasOne(a => a.Produto)
              .WithOne()
              .HasForeignKey<Lazer>(s => s.Id);

            builder
                .HasKey(u => u.Id);

            builder
                .Ignore(t => t.Descricao);

            builder
              .Property(e => e.TipoLazer)
              .HasColumnName("ch_tp_lazer")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoLazer)Enums<char?>.Parse<TipoLazer>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.FamiliaLazer)
              .HasColumnName("ch_fg_sesiclube_familiar_lazer")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (FamiliaLazer)Enums<char?>.Parse<FamiliaLazer>(v))
              .IsUnicode(false);

            builder
                .ToTable("Lazer");
        }
    }
}
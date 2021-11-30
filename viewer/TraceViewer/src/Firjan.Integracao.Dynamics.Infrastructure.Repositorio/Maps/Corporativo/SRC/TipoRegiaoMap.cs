using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.SRC
{
    public class TipoRegiaoMap : IEntityTypeConfiguration<TipoRegiao>
    {
        public void Configure(EntityTypeBuilder<TipoRegiao> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("si_sq_tp_regiao")
               .HasColumnType("smallint")
               .HasMaxLength(2)
               .IsRequired(true);

            builder
                .HasKey(e => e.Id);

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_ds_tp_regiao")
              .HasColumnType("varchar")
              .HasMaxLength(25)
              .IsRequired(true);

            builder
                .ToTable("TipoRegiao");
        }
    }
}
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class TipoRegimentoMap : IEntityTypeConfiguration<TipoRegimento>
    {
        public void Configure(EntityTypeBuilder<TipoRegimento> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("ch_cd_tiporegimento")
               .HasColumnType("char")
               .HasMaxLength(2)
               .IsRequired(true);

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_ds_tiporegimento")
              .HasColumnType("varchar")
              .HasMaxLength(20)
              .IsRequired(true);

            builder
                .ToTable("TipoRegimento");
        }
    }
}
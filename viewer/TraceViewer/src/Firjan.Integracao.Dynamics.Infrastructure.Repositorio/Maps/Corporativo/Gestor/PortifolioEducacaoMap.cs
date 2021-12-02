using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class PortifolioEducacaoMap : IEntityTypeConfiguration<PortifolioEducacao>
    {
        public void Configure(EntityTypeBuilder<PortifolioEducacao> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("in_sq_portifolioeducacao")
               .HasColumnType("int")
               .HasMaxLength(4)
               .IsRequired(true);

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_ds_portifolioeducacao")
              .HasColumnType("varchar")
              .HasMaxLength(100)
              .IsRequired(true);

            builder
                .ToTable("PortifolioEducacao");
        }
    }
}
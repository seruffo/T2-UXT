using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class NaturezaServicoMap : IEntityTypeConfiguration<NaturezaServico>
    {
        public void Configure(EntityTypeBuilder<NaturezaServico> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("si_cd_naturezaservico")
               .HasColumnType("smallint")
               .HasMaxLength(2)
               .IsRequired(true);

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_ds_naturezaservico")
              .HasColumnType("varchar")
              .HasMaxLength(30)
              .IsRequired(true);

            builder
                .ToTable("NaturezaServico");
        }
    }
}
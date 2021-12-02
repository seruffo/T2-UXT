using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class GeneroMap : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("ch_cd_genero")
               .HasColumnType("char")
               .HasMaxLength(16)
               .IsRequired(true);

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_ds_genero")
              .HasColumnType("varchar")
              .HasMaxLength(200)
              .IsRequired(true);
 
            builder
                 .Property(e => e.RamoAtividadeId)
                 .HasColumnName("ti_sq_ramoatividade");

            builder                
                .HasOne(a => a.RamoAtividade)
                .WithMany()
                .IsRequired()
                .HasForeignKey(s => s.RamoAtividadeId);

            builder
                .ToTable("Genero");
        }
    }
}
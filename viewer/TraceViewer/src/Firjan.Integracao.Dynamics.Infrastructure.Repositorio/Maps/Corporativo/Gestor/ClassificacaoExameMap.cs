using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Saude;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class ClassificacaoExameMap : IEntityTypeConfiguration<ClassificacaoExame>
    {
        public void Configure(EntityTypeBuilder<ClassificacaoExame> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("si_sq_classifexame")
               .HasColumnType("smallint");

            builder
                .HasKey(e => e.Id);

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_ds_classifexame")
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .IsRequired(true);

            builder
                .ToTable("ClassificacaoExame");
        }
    }
}
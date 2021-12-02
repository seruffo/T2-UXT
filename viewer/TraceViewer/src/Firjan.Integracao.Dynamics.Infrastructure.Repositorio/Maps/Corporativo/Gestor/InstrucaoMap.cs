using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class InstrucaoMap : IEntityTypeConfiguration<Instrucao>
    {
        public void Configure(EntityTypeBuilder<Instrucao> builder)
        {
            builder
               .Property(e => e.Codigo)
               .HasColumnName("ch_cd_instrucao")
               .HasColumnType("char")
               .HasMaxLength(2)
               .IsRequired(true);

            builder
                .HasKey(e => e.Codigo);

            builder
                .Ignore(c => c.Id);

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_ds_instrucao")
              .HasColumnType("varchar")
              .HasMaxLength(60)
              .IsRequired(true);

            builder
                .ToTable("Instrucao");
        }
    }
}
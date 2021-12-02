using Firjan.Integracao.Dynamics.Domain.Models.SGE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.SGE
{
    public class ModalidadeCursoMap : IEntityTypeConfiguration<ModalidadeCurso>
    {
        public void Configure(EntityTypeBuilder<ModalidadeCurso> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("codmodalidadecurso")
                .HasColumnType("varchar(4)")
                .IsRequired();

            builder
                .HasKey(t => t.Id);

            builder
                .Property(e => e.ColigadaId)
                .HasColumnName("codcoligada")
                .HasColumnType("smallint")
                .HasMaxLength(2)
                .IsRequired();

            builder
               .HasOne(a => a.Coligada)
               .WithMany()
               .HasForeignKey(s => s.ColigadaId)
               .IsRequired();

            builder
                .Property(e => e.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .IsRequired(true);

            builder
                .ToTable("smodalidadecurso");
        }
    }
}
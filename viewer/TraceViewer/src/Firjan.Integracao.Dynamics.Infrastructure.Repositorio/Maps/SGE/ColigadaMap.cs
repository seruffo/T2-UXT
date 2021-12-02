using Firjan.Integracao.Dynamics.Domain.Models.SGE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.SGE
{
    public class ColigadaMap : IEntityTypeConfiguration<Coligada>
    {
        public void Configure(EntityTypeBuilder<Coligada> builder)
        {
            builder
                .Property(e => e.Id)
                .HasMaxLength(2)
                .HasColumnName("CODCOLIGADA")
                .HasColumnType("Int16")
                .IsRequired(true);

            builder.Property(e => e.Descricao)
                .HasColumnName("NOMEFANTASIA")
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .IsRequired();

            builder
                .ToTable("GCOLIGADA");
        }
    }
}
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.SRC
{
    public class RegiaoUnidadeNegocioMap : IEntityTypeConfiguration<RegiaoUnidadeNegocio>
    {
        public void Configure(EntityTypeBuilder<RegiaoUnidadeNegocio> builder)
        {
            builder
                .HasKey(pc => new { pc.TipoRegiaoId, pc.RegiaoId, pc.UnidadeNegocioId, pc.Inicio });

            builder
                .Property(e => e.TipoRegiaoId)
                .HasMaxLength(2)
                .HasColumnType("smallint")
                .HasColumnName("si_sq_tp_regiao")
                .IsRequired(true);

            builder.HasOne(a => a.TipoRegiao)
                .WithMany()
                .HasForeignKey(s => s.TipoRegiaoId);

            builder
                .Property(e => e.RegiaoId)
                .HasColumnType("int")
                .HasMaxLength(4)
                .HasColumnName("in_sq_regiao")
                .IsRequired(true);

            builder.HasOne(a => a.Regiao)
                .WithMany()
                .HasForeignKey(s => s.RegiaoId)
                .IsRequired();

            builder
                .Property(e => e.UnidadeNegocioId)
                .HasColumnType("smallint")
                .HasMaxLength(2)
                .HasColumnName("si_sq_unidnegocio")
                .IsRequired(true);

            builder.HasOne(a => a.UnidadeNegocio)
                .WithMany()
                .HasForeignKey(s => s.UnidadeNegocioId)
                .IsRequired();

            builder
               .Property(e => e.Inicio)
               .HasColumnName("sd_dt_ini_regiaounidneg")
               .HasColumnType("smalldatetime")
               .IsRequired(true);

            builder
               .Property(e => e.Fim)
               .HasColumnName("sd_dt_fim_regiaounidneg")
               .HasColumnType("smalldatetime");

            builder
                .ToTable("RegiaoUnidNeg");
        }
    }
}
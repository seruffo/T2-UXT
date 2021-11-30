using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using static Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Municipio;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class MunicipioMap : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("in_sq_municipio")
                .HasColumnType("int")
                .HasMaxLength(4)
                .IsRequired(true);

            builder
                .Property(e => e.Codigo)
                .HasColumnName("in_cd_municipio")
                .HasColumnType("int")
                .HasMaxLength(4);

            builder
                .Property(e => e.Descricao)                
                .HasColumnName("vc_nm_municipio")
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .IsRequired(true);

            builder
              .Property(e => e.SiglaUF)
              .HasColumnName("ch_sg_uf")
              .HasColumnType("char")
              .HasMaxLength(2)
              .IsRequired(true);

            builder.HasOne(a => a.UF)
              .WithMany()
              .HasForeignKey(s => s.SiglaUF)
              .IsRequired();

            builder
              .Property(e => e.CEP)
              .HasColumnName("ch_cd_cep_municipio")
              .HasColumnType("char(8)")
              .HasMaxLength(8);


            builder
                .ToTable("Municipio");
        }
    }
}

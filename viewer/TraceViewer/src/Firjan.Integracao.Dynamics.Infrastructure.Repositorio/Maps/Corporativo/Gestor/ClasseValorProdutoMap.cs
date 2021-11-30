using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class ClasseValorProdutoMap : IEntityTypeConfiguration<ClasseValorProduto>
    {
        public void Configure(EntityTypeBuilder<ClasseValorProduto> builder)
        {
            builder
               .Property(e => e.CodigoEmpresa)
               .HasColumnName("EMPRESA")
               .HasColumnType("char")
               .HasMaxLength(8)
               .IsRequired(true)
               .HasConversion(
                 v => v,
                 v => v.Trim());

            builder
               .Property(e => e.CodigoCentroResponsabilidade)
               .HasColumnName("CODSUB2")
               .HasColumnType("char")
               .HasMaxLength(20)
               .IsRequired(true)
               .HasConversion(
                 v => v,
                 v => v.Trim());

            builder
               .Property(e => e.ProdutoId)
               .HasColumnName("in_sq_classifservofic")
               .HasColumnType("int")
               .HasMaxLength(4)
               .IsRequired(true);

            builder
               .Property(e => e.Inicio)
               .HasColumnName("sd_dt_ini_clservsubconta2");

            builder
                .HasKey(s => new { s.CodigoEmpresa, s.CodigoCentroResponsabilidade, s.ProdutoId, s.Inicio });

            builder
               .Property(e => e.Fim)
               .HasColumnName("sd_dt_fim_clservsubconta2");

            builder
                .Ignore(s => s.GrupoClassifId);


            builder
                .ToTable("ClServSubConta2");
        }
    }
}

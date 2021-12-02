using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class CodigoMunicipalMap : IEntityTypeConfiguration<CodigoMunicipal>
    {
        public void Configure(EntityTypeBuilder<CodigoMunicipal> builder)
        {
            builder
                .HasKey(pc => new { pc.MunicipioId, pc.Id });

            builder
               .Property(e => e.Id)
               .HasColumnName("cod_serv_mun")
               .HasColumnType("char")
               .HasMaxLength(6)
               .IsRequired(true);

            builder
               .Property(e => e.CoodigoMunicipio)
               .HasColumnName("cod_municipio")
               .HasColumnType("char")
               .HasMaxLength(7)
               .IsRequired();

            builder
               .Property(e => e.Descricao)
               .HasColumnName("descricao")
               .HasColumnType("char")
               .HasMaxLength(50)
               .IsRequired(true);

            builder
               .Property(e => e.MunicipioId)
               .HasColumnName("in_sq_municipio")
               .HasColumnType("int")
               .HasMaxLength(4)
               .IsRequired(true);

            builder
               .Property(e => e.AliqISS)
               .HasColumnName("aliq_ISS")
               .HasColumnType("numeric")
               .HasMaxLength(5);

            builder
               .Property(e => e.CNAE)
               .HasColumnName("cod_cnae_mun")
               .HasMaxLength(20);
            

            builder.HasOne(a => a.Municipio)
                .WithMany()
                .HasForeignKey(pc => pc.MunicipioId)
                .IsRequired();

            builder
                .ToTable("serv_municipal");
        }
    }
}
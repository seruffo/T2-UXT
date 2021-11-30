using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo
{
    public class CodigoMunicipalServicoCorporativoMap : IEntityTypeConfiguration<CodigoMunicipalServicoCorporativo>
    {
        public void Configure(EntityTypeBuilder<CodigoMunicipalServicoCorporativo> builder)
        {
            builder
                .HasKey(pc => new { pc.CodigoServicoOficial, pc.Inicio, pc.CodigoMunicipalId, pc.CodigoMunicipio });

            builder
               .Property(e => e.CodigoServicoOficial)
               .HasColumnName("in_sq_classifservofic")
               .HasColumnType("int")
               .IsRequired(true);

            builder
               .Property(e => e.Inicio)
               .HasColumnName("sd_dt_ini_classiftabservgoverno")
               .HasColumnType("smalldatetime")
               .IsRequired(true);

            builder
               .Property(e => e.SeqMunicipio)
               .HasColumnName("in_sq_municipio")
               .HasColumnType("int")
               .IsRequired(true);

            builder
               .HasOne(a => a.Municipio)
               .WithMany()
               .HasForeignKey(s => s.SeqMunicipio)
               .IsRequired();

            builder
               .Property(e => e.CodigoMunicipalId)
               .HasColumnName("cod_serv_mun")
               .HasColumnType("char(6)")
               .IsRequired(true);

            builder
                .HasOne(a => a.CodigoMunicipal)
                .WithMany()
                .HasForeignKey(pc => new { pc.SeqMunicipio, pc.CodigoMunicipalId } )
                .IsRequired();

            builder
               .Property(e => e.CodigoMunicipio)
               .HasColumnName("cod_municipio")
               .HasColumnType("char(7)")
               .IsRequired(true);

            builder
                .Property(e => e.Fim)
                .HasColumnName("sd_dt_fim_classiftabservgoverno")
                .HasColumnType("smalldatetime");

            builder
                .ToTable("ClassifTabServicoGoverno");
        }
    }
}
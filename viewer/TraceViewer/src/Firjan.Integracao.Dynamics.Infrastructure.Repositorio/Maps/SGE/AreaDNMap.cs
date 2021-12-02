using Firjan.Integracao.Dynamics.Domain.Models.SGE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.SGE
{
    public class AreaDNMap : IEntityTypeConfiguration<AreaDN>
    {
        public void Configure(EntityTypeBuilder<AreaDN> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("ti_cd_area")
                .HasColumnType("tinyint")
                .IsRequired(true);

            builder
                .HasKey(p => p.Id);

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_nm_area")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder
               .Property(e => e.Inicio)
               .HasColumnName("sd_dt_ini_vigencia")
               .HasColumnType("smalldatetime");

            builder
               .Property(e => e.Fim)
               .HasColumnName("sd_dt_fim_vigencia")
               .HasColumnType("smalldatetime");

            builder
                .ToTable("AreaDN");
        }
    }
}
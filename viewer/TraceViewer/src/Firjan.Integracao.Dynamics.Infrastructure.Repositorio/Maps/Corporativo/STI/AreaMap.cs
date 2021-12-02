using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.STI
{
    public class AreaMap : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder
              .Property(e => e.Id)
              .HasColumnName("ch_cd_area")
              .HasConversion(
                  v => v,
                  v => v.Trim());

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_ds_area");

            builder
              .Property(e => e.CodigoDnaArea)
              .HasColumnName("ch_cd_dn_area")
              .HasConversion(
                  v => v,
                  v => v.Trim());

            builder
                .Property(e => e.Fim)
                .HasColumnName("sd_dt_fim_area")
                .HasDefaultValueSql("NULL")
                .HasColumnType("smalldatetime");

            builder
                .ToTable("Area");
        }
    }
}
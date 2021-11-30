using Firjan.Integracao.Dynamics.Domain.Models.Corporativo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo
{
    public class RamoAtividadeMap : IEntityTypeConfiguration<RamoAtividade>
    {
        public void Configure(EntityTypeBuilder<RamoAtividade> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("ti_sq_ramoatividade")
                .HasColumnType("tinyint")
                .IsRequired();

            builder
                .Property(e => e.Descricao)
                .HasColumnType("varchar(80)")
                .HasColumnName("vc_ds_ramoatividade");

            builder
                .Property(e => e.Codigo)
                .HasColumnType("char(1)")
                .HasColumnName("ch_cd_ramoatividade");

            builder
                .ToTable("RamoAtividade");
        }
    }
}
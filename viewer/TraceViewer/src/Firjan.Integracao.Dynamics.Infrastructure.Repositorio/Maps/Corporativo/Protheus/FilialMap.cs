using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Protheus
{
    public class FilialMap : IEntityTypeConfiguration<Filial>
    {
        public void Configure(EntityTypeBuilder<Filial> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("Codigo")
                .HasColumnType("varchar(8)")
                .IsRequired(true);

            builder
                .Property(e => e.Descricao)
                .HasColumnName("Nome")
                .HasColumnType("varchar(40)")
                .IsRequired(true);

            builder
                .HasKey(e => new { e.Id, e.Empresa });

            builder
                .Property(e => e.Empresa)
                .HasColumnName("Empresa")
                .HasColumnType("varchar(80)")
                .IsRequired(true);

            builder
                .ToTable("Filiais");
        }
    }
}
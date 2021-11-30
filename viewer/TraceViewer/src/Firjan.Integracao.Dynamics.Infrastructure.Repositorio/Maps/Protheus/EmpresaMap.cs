using Microsoft.EntityFrameworkCore;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Protheus
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("Z7_FILIAL")
               .IsRequired();

            builder
                .HasKey(e => new { e.Id, e.Descricao, e.Nome });

            builder
                .Property(e => e.Nome)
                .HasColumnName("Z7_NOME");

            builder
                .Property(e => e.Descricao)
                .HasColumnName("Z7_NOMECOM");

            builder
                .ToTable("Empresas");
        }
    }
}
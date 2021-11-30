using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("in_sq_pessoa")
               .HasColumnType("int")
               .HasMaxLength(4)
               .IsRequired(true);

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_nm_pessoa")
              .HasColumnType("varchar")
              .HasMaxLength(100)
              .IsRequired(true);

            builder
                .ToTable("Pessoa");
        }
    }
}
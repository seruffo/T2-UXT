using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.SRC
{
    public class EntidadeMap : IEntityTypeConfiguration<Entidade>
    {
        public void Configure(EntityTypeBuilder<Entidade> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("in_sq_entidade")
                .IsRequired();

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_nm_entidade");

            builder
               .Property(e => e.TipoEntidadeVinculoId)
               .HasColumnName("ch_tp_entidade_vinculo")
               .HasConversion(
                 v => v,
                 v => v.Trim());

            builder
                .HasOne(a => a.TipoEntidadeVinculo)
                .WithMany()
                .HasForeignKey(s => s.TipoEntidadeVinculoId);

            builder
                .ToTable("Entidade");
        }
    }
}
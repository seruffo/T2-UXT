using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class TipoEntidadeVinculoMap : IEntityTypeConfiguration<TipoEntidadeVinculo>
    {
        public void Configure(EntityTypeBuilder<TipoEntidadeVinculo> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("ch_tp_entidade_vinculo")
               .HasConversion(
                 v => v,
                 v => v.Trim())
               .IsRequired(true);

            builder
               .HasKey("Id");

            builder
               .Property(e => e.Descricao)
               .HasColumnName("vc_ds_tp_entidade_vinculo")
               .IsRequired(true);
            
            builder
                .Ignore(e => e.GruposClassificacoes);

            builder
                .ToTable("TipoEntidadeVinculo");
        }
    }
}
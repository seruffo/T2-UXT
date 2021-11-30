using Microsoft.EntityFrameworkCore;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class EmpresaEntidadeVinculoMap : IEntityTypeConfiguration<EmpresaEntidadeVinculo>
    {
        public void Configure(EntityTypeBuilder<EmpresaEntidadeVinculo> builder)
        {

            builder
               .Property(e => e.TipoEntidadeVinculoId)
               .HasColumnName("ch_tp_entidade_vinculo")
               .HasColumnType("char(2)")
               .IsRequired(true);

            builder
                .HasOne(t => t.TipoEntidadeVinculo)
                .WithMany()
                .HasForeignKey(r => r.TipoEntidadeVinculoId);

            builder
               .Property(e => e.EmpresaId)
               .HasColumnName("ch_cd_empresa")
               .HasColumnType("char(1)")
               .IsRequired(true);

            builder
                .HasOne(r => r.Empresa)
                .WithMany()
                .HasForeignKey(r => r.EmpresaId);

            builder
                .HasKey(e => new { e.TipoEntidadeVinculoId, e.EmpresaId });

            builder
                .ToTable("EmpresaEntidadeVinculo");
        }
    }
}
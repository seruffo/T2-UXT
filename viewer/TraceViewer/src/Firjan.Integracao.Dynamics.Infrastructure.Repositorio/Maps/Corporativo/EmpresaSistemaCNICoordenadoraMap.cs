using Microsoft.EntityFrameworkCore;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo
{
    public class EmpresaSistemaCNICoordenadoraMap : IEntityTypeConfiguration<EmpresaSistemaCNICoordenadora>
    {
        public void Configure(EntityTypeBuilder<EmpresaSistemaCNICoordenadora> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("in_sq_entidade")
               .IsRequired();

            builder.HasKey(a => a.Id);

            builder
                .Property(e => e.Sigla)
                .HasColumnName("vc_sg_empresacni");

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_nr_resolucaoexec_empresacni");

            builder
                .ToTable("EmprSistCNI");
        }
    }
}
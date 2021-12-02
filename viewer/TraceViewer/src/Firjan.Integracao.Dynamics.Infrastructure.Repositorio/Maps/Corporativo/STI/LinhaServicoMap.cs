using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.STI
{
    public class LinhaServicoMap : IEntityTypeConfiguration<LinhaServico>
    {
        public void Configure(EntityTypeBuilder<LinhaServico> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("in_sq_linhaservicost")
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_ds_linhaservicost");

            builder
              .Property(e => e.CodigoFuncao)
              .HasColumnName("ch_cd_funcaoservtec")
              .HasConversion(
                  v => v,
                  v => v.Trim());

            builder
               .HasOne(a => a.Funcao)
               .WithMany()
               .HasForeignKey(s => s.CodigoFuncao);

            builder
                .ToTable("LinhaServicoST");
        }
    }
}
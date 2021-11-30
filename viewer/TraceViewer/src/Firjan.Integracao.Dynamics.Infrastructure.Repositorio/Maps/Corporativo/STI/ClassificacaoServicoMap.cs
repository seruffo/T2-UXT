using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.STI
{
    public class ClassificacaoServicoMap : IEntityTypeConfiguration<ClassificacaoServico>
    {
        public void Configure(EntityTypeBuilder<ClassificacaoServico> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("in_sq_classificacaoservicost")
                .IsRequired(true);

            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_ds_classificacaoservicost")
                .IsRequired(true);

            builder
                .Property(e => e.LinhaServicoId)
                .HasColumnName("in_sq_linhaservicost")
                .HasColumnType("int")
                .IsRequired(true);

            builder
               .HasOne(a => a.LinhaServico)
               .WithMany()
               .HasForeignKey(s => s.LinhaServicoId)
               .IsRequired(true);

            builder
              .Property(e => e.AreaDN)
              .HasColumnName("ch_cd_areaDN")              
              .IsRequired(true);

            builder
                .ToTable("ClassificacaoServicoDNST");
        }
    }
}
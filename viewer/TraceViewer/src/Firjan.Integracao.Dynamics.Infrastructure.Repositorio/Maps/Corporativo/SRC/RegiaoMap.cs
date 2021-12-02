using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.SRC
{
    public class RegiaoMap : IEntityTypeConfiguration<Regiao>
    {
        public void Configure(EntityTypeBuilder<Regiao> builder)
        {
            builder
                .Property(e => e.Id)
                .HasMaxLength(4)
                .HasColumnName("in_sq_regiao")
                .HasMaxLength(4)
                .IsRequired(true);

            builder
                .Property(e => e.TipoRegiaoId)
                .HasColumnName("si_sq_tp_regiao")
                .HasMaxLength(2)
                .IsRequired(true);

            builder.HasOne(a => a.TipoRegiao)
                .WithMany()
                .HasForeignKey(s => s.TipoRegiaoId);

            builder
                .Property(e => e.EnderecoUnidadeId)
                .HasColumnName("in_sq_endereco")
                .HasColumnType("int")
                .HasMaxLength(4);

            builder.HasOne(a => a.EnderecoUnidade)
                .WithMany()
                .HasForeignKey(s => s.EnderecoUnidadeId);

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_nm_regiao")
                .HasMaxLength(100)
                .IsRequired(true);

            builder
                .ToTable("Regiao");
        }
    }
}
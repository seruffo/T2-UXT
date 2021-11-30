using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class TipoModalidadeMap : IEntityTypeConfiguration<TipoModalidade>
    {
        public void Configure(EntityTypeBuilder<TipoModalidade> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("si_sq_tipomodal")
               .HasColumnType("smallint")
               .HasMaxLength(2)
               .IsRequired(true);

            builder
                .HasKey(e => e.Id);

            builder
               .Property(e => e.Descricao)
               .HasColumnName("vc_ds_tipomodal")
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsRequired(true);

            builder
               .Property(e => e.Codigo)
               .HasColumnName("ch_cd_tipomodal")
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsRequired(true);

            builder
               .Property(e => e.CodigoDN)
               .HasColumnName("ch_cd_DN_tipomodal")
               .HasColumnType("char")
               .HasMaxLength(3)
               .IsRequired(true);

            builder
               .Property(e => e.ModalidadeId)
               .HasColumnType("smallint")
               .HasColumnName("si_sq_modalidade")
               .IsRequired(true)
               .HasMaxLength(2);

            builder
              .HasOne(a => a.Modalidade)
              .WithMany()
              .HasForeignKey(s => s.ModalidadeId)
              .IsRequired();

            builder
               .Property(e => e.AcaoId)
               .HasColumnType("char")
               .HasColumnName("ch_fg_acao_tipomodal")
               .IsRequired(true)
               .HasMaxLength(1);

            builder
              .Ignore(a => a.Acao);

            builder
                .ToTable("TipoModalidade");
        }
    }
}
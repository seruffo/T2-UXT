using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class ServicoMap : IEntityTypeConfiguration<Domain.Models.Corporativo.Gestor.Servico>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Corporativo.Gestor.Servico> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("in_sq_servoficial")
                .HasColumnType("int")
                .IsRequired(true);

            builder
                .HasKey(t => t.Id );

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_ds_servoficial")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder
              .Property(e => e.Atendimento)
              .HasColumnName("ch_fg_atendimento_servoficial")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Atendimento)Enums<char>.Parse<Atendimento>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.NaturezaServicoId)
              .HasColumnName("si_cd_naturezaservico")
              .HasColumnType("smallint");

            builder
              .HasOne(a => a.NaturezaServico)
              .WithMany()
              .HasForeignKey(s => s.NaturezaServicoId);

            builder
              .Property(e => e.Procedimento)
              .HasColumnName("vc_ds_procprep_servoficial")
              .HasColumnType("varchar")
              .HasMaxLength(300);

            builder
              .Property(e => e.MarcaHora)
              .HasColumnName("ch_fg_marcahr_servoficial")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.Objetivo)
              .HasColumnName("vc_ds_objetivo_servoficial");

            builder
              .Property(e => e.AreaId)
              .HasColumnName("ch_cd_area");

            builder
              .HasOne(a => a.Area)
              .WithMany()
              .HasForeignKey(s => s.AreaId);

            builder
                .ToTable("ServicoOficial");
        }
    }
}

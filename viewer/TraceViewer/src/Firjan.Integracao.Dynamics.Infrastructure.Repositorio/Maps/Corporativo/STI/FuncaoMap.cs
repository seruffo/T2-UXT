using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo
{
    public class FuncaoMap : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            builder
                .Property(e => e.Nome)
                .HasColumnName("vc_nm_funcaoservtec")
                .HasMaxLength(50)
                .IsRequired(true);

            builder
                .Ignore(r => r.Descricao);

            builder
                .Ignore(r => r.Id);

            builder
              .Property(e => e.Codigo)
              .HasColumnName("ch_cd_funcaoservtec")
              .HasConversion(
                  v => v,
                  v => v.Trim());

            builder
                .HasKey(c => c.Codigo);

            builder
                .Property(e => e.Sigla)
                .HasColumnName("vc_sg_funcaoservtec")
                .HasMaxLength(10);

            builder
                .Property(e => e.ParticipantePF)
                .HasColumnName("bi_fg_participantesPF_funcaoservtec")
                .HasColumnType("bit");

            builder
                .Property(e => e.ParticipantePJ)
                .HasColumnName("bi_fg_participantesPJ_funcaoservtec")
                .HasColumnType("bit");

            builder
                .Property(e => e.ValidaFavorecidoContratoPF)
                .HasColumnName("bi_fg_validaPFfavorecidocontrato_funcaoservtec")
                .HasColumnType("bit");

            builder
                .Property(e => e.Inicio)
                .HasColumnName("sd_dt_inicio_funcaoservtec")
                .HasDefaultValueSql("NULL")
                .HasColumnType("smalldatetime");

            builder
                .Property(e => e.Fim)
                .HasColumnName("sd_dt_fim_funcaoservtec")
                .HasDefaultValueSql("NULL")
                .HasColumnType("smalldatetime");

            builder
                .ToTable("FuncaoServicotecnologico");
        }
    }
}

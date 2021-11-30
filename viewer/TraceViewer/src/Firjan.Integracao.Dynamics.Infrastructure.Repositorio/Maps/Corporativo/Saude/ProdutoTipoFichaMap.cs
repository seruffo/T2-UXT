using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Saude
{
    public class ProdutoTipoFichaMap : IEntityTypeConfiguration<ProdutoTipoFicha>
    {
        public void Configure(EntityTypeBuilder<ProdutoTipoFicha> builder)
        {
            builder
                .HasKey(e => new { e.TipoFichaId, e.ProdutoId });

            builder
               .Property(e => e.TipoFichaId)
               .HasColumnName("in_sq_tpregatend")
               .HasColumnType("int")
               .IsRequired(true);

            builder
              .HasOne(a => a.TipoFicha)
              .WithMany()
              .HasForeignKey(s => s.TipoFichaId);

            builder
                .Property(e => e.ProdutoId)
                .HasColumnName("in_sq_classifservofic")
                .HasColumnType("int")
                .IsRequired(true);

            builder
              .HasOne(p => p.Produto)
              .WithMany()
              .HasForeignKey(s => s.ProdutoId);

            builder
               .Property(e => e.ServicoId)
               .HasColumnName("in_sq_servoficial")
               .HasColumnType("int");

            builder
              .HasOne(a => a.Servico)
              .WithMany()
              .HasForeignKey(s => s.ServicoId);

            builder
              .Property(e => e.GeraAtendimento)
              .HasColumnName("ch_fg_geraatendimento_servofictpreg")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Flag)Enums<char?>.Parse<Flag>(v))
              .IsUnicode(false);

            builder
                .ToTable("ServOficTpReg");
        }
    }
}
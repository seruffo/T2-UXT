using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class OdontogramaMap : IEntityTypeConfiguration<Odontograma>
    {
        public void Configure(EntityTypeBuilder<Odontograma> builder)
        {

            builder
              .Property(e => e.PessoaId)
              .HasColumnName("in_sq_pessoa");

            builder
              .HasOne(a => a.Pessoa)
              .WithMany()
              .HasForeignKey(s => s.PessoaId);

            builder
               .Property(e => e.NumeroDente)
               .HasColumnName("ti_nr_dente_odontograma");

            builder
               .Property(e => e.FiguraOdontogramaId)
               .HasColumnName("in_sq_figuraodontograma");

            builder
              .HasOne(a => a.FiguraOdontograma)
              .WithMany()
              .HasForeignKey(s => s.FiguraOdontogramaId);

            builder
                .HasKey(s => new { s.PessoaId, s.NumeroDente, s.FiguraOdontogramaId });

            builder
               .Property(e => e.AtendimentoId)
               .HasColumnName("ch_nr_atendOdont_referencia");

            builder
              .HasOne(a => a.Atendimento)
              .WithMany()
              .HasForeignKey(s => s.AtendimentoId);

            builder
              .Property(e => e.Operacao)
              .HasColumnName("ch_fg_operacao_odontograma")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Operacao)Enums<char?>.Parse<Operacao>(v));

            builder
              .Property(e => e.Radiografia)
              .HasColumnName("ch_fg_radiografia_odontograma")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Radiografia)Enums<char?>.Parse<Radiografia>(v));

            builder
              .Property(e => e.Raiz1)
              .HasColumnName("ch_fg_raiz1_odontograma")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Raiz)Enums<char?>.Parse<Raiz>(v));

            builder
              .Property(e => e.Raiz2)
              .HasColumnName("ch_fg_raiz2_odontograma")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Raiz)Enums<char?>.Parse<Raiz>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.Raiz3)
              .HasColumnName("ch_fg_raiz3_odontograma")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Raiz)Enums<char?>.Parse<Raiz>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.Face1)
              .HasColumnName("ch_fg_face1_odontograma")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Face)Enums<char?>.Parse<Face>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.Face2)
              .HasColumnName("ch_fg_face2_odontograma")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Face)Enums<char?>.Parse<Face>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.Face3)
              .HasColumnName("ch_fg_face3_odontograma")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Face)Enums<char?>.Parse<Face>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.Face4)
              .HasColumnName("ch_fg_face4_odontograma")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Face)Enums<char?>.Parse<Face>(v));

            builder
              .Property(e => e.Face5)
              .HasColumnName("ch_fg_face5_odontograma")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Face)Enums<char?>.Parse<Face>(v));

            builder
               .Property(e => e.DataRadiografia)
               .HasColumnName("sd_dt_radiografia_odontograma")
               .HasColumnType("smalldatetime")
               .HasMaxLength(4);

            builder
                .Ignore(e => e.Descricao);

            builder
                .ToTable("Odontograma");
        }
    }
}
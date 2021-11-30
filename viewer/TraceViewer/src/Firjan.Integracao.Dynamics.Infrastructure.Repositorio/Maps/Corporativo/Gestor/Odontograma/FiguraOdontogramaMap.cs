using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class FiguraOdontogramaMap : IEntityTypeConfiguration<FiguraOdontograma>
    {
        public void Configure(EntityTypeBuilder<FiguraOdontograma> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("in_sq_figuraodontograma")
               .HasColumnType("int")
               .HasMaxLength(4)
               .IsRequired(true);

            builder
                .HasKey(e => e.Id);

            builder
               .Property(e => e.Descricao)
               .HasColumnName("vc_ds_figuraodontograma")
               .HasColumnType("varchar")
               .HasMaxLength(40);

            builder
              .Property(e => e.TipoFigura)
              .HasColumnName("ch_tp_figuraodontograma")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoFigura)Enums<char?>.Parse<TipoFigura>(v))
              .IsUnicode(false)
              .IsRequired(true);

            builder
               .Property(e => e.Descricao)
               .HasColumnName("vc_ds_figuraodontograma")
               .HasColumnType("varchar")
               .HasMaxLength(40);

            builder
               .Property(e => e.Image)
               .HasColumnName("im_figuraodontograma")
               .HasColumnType("image");

            builder
              .Property(e => e.Local)
              .HasColumnName("ch_fg_local_figuraodontograma")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (Local)Enums<char?>.Parse<Local>(v))
              .IsUnicode(false);

            builder
             .Property(e => e.Tamanho)
             .HasColumnName("nc_vl_tamanho_figuraodontograma")
             .HasColumnType("numeric")
             .HasMaxLength(9);

            builder
               .Property(e => e.Face1)
               .HasColumnName("ch_fg_face1_figuraodontograma")
               .HasMaxLength(1)
               .HasConversion(
                   v => v.Id,
                   v => (Face)Enums<char?>.Parse<Face>(v))
               .IsUnicode(false);

            builder
               .Property(e => e.Face2)
               .HasColumnName("ch_fg_face2_figuraodontograma")
               .HasMaxLength(1)
               .HasConversion(
                   v => v.Id,
                   v => (Face)Enums<char?>.Parse<Face>(v))
               .IsUnicode(false);

            builder
               .Property(e => e.Face3)
               .HasColumnName("ch_fg_face3_figuraodontograma")
               .HasMaxLength(1)
               .HasConversion(
                   v => v.Id,
                   v => (Face)Enums<char?>.Parse<Face>(v))
               .IsUnicode(false);

            builder
               .Property(e => e.Face4)
               .HasColumnName("ch_fg_face4_figuraodontograma")
               .HasMaxLength(1)
               .HasConversion(
                   v => v.Id,
                   v => (Face)Enums<char?>.Parse<Face>(v))
               .IsUnicode(false);

            builder
               .Property(e => e.Face5)
               .HasColumnName("ch_fg_face5_figuraodontograma")
               .HasMaxLength(1)
               .HasConversion(
                   v => v.Id,
                   v => (Face)Enums<char?>.Parse<Face>(v))
               .IsUnicode(false);

            builder
               .Property(e => e.Raiz1)
               .HasColumnName("ch_fg_raiz1_figuraodontograma")
               .HasMaxLength(1)
               .HasConversion(
                   v => v.Id,
                   v => (Raiz)Enums<char?>.Parse<Raiz>(v))
               .IsUnicode(false);

            builder
               .Property(e => e.Raiz2)
               .HasColumnName("ch_fg_raiz2_figuraodontograma")
               .HasMaxLength(1)
               .HasConversion(
                   v => v.Id,
                   v => (Raiz)Enums<char?>.Parse<Raiz>(v))
               .IsUnicode(false);

            builder
               .Property(e => e.Raiz3)
               .HasColumnName("ch_fg_raiz3_figuraodontograma")
               .HasMaxLength(1)
               .HasConversion(
                   v => v.Id,
                   v => (Raiz)Enums<char?>.Parse<Raiz>(v))
               .IsUnicode(false);

            builder
               .Property(e => e.Sentido)
               .HasColumnName("ch_fg_sentido_figuraodontograma")
               .HasMaxLength(1)
               .HasConversion(
                   v => v.Id,
                   v => (Sentido)Enums<char?>.Parse<Sentido>(v))
               .IsUnicode(false);

            builder
               .Property(e => e.Ordem)
               .HasColumnName("ti_nr_ordem_figuraodontograma")
               .HasColumnType("tinyint");

            builder
                .ToTable("FiguraOdontograma");
        }
    }
}
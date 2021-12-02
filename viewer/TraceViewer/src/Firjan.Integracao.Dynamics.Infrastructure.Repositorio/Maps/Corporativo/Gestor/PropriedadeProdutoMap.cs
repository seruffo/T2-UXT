using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class PropriedadeProdutoMap : IEntityTypeConfiguration<Bairro>
    {
        public void Configure(EntityTypeBuilder<Bairro> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("in_sq_bairro")
               .HasColumnType("int")
               .HasMaxLength(4)
               .IsRequired(true);

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_ds_bairro")
              .HasColumnType("varchar")
              .HasMaxLength(60)
              .IsRequired(true);

            builder
              .Property(e => e.MunicipioId)
              .HasColumnName("in_sq_municipio")
              .IsRequired(true);

            builder.HasOne(a => a.Municipio)
              .WithMany()
              .HasForeignKey(s => s.MunicipioId)
              .IsRequired();

            builder
              .Property(e => e.CodigoLocalCorreio)
              .HasColumnName("ch_cd_LocalCorreio")
              .HasColumnType("char(8)")
              .HasMaxLength(8);

            builder
              .Property(e => e.CodigoBairroCorreio)
              .HasColumnName("ch_cd_BairroCorreio")
              .HasColumnType("char(8)")
              .HasMaxLength(8);

            builder
              .Property(e => e.Ativo)
              .HasColumnName("ch_fg_ativo_bairro")
              .HasColumnType("char(1)")
              .HasMaxLength(8);

            builder
              .Property(e => e.DescricaoAbreviada)
              .HasColumnName("vc_ds_abrev_bairro")
              .HasColumnType("varchar(36)")
              .HasMaxLength(36);

            builder
                .ToTable("Bairro");
        }
    }
}
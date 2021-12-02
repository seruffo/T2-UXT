using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class EnderecoUnidadeMap : IEntityTypeConfiguration<EnderecoUnidade>
    {
        public void Configure(EntityTypeBuilder<EnderecoUnidade> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("in_sq_endereco")
               .HasColumnType("int")
               .HasMaxLength(4);

            builder
             .Property(e => e.MunicipioId)
             .HasColumnName("in_sq_municipio")
             .HasColumnType("int");

            builder.HasOne(a => a.Municipio)
                .WithMany()
                .HasForeignKey(s => s.MunicipioId);

            builder
                 .Property(e => e.UnidadeNegocioId)
                 .HasColumnName("si_sq_unidnegocio")
                 .HasColumnType("smallint")
                 .HasMaxLength(2)
                 .IsRequired(true);

            builder.HasOne(a => a.UnidadeNegocio)
                .WithMany()
                .HasForeignKey(s => s.UnidadeNegocioId)
                .IsRequired();

            builder
             .Property(e => e.Logradouro)
             .HasColumnName("vc_ds_logradouro_endereco")
             .HasColumnType("varchar")
             .HasMaxLength(50)
             .IsRequired(true);

            builder
             .Property(e => e.BairroId)
             .HasColumnName("in_sq_bairro")
             .HasColumnType("int")
             .HasMaxLength(4);

            builder
                .HasOne(a => a.Bairro)
                .WithMany()
                .HasForeignKey(s => s.BairroId);

            builder
             .Property(e => e.Numero)
             .HasColumnName("vc_nr_logradouro_endereco")
             .HasColumnType("varchar")
             .HasMaxLength(7);

            builder
             .Property(e => e.Complemento)
             .HasColumnName("vc_ds_compl_endereco")
             .HasColumnType("varchar")
             .HasMaxLength(30);

            builder
             .Property(e => e.CEP)
             .HasColumnName("vc_cd_cep_endnacional")
             .HasColumnType("varchar")
             .HasMaxLength(8);

            builder
             .Property(e => e.PontoReferencia)
             .HasColumnName("vc_ds_ponto_refer_endereco")
             .HasColumnType("varchar")
             .HasMaxLength(255);

            builder
             .Property(e => e.Latitude)
             .HasColumnName("nc_vl_latitude_enderecounidade")
             .HasColumnType("numeric")
             .HasMaxLength(9);

            builder
             .Property(e => e.Longitude)
             .HasColumnName("nc_vl_longitude_enderecounidade")
             .HasColumnType("numeric")
             .HasMaxLength(9);

            builder
              .Property(e => e.TipoEndereco)
              .HasColumnName("ch_tp_enderecounidade")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoEndereco)Enums<char?>.Parse<TipoEndereco>(v))
              .IsUnicode(false);

            builder
                .ToTable("EnderecoUnidade");
        }
    }
}
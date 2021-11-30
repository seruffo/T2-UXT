using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor
{
    public class TipoClienteMap : IEntityTypeConfiguration<Domain.Models.Corporativo.Gestor.TipoCliente>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Corporativo.Gestor.TipoCliente> builder)
        {
            builder
               .Property(e => e.Id)
               .HasColumnName("ch_tp_tipocliente")
               .HasColumnType("char")
               .HasMaxLength(2)
               .IsRequired(true);

            builder
                .HasKey(e => e.Id);

            builder
              .Property(e => e.Descricao)
              .HasColumnName("vc_ds_tipocliente")
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .IsRequired(true);

            builder
              .Property(e => e.Qualificador)
              .HasColumnName("ch_ql_tipocliente")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (TipoPessoa)Enums<char?>.Parse<TipoPessoa>(v))
              .IsUnicode(false);

            builder
              .Property(e => e.EmpresaSistema)
              .HasColumnName("ch_fg_empsist_tipocliente")
              .HasMaxLength(1)
              .HasConversion(
                  v => v.Id,
                  v => (EmpresaSistema)Enums<char?>.Parse<EmpresaSistema>(v))
              .IsUnicode(false);

            builder
                .ToTable("TipoCliente");
        }
    }
}
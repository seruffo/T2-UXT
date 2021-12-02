using Firjan.Integracao.Dynamics.Domain.Models.Corporativo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo
{
    public class AtividadeMap : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnName("ch_cd_cnae")
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Descricao)
                .HasColumnName("vc_ds_atividade");

            builder
                .ToTable("Atividade");
        }
    }
}
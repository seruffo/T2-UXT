using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using FluentValidation.Results;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Protheus;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Protheus
{
    public class ProtheusContext : DbContext
    {
        public ProtheusContext(DbContextOptions<ProtheusContext> options)
            : base(options)
        {
        }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationFailure>();

            modelBuilder.Ignore<ValidationResult>();

            modelBuilder.ApplyConfiguration(new EmpresaMap());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
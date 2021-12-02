using Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.SGE;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using FluentValidation.Results;
using Firjan.Integracao.Dynamics.Domain.Models.SGE;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.SGE
{
    public class SGEContext : DbContext
    {
        public SGEContext(DbContextOptions<SGEContext> options) : base(options) { }

        public DbSet<ModalidadeCurso> ModalidadesCursos { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Coligada> Coligadas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<ValidationFailure>();

            modelBuilder
                .Ignore<ValidationResult>();

            modelBuilder
                .ApplyConfiguration(new ColigadaMap());

            modelBuilder
                .ApplyConfiguration(new AreaSGEMap()) ;

            modelBuilder
                .ApplyConfiguration(new ModalidadeCursoMap());

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
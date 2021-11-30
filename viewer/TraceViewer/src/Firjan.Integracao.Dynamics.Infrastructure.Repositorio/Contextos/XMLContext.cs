#region Usings
using Firjan.Integracao.Dynamics.Domain.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
#endregion

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Contextos
{
    public class XMLContext : DbContext
    {
        public DbSet<Trace> Traces { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // To remove the requests to the Migration History table
            Database.SetInitializer<XMLContext>(null);
            // To remove the plural names   
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

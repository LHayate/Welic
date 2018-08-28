using System.Data.Entity;
using Welic.Dominio.Models.Login.Mapeamentos;
using Welic.Infra.Mapeamentos;

namespace Welic.Api.Contexts
{
    public class WelicContext : DbContext
    {
        public WelicContext()
            :base("WelicConectionString")
        {

        }
        //public DbSet<Autor> Autores { get; set; }      
        public DbSet<LoginMap> Login { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new AutorMap());
            modelBuilder.Configurations.Add(new MapeamentoLogin());


        }
    }
}
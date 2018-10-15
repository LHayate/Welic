    using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Welic.Dominio.Models.Acesso.Mapeamentos;
    using Welic.Dominio.Models.Lives.Maps;
    using Welic.Dominio.Models.News.Maps;
    using Welic.Dominio.Models.Schedule.Maps;
    using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Infra.Mapeamentos;
using Welic.Infra.Migrations;

namespace Welic.Infra.Context
{
    

    public class AuthContext : DbContext// IdentityDbContext<ApplicationUser>
    {
        public AuthContext()
            : base("WelicDbContext")
            //: base("WelicDbContext",throwIfV1Schema: false)
        {
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, Configuration>());
        }
            
        public static AuthContext Create()
        {
            return new AuthContext();
        }

        public DbSet<DispositivosMap> Dispositivo { get; set; }
        public DbSet<UserMap> User { get; set; }
        public DbSet<LiveMap> Live { get; set; }
        public DbSet<ScheduleMap> Schedule { get; set; }
        public DbSet<NewsMap> News { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new MapeamentoDispositivos());
            modelBuilder.Configurations.Add(new MapeamentoUser());
            modelBuilder.Configurations.Add(new MapeamentoLive());
            modelBuilder.Configurations.Add(new MapeamentoSchedule());
            modelBuilder.Configurations.Add(new MappingNews());


        }
    }
}
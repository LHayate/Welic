    using System;
    using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Welic.Dominio.Models.Acesso.Mapeamentos;
    using Welic.Dominio.Models.Lives.Maps;
    using Welic.Dominio.Models.Menu.Mapeamentos;
    using Welic.Dominio.Models.News.Maps;
    using Welic.Dominio.Models.Schedule.Maps;
    using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Infra.Mapeamentos;
using Welic.Infra.Migrations;

namespace Welic.Infra.Context
{
    public class ApplicationUser : IdentityUser
    {        
        public Guid Guid { get; set; }                
        public string NickName { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }                        
        public byte[] ImagemPerfil { get; set; }
        public string Identity { get; set; }
        public DateTime LastAcess { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class AuthContext : DbContext//IdentityDbContext<ApplicationUser>
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
        public DbSet<GroupUserMap> GroupUser { get; set; }
        public DbSet<ProgramsMap> Programs { get; set; }

        public DbSet<MenuMap> Menus { get; set; }

        //public DbSet<ProgramGroupUserMap> ProgramGroupUser { get; set; }
        //public DbSet<ProgramUserMap> ProgramUser { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new MapeamentoDispositivos());
            modelBuilder.Configurations.Add(new MapeamentoUser());
            modelBuilder.Configurations.Add(new MapeamentoLive());
            modelBuilder.Configurations.Add(new MapeamentoSchedule());
            modelBuilder.Configurations.Add(new MappingNews());
            modelBuilder.Configurations.Add(new MappingGroupUser());
            modelBuilder.Configurations.Add(new MappingProgram());
            modelBuilder.Configurations.Add(new MappingMenu());




        }

        public System.Data.Entity.DbSet<Welic.Dominio.Models.Menu.Dtos.MenuDto> MenuDtoes { get; set; }
    }
}
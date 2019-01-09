using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Welic.Infra.Context;
using Welic.WebSite.Migrations;

namespace Welic.WebSite.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // Properties                        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegisterDate { get; set; }

        public string RegisterIP { get; set; }

        public DateTime LastAccessDate { get; set; }

        public string LastAccessIP { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool Disabled { get; set; }

        public bool AcceptEmail { get; set; }

        public string Gender { get; set; }

        public int LeadSourceID { get; set; }

        public double Rating { get; set; }
        public Guid Guid { get; set; }
                
        public int Profession { get; set; }

        [DefaultValue("https://welic.app/Arquivos/Icons/perfil_Padrao.png")]
        public string ImagePerfil { get; set; }
        public string Identity { get; set; }

        public int EmpresaId { get; set; } = 1;

        public bool Development { get; set; }

        [NotMapped]
        public bool RoleAdministrator { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}".Trim(), FirstName, LastName);
            }
        }

        [NotMapped]
        public string RatingClass
        {
            get
            {
                return "s" + Math.Round(Rating * 2);
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("WelicDbContext", throwIfV1Schema: false)
            //: base("WelicDbContext")
        {           
        }

        public static ApplicationDbContext Create()
        {







            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, WelicDatabaseInitializer>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
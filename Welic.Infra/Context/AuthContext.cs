﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Welic.Dominio.Models.Acesso.Mapeamentos;
using Welic.Dominio.Models.City.Map;
using Welic.Dominio.Models.Client.Map;
using Welic.Dominio.Models.ConfigApp.Map;
using Welic.Dominio.Models.Contratos.Map;
using Welic.Dominio.Models.Curso.Map;
using Welic.Dominio.Models.Departamento.Map;
using Welic.Dominio.Models.EBook.Map;
using Welic.Dominio.Models.Empresa.Map;
using Welic.Dominio.Models.Estacionamento.Map;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Marketplaces.Entityes;
using Welic.Dominio.Models.Menu.Mapeamentos;
using Welic.Dominio.Models.News.Maps;
using Welic.Dominio.Models.Schedule.Maps;
using Welic.Dominio.Models.Segurança.Map;
using Welic.Dominio.Models.Uploads.Maps;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;
using Infra.Mapeamentos;
using Infra.Migrations;

namespace Infra.Context
{
    public partial class AuthContext : DataContext
    {
        //static AuthContext()
        //{
        //    // Check if migrate database to latest version automatically (using automatic migration)
        //    // AutomaticMigrationDataLossAllowed is disabled by default (can be configred in web.config)
        //    // reference: http://stackoverflow.com/questions/10646111/entity-framework-migrations-enable-automigrations-along-with-added-migration

        //    if (WelicConfigurationManager.MigrateDatabaseToLatestVersion)
        //    {
        //        Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, Configuration>());
        //    }
        //    else
        //    {
        //        Database.SetInitializer<AuthContext>(null);
        //    }
        //}

       
        public AuthContext()
            //: base("ConnectionDbContext")
            : base("ConnectionDesenv")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, ConfigurationInstall<AuthContext>>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, Configuration>());
        }

        public static AuthContext Create()
        {
            return new AuthContext();
        }


        public DbSet<DispositivosMap> Dispositivo { get; set; }
        public DbSet<AspNetUser> User { get; set; }
        public DbSet<LiveMap> Live { get; set; }
        public DbSet<ScheduleMap> Schedule { get; set; }
        public DbSet<NewsMap> News { get; set; }
        public DbSet<PermissionMap> Permission { get; set; }
        public DbSet<ProgransMap> Prograns { get; set; }
        public DbSet<MenuMap> Menus { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryListingType> CategoryListingTypes { get; set; }
        public DbSet<CategoryStat> CategoryStats { get; set; }
        public DbSet<ContentPage> ContentPages { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<ListingMeta> ListingMetas { get; set; }
        public DbSet<ListingPicture> ListingPictures { get; set; }
        public DbSet<ListingReview> ListingReviews { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<ListingStat> ListingStats { get; set; }
        public DbSet<ListingType> ListingTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageParticipant> MessageParticipants { get; set; }
        public DbSet<MessageReadState> MessageReadStates { get; set; }
        public DbSet<MessageThread> MessageThreads { get; set; }
        public DbSet<MetaCategory> MetaCategories { get; set; }
        public DbSet<MetaField> MetaFields { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<SettingDictionary> SettingDictionaries { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<StripeConnect> StripeConnects { get; set; }
        public DbSet<StripeTransaction> StripeTransactions { get; set; }
        public DbSet<UploadsMap> Uploads { get; set; }
        public DbSet<CursoMap> Curso { get; set; }
        public DbSet<EBookMap> EBook { get; set; }
        public DbSet<ConfigAppMap> ConfigApp { get; set; }
        public DbSet<FavoriteLiveMap> FavoriteLive { get; set; }
        public DbSet<PessoaMap> Pessoa { get; set; }
        public DbSet<CityMap> City { get; set; }
        public DbSet<EmpresaMap> Empresa { get; set; }
        public DbSet<DepartamentoMap> Departamento { get; set; }
        public DbSet<DepartamentoUsuario> DepartamentoUsuario { get; set; }
        public DbSet<EstacionamentoMap> Estacionamento { get; set; }
        public DbSet<EstacionamentoVagasMap> EstacionamentoVagas { get; set; }
        public DbSet<SolicitacoesVagasMap> SolicitacoesVagas { get; set; }
        public DbSet<VeiculosMap> Veiculos { get; set; }
        public DbSet<SolicitacoesEstacionamentoMap> SolicitacoesEstacionamento { get; set; }
        public DbSet<SolicitacoesVagasLiberadasMap> SolicitacoesVagasLiberadas { get; set; }
        //public DbSet<ContratosMap> Contratos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions
                .Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions
                .Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new MappingDispositivos());
            modelBuilder.Configurations.Add(new MappingUser());
            modelBuilder.Configurations.Add(new MappingLive());
            modelBuilder.Configurations.Add(new MappingSchedule());
            modelBuilder.Configurations.Add(new MappingNews());            
            modelBuilder.Configurations.Add(new MappingProgram());
            modelBuilder.Configurations.Add(new MappingMenu());
            modelBuilder.Configurations.Add(new MappingAspNetRole());
            modelBuilder.Configurations.Add(new MappingAspNetUserClaim());
            modelBuilder.Configurations.Add(new MappingAspNetUserLogin());
            modelBuilder.Configurations.Add(new MappingCategoryListingType());
            modelBuilder.Configurations.Add(new MappingCategory());
            modelBuilder.Configurations.Add(new MappingCategoryStat());
            modelBuilder.Configurations.Add(new MappingContentPage());
            modelBuilder.Configurations.Add(new MappingEmailTemplate());
            modelBuilder.Configurations.Add(new MappingListing());
            modelBuilder.Configurations.Add(new MappingListingMeta());
            modelBuilder.Configurations.Add(new MappingListingPicture());
            modelBuilder.Configurations.Add(new MappingListingReview());
            modelBuilder.Configurations.Add(new MappingListingStat());
            modelBuilder.Configurations.Add(new MappingListingType());
            modelBuilder.Configurations.Add(new MappingMessage());
            modelBuilder.Configurations.Add(new MappingMessageParticipant());
            modelBuilder.Configurations.Add(new MappingMessageReadState());
            modelBuilder.Configurations.Add(new MappingMessageThread());
            modelBuilder.Configurations.Add(new MappingMetaCategory());
            modelBuilder.Configurations.Add(new MappingMetaField());
            modelBuilder.Configurations.Add(new MappingOrder());
            modelBuilder.Configurations.Add(new MappingPicture());
            modelBuilder.Configurations.Add(new MappingSettingDictionary());
            modelBuilder.Configurations.Add(new MappingSetting());
            modelBuilder.Configurations.Add(new MappingStripeConnect());
            modelBuilder.Configurations.Add(new MappingStripeTransaction());
            modelBuilder.Configurations.Add(new MappingUploads());
            modelBuilder.Configurations.Add(new MappingCursos());
            modelBuilder.Configurations.Add(new MappingEBook());
            modelBuilder.Configurations.Add(new MappingConfigApp());
            modelBuilder.Configurations.Add(new MappingFavoriteLive());
            modelBuilder.Configurations.Add(new MappingPessoa());
            modelBuilder.Configurations.Add(new MappingCity());
            modelBuilder.Configurations.Add(new MappingEmpresa());
            modelBuilder.Configurations.Add(new MappingPermission());
            modelBuilder.Configurations.Add(new MappingDepartamento());
            modelBuilder.Configurations.Add(new MappingEstacionamento());
            modelBuilder.Configurations.Add(new MappingSolicitacoesVagas());
            modelBuilder.Configurations.Add(new MappingVeiculos());
            modelBuilder.Configurations.Add(new MappingSolicitacoesEstacionamento());
            modelBuilder.Configurations.Add(new MappingSolicitacoesVagasLiberadas());


        }
    }
}
using System.Globalization;
using System.IO;
using System.Web;
using Welic.Dominio.Core;
using Welic.Dominio.Enumerables;
using Welic.Dominio.Models.Empresa.Map;
using Welic.Dominio.Models.Marketplaces.Entityes;
using Welic.Dominio.Models.Menu.Mapeamentos;
using Welic.Dominio.Models.Segurança.Map;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Repository.Pattern.Infrastructure;
using Welic.Infra.Context;

namespace Welic.Infra.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Welic.Infra.Context.AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = WelicConfigurationManager.AutomaticMigrationDataLossAllowed; 
            //ContextKey = "Welic.Infra.Context.AuthContext";

            //TargetDatabase = new System.Data.Entity.Infrastructure.DbConnectionInfo("WelicDbContext");
        }

        protected override void Seed(AuthContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            base.Seed(context);
            InstallEmpresa(context);
            InstallProgramas(context);
            InstallPermission(context);
            InstallSettings(context);
            //InstallEmailTemplates(context);
            InstallMenu(context);            
            //InstallCategories(context);
            //InstallCategoryTypes(context);
            //InstallSampleData(context);
            //InstallPictures(context);
            InstallStripe(context);
            InstallDisqus(context);
            InstallRoles(context);
            //InstallListingTypes(context);

            context.SaveChanges();
        }

        private void InstallProgramas(AuthContext context)
        {
            context.Prograns.AddOrUpdate(
                new ProgransMap()
                {
                    IdProgram = 1,
                    Description = "Cadastro de Pessoas", 
                    Type = TypeProgram.Cadastro,
                    Active = true,     
                    ObjectState = context.Prograns.Count(x=> x.IdProgram == 1) <= 0 ? ObjectState.Added
                        : ObjectState.Modified
                },
                new ProgransMap()
                {
                    IdProgram = 2,
                    Description = @"Cadastro de Estacionamento",
                    Type = TypeProgram.Cadastro,
                    Active = true,
                    ObjectState = context.Prograns.Count(x => x.IdProgram == 2) <= 0 ? ObjectState.Added
                        : ObjectState.Modified
                },
                new ProgransMap()
                {
                    IdProgram = 3,
                    Description = @"Cadastro de Vagas de Estacionamento",
                    Type = TypeProgram.Cadastro,
                    Active = true,
                    ObjectState = context.Prograns.Count(x => x.IdProgram == 3) <= 0 ? ObjectState.Added
                        : ObjectState.Modified
                }
                );
            context.SaveChanges();
        }

        private void InstallPermission(AuthContext context)
        {
            var users = context.User.Select(x => x).Where(x => x.Development).ToList();
            var programs = context.Prograns.Select(x => x).Where(x => x.Active).ToList();

            foreach (var user in users)
            {
                var permissions = context.Permission.Select(x => x).Where(x => x.IdUser == user.Id).ToList();
                permissions.ForEach(x=> x.ObjectState = ObjectState.Deleted);
                context.Permission.RemoveRange(permissions);

                context.SaveChanges();

                var permissions1 = context.Permission.Select(x => x).Where(x => x.IdUser == user.Id).ToList();
                foreach (var program in programs)
                {                    
                    context.Permission.Add(
                        new PermissionMap()
                        {
                            Active = true,
                            All = true,
                            Delete = true,
                            IdProgram = program.IdProgram,
                            IdUser = user.Id,
                            Insert = true,
                            Read = true,
                            Update = true,  
                            ObjectState = ObjectState.Added
                        }
                    );
                }
               
            }
        }

        private void InstallEmpresa(AuthContext context)
        {
            context.Empresa.AddOrUpdate(new EmpresaMap()
            {
                Cep = "00000000",
                Cidade = "Uberaba",
                Email = "lucasrr59@gmail.com",
                Endereco = "Inicial para ter na Welic",
                Cnpj = "Ainda não criado ",
                Fone = 991996194,
                Fone1 = 991996194,
                ConfigMailEnableSsl = true,
                FoneFax = null,
                Ie = "000123132",
                Uf = "MG",
                RazaoSocial = "WElic",
                //ObjectState = context.Empresa.Count(x => x.Ie == "000123132" && x.RazaoSocial == "WElic") <= 0 ? ObjectState.Added
                //: ObjectState.Modified
            });
        }

        //private AspNetUser CreateUser()
        //{
        //    var user = new AspNetUser
        //    {
        //        NickName = "Administrator",
        //        FirstName = "Administrator",
        //        Email = "admin@welic.app",
        //        RegisterDate = DateTime.Now,                
        //        LastAccessDate = DateTime.Now,                
        //        Rating = 4
        //    };

        //    using (var context = new AuthContext())
        //    {
        //        context.Database.Initialize(true);
        //        context.SaveChanges();

        //        //var userManager = new ApplicationUserManager(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(context));

        //        // Create role/user and redirect
        //        var userRole = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(Enum_UserType.Administrator.ToString());
        //        //var roleResult = RoleManager.Create(userRole);
        //        //var result = userManager.Create(user, _installModel.Password);
        //        var roleAdded = userManager.AddToRole(user.Id, Enum_UserType.Administrator.ToString());
        //    }

        //    // Copy profile image
        //    var pathFrom = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Imagens/images/sample/profile"), "admin.jpg");
        //    var pathTo = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Imagens/images/profile"), string.Format("{0}.{1}", user.Id, "jpg"));
        //    File.Copy(pathFrom, pathTo, true);

        //    return user;
        //}

        private void InstallRoles(AuthContext context)
        {
            
        }

        private void InstallMenu(AuthContext context)
        {
            //TODO: Criar Menus Automaticos
            context.Menus.AddOrUpdate(
                new MenuMap()
                {
                    Id = 1, Title = "Dashboard", IconMenu = "dashboard",
                    ObjectState = context.Menus.Count(x => x.Id == 1 && x.Title == "Dashboard") <= 0
                        ? ObjectState.Added
                        : ObjectState.Modified, Action = "index", Controller = "Manage", Nivel = "1"
                },
                new MenuMap()
                {
                    Id = 2, Title = "Marketplace", IconMenu = "local_grocery_store",
                    ObjectState = context.Menus.Count(x => x.Id == 2 && x.Title == "Marketplace") <= 0
                        ? ObjectState.Added
                        : ObjectState.Modified,  Action = "index", Controller = "Manage", Nivel = "1"
                },

                new MenuMap()
                {
                    Id = 3, Title = "User", IconMenu = "person",
                    ObjectState = context.Menus.Count(x => x.Id == 3 && x.Title == "User") <= 0
                        ? ObjectState.Added
                        : ObjectState.Modified, Action = "", Controller = "", Nivel = "1"
                },
                new MenuMap()
                {
                    Id = 4, Title = "Profile", IconMenu = "face",
                    ObjectState = context.Menus.Count(x => x.Id == 4 && x.Title == "Profile") <= 0
                        ? ObjectState.Added
                        : ObjectState.Modified,
                    Action = "UserProfile", Controller = "Manage", Nivel = "2", DadId = 3
                },
                new MenuMap()
                {
                    Id = 5, Title = "MailBox", IconMenu = "local_post_office",
                    ObjectState = context.Menus.Count(x => x.Id == 5 && x.Title == "MailBox") <= 0
                        ? ObjectState.Added
                        : ObjectState.Modified,
                    Action = "Messages", Controller = "Manage", Nivel = "2", DadId = 3
                },
                new MenuMap()
                {
                    Id = 6, Title = "Change Password", IconMenu = "vpn_key",
                    ObjectState = context.Menus.Count(x => x.Id == 6 && x.Title == "Change Password") <= 0
                        ? ObjectState.Added
                        : ObjectState.Modified,
                    Action = "ChangePassword", Controller = "Manage", Nivel = "2", DadId = 3
                },

                new MenuMap()
                {
                    Id = 7, Title = "Finanças", IconMenu = "vpn_key", 
                    ObjectState = context.Menus.Count(x => x.Id == 7 && x.Title == "Finanças") <= 0
                        ? ObjectState.Added
                        : ObjectState.Modified,
                    Action = "",Controller = "", Nivel = "1"
                },
                new MenuMap()
                {
                    Id = 8, Title = "Payments", IconMenu = "payment",
                    ObjectState = context.Menus.Count(x => x.Id == 8 && x.Title == "Payments") <= 0
                        ? ObjectState.Added
                        : ObjectState.Modified,
                    Action = "PaymentSetting", Controller = "Payment", Nivel = "2", DadId = 7
                },
                new MenuMap()
                {
                    Id = 9, Title = "Transaction", IconMenu = "attach_money",
                    ObjectState = context.Menus.Count(x => x.Id == 9 && x.Title == "Transaction") <= 0
                        ? ObjectState.Added
                        : ObjectState.Modified,
                    Action = "Transaction", Controller = "Payment", Nivel = "2", DadId = 7
                },
                new MenuMap()
                {
                    Id = 10, Title = "Orders", IconMenu = "shopping_cart",
                    ObjectState = context.Menus.Count(x => x.Id == 10 && x.Title == "Orders") <= 0
                        ? ObjectState.Added
                        : ObjectState.Modified,
                    Action = "Orders", Controller = "Payment", Nivel = "2", DadId = 7
                },

                new MenuMap()
                {
                    Id = 11, Title = "Suport", IconMenu = "person_pin",
                    ObjectState = context.Menus.Count(x => x.Id == 11 && x.Title == "Suport") <= 0
                        ? ObjectState.Added
                        : ObjectState.Modified,
                    Action = "suport", Controller = "Manage", Nivel = "1"
                },

                new MenuMap
                {
                    Id = 12, Title = "List of Lives", IconMenu = "",
                    ObjectState = context.Menus.Count(x => x.Id == 12 && x.Title == "List of Lives") <= 0
                        ? ObjectState.Added
                        : ObjectState.Modified,
                    Action = "index", Controller = "listing", Nivel = "1"
                },

                new MenuMap
                {
                    Id = 13,
                    Title = "Admin",
                    IconMenu = "",
                    ObjectState = context.Menus.Count(x => x.Id == 13 && x.Title == "Admin") <= 0
                        ? ObjectState.Added
                        : ObjectState.Modified,
                    Action = "Manage",
                    Controller = "Admin",
                    Nivel = "1"
                }
            );
        }

        private void InstallSettings(AuthContext context)
        {
                context.Settings.AddOrUpdate(new Setting()
                {
                    ID = 1,
                    Name = "Welic",
                    Description = "Create your own peer to peer market place in 5 minutes!",
                    Slogan = "Slogan...",
                    SearchPlaceHolder = "Search...",
                    EmailContact = "contato@welic.app",
                    Version = "1.0",
                    Currency = "DKK",
                    TransactionFeePercent = 1,
                    TransactionMinimumSize = 10,
                    TransactionMinimumFee = 10,
                    EmailConfirmedRequired = false,
                    Theme = "Default",
                    DateFormat = DateTimeFormatInfo.CurrentInfo.ShortDatePattern,
                    TimeFormat = DateTimeFormatInfo.CurrentInfo.ShortTimePattern,
                    ListingReviewEnabled = true,
                    ListingReviewMaxPerDay = 5,
                    Created = DateTime.Now,
                    LastUpdated = DateTime.Now,
                    ObjectState = context.Settings.Count(x => x.ID == 1) <= 0 ? ObjectState.Added: ObjectState.Modified
                });
            
        }

        private void InstallEmailTemplates(AuthContext context)
        {
            context.EmailTemplates.AddOrUpdate(new EmailTemplate()
            {
                Slug = "signup",
                Subject = "Sign up",
                Body = @"<p>Hi there,</p>
                        <h1>Welcome to {SiteName}</h1>
                        <p>Thanks for your sign up.</p>
                        <table>
	                        <tbody>
		                        <tr>
			                        <td class=""padding"">
			                        <p><a class=""btn-primary"" href=""{CallbackUrl}"">Please confirm your email by clicking this link</a></p>
			                        </td>
		                        </tr>
	                        </tbody>
                        </table>",
                SendCopy = true,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                //ObjectState = context.EmailTemplates.Count(x => x.Slug.Equals("signup")) <= 0 ? ObjectState.Added : ObjectState.Modified
            });

            context.EmailTemplates.AddOrUpdate(new EmailTemplate()
            {
                Slug = "forgotpassword",
                Subject = "Forgot Password",
                Body = @"<p>Hi there,</p>
                        <p>You can use the link below to reset your password.</p>
                        <table>
	                        <tbody>
		                        <tr>
			                        <td class=""padding"">
			                        <p><a class=""btn-primary"" href=""{CallbackUrl}"">Please reset your password by clicking this link</a></p>
			                        </td>
		                        </tr>
	                        </tbody>
                        </table>",
                SendCopy = true,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
               // ObjectState = context.EmailTemplates.Count(x => x.Slug.Equals("forgotpassword")) <= 0 ? ObjectState.Added : ObjectState.Modified
            });

            context.EmailTemplates.AddOrUpdate(new EmailTemplate()
            {
                Slug = "privatemessage",
                Subject = "Private Message",
                Body = @"<p>Hi there,</p>
			            <p>You got a new message as below.</p>
			            <table>
				            <tbody>
					            <tr>
						            <td class=""padding"">
						            <h4>{Message}</h4>
						            </td>
					            </tr>
				            </tbody>
			            </table>",
                SendCopy = true,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
               // ObjectState = context.EmailTemplates.Count(x => x.Slug.Equals("privatemessage")) <= 0 ? ObjectState.Added : ObjectState.Modified
            });
        }

        //TODO: Revisar este processo de Install Samples
        private void InstallSampleData(AuthContext context)
        {
            context.Listings.AddOrUpdate(new Listing()
            {
                Title = "Preganancy Massage",
                Description = @"During an hour waiting women be allowed to experience total relaxation and relief of aches. The therapist works gently with the pregnant body to loosen up tight muscles, give peace to the nervous system, increase blood circulation and reduce pain in the body.",
                CategoryID = 1,
                ListingTypeID = 1,
                //UserID = user.Id,
                Price = 100,
                Currency = "DKK",
                ContactName = "Celia",
                ContactEmail = "demo@com",
                //IP = HttpContext.Current.Request.GetVisitorIP(),
                Location = "Marievej 1, 2900 Hellerup, Danmark",
                Latitude = 55.730344,
                Longitude = 12.5767257,
                Expiration = DateTime.MaxValue.Date,
                Active = true,
                Enabled = true,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = context.Settings.Count(x => x.ID == 1) <= 0 ? ObjectState.Added : ObjectState.Modified
            });

            context.Listings.AddOrUpdate(new Listing()
            {
                Title = "Facial Treatment",
                Description = @"Classic 45 min Facial treat: Cleaning, skin analysis, AHA-PHA peeling, light deep cleanse...",
                CategoryID = 2,
                ListingTypeID = 1,
                //UserID = user.Id,
                Price = 249,
                Currency = "DKK",
                ContactName = "The Facial Lounge",
                ContactEmail = "demo@com",
                //IP = HttpContext.Current.Request.GetVisitorIP(),
                Location = "Sankt Jørgens Allé 5, København V, Danmark",
                Latitude = 55.6735479,
                Longitude = 12.559128399999963,
                Active = true,
                Enabled = true,
                Expiration = DateTime.MaxValue.Date,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.Listings.AddOrUpdate(new Listing()
            {
                Title = "60min Moisturizing face treatment",
                Description = @"During an hour waiting women be allowed to experience total relaxation and relief of aches. The therapist works gently with the pregnant body to loosen up tight muscles, give peace to the nervous system, increase blood circulation and reduce pain in the body.",
                CategoryID = 2,
                ListingTypeID = 1,
                //UserID = user.Id,
                Price = 219,
                Currency = "DKK",
                ContactName = "Clinique Margarita",
                ContactEmail = "demo@com",
                //IP = HttpContext.Current.Request.GetVisitorIP(),
                Location = "Studiestræde 18 København K",
                Latitude = 55.6786854,
                Longitude = 12.5694609,
                Active = true,
                Enabled = true,
                Expiration = DateTime.MaxValue.Date,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.Listings.AddOrUpdate(new Listing()
            {
                Title = "Eyelash extensions",
                Description = @"Give the lashes fullness and length with eyelash extensions. 50-100 fiber hair attached individually at one's own lashes for a natural look. The treatment takes about 90 minutes.",
                CategoryID = 2,
                ListingTypeID = 1,
                //UserID = user.Id,
                Price = 375,
                Currency = "DKK",
                ContactName = "Beauty And Accessories",
                ContactEmail = "demo@com",
                //IP = HttpContext.Current.Request.GetVisitorIP(),
                Location = "Henrik Steffens Vej 6, 1866 Frederiksberg C, Danmark",
                Latitude = 55.6779527,
                Longitude = 12.538388800000007,
                Active = true,
                Enabled = true,
                Expiration = DateTime.MaxValue.Date,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.Listings.AddOrUpdate(new Listing()
            {
                Title = "60min Massage for 2 persons - 3 types to choose",
                Description = @"Take your partner by the arm and enjoy an hour of relaxing parma sage. Choose freely between wellness, Aromatherapy- and hotstone massage. By wellness massage using long, smooth movements of the upper layers of the muscles of mental and physical relaxation. Fragrant oils from flowers and herbs used in Aroma Therapy massage for relaxation and enjoyment. By hotstone massage used heated lava rocks to smoothen the muscles, then loosen tensions and aches.",
                CategoryID = 1,
                ListingTypeID = 1,
                //UserID = user.Id,
                Price = 549,
                Currency = "DKK",
                ContactName = "Healingstedet",
                ContactEmail = "demo@com",
                //IP = HttpContext.Current.Request.GetVisitorIP(),
                Location = "Liflandsgade 8 København 2300",
                Latitude = 55.6608952,
                Longitude = 12.6031471,
                Active = true,
                Enabled = true,
                Expiration = DateTime.MaxValue.Date,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.Listings.AddOrUpdate(new Listing()
            {
                Title = "1 hour shiatsu massage",
                Description = @"Let the body come into focus with an hour shiatsu massage that combines deep pressure and long runs. The treatment allows the body to sink into a relaxed state, and it is therefore suitable for stress-related genes and other long-term imbalances. The massage takes place on a mattress on the floor, and it is important to be dressed in comfortable clothes, so the body can completely relax.",
                CategoryID = 1,
                ListingTypeID = 1,
                //UserID = user.Id,
                Price = 249,
                Currency = "DKK",
                ContactName = "Zen-Shiatsu",
                ContactEmail = "demo@com",
                //IP = HttpContext.Current.Request.GetVisitorIP(),
                Location = "Havnegade 43, st. th. København K 1058",
                Latitude = 55.677783,
                Longitude = 12.591222,
                Active = true,
                Enabled = true,
                Expiration = DateTime.MaxValue.Date,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.Listings.AddOrUpdate(new Listing()
            {
                Title = "Hot Stone Massage",
                Description = @"With heated lava stones are the body's tense muscles supple and ready for a deep massage. The massage works with aches and tension, and brings blood to the muscles for a pain-relieving effect and increased flexibility.",
                CategoryID = 1,
                ListingTypeID = 1,
                //UserID = user.Id,
                Price = 249,
                Currency = "DKK",
                ContactName = "Healingstedet",
                ContactEmail = "demo@com",
                //IP = HttpContext.Current.Request.GetVisitorIP(),
                Location = "Liflandsgade 8, 2300 København",
                Latitude = 55.660869,
                Longitude = 12.603241,
                Active = true,
                Enabled = true,
                Expiration = DateTime.MaxValue.Date,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.Listings.AddOrUpdate(new Listing()
            {
                Title = "Facial massage",
                Description = @"30 mins facial massage",
                CategoryID = 1,
                ListingTypeID = 1,
                //UserID = user.Id,
                Price = 199,
                Currency = "DKK",
                ContactName = "Natasha's Wellness",
                ContactEmail = "demo@com",
                //IP = HttpContext.Current.Request.GetVisitorIP(),
                Location = "Blegdamsvej 112A 2100 København",
                Latitude = 55.697579,
                Longitude = 12.574109,
                Active = true,
                Enabled = true,
                Expiration = DateTime.MaxValue.Date,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.Listings.AddOrUpdate(new Listing()
            {
                Title = "Waxing",
                Description = @"Choose one of below for waxing: arms / thighs / Lower armpit / Upper lip / Upper lip and chin",
                CategoryID = 3,
                ListingTypeID = 1,
                //UserID = user.Id,
                Price = 249,
                Currency = "DKK",
                ContactName = "Mind Body and Soul",
                ContactEmail = "demo@com",
                //IP = HttpContext.Current.Request.GetVisitorIP(),
                Location = "Blegdamsvej 84, St. tv , København Ø 2100",
                Latitude = 55.696199,
                Longitude = 12.571483,
                Active = true,
                Enabled = true,
                Expiration = DateTime.MaxValue.Date,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });
        }

        private void InstallListingTypes(AuthContext context)
        {
            context.ListingTypes.AddOrUpdate(new ListingType()
            {
                Name = "Offer",
                ButtonLabel = "Book",
                OrderTypeID = (int)Enum_ListingOrderType.DateRange,
                OrderTypeLabel = "Number of days",
                PriceUnitLabel = "Per day",
                PaymentEnabled = true,
                PriceEnabled = true,
                ShippingEnabled = false,
                ObjectState = ObjectState.Added
            });

            
        }

        private void InstallCategories(AuthContext context)
        {
            context.Categories.AddOrUpdate(new Category()
            {
                Name = "Massage",
                Description = "Massage",
                Parent = 0,
                Enabled = true,
                Ordering = 0,
                ObjectState = ObjectState.Added
            });

            context.Categories.AddOrUpdate(new Category()
            {
                Name = "Facial",
                Description = "Facial Care",
                Parent = 0,
                Enabled = true,
                Ordering = 1,
                ObjectState = ObjectState.Added
            });

            context.Categories.AddOrUpdate(new Category()
            {
                Name = "Skin Care",
                Description = "Skin Care",
                Parent = 0,
                Enabled = true,
                Ordering = 2,
                ObjectState = ObjectState.Added
            });
        }

        private void InstallCategoryTypes(AuthContext context)
        {
            context.CategoryListingTypes.AddOrUpdate(new CategoryListingType()
            {
                CategoryID = 1,
                ListingTypeID = 1,
                ObjectState = ObjectState.Added
            });

            context.CategoryListingTypes.AddOrUpdate(new CategoryListingType()
            {
                CategoryID = 2,
                ListingTypeID = 1,
                ObjectState = ObjectState.Added
            });

            context.CategoryListingTypes.AddOrUpdate(new CategoryListingType()
            {
                CategoryID = 3,
                ListingTypeID = 1,
                ObjectState = ObjectState.Added
            });
        }

        private void InstallPictures(AuthContext context)
        {
            for (int i = 1; i <= 9; i++)
            {
                context.Pictures.AddOrUpdate(new Picture()
                {
                    MimeType = "image/jpeg",
                    ObjectState = ObjectState.Added
                });

                context.SaveChanges();

                context.ListingPictures.AddOrUpdate(new ListingPicture()
                {
                    ListingID = i,
                    PictureID = i,
                    ObjectState = ObjectState.Added
                });

                // Copy files
                var pathFrom = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Imagens/images/sample/listing"), string.Format("{0}.{1}", i.ToString("00000000"), "jpg"));
                var pathTo = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Imagens/images/listing"), string.Format("{0}.{1}", i.ToString("00000000"), "jpg"));
                File.Copy(pathFrom, pathTo, true);
            }
        }

        private void InstallStripe(AuthContext context)
        {
            context.SettingDictionaries.AddOrUpdate(new SettingDictionary()
            {
                SettingID = 1,
                Name = "StripeApiKey",
                Value = "sk_test_kUNQFEh3YLbEFEa38tbeMJLV",
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.SettingDictionaries.AddOrUpdate(new SettingDictionary()
            {
                SettingID = 1,
                Name = "StripePublishableKey",
                Value = "pk_test_EfbP8SfcALEJ8Jk2JxtSxmqe",
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.SettingDictionaries.AddOrUpdate(new SettingDictionary()
            {
                SettingID = 1,
                Name = "StripeClientID",
                Value = "ca_6Rh18px61rjCEZIav5ItunZ1mKD8YjvU",
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });
        }

        private void InstallDisqus(AuthContext context)
        {
            context.SettingDictionaries.Add(new SettingDictionary()
            {
                SettingID = 1,
                Name = "Disqus_ShortName",
                Value = "beyourmarket",
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });
        }
        
    }
}

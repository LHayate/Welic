using System.Globalization;
using System.IO;
using System.Web;
using Welic.Dominio.Core;
using Welic.Dominio.Enumerables;
using Welic.Dominio.Models.Marketplaces.Entityes;
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
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed =true;
            ContextKey = "Welic.Infra.Context.AuthContext";

            //TargetDatabase = new System.Data.Entity.Infrastructure.DbConnectionInfo("WelicDbContext");
        }

        protected override void Seed(Welic.Infra.Context.AuthContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            base.Seed(context);
            InstallSettings(context);
            InstallEmailTemplates(context);
            InstallListingTypes(context);
                      
            InstallCategories(context);
            InstallCategoryTypes(context);
            InstallSampleData(context);
            InstallPictures(context);
            InstallStripe(context);
            InstallDisqus(context);
            
        }
        
       

        private void InstallSettings(AuthContext context)
        {
                context.Settings.Add(new Setting()
                {
                    ID = 1,
                    Name = "BeYourMarket",
                    Description = "Create your own peer to peer market place in 5 minutes!",
                    Slogan = "Slogan...",
                    SearchPlaceHolder = "Search...",
                    EmailContact = "hello@com",
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
                    ObjectState = ObjectState.Added
                });
            
        }

        private void InstallEmailTemplates(AuthContext context)
        {
            context.EmailTemplates.Add(new EmailTemplate()
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
                ObjectState = ObjectState.Added
            });

            context.EmailTemplates.Add(new EmailTemplate()
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
                ObjectState = ObjectState.Added
            });

            context.EmailTemplates.Add(new EmailTemplate()
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
                ObjectState = ObjectState.Added
            });
        }

        private void InstallSampleData(AuthContext context)
        {
            context.Listings.Add(new Listing()
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
                ObjectState = ObjectState.Added
            });

            context.Listings.Add(new Listing()
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
                Location = "Sankt J�rgens All� 5, K�benhavn V, Danmark",
                Latitude = 55.6735479,
                Longitude = 12.559128399999963,
                Active = true,
                Enabled = true,
                Expiration = DateTime.MaxValue.Date,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.Listings.Add(new Listing()
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
                Location = "Studiestr�de 18 K�benhavn K",
                Latitude = 55.6786854,
                Longitude = 12.5694609,
                Active = true,
                Enabled = true,
                Expiration = DateTime.MaxValue.Date,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.Listings.Add(new Listing()
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

            context.Listings.Add(new Listing()
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
                Location = "Liflandsgade 8 K�benhavn 2300",
                Latitude = 55.6608952,
                Longitude = 12.6031471,
                Active = true,
                Enabled = true,
                Expiration = DateTime.MaxValue.Date,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.Listings.Add(new Listing()
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
                Location = "Havnegade 43, st. th. K�benhavn K 1058",
                Latitude = 55.677783,
                Longitude = 12.591222,
                Active = true,
                Enabled = true,
                Expiration = DateTime.MaxValue.Date,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.Listings.Add(new Listing()
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
                Location = "Liflandsgade 8, 2300 K�benhavn",
                Latitude = 55.660869,
                Longitude = 12.603241,
                Active = true,
                Enabled = true,
                Expiration = DateTime.MaxValue.Date,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.Listings.Add(new Listing()
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
                Location = "Blegdamsvej 112A 2100 K�benhavn",
                Latitude = 55.697579,
                Longitude = 12.574109,
                Active = true,
                Enabled = true,
                Expiration = DateTime.MaxValue.Date,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.Listings.Add(new Listing()
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
                Location = "Blegdamsvej 84, St. tv , K�benhavn � 2100",
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
            context.ListingTypes.Add(new ListingType()
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

            context.SaveChanges();
        }

        private void InstallCategories(AuthContext context)
        {
            context.Categories.Add(new Category()
            {
                Name = "Massage",
                Description = "Massage",
                Parent = 0,
                Enabled = true,
                Ordering = 0,
                ObjectState = ObjectState.Added
            });

            context.Categories.Add(new Category()
            {
                Name = "Facial",
                Description = "Facial Care",
                Parent = 0,
                Enabled = true,
                Ordering = 1,
                ObjectState = ObjectState.Added
            });

            context.Categories.Add(new Category()
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
            context.CategoryListingTypes.Add(new CategoryListingType()
            {
                CategoryID = 1,
                ListingTypeID = 1,
                ObjectState = ObjectState.Added
            });

            context.CategoryListingTypes.Add(new CategoryListingType()
            {
                CategoryID = 2,
                ListingTypeID = 1,
                ObjectState = ObjectState.Added
            });

            context.CategoryListingTypes.Add(new CategoryListingType()
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
                context.Pictures.Add(new Picture()
                {
                    MimeType = "image/jpeg",
                    ObjectState = ObjectState.Added
                });

                context.SaveChanges();

                context.ListingPictures.Add(new ListingPicture()
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
            context.SettingDictionaries.Add(new SettingDictionary()
            {
                SettingID = 1,
                Name = "StripeApiKey",
                Value = "sk_test_kUNQFEh3YLbEFEa38tbeMJLV",
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.SettingDictionaries.Add(new SettingDictionary()
            {
                SettingID = 1,
                Name = "StripePublishableKey",
                Value = "pk_test_EfbP8SfcALEJ8Jk2JxtSxmqe",
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added
            });

            context.SettingDictionaries.Add(new SettingDictionary()
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

using System;
using System.Web.Routing;
using Plugin.Payment.Stripe.Data;
using Plugin.Payment.Stripe.Migrations;
using Registrators;
using Registrators.Plugins;
using Welic.Core;
using Welic.Dominio.Models.Marketplaces.Entityes;
using Welic.Dominio.Models.Marketplaces.Services;
using Welic.Dominio.Patterns.Pattern.Ef6;
using Welic.Dominio.Patterns.Repository.Pattern.Infrastructure;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;
using Welic.Infra.Extensions;

namespace Plugin.Payment.Stripe
{
    public class StripePlugin : HookBasePlugin
    {
        public const string PluginName = "Plugin.Payment.Stripe";

        public const string SettingStripeApiKey = "StripeApiKey";
        public const string SettingStripePublishableKey = "StripePublishableKey";
        public const string SettingStripeClientID = "StripeClientID";

        private readonly ISettingDictionaryService _settingDictionaryService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;        

        public enum Enum_StripeConnectStatus
        {
            None = 0,
            Authorized
        }

        public StripePlugin(
            ISettingDictionaryService settingDictionaryService,
            IUnitOfWorkAsync unitOfWorkAsync)
        {
            _settingDictionaryService = settingDictionaryService;
            _unitOfWorkAsync = unitOfWorkAsync;

            AddRoute(HookName.Payment, new RouteValueDictionary
                {
                    { "action", "Payment" }, 
                    { "controller", "PaymentStripe" }, 
                    { "namespaces", "Plugin.Payment.Stripe.Controllers"},
                    { "area", null},
                    { "hookName", HookName.Payment}
                });

            AddRoute(HookName.PaymentSetting, new RouteValueDictionary
                {
                    { "action", "PaymentSetting" }, 
                    { "controller", "PaymentStripe" }, 
                    { "namespaces", "Plugin.Payment.Stripe.Controllers"},
                    { "area", null},
                    { "hookName", HookName.PaymentSetting}
                });

            AddRoute(HookName.Transaction, new RouteValueDictionary
                {
                    { "action", "Transaction" }, 
                    { "controller", "PaymentStripe" }, 
                    { "namespaces", "Plugin.Payment.Stripe.Controllers"},
                    { "area", null},
                    { "hookName", HookName.Transaction}
                });

            AddRoute(HookName.TransactionOverview, new RouteValueDictionary
                {
                    { "action", "TransactionOverview" }, 
                    { "controller", "PaymentStripe" }, 
                    { "namespaces", "Plugin.Payment.Stripe.Controllers"},
                    { "area", null},
                    { "hookName", HookName.TransactionOverview}
                });

            AddRoute(HookName.Configuration, new RouteValueDictionary {                 
                { "action", "Configure" }, 
                { "controller", "PaymentStripe" }, 
                { "namespaces", "Plugin.Payment.Stripe.Controllers" }, 
                { "area", null } 
            });
        }

        public override Type GetControllerType()
        {
            return typeof(Plugin.Payment.Stripe.Controllers.PaymentStripeController);
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            // Initialize database
            System.Data.Entity.Database.SetInitializer(new StripeDatabaseInitializer());

            // initialize and create database
            using (var context = new StripeContext())
            {
                context.Database.Initialize(true);
                context.SaveChanges();
            }

            // Add settings
            _settingDictionaryService.Insert(new SettingDictionary()
            {
                Name = SettingStripeApiKey,
                Value = "sk_test_kUNQFEh3YLbEFEa38tbeMJLV",
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added,
                SettingID = CacheHelper.Settings.ID
            });

            _settingDictionaryService.Insert(new SettingDictionary()
            {
                Name = SettingStripePublishableKey,
                Value = "pk_test_EfbP8SfcALEJ8Jk2JxtSxmqe",
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added,
                SettingID = CacheHelper.Settings.ID
            });

            _settingDictionaryService.Insert(new SettingDictionary()
            {
                Name = SettingStripeClientID,
                Value = "ca_6Rh18px61rjCEZIav5ItunZ1mKD8YjvU",
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                ObjectState = ObjectState.Added,
                SettingID = CacheHelper.Settings.ID
            });

            _unitOfWorkAsync.SaveChanges();

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            // Remove settings
            var settings = _settingDictionaryService.Query(
                x => x.Name == SettingStripeApiKey ||
                     x.Name == SettingStripePublishableKey ||
                     x.Name == SettingStripeClientID).Select();

            foreach (var setting in settings)
            {
                _settingDictionaryService.Delete(setting);
            }

            _unitOfWorkAsync.SaveChanges();

            var context = new Plugin.Payment.Stripe.Data.StripeContext();
            context.DeletePluginData<StripeContext>();

            base.Uninstall();
        }
    }
}

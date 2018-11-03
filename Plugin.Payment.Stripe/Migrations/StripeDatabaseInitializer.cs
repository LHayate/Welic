using Plugin.Payment.Stripe.Data;
using Welic.Infra.Migrations;

namespace Plugin.Payment.Stripe.Migrations
{
    class StripeDatabaseInitializer : CreateAndMigrateDatabaseInitializer<StripeContext, ConfigurationInstall<StripeContext>>
    {
        #region Constructor
        // pass user model, and database info
        public StripeDatabaseInitializer()
            : base()
        {            
            InitializeDatabase(new StripeContext());
        }
        #endregion

        #region Methods
        protected override void Seed(StripeContext context)
        {
        }

        #endregion
    }
}

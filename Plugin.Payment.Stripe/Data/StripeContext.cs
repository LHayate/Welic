using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Plugin.Payment.Stripe.Data
{
    public class StripeContext : DataContext
    {
        static StripeContext()
        {
            Database.SetInitializer<StripeContext>(null);
        }

        public StripeContext()
            : base("Name=WelicDbContext")
        {
        }

        public DbSet<StripeConnect> StripeConnects { get; set; }
        public DbSet<StripeTransaction> StripeTransactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();            
            modelBuilder.Configurations.Add(new StripeConnectMap());
            modelBuilder.Configurations.Add(new StripeTransactionMap());
        }
    }
}

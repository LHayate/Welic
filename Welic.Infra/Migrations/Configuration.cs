using Welic.Dominio.Models.Users.Enums;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Utilitarios.Enums;
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
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AuthContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.GroupUser.SeedEnumValues<GroupUserMap, GroupUserEnum>(genum => genum);
            context.SaveChanges();
        }
    }
}

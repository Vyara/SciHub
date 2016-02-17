namespace SciHub.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SciHub.Data.DataSeeders;

    public sealed class Configuration : DbMigrationsConfiguration<SciHubDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SciHubDbContext context)
        {
            DataSeeder.SeedUserRoles(context);
            DataSeeder.SeedData(context);
            DataSeeder.SeedAdmin(context);
        }
    }
}

namespace SciHub.Web
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SciHubDbContext, Configuration>());
            SciHubDbContext.Create().Database.Initialize(true);
        }
    }
}
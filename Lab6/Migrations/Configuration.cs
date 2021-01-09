namespace Lab6.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lab6.data.db.prejectsEF.CodeFirst.ProjectsDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Lab6.data.db.prejectsEF.CodeFirst.ProjectsDatabaseContext";
        }

        protected override void Seed(Lab6.data.db.prejectsEF.CodeFirst.ProjectsDatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

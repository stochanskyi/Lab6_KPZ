namespace Lab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectDBv1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "customer_name", c => c.String(nullable: false, defaultValue: ""));
        }
        
        public override void Down()
        {
        }
    }
}

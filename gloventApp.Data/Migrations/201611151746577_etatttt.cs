namespace gloventApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class etatttt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.events", "etatt", c => c.Boolean(nullable: false));
            DropColumn("dbo.events", "etat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.events", "etat", c => c.Boolean(nullable: false));
            DropColumn("dbo.events", "etatt");
        }
    }
}

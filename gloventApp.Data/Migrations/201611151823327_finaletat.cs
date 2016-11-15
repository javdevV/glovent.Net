namespace gloventApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finaletat : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.events", "etatt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.events", "etatt", c => c.Boolean(nullable: false));
        }
    }
}

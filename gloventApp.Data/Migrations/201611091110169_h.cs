namespace gloventApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.hous",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.hous");
        }
    }
}

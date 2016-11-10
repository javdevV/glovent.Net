namespace gloventApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class houssemDelete : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.hous");
        }
        
        public override void Down()
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
    }
}

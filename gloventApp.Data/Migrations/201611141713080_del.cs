namespace gloventApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class del : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.testas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.testas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}

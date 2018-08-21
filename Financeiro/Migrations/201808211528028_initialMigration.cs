namespace Financeiro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classifications",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        value = c.Double(nullable: false),
                        date = c.DateTime(nullable: false),
                        classification_id = c.Int(),
                        source_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Classifications", t => t.classification_id)
                .ForeignKey("dbo.Sources", t => t.source_id)
                .Index(t => t.classification_id)
                .Index(t => t.source_id);
            
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "source_id", "dbo.Sources");
            DropForeignKey("dbo.Expenses", "classification_id", "dbo.Classifications");
            DropIndex("dbo.Expenses", new[] { "source_id" });
            DropIndex("dbo.Expenses", new[] { "classification_id" });
            DropTable("dbo.Sources");
            DropTable("dbo.Expenses");
            DropTable("dbo.Classifications");
        }
    }
}

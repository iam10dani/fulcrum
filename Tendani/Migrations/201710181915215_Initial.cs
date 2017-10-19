namespace Tendani.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assertions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Procedure_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Procedures", t => t.Procedure_Id)
                .Index(t => t.Procedure_Id);
            
            CreateTable(
                "dbo.ClientTools",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Procedure_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Procedures", t => t.Procedure_Id)
                .Index(t => t.Procedure_Id);
            
            CreateTable(
                "dbo.Industries",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Procedure_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Procedures", t => t.Procedure_Id)
                .Index(t => t.Procedure_Id);
            
            CreateTable(
                "dbo.SignificantAccounts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Procedure_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Procedures", t => t.Procedure_Id)
                .Index(t => t.Procedure_Id);
            
            CreateTable(
                "dbo.Solutions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Procedure_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Procedures", t => t.Procedure_Id)
                .Index(t => t.Procedure_Id);
            
            CreateTable(
                "dbo.ToolsUseds",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Procedure_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Procedures", t => t.Procedure_Id)
                .Index(t => t.Procedure_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToolsUseds", "Procedure_Id", "dbo.Procedures");
            DropForeignKey("dbo.Solutions", "Procedure_Id", "dbo.Procedures");
            DropForeignKey("dbo.SignificantAccounts", "Procedure_Id", "dbo.Procedures");
            DropForeignKey("dbo.Industries", "Procedure_Id", "dbo.Procedures");
            DropForeignKey("dbo.ClientTools", "Procedure_Id", "dbo.Procedures");
            DropForeignKey("dbo.Assertions", "Procedure_Id", "dbo.Procedures");
            DropIndex("dbo.ToolsUseds", new[] { "Procedure_Id" });
            DropIndex("dbo.Solutions", new[] { "Procedure_Id" });
            DropIndex("dbo.SignificantAccounts", new[] { "Procedure_Id" });
            DropIndex("dbo.Industries", new[] { "Procedure_Id" });
            DropIndex("dbo.ClientTools", new[] { "Procedure_Id" });
            DropIndex("dbo.Assertions", new[] { "Procedure_Id" });
            DropTable("dbo.ToolsUseds");
            DropTable("dbo.Solutions");
            DropTable("dbo.SignificantAccounts");
            DropTable("dbo.Industries");
            DropTable("dbo.ClientTools");
            DropTable("dbo.Assertions");
        }
    }
}

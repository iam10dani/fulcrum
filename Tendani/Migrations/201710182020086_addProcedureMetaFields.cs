namespace Tendani.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProcedureMetaFields : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ToolsUseds", newName: "ToolUseds");
            AddColumn("dbo.Assertions", "Name", c => c.String());
            AddColumn("dbo.ClientTools", "Name", c => c.String());
            AddColumn("dbo.ToolUseds", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToolUseds", "Name");
            DropColumn("dbo.ClientTools", "Name");
            DropColumn("dbo.Assertions", "Name");
            RenameTable(name: "dbo.ToolUseds", newName: "ToolsUseds");
        }
    }
}

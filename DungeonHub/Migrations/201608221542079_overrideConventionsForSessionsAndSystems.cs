namespace DungeonHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class overrideConventionsForSessionsAndSystems : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sessions", "GameSystem_Id", "dbo.GameSystems");
            DropForeignKey("dbo.Sessions", "GM_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Sessions", new[] { "GameSystem_Id" });
            DropIndex("dbo.Sessions", new[] { "GM_Id" });
            AlterColumn("dbo.GameSystems", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Sessions", "Location", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Sessions", "GameSystem_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Sessions", "GM_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Sessions", "GameSystem_Id");
            CreateIndex("dbo.Sessions", "GM_Id");
            AddForeignKey("dbo.Sessions", "GameSystem_Id", "dbo.GameSystems", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sessions", "GM_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "GM_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sessions", "GameSystem_Id", "dbo.GameSystems");
            DropIndex("dbo.Sessions", new[] { "GM_Id" });
            DropIndex("dbo.Sessions", new[] { "GameSystem_Id" });
            AlterColumn("dbo.Sessions", "GM_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Sessions", "GameSystem_Id", c => c.Byte());
            AlterColumn("dbo.Sessions", "Location", c => c.String());
            AlterColumn("dbo.GameSystems", "Name", c => c.String());
            CreateIndex("dbo.Sessions", "GM_Id");
            CreateIndex("dbo.Sessions", "GameSystem_Id");
            AddForeignKey("dbo.Sessions", "GM_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Sessions", "GameSystem_Id", "dbo.GameSystems", "Id");
        }
    }
}

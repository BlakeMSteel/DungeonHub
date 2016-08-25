namespace DungeonHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToSession : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Sessions", name: "GameSystem_Id", newName: "GameSystemId");
            RenameColumn(table: "dbo.Sessions", name: "GM_Id", newName: "GMId");
            RenameIndex(table: "dbo.Sessions", name: "IX_GM_Id", newName: "IX_GMId");
            RenameIndex(table: "dbo.Sessions", name: "IX_GameSystem_Id", newName: "IX_GameSystemId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Sessions", name: "IX_GameSystemId", newName: "IX_GameSystem_Id");
            RenameIndex(table: "dbo.Sessions", name: "IX_GMId", newName: "IX_GM_Id");
            RenameColumn(table: "dbo.Sessions", name: "GMId", newName: "GM_Id");
            RenameColumn(table: "dbo.Sessions", name: "GameSystemId", newName: "GameSystem_Id");
        }
    }
}

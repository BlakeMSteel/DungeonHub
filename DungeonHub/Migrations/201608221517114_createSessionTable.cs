namespace DungeonHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class createSessionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameSystems",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Location = c.String(),
                        GameSystem_Id = c.Byte(),
                        GM_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameSystems", t => t.GameSystem_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.GM_Id)
                .Index(t => t.GameSystem_Id)
                .Index(t => t.GM_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "GM_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sessions", "GameSystem_Id", "dbo.GameSystems");
            DropIndex("dbo.Sessions", new[] { "GM_Id" });
            DropIndex("dbo.Sessions", new[] { "GameSystem_Id" });
            DropTable("dbo.Sessions");
            DropTable("dbo.GameSystems");
        }
    }
}

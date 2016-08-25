namespace DungeonHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        SessionId = c.Int(nullable: false),
                        PlayerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SessionId, t.PlayerId })
                .ForeignKey("dbo.AspNetUsers", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.SessionId)
                .Index(t => t.SessionId)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.Attendances", "PlayerId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "PlayerId" });
            DropIndex("dbo.Attendances", new[] { "SessionId" });
            DropTable("dbo.Attendances");
        }
    }
}

namespace DungeonHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class populateGameSystems : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GameSystems (Id, Name) VALUES (1, 'Original Dungeons & Dragons')");
            Sql("INSERT INTO GameSystems (Id, Name) VALUES (2, 'Advanced Dungeons & Dragons')");
            Sql("INSERT INTO GameSystems (Id, Name) VALUES (3, 'Advanced Dungeons & Dragons 2nd edition')");
            Sql("INSERT INTO GameSystems (Id, Name) VALUES (4, 'Advanced Dungeons & Dragons 2nd edition revised')");
            Sql("INSERT INTO GameSystems (Id, Name) VALUES (5, 'Dungeons & Dragons 3rd edition')");
            Sql("INSERT INTO GameSystems (Id, Name) VALUES (6, 'Dungeons & Dragons revised 3rd edition (v3.5)')");
            Sql("INSERT INTO GameSystems (Id, Name) VALUES (7, 'Dungeons & Dragons 4th edition')");
            Sql("INSERT INTO GameSystems (Id, Name) VALUES (8, 'Dungeons & Dragons Essentials')");
            Sql("INSERT INTO GameSystems (Id, Name) VALUES (9, 'Dungeons & Dragons 5th Edition')");

        }
        
        public override void Down()
        {
            Sql("DELETE FROM GameSystems WHERE Id IN (1, 2, 3, 4, 5, 6, 7, 8, 9)");
        }
    }
}

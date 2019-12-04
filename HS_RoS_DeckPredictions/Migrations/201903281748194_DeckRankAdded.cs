namespace HS_RoS_DeckPredictions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeckRankAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Decks", "Rank", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Decks", "Rank");
        }
    }
}

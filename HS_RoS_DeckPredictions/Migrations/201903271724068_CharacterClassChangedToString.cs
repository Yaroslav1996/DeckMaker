namespace HS_RoS_DeckPredictions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CharacterClassChangedToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cards", "CardClass", c => c.String());
            AlterColumn("dbo.Decks", "DeckClass", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Decks", "DeckClass", c => c.Int(nullable: false));
            AlterColumn("dbo.Cards", "CardClass", c => c.Int(nullable: false));
        }
    }
}

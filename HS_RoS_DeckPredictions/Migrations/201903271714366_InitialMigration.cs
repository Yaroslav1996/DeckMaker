namespace HS_RoS_DeckPredictions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Int(nullable: false),
                        CardClass = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardId);
            
            CreateTable(
                "dbo.Decks",
                c => new
                    {
                        DeckId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DeckType = c.String(),
                        DeckClass = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeckId);
            
            CreateTable(
                "dbo.DeckCards",
                c => new
                    {
                        DeckId = c.Int(nullable: false),
                        CardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DeckId, t.CardId })
                .ForeignKey("dbo.Decks", t => t.DeckId, cascadeDelete: true)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .Index(t => t.DeckId)
                .Index(t => t.CardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeckCards", "CardId", "dbo.Cards");
            DropForeignKey("dbo.DeckCards", "DeckId", "dbo.Decks");
            DropIndex("dbo.DeckCards", new[] { "CardId" });
            DropIndex("dbo.DeckCards", new[] { "DeckId" });
            DropTable("dbo.DeckCards");
            DropTable("dbo.Decks");
            DropTable("dbo.Cards");
        }
    }
}

namespace HS_RoS_DeckPredictions.Migrations
{
    using HS_RoS_DeckPredictions.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HS_RoS_DeckPredictions.Models.DeckPredisctionsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HS_RoS_DeckPredictions.Models.DeckPredisctionsDbContext context)
        {
            Deck SecretPally = new Deck()
            {
                DeckId = 1,
                Name = "Secret Paladin",
                DeckType = "Tempo",
                DeckClass = "Paladin",
                Rank = 4
            };

            Card CommanderRhyssa = new Card()
            {
                CardId = 1,
                Name = "Commander Rhyssa",
                Cost = 3,
                CardClass = "Paladin"
            };

            SecretPally.Cards.Add(CommanderRhyssa);
            CommanderRhyssa.Decks.Add(SecretPally);

            context.Decks.AddOrUpdate(x => x.DeckId, SecretPally);
            context.Cards.AddOrUpdate(x => x.CardId, CommanderRhyssa);
        }
    }
}

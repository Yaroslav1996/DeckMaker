namespace HS_RoS_DeckPredictions.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DeckPredisctionsDbContext : DbContext
    {
        public DeckPredisctionsDbContext()
            : base("name=DeckPredisctionsDbContext")
        {
        }


        public DbSet<Deck> Decks { get; set; }
        public DbSet<Card> Cards { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deck>().
                HasMany<Card>(d => d.Cards).
                WithMany(c => c.Decks).
                Map(dc =>
                {
                    dc.MapLeftKey("DeckId");
                    dc.MapRightKey("CardId");
                    dc.ToTable("DeckCards");
                });

            modelBuilder.Entity<Deck>().HasKey(d => d.DeckId);
            modelBuilder.Entity<Card>().HasKey(c => c.CardId);
        }
    }
}
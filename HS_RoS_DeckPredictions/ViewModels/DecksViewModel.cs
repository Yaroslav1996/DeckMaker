using HS_RoS_DeckPredictions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HS_RoS_DeckPredictions.ViewModels
{
    public class DecksViewModel
    {
        public DecksViewModel(List<Card> cards, List<Deck> decks)
        {
            Cards = cards;
            Decks = decks;
        }

        
        public List<Card> Cards { get; set; }
        public List<Deck> Decks { get; set; }
    }
}
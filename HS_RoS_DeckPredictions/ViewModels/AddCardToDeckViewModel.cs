using HS_RoS_DeckPredictions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HS_RoS_DeckPredictions.ViewModels
{
    public class AddCardToDeckViewModel
    {
        public AddCardToDeckViewModel()
        {

        }

        public AddCardToDeckViewModel(Deck deck, List<Card> cards)
        {
            Deck = deck;
            Cards = cards;
        }

        public Deck Deck { get; set; }
        public int CardId { get; set; }
        public List<Card> Cards { get; set; }
    }
}
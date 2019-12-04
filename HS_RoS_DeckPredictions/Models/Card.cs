using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HS_RoS_DeckPredictions.Models;
using System.ComponentModel.DataAnnotations;

namespace HS_RoS_DeckPredictions.Models
{
    public class Card
    {
        public Card()
        {
            this.Decks = new HashSet<Deck>();
        }
        
        public int CardId { get; set; }
        
        public string Name { get; set; }

        [Display(Name = "Cost")]
        public int Cost { get; set; }

        [Display(Name = "Class")]
        public string CardClass { get; set; }

        public virtual ICollection<Deck> Decks { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
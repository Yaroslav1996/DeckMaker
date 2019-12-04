using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HS_RoS_DeckPredictions.Models
{
    public class Deck
    {
        public Deck()
        {
            this.Cards = new HashSet<Card>();
        }

        public int DeckId { get; set; }
        
        public string Name { get; set; }

        [Display(Name = "Type")]
        public string DeckType { get; set; }

        [Display(Name = "Class")]
        public string DeckClass { get; set; }

        [Display(Name = "Rank")]
        public int Rank { get; set; }

        public virtual ICollection<Card> Cards { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HS_RoS_DeckPredictions.Models;
using HS_RoS_DeckPredictions.ViewModels;
using System.Data.Entity;

namespace HS_RoS_DeckPredictions.Controllers
{
    public class HomeController : Controller
    {
        private DeckPredisctionsDbContext _context;

        public HomeController()
        {
            _context = new DeckPredisctionsDbContext();
        }

        public ActionResult Index()
        {
            DecksViewModel viewModel = new DecksViewModel(_context.Cards.ToList(), _context.Decks.ToList());

            return View(viewModel);
        }

        public ActionResult Cards()
        {
            DecksViewModel viewModel = new DecksViewModel(_context.Cards.ToList(), _context.Decks.ToList());

            return View(viewModel);
        }

        public ActionResult CardsInDeck(int? deckId)
        {
            DecksViewModel viewModel = new DecksViewModel(_context.Decks.Where(s => s.DeckId == deckId).Single().Cards.ToList(), new List<Deck>() { _context.Decks.Single(p => p.DeckId == deckId)});

            return View("Cards", viewModel);
        }

        public ActionResult NewCard()
        {
            Card newCard = new Card()
            {
                CardId = 0
            };

            return View(newCard);
        }

        [HttpPost]
        public ActionResult SaveCard(Card card)
        {
            if (card.CardId == 0)
            {
                _context.Cards.Add(card);
                _context.SaveChanges();
            }

            return RedirectToAction("Cards");
        }

        public ActionResult NewDeck()
        {
            Deck newDeck = new Deck()
            {
                DeckId = 0
            };

            return View(newDeck);
        }

        [HttpPost]
        public ActionResult SaveDeck(Deck deck)
        {
            if (deck.DeckId == 0)
            {
                _context.Decks.Add(deck);
                _context.SaveChanges();
            }
            else if (_context.Decks.Where(d => d.DeckId == deck.DeckId).Count() == 1)
            {
                Deck editedDeck = _context.Decks.First(d => d.DeckId == deck.DeckId);

                editedDeck.Name = deck.Name;
                editedDeck.DeckType = deck.DeckType;
                editedDeck.DeckClass = deck.DeckClass;
                editedDeck.Rank = deck.Rank;

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult EditDeck(Deck deck)
        {
            return View("NewDeck", deck);
        }

        public ActionResult DeleteDeck(int? deckId)
        {
            if (_context.Decks.Where(d => d.DeckId == deckId).Count() == 1)
            {
                Deck deck = _context.Decks.First(d => d.DeckId == deckId);
                _context.Decks.Remove(deck);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Error");
        }

        public ActionResult AddCardTo(Deck deck)
        {
            Deck dd = _context.Decks.ToList().Where(d => d.DeckId == deck.DeckId).Single();

            List<Card> cd = _context.Cards.ToList().Where(c => !dd.Cards.Contains(c)).Where(c => c.CardClass == dd.DeckClass || c.CardClass == "Neutral").ToList();

            AddCardToDeckViewModel model = new AddCardToDeckViewModel(dd, cd);
            return View(model);
        }


        [HttpPost]
        public ActionResult AddCard(AddCardToDeckViewModel model)
        {
            Deck dd = _context.Decks.Single(d => d.DeckId == model.Deck.DeckId);

            dd.Cards.Add(_context.Cards.Single(c => c.CardId == model.CardId));
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult CancelDeckEdit()
        {
            return RedirectToAction("Index");
        }
    }
}
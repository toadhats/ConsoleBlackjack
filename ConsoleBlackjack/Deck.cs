using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    public class Deck
    {
        private static readonly Random rng = new Random(); // One RNG to rule them all. Or maybe I need an even more monolithic RNG in the game manager?
        private Stack<Card> cards;

        public Deck()
        {
            // Create all the cards for the deck, "shuffle" them, and transform to a stack
            cards = ShuffleCards(CreateCards());
        }

        // Draw a card out of the deck and return it
        public Card DrawCard()
        {
            if (cards.Count > 0)
            {
                return cards.Pop();
            }
            else
            {
                // Move this logic elsewhere once everything is actually working
                Console.WriteLine("We're out of cards - reshuffling the deck.");
                cards = ShuffleCards(CreateCards());
                return cards.Pop();
            }
        }

        // Check how many cards are left in the deck, could be used to display this info to the
        // player (eg a visual representation of the thickness of the deck)
        public int CountRemainingCards()
        {
            return cards.Count;
        }

        // Creates a list containing an instance of each card. Used when constructing a deck.
        public static List<Card> CreateCards()
        {
            List<Card> cards = new List<Card>();
            // Iterate over the suits
            for (var suit = 0; suit <= 3; ++suit)
            {
                // Iterate over the ranks. MUST index from 1 beacuse I decided to map Ace to 1 (and
                // NOT zero).
                for (var rank = 1; rank <= 13; ++rank)
                {
                    Card c = new Card(suit, rank);
                    cards.Add(c);
                }
            }

            // Returns a list of cards in suit and rank order
            return cards;
        }

        // Accepts the output of CreateCards() and returns the Stack<Card> that a 'Deck' in the game
        // will actually be backed by. I wanted to order by random because it's a hilariously simple
        // approach but it ultimately doesn't seem like a good idea. I don't want a Fisher-Yates in
        // place shuffle, because we're not going to use this list again - I'm just going to grab
        // random cards one by one until there are none left in the original ordered list.
        public static Stack<Card> ShuffleCards(List<Card> cards)
        {
            List<Card> toShuffle = cards; // I don't want to mutate the input list but I can't articulate why
            List<Card> shuffled = new List<Card>();
            while (toShuffle.Count > 0)
            {
                int index = rng.Next(0, toShuffle.Count);
                shuffled.Add(toShuffle[index]);
                toShuffle.RemoveAt(index);
            }

            return new Stack<Card>(shuffled);
        }
    }
}

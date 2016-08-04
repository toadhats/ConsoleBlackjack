using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    public class Card
    {
        private Suit suit;
        private Rank rank;

        // Compulsively creating a default constructor - this would only become useful if I tried to
        // serialise the cards or something.
        private Card()
        {
        }

        // Instantiates a card of the given suit and rank, e.g. Card(0, 1) is the ace of spades,
        // Card(3, 13) is the king of clubs.
        public Card(int suit, int rank)
        {
            this.suit = (Suit)suit;
            this.rank = (Rank)rank;
        }

        // Construct a card of named suit and rank with strings. Not for "production" since cards
        // will always come out of a RNG.
        public Card(string suit, string rank)
        {
            this.suit = (Suit)Enum.Parse(typeof(Suit), suit, true); // the third boolean argument makes Enum.Parse() ignore case
            this.rank = (Rank)Enum.Parse(typeof(Rank), rank, true);
        }

        public enum Suit
        {
            Spades, Hearts, Diamonds, Clubs
        }

        // Indexing from 1 for a slightly more natural mapping of rank to point value - indexing
        // enums from 1 isn't necessarily recommended and might need to change if it causes actual
        // headaches later
        public enum Rank
        {
            Ace = 1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack, // id is 11
            Queen, // 12
            King //13
        }

        // Returns the point value of the card - corresponds to rank up to 10, and then we take the
        // min to cap it there. Ace is 1 by default, need to handle whether to make it 10 elsewhere,
        // in the logic where we add up the points.
        public int GetValue()
        {
            return Math.Min(10, (int)rank);
        }

        public override string ToString()
        {
            return String.Format("{0} of {1}", rank.ToString(), suit.ToString());
        }
    }
}

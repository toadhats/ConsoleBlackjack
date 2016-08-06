using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    internal class Hand
    {
        private List<Card> cards; // Should this just be a field instead? I guess no because that would be inconsistent.

        public int Value
        {
            get
            {
                value = 0; // Should I even be treating the hand value as a property if I'm recalculating it every time?
                bool hasAce = false;
                foreach (Card card in Cards)
                {
                    if (card.rank == (Card.Rank)1) // Ace = 1 in the rank enum remember
                    {
                        hasAce = true;
                    }
                    value += card.GetValue();
                }
                // If making an ace high doesn't bust, we want to do that.
                if (hasAce && (value + 10 <= 21))
                {
                    return value + 10;
                }
                else return value;
            }

            // setter cannot be used because value is computed - what's best practice in this situation?
            set
            {
                this.value = value;
            }
        }

        public List<Card> Cards
        {
            get
            {
                return cards;
            }

            set
            {
                cards = value;
            }
        }

        private int value;

        public Hand()
        {
            Cards = new List<Card>(11); // 11 is the largest possible hand of cards in blackjack - is making the size explicit even useful though?
            Value = 0;
        }

        public void AddCardToHand(Card c)
        {
            Cards.Add(c);
        }

        // Experiment - making Hand indexable like an array, e.g. hand[0]
        public Card this[int index]
        {
            get
            {
                return Cards[index];
            }
        }
    }
}

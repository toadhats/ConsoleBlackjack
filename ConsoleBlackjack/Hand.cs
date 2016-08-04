using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    internal class Hand
    {
        private List<Card> Cards { get; set; } // Is it even worth using properties or am i just cargo culting

        public int Value
        {
            get
            {
                value = 0; // Reset value to 0 temporaily - this whole thing sucks and should probably be refactored, why even store the value if we recalculate it every time it's needed?
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

            set
            {
                this.value = value;
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

        // Not using this anymore delete it once I'm confident
        //private Boolean CheckForAce()
        //{
        //    foreach (Card card in Cards)
        //    {
        //        if (card.rank == (Card.Rank)1)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}

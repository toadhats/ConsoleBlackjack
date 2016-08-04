using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    internal class Player
    {
        private int Chips { get; set; }
        private Hand hand { get; } // To allow splitting, player is going to need to have more than one hand...

        public Player()
        {
            Chips = 0;
            hand = new Hand();
        }

        public Player(int chips)
        {
            Chips = chips;
            hand = new Hand();
        }

        public int AddChips(int n)
        {
            Chips += n;
            return Chips;
        }

        public int RemoveChips(int n)
        {
            Chips = Math.Abs(Chips - n); // Chips can't be negative.
            return Chips;
        }

        // Returns the new value of the hand after receiving a card
        public int ReceiveCard(Card c)
        {
            hand.AddCardToHand(c);
            return hand.Value;
        }

        // Not sure if I'll need this on its own...
        public int GetHandValue()
        {
            return hand.Value;
        }
    }
}

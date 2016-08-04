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
        private Hand hand;

        public Player()
        {
            Chips = 0;
            hand = new Hand();
        }

        public AddChips(int n)
        {
            Chips += n;
        }

        public RemoveChips(int n)
        {
            Chips = Math.Abs(Chips - n); // Chips can't be negative.
        }
    }
}

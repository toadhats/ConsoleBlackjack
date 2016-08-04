using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    internal class GameManager
    {
        private Dealer dealer;
        private Player player;
        private Deck deck;

        // Gameplay variables
        public int startingChips = 1000;

        public GameManager()
        {
            dealer = new Dealer();
            player = new Player(startingChips);
            deck = new Deck();
        }
    }
}

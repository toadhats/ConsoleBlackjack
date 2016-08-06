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
        private int startingChips = 1000;

        public GameManager()
        {
            deck = new Deck();
            dealer = new Dealer(deck);
            player = new Player(startingChips);
        }
    }
}

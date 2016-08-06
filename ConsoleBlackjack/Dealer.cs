using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    internal class Dealer
    {
        private Hand hand { get; }
        private Deck deck;

        // This could be variable, allowing different house rules
        private int dealerStands = 17;

        public Dealer(Deck deck)
        {
            hand = new Hand();
            this.deck = deck;
        }

        // With better use of polymorphism/inheritance I could simplify these methods and reduce
        // repetition - but it would add significant complexity without achieving very much.

        public void DealSelf()
        {
            hand.AddCardToHand(deck.DrawCard());
            hand.AddCardToHand(deck.DrawCard());
        }

        public void DealPlayer(Player player)
        {
            player.ReceiveCard(deck.DrawCard());
            player.ReceiveCard(deck.DrawCard());
        }

        public void HitSelf()
        {
            hand.AddCardToHand(deck.DrawCard());
        }

        public void HitPlayer(Player player)
        {
            player.ReceiveCard(deck.DrawCard());
        }

        // I'd need to refactor this if I wanted to allow flexible rules
        public void Play()
        {
            while (hand.Value < dealerStands)
            {
                HitSelf();
            }
        }

        // Not sure if I'll need this on its own...
        public int GetHandValue()
        {
            return hand.Value;
        }
    }
}

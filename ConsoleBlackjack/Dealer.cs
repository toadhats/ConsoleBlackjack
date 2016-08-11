using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    internal class Dealer
    {
        private Hand Hand { get; }
        private Deck Deck { set; get; }

        // This could be variable, allowing different house rules
        private int dealerStands = 17;

        public Dealer(Deck deck)
        {
            Hand = new Hand();
            Deck = deck;
        }

        // With better use of polymorphism/inheritance I could simplify these methods and reduce
        // repetition - but it would add significant complexity without achieving very much.

        public void DealSelf()
        {
            Hand.AddCardToHand(Deck.DrawCard());
            Hand.AddCardToHand(Deck.DrawCard());
        }

        public void DealPlayer(Player player)
        {
            player.ReceiveCard(Deck.DrawCard());
            player.ReceiveCard(Deck.DrawCard());
        }

        public void HitSelf()
        {
            Hand.AddCardToHand(Deck.DrawCard());
        }

        public void HitPlayer(Player player)
        {
            player.ReceiveCard(Deck.DrawCard());
        }

        // I'd need to refactor this if I wanted to allow flexible rules, eg hitting differently on
        // soft hands
        public void Play()
        {
            while (Hand.Value < dealerStands)
            {
                HitSelf();
            }
        }

        // This feels better than accessing Dealer.Hand.Value from the GameManager
        public int GetHandValue()
        {
            return Hand.Value;
        }
    }
}
